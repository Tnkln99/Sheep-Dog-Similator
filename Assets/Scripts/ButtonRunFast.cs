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
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isFast = false;
    }
}

