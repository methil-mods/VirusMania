using System;
using System.Collections.Generic;
using Core.Input;
using Core.PostProcess;
using UnityEngine;
using UnityEngine.UI;
using Framework.Controller;

namespace Core.Computer
{
    public class ComputerInterface : InterfaceController<ComputerInterface>
    {
        public void Start()
        {
            base.Start();

            this.OnPanelOpen += () => { 
                PostProcessController.Instance.OnShowPanelPostProcess();
                InputDatabase.Instance.moveAction.action.Disable();
            };

            this.OnPanelClose += () => { 
                PostProcessController.Instance.OnHidePanelPostProcess();
                InputDatabase.Instance.moveAction.action.Enable();
            };
        }
    }
}