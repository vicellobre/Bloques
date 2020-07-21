using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Suelo : StringEventInvoker {

    #region Métodos
    
    private void Start() {
        unityEvents.Add(EventName.PerderVidaEvent, new PerderVidaEvent());
        EventManager.AddInvoker(EventName.PerderVidaEvent, this);
    }

    private void OnTriggerEnter(Collider otro) {
        if (otro.gameObject.CompareTag("Pelota")) {
            unityEvents[EventName.PerderVidaEvent].Invoke("");
            AudioManager.Play(AudioClipName.Error);
        }
    }
    #endregion
}