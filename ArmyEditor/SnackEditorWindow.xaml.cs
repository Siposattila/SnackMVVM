using SnackMVVM.Models;
using SnackMVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SnackMVVM
{
    /// <summary>
    /// Interaction logic for SnackEditor.xaml
    /// </summary>
    public partial class SnackEditor : Window
    {
        public SnackEditor(Snack snack)
        {
            InitializeComponent();
            this.DataContext = new SnackEditorWindowViewModel();
            (this.DataContext as SnackEditorWindowViewModel).Setup(snack);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in stack.Children)
                if(item is TextBox t)
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.DialogResult = true;
        }
    }
}
