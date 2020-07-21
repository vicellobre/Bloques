using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : Menu {

    private void Update() {
        // Carga al Menú principal si se presiona
        // click izquierdo
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            MenuManager.GoToMenu(MenuName.Main);
        }
    }
}