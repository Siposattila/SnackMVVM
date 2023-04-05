using ArmyEditor.Models;
using System.Collections.Generic;

namespace ArmyEditor.Logic
{
    public interface IArmyLogic
    {
        double AVGPower { get; }
        double AVGSpeed { get; }
        int TotalCost { get; }

        void AddToArmy(Trooper trooper);
        void RemoveFromArmy(Trooper trooper);
        void EditTrooper(Trooper trooper);
        void SetupCollections(IList<Trooper> barracks, IList<Trooper> army);
        
    }
}