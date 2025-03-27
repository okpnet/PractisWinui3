using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUiTest.Shared.Dtos
{
    public interface IModalOption
    {
        float Opacity { get; }
        bool IsEnabled { get; set; }

        Visibility IsModalVisible { get; }
    }
}
