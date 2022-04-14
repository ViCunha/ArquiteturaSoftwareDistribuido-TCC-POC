using System.Net;

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
            _httpStatusCodeDescription = ((HttpStatusCode)httpStatusCode).ToString();
            _isSucess = isSucess;
        }

        protected abstract object FormatResponseObject();

    }
}
