using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : Menu {
    
    #region Métodos Públicos

    /// <summary>
    /// Regresa al menú principal
    /// </summary>
    public void Back() {
		AudioManager.Play(AudioClipName.Click);
		MenuManager.GoToMenu(MenuName.Main);
	}

    /// <summary>
    /// Regresa al menú principal
    /// </summary>
    public void Credits() {
		AudioManager.Play(AudioClipName.Click);
		MenuManager.GoToMenu(MenuName.Credits);
	}
  #endregion
}