using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMVVM.Models
{
    public class Snack : ObservableObject
    {
        private string name;
        private int amount;
        private int price;

        public string Name 
        { 
            get => name;
            set { SetProperty(ref name, value); } 
        }
        public int Amount
        {
            get => amount;
            set { SetProperty(ref amount, value); }
        }
        public int Price
        {
            get => price;
            set { SetProperty(ref price, value); }
        }
    }
}
