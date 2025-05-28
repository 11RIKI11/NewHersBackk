namespace Core.Results;

public class ApiResponse
{
    public bool IsSuccess { get; set; }
    public object? Data { get; set; }
    ErrorApiResponse? Error { get; set; }

    private ApiResponse(bool isSuccess = true, object? data = null, ErrorApiResponse? error = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
    }

    public static ApiResponse Success(object? data = null)
    {
        return new ApiResponse(true, data);
    }

    public static ApiResponse Failure(string errorMessage, int statusCode = 400, Dictionary<string, string>? details = null)
    {
        return new ApiResponse(false, null, new ErrorApiResponse(errorMessage, statusCode, details));
    }

    private class ErrorApiResponse
    {

        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public Dictionary<string, string>? Details { get; set; }

        public ErrorApiResponse(string errorMessage, int statusCode = 400, Dictionary<string,string>? details = null)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
            Details = details;
        }
    }
}

