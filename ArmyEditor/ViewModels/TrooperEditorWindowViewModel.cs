using ArmyEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyEditor.ViewModels
{
    public class TrooperEditorWindowViewModel
    {
        public Trooper Selected { get; set; }
        public void Setup(Trooper trooper)
        {
            this.Selected = trooper;
        }
        public TrooperEditorWindowViewModel()
        {

        }
    }
}
