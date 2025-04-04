using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Authentication.Domain.Abstractions;

public class Result<TResult>
{
    public bool Success { get; set; }
    public List<ErrorMessage> Errors { get; set; }
    public TResult? Value { get; set; }

    public Result(List<ErrorMessage> errors)
    {
        Errors = errors;

    }

    public Result(bool success) : this(default, success, new List<ErrorMessage>())
    {

    }

    public Result(TResult value, bool success) : this(value, success, new List<ErrorMessage>())
    {

    }

    [JsonConstructor]
    public Result(TResult value, bool success, List<ErrorMessage> errors)
    {
        Errors = errors;
        Success = success;
        Value = value;
    }

    public Result<TResult> WithErrors(List<ErrorMessage> errors)
    {
        errors.ForEach(x => WithError(x));
        return this;
    }

    public Result<TResult> WithError(ErrorMessage error)
    {
        Errors.Add(error);
        return this;
    }

    public Result<TResult> WithError(string error)
    {
        Errors.Add(new ErrorMessage(error));
        return this;
    }

}

public class Result : Result<object>
{
    public Result(bool success) : base(success)
    {
    }

    public Result(object value, bool success, List<ErrorMessage> errorMessages) : base(value, success, errorMessages)
    {

    }

    public static Result<TResult> Ok<TResult>(TResult value)
    {
        return new Result<TResult>(value, true);
    }
    public static Result Ok()
    {
        return new Result(true);
    }

    public static Result<TResult> Error<TResult>(List<ErrorMessage> errors)
    {
        return new Result<TResult>(false).WithErrors(errors);
    }

    public static Result<TResult> Error<TResult>(ErrorMessage error)
    {
        return new Result<TResult>(false).WithError(error);
    }

    public static Result<TResult> Error<TResult>(string error)
    {
        return new Result<TResult>(false).WithError(error);
    }


    public static Result Error(List<ErrorMessage> errors)
    {
        return (Result) new Result(false).WithErrors(errors);
    }

    public static Result Error(ErrorMessage error)
    {
        return (Result) new Result(false).WithError(error);
    }
    public static Result Error(string error)
    {
        return (Result) new Result(false).WithError(error);
    }


}
