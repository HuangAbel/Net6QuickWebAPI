using Models;
using System.Runtime.CompilerServices;

namespace WebAPI.Extensions
{
    public static class ResultExtension
    {
        public static IResult<TEntity> ErrorLog<TEntity, Controller>(
           this IResult<TEntity> result,
           ILogger<Controller> logger,
           [CallerMemberName] string methodName = "",
           [CallerLineNumber] int lineNumber = 0) where TEntity : class
        {
            if (!result.Success)
            {
                logger.LogError($"method:{methodName} line:{lineNumber} exmessage:{result.ErrMessage}");
            }
            return result;
        }
    }
}
