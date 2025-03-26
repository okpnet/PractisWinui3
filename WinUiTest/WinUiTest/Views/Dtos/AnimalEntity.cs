using Microsoft.UI.Dispatching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUiTest.Views.Dtos
{
    public class AnimalEntity: INotifyPropertyChanged
    {
        bool _isBusy=false;
        public bool IsBusy {
            get => _isBusy;
            protected set
            {
                if (_isBusy == value)
                {
                    return;
                }
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
                System.Diagnostics.Debug.WriteLine($"[UI] IsBusy = {IsBusy}");
            }
        }

        string _name;
        public string Name 
        {
            get => _name;
            set
            {
                if (_name == value)
                {
                    return;
                }
                _name = value;
                OnPropertyChanged(nameof(Name));
                System.Diagnostics.Debug.WriteLine($"[UI] Name = {Name}");
            }
        }

        public float Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void StartInit()=>IsBusy = false;

        public async Task Loading()//DispatcherQueue dispatcher)
        {
            
            IsBusy = true;
            var secRnd = new Random(DateTime.Now.Millisecond);
            var waitsec= secRnd.Next(8)+2;
            System.Diagnostics.Debug.WriteLine($"True: wait {waitsec}sec");
            await Task.Delay(waitsec*1000);
            Name=Guid.NewGuid().ToString();
            IsBusy = false;
            System.Diagnostics.Debug.WriteLine("False");
        }
    }
}
