using SnackMVVM.Models;
using SnackMVVM.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMVVM.Logic
{
    public class SnackLogic : ISnackLogic
    {
        IList<Trooper> shelf;
        IMessenger messenger;
        ISnackEditorService editorService;

        public SnackLogic(IMessenger m, ISnackEditorService e )
        {
            this.messenger = m;
            this.editorService = e;            
        }

        public void SetupCollections(IList<Trooper> shelf)
        {
            this.shelf = shelf;
        }

        public void AddToSnackShelf(Trooper trooper)
        {
            this.shelf.Add(trooper);
            messenger.Send("Snack Added", "SnackInfo");
        }

        public void RemoveFromSnackShelf(Trooper trooper)
        {
            this.shelf.Remove(trooper);
            messenger.Send("Snack Removed", "SnackInfo");
        }

        public void EditSnack(Trooper trooper)
        {
            this.editorService.Edit(trooper);
        }

        public void BuySnack(Trooper trooper)
        {
            throw new NotImplementedException();
        }

        public int Income
        {
            get
            {
                return army.Count == 0 ? 0 : army.Sum(t => t.Cost);
            }
        }
    }
}
