namespace WebAPI
{
    public class Log4netProvider : ILoggerProvider
    {
        public readonly FileInfo _fileInfo;
        public Log4netProvider(string log4netConfigFile)
        {
            _fileInfo = new FileInfo(log4netConfigFile);
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new Log4netLogger(categoryName, _fileInfo);
        }
        public void Dispose()
        {

        }
    }
}
