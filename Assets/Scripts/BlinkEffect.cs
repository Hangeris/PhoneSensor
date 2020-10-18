using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    public AnimationCurve alphaCurve;
    public Sprite sprite;

    void Update()
    {
        Blink();
    }

    public void Blink()
    {
        Debug.Log(alphaCurve.length);
    }
    
}
