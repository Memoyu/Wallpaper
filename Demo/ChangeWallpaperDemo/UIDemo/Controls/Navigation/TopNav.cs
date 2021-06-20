using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.Input;

namespace UIDemo.Controls.Navigation
{
    public class TopNav : ContentControl
    {
        #region 依赖属性

        /// <summary>
        /// 内容标题
        /// </summary>
        public string ContentTitle
        {
            get => (string)GetValue(ContentTitleProperty);
            set => SetValue(ContentTitleProperty, value);
        }
        public static readonly DependencyProperty ContentTitleProperty = DependencyProperty.Register("ContentTitle", typeof(string), typeof(TopNav), new PropertyMetadata(default(string)));

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }
        public static readonly DependencyProperty ContentMarginProperty = DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(TopNav), new PropertyMetadata(default(Thickness)));

        public RelayCommand GoBackCommand
        {
            get => (RelayCommand)GetValue(GoBackCommandProperty);
            set => SetValue(GoBackCommandProperty, value);
        }
        public static readonly DependencyProperty GoBackCommandProperty = DependencyProperty.Register("GoBackCommand", typeof(RelayCommand), typeof(TopNav));
        #endregion
    }
}
