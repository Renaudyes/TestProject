using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface IInterface : INotifyPropertyChanged
    {
        string Name { get; set; }

        string FamilyName { get; set; }

        int Patates { get; set; }
    }
}
