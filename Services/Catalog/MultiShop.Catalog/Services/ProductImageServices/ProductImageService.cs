﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);

            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);

            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto productImageDto)
        {
            var value = _mapper.Map<ProductImage>(productImageDto);

            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _productImageCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto productImageDto)
        {
            var value = _mapper.Map<ProductImage>(productImageDto);

            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == productImageDto.ProductImageID, value);
        }
    }
}
