using System.Windows;
using System.Windows.Controls;

namespace InstructionSearch
{

    public static class FocusExtension
    {
        public static bool GetIsFocused(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFocusedProperty);
        }


        public static void SetIsFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }


        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached(
             "IsFocused", typeof(bool), typeof(FocusExtension),
             new PropertyMetadata(false, OnIsFocusedPropertyChanged));


        private static void OnIsFocusedPropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                var uie = d as TextBox;

                if (uie != null)
                {
                    uie.Focus();
                }
            }
        }
    }
}
