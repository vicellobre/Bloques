using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils {
    
    #region  Fields
    
    private const LanguageName          _LANGUAGE_DEFAULT = LanguageName.English;
    private static ConfigurationData    _CONFIGURATION_DATA;
    private static LanguagesData        _LANGUAGES_DATA;
    private static LanguageName         _LANGUAGE;
    private static bool                 _MUSIC = true;
    private static bool                 _SOUNDS = true;
    private static bool                 _GAME_OVER = false;
    private static bool                 _EN_JUEGO =  false;
    private static float                _VELOCIDAD_PELOTA;
    private static float                _PROB_BLOQUE_BONUS;
    private static float                _PROB_BLOQUE_VELOZ;
    private static float                _PROB_BLOQUE_HIELO;
    private static Difficulty           _DIFFICULTY = Difficulty.Easy;
    #endregion


    #region Properties

    public static float         VelocidadBarra { get { return _CONFIGURATION_DATA.VelocidadBarra; } }
    public static float         VelocidadBarraMovil { get { return _CONFIGURATION_DATA.VelocidadBarraMovil; } }
    public static float         SegundosCongelado { get { return _CONFIGURATION_DATA.SegundosCongelado; } }
    public static float         SegundosVelocidad { get { return _CONFIGURATION_DATA.SegundosVelocidad; } }
    public static float         MultiplicadorVelocidad { get { return _CONFIGURATION_DATA.MultiplicadorVelocidad; } }
    public static int           Puntos { get { return _CONFIGURATION_DATA.Puntos; } }
    public static LanguageName  Language_DEFAULT { get { return _LANGUAGE_DEFAULT; } }
    public static Dictionary<string, Dictionary<string, string>> Dict { get { return _LANGUAGES_DATA.Dict; } }


    public static LanguageName  Language { get { return _LANGUAGE; } set { _LANGUAGE = value; } }    
    public static bool          EnJuego { get { return _EN_JUEGO; } set { _EN_JUEGO = value;} }
    public static bool          Music { get { return _MUSIC;} set { _MUSIC = value;} }
    public static bool          Sounds { get { return _SOUNDS;} set { _SOUNDS = value;} }

    public static bool          GameOver { get { return _GAME_OVER;} set { _GAME_OVER = value;} }
    public static float         VelocidadPelota { get { return _VELOCIDAD_PELOTA; } set { _VELOCIDAD_PELOTA = value; } }
    public static float         ProbBloqueBonus { get { return _PROB_BLOQUE_BONUS; } set { _PROB_BLOQUE_BONUS = value; } }
    public static float         ProbBloqueVeloz { get { return _PROB_BLOQUE_VELOZ; } set { _PROB_BLOQUE_VELOZ = value; } }
    public static float         ProbBloqueHielo { get { return _PROB_BLOQUE_HIELO; } set { _PROB_BLOQUE_HIELO = value; } }
    public static Difficulty    Difficulty {
        get { return _DIFFICULTY; }

        set {
            _DIFFICULTY = value;
            switch (_DIFFICULTY) {
                case Difficulty.Easy:
                    _DIFFICULTY = Difficulty.Easy;
                    _VELOCIDAD_PELOTA   = _CONFIGURATION_DATA.VelocidadPelotaFacil;
                    _PROB_BLOQUE_BONUS  = _CONFIGURATION_DATA.ProbBloqueBonusFacil;
                    _PROB_BLOQUE_VELOZ  = _CONFIGURATION_DATA.ProbBloqueVelozFacil;
                    _PROB_BLOQUE_HIELO  = _CONFIGURATION_DATA.ProbBloqueHieloFacil;
                    break;

                case Difficulty.Medium:
                    _DIFFICULTY = Difficulty.Medium;
                    _VELOCIDAD_PELOTA   = _CONFIGURATION_DATA.VelocidadPelotaMedio;
                    _PROB_BLOQUE_BONUS  = _CONFIGURATION_DATA.ProbBloqueBonusMedio;
                    _PROB_BLOQUE_VELOZ  = _CONFIGURATION_DATA.ProbBloqueHieloMedio;
                    _PROB_BLOQUE_HIELO  = _CONFIGURATION_DATA.ProbBloqueHieloMedio;
                    break;

                case Difficulty.Hard:
                    _DIFFICULTY = Difficulty.Hard;
                    _VELOCIDAD_PELOTA   = _CONFIGURATION_DATA.VelocidadPelotaDificil;
                    _PROB_BLOQUE_BONUS  = _CONFIGURATION_DATA.ProbBloqueHieloDificil;
                    _PROB_BLOQUE_VELOZ  = _CONFIGURATION_DATA.ProbBloqueVelozDificil;
                    _PROB_BLOQUE_HIELO  = _CONFIGURATION_DATA.ProbBloqueHieloDificil;
                    break;

                default:
                    _DIFFICULTY = Difficulty.Easy;
                    _VELOCIDAD_PELOTA = _CONFIGURATION_DATA.VelocidadPelotaFacil;
                    _PROB_BLOQUE_BONUS = _CONFIGURATION_DATA.ProbBloqueBonusFacil;
                    _PROB_BLOQUE_VELOZ = _CONFIGURATION_DATA.ProbBloqueVelozFacil;
                    _PROB_BLOQUE_HIELO = _CONFIGURATION_DATA.ProbBloqueHieloFacil;
                    break;
            }
        }
    }
    #endregion Properties


    #region Methods Publics

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize() {
        _CONFIGURATION_DATA = new ConfigurationData();
        _LANGUAGES_DATA = new LanguagesData();

        string field = PlayerPrefs.GetString("Language", _LANGUAGE_DEFAULT.ToString());
        _LANGUAGE = (LanguageName) System.Enum.Parse(typeof(LanguageName), field);
    }
    #endregion
}