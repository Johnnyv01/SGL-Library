namespace WebApplication1.Models
{
    public class ResponseModel<T>
    {
        public T? Dados {get; set; }
        public string Message { get; set; }

        public bool Status { get; set; } = true;
    }
}
