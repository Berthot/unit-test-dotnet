namespace Application.CommonResponses;

public class EntitySuccess<T>
{
    public EntitySuccess(bool success, T? body)
    {
        Success = success;
        Body = body;
    }

    public bool Success { get; init; }

    public T? Body { get; init; }

    public List<Error> Errors { get; set; } = new();

    public void AddError(Error error)
    {
        Errors.Add(error);
    }

}