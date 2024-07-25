namespace ebuy.Domain.DTOs.ResponseBase
{
    public class BadRequestResponseDTO
    {
        public bool Success = false;
        public object? Data { get; set; }
        public IEnumerable<string> Errors { get; set; } = [];
    }
}
