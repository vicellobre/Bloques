using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

    public string nivelACargar;
    public float retraso;

    [ContextMenu("Activar Carga")]
    public void ActivarCarga() {
        Invoke("CargarNivel", retraso);
    }

    public bool EsUltimoNivel() {
        return nivelACargar == "Portada";
    }
}