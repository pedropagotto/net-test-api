using System.Text.Json.Serialization;

namespace Authentication.Domain.Abstractions;

public class ErrorMessage
{
    public string Message { get; set; }

    [JsonConstructor]
    public ErrorMessage(string message)
    {
        Message = message;
    }
}
