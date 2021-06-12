using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Regions;
using UIDemo.Model;

namespace UIDemo.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public MainViewModel(IContainerProvider containerProvider)
        {
            regionManager = containerProvider.Resolve<IRegionManager>();
        }

        /// <summary>
        /// 打开页面
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public void OpenPage(string pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName)) return;

            var region = regionManager.Regions["MainContent"];
            region.RequestNavigate(pageName, arg =>
            {
                //..
            });
        }
    }
}
