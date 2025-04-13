using Dialogs;
using UnityEngine;

namespace InteractableObjects
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] private Outline _outline;
        [SerializeField] private Dialog _dialog;

        private int _width = 5;

        private void Awake()
        {
            _outline.OutlineColor = Color.blue;
            _outline.OutlineWidth = _width;
        }

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
