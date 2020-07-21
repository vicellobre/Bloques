using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : Menu {

    #region Métodos Privados

    /// <summary>
    /// Obtiene el puntaje del PlayerPrefs
    /// y lo escribe en el texto
    /// de la dificultad correspondiente.
    /// </summary>
    /// <param name="highScore">Puntos de la dificultad</param>
    private void GetPoints(GameObject go) {
        string field = go.name + "HighScore";
        int points = PlayerPrefs.GetInt(field, 0);
        go.GetComponent<Text>().text += ": " + points.ToString();
    }
    #endregion


    #region Métodos Protegidos

    /// <summary>
    /// Inicializa los textos de dificultad
    /// con los puntajes del PlayerPrefs
    /// correspondientes
    /// </summary>
    protected override void Initialize() {
        base.Initialize();
        
        GameObject[] highScores = GameObject.FindGameObjectsWithTag("Score");
        foreach (GameObject text in highScores) {
            GetPoints(text);
        }
    }
    #endregion


    #region Métodos Públicos

    /// <summary>
    /// Regresa al menú principal
    /// </summary>
    public void Back() {
		AudioManager.Play(AudioClipName.Click);
		MenuManager.GoToMenu(MenuName.Main);
	}
    #endregion
}