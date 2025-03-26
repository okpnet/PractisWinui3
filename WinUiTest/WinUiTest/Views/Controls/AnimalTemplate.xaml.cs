using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUiTest.Views.Dtos;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiTest.Views.Controls
{
    public partial class AnimalTemplate : UserControl,INotifyPropertyChanged
    {
        AnimalEntity _entity;
        public AnimalEntity Entity
        {
            get=> _entity;
            set
            {
                if (object.Equals(_entity,value))
                {
                    return;
                }
                var test = DataContext;
                _entity = value;
                OnPropertyChanged(nameof(Entity));
                System.Diagnostics.Debug.WriteLine($"[UI] Entity = {Entity.Name}");
            }
        }


        public AnimalTemplate()
        {
            this.InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
