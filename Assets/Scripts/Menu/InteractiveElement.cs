using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InteractiveElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    #region Campos

    public bool pressed;
    #endregion


    #region Métodos Públicos

    public void OnPointerDown(PointerEventData eventData) {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        pressed = false;
    }
    #endregion
}
