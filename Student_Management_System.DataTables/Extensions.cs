using System.Collections.Generic;
using System.Linq;

namespace Student_Management_System.DataTables
{
    public static class DataTableExtensions
    {
        /// <summary>
        /// Gets sorted columns of Sort
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static IEnumerable<Sort> SortedColumns(this ColumnCollection columns)
        {
            var lst = new List<Sort>();
            foreach (var column in columns.GetSortedColumns())
            {
                lst.Add(new Sort
                {
                    Field = column.Data,
                    Dir = column.SortDirection == Column.OrderDirection.Descendant ? "desc" : "asc"
                });
            }
            return lst;
        }

        /// <summary>
        /// Converts to form required by Dynamic Linq e.g. "Field1 desc, Field2 asc"
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static string ToExpression(this IEnumerable<Sort> sort)
        {
            if (sort != null && sort.Any())
            {
                return string.Join(",", sort.Select(s => s.ToExpression()));
            }
            return string.Empty;
        }
    }
}