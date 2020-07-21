using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyMenu : Menu {

    #region Métodos Privados
    
    /// <summary>
    /// Carga la escena Gameplay con la dificultad indicada.
    /// </summary>
    /// <param name="difficulty">Dificultad seleccionada</param>
    private void LoadDifficulty (Difficulty difficulty) {
        ConfigurationUtils.Difficulty = difficulty;
        MenuManager.GoToMenu(MenuName.Levels);
    }
    #endregion
    
    
    #region Métodos Públicos

    /// <summary>
    /// Carga el juego con la dificultad Fácil
    /// </summary>
    public void Easy() {
        LoadDifficulty(Difficulty.Easy);
    }

    /// <summary>
    /// Carga el juego con la dificultad Medio
    /// </summary>
    public void Medium() {
        LoadDifficulty(Difficulty.Medium);
    }

    /// <summary>
    /// Carga el juego con la dificultad Difícil
    /// </summary>
    public void Hard() {
        LoadDifficulty(Difficulty.Hard);
    }

    /// <summary>
    /// Regresa al menú principal
    /// </summary>
    public void Back() {
		AudioManager.Play(AudioClipName.Click);
		MenuManager.GoToMenu(MenuName.Main);
	}
    #endregion
}