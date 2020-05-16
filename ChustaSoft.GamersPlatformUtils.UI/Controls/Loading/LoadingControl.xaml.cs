using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChustaSoft.GamersPlatformUtils.UI.Controls.Loading
{
    /// <summary>
    /// Lógica de interacción para LoadingControl.xaml
    /// </summary>
    public partial class LoadingControl : UserControl
    {

        public LoadingControl()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(LoadingControl), new PropertyMetadata(null));


        public string BackgroundColor
        {
            get { return (string)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor", typeof(string), typeof(LoadingControl), new PropertyMetadata(null));

        public string TextColor
        {
            get { return (string)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(string), typeof(LoadingControl), new PropertyMetadata(null));

        public double PanelOpacity
        {
            get { return (double)GetValue(PanelOpacityProperty); }
            set { SetValue(PanelOpacityProperty, value); }
        }

        public static readonly DependencyProperty PanelOpacityProperty =
            DependencyProperty.Register("PanelOpacity", typeof(double), typeof(LoadingControl), new PropertyMetadata(null));

        public bool Visible
        {
            get { return (bool)GetValue(VisibleProperty); }
            set { SetValue(VisibleProperty, value); }
        }

        public static readonly DependencyProperty VisibleProperty =
            DependencyProperty.Register("Visible", typeof(bool), typeof(LoadingControl), new PropertyMetadata(null));

        public bool TopBarVisible
        {
            get { return (bool)GetValue(TopBarVisibleProperty); }
            set { SetValue(TopBarVisibleProperty, value); }
        }

        public static readonly DependencyProperty TopBarVisibleProperty =
            DependencyProperty.Register("TopBarVisible", typeof(bool), typeof(LoadingControl), new PropertyMetadata(null));

        public bool BottomBarVisible
        {
            get { return (bool)GetValue(BottomBarVisibleProperty); }
            set { SetValue(BottomBarVisibleProperty, value); }
        }

        public static readonly DependencyProperty BottomBarVisibleProperty =
            DependencyProperty.Register("BottomBarVisible", typeof(bool), typeof(LoadingControl), new PropertyMetadata(null));

        public float PanelWidth
        {
            get { return (float)GetValue(PanelWidthProperty); }
            set { SetValue(PanelWidthProperty, value); }
        }

        public static readonly DependencyProperty PanelWidthProperty =
            DependencyProperty.Register("PanelWidth", typeof(float), typeof(LoadingControl), new PropertyMetadata(null));

    }
}
