using UnityEngine;

namespace Core.Interaction
{
    public class DebugInteractable : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Interacting with " + gameObject.name);
        }
    }
}