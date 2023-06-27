using AutoMapper;
using System.Security.Cryptography;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public CategoryDTO Create(CategoryDTO objDTO)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
            obj.CreatedDate = DateTime.Now;

            var addedObj = _db.Categories.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        public int Delete(int id)
        {
            var objFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (objFromDb != null)
            {
                _db.Categories.Remove(objFromDb);
                return _db.SaveChanges();
            }
            return 0;
        }

        public CategoryDTO Get(int id)
        {
            var objFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (objFromDb != null)
            {
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            else
            {
                return new CategoryDTO();
            }
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            var objFromDb = _db.Categories.FirstOrDefault(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                _db.Categories.Update(objFromDb);
                _db.SaveChanges();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            else
            {
                return new CategoryDTO();
            }
        }
    }
}
