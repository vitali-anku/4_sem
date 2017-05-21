using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

namespace OOPLab08.Commands
{
    public class WindowCommands
    {
        static WindowCommands()
        {
            InputGestureCollection exitGesture = new InputGestureCollection();
            exitGesture.Add(new KeyGesture(Key.Q, ModifierKeys.Control, "Ctrl + Q"));

            Exit = new RoutedCommand("Exit", typeof(MainWindow), exitGesture);
            ChangeLanguage = new RoutedCommand("Change language", typeof(Menu));
        }

        public static RoutedCommand Exit { get; }
        public static RoutedCommand ChangeLanguage { get; }
    }
}