using UnityEngine;
using UnityEngine.EventSystems;

public class RotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private int id = 0;
    private bool isPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (!isPressed)
            return;

        if (id == 0)
            PlayerController.instance.RotateHorary();
        else if (id == 1)
            PlayerController.instance.RotateAntiHorary();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
