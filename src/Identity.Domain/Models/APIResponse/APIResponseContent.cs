using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models.APIResponse
{
    public abstract class APIResponseContent
    {
        protected readonly int _httpStatusCode;

        protected readonly string _httpStatusCodeDescription;

        protected readonly bool _isSucess;

        public object Response 
        {
            get
            {
                return FormatResponseObject();
            } 
        }

        public APIResponseContent(int httpStatusCode, bool isSucess)
        {
            _httpStatusCode = httpStatusCode;
            _httpStatusCodeDescription = ((HttpStatusCode) httpStatusCode).ToString();
            _isSucess = isSucess;
        }

        protected abstract object FormatResponseObject();

    }
}
