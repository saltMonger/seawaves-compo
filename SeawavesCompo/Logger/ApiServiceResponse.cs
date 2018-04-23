using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeawavesCompo.Logger
{
    public enum ApiServiceResponseCode
    {
        FAILURE = 0,
        SUCCESS = 1
    }
    public class ApiServiceResponse<T>
    {
        public ApiServiceResponseCode ResponseCode { get; set; }
        public T ResponseObject { get; set; }
        public string Message { get; set; }

        public ApiServiceResponse()
        {
            if(ResponseCode == ApiServiceResponseCode.FAILURE)
            {
                //log the reason to some file
            }
        }

    }
}