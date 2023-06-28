using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<ProductDTO> Create(ProductDTO obj);
        Task<ProductDTO> Update(ProductDTO obj);
        Task<int> Delete(int id);
        Task<ProductDTO> Get(int id);
        Task<IEnumerable<ProductDTO>> GetAll();
    }
}
