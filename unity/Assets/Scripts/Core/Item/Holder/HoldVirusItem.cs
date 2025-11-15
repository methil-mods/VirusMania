using System;
using System.Collections.Generic;
using Core.Threats;

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

        public List<ThreatImpact> GetThreatImpacts()
        {
            List<ThreatImpact> threatImpacts = new List<ThreatImpact>();
            foreach (MicrobeItem microbe in MicrobeInVirus)
            {
                if (microbe.threatParameters.Length == 0) continue;
                foreach (ThreatParameter parameter in microbe.threatParameters)
                {
                
                    var threat = threatImpacts.Find((impact =>
                    {
                        return impact.ThreatType == parameter.threatType;
                    }));
                    
                    if (threat == null)
                    {
                        threat = new ThreatImpact();
                        threat.ThreatType = parameter.threatType;
                        threatImpacts.Add(threat);
                    }

                    threat.ThreatLevel += parameter.threatImpact;
                }
            }
            return threatImpacts;
        }
    }

    public class ThreatImpact
    {
        public ThreatType ThreatType;
        public int ThreatLevel;
    }
}