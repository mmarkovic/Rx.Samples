// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" author="Marko Marković">
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

namespace WpfApp
{
    using System;
    using System.Reactive.Linq;
    using System.Windows;
    using System.Windows.Input;

    using WpfApp.MouseEvents;

    public partial class MainWindow : Window
    {
        //private readonly IDisposable mouseMoveSubscription;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void DockPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //Point mousePosition = e.GetPosition(this);
            //var viewModel = (MainViewModel)this.DataContext;

            //viewModel.X = mousePosition.X;
            //viewModel.Y = mousePosition.Y;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //this.mouseMoveSubscription.Dispose();
        }

        private void MouseEvents_Click(object sender, RoutedEventArgs e)
        {
            var mouseEventsSampleWindow = new MouseEventsMainView();
            mouseEventsSampleWindow.Show();
        }
    }
}
