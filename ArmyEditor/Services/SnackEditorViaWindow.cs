using SnackMVVM.Models;
using SnackMVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMVVM.Services
{
    public class SnackEditorViaWindow : ISnackEditorService
    {
        public void Edit(Snack snack)
        {
            new SnackEditor(snack).ShowDialog();
        }
    }
}
