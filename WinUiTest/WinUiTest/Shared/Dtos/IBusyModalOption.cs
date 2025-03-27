using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUiTest.Shared.Dtos
{
    public interface IBusyModalOption: IModalOption
    {
        bool IsBusy { get; set; }
    }
}
