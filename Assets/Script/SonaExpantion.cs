using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SonaExpantion : MonoBehaviour
{
    private GameObject sona = null;
    Light2D sona_light = null;
    SpriteRenderer spriteRenderer = null;
    Transform tr = null;

    public Vector3 sonaScale = new Vector3(0.35f, 0.35f, 0.35f);
    // inspector :
    // extandeTime 0.1
    // fadeTime 0.3
    public float extandeTime;
    public float fadeTime;
    public float lightFadeTime;

    public float initialOuterRadius = 1.0f;

    void Start()
    {
        sona = this.gameObject;
        spriteRenderer = sona.GetComponent<SpriteRenderer>();
        tr = sona.GetComponent<Transform>();
        sona_light = sona.GetComponent<Light2D>();

        StartCoroutine(ExpandAndFade());
        StartCoroutine(LightExpand());
    }


    IEnumerator ExpandAndFade()
    {
        Vector3 initialScale = tr.localScale;
        Vector3 targetScale = sonaScale;
        float elapsedTime = 0f;

        // Expand
        while (elapsedTime < extandeTime)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / extandeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        tr.localScale = targetScale;

        // Fade
        elapsedTime = 0;
        Color initialColor = spriteRenderer.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0);

        while (elapsedTime < fadeTime)
        {
            spriteRenderer.color = Color.Lerp(initialColor, targetColor, elapsedTime / fadeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        spriteRenderer.color = targetColor;
    }
    IEnumerator LightExpand()
    {
        float targetRadius = initialOuterRadius * 2f;
        float lightTime = 0f;

        sona_light.pointLightOuterRadius = 2.0f;

        // Expand
        while (lightTime < lightFadeTime)
        {
            sona_light.pointLightOuterRadius = Mathf.Lerp(targetRadius, initialOuterRadius, lightTime / lightFadeTime);
            lightTime += Time.deltaTime;
            yield return null;
        }

    }
}
