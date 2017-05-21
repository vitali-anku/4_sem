using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Resources;
using System.Runtime.CompilerServices;

namespace OOPLab08
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string mainWindowTitle = "MapTextEditor";
        private ObservableCollection<string> openedDocuments;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> OpenedDocuments
        {

            get { return openedDocuments; }
            set
            {
                openedDocuments = value;
                OnPropertyChanged();
            }
        }

        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();

            //Resources.Source = new Uri(@"Localization/RussianLanguage.xaml", UriKind.Relative);

            AddNewTab();
            ChangeWindowTitle();
            OpenedDocuments = new ObservableCollection<string>();
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeWindowTitle();
            UpdateStatusBar();
        }

        private void NewRichTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateStatusBar();
        }

        private void Scaling_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            (sender as Slider).SelectionEnd = e.NewValue;
            if (e.NewValue > 8.0)   // 8.0 - минимальный размер текста в RTB
            {
                (GetSelectedUserDocumentTab().Content as RichTextBox).Selection.ApplyPropertyValue(FontSizeProperty, e.NewValue);
            }
        }

        // --- Вспомогательные методы --- 

        /// <summary>
        /// Добавить новую вкладку с документом
        /// </summary>
        private void AddNewTab()
        {
            MenuItem newContextMenuItem = new MenuItem() { Header = "Закрыть", Command = ApplicationCommands.Close };

            ContextMenu newContextMenu = new ContextMenu();
            newContextMenu.Items.Add(newContextMenuItem);

            RichTextBox newRichTextBox = new RichTextBox();
            newRichTextBox.SpellCheck.IsEnabled = true;           // проверка орфографии
            newRichTextBox.Document.LineHeight = 0.5;             // межстрочный интервал
            newRichTextBox.KeyUp += NewRichTextBox_KeyUp;
            newRichTextBox.AllowDrop = true;
            newRichTextBox.PreviewDragEnter += UserDocumentTab_PreviewDragEnter;
            newRichTextBox.ForceCursor = true;
            newRichTextBox.Cursor = new Cursor(@"D:\visual_studio\ООП\Lab9-10\OOPLab08\cursor.cur");

            UserDocumentTab userDocumentTab = new UserDocumentTab()
            {
                Header = (string)FindResource("Key_NewFileName") + (Tabs.Items.Count + 1),
                Content = newRichTextBox,
                ContextMenu = newContextMenu,
                IsSelected = true
            };

            Tabs.Items.Add(userDocumentTab);
        }

        private void UserDocumentTab_PreviewDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);

                UserDocumentTab currentUserDocumentTab = GetSelectedUserDocumentTab();
                RichTextBox documentContent = currentUserDocumentTab.Content as RichTextBox;

                using (FileStream fs = new FileStream(docPath[0], FileMode.Open))
                {
                    new TextRange(documentContent.Document.ContentStart, documentContent.Document.ContentEnd).Load(fs, DataFormats.Rtf);

                    currentUserDocumentTab.Header = docPath[0].Split('\\').Last();
                    currentUserDocumentTab.Path = docPath[0];

                    UpdateStatusBar();
                }
            }
        }

        /// <summary>
        /// Получить активную в данный момент вкладку с пользовательским документом
        /// </summary>
        private UserDocumentTab GetSelectedUserDocumentTab()
        {
            return Tabs.SelectedItem as UserDocumentTab;
        }

        /// <summary>
        /// Изменить заголовок главного окна в соответствии с открытым на данный момент файлом
        /// </summary>
        private void ChangeWindowTitle()
        {
            UserDocumentTab udt = GetSelectedUserDocumentTab();
            if (udt != null)
            {
                this.Title = udt.Path ?? udt.Header as string;
                this.Title += " - " + mainWindowTitle;
            }
        }

        /// <summary>
        /// Открывает диалог для сохранения файла
        /// </summary>
        private void SaveUserDocumentAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "RTF-файлы (*.rtf)|*.rtf";
            sfd.InitialDirectory = Directory.GetCurrentDirectory();

            if (sfd.ShowDialog() == true)
            {
                UserDocumentTab currentUserDocumentTab = GetSelectedUserDocumentTab();
                RichTextBox documentContent = (currentUserDocumentTab.Content as RichTextBox);

                using (FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate))
                {
                    new TextRange(documentContent.Document.ContentStart, documentContent.Document.ContentEnd).Save(fs, DataFormats.Rtf);
                    currentUserDocumentTab.Header = sfd.SafeFileName;
                    currentUserDocumentTab.Path = sfd.FileName;
                }

                ChangeWindowTitle();
            }
        }

        /// <summary>
        /// Обновить количество символов и слов в статус-баре
        /// </summary>
        private void UpdateStatusBar()
        {
            UserDocumentTab userDocumentTab = GetSelectedUserDocumentTab();
            if (userDocumentTab != null)
            {
                RichTextBox documentContent = userDocumentTab.Content as RichTextBox;
                string text = new TextRange(documentContent.Document.ContentStart, documentContent.Document.ContentEnd).Text;

                NumOfSymbols.Content = text.Count().ToString();
                NumOfWords.Content = text.WordCount().ToString();
            }
        }

        /// <summary>
        /// Закрыть вкладку с документом
        /// </summary>
        private void CloseUserDocumentTab()
        {
            Tabs.Items.Remove(GetSelectedUserDocumentTab());

            if (Tabs.Items.IsEmpty)
            {
                AddNewTab();
            }

            ChangeWindowTitle();
        }

        // --- Обработчики команд ---

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddNewTab();
            ChangeWindowTitle();
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RTF-файлы (*.rtf)|*.rtf";
            ofd.InitialDirectory = Directory.GetCurrentDirectory();

            if (ofd.ShowDialog() == true)
            {
                bool sameFileIsOpen = false;

                foreach (UserDocumentTab udt in Tabs.Items)
                {
                    if (udt.Path == ofd.FileName)
                    {
                        sameFileIsOpen = true;
                        break;
                    }
                }

                if (!sameFileIsOpen)
                {
                    AddNewTab();

                    UserDocumentTab currentUserDocumentTab = GetSelectedUserDocumentTab();
                    RichTextBox documentContent = (currentUserDocumentTab.Content as RichTextBox);

                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        new TextRange(documentContent.Document.ContentStart, documentContent.Document.ContentEnd).Load(fs, DataFormats.Rtf);

                        currentUserDocumentTab.Header = ofd.SafeFileName;
                        currentUserDocumentTab.Path = ofd.FileName;
                        OpenedDocuments.Add(ofd.FileName);

                        UpdateStatusBar();
                    }
                    ChangeWindowTitle();
                }
            }
        }

        private void OpenRecentOpenedWindow(object sender, MouseButtonEventArgs e)
        {
            bool sameFileIsOpen = false;

            foreach (UserDocumentTab udt in Tabs.Items)
            {
                if (udt.Path == selectedItem)
                {
                    sameFileIsOpen = true;
                    break;
                }
            }

            if (!sameFileIsOpen)
            {
                AddNewTab();

                UserDocumentTab currentUserDocumentTab = GetSelectedUserDocumentTab();
                RichTextBox documentContent = (currentUserDocumentTab.Content as RichTextBox);

                using (FileStream fs = new FileStream(SelectedItem, FileMode.Open))
                {
                    new TextRange(documentContent.Document.ContentStart, documentContent.Document.ContentEnd).Load(fs, DataFormats.Rtf);

                    currentUserDocumentTab.Header = "Opened Window";
                    currentUserDocumentTab.Path = SelectedItem;

                    UpdateStatusBar();
                }

                ChangeWindowTitle();
            }
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UserDocumentTab currentUserDocumentTab = GetSelectedUserDocumentTab();

            if (currentUserDocumentTab.Path == null)
            {
                SaveUserDocumentAs();
            }
            else
            {
                RichTextBox documentContent = currentUserDocumentTab.Content as RichTextBox;

                using (FileStream fs = new FileStream(currentUserDocumentTab.Path, FileMode.Open))
                {
                    new TextRange(documentContent.Document.ContentStart, documentContent.Document.ContentEnd).Save(fs, DataFormats.Rtf);
                }
            }
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveUserDocumentAs();
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CloseUserDocumentTab();
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RichTextBox document = GetSelectedUserDocumentTab().Content as RichTextBox;

            if (!document.Selection.IsEmpty)
            {
                document.Selection.ApplyPropertyValue(FontFamilyProperty, ((ComboBoxItem)FontComboBox.SelectedItem).Content.ToString());
            }
        }

        private void ChangeLanguageCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            switch ((sender as MenuItem).Header.ToString())
            {
                case "English":
                    Resources.MergedDictionaries[0].Source = new Uri(@"Localization/EnglishLanguage.xaml", UriKind.Relative);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-IN");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-IN");
                    break;

                case "Русский":
                    Resources.MergedDictionaries[0].Source = new Uri(@"Localization/RussianLanguage.xaml", UriKind.Relative);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");                    
                    break;
            }
        }

        private void ThemeGrey(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"Localization/GreyTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDic = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDic);
        }

        private void ThemeFunny(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"Localization/FunnyTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDic = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDic);
        }

    }
}