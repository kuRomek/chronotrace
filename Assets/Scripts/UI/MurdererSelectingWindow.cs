using Misc;
using UnityEngine;

namespace UI
{
    public class MurdererSelectingWindow : AskingWindow
    {
        [SerializeField] private MurdererButton[] _murderersButtons;
        [SerializeField] private WinWindow _winWindow;
        [SerializeField] private LoseWindow _loseWindow;
        [SerializeField] private Suspects _suspects;

        private void Awake()
        {
            for (int i = 0; i < _suspects.SuspectsList.Length; i++)
                _murderersButtons[i].Init(_suspects.SuspectsList[i]);
        }

        private void OnEnable()
        {
            for (int i = 0; i < _murderersButtons.Length; i++)
                _murderersButtons[i].MurdererSelected += OnMurdererButtonClick;
        }

        private void OnDisable()
        {
            for (int i = 0; i < _murderersButtons.Length; i++)
                _murderersButtons[i].MurdererSelected -= OnMurdererButtonClick;
        }

        private void OnMurdererButtonClick(Suspect suspect)
        {
            Close();

            if (suspect.IsMurderer)
            {
                _winWindow.Open();
            }
            else
            {
                _loseWindow.Open();
            }
        }
    }
}
