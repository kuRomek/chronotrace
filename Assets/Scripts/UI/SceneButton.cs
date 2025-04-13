using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class SceneButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _sceneName;

        public event Action<string> SceneSelected;

        private void OnEnable()
        {
            _button.onClick.AddListener(LoadScene);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(LoadScene);
        }

        public void Init(string sceneName)
        {
            _sceneName.text = sceneName;
        }

        private void LoadScene()
        {
            SceneSelected?.Invoke(_sceneName.text);
            SceneManager.LoadScene(_sceneName.text);
        }
    }
}
