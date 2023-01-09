using Dapper;
using System.Data;

namespace Models.Extensions
{
    public static class GetInputPropertiesExtension
    {
        public static DynamicParameters GetInputProperties(this object obj)
        {
            var ppts = obj.GetType().GetProperties();
            var spi = ppts.Where(q => Attribute.IsDefined(q, typeof(StoreProcedureInput)));
            var dynamicParameters = new DynamicParameters();
            foreach (var pItem in spi)
            {
                dynamicParameters.Add($"@{pItem.Name}", pItem.GetValue(obj));
            }
            var spit = ppts.Where(q => Attribute.IsDefined(q, typeof(StoreProcedureInputWithTable)));
            foreach (var pItem in spit)
            {
                var dt = pItem.GetValue(obj) as DataTable;
                dynamicParameters.Add($"@{pItem.Name}", dt.AsTableValuedParameter($"TYPE_{pItem.Name.Replace("TABLE_", "")}"));
            }
            return dynamicParameters;
        }
    }
}
