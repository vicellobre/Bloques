using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : StringEventInvoker {

    #region Campos

    private float   _delay = 3f;
    #endregion


    #region Métodos

    private void Start() {
        EventManager.AddListener(EventName.ImLastEvent, ImLastEvent);

        unityEvents.Add(EventName.LevelCompletedEvent, new LevelCompletedEvent());
        EventManager.AddInvoker(EventName.LevelCompletedEvent, this);
        
        unityEvents.Add(EventName.GameOverEvent, new GameOverEvent());
        EventManager.AddInvoker(EventName.GameOverEvent, this);
    }

    /// <summary>
    /// Verifica si no tiene más hijos
    /// y en caso de no tener, carga el siguiente nivel
    /// con retraso de 3seg
    /// </summary>
    /// <param name="nothing">Ignorar parametro</param>
    private void ImLastEvent(string nothing) {
        if (transform.childCount == 0) {
            if (MenuManager.NextLevelExist()) {
                unityEvents[EventName.LevelCompletedEvent].Invoke("LevelCompleted");
            } else {
                unityEvents[EventName.LevelCompletedEvent].Invoke("GameCompleted");
                unityEvents[EventName.GameOverEvent].Invoke(ConfigurationUtils.Difficulty.ToString());
            }
            AudioManager.Play(AudioClipName.Completado);
            PlayerPrefsLevel();
            Invoke("LoadNextLevel", _delay);
        }
    }

    /// <summary>
    /// Carga el siguiente nivel
    /// <para>
    /// Si es el último nivel, carga el menú principal
    /// </summary>
    private void LoadNextLevel() {
        MenuManager.GoToMenu(MenuName.NextLevel);
    }

    /// <summary>
    /// Desbloquea el siguiente nivel
    /// </summary>
    private void PlayerPrefsLevel() {
        // Obtiene el nombre del campo
        string field = ConfigurationUtils.Difficulty.ToString() + "Levels";

        // Obtiene el nombre de la escena para saber en qué nivel se encuentra
        // Divide el nombre en palabras separadas por espacios
        string[] levelName = MenuManager.SceneName().Split(' ');
        // Obtiene el numero del nivel desde el nombre de la escena
        int playingLevel = int.Parse(levelName[1]);

        // Si el nivel en que se encuentra jugando es el mismo
        // al nivel máximo desbloqueado en el PlayerPrefs
        // se modifica a un nivel más
        if (playingLevel == PlayerPrefs.GetInt(field, 1)) {
            PlayerPrefs.SetInt(field, playingLevel + 1);
            PlayerPrefs.Save(); //OJO
        }
    }
    #endregion
}
