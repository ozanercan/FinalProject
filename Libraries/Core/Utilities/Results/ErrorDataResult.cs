namespace Core.Utilities.Results
{
    public class ErrorDataResult<TData> : DataResult<TData>
    {
        public ErrorDataResult(string message, TData data) : base(false, message, data)
        {
        }
        public ErrorDataResult(TData data) : base(false, data)
        {
        }
    }
}
