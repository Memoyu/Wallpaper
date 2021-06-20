using Microsoft.Toolkit.Mvvm.Input;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using UIDemo.Model;

namespace UIDemo.ViewModels
{
    public class SettingViewModel : BindableBase
    {
        public string Title { get; } = "首页";
        public RelayCommand GoBackCommand { get; }

        public SettingViewModel(IEventAggregator eventAggregator)
        {
            GoBackCommand = new RelayCommand(() =>
            {
                eventAggregator.GetEvent<GoPageEvent>().Publish("GoBack");
            });
        }

    }
}
