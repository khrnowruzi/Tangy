using AutoMapper;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess.Data;
using Tangy_DataAccess;
using Tangy_Models;
using Microsoft.EntityFrameworkCore;

namespace Tangy_Business.Repository
{
    public class ProductPriceRepository : IProductPriceRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductPriceRepository(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public async Task<ProductPriceDTO> Create(ProductPriceDTO objDTO)
        {
            var obj = _mapper.Map<ProductPriceDTO, ProductPrice>(objDTO);

            var addedObj = _db.ProductPrices.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductPrice, ProductPriceDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var objFromDb = await _db.ProductPrices.FirstOrDefaultAsync(productPrice => productPrice.Id == id);
            if (objFromDb != null)
            {
                _db.ProductPrices.Remove(objFromDb);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProductPriceDTO> Get(int id)
        {
            var objFromDb = await _db.ProductPrices
                .Include(prodcutPrice => prodcutPrice.Product)
                .FirstOrDefaultAsync(productPrice => productPrice.Id == id);
            if (objFromDb != null)
            {
                return _mapper.Map<ProductPrice, ProductPriceDTO>(objFromDb);
            }
            return new ProductPriceDTO();
        }

        public async Task<IEnumerable<ProductPriceDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>
                (_db.ProductPrices.Include(productPrice => productPrice.Product));
        }

        public async Task<ProductPriceDTO> Update(ProductPriceDTO objDTO)
        {
            var objFromDb = await _db.ProductPrices.FirstOrDefaultAsync(productPrice => productPrice.Id == objDTO.Id);

            if (objFromDb != null)
            {
                objFromDb.Price = objDTO.Price;
                objFromDb.Size = objDTO.Size;
                objFromDb.ProductId = objDTO.ProductId;

                _db.ProductPrices.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<ProductPrice, ProductPriceDTO>(objFromDb);
            }

            return objDTO;
        }
    }
}
