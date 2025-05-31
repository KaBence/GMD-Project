using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelectionFeedback : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Image background;

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Button selected: " + gameObject.name);
        background.CrossFadeAlpha(0.8f, 0.2f, false); // fade to visible
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Button deselected: " + gameObject.name);
        background.CrossFadeAlpha(0f, 0.2f, false); // fade to invisible
    }

    void Start()
    {
        background.canvasRenderer.SetAlpha(0f); // start hidden
    }
}