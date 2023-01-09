using System.Text.Json.Serialization;

namespace Models
{
    public interface IResult<TEntity> where TEntity : class
    {
        bool Success { get; set; }
        string? Message { get; set; }
        bool HasMessage { get; set; }
        IEnumerable<TEntity> Data { get; set; }
        int TotCnt { get; }
        [JsonIgnore]
        Exception? Exception { get; set; }
        [JsonIgnore]
        string ErrMessage { get; }
        [JsonIgnore]
        Result<TEntity> GetResult { get; }
        [JsonIgnore]
        IResult<TEntity> GetIResult { get; }
    }
}
