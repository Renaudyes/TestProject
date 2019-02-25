using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Model : IInterface
    {
        public string Name { get; set; } = "test";

        public string FamilyName { get; set; } = "famil";

        public int Patates { get; set; } = 0;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
