namespace Identity.Domain.Models.APIResponse
{
    public class APIResponseContentSuccess : APIResponseContent
    {
        private readonly object _objectResult;

        public APIResponseContentSuccess(int httpStatusCode, object objectResult)
            : base(httpStatusCode, true)
        {
            _objectResult = objectResult;
        }


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
                Data = _objectResult
            };
        }

    }
}
