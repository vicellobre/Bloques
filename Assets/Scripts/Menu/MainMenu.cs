using UnityEngine;

public class MainMenu : Menu {

	#region Métodos Privados

	/// <summary>
	/// Carga el menú seleccionado
	/// </summary>
	/// <param name="menuName">Nombre del menú a cargar</param>
    private void LoadMenu(MenuName menuName) {
        MenuManager.GoToMenu(menuName);
    }
	#endregion
	
	
	#region Métodos Públicos

	/// <summary>
	/// Carga menú de Configuracion
	/// </summary>
    public void Settings() {
        LoadMenu(MenuName.Settings);
    }
    
	/// <summary>
	/// Carga menú de Ayuda
	/// </summary>
    public void Help() {
        LoadMenu(MenuName.Help);
    }
    
	/// <summary>
	/// Carga menú de Máximos Puntajes
	/// </summary>
    public void HighScore() {
        LoadMenu(MenuName.HighScore);
    }
    
	/// <summary>
	/// Carga menú de seleccion de dificultad
	/// </summary>
    public void PlayGame() {
        LoadMenu(MenuName.Difficulty);
    }

	/// <summary>
	/// Cierra el juego
	/// <para>
	/// antes, guarda los datos del juego
	/// </para>
	/// </summary>
    public void QuitGame() {
        PlayerPrefs.Save();
        AudioManager.Play(AudioClipName.Click);
        Application.Quit();
    }
	#endregion
}