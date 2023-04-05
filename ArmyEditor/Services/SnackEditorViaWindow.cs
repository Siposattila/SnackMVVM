using SnackMVVM.Models;

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