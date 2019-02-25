using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public BaseViewModel()
        {

        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class BaseViewModel<T> : BaseViewModel where T : INotifyPropertyChanged
    {
        private Dictionary<string, string> RaisePropertyChanged = new Dictionary<string, string>();
        private Dictionary<string, string> UpdateValueFromPropertyChanged = new Dictionary<string, string>();

        protected T _Model;

        public BaseViewModel(T Model)
        {
            this._Model = Model;

            Model.PropertyChanged += (sender, e) =>
            {
                if (RaisePropertyChanged.ContainsKey(e.PropertyName))
                {
                    OnPropertyChanged(RaisePropertyChanged[e.PropertyName]);
                    return;
                }
                if(UpdateValueFromPropertyChanged.ContainsKey(e.PropertyName))
                {
                    var ObjectToSet = sender.GetType().GetProperty(e.PropertyName).GetValue(sender, null);
                    PropertyInfo propertySent = sender.GetType().GetProperty(e.PropertyName);
                    this.GetType().GetProperty(UpdateValueFromPropertyChanged[e.PropertyName]).SetValue(this, ObjectToSet);
                    return;
                }

            };
        }

        protected void AddKeyToRaisePropertyChanged(string NameOfPropertyModel, string NameOfPropertyViewModel)
        {
            RaisePropertyChanged.Add(NameOfPropertyModel, NameOfPropertyViewModel);
        }
        protected void AddKeyToUpdateValueFromPropertyChanged(string NameOfPropertyModel, string NameOfPropertyViewModel)
        {
            UpdateValueFromPropertyChanged.Add(NameOfPropertyModel, NameOfPropertyViewModel);
        }

    }

}
