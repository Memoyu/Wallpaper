using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using UIDemo.Model;

namespace UIDemo.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal _navigationJournal;

        public MainViewModel(IContainerProvider containerProvider, IEventAggregator eventAggregator)
        {
            regionManager = containerProvider.Resolve<IRegionManager>();
            eventAggregator.GetEvent<GoPageEvent>().Subscribe(OpenPage);
        }

        /// <summary>
        /// 打开页面
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public void OpenPage(string pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName)) return;
            if (pageName.Equals("GoBack"))
            {
                _navigationJournal.GoBack();
            }
            else
            {
                var region = regionManager.Regions["MainContent"];
                region.RequestNavigate(pageName, arg =>
                {
                    _navigationJournal = arg.Context.NavigationService.Journal;
                });
            }
           
        }
    }
}
