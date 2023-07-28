using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<CategoryDTO> Create(CategoryDTO obj);
        Task<CategoryDTO> Update(CategoryDTO obj);
        Task<int> Delete(int id);
        Task<CategoryDTO> Get(int id);
        Task<IEnumerable<CategoryDTO>> GetAll();
    }
}
