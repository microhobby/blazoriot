using System;
using System.Linq;
using System.Threading.Tasks;

namespace blazorIoT.Data
{
    public class PageTitleService
    {
        public string headerTitle = "";
        public string HeaderTitle
        {
            get { return headerTitle; }
            set
            {
                if (headerTitle != value)
                {
                    headerTitle = value;

                    if (NotifyDataChanged != null)
                    {
                        NotifyDataChanged?.Invoke();
                    }
                }
            }
        }

        public event Func<Task> NotifyDataChanged;
    }
}
