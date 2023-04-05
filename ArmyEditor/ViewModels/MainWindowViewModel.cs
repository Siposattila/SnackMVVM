using ArmyEditor.Logic;
using ArmyEditor.Models;
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

namespace ArmyEditor.ViewModels
{
    public class MainWindowViewModel: ObservableRecipient
    {
        IArmyLogic logic;
        public ObservableCollection<Trooper> Barracks { get; set; }
        public ObservableCollection<Trooper> Army { get; set; }
        private Trooper selectedFromBarracks;

        public Trooper SelectedFromBarracks
        {
            get { return selectedFromBarracks; }
            set { SetProperty(ref selectedFromBarracks, value);
                (AddToArmy as RelayCommand).NotifyCanExecuteChanged();
                (EditTrooper as RelayCommand).NotifyCanExecuteChanged();

            }
        }
        private Trooper selectedFromArmy;

        public Trooper SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set { SetProperty(ref selectedFromArmy, value);
                (RemoveFromArmy as RelayCommand).NotifyCanExecuteChanged();
                
            }
        }
        public ICommand AddToArmy { get; set; }
        public ICommand RemoveFromArmy { get; set; }
        public ICommand EditTrooper { get; set; }

        public int TotalCost { get { return logic.TotalCost; } }
        public double AVGPower { get { return logic.AVGPower; } }
        public double AVGSpeed { get { return logic.AVGSpeed; } }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
            :this(IsInDesignMode ? null : Ioc.Default.GetService<IArmyLogic>())
        {

        }
        public MainWindowViewModel(IArmyLogic logic)
        {
            this.logic = logic;
            
            Barracks = new ObservableCollection<Trooper>()
            {
                new Trooper(){Type="Scout",Speed=9,Power=3},
                new Trooper(){Type="Soldier",Speed=4,Power=8},
                new Trooper(){Type="Pyro",Speed=6,Power=7},
                new Trooper(){Type="Demoman",Speed=5,Power=8},
                new Trooper(){Type="Heavy",Speed=3,Power=10},
                new Trooper(){Type="Engineer",Speed=6,Power=2},
                new Trooper(){Type="Medic",Speed=7,Power=2},
                new Trooper(){Type="Sniper",Speed=6,Power=3},
                new Trooper(){Type="Spy",Speed=7,Power=1},

            };
            Army = new ObservableCollection<Trooper>()
            {
                Barracks[0].GetCopy(),
                Barracks[1].GetCopy(),
                Barracks[2].GetCopy(),
            };
            logic.SetupCollections(Barracks, Army);
            AddToArmy = new RelayCommand(
                () => logic.AddToArmy(SelectedFromBarracks.GetCopy()),
                () => selectedFromBarracks != null
                );
            RemoveFromArmy = new RelayCommand(
                () => logic.RemoveFromArmy(SelectedFromArmy),
                () => selectedFromArmy != null
                );
            EditTrooper = new RelayCommand(
                () => logic.EditTrooper(SelectedFromBarracks),
                () => selectedFromBarracks != null
                );
            Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recipient, msg) =>
            {
                OnPropertyChanged("TotalCost");
                OnPropertyChanged("AVGPower");
                OnPropertyChanged("AVGSpeed");
            });
                  
        }
    }
}
