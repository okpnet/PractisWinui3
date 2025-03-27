using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using WinRT.Interop;
using WinUiTest.Presentation.Facades;
using WinUiTest.Presentation.Services;
using WinUiTest.Shared.Dtos;
using WinUiTest.Views.Dtos;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiTest
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public string OutPutDir { get; set; }

        public AnimalCollectionService AnimalService { get; }

        public ProgressModalOption ProgressModalOption { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();
            AnimalService = new(AnimalPanels.Animals);
            ProgressModalOption = new (new());
        }

        private async void DirSelect_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FolderPicker();
            InitializeWithWindow.Initialize(picker, WindowNative.GetWindowHandle(this));
            var folder=await picker.PickSingleFolderAsync();
            if(folder is  null)
            {
                return;
            }
            OutPutDir = folder.Name;
        }

        private void MainFrame_DragOver(object sender, DragEventArgs e)
        {
            if (!e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                e.AcceptedOperation = DataPackageOperation.None;
                return;
            }
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
        }

        private async void MainFrame_Drop(object sender, DragEventArgs e)
        {
            if (!e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                return;
            }
            var items =await e.DataView.GetStorageItemsAsync();
            AnimalService.AddAnimalItems(items.Select(t => t.Path));
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            await AnimalService.AllLoad(ProgressModalOption);
        }
    }
}
