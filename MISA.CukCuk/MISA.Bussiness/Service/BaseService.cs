﻿using MISA.Bussiness.Interfaces;
using MISA.Common.Model;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> _baseRepository;
        protected List<string> validateErrorResponseMsg = new List<string>();

        public BaseService(IBaseRepository<T> customerRepository)
        {
            _baseRepository = customerRepository;
        }
        public ServiceResponse Delete(Guid objId)
        {
            var serviceResponse = new ServiceResponse();
            serviceResponse.Success = true;
            serviceResponse.Msg.Add("Thành công");
            serviceResponse.Data = _baseRepository.Delete(objId);
            return serviceResponse;
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T GetById(object objId)
        {
            return _baseRepository.GetById(objId);
        }

        public ServiceResponse Insert(T obj)
        {
            var serviceResponse = new ServiceResponse();
            if (Validate(obj) == true)
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
            if (Validate(obj) == true)
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
        protected virtual bool Validate(T entity)
        {
            return true;
        }
    }
}
