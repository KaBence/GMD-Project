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
        Time.timeScale = 0f; // Pause the game initially
        StartCoroutine(LevelStartSequence());
    }

    IEnumerator LevelStartSequence()
    {
        yield return StartCoroutine(DisableTemporarily());
        yield return StartCoroutine(CountdownRoutine());
        Time.timeScale = 1f; // Resume the game after everything is done
    }

    IEnumerator DisableTemporarily()
    {
        foreach (var obj in controlObjects)
        {
            foreach (var script in obj.GetComponents<MonoBehaviour>())
            {
                script.enabled = false;
            }
        }

        yield return new WaitForSecondsRealtime(disableDuration);

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

        countdownText.gameObject.SetActive(false);
    }

    IEnumerator FadeText()
    {
        float duration = 1f;
        float halfDuration = duration / 2f;

        // Fade in
        for (float t = 0; t < halfDuration; t += Time.unscaledDeltaTime)
        {
            float alpha = t / halfDuration;
            countdownText.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        countdownText.color = new Color(1, 1, 1, 1);
        yield return new WaitForSecondsRealtime(0.2f);

        // Fade out
        for (float t = 0; t < halfDuration; t += Time.unscaledDeltaTime)
        {
            float alpha = 1 - (t / halfDuration);
            countdownText.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        countdownText.color = new Color(1, 1, 1, 0);
    }
}
