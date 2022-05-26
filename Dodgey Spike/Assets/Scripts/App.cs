using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public static App instance;

    private void Awake()
    {
        if(instance == null) { instance = this; }
        else if (instance != this) { Destroy(gameObject); }

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        DontDestroyOnLoad(this.gameObject);
    }
}
