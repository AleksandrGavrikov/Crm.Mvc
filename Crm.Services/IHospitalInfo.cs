using Crm.Utilities;
using Crm.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Services
{
    public interface IHospitalInfo
    {
        PageResult<CrmInfoViewModel> GetAll(int pageNumber, int pageSize);
        CrmInfoViewModel GetHospitalById(int HospitalId);
        void UpdateHospitalInfo(CrmInfoViewModel hospitalInfo);
        void InsertHospitalInfo(CrmInfoViewModel hospitalInfo);
        void DeleteHospitalInfo(int id);
        
    }
}
