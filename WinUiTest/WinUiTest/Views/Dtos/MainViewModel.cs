using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WinUiTest.Presentation.Facades;

namespace WinUiTest.Views.Dtos
{
    public class MainViewModel:IDisposable,INotifyPropertyChanged
    {
        CompositeDisposable _compositeDisposable = new();
        bool _isBusy = false;
        bool _isAnimals = false;

        public string OutPutDir { get; set; }

        public bool IsAnimals
        {
            get => _isAnimals;
            private set
            {
                if (_isAnimals == value)
                {
                    return;
                }
                _isAnimals = value;
                OnPropertyChanged(nameof(IsAnimals));
                System.Diagnostics.Debug.WriteLine($"[UI] IsAnimals = {IsAnimals}");
            }
        }

        public bool IsBusy 
        {
            get => _isBusy;
            private set
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

        public AnimalDoctor AnimalsDoctor { get; }



        public MainViewModel(AnimalDoctor animalEntities)
        {
            AnimalsDoctor = animalEntities;
            _compositeDisposable.Add(
                    Observable.
                    FromEventPattern<NotifyCollectionChangedEventArgs>(AnimalsDoctor, nameof(AnimalsDoctor.CollectionChanged)).
                    Subscribe((e) =>
                    {
                        IsAnimals = AnimalsDoctor.Any();
                    })
                );
        }

        public void AddAnimalItems(IEnumerable<string> paths)
        {
            foreach (var path in paths)
            {
                var fileName = System.IO.Path.GetFileNameWithoutExtension(path);
                if (fileName is (null or ""))
                {
                    continue;
                }
                AnimalsDoctor.Add(new AnimalEntity { Name = fileName });
            }
        }

        public async Task AllLoad()
        {
            IsBusy = true;
            var tasks = AnimalsDoctor.Select(t => t.Loading()).ToList();
            await Task.WhenAll(tasks);
            IsBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
