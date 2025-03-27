﻿using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUiTest.Core;

namespace WinUiTest.Shared.Dtos
{
    public abstract class ModalOptionBase : NotifyPropertyChangedBase, INotifyPropertyChanged, IModalOption
    {
        private float _opacity = 1.0F;
        public float Opacity
        {
            get => _opacity;
            set
            {
                if (_opacity == value)
                {
                    return;
                }
                _opacity = value;
                OnPropertyChanged(nameof(Opacity));
            }
        }

        private bool _isEnabled = false;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled == value)
                {
                    return;
                }
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
                OnPropertyChanged(nameof(IsModalVisible));
                System.Diagnostics.Debug.WriteLine($"[UI] {nameof(IsEnabled)} = {IsEnabled}");
                System.Diagnostics.Debug.WriteLine($"[UI] {nameof(IsModalVisible)} = {IsModalVisible}");
            }
        }

        public Visibility IsModalVisible => IsEnabled ? Visibility.Visible : Visibility.Collapsed;
    }
}
