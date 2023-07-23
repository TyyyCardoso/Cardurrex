
using System.Runtime.CompilerServices;
using CardurrexAPI.Utils.Enums;
using CardurrexAPI.Utils;

namespace CardurrexAPI.Data.Beans
{
    public class ResponseBean
    {
        public ResponseHeader header { get; set; }
        public ResponseBody body { get; set; }

        public ResponseBean()
        {
            header = new ResponseHeader();
            body = new ResponseBody();
        }

        public void SetSuccessResponse()
        {
            header.resCode = ResCodesConstants.RESCODE_SUCCESS_RESPONSE;
        }

        public void SetSuccessResponseWithMessage(string message)
        {
            header.resCode = ResCodesConstants.RESCODE_SUCCESS_RESPONSE;
            header.resMessage = ResourcesUtils.GetMessageFromResource(message);
        }

        public void SetErrorResponse()
        {
            header.resCode = ResCodesConstants.RESCODE_GENERIC_ERROR_RESPONSE;
            header.resMessage = ResourcesUtils.GetMessageFromResource("GENERIC_ERROR");
        }

        public void SetErrorResponseWithMessage(string message)
        {
            header.resCode = ResCodesConstants.RESCODE_GENERIC_ERROR_RESPONSE;
            header.resMessage = message;
        }

        public void SetPayDataObject(Object obj)
        {
            body.resObj = obj;
        }


    }
}
