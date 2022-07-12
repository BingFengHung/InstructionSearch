using System.Windows;

namespace InstructionSearch
{
    interface ILoadedAction
    {
        void WindowLoaded(object sender, RoutedEventArgs e);
    }
}
