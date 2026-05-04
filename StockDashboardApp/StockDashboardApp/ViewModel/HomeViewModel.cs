using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDashboardApp.ViewModel
{
    public class HomeViewModel:ViewModelBase
    {
        public MajorIndexViewModel MajorIndexViewModel { get; set; }
        public HomeViewModel(MajorIndexViewModel majorIndexViewModel)
        {
            MajorIndexViewModel = majorIndexViewModel;
        }
    }
}
