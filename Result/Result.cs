/// Copyright (c) 2026 Chiara Altobelli

namespace Budget.Server.Results;

// Basic result class to indicate success or failure of an operation, along with a message.
public class Result
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    // Constructor to initialize the result with success status and message.
    public Result(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    // Success result without data
    // <param name="message">An optional success message to include with the returned result.</param>
    // <returns> A Result object indicating success and an optional message. Message is empty if not provided.</returns>
    public static Result Success(string message = "")
    {
        return new Result(true, message);
    }

    // Failure result without data
    // <param name="message">A failure message to include with the returned result.</param>
    // <returns> A Result object indicating failure and an error message.</returns>
    public static Result Failure (string message)
    {
        return new Result(false, message);
    }
}

// Generic version of Result to include data
public sealed class Result<T>
{
    public bool IsSuccess { get; }
    public string Message { get; }

    // Optional data for successful results
    public T? Data { get; }

    // Constructor for a result containing data and a message
    private Result(bool isSuccess, T? data, string message)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }

    // Success result with data
    // <param name="data">The data to return on success.</param>
    // <param name="message">An optional success message to include with the returned result
    // <returns> A Result object indicating success and containing the provided data.</returns> 
    public static Result<T> Success(T data, string message = "")
    {
        return new Result<T>(true, data, message);
    }
    
    
    // Failure result
    // <param name="message">A failure message to include with the returned result.</param>
    // <returns> A Result object indicating failure and an error message.</returns>
    public static Result<T> Failure(string message = "")
    {
        return new Result<T>(false, default, message);
    }
}