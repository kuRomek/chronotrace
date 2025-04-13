using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace Misc
{
    [CreateAssetMenu(fileName = "Scenes", menuName = "Scenes")]
    public class Scenes : ScriptableObject
    {
        [Scene, SerializeField] private string[] _scenes;
        [Scene, SerializeField] private string _finalScene;

        public int SceneNumber { get; private set; } = 0;
        public string FinalScene => _finalScene;
        private List<string> _scenesList;

        public IReadOnlyList<string> ScenesList => _scenesList;

        private void OnValidate()
        {
            _scenesList = new List<string>(_scenes);
        }

        public void RemoveScene(string scene)
        {
            _scenesList.Remove(scene);
            SceneNumber++;
        }
    }
}
