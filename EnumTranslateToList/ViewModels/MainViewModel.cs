using EnumTranslateToList.Model;
using GalaSoft.MvvmLight;
using System;

namespace EnumTranslateToList.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Type _selectionType;

        public Type SelectionType
        {
            get { return _selectionType; }
            set
            {
                if (_selectionType == value)
                    return;

                _selectionType = value;
                RaisePropertyChanged();
            }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex == value)
                    return;

                _selectedIndex = value;

                this.SelectedValue = Enum.GetValues(this.SelectionType).GetValue(SelectedIndex).ToString();

                RaisePropertyChanged();
            }
        }

        private string _selectedValue;
        public string SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if(_selectedValue == value)
                    return;

                _selectedValue = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            this.SelectionType = typeof (Enums.Gender);
            _selectedIndex = -1;
        }
    }
}
