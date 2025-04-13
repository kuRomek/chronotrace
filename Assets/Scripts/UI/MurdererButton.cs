using Misc;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class MurdererButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private WinWindow _winWindow;

        private Suspect _suspect;

        public Action<Suspect> MurdererSelected;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        public void Init(Suspect suspect)
        {
            _suspect = suspect;
            _button.GetComponentInChildren<TextMeshProUGUI>().text = suspect.Name;
        }

        private void OnButtonClick()
        {
            MurdererSelected?.Invoke(_suspect);
        }
    }
}
