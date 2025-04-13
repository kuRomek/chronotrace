using Dialogs;
using PlayerControl;
using System.Collections;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tutorialText;
    [SerializeField] private Player _player;
    [SerializeField] private float _fadingSpeed = 1f;

    private Coroutine _textFadingCoroutine = null;
    private bool _movingTutorialPassed = false;
    private bool _interactingTutorialPassed = false;

    private void OnEnable()
    {
        _player.Interacting += PassInteractingTutorial;
        _player.Movement.Moved += PassMovingTuturial;
    }

    private void OnDisable()
    {
        _player.Interacting -= PassInteractingTutorial;
        _player.Movement.Moved -= PassMovingTuturial;
    }

    private void PassMovingTuturial()
    {
        _movingTutorialPassed = true;

        if (_interactingTutorialPassed && _textFadingCoroutine == null)
            StartCoroutine(StartTextFading());
    }

    private void PassInteractingTutorial(Dialog _)
    {
        _interactingTutorialPassed = true;

        if (_movingTutorialPassed && _textFadingCoroutine == null)
            StartCoroutine(StartTextFading());
    }

    private IEnumerator StartTextFading()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        while (_tutorialText.color.a > 0)
        {
            Color color = _tutorialText.color;
            color.a -= Time.fixedDeltaTime * _fadingSpeed;
            _tutorialText.color = color;
            yield return waitForFixedUpdate;
        }

        gameObject.SetActive(false);
    }
}
