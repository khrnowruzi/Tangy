﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        //-------------------------------------------------------------------------------------
        public async Task<CategoryDTO> Create(CategoryDTO objDTO)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
            obj.CreatedDate = DateTime.Now;

            var addedObj = await _db.Categories.AddAsync(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        //-------------------------------------------------------------------------------------
        public async Task<int> Delete(int id)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(category => category.Id == id);
            if (objFromDb != null)
            {
                _db.Categories.Remove(objFromDb);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        //-------------------------------------------------------------------------------------
        public async Task<CategoryDTO> Get(int id)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(category => category.Id == id);
            if (objFromDb != null)
            {
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            return new CategoryDTO();
        }

        //-------------------------------------------------------------------------------------
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        //-------------------------------------------------------------------------------------
        public async Task<CategoryDTO> Update(CategoryDTO objDTO)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(category => category.Id == objDTO.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                _db.Categories.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }

            return objDTO;
        }
    }
}
