using Application.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyCrudOperation.API.Models
{
    public class ApisResponse
    {
        public string Status { get; set; }
        public dynamic Response { get; set; }
        public List<ResponseError> Error { get; set; }

        public ApisResponse(ServiceResult serviceResult)
        {

            if (serviceResult.Succeeded && serviceResult.Errors == null)
            {
                this.Response = serviceResult.ResultObject;
                this.Status = "Succeded";
                this.Error = null;
            }
            else
            {
                this.Status = "Failed";
                this.Response = null;
                this.Error = new List<ResponseError>();
                foreach (var error in serviceResult.Errors)
                {
                    this.Error.Add(new ResponseError(error.Code, error.Description));
                }
            }
        }
    }
    public class ResponseError
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public ResponseError(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }

}
