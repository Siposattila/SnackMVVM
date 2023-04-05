using SnackMVVM.Models;
using SnackMVVM.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SnackMVVM.Logic
{
    public class SnackLogic : ISnackLogic
    {
        private int income;
        IList<Snack> shelf;
        IMessenger messenger;
        ISnackEditorService editorService;

        public int Income { get { return this.income; } }

        public SnackLogic(IMessenger m, ISnackEditorService e )
        {
            this.messenger = m;
            this.editorService = e;            
        }

        public void SetupCollections(IList<Snack> shelf)
        {
            this.shelf = shelf;
        }

        public void AddToSnackShelf(Snack snack)
        {
            this.shelf.Add(snack);
            this.editorService.Edit(snack);
            messenger.Send("Snack Added", "SnackInfo");
        }

        public void RemoveFromSnackShelf(Snack snack)
        {
            this.shelf.Remove(snack);
            messenger.Send("Snack Removed", "SnackInfo");
        }

        public void EditSnack(Snack snack)
        {
            this.editorService.Edit(snack);
        }

        public void BuySnack(Snack snack)
        {
            int index = this.shelf.IndexOf(snack);
            this.shelf[index].Amount--;
            this.income += snack.Price;
            messenger.Send("Snack Bought", "SnackInfo");
        }
    }
}
