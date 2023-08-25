using System.Security;
using System.Windows.Forms;

namespace SalesDataAnalysis.Helpers
{
    public static class FileHelper
    {
        public static string OpenFileDialog()
        {
            try
            {
                var dialog = new OpenFileDialog();
                return dialog.ShowDialog() != DialogResult.OK ? null : dialog.FileName;
            }
            catch (SecurityException exception)
            {
                MessageBox.Show(exception.Message);
            }

            return null;
        }

        public static string ChoosePathDialog()
        {
            try
            {
                var dialog = new FolderBrowserDialog();
                return dialog.ShowDialog() != DialogResult.OK ? null : dialog.SelectedPath;
            }
            catch (SecurityException exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            return null;
        }
    }
}