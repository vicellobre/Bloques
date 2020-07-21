using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class LanguagesData {

    #region Campos

    private Dictionary<string, Dictionary<string, string>>  dictionary =
        new Dictionary<string, Dictionary<string, string>>();
    private const string LANGUAGES_DATA_FILE_NAME = "LanguagesData.csv";
    #endregion


    #region Propiedades

    public Dictionary<string, Dictionary<string, string>> Dict {
        get { return dictionary;}
    }
    #endregion


    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public LanguagesData() {
        StreamReader file = null;
        try {
            file = File.OpenText(Path.Combine(Application.streamingAssetsPath, LANGUAGES_DATA_FILE_NAME));

            //CONVIERTE UN ENUM A ARRAY
            string[] words = Enum.GetNames(typeof(WordsName));
            //INICIALIZANDO DICCIONARIO EXTERNO (PALABRAS)
            foreach (string word in words) {
               dictionary.Add(word, new Dictionary<string, string>());
            }

            //CONVIRTIENDO UN ENUM A ARRAY PARA CREAR LA TUPLA CON EL METODO ZIP
            string[] languages = Enum.GetNames(typeof(LanguageName));
            //LEYENDO LA PRIMERA LINEA
            string line = file.ReadLine();
            //OBTENIENDO PRIMERA PALABRA
            int i = 0;
            while (line != null && i < words.Length) {

                //OBTENIENDO EL SEGUNDO ARRAY PARA CREAR LA TUPLA CON EL METODO ZIP
                string[] translation = line.Split(';');
                //CREANDO LA TUPLA ITERABLE CON EL METODO ZIP
                var tuples = languages.Zip(translation, (l, t) => new { Language = l, Translation = t });
                //PARA RECORRER 2 ENUMERABLES EN UN FOREACH
                foreach (var tuple in tuples) {
                    dictionary[words[i]].Add(tuple.Language, tuple.Translation);
                } 

                //LEYENDO LA SIGUIENTE LINEA
                line = file.ReadLine();
                //SIGUIENTE PALABRA
                i++;
            }
        } catch (Exception) {
            LoadFile();
        } finally {
            if (file != null) {
                file.Close();
            }
            
        }
    }

    private void LoadFile() {
        dictionary.Add("Back", new Dictionary<string, string>());
        dictionary.Add("Blocks", new Dictionary<string, string>());
        dictionary.Add("Credits", new Dictionary<string, string>());
        dictionary.Add("Difficulty", new Dictionary<string, string>());
        dictionary.Add("Easy", new Dictionary<string, string>());
        dictionary.Add("Exit", new Dictionary<string, string>());
        dictionary.Add("GameCompleted", new Dictionary<string, string>());
        dictionary.Add("GameOver", new Dictionary<string, string>());
        dictionary.Add("Hard", new Dictionary<string, string>());
        dictionary.Add("Help", new Dictionary<string, string>());
        dictionary.Add("HighScore", new Dictionary<string, string>());
        dictionary.Add("Home", new Dictionary<string, string>());
        dictionary.Add("Language", new Dictionary<string, string>());
        dictionary.Add("Level", new Dictionary<string, string>());
        dictionary.Add("LevelCompleted", new Dictionary<string, string>());
        dictionary.Add("Levels", new Dictionary<string, string>());
        dictionary.Add("Lives", new Dictionary<string, string>());
        dictionary.Add("Medium", new Dictionary<string, string>());
        dictionary.Add("Music", new Dictionary<string, string>());
        dictionary.Add("Pause", new Dictionary<string, string>());
        dictionary.Add("Play", new Dictionary<string, string>());
        dictionary.Add("Points", new Dictionary<string, string>());
        dictionary.Add("Restart", new Dictionary<string, string>());
        dictionary.Add("Resume", new Dictionary<string, string>());
        dictionary.Add("Settings", new Dictionary<string, string>());
        dictionary.Add("Sounds", new Dictionary<string, string>());
        dictionary.Add("Title", new Dictionary<string, string>());

        dictionary["Back"].Add("English", "Back");
        dictionary["Back"].Add("Spanish", "Atras");

        dictionary["Blocks"].Add("English", "Blocks!");
        dictionary["Blocks"].Add("Spanish", "Bloques!");

        dictionary["Credits"].Add("English", "Credits");
        dictionary["Credits"].Add("Spanish", "Creditos");
        
        dictionary["Difficulty"].Add("English", "Difficulty");
        dictionary["Difficulty"].Add("Spanish", "Dificultad");
        
        dictionary["Easy"].Add("English", "Easy");
        dictionary["Easy"].Add("Spanish", "Facil");
        
        dictionary["Exit"].Add("English", "Exit");
        dictionary["Exit"].Add("Spanish", "Salir");
        
        dictionary["GameCompleted"].Add("English", "Game Completed!");
        dictionary["GameCompleted"].Add("Spanish", "Juego Completado!");
        
        dictionary["GameOver"].Add("English", "GameOver!");
        dictionary["GameOver"].Add("Spanish", "GameOver!");
        
        dictionary["Hard"].Add("English", "Hard");
        dictionary["Hard"].Add("Spanish", "Dificil");
        
        dictionary["Help"].Add("English", "Help");
        dictionary["Help"].Add("Spanish", "Ayuda");
        
        dictionary["HighScore"].Add("English", "HighScore");
        dictionary["HighScore"].Add("Spanish", "Mejores Puntajes");
        
        dictionary["Home"].Add("English", "Home");
        dictionary["Home"].Add("Spanish", "Inicio");
        
        dictionary["Language"].Add("English", "Language");
        dictionary["Language"].Add("Spanish", "Idioma");
        
        dictionary["Level"].Add("English", "Level");
        dictionary["Level"].Add("Spanish", "Nivel");
        
        dictionary["LevelCompleted"].Add("English", "Level Completed!");
        dictionary["LevelCompleted"].Add("Spanish", "Nivel Completado!");
        
        dictionary["Levels"].Add("English", "Levels");
        dictionary["Levels"].Add("Spanish", "Niveles");
        
        dictionary["Lives"].Add("English", "Lives");
        dictionary["Lives"].Add("Spanish", "Vidas");
        
        dictionary["Medium"].Add("English", "Medium");
        dictionary["Medium"].Add("Spanish", "Medio");
        
        dictionary["Music"].Add("English", "Music");
        dictionary["Music"].Add("Spanish", "Musica");
        
        dictionary["Pause"].Add("English", "Pause");
        dictionary["Pause"].Add("Spanish", "Pausa");
        
        dictionary["Play"].Add("English", "Play");
        dictionary["Play"].Add("Spanish", "Jugar");
        
        dictionary["Points"].Add("English", "Points");
        dictionary["Points"].Add("Spanish", "Puntos");
        
        dictionary["Restart"].Add("English", "Restart");
        dictionary["Restart"].Add("Spanish", "Reiniciar");
        
        dictionary["Resume"].Add("English", "Resume");
        dictionary["Resume"].Add("Spanish", "Reanudar");
        
        dictionary["Settings"].Add("English", "Settings");
        dictionary["Settings"].Add("Spanish", "Ajustes");
        
        dictionary["Sounds"].Add("English", "Sounds");
        dictionary["Sounds"].Add("Spanish", "Sonidos");
        
        dictionary["Title"].Add("English", "Title");
        dictionary["Title"].Add("Spanish", "Titulo");
    }
    #endregion
}