using Framework.Controller;
using UnityEngine;

namespace Core.Brief
{
    public class BriefController : BaseController<BriefController>
    {
        [SerializeField]
        BriefInterface briefInterface;
        
        [ContextMenu("New Brief")]
        public void NewBrief()
        {
            Brief newBrief = BriefDatabase.Instance.GetRandom();
            briefInterface.SetupNewBriefShow(newBrief);
        }
    }
}