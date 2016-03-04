using Microsoft.Win32;
using System.Windows;

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
           
        }

        private void CoreWindow_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.
                var filePath = files[0];

                System.Uri uri;
                System.Uri.TryCreate(filePath, System.UriKind.Absolute, out uri);
                mediaElement.Source = uri;
            }

        }

    }
}
