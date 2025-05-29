using UnityEngine;
using UnityEngine.EventSystems;

public class SelectFirstOnEnable : MonoBehaviour
{
    [SerializeField] private GameObject firstSelected;

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}