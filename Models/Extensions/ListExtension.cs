using System.Data;

namespace Models.Extensions
{
    public static class ListExtension
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> list, string[] sort)
        {
            DataTable dt = new DataTable();
            var pts = typeof(T).GetProperties()
                .Where(q => Attribute.IsDefined(q, typeof(StoreProcedureInput)) && sort.Contains(q.Name))
                .OrderBy(o => { if (sort == null) { return 0; } return Array.IndexOf(sort, o.Name); }).ToList();
            pts.ForEach(p => { dt.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType); });
            foreach (T item in list)
            {
                var row = dt.NewRow();
                pts.ForEach(p => { row[p.Name] = p.GetValue(item) ?? DBNull.Value; });
                dt.Rows.Add(row);
            }
            return dt;
        }
        public static DataTable ToDataTableNotAttribute<T>(this IEnumerable<T> list, string[] sort)
        {
            DataTable dt = new DataTable();
            var pts = typeof(T).GetProperties()
                .Where(q => sort.Contains(q.Name))
                .OrderBy(o => { if (sort == null) { return 0; } return Array.IndexOf(sort, o.Name); }).ToList();
            pts.ForEach(p => { dt.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType); });
            foreach (T item in list)
            {
                var row = dt.NewRow();
                pts.ForEach(p => { row[p.Name] = p.GetValue(item) ?? DBNull.Value; });
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
