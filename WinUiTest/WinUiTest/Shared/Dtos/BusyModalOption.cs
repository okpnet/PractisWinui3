using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUiTest.Shared.Dtos
{
    public class BusyModalOption : ModalOptionBase, INotifyPropertyChanged, IBusyModalOption
    {
        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                {
                    return;
                }
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
    }
}
