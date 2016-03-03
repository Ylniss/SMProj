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
                var d = files[0];
                OpenFileDialog s = new OpenFileDialog();
                var b = s.FileName;
              
            }

        }

    }
}
