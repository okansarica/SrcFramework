namespace SrcFramework.Web.ViewModel
{
    public class ResultViewModel<T>:BaseViewModel
    {
        public ResultViewModel(T result)
        {
            Result = result;
        }
        public T Result { get; set; }
    }
}
