using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class ServiceResult
    {
        public bool Succeeded { get; set; }
        public object ResultObject { get; set; }
        public IEnumerable<ServiceError> Errors { get; set; }



        public ServiceResult()
        {
            this.Succeeded = true;
        }

        public ServiceResult(object ResultObject)
        {
            this.Succeeded = true;
            this.ResultObject = ResultObject;
        }


        public ServiceResult(IEnumerable<ServiceError> Errors)
        {
            this.Succeeded = false;
            this.Errors = Errors;
        }

        public ServiceResult(ServiceError Error)
        {
            var Errors = new List<ServiceError>();
            Errors.Add(new ServiceError(Error.Code, Error.Description));
            this.Succeeded = false;
            this.Errors = Errors;
        }


    }
}
