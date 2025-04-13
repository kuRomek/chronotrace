using Misc;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class SceneWindow : Window
    {
        [SerializeField] private Scenes _scenes;
        [SerializeField] private SceneButton[] _sceneButtons;

        private void Awake()
        {
            List<string> scenes = new List<string>(_scenes.ScenesList);

            if (_scenes.SceneNumber == 3)
            {
                foreach (var sceneButton in _sceneButtons)
                    sceneButton.gameObject.SetActive(false);

                _sceneButtons[0].gameObject.SetActive(true);
                _sceneButtons[0].Init(_scenes.FinalScene);
                _sceneButtons[0].SceneSelected += _scenes.IncrementSceneNumber;
            }
            else
            {
                for (int i = 0; i < _sceneButtons.Length; i++)
                {
                    int randomIndex = Random.Range(0, scenes.Count);
                    _sceneButtons[i].Init(scenes[randomIndex]);
                    _sceneButtons[i].SceneSelected += _scenes.RemoveScene;
                    scenes.RemoveAt(randomIndex);
                }
            }
        }
    }
}
