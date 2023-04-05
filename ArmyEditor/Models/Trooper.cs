using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMVVM.Models
{
    public class Trooper : ObservableObject
    {
        private string type;
        private int power;
        private int speed;

        public string Type 
        { 
            get => type;
            set { SetProperty(ref type, value); } 
        }
        public int Power
        {
            get => power;
            set { SetProperty(ref power, value); }
        }
        public int Speed 
        { 
            get => speed;
            set { SetProperty(ref speed, value); } 
        }
        public int Cost
        {
            get { return power * speed; }
        }
        public Trooper GetCopy()
        {
            return new Trooper()
            {
                Type = this.Type,
                Power = this.Power,
                Speed = this.Speed
            };
        }
    }
}
