using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models.APIResponse
{
    public class APIResponseContentFailure : APIResponseContent
    {
        //
        private readonly IEnumerable<string> _objectFailureResultMessages;

        //
        public APIResponseContentFailure(int httpStatusCode, IEnumerable<string> objectFailureResultMessages)
            : base(httpStatusCode, false)
        {
            _objectFailureResultMessages = objectFailureResultMessages;
        }

        //
        protected override object FormatResponseObject()
        {
            return new
            {
                Success = _isSucess
                ,
                HttpStatusCode = _httpStatusCode
                ,
                HttpStatusCodeDescription = _httpStatusCodeDescription
                ,
                Erros = _objectFailureResultMessages
            };
        }

    }
}
