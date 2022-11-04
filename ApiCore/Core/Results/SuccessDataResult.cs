using System.Collections.Generic;

namespace Core.Results
{
    public sealed partial class SuccessDataResult<T>
    {
        public IEnumerable<T> ListResponseModel { get; set; } = null;
        public T ResponseModel { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public long ModelCount { get; set; } = 0;
        public SuccessDataResult()
        {
        }
        public SuccessDataResult(IEnumerable<T> ListResponseModel, bool Status, string Message, long ModelCount)
        {
            this.ListResponseModel = ListResponseModel;
            this.Status = Status;
            this.Message = Message;
            this.ModelCount = ModelCount;
        }
        public SuccessDataResult(T ResponseModel, bool Status, string Message)
        {
            this.ResponseModel = ResponseModel;
            this.Status = Status;
            this.Message = Message;
        }
    }
}