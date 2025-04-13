using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TwoAnswersWindow : AskingWindow
    {
        [SerializeField] private Button _yesButton;
        [SerializeField] private Button _noButton;

        public event Action YesButtonClicked;
        public event Action NoButtonClicked;

        private void OnEnable()
        {
            _yesButton.onClick.AddListener(OnYesButtonClick);
            _noButton.onClick.AddListener(OnNoButtonClick);
        }

        private void OnDisable()
        {
            _yesButton.onClick.RemoveListener(OnYesButtonClick);
            _noButton.onClick.RemoveListener(OnNoButtonClick);
        }

        private void OnYesButtonClick()
        {
            YesButtonClicked?.Invoke();
            Close();
        }

        private void OnNoButtonClick()
        {
            NoButtonClicked?.Invoke();
            Close();
        }
    }
}
