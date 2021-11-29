using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
    }

    public class CommonService : ICommonService
    {
        IFooterRepository _FooterRepository;
        IUnitOfWork _UnitOfWork;
        public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork)
        {
            _FooterRepository = footerRepository;
            _UnitOfWork = unitOfWork;
        }

        public Footer GetFooter()
        {
            return _FooterRepository.GetSingleByCondition(x => x.ID == Common.CommonConstants.DefaultFooter);
        }
    }
}
