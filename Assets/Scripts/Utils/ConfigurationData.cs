using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData {
    #region Campos

    private const string    CONFIGURATION_DATA_FILE_NAME = "ConfigurationData.csv";

    // configuration data
    private static float    _VELOCIDAD_PELOTA_FACIL = 600f;
    private static float    _VELOCIDAD_PELOTA_MEDIO = 700f;
    private static float    _VELOCIDAD_PELOTA_DIFICIL = 800f;
    private static float    _VELOCIDAD_BARRA = 20f;
    private static float    _SEGUNDOS_CONGELADO = 2f;
    private static float    _SEGUNDOS_VELOCIDAD = 3f;
    private static float    _MULTIPLICADOR_VELOCIDAD = 0.33f;
    private static float    _VELOCIDAD_BARRA_MOVIL = 8f;
    private static float    _PROB_BLOQUE_BONUS_FACIL = 30f;
    private static float    _PROB_BLOQUE_BONUS_MEDIO = 25f;
    private static float    _PROB_BLOQUE_BONUS_DIFICIL = 20f;
    private static float    _PROB_BLOQUE_VELOZ_FACIL = 20f;
    private static float    _PROB_BLOQUE_VELOZ_MEDIO = 25f;
    private static float    _PROB_BLOQUE_VELOZ_DIFICIL = 30f;
    private static float    _PROB_BLOQUE_HIELO_FACIL = 15f;
    private static float    _PROB_BLOQUE_HIELO_MEDIO = 20f;
    private static float    _PROB_BLOQUE_HIELO_DIFICIL = 25f;
    private static int      _PUNTOS = 10;


    #endregion

    #region Propiedades

    public float VelocidadPelotaFacil { get { return _VELOCIDAD_PELOTA_FACIL; } }
    public float VelocidadPelotaMedio { get { return _VELOCIDAD_PELOTA_MEDIO; } }
    public float VelocidadPelotaDificil { get { return _VELOCIDAD_PELOTA_DIFICIL; } }
    public float VelocidadBarra { get { return _VELOCIDAD_BARRA; } }
    public float SegundosCongelado { get { return _SEGUNDOS_CONGELADO; } }
    public float SegundosVelocidad { get { return _SEGUNDOS_VELOCIDAD; } }
    public float MultiplicadorVelocidad { get { return _MULTIPLICADOR_VELOCIDAD; } }
    public float VelocidadBarraMovil { get { return _VELOCIDAD_BARRA_MOVIL; } }
    public float ProbBloqueBonusFacil { get { return _PROB_BLOQUE_BONUS_FACIL; } }
    public float ProbBloqueBonusMedio { get { return _PROB_BLOQUE_BONUS_MEDIO; } }
    public float ProbBloqueBonusDificil { get { return _PROB_BLOQUE_BONUS_DIFICIL; } }
    public float ProbBloqueVelozFacil { get { return _PROB_BLOQUE_VELOZ_FACIL; } }
    public float ProbBloqueVelozMedio { get { return _PROB_BLOQUE_VELOZ_MEDIO; } }
    public float ProbBloqueVelozDificil { get { return _PROB_BLOQUE_VELOZ_DIFICIL; } }
    public float ProbBloqueHieloFacil { get { return _PROB_BLOQUE_HIELO_FACIL; } }
    public float ProbBloqueHieloMedio { get { return _PROB_BLOQUE_HIELO_MEDIO; } }
    public float ProbBloqueHieloDificil { get { return _PROB_BLOQUE_HIELO_DIFICIL; } }
    public int Puntos { get { return _PUNTOS; } }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData() {
        StreamReader file = null;
        try {
            file = File.OpenText(Path.Combine(Application.streamingAssetsPath, CONFIGURATION_DATA_FILE_NAME));
            string names = file.ReadLine();
            string values = file.ReadLine();

            SetConfigurationDataFields(values);
        } catch (Exception) {} finally {
            if (file != null) {
                file.Close();
            }
        }
    }

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    private static void SetConfigurationDataFields(string csvValues) {
        string[] values = csvValues.Split(';');
        _VELOCIDAD_PELOTA_FACIL = float.Parse(values[0]);
        _VELOCIDAD_PELOTA_MEDIO = float.Parse(values[1]);
        _VELOCIDAD_PELOTA_DIFICIL = float.Parse(values[2]);
        _VELOCIDAD_BARRA = float.Parse(values[3]);
        _SEGUNDOS_CONGELADO = float.Parse(values[4]);
        _SEGUNDOS_VELOCIDAD = float.Parse(values[5]);
        _MULTIPLICADOR_VELOCIDAD = float.Parse(values[6]);
        _VELOCIDAD_BARRA_MOVIL = float.Parse(values[7]);
        _PROB_BLOQUE_BONUS_FACIL = float.Parse(values[8]);
        _PROB_BLOQUE_BONUS_MEDIO = float.Parse(values[9]);
        _PROB_BLOQUE_BONUS_DIFICIL = float.Parse(values[10]);
        _PROB_BLOQUE_VELOZ_FACIL = float.Parse(values[11]);
        _PROB_BLOQUE_VELOZ_MEDIO = float.Parse(values[12]);
        _PROB_BLOQUE_VELOZ_DIFICIL = float.Parse(values[13]);
        _PROB_BLOQUE_HIELO_FACIL = float.Parse(values[14]);
        _PROB_BLOQUE_HIELO_MEDIO = float.Parse(values[15]);
        _PROB_BLOQUE_HIELO_DIFICIL = float.Parse(values[16]);
        _PUNTOS = int.Parse(values[17]);
    }
    #endregion
}