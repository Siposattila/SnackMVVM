using SnackMVVM.Models;
using System.Collections.Generic;

namespace SnackMVVM.Logic
{
    public interface ISnackLogic
    {
        int Income { get; }

        void AddToSnackShelf(Trooper trooper);
        void RemoveFromSnackShelf(Trooper trooper);
        void EditSnack(Trooper trooper);
        void BuySnack(Trooper trooper);
        void SetupCollections(IList<Trooper> shelf);
    }
}