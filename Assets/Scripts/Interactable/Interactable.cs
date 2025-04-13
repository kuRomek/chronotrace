using Dialogs;
using UnityEngine;

namespace InteractableObjects
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] private Outline _outline;
        [SerializeField] private Dialog _dialog;

        public Dialog Interact()
        {
            RemoveHighlight();
            return _dialog;
        }

        public void Highlight()
        {
            _outline.enabled = true;
        }

        public void RemoveHighlight()
        {
            _outline.enabled = false;
        }
    }
}
