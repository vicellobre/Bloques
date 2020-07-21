using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : StringEventInvoker {

    #region  Campos
    
    private GameObject  _particulas;
    #endregion


    #region Métodos

    /// <summary>
    /// Es llamado antes del primer frame del Update
    /// <para>
    /// Inicializa todas las variables necesarias
    /// </para>
    /// </summary>
    void Start() {
        _particulas = Resources.Load<GameObject>("Prefabs/Particle System");

        unityEvents.Add(EventName.GanarPuntosEvent, new GanarPuntosEvent());
        EventManager.AddInvoker(EventName.GanarPuntosEvent, this);

        unityEvents.Add(EventName.ImLastEvent, new ImLastEvent());
        EventManager.AddInvoker(EventName.ImLastEvent, this);
    }

    /// <summary>
    /// Es llamado cuando este Collider/RigidBody ha comenzado
    /// a tocar otro Rigidbody/Collider.
    /// </summary>
    /// <param name="otro">Los datos de la colisión asociados con esta colisión.</param>
    void OnCollisionEnter(Collision otro) {
        // Detecta si colisonó con Pelota
        if (otro.gameObject.CompareTag("Pelota")) {
            AudioManager.Play(AudioClipName.Point);
            
            // Suma Puntos
            unityEvents[EventName.GanarPuntosEvent].Invoke("");
            
            // Crea las particulas
            _particulas = Instantiate(_particulas, transform.position, Quaternion.identity);

            // Destruye este objeto y abandona al padre
            Destroy(gameObject);
            transform.SetParent(null);

            // Detecta si soy ultimo
            unityEvents[EventName.ImLastEvent].Invoke("");
        }
    }
    #endregion
}