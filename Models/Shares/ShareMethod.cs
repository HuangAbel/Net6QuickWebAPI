using System.Runtime.CompilerServices;

namespace Models
{
    public static class ShareMethod
    {
        public static void SetExecuteType<TEntity>(TEntity entity, [CallerMemberName] string methodName = "")
        {
            if (entity != null)
            {
                var gpt = entity.GetType().GetProperty("ExecuteType");
                if (gpt != null)
                {
                    gpt.SetValue(entity, methodName.ToUpper());
                }
            }
        }
    }
}
