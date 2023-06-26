using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public CategoryDTO Create(CategoryDTO obj)
        {
            Category category = new Category
            {
                Id = obj.Id,
                Name = obj.Name,
                CreatedDate = DateTime.Now
            };
            _db.Add(category);
            _db.SaveChanges();
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Update(CategoryDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
