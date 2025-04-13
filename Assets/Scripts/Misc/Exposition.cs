using System.Collections;
using TMPro;
using UnityEngine;

namespace Misc
{
    public class Exposition : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tutorialText;
        [SerializeField] private float _fadingSpeed = 0.2f;

        private void Start()
        {
            StartCoroutine(StartTextFading());
        }

        private IEnumerator StartTextFading()
        {
            yield return new WaitForSeconds(15f);

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
}
