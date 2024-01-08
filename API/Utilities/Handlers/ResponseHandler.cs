namespace API.Utilities.Handlers
{
    public class ResponseHandler<TEntity>
    {
        public int Code { get; set; }
        public string Status { get; set; } = default!;
        public string Message { get; set; } = default!;
        public TEntity? Data { get; set; }
    }
}