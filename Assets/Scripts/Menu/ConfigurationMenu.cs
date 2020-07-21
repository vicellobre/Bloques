using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ConfigurationMenu : Menu {

    #region Campos

    private readonly  string[]  LANGUAGES_NAMES = { "English", "Español"};
    private Text                musicText, languageText, soundText;
    private GameObject          musicObject, speakersObject;
    #endregion


    #region Métodos Protegidos

    /// <summary>
    /// Inicializa todos los gameObjects con etiqueta Boton
    /// </summary>
    protected override void Initialize() {
        base.Initialize();

        speakersObject = GameObject.FindGameObjectWithTag("SpeakersSounds");

        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Boton");
        foreach (GameObject button in buttons) {
            switch (Type(button)) {

                case ButtonName.Music:
                    musicObject = Resources.Load<GameObject>("Prefabs/SpeakersMusic");
                    musicText = button.GetComponent<Text>();
                    musicText.text = TextName(musicText);
                    musicText.text += ConfigurationUtils.Music ? ": On" : ": Off";
                    break;
                
                case ButtonName.Language:
                    languageText = button.GetComponent<Text>();
                    languageText.text = TextName(languageText);
                    languageText.text += ": " + LANGUAGES_NAMES[ (int)ConfigurationUtils.Language ];
                    break;

                case ButtonName.Sounds:
                    soundText = button.GetComponent<Text>();
                    soundText.text = TextName(soundText);
                    soundText.text += ConfigurationUtils.Sounds ? ": On" : ": Off";
                    break;
            }
        }
    }
    #endregion


    #region Métodos Privados

    /// <summary>
    /// Determina a qué tipo de botón pertenece el objeto
    /// </summary>
    /// <param name="button">Objeto a convetir su nombre en ButtonName</param>
    /// <returns>El nombre del objeto convertido a tipo ButtonName</returns>
    private ButtonName Type(GameObject button) {
        return (ButtonName) System.Enum.Parse(typeof(ButtonName), button.name);
    }
    #endregion

    
    #region Métodos Públicos
    
    /// <summary>
    /// Habilita/Deshabilita la música del juego.
    /// </summary>
    public void Music() {
        AudioManager.Play(AudioClipName.Click);
        ConfigurationUtils.Music = !ConfigurationUtils.Music;
        musicText.text = TextName(musicText);
        if (ConfigurationUtils.Music) {
            Instantiate(musicObject, speakersObject.transform.position, Quaternion.identity, speakersObject.transform);
            musicText.text += ": On";
        } else {
            musicText.text += ": Off";
            Destroy(GameObject.FindGameObjectWithTag("SpeakersMusic"));
        }
    }

    /// <summary>
    /// Habilita/Deshabilita los efectos de sonidos del juego.
    /// </summary>
    public void Sounds() {
        AudioManager.Play(AudioClipName.Click);
        ConfigurationUtils.Sounds = !ConfigurationUtils.Sounds;
        speakersObject.GetComponent<AudioSource>().enabled = ConfigurationUtils.Sounds;

        soundText.text = TextName(soundText);
        soundText.text += ConfigurationUtils.Sounds ? ": On" : ": Off";
    }
    
    /// <summary>
    /// Cambia el idioma al instante
    /// y guarda el idioma actual en una
    /// variable del PlayerPrefs
    /// </summary>
    public void Language() {
        AudioManager.Play(AudioClipName.Click);
        
        int i = (int)ConfigurationUtils.Language;

        i = (i < (int)LanguageName.Spanish) ? i+1 : 0;
        ConfigurationUtils.Language = (LanguageName)i;

        languageText.text = TextName(languageText);
        languageText.text += ": " + LANGUAGES_NAMES[ (int)ConfigurationUtils.Language ];

        PlayerPrefs.SetString("Language", ConfigurationUtils.Language.ToString());

        //Initialize();
        MenuManager.GoToMenu(MenuName.Settings);
    }

    /// <summary>
    /// Regresa al menú principal
    /// </summary>
    public void Back() {
        PlayerPrefs.Save();//OJO
		AudioManager.Play(AudioClipName.Click);
		MenuManager.GoToMenu(MenuName.Main);
	}
    #endregion
}