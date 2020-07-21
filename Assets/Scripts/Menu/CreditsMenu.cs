using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : Menu {
    
    #region Métodos Públicos

    /// <summary>
    /// Regresa al menú de ayuda
    /// </summary>
    public void Back() {
		AudioManager.Play(AudioClipName.Click);
		MenuManager.GoToMenu(MenuName.Help);
	}
    #endregion
}
