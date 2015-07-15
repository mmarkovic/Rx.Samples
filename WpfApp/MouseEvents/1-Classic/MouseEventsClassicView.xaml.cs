// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MouseEventsClassicView.xaml.cs" author="Marko Marković">
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

// ReSharper disable InconsistentNaming

namespace WpfApp.MouseEvents
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public partial class MouseEventsClassicView : UserControl
    {
        private static readonly long ThrottleDelta = TimeSpan.FromSeconds(0.5).Ticks;

        private long lastMovementInTicks;

        public MouseEventsClassicView()
        {
            this.InitializeComponent();
            this.DataContext = new MouseEventsClassicViewModel();
        }

        private void DockPanel_MouseMove(object sender, MouseEventArgs e)
        {
            var viewModel = (MouseEventsClassicViewModel)this.DataContext;

            if (viewModel.ThrottleEnabled && (DateTime.Now.Ticks - this.lastMovementInTicks) < ThrottleDelta)
            {
                this.lastMovementInTicks = DateTime.Now.Ticks;
                return;
            }

            this.lastMovementInTicks = DateTime.Now.Ticks;

            Point mousePosition = e.GetPosition(this.PlayGround);

            viewModel.X = mousePosition.X;
            viewModel.Y = mousePosition.Y;
        }
    }
}
