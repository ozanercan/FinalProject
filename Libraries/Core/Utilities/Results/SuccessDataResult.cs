namespace Core.Utilities.Results
{
    public class SuccessDataResult<TData> : DataResult<TData>
    {
        public SuccessDataResult(string message, TData data) : base(true, message, data)
        {
        }
        public SuccessDataResult(TData data) : base(true, data)
        {
        }
    }
}
