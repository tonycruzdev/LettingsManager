using System.Linq;

namespace BlazorManageLettings
{
    public class ManagePagination<T>
    {
        public T[] DataSource { get; set; }
        public T[] DisplaySource { get; set; }
        public T[] SearchSource { get; set; }
        public int PageStart { get; set; } = 0;
        public int CurrentPage { get; set; }
        public int ItemPerPage { get; set; } = 8;
        public int PageCount { get; set; }
        public string Searchtxt { get; set; }
        public void Paginate(int page)
        {
            var size = ItemPerPage;
            var start = page * size;

            var nextPage = SearchSource.Skip(start).Take(size).ToArray();
            DisplaySource = nextPage;
            CurrentPage = page;
        }
        public void NextPage()
        {
            Paginate(CurrentPage + 1);
        }
        public void PreviousPage()
        {
            Paginate(CurrentPage - 1);
        }
        public void FirstPage()
        {
            Paginate(0);
        }
        public void LastPage()
        {
            Paginate(PageCount - 1);
        }
    }
}
