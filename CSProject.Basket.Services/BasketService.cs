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

        public async Task<List<BasketDto>> GetAll()
        {
            var basketEntites = await _basketRepository.GetAll().ConfigureAwait(false);
            return Mapper.Map<List<BasketDto>>(basketEntites);
        }

        public async Task<ClientBasketResponseModel> AddToBasket(AddBasketRequest addBasketRequest)
        {
            var product = await CheckProductStock(addBasketRequest.ProductId, addBasketRequest.Quantity);

            var basket = await GetOrSetClientBasket(addBasketRequest.ClientId);

            //Check Client Basket Product

            var basketProduct = await AddProductToBasket(product.Id, product.Id, addBasketRequest.Quantity);

            var clientBasketProductIds = await _basketProductRepository.GetBasketProductIds(basket.Id);


            List<ProductRequestModel> productRequestModels = clientBasketProductIds.Select(x => new ProductRequestModel
            {
                Id = x
            }).ToList();


            var clientBasketResponseModel = new ClientBasketResponseModel
            {
                ClientId = basket.ClientId,
                BasketId = basket.Id,
                Products = await GetClientBasketProducts(productRequestModels)
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
            var basketProductEntity = await _basketProductRepository.AddBasketProduct(basketId, productId, quantity).ConfigureAwait(false);

            return Mapper.Map<BasketProductDto>(basketProductEntity);
        }

    }
}
