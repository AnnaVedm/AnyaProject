﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyaProject
{
    public class User : INotifyPropertyChanged
    {
        private string _userName;
        private string _userPassword;
        private string _userStatus;

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                if (_userStatus != value)
                {
                    _userPassword = value;
                    OnPropertyChanged("UserPassword");
                }
            }
        }

        public string UserStatus
        {
            get { return _userStatus; }
            set
            {
                if (_userStatus != value)
                {
                    _userStatus = value;
                    OnPropertyChanged("UserStatus");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
