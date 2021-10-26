using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostCategories
    {
        void Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        void Delete(int id);

        PostCategory GetById(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetByTagPaging(string tag, int page, int pageSize, out int totalRow);

        IEnumerable<PostCategory> GetByPaging(int page, int pageSize, out int totalRow);
    }

    public class PostCategoriesService : IPostCategories
    {
        private IUnitOfWork _unitOfWork;
        private IPostCategoryRepository _postCategoryRepository;

        public PostCategoriesService(IUnitOfWork unitOfWork, IPostCategoryRepository postCategoryRepository)
        {
            this._unitOfWork = unitOfWork;
            this._postCategoryRepository = postCategoryRepository;
        }

        public void Add(PostCategory postCategory)
        {
            _postCategoryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<PostCategory> GetByPaging(int page, int pageSize, out int totalRow)
        {
            return _postCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<PostCategory> GetByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _postCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}