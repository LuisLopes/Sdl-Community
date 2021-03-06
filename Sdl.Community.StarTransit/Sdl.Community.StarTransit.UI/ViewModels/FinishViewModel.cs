﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Sdl.Community.StarTransit.Shared.Models;
using Sdl.Community.StarTransit.Shared.Services;
using Sdl.Community.StarTransit.Shared.Utils;
using Sdl.Community.StarTransit.UI.Annotations;

namespace Sdl.Community.StarTransit.UI.ViewModels
{
    public class FinishViewModel: INotifyPropertyChanged
    {
        private bool _active;
        private  string _location;
        private   string _txtName;
        private  string _txtDescription;
        private   string _sourceLanguage;
        private  string _targetLanguage;
        private  string _templateName;
        private  string _customer;
        private  string _dueDate;
        private readonly PackageDetailsViewModel _packageDetailsViewModel;

        public FinishViewModel(PackageDetailsViewModel packageDetailsViewModel)
        {
            _packageDetailsViewModel = packageDetailsViewModel;
            
            Refresh();
            
          
        }

        public void Refresh()
        {
            
                Name = _packageDetailsViewModel.Name;
                Location = _packageDetailsViewModel.TextLocation;
                if (_packageDetailsViewModel.HasDueDate)
                {
                    DueDate =
                        Helpers.TimeHelper.SetDateTime(_packageDetailsViewModel.DueDate,
                            _packageDetailsViewModel.SelectedHour, _packageDetailsViewModel.SelectedMinute,
                            _packageDetailsViewModel.SelectedMoment).ToString();
                }

                if (_packageDetailsViewModel.Template != null)
                {
                    TemplateName = _packageDetailsViewModel.Template.Name;
                }
                if (_packageDetailsViewModel.SelectedCustomer != null)
                {
                    Customer = _packageDetailsViewModel.SelectedCustomer.Name;
                }

                Description = _packageDetailsViewModel.Description;
                SourceLanguage = _packageDetailsViewModel.SourceLanguage;
                TargetLanguage = _packageDetailsViewModel.TargetLanguage;
            
          
        }
   
        public string Name
        {
            get { return _packageDetailsViewModel.Name ; }
            set
            {
                if (Equals(value, _txtName))
                {
                    return;
                }
                _txtName = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _txtDescription; }
            set
            {
                if (Equals(value, _txtDescription))
                {
                    return;
                }
                _txtDescription = value;
                OnPropertyChanged();
            }
        }

        public string SourceLanguage
        {
            get { return _packageDetailsViewModel.SourceLanguage; }
            set
            {
                if (Equals(value, _sourceLanguage))
                {
                    return;

                }
                _sourceLanguage = value;
                OnPropertyChanged();
            }
        }

        public string TargetLanguage
        {
            get { return _targetLanguage; }
            set
            {
                if (Equals(value, _targetLanguage))
                {
                    return;
                }
                _targetLanguage = value;
                OnPropertyChanged();
            }
        }

        public string Location
        {
            get { return _packageDetailsViewModel.TextLocation; }
            set
            {
                if (Equals(value, _location))
                {
                    return;
                }
                _location = value;
                OnPropertyChanged();
            }
        }

        public bool Active
        {
            get { return _active; }
            set
            {
                if (Equals(value, _active))
                {
                    return;
                }
                _active = value;
                OnPropertyChanged();
            }
        }

        public string TemplateName
        {
            get { return _templateName; }
            set
            {
                if (Equals(value,_templateName))
                {
                    return;
                    
                }
                _templateName = value;
                OnPropertyChanged();
            }
        }

        public string Customer
        {
            get { return _customer; }
            set
            {
                if (Equals(value, _customer))
                {
                    return;
                    
                }
                _customer = value;
                OnPropertyChanged();
            }
        }

        public string DueDate
        {
            get { return _dueDate; }
            set
            {
                if (Equals(value, _dueDate))
                {
                    return;
                }
                _dueDate = value;
                OnPropertyChanged();

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
      
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
