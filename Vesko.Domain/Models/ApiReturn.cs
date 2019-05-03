using System;
using System.Collections.Generic;
using System.Text;

namespace VeskoWeb.Domain.Models
{
    public class ApiReturn
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }

        public ApiReturn()
        {
            Success = true;
        }
    }
}
