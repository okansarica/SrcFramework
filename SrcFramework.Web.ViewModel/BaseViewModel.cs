
namespace SrcFramework.Web.ViewModel
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            IsSuccessfull = true;
        }

        public BaseViewModel(string message)
        {
            IsSuccessfull = false;
            Message = message;
        }

        public BaseViewModel(string message, int code)
        {
            IsSuccessfull = false;
            Message = message;
            this.Code =code;
        }

        public bool IsSuccessfull { get; set; }
        public bool IsBusinessException { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
