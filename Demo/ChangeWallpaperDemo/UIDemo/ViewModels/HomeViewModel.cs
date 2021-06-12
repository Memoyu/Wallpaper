using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using UIDemo.Model;

namespace UIDemo.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        public List<ImagePreviewModel> ImagePreviews { get; set; }

        public HomeViewModel()
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
        }
    }
}
