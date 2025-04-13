using PlayerControl;
using System;
using UI;
using UnityEngine;

namespace Dialogs
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private DialogWindow _dialogWindow;
        [SerializeField] private SceneWindow _sceneWindow;
        [SerializeField] private TwoAnswersWindow _askingWindow;
        [SerializeField] private MurdererSelectingWindow _murdererSelectingWindow;

        private Dialog _currentDialog = null;

        private void OnEnable()
        {
            _dialogWindow.DialogFinished += OnDialogFinished;
            _dialogWindow.AskingWindowOpening += _askingWindow.Open;
            _player.Interacting += StartDialog;
            _askingWindow.YesButtonClicked += OnYesButtonClicked;
            _askingWindow.NoButtonClicked += OnNoButtonClicked;
        }

        private void OnDisable()
        {
            _dialogWindow.DialogFinished -= OnDialogFinished;
            _dialogWindow.AskingWindowOpening -= _askingWindow.Open;
            _player.Interacting -= StartDialog;
            _askingWindow.YesButtonClicked -= OnYesButtonClicked;
            _askingWindow.NoButtonClicked -= OnNoButtonClicked;
        }

        private void StartDialog(Dialog dialog)
        {
            _dialogWindow.StartDialog(dialog);
            _player.enabled = false;
            _currentDialog = dialog;
        }

        private void OnDialogFinished()
        {
            if (_currentDialog.IsTriggeringSceneLoading)
                _sceneWindow.Open();

            if (_currentDialog.InvokesMurderesSelection)
                _murdererSelectingWindow.Open();

            if (_currentDialog.FollowingDialogOnYes == null && _currentDialog.FollowingDialogOnNo == null)
            {
                _dialogWindow.Close();
                _currentDialog = null;
                _player.enabled = true;
            }
        }

        private void OnYesButtonClicked()
        {
            _askingWindow.Close();
            _dialogWindow.StartDialog(_currentDialog.FollowingDialogOnYes);
            _currentDialog = _currentDialog.FollowingDialogOnYes;
        }

        private void OnNoButtonClicked()
        {
            _askingWindow.Close();
            _dialogWindow.StartDialog(_currentDialog.FollowingDialogOnNo);
            _currentDialog = _currentDialog.FollowingDialogOnNo;
        }
    }
}
