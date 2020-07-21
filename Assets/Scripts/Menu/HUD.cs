using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HUD : StringEventInvoker {

    #region Campos

    static private int      _VIDAS_INT = 3;
    static private int      _PUNTOS_INT = 0;
    private Text            _puntos;
    private Text            _vidas;
    private GameObject      _buttonPause;
    private Dictionary<string, GameObject> _children = new Dictionary<string, GameObject>();
    #endregion

    #region  Métodos Privados

    private void Awake() {
        Initialize();
        _puntos = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();
        _vidas = GameObject.FindGameObjectWithTag("Vidas").GetComponent<Text>();
        _buttonPause = GameObject.FindGameObjectWithTag("Boton");
        Children();
    }

    /// <summary>
    /// Es llamado antes del primer frame del Update
    /// <para>
    /// Inicializa todas las variables necesarias,
    /// Eventos y métodos oyentes
    /// </para>
    /// </summary>
    private void Start() {
        _vidas.text += ": " + _VIDAS_INT.ToString();
        _puntos.text += ": " + _PUNTOS_INT.ToString();

        unityEvents.Add(EventName.GameOverEvent, new GameOverEvent());
        EventManager.AddInvoker(EventName.GameOverEvent, this);

        EventManager.AddListener(EventName.GanarPuntosEvent, GanarPuntosEvent);
        EventManager.AddListener(EventName.PerderVidaEvent, PerderVidaEvent);
        EventManager.AddListener(EventName.RestartGameEvent, RestartGameEvent);
        EventManager.AddListener(EventName.ActiveChildEvent, ActiveChildEvent);
        EventManager.AddListener(EventName.LevelCompletedEvent, LevelCompletedEvent);
        EventManager.AddListener(EventName.GameOverEvent, SetPlayerPrefs);
    }

    /// <summary>
    /// Traduce el text de todos los
    /// objetos Text al idioma actual
    /// <para>
    /// Solo si el idioma actual es
    /// distinto al predeterminado
    /// </para>
    /// </summary>
    private void Initialize() {
		if (ConfigurationUtils.Language != ConfigurationUtils.Language_DEFAULT) {
            foreach (Transform child in transform) {
                if (child.TryGetComponent(out Text txt)) {
                    txt.text = txt.text = TextName(txt);
                }
            }
		}
	}

    /// <summary>
    /// Obtiene el nombre del objeto Texto
    /// en el diccionario del idioma actual
    /// para traducirlo
    /// </summary>
    /// <param name="text">Object Text</param>
    /// <returns>Text.name</returns>
    private string TextName(Text text) {
        text.name.Replace("(Clone)", "");
		return ConfigurationUtils.Dict[text.name][ConfigurationUtils.Language.ToString()];
	}

    /// <summary>
    /// Actualiza los puntos de la partida
    /// <para>
    /// Método oyente que se activa cuando un bloque es destruido
    /// </para>
    /// </summary>
    /// <param name="nothing">Ignorar</param>
    private void GanarPuntosEvent(string nothing) {
        _PUNTOS_INT += ConfigurationUtils.Puntos;
        _puntos.text = TextName(_puntos) + ": " + _PUNTOS_INT.ToString();
    }

    /// <summary>
    /// Actualiza las vidas de la partida.
    /// <para>
    /// Método oyente que se activa la pelota toca el suelo
    /// </para>
    /// </summary>
    /// <param name="nothing">Ignorar</param>
    private void PerderVidaEvent(string nothing) {
        _VIDAS_INT = Mathf.Max(0, _VIDAS_INT - 1);
        _vidas.text = TextName(_vidas) + ": " + _VIDAS_INT.ToString();
        if (_VIDAS_INT == 0) {
            GameOver();
        }
    }

    /// <summary>
    /// Activa/Desactiva al hijo
    /// </summary>
    /// <param name="nameChild">Nombre del hijo</param>
    private void ActiveChildEvent(string nameChild) {
        if (_children[nameChild].activeSelf) {
            _children[nameChild].SetActive(false);
        } else {
            _children[nameChild].SetActive(true);
        }
    }

    /// <summary>
    /// Reestablece los puntos y vidas
    /// <para>
    /// Método oyente cuando se reinicia el juego
    /// desde el menú GameOver o Pausa
    /// </para>
    /// </summary>
    /// <param name="nothing">Ignorar</param>
    private void RestartGameEvent(string nothing) {
        RestartGame();
    }
    
    /// <summary>
    /// Activa el mensaje pasado por mensaje
    /// </summary>
    /// <param name="nameMessage">Nombre del mensaje</param>
    private void LevelCompletedEvent(string message) {
        ActiveChildEvent(message);
        ActiveChildEvent("Pause");
        _VIDAS_INT++;
    }

    /// <summary>
    /// Carga el objeto GameOver
    /// <para>
    /// Invoca el evento GameOver para actualizar
    /// el puntaje del PlayerPrefs
    /// </para><para>
    /// Reestablece los puntos y vidas
    /// </summary>
    private void GameOver() {
        MenuManager.GoToMenu(MenuName.GameOver);
        SetPlayerPrefs(ConfigurationUtils.Difficulty.ToString());
        RestartGame();
    }

    /// <summary>
    /// Estable los puntos a 0 y las vidas en 3
    /// </summary>
    private void RestartGame() {
        _PUNTOS_INT = 0;
        _VIDAS_INT = 3;
    }

    /// <summary>
    /// Carga el diccionario Children
    /// con los hijos del HUD
    /// </summary>
    private void Children() {
        foreach (Transform child in transform) {
            _children.Add(child.name, child.gameObject);
        }
    }

    /// <summary>
    /// Obtiene la variable puntos de la dificultad
    /// establecida del PlayerPrefs y la modifica
    /// si estos son menores a los puntos conseguidos.
    /// </summary>
    /// <param name="difficulty">Dificultad establecida en el juego</param>
    private void SetPlayerPrefs(string difficulty){
        
        // Obtiene el campo del PlayerPrefs
        string field = difficulty + "HighScore";
        
        // Obtiene los puntos del campo del PlayerPrefs
        int highScore = PlayerPrefs.GetInt(field, 0);

        // Modifica el campo si el puntaje actual es mayor al guardado
        if (_PUNTOS_INT > highScore) {
            PlayerPrefs.SetInt(field, _PUNTOS_INT);
            PlayerPrefs.Save(); //OJO
        }

        RestartGame();
    }
    #endregion

    #region Métodos Públicos

    /// <summary>
    /// Establece el juego en pausa
    /// <para>
    /// Desactiva el botón Pausa
    /// </para>
    /// </summary>
    public void Pause() {
        ActiveChildEvent("Pause");
        MenuManager.GoToMenu(MenuName.Pause);
    }
    #endregion
}