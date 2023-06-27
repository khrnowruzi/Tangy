using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDTO> Create(CategoryDTO obj);
        public Task<CategoryDTO> Update(CategoryDTO obj);
        public Task<int> Delete(int id);
        public Task<CategoryDTO> Get(int id);
        public Task<IEnumerable<CategoryDTO>> GetAll();
    }
}
