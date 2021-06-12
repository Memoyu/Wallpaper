using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace UIDemo.Styles
{
    public class VisualElement
    {
        public static readonly DependencyProperty HighlightBrushProperty = DependencyProperty.RegisterAttached(
            "HighlightBrush", typeof(Brush), typeof(VisualElement), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetHighlightBrush(DependencyObject element, Brush value)
            => element.SetValue(HighlightBrushProperty, value);

        public static Brush GetHighlightBrush(DependencyObject element)
            => (Brush)element.GetValue(HighlightBrushProperty);
    }
}
