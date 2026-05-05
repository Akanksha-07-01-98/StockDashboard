using SimpleTrader.Domain.Services;
using StockDashboardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDashboardApp.ViewModel
{
    public class MajorIndexingViewModel:ViewModelBase
    {
        private readonly IMajorIndexService _majorIndexService;
        private MajorIndex _dowJones;

        public MajorIndex DowJones
        {
            get { return _dowJones; }
            set
            {

                _dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }

        private MajorIndex _nasdaq;

        public MajorIndex Nasdaq
        {
            get { return _nasdaq; }
            set
            {

                _nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }

        private MajorIndex _apple;

        public MajorIndex Apple
        {
            get { return _apple; }
            set
            {

                _apple = value;
                OnPropertyChanged(nameof(Apple));
            }
        }

        public MajorIndexingViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public static MajorIndexingViewModel LoadMajorIndexes(IMajorIndexService majorIndexService) 
        {
            MajorIndexingViewModel majorIndexViewModel = new MajorIndexingViewModel(majorIndexService);
            majorIndexViewModel.LoadMajorIndexes();
            return majorIndexViewModel;
        }

        private void LoadMajorIndexes()
        {
            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    DowJones = task.Result;
                }
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Nasdaq = task.Result;
                }
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.Apple).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Apple = task.Result;
                }
            });
        }
    }
}
