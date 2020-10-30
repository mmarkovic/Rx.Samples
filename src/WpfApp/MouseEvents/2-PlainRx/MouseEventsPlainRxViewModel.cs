// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MouseEventsPlainRxViewModel.cs" author="Marko Marković">
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
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using WpfApp.Annotations;

    public class MouseEventsPlainRxViewModel : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private bool throttleEnabled;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public void SetMousePosition(double x, double y)
        {
            if (!this.ThrottleEnabled)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public void SetThrottledMouseMove(double x, double y)
        {
            if (this.ThrottleEnabled)
            {
                this.X = x;
                this.Y = y;
            }
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