namespace DemoBlazor.Shared
{
    public class ResponseAPI<T>
    {
        public bool Flag { get; set; }
        public T? Value { get; set; }
        public string? Message { get; set; }
    }
}
