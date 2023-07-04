using Tangy_Models;

namespace TangyWeb_Client.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> Get(int productId);
    }
}
