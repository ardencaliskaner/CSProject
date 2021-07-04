using CSProject.Dto.DataDto;
using CSProject.Basket.Data.Repository.Interfaces;
using CSProject.Basket.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using CSProject.Dto.DataDto.Request;
using CSProject.Dto.ApiModel.Response;
using CSProject.Dto.ApiModel.Request;
using CSProject.Basket.Services.ApiService.Contracts;
using System.Linq;

namespace CSProject.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketProductRepository _basketProductRepository;
        private readonly IProductApiService _productApiService;


        public BasketService(IBasketRepository basketRepository, IBasketProductRepository basketProductRepository, IProductApiService productApiService)
        {
            _basketRepository = basketRepository;
            _basketProductRepository = basketProductRepository;
            _productApiService = productApiService;
        }

        public async Task<List<BasketReponseModel>> GetAll()
        {
            var basketEntites = await _basketRepository.GetAll().ConfigureAwait(false);
            return Mapper.Map<List<BasketReponseModel>>(basketEntites);
        }

        public async Task<ClientBasketResponseModel> AddToBasket(AddBasketRequest addBasketRequest)
        {
            // Check product stock
            var product = await CheckProductStock(addBasketRequest.ProductId, addBasketRequest.Quantity);

            // If client doesnt have basket create new
            var basket = await GetOrSetClientBasket(addBasketRequest.ClientId);

            //Check client basket to prevent to add more than stock
            bool canClientAddToBasket = await CheckClientBasketQuantityOfProduct(addBasketRequest.ClientId, product.Id, addBasketRequest.Quantity, product.Stock);

            if (canClientAddToBasket)
            {
                var basketProduct = await AddProductToBasket(basket.Id, product.Id, addBasketRequest.Quantity);
            }

            var clientBasketProductIds = await _basketProductRepository.GetBasketProductIds(basket.Id);

            List<ProductRequestModel> productRequestModels = clientBasketProductIds.Select(x => new ProductRequestModel
            {
                Id = x
            }).ToList();

            var productResponseModel = await GetClientBasketProducts(productRequestModels);

            var basketProducts = await _basketProductRepository.GetAllWithBasketId(basket.Id).ConfigureAwait(false);

            var clientBasketResponseModel = new ClientBasketResponseModel
            {
                ClientId = basket.ClientId,
                BasketId = basket.Id,
                Products = productResponseModel.Select(x => new BasketProductResponseModel
                {
                    ProductId = x.ProductId,
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    Stock = x.Stock,
                    IsActive = x.IsActive,
                    IsDeleted = x.IsDeleted,
                    Price = x.Price,
                    ProductName = x.Name,
                    BasketQuantity = basketProducts.FirstOrDefault(y => y.ProductId == x.ProductId)?.Quantity ?? 0
                }).ToList()
            };

            return clientBasketResponseModel;
        }


        private async Task<BasketDto> GetOrSetClientBasket(int clientId)
        {
            var basketEntity = await _basketRepository.CheckClientBasket(clientId);

            if (basketEntity != null)
            {
                return Mapper.Map<BasketDto>(basketEntity);
            }

            basketEntity = await _basketRepository.CreateBasket(clientId);

            return Mapper.Map<BasketDto>(basketEntity);

        }

        private async Task<ProductDto> CheckProductStock(int productId, int quantity)
        {
            var productStockRequestModel = new ProductStockRequestModel { ProductId = productId };

            ApiResponse<ProductStockResponseModel> apiResponse = await _productApiService.GetProductStock(productStockRequestModel);

            if (apiResponse.Data != null)
            {
                var product = Mapper.Map<ProductDto>(apiResponse.Data);

                if (product.Stock >= quantity)
                {
                    return product;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private async Task<List<ProductResponseModel>> GetClientBasketProducts(List<ProductRequestModel> productRequestModels)
        {
            var apiResponse = await _productApiService.GetClientBasketProducts(productRequestModels);

            return apiResponse.Data;
        }

        private async Task<BasketProductDto> AddProductToBasket(int basketId, int productId, int quantity)
        {
            var basketProduct = await _basketProductRepository.GetWithBasketAndProductId(basketId, productId).ConfigureAwait(false);

            var basketProductEntity = default(Data.ORM.Model.BasketProduct);

            if (basketProduct != null)
            {
                var totalQunatity = quantity + basketProduct.Quantity;

                basketProductEntity = await _basketProductRepository.UpdateBasketProduct(basketId, productId, totalQunatity).ConfigureAwait(false);
            }
            else
            {
                basketProductEntity = await _basketProductRepository.AddBasketProduct(basketId, productId, quantity).ConfigureAwait(false);
            }

            return Mapper.Map<BasketProductDto>(basketProductEntity);
        }


        private async Task<bool> CheckClientBasketQuantityOfProduct(int basketId, int productId, int quantity, int productStock)
        {
            var basketProduct = await _basketProductRepository.GetWithBasketAndProductId(basketId, productId).ConfigureAwait(false);

            if (basketProduct != null)
            {
                var currentQuantity = basketProduct.Quantity;

                return currentQuantity + quantity <= productStock;

            }

            return true;

        }

    }
}
