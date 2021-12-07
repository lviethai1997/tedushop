using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IFeedBackService
    {
        FeedBack Create(FeedBack feedBack);

        void Save();
    }

    public class FeedBackService : IFeedBackService
    {
        private IFeedBackRepository _feedBackRepository;
        private IUnitOfWork _unitOfWork;

        public FeedBackService(IFeedBackRepository feedBackRepository, IUnitOfWork unitOfWork)
        {
            this._feedBackRepository = feedBackRepository;
            this._unitOfWork = unitOfWork;
        }

        public FeedBack Create(FeedBack feedBack)
        {
            return _feedBackRepository.Add(feedBack);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}