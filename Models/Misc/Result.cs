using System.Text.Json.Serialization;

namespace Models
{
    public class Result<TEntity> : IResult<TEntity> where TEntity : class
    {
        public Result(bool success, bool hasMessage, string message, IEnumerable<TEntity> data, Exception? exception)
        {
            Success = success;
            HasMessage = hasMessage;
            Message = message;
            Data = data;
            Exception = exception;
        }
        public Result()
        {
        }
        public Result(string message)
        {
            this.Success = true;
            this.HasMessage = true;
            this.Message = message;
        }
        public Result(bool success, bool hasMessage)
        {
            this.Success = success;
            this.HasMessage = hasMessage;
        }
        /// <summary>
        /// 執行狀況
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 是否有訊息回傳
        /// </summary>
        public bool HasMessage { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string? Message { get; set; }
        private IEnumerable<TEntity>? _Data;
        /// <summary>
        /// 資料
        /// </summary>
        public IEnumerable<TEntity> Data
        {
            get
            {
                if (_Data == null)
                {
                    _Data = new List<TEntity>();
                }
                return _Data;
            }
            set
            {
                if (value != null)
                {
                    _Data = value;
                }
            }
        }
        public int TotCnt
        {
            get
            {
                return this.Data.Count();
            }
        }

        [JsonIgnore]
        public Exception? Exception { get; set; }
        [JsonIgnore]
        public string ErrMessage
        {
            get
            {
                if (Exception != null)
                {
                    return Exception.Message;
                }
                return "";
            }
        }
        [JsonIgnore]
        public Result<TEntity> GetResult => this;
        [JsonIgnore]
        public IResult<TEntity> GetIResult
        {
            get
            {
                return this;
            }
        }
    }
}
