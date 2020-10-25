using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int id = 0;
    public bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
