using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class LevelsMenu : Menu {

    #region Campos

    private int     _currentLevels;
    #endregion


    #region Métodos Privados

    /// <summary>
    /// Deshabilita los niveles bloqueados
    /// <para>
    /// Cambiar el color del texto a gris
    /// </para><para>
    /// Desactiva el componente Button
    /// </summary>
    /// <param name="button">Botón hijo del HUD</param>
    private void DisableLevel(GameObject button) {
        Text txt = button.GetComponent<Text>();
        int level = int.Parse(txt.text);

        if (level > _currentLevels) {
            txt.color = Color.grey;
            button.GetComponent<Button>().enabled = false;
        }
    }
    #endregion


    #region Métodos Protegidos
    
        /// <summary>
    /// Busca los hijos del HUD
    /// para desactivar los niveles
    /// superiores
    /// </summary>
    protected override void Initialize() {
        base.Initialize();

        string difficulty = ConfigurationUtils.Difficulty.ToString();
        _currentLevels = PlayerPrefs.GetInt(difficulty + "Levels", 1);

        foreach (Transform child in transform) {
            if (child.name.Contains("Level") && child.TryGetComponent<Button>(out Button component)) {
                DisableLevel(child.gameObject);
            }
        }
    }
    #endregion
    
    
    #region Métodos Públicos

    /// <summary>
    /// Regresa al menú de selección de dificultad
    /// </summary>
    public void Back() {
		AudioManager.Play(AudioClipName.Click);
		MenuManager.GoToMenu(MenuName.Difficulty);
	}
    #endregion
}