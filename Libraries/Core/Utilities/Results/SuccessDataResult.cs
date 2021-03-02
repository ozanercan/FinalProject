﻿namespace Core.Utilities.Results
{
    public class SuccessDataResult<TData> : DataResult<TData>
    {
        public SuccessDataResult(TData data, string message) : base(data, true, message)
        {
        }
        public SuccessDataResult(TData data) : base(data, true)
        {
        }
    }
}
