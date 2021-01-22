using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingCallback : MonoBehaviour
{
    // Script

    void Awake()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - Awake()");
    }

    void Start()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - Start()");
    }

    void Update()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - Update()");
    }

    void LateUpdate()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - LateUpdate()");
    }

    void OnEnable()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnEnable()");
    }

    void OnDisable()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnDisable()");
    }

    void OnDestroy()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnDestroy()");
    }

    // Rendering

    void OnWillRenderObject()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnWillRenderObject()");
    }

    void OnPreCull()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnPreCull()");
    }

    void OnBecameVisible()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnBecameVisible()");
    }

    void OnBecameInvisible()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnBecameInvisible()");
    }

    void OnPreRender()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnPreRender()");
    }

    void OnRenderObject()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnRenderObject()");
    }

    void OnPostRender()
    {
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnPostRender()");
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src,dst);
        Debug.Log(this.gameObject.name + " MonoBehaviour - OnRenderImage()");
    }
}
