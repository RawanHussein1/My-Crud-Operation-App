using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class ServiceError
    {
        public ServiceError(string Code, string Description)
        {
            this.Code = Code;
            this.Description = Description;
        }

        public string Code { get; set; }
        public string Description { get; set; }
    }
}

