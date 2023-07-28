using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface IProductPriceRepository
    {
        Task<ProductPriceDTO> Create(ProductPriceDTO obj);
        Task<ProductPriceDTO> Update(ProductPriceDTO obj);
        Task<int> Delete(int id);
        Task<ProductPriceDTO> Get(int id);
        Task<IEnumerable<ProductPriceDTO>> GetAll(int? productId = null);
    }
}
