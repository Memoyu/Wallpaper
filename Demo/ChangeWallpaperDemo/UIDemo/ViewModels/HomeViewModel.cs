using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.Input;
using Prism.Events;
using Prism.Mvvm;
using UIDemo.Model;

namespace UIDemo.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        #region 属性
        public List<ImagePreviewModel> ImagePreviews { get; set; }
        #endregion

        #region Command

        /// <summary>
        /// 跳转新页面
        /// </summary>
        public RelayCommand GoSettingCommand { get; private set; }
        public RelayCommand GoHistoryCommand { get; private set; }

        #endregion

        private readonly IEventAggregator _eventAggregator;

        public HomeViewModel(IEventAggregator eventAggregator)
        {
            ImagePreviews = new List<ImagePreviewModel>
            {
                new ImagePreviewModel
                {
                    DownloadUrl = "",
                    PreviewUrl = "/Resources/unsplash.jpg"
                },
                new ImagePreviewModel
                {
                    DownloadUrl = "",
                    PreviewUrl = "/Resources/unsplash1.jpg"
                },
                new ImagePreviewModel
                {
                    DownloadUrl = "",
                    PreviewUrl = "/Resources/unsplash2.jpg"
                },
                new ImagePreviewModel
                {
                    DownloadUrl = "",
                    PreviewUrl = "/Resources/unsplash1.jpg"
                },
                new ImagePreviewModel
                {
                    DownloadUrl = "",
                    PreviewUrl = "/Resources/unsplash.jpg"
                },
                new ImagePreviewModel
                {
                    DownloadUrl = "",
                    PreviewUrl = "/Resources/unsplash2.jpg"
                }
            };
            GoSettingCommand = new RelayCommand(()=> GoPage("SettingView"));
            GoHistoryCommand = new RelayCommand(() => GoPage("HistoryView"));
            _eventAggregator = eventAggregator;
            
        }

        private void GoPage(string pageNam)
        {
            _eventAggregator.GetEvent<GoPageEvent>().Publish(pageNam);
        }
    }
}
