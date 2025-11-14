using Framework.Controller;
using UnityEngine;

namespace Core.MainMenu
{
    public class MainMenuController : BaseController<MainMenuController>
    {
        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}