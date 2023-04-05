using ArmyEditor.Models;
using ArmyEditor.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyEditor.Logic
{
    public class ArmyLogic : IArmyLogic
    {
        IList<Trooper> barracks;
        IList<Trooper> army;
        IMessenger messenger;
        ITrooperEditorService editorService;

        public ArmyLogic(IMessenger m, ITrooperEditorService e )
        {
            this.messenger = m;
            this.editorService = e;
            
        }
        public void SetupCollections(IList<Trooper> barracks, IList<Trooper> army)
        {
            this.barracks = barracks;
            this.army = army;
        }

        public void AddToArmy(Trooper trooper)
        {
            army.Add(trooper.GetCopy());
            messenger.Send("Trooper Added", "TrooperInfo");
        }
        public void RemoveFromArmy(Trooper trooper)
        {
            army.Remove(trooper);
            messenger.Send("Trooper Removed", "TrooperInfo");
        }
        public void EditTrooper( Trooper trooper)
        {
            editorService.Edit(trooper);
        }
        public int TotalCost
        {
            get
            {
                return army.Count == 0 ? 0 : army.Sum(t => t.Cost);
            }
        }
        public double AVGPower
        {
            get
            {
                return army.Count == 0 ? 0 : Math.Round(army.Average(t => t.Power),2);
            }
        }
        public double AVGSpeed
        {
            get
            {
                return army.Count == 0 ? 0 : Math.Round(army.Average(t => t.Speed),2);
            }
        }
    }
}
