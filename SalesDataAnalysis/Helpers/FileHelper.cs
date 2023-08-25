using System;
using System.Security;
using System.Windows.Forms;

namespace SalesDataAnalysis.Helpers
{
    /// <summary>
    /// Handler for working with dialogs
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Opens a dialog in which a file from the systems storage can be chosen and returns the selected files path
        /// </summary>
        /// <returns>string</returns>
        public static string OpenFileDialog()
        {
            try
            {
                var dialog = new OpenFileDialog();
                return dialog.ShowDialog() != DialogResult.OK ? null : dialog.FileName;
            }
            catch (SecurityException exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        /// Opens a dialog in which a folder from the systems storage can be chosen and returns the selected folders path
        /// </summary>
        /// <returns>string</returns>
        public static string ChoosePathDialog()
        {
            try
            {
                var dialog = new FolderBrowserDialog();
                return dialog.ShowDialog() != DialogResult.OK ? null : dialog.SelectedPath;
            }
            catch (SecurityException exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}