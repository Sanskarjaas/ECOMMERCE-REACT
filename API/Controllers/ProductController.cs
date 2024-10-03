
using System.ComponentModel;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Intefaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product>
         productcontext, IGenericRepository<ProductBrand>
         brandcontext, IGenericRepository<ProductType>
         typecontext, IMapper mapper)
        {
            _productBrandRepo = brandcontext;
            _productRepo = productcontext;
            _productTypeRepo = typecontext;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetAllProducts(
            [FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);
            // return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
            return Ok(data);
            // return products.Select(product => new ProductToReturnDto
            // {
            //     Id = product.Id,
            //     Name = product.Name,~
            //     Description = product.Description,
            //     PictureUrl = product.PictureUrl,
            //     Price = product.Price,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name


            // }).ToList();
        }
        [HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if (product == null)
                return NotFound(new ApiResponse(404));

            //using automapper  to map the class attributes or varviables
            return _mapper.Map<Product, ProductToReturnDto>(product);

            //without using automapper  to map the class attributes or varviables
            // return new ProductToReturnDto
            // {
            //     Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     PictureUrl = product.PictureUrl,
            //     Price = product.Price,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name
            // };
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}
