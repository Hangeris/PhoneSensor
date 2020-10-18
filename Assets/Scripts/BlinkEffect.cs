using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkEffect : MonoBehaviour
{
    public AnimationCurve alphaCurve;
    public Image image;

    void Update()
    {
        Blink();
    }

    public void Blink()
    {
        Debug.Log(alphaCurve.length);
    }
    
}
