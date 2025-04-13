using System;
using UnityEngine;

namespace Misc
{
    [Serializable]
    public class Suspect
    {
        [SerializeField] private string _name;
        [SerializeField] private bool _isMurderer;

        public string Name => _name;
        public bool IsMurderer => _isMurderer;
    }
}
