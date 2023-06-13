using _0_Fremework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public OperationResult Create(CreateProductCategory command)
        {
           var operation = new OperationResult();
            if (_productCategoryRepository.Exists(command.Name))
                return operation.Failed("امکان ثبت تکراری وچود ندارد");

            var productcategory = new ProductCategory(command.Name,command.Description, command.Picture, command.PictureAlt,
                command.PictureTitle, command.Keywords, command.MetaDescription,command.Slug);


        }

        public OperationResult Edit(EditProductCategory command)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchmodel)
        {
            throw new NotImplementedException();
        }
    }
}
