using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkEffect : MonoBehaviour
{
    public AnimationCurve alphaCurve;
    public Image image;
    public void Blink(Color color)
    {
        StopAllCoroutines();
        StartCoroutine(BlinkRoutine(color));
    }

    IEnumerator BlinkRoutine(Color color)
    {
        float time = 0;
        var startColor = color;
        startColor.a = 0;
        image.color = startColor;
        
        while (true)
        {
            yield return null;
            time += Time.deltaTime;
            startColor.a = alphaCurve.Evaluate(time);
            image.color = startColor;

            if (alphaCurve.Evaluate(time) <= 0)
                yield break;
        }
        
        
    }
    
}
