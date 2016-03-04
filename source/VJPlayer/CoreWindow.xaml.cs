using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace VJPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CoreWindow : Window
    {
        public CoreWindow()
        {
            InitializeComponent();
            Drop += CoreWindow_Drop;
            MouseDown += CoreWindow_MouseDown;
        }


        /// <summary>
        /// Obsługa drag'n'drop, przekazuje Uri przeciągniętego pliku do mediaElement
        /// </summary>
        private void CoreWindow_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Można przeciągnąć wiele plików (dlatego tablica)
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Na razie pobranie tylko jednego z przeciągniętych plików
                // ToDo: pobierać całą tablicę i w foreachu jakoś to tam układać do listy czy coś
                var filePath = files[0];

                // Utworzenie URI z ścieżki do pliku
                System.Uri uri;
                System.Uri.TryCreate(filePath, System.UriKind.Absolute, out uri);
                mediaElement.Source = uri;
            }

        }

        /// <summary>
        /// Umożliwia przeciąganie okna bez ramek lewym przyciskiem myszy
        /// </summary>
        private void CoreWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (System.InvalidOperationException)
            {

            }
        }

        /// <summary>
        /// Tworzy nowe okno
        /// </summary>
        private void OnSpawnClick(object sender, RoutedEventArgs e)
        {
            CoreWindow newWindow = new CoreWindow();
            newWindow.Show();
        }
    }
}
