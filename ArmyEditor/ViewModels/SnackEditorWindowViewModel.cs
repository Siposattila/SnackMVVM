using SnackMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMVVM.ViewModels
{
    public class SnackEditorWindowViewModel
    {
        public Snack Selected { get; set; }
        public void Setup(Snack snack)
        {
            this.Selected = snack;
        }
    }
}
