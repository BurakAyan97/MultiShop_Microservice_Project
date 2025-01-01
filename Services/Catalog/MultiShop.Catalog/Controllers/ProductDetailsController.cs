using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productdetailService;

        public ProductDetailsController(IProductDetailService productdetailService)
        {
            _productdetailService = productdetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productdetailService.GetAllProductDetailAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values = await _productdetailService.GetByIdProductDetailAsync(id);

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto productdetailDto)
        {
            await _productdetailService.CreateProductDetailAsync(productdetailDto);

            return Ok("Ürün detayı başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productdetailService.DeleteProductDetailAsync(id);

            return Ok("Ürün detayı başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto productdetailDto)
        {
            await _productdetailService.UpdateProductDetailAsync(productdetailDto);

            return Ok("Ürün detayı başarıyla güncellendi");
        }
    }
}
