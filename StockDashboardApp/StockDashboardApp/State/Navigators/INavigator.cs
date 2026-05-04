using StockDashboardApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockDashboardApp.State.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel{ get; set; }

        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
