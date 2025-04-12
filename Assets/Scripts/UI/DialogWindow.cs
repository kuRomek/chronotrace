using Dialogs;
using Input;
using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DialogWindow : Window
    {
        [SerializeField] private PlayerInputController _input;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _line;

        private Dialog _currentDialog = null;
        private int _currentLineIndex = 0;

        public event Action DialogFinished;
        public event Action AskingWindowOpening;

        public bool IsDialogActive => gameObject.activeSelf;

        private void OnEnable()
        {
            _input.DialogSkiping += SkipDialog;
        }

        private void OnDisable()
        {
            _input.DialogSkiping -= SkipDialog;
        }

        public void StartDialog(Dialog dialog)
        {
            _currentDialog = dialog;
            _title.text = dialog.Title;
            _line.text = dialog.Lines[_currentLineIndex++];

            _currentDialog = dialog;

            Open();
        }

        private void SkipDialog()
        {
            if (_currentLineIndex < _currentDialog.Lines.Count)
                _line.text = _currentDialog.Lines[_currentLineIndex++];
            else
                FinishDialog();
        }

        private void FinishDialog()
        {
            if (_currentDialog.InvokesQuestion == true)
                AskingWindowOpening?.Invoke();

            _currentDialog = null;
            _currentLineIndex = 0;

            DialogFinished?.Invoke();
        }
    }
}
