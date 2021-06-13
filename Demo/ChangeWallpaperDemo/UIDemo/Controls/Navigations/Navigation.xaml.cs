using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.Input;

namespace UIDemo.Controls.Navigations
{

    /// <summary>
    /// Navigation.xaml 的交互逻辑
    /// </summary>
    public partial class Navigation : Border
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
        public static readonly DependencyProperty ContentTitleProperty = DependencyProperty.Register("ContentTitle", typeof(string), typeof(Navigation), new PropertyMetadata(""));

        ///// <summary>
        ///// 子操作内容
        ///// </summary>
        //public object SubContent
        //{
        //    get => GetValue(SubContentProperty);
        //    set => SetValue(SubContentProperty, value);
        //}
        //public static readonly DependencyProperty SubContentProperty = DependencyProperty.Register("SubContent", typeof(object), typeof(Navigation));

        public RelayCommand GoBackCommand
        {
            get => (RelayCommand)GetValue(GoBackCommandProperty);
            set => SetValue(GoBackCommandProperty, value);
        }
        public static readonly DependencyProperty GoBackCommandProperty = DependencyProperty.Register("GoBackCommand", typeof(RelayCommand), typeof(Navigation));
        #endregion

        public Navigation()
        {
            InitializeComponent();

        }


    }
}
