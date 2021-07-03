namespace CSProject.Product.Services.Interfaces
{
    public interface IProductService
    {
        int GetByProductId(string productname);

        void SeedData();
    }
}
