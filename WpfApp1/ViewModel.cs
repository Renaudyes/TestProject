using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ViewModel : BaseViewModel<IInterface>
    {


        public string NameVM { get; set; } = "NameVM";

        public string FamilyNameVM { get => _Model.FamilyName; set => _Model.FamilyName = value; }

        public int PatatesVM { get; set; } = 0;

        public ViewModel(IInterface _Model) : base(_Model)
        {
            AddKeyToUpdateValueFromPropertyChanged(nameof(IInterface.Name), nameof(NameVM));
            AddKeyToRaisePropertyChanged(nameof(IInterface.FamilyName), nameof(FamilyNameVM));  
        }

    }
}
