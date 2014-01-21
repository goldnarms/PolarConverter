using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PolarConverter.Win
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void PickInputFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var folderPicker = new FolderPicker {SuggestedStartLocation = PickerLocationId.Desktop};
            folderPicker.FileTypeFilter.Add(".gpx");
            folderPicker.FileTypeFilter.Add(".hrm");
            var folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder (including other sub-folder contents)
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedInputFolderToken", folder);
                InputTextBlock.Text = "Picked folder: " + folder.Name;
            }
            else
            {
                InputTextBlock.Text = "Operation cancelled.";
            }
        }

        private async void PickOutputFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var folderPicker = new FolderPicker {SuggestedStartLocation = PickerLocationId.Desktop};
            folderPicker.FileTypeFilter.Add(".gpx");
            var folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder (including other sub-folder contents)
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedOutputFolderToken", folder);
                OutputTextBlock.Text = "Picked folder: " + folder.Name;
            }
            else
            {
                OutputTextBlock.Text = "Operation cancelled.";
            }
        }
    }
}
