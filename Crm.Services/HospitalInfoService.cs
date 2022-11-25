using Crm.Models;
using Crm.Repositories.Interfaces;
using Crm.Utilities;
using Crm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Services
{
    public class HospitalInfoService : IHospitalInfo
    {
        private IUnitOfWork _unitOfWork;
        public HospitalInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteHospitalInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(id);
            _unitOfWork.GenericRepository<HospitalInfo>().Delete(model);
            _unitOfWork.Save();

        }

        public PageResult<CrmInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new CrmInfoViewModel();
            int totalCount;
            List<CrmInfoViewModel> vmList = new List<CrmInfoViewModel>();
            try
            {
               int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<HospitalInfo>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<HospitalInfo>().GetAll().Count();

                vmList = ConvertModelToViewModelList(modelList);

            }
            catch(Exception)
            {
                throw;
            }
            var result = new PageResult<CrmInfoViewModel>()
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
           
        }

        public CrmInfoViewModel GetHospitalById(int HospitalId)
        {
           var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(HospitalId);
            var vm = new CrmInfoViewModel();
            return vm;
        }

        public void InsertHospitalInfo(CrmInfoViewModel hospitalInfo)
        {
            var model = new CrmInfoViewModel().ConvertViewModel(hospitalInfo);
            _unitOfWork.GenericRepository<HospitalInfo>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateHospitalInfo(CrmInfoViewModel hospitalInfo)
        {
            var model = new CrmInfoViewModel().ConvertViewModel(hospitalInfo);
            var ModelById = _unitOfWork.GenericRepository<HospitalInfo>().GetById(model.Id);
            ModelById.Name = hospitalInfo.Name;
            ModelById.City = hospitalInfo.City;
            ModelById.PinCode = hospitalInfo.PinCode;
            ModelById.Country = hospitalInfo.Country;
            _unitOfWork.GenericRepository<HospitalInfo>().Update(ModelById);
            _unitOfWork.Save();
        }

        private List<CrmInfoViewModel> ConvertModelToViewModelList(List<HospitalInfo> modelList)
        {
            return modelList.Select(x => new CrmInfoViewModel(x)).ToList();
        }

    }
}
