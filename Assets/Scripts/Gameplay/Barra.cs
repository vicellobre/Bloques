using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : StringEventInvoker {
    
    #region  Fields

    private bool                _moverBarra = true;
    private float               _direction;
    private float               _posicionX;
    private Vector3             _posicionInicial;
    private InteractiveElement  _buttonLeft,_buttonRight;
    #endregion


    #region Private Methods

    private void Awake() {
        _buttonLeft = GameObject.FindGameObjectWithTag("ButtonLeft").GetComponent<InteractiveElement>();
        _buttonRight = GameObject.FindGameObjectWithTag("ButtonRight").GetComponent<InteractiveElement>();
    }


    
    /// <summary>
    /// Es llamado antes del primer frame del Update
    /// <para>
    /// Inicializa todas las variables necesarias
    /// </para>
    /// </summary>
    private void Start() {
        _posicionInicial = transform.position;

        EventManager.AddListener(EventName.PerderVidaEvent, Reiniciar);
        EventManager.AddListener(EventName.LevelCompletedEvent, DetenerMovimiento);
    }

    // Update es llamado una vez por frame
    private void Update() {
        if (_moverBarra) {
            MoverBara();
        }
    }

    /// <summary>
    /// <para>
    /// Establece la posicion del objeto,
    /// a la posicion inicial.
    /// </para>
    /// </summary>
    private void Reiniciar(string nada) {
        transform.position = _posicionInicial;
    }

    /// <summary>
    /// Captura la entrada del eje Horizontal
    /// <para>
    /// Calcula la velocidad de movimiento
    /// </para><para>
    /// Limita el movimiento del eje X al rango (-8, 8)
    /// </para>
    /// </summary>
    private void MoverBara() {
        _direction = _buttonRight.pressed ? 1 : _buttonLeft.pressed ? -1 : Input.GetAxisRaw("Horizontal");
        _posicionX = transform.position.x + _direction * ConfigurationUtils.VelocidadBarra * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(_posicionX, -8f, 8f),//const
                                        _posicionInicial.y,
                                        _posicionInicial.z);  
    }

    /// <summary>
    /// Modifica la bandera para
    /// detener la barra
    /// </summary>
    /// <param name="nothing"></param>
    private void DetenerMovimiento(string nothing) {
        _moverBarra = false;
    }
    #endregion
}