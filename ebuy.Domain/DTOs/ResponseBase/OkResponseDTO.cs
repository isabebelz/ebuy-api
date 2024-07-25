namespace ebuy.Domain.DTOs.ResponseBase
{
    public class OkResponseDTO
    {
        public bool Sucess = true;
        public object? Data { get; set; }
        public IEnumerable<string> Message { get; set; } = [];
    }
}
