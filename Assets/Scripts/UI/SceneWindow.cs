using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class SceneWindow : Window
    {
        private List<SceneButton> _sceneButtons;
        private int _activeScenesCount = 3;

        private void Awake()
        {
            _sceneButtons = GetComponentsInChildren<SceneButton>(true).ToList();

            for (int i = 0; i < _activeScenesCount; i++)
            {
                int randomIndex = Random.Range(0, _sceneButtons.Count);
                _sceneButtons[randomIndex].gameObject.SetActive(true);
                _sceneButtons.RemoveAt(randomIndex);
            }
        }
    }
}
