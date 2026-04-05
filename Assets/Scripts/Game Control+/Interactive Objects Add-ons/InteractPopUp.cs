using UnityEngine;

public class InteractPopup : MonoBehaviour
{
    [Header("Popup")]
    public GameObject popupUI;

    private void Start()
    {
        if (popupUI != null)
            popupUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (popupUI != null)
                popupUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (popupUI != null)
                popupUI.SetActive(false);
        }
    }
}
