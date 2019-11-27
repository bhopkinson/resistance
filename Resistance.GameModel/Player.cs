using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Resistance.GameModels
{
    public class Player : INotifyPropertyChanged
    {
        private Guid _id;
        private string _name;
        private Character _character;
        private bool _isReady;

        public Guid Id
        {
            get => _id;

            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;

            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public Character Character
        {
            get => _character;

            set
            {
                _character = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsReady
        {
            get => _isReady;

            set
            {
                _isReady = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
