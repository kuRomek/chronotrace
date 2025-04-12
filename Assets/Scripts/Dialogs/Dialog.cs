using System.Collections.Generic;
using UnityEngine;

namespace Dialogs
{
    [CreateAssetMenu(fileName = "New Dialog", menuName = "Dialogs/Dialog")]
    public class Dialog : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private string[] _lines;
        [SerializeField] private Dialog _followingDialogOnYes;
        [SerializeField] private Dialog _followingDialogOnNo;
        [SerializeField] private bool _isTriggeringSceneLoading;
        [SerializeField] private bool _invokesQuestion;

        public string Title => _title;
        public IReadOnlyList<string> Lines => _lines;
        public Dialog FollowingDialogOnYes => _followingDialogOnYes;
        public Dialog FollowingDialogOnNo => _followingDialogOnNo;
        public bool IsTriggeringSceneLoading => _isTriggeringSceneLoading;
        public bool InvokesQuestion => _invokesQuestion;
    }
}