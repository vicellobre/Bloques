using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : StringEventInvoker {

    #region Métodos Privados

    private void Awake() {
        Initialize();
        unityEvents.Add(EventName.ActiveChildEvent, new ActiveChildEvent());
        EventManager.AddInvoker(EventName.ActiveChildEvent, this);
    }

    private void Start() {
        Time.timeScale = 0;

        unityEvents.Add(EventName.RestartGameEvent, new RestartGameEvent());
        EventManager.AddInvoker(EventName.RestartGameEvent, this);
        unityEvents[EventName.ActiveChildEvent].Invoke("Pause");

        AudioManager.Play(AudioClipName.GameOver);
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
			Text[] texts = transform.GetComponentsInChildren<Text>();

			foreach (Text text in texts) {
				text.text = TextName(text);
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
        text.name = text.name.Replace("Menu(Clone)", "");
		return ConfigurationUtils.Dict[text.name][ConfigurationUtils.Language.ToString()];
	}
    #endregion


    #region Metodos Públicos
    
    /// <summary>
    /// Establece las variables timeScale a 1, EnJuego en false,
    /// los puntos a 0 y las vidas a 3
    /// <para>
    /// Carga la escena del menú principal
    /// </para>
    /// </summary>
    public void QuitMenu() {
        unityEvents[EventName.RestartGameEvent].Invoke("");
        Time.timeScale = 1;
		ConfigurationUtils.EnJuego = false;
        MenuManager.GoToMenu(MenuName.Main);
    }

    /// <summary>
    /// Establece las variables timeScale a 1, EnJuego en false,
    /// los puntos a 0 y las vidas a 3
    /// <para>
    /// Vuelve a carga la escena actual
    /// </para>
    /// </summary>
    public void Restart() {
        unityEvents[EventName.RestartGameEvent].Invoke("");
        MenuManager.GoToMenu(MenuName.Restart);
    }
    #endregion
}