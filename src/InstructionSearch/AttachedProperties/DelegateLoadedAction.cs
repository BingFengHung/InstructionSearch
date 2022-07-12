using System;
using System.Windows;

namespace InstructionSearch
{
    internal class DelegateLoadedAction : ILoadedAction
    {
        public Action<object, RoutedEventArgs> LoadedActionDelegate { get; set; }

        public DelegateLoadedAction(Action<object, RoutedEventArgs> action)
        {
            LoadedActionDelegate = action;
        }

        public void WindowLoaded(object sender, RoutedEventArgs e)
        {
            LoadedActionDelegate?.Invoke(sender, e);
        }
    }
}
