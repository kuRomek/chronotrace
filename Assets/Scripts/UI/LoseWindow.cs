using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LoseWindow : Window
    {
        [SerializeField] private Button _restartButton;
        [Scene, SerializeField] private string _firstScene;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        }

        private void OnRestartButtonClick()
        {
            SceneManager.LoadScene(_firstScene);
        }
    }
}
