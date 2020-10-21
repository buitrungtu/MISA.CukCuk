using MISA.Bussiness.Interfaces;
using MISA.Common.Model;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        #region property
        IBaseRepository<T> _baseRepository;
        protected List<string> validateErrorResponseMsg = new List<string>();
        #endregion
        #region Constructor
        public BaseService(IBaseRepository<T> customerRepository)
        {
            _baseRepository = customerRepository;
        }
        #endregion
        #region Metod
        public ServiceResponse Delete(Guid objId)
        {
            var serviceResponse = new ServiceResponse();
            serviceResponse.Success = true;
            serviceResponse.Msg.Add("Thành công");
            serviceResponse.Data = _baseRepository.Delete(objId);
            return serviceResponse;
        }

        public IEnumerable<T> GetData()
        {
            return _baseRepository.GetData();
        }

        public IEnumerable<T> GetDataByPage(int page,int record)
        {
            return _baseRepository.GetDataByPage(page,record);
        }

        public T GetById(object objId)
        {
            return _baseRepository.GetByID(objId);
        }

        public ServiceResponse Insert(T obj)
        {
            var serviceResponse = new ServiceResponse();
            if (Validate(obj,"POST") == true) //check thông tin
            {
                serviceResponse.Success = true;
                serviceResponse.Msg.Add("Thành công");
                serviceResponse.Data = _baseRepository.Insert(obj);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Msg = validateErrorResponseMsg;
            }
            return serviceResponse;
        }

        public ServiceResponse Update(T obj)
        {
            var serviceResponse = new ServiceResponse();
            if (Validate(obj,"PUT") == true)
            {
                serviceResponse.Success = true;
                serviceResponse.Msg.Add("Thành công");
                serviceResponse.Data = _baseRepository.Update(obj);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Msg = validateErrorResponseMsg;
            }
            return serviceResponse;
        }

        /// <summary>
        /// Kiểm tra thông tin trước khi thêm hoặc sửa (Sẽ thực hiện tại các lớp kế thừa)
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// Author: BTTu (18/10/2020)
        /// <returns></returns>
        protected virtual bool Validate(T entity,string Method)
        {
            return true;
        }
        #endregion

    }
}
