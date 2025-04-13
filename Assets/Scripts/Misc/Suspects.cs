using UnityEngine;

namespace Misc
{
    [CreateAssetMenu(fileName = "Murderers", menuName = "Murderers")]
    public class Suspects : ScriptableObject
    {
        [SerializeField] private Suspect[] _suspects;

        public Suspect[] SuspectsList => _suspects;
    }
}
