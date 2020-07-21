using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPlay : MonoBehaviour {     

    #region Métodos Públicos

    /// <summary>
    /// Carga la escena con el nombre del objeto
    /// </summary>
    public void LoadLevel () {
        AudioManager.Play(AudioClipName.Click);
        SceneManager.LoadScene(gameObject.name);
    }
    #endregion
}
