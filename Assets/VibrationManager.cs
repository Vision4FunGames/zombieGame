using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : Singleton<VibrationManager>
{
    private void Awake()
    {
        Vibration.Init();
    }
    public void Vib()
    {
        Vibration.VibratePop();
    }
}
