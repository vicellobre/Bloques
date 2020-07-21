using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager {

    #region Métodos Privados

    /// <summary>
    /// Reproduce el sonido del botón
    /// y carga el menú escena indicado.
    /// </summary>
    /// <param name="menuName">Nombre de la escena a cargar</param>
    private static void LoadScene(MenuName menuName) {
        AudioManager.Play(AudioClipName.Click);
        SceneManager.LoadScene(menuName.ToString() + "Menu");
    }

    /// <summary>
    /// Reproduce el sonido del botón
    /// y carga un menú objeto desde la carpeta Resources
    /// </summary>
    /// <param name="menuName">Nombre del objeto menú</param>
    /// <param name="audioName">Nombre del audio a reproducir</param>
    private static void LoadObject(MenuName menuName, AudioClipName audioName) {
        AudioManager.Play(audioName);
        Object.Instantiate(Resources.Load("Prefabs/" + menuName.ToString() + "Menu"),
            GameObject.FindGameObjectWithTag("HUD").transform);
    }

    /// <summary>
    /// Configura las variables para empezar un nuevo juego
    /// y reproduce el sonido indicado.
    /// <para>
    /// Establece timeScale a 1
    /// </para><para>
    /// Establece la variable global EnJuego en falso
    /// </para>
    /// </summary>
    /// <param name="audioName"></param>
    private static void NewGame() {
        Time.timeScale = 1;
        ConfigurationUtils.EnJuego = false;
    }
    #endregion

    #region Métodos Públicos

    /// <summary>
    /// Carga la escena menú u objeto menú indicado.
    /// </summary>
    /// <param name="name">Nombre del menú</param>
    public static void GoToMenu(MenuName name) {
        switch (name) {
            case MenuName.Settings:
                LoadScene(name);
                break;

            case MenuName.Credits:
                LoadScene(name);
                break;

            case MenuName.Difficulty:
                LoadScene(name);
                break;

            case MenuName.GameOver:
                LoadObject(name, AudioClipName.GameOver);
                break;

            case MenuName.Gameplay:
                AudioManager.Play(AudioClipName.Click);
                SceneManager.LoadScene("Level 01");
                break;

            case MenuName.Help:
                LoadScene(name);
                break;

            case MenuName.HighScore:
                LoadScene(name);
                break;

            case MenuName.Levels:
                LoadScene(name);
                break;

            case MenuName.Main:
                LoadScene(name);
                break;

            case MenuName.NextLevel:
                NewGame();
                if (NextLevelExist()) {
                    int levelIndex = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(levelIndex + 1);
                } else {
                    GoToMenu(MenuName.Main);
                }

                break;

            case MenuName.Pause:
                LoadObject(name, AudioClipName.Click);
                break;

            case MenuName.Restart:
                NewGame();
                AudioManager.Play(AudioClipName.Click);
                string levelName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(levelName);
                break;
        }
    }

    /// <summary>
    /// Carga la escena menú u objeto menú indicado.
    /// </summary>
    /// <param name="name">Nombre del menú</param>
    public static bool NextLevelExist() {
        return SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings;
    }

    /// <summary>
    /// Carga el nivel del juego seleccionado.
    /// </summary>
    /// <param name="name">Nombre del nivel</param>
    public static void GoToLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

    /// <summary>
    /// Obtiene el nombre de la escena actual
    /// </summary>
    /// <returns>Nombre de la escena actual</returns>
    public static string SceneName() {
        return SceneManager.GetActiveScene().name;
    }
    #endregion
}