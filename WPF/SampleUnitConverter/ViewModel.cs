﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleUnitConverter {
    public class ViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //if(this.PropertyChanged != null) {
            //    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}
        }
    }
}
