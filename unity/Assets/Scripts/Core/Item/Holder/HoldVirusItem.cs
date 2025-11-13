using System;
using System.Collections.Generic;

namespace Core.Item.Holder
{
    public class HoldVirusItem : HoldItem
    {
        public List<MicrobeItem> MicrobeInVirus = new List<MicrobeItem>();
        
        public HoldVirusItem(Item item) : base(item)
        {
            
        }

        public void AddMicrobe(MicrobeItem microbe)
        {
            MicrobeInVirus.Add(microbe);
        }
    }
}