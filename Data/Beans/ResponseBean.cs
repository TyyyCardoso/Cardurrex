using CardurrexAPI.Utils.Enums;
using System.Runtime.CompilerServices;

namespace CardurrexAPI.Data.Beans
{
    public class ResponseBean
    {
        public string resCode { get; set; }
        public string resMessage { get; set; }
        public object resObj { get; set; }

        public void SetSuccessResponse()
        {
            resCode = ResCodesEnum.RESCODE_SUCCESS_RESPONSE.ToString();
        }

        public void SetSuccessResponseWithMessage(string message)
        {
            resCode = ResCodesEnum.RESCODE_SUCCESS_RESPONSE.ToString();
            resMessage = message;
        }

        public void SetErrorResponse()
        {
            resCode = ResCodesEnum.RESCODE_GENERIC_ERROR_RESPONSE.ToString();
            resMessage = "";
        }

        public void SetErrorResponseWithMessage(string message)
        {
            resCode = ResCodesEnum.RESCODE_GENERIC_ERROR_RESPONSE.ToString();
            resMessage = message;
        }

        public void SetPayDataObject(Object obj)
        {
            resObj = obj;
        }


    }
}
