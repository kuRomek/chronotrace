using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Misc
{
    [CreateAssetMenu(fileName = "Scenes", menuName = "Scenes")]
    public class Scenes : ScriptableObject
    {
        [Scene, SerializeField] private string[] _scenes;
        [Scene, SerializeField] private string _finalScene;
        [Scene, SerializeField] private string _firstScene;
        [SerializeField] private int _maxSceneNumber = 4;

        public int SceneNumber { get; private set; } = 0;
        public string FinalScene => _finalScene;
        private List<string> _scenesList;

        public IReadOnlyList<string> ScenesList => _scenesList;

        private void Awake()
        {
            _scenesList = new List<string>(_scenes);
            SceneNumber = 0;
        }

        public void RemoveScene(string scene)
        {
            _scenesList.Remove(scene);

            IncrementSceneNumber();
        }

        public void IncrementSceneNumber(string _ = null)
        {
            SceneNumber = (SceneNumber + 1) % _maxSceneNumber;

            if (SceneNumber == 0)
                _scenesList = new List<string>(_scenes);
        }
    }
}
