using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {

    void Awake() {
        EventManager.Initialize();
        ConfigurationUtils.Initialize();
        ScreenUtils.Initialize();
    }
}