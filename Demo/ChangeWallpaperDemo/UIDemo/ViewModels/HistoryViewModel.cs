using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;
using Prism.Events;
using Prism.Mvvm;
using UIDemo.Model;

namespace UIDemo.ViewModels
{
    public class HistoryViewModel : BindableBase
    {
        public RelayCommand GoDownloadFolderCommand { get;}
        public RelayCommand GoBackCommand { get;}

        public HistoryViewModel(IEventAggregator eventAggregator)
        {
            GoBackCommand = new RelayCommand(() =>
            {
                eventAggregator.GetEvent<GoPageEvent>().Publish("GoBack");
            });
            GoDownloadFolderCommand = new RelayCommand(GoDownloadFolder);
        }

        private void GoDownloadFolder()
        {
            throw new NotImplementedException();
        }
    }
}
