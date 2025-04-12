using PlayerControl;
using UI;
using UnityEngine;

namespace Dialogs
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private DialogWindow _dialogWindow;

        private void OnEnable()
        {
            _dialogWindow.DialogFinished += OnDialogFinished;
            _player.Interacting += StarDialog;
        }

        private void OnDisable()
        {
            _dialogWindow.DialogFinished -= OnDialogFinished;
            _player.Interacting -= StarDialog;
        }

        private void StarDialog(Dialog dialog)
        {
            _dialogWindow.StartDialog(dialog);
            _player.enabled = false;
        }

        private void OnDialogFinished()
        {
            _player.enabled = true;
        }
    }
}
