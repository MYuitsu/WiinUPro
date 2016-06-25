﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WiinUPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            #region Test
            foreach (var path in NintrollerLib.Nintroller.GetControllerPaths())
            {
                TabItem t = new TabItem();
                //t.Header = "New";
                var stack = new StackPanel() { Orientation = Orientation.Horizontal };
                stack.Children.Add(new Image()
                {
                    Source = new BitmapImage(new Uri("../Images/Icons/ProController_black_24.png", UriKind.Relative)),
                    Height = 12,
                    Margin = new Thickness(0, 0, 4, 0),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left
                });
                stack.Children.Add(new TextBlock() { Text = "TEST" + tabControl.Items.Count.ToString() });
                t.Header = stack;
                NintyControl n = new NintyControl(path);
                n.OnTypeChange += (NintrollerLib.ControllerType type) => { ChangeIcon(t, type); };
                t.Content = n;
                tabControl.Items.Add(t);
            }
            #endregion
        }

        private void AddController(object sender, MouseButtonEventArgs e)
        {
            // More testing
            TabItem test = new TabItem();
            //test.Header = "TEST" + tabControl.Items.Count.ToString();
            var stack = new StackPanel() { Orientation = Orientation.Horizontal };
            stack.Children.Add(new Image()
            {
                Source = new BitmapImage(new Uri("../Images/Icons/ProController_black_24.png", UriKind.Relative)),
                Height = 12,
                Margin = new Thickness(0, 0, 4, 0),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            });
            stack.Children.Add(new TextBlock() { Text = "TEST" + tabControl.Items.Count.ToString() });
            test.Header = stack;
            NintyControl nin = new NintyControl("");
            nin.OnTypeChange += (NintrollerLib.ControllerType type) =>
            {
                ((Image)stack.Children[0]).Source = new BitmapImage(new Uri("../Images/Icons/ProController_white_24.png", UriKind.Relative));
            };
            test.Content = nin;
            tabControl.Items.Insert(tabControl.Items.Count - 1, test);
        }

        private void ChangeIcon(TabItem target, NintrollerLib.ControllerType type)
        {
            string img = "ProController_black_24.png";

            switch (type)
            {
                case NintrollerLib.ControllerType.ProController:
                    img = "ProController_white_24.png";
                    break;

                case NintrollerLib.ControllerType.Wiimote:
                    img = "wiimote_black_24.png";
                    break;

                case NintrollerLib.ControllerType.Nunchuk:
                case NintrollerLib.ControllerType.NunchukB:
                    img = "Wiimote+Nunchuck_black_24.png";
                    break;

                case NintrollerLib.ControllerType.ClassicController:
                    img = "Classic_black_24.png";
                    break;

                case NintrollerLib.ControllerType.ClassicControllerPro:
                    img = "ClassicPro_black_24.png";
                    break;
            }

            var stack = target.Header as StackPanel;
            if (stack != null && stack.Children.Count > 0 && stack.Children[0].GetType() == typeof(Image))
            {
                ((Image)stack.Children[0]).Source = new BitmapImage(new Uri("../Images/Icons/" + img, UriKind.Relative));
            }
        }
    }
}