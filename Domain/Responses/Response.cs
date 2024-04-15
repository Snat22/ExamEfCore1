using System.Net;

namespace Domain.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
    public T? Data { get; set; }

    public Response(HttpStatusCode statusCode,string messages,T data)
    {
        StatusCode = (int)statusCode;
        Errors.Add(messages);
        Data = data;
        
    }

    
    public Response(HttpStatusCode statusCode,List<string> messages,T data)
    {
        StatusCode = (int)statusCode;
        Errors = messages;
        Data = data;
        
    }

    
    public Response(HttpStatusCode statusCode,string messages)
    {
        StatusCode = (int)statusCode;
        Errors.Add(messages);
        
    }

    
    public Response(HttpStatusCode statusCode,List<string> messages)
    {
        StatusCode = (int)statusCode;
        Errors =messages;
        
    }
    public Response(HttpStatusCode statusCode, T data)
    {
        StatusCode = (int)statusCode;
        Data = data;
    }

    public Response(T data)
    {
        StatusCode = 200;
        Data = data;
    }
}
