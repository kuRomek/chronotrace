using System.Collections.Generic;
using UnityEngine;

namespace Dialogs
{
    [CreateAssetMenu(fileName = "New Dialog", menuName = "Dialogs/Dialog")]
    public class Dialog : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private string[] _lines;

        public string Title => _title;
        public IReadOnlyList<string> Lines => _lines;
    }
}