using AventStack.ExtentReports.MarkupUtils;
using CoreFramework.APICore;

namespace CoreFramework.Reporter.ExtentMarkup;

public class APIRequestLog : IMarkup
{
    private APIRequest Request { get; set; }
    private APIResponse Response { get; set; }
    public APIRequestLog(APIRequest request, APIResponse response)
    {
        Request = request;
        Response = response;
    }
    public string GetMarkup()
    {
        string log = $@"
                    <p>Request url: {Request.Url}</p>
                    <p>Request body: {Response.responseBody}</p>
                    <p>Response status: {Response.responseStatusCode}</p>";
        return log;
    }
}



