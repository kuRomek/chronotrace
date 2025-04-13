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
