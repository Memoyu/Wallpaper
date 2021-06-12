using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using UIDemo.Views;
using UIDemo.ViewModels;

namespace UIDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {

        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainViewModel>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>(nameof(HomeView));
            containerRegistry.RegisterForNavigation<HistoryView, HistoryViewModel>(nameof(HistoryView));
            containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>(nameof(SettingView));
            containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>(nameof(AboutView));
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            var mainViewModel = MainWindow?.DataContext as MainViewModel;
            mainViewModel?.OpenPage(nameof(HomeView));
            base.OnInitialized();
        }
    }

}
