using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace Misc
{
    [CreateAssetMenu(fileName = "Scenes", menuName = "Scenes")]
    public class Scenes : ScriptableObject
    {
        [Scene, SerializeField] private string[] _scenes;

        private List<string> _scenesList;

        public IReadOnlyList<string> ScenesList => _scenesList;

        private void OnValidate()
        {
            _scenesList = new List<string>(_scenes);
        }

        public void RemoveScene(string scene)
        {
            _scenesList.Remove(scene);
        }
    }
}
