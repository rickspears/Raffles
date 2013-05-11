using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raffles.DomainObjects.Events;

namespace Raffles.ViewModels
{
    public class ViewModelBase<T> : NotifyPropertyChanged, IEditableObject
    {
        public ViewModelBase() { }

        public bool IsDirty { get; set; }
        public T Backup { get; set; }

        public void BeginEdit(T value) {
            if (!IsDirty) {
                IsDirty = true;
                Backup = value;
            }
        }
        public void BeginEdit() {
            if (!IsDirty) IsDirty = true;
        }

        public void CancelEdit(T value) {
            IsDirty = false;
            value = Backup;
        }
        public void CancelEdit() {
            IsDirty = false;
        }

        public void EndEdit() {
            IsDirty = false;
        }
    }
}
