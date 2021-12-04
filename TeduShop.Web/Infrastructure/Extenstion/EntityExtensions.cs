using TeduShop.Model.Models;
using TeduShop.Web.Models;

namespace TeduShop.Web.Infrastructure.Extenstion
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryViewModel)
        {
            postCategory.ID = postCategoryViewModel.ID;
            postCategory.Name = postCategoryViewModel.Name;
            postCategory.Alias = postCategoryViewModel.Alias;
            postCategory.Desciption = postCategoryViewModel.Desciption;
            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategory.Image = postCategoryViewModel.Image;
            postCategory.ParentID = postCategoryViewModel.ParentID;
            postCategory.HomeFlag = postCategoryViewModel.HomeFlag;
            postCategory.MetaKeyword = postCategoryViewModel.MetaKeyword;
            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;
            postCategory.CreatedDate = postCategoryViewModel.CreatedDate;
            postCategory.CreatedBy = postCategoryViewModel.CreatedBy;
            postCategory.UpdatedDate = postCategoryViewModel.UpdatedDate;
            postCategory.UpdatedBy = postCategoryViewModel.UpdatedBy;
            postCategory.Status = postCategoryViewModel.Status;
        }

        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.ID = productViewModel.ID;
            product.Name = productViewModel.Name;
            product.Alias = productViewModel.Alias;
            product.CategoryID = productViewModel.CategoryID;
            product.Image = productViewModel.Image;
            product.MoreImage = productViewModel.MoreImage;
            product.Price = productViewModel.Price;
            product.Promotion = productViewModel.Promotion;
            product.Warranty = productViewModel.Warranty;
            product.Description = productViewModel.Description;
            product.Content = productViewModel.Content;
            product.HomeFlag = productViewModel.HomeFlag;
            product.HotFlag = productViewModel.HotFlag;
            product.ViewCount = productViewModel.ViewCount;
            product.MetaKeyword = productViewModel.MetaKeyword;
            product.MetaDescription = productViewModel.MetaDescription;
            product.CreatedDate = productViewModel.CreatedDate;
            product.CreatedBy = productViewModel.CreatedBy;
            product.UpdatedDate = productViewModel.UpdatedDate;
            product.UpdatedBy = productViewModel.UpdatedBy;
            product.Status = productViewModel.Status;
            product.Tags = productViewModel.Tags;
            product.Quantity = productViewModel.Quantity;
            product.SellOut = productViewModel.SellOut;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryViewModel)
        {
            productCategory.ID = productCategoryViewModel.ID;
            productCategory.Name = productCategoryViewModel.Name;
            productCategory.Alias = productCategoryViewModel.Alias;
            productCategory.ParentID = productCategoryViewModel.ParentID;
            productCategory.Description = productCategoryViewModel.Description;
            productCategory.DisplayOrder = productCategoryViewModel.DisplayOrder;
            productCategory.Image = productCategoryViewModel.Image;

            productCategory.HomeFlag = productCategoryViewModel.HomeFlag;
            productCategory.MetaKeyword = productCategoryViewModel.MetaKeyword;
            productCategory.MetaDescription = productCategoryViewModel.MetaDescription;
            productCategory.CreatedDate = productCategoryViewModel.CreatedDate;
            productCategory.CreatedBy = productCategoryViewModel.CreatedBy;
            productCategory.UpdatedDate = productCategoryViewModel.UpdatedDate;
            productCategory.UpdatedBy = productCategoryViewModel.UpdatedBy;
            productCategory.Status = productCategoryViewModel.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.ID = postViewModel.ID;
            post.Name = postViewModel.Name;
            post.Alias = postViewModel.Alias;
            post.CategoryID = postViewModel.CategoryID;
            post.Content = postViewModel.Content;
            post.Image = postViewModel.Image;
            post.Description = postViewModel.Description;
            post.ViewCount = postViewModel.ViewCount;
            post.Content = postViewModel.Content;
            post.HomeFlag = postViewModel.HomeFlag;
            post.HotFlag = postViewModel.HotFlag;
            post.MetaKeyword = postViewModel.MetaKeyword;
            post.MetaDescription = postViewModel.MetaDescription;
            post.CreatedDate = postViewModel.CreatedDate;
            post.CreatedBy = postViewModel.CreatedBy;
            post.UpdatedDate = postViewModel.UpdatedDate;
            post.UpdatedBy = postViewModel.UpdatedBy;
            post.Status = postViewModel.Status;
        }

        public static void UpdateContactDetail(this ContactDetail contactDetail, ContactDetailViewModel contactDetailViewModel)
        {
            contactDetail.ID = contactDetailViewModel.ID;
            contactDetail.Name = contactDetailViewModel.Name;
            contactDetail.Phone = contactDetailViewModel.Phone;
            contactDetail.Email = contactDetailViewModel.Email;
            contactDetail.Address = contactDetailViewModel.Address;
            contactDetail.Website = contactDetailViewModel.Website;
            contactDetail.Other = contactDetailViewModel.Other;
            contactDetail.Lat = contactDetailViewModel.Lat;
            contactDetail.Lng = contactDetailViewModel.Lng;
            contactDetail.Status = contactDetailViewModel.Status;
        }

        public static void UpdatePage(this Page page, PageViewModel pageViewModel)
        {
            page.ID = pageViewModel.ID;
            page.Name = pageViewModel.Name;
            page.Alias = pageViewModel.Alias;
            page.Content = pageViewModel.Content;
            page.MetaKeyword = pageViewModel.MetaKeyword;
            page.MetaDescription = pageViewModel.MetaDescription;
            page.CreatedDate = pageViewModel.CreatedDate;
            page.CreatedBy = pageViewModel.CreatedBy;
            page.UpdatedDate = pageViewModel.UpdatedDate;
            page.UpdatedBy = pageViewModel.UpdatedBy;
            page.Status = pageViewModel.Status;
        }
    }
}