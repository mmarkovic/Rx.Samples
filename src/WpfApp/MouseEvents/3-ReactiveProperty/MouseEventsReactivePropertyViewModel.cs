﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MouseEventsReactivePropertyViewModel.cs" author="Marko Marković">
//   Copyright (c) 2015
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//   http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfApp.MouseEvents
{
    using System;
    using System.ComponentModel;
    using System.Reactive.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    using Reactive.Bindings;

    using WpfApp.Annotations;

    public class MouseEventsReactivePropertyViewModel : INotifyPropertyChanged, IDisposable
    {
        private double x;
        private double y;

        private bool throttleEnabled;

        public MouseEventsReactivePropertyViewModel()
        {
            this.MouseMove = new ReactiveProperty<MouseEventArgs>(mode: ReactivePropertyMode.None);
            this.MouseMove.Select(x => x.GetPosition(x.Source as UIElement))
                .Subscribe(
                    position =>
                    {
                        this.X = position.X;
                        this.Y = position.Y;
                    });

            this.ThrottledMouseMove = new ReactiveProperty<MouseEventArgs>(mode: ReactivePropertyMode.None);
            this.ThrottledMouseMove.Select(x => x.GetPosition(x.Source as UIElement))
                .Throttle(TimeSpan.FromSeconds(0.5))
                .Subscribe(
                    position =>
                    {
                        this.X = position.X;
                        this.Y = position.Y;
                    });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ReactiveProperty<MouseEventArgs> MouseMove { get; private set; }

        public ReactiveProperty<MouseEventArgs> ThrottledMouseMove { get; private set; }

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
                this.OnPropertyChanged();
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
                this.OnPropertyChanged();
            }
        }

        public bool ThrottleEnabled
        {
            get
            {
                return this.throttleEnabled;
            }

            set
            {
                if (value != this.throttleEnabled)
                {
                    this.throttleEnabled = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public void Dispose()
        {
            this.MouseMove.Dispose();
            this.ThrottledMouseMove.Dispose();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}