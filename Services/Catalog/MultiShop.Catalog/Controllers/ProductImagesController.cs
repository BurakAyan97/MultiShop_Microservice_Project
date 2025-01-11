using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productdetailService;

        public ProductImagesController(IProductImageService productdetailService)
        {
            _productdetailService = productdetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productdetailService.GettAllProductImageAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var values = await _productdetailService.GetByIdProductImageAsync(id);

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto productdetailDto)
        {
            await _productdetailService.CreateProductImageAsync(productdetailDto);

            return Ok("Ürün görseli başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productdetailService.DeleteProductImageAsync(id);

            return Ok("Ürün görseli başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto productdetailDto)
        {
            await _productdetailService.UpdateProductImageAsync(productdetailDto);

            return Ok("Ürün görseli başarıyla güncellendi");
        }
    }
}
