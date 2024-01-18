using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3.Business.Models
{
	public class GenericPaginatedModel<T>
	{
        public GenericPaginatedModel(int currentPage, int rowCount, int perPage, IEnumerable<T> data)
        {
            CurrentPage = currentPage;
            RowCount = rowCount;
            PerPage = perPage;
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int RowCount { get; set; }
        public int PerPage { get; set; }

        public string Next { get; set; }
        public string Prev { get; set; }

        public int PageCount { get => (int)Math.Ceiling(RowCount * 1.0 / PerPage); }
        public bool HasNext { get => CurrentPage < PageCount; }
        public bool HasPrev { get => CurrentPage > 1; }




    }
}
