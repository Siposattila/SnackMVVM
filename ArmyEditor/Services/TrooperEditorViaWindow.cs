using SnackMVVM.Models;
using SnackMVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMVVM.Services
{
    public class TrooperEditorViaWindow : ITrooperEditorService
    {
        public void Edit(Trooper trooper)
        {
            new TrooperEditor(trooper).ShowDialog();
        }
    }
}
