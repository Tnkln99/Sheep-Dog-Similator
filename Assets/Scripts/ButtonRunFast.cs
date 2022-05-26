using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRunFast : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool isFast;

    private void Start()
    {
        isFast = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isFast = true;
        Debug.Log(isFast);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isFast = false;
        Debug.Log(isFast);
    }
}

