using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUiTest.Shared.Dtos
{
    public interface IProgressModalOption: IModalOption
    {
        public double ProgressValue { get; set; }
        IProgress<uint> Progress { get; }
    }
}
