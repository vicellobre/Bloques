using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Pelota : StringEventInvoker {
    
    #region Campos

    private Rigidbody           _rigidbody;
    private Vector3             _posicionInicial;
    private Transform           _barra;
    private InteractiveElement  _fullscreen;
    #endregion


    #region Métodos

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _barra = transform.parent;
        _fullscreen = GameObject.FindGameObjectWithTag("Fullscreen").GetComponent<InteractiveElement>();
    }

    private void Start() {
        _posicionInicial = transform.position;
        EventManager.AddListener(EventName.PerderVidaEvent, Reiniciar);
        EventManager.AddListener(EventName.LevelCompletedEvent, DetenerMovimiento);
    }

    private void Update() {

        // Detecta cuando empieza el juego
        if ((Input.GetKeyDown(KeyCode.Space) || _fullscreen.pressed) && !ConfigurationUtils.EnJuego) {
            AudioManager.Play(AudioClipName.Pelota);
            EmpiezaElJuego();
        }
    }

    private void OnCollisionEnter(Collision other) {
        AudioManager.Play(AudioClipName.Pelota);
    }

    /// <summary>
    /// La pelota deja de ser hijo de la Barra
    /// <para>
    /// Establece el RigidBody a Dinamico
    /// </para><para>
    /// Añade impulso a la pelota
    /// </para>
    /// </summary>
    private void EmpiezaElJuego() {
        ConfigurationUtils.EnJuego = true;
        transform.SetParent(null); // Deja de ser hijo de la Barra
        _rigidbody.isKinematic = false; // Convierte el RigidBody en Dinamico
        _rigidbody.AddForce(new Vector3(ConfigurationUtils.VelocidadPelota, // Añade impulso a la pelota
                                        ConfigurationUtils.VelocidadPelota,
                                        0));
    }

    /// <summary>
    /// Establece la posicion a la posicion inicial
    /// <para>Regresa a ser hijo de la Barra
    /// </para><para>
    /// Ademas, detiene el movimiento
    /// </para>
    /// </summary>
    private void Reiniciar(string nada) {
        ConfigurationUtils.EnJuego = false;
        transform.SetParent(_barra);
        transform.position = _posicionInicial;
        DetenerMovimiento("");
    }

    /// <summary>
    /// Establece la velocidad a cero.
    /// <para>
    /// Convierte el RigidBody a Kinematic
    /// </para>
    /// </summary>
    private void DetenerMovimiento(string nothing) {
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector3.zero;
    }
    #endregion
}