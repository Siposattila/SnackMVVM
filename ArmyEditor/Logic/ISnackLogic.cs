using SnackMVVM.Models;
using System.Collections.Generic;

namespace SnackMVVM.Logic
{
    public interface ISnackLogic
    {
        int Income { get; }

        void AddToSnackShelf(Snack snack);
        void RemoveFromSnackShelf(Snack snack);
        void EditSnack(Snack snack);
        void BuySnack(Snack snack);
        void SetupCollections(IList<Snack> shelf);
    }
}