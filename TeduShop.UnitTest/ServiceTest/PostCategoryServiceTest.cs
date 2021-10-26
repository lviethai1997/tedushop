using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitofWork;
        private PostCategoriesService _categoryService;
        private List<PostCategory> _listPostCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitofWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoriesService(_mockUnitofWork.Object, _mockRepository.Object);
            _listPostCategory = new List<PostCategory>()
            {
                new PostCategory(){ID=1,Name="haile",Status=true},
                new PostCategory(){ID=2,Name="haile1",Status=true},
                new PostCategory(){ID=3,Name="haile2",Status=true}
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listPostCategory);

            var rs = _categoryService.GetAll() as List<PostCategory>;
            Assert.IsNotNull(rs);
            Assert.AreEqual(3, rs.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "test";
            category.Alias = "ts";
            category.HomeFlag = true;
            category.ParentID = 4;
            category.Status = true;
            category.CreatedDate = DateTime.Now;

            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
              {
                  p.ID = 1;
                  return p;
              }
            );
            var rs = _categoryService.Add(category);

            Assert.IsNotNull(rs);
            Assert.AreEqual(1, rs.ID);
        }
    }
}