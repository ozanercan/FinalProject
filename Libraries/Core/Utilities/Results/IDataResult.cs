namespace Core.Utilities.Results
{
    public interface IDataResult<TData> : IResult
    {
        TData Data { get; }
    }
}
