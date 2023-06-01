namespace WebApi.Models
{
    public class CustomResponseSucesso
    {
        public object Data { get; private set; }

        public CustomResponseSucesso(object data)
        {
            Data = data;
        }
    }
}
