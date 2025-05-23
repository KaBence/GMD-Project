using System.Collections;
using TMPro;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private GameObject[] controlObjects;
    [SerializeField] private TextMeshProUGUI countdownText;



    public float disableDuration = 3f;

    void Start()
    {
        StartCoroutine(DisableTemporarily());
        StartCoroutine(CountdownRoutine());

    }

    IEnumerator DisableTemporarily()
    {
        // Disable all MonoBehaviour scripts on target objects
        foreach (var obj in controlObjects)
        {
            foreach (var script in obj.GetComponents<MonoBehaviour>())
            {
                script.enabled = false;
            }
        }

        yield return new WaitForSeconds(disableDuration);

        // Re-enable them after delay
        foreach (var obj in controlObjects)
        {
            foreach (var script in obj.GetComponents<MonoBehaviour>())
            {
                script.enabled = true;
            }
        }
    }

    IEnumerator CountdownRoutine()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return StartCoroutine(FadeText());
        }

        countdownText.gameObject.SetActive(false); // hide after countdown
    }

    IEnumerator FadeText()
    {
        float duration = 1f;
        float halfDuration = duration / 2f;

        // Fade in
        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            float alpha = t / halfDuration;
            countdownText.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        // Stay fully visible briefly
        countdownText.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);

        // Fade out
        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            float alpha = 1 - (t / halfDuration);
            countdownText.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        countdownText.color = new Color(1, 1, 1, 0); // ensure fully invisible
    }
}
