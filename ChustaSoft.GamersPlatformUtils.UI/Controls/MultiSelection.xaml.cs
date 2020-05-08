using ChustaSoft.GamersPlatformUtils.UI.Models;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace ChustaSoft.GamersPlatformUtils.UI.Controls
{
    public partial class MultiSelection : UserControl
    {

        public static DependencyProperty DefaultTextProperty =
            DependencyProperty.Register(nameof(DefaultText), typeof(string), typeof(MultiSelection));

        public static DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(Items), typeof(IEnumerable), typeof(MultiSelection));

        public static DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(ItemSelected), typeof(SelectableOption), typeof(MultiSelection));


        public string DefaultText
        {
            get { return (string)GetValue(DefaultTextProperty); }
            set { SetValue(DefaultTextProperty, value); }
        }

        public IEnumerable Items
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public SelectableOption ItemSelected
        {
            get { return (SelectableOption)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }


        public MultiSelection()
        {
            InitializeComponent();
        }

    }
}
