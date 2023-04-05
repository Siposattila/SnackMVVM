using SnackMVVM.Logic;
using SnackMVVM.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SnackMVVM.ViewModels
{
    public class MainWindowViewModel: ObservableRecipient
    {
        ISnackLogic logic;
        public ObservableCollection<Snack> Shelf { get; set; }
        
        private Snack selectedFromShelf;

        public Snack SelectedFromShelf
        {
            get { return selectedFromShelf; }
            set { SetProperty(ref selectedFromShelf, value);
                (AddSnack as RelayCommand).NotifyCanExecuteChanged();
                (EditSnack as RelayCommand).NotifyCanExecuteChanged();
                (BuySnack as RelayCommand).NotifyCanExecuteChanged();

            }
        }

        public ICommand AddSnack { get; set; }
        public ICommand RemoveSnack { get; set; }
        public ICommand EditSnack { get; set; }
        public ICommand BuySnack { get; set; }

        public int Income { get { return logic.Income; } }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
            :this(IsInDesignMode ? null : Ioc.Default.GetService<ISnackLogic>())
        {

        }
        public MainWindowViewModel(ISnackLogic logic)
        {
            this.logic = logic;

            Shelf = new ObservableCollection<Snack>()
            {
                new Snack(){Name="Bal twix",Amount=20,Price=300},
                new Snack(){Name="Jobb twix",Amount=20,Price=310},
                new Snack(){Name="Moment",Amount=11,Price=280}
            };
            logic.SetupCollections(Shelf);
            AddSnack = new RelayCommand(
                () => logic.AddToSnackShelf(new Snack()),
                () => selectedFromShelf != null
                );
            RemoveSnack = new RelayCommand(
                () => logic.RemoveFromSnackShelf(SelectedFromShelf),
                () => selectedFromShelf != null
                );
            EditSnack = new RelayCommand(
                () => logic.EditSnack(SelectedFromShelf),
                () => selectedFromShelf != null
                );
            BuySnack = new RelayCommand(
                () => logic.BuySnack(SelectedFromShelf),
                () => selectedFromShelf != null
                );
            Messenger.Register<MainWindowViewModel, string, string>(this, "SnackInfo", (recipient, msg) =>
            {
                OnPropertyChanged("Income");
            });
                  
        }
    }
}
