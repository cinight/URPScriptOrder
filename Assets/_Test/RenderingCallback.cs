using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingCallback : MonoBehaviour
{
    // Script

    void Awake()
    {
        Debug.Log("MonoBehaviour - Awake() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void Start()
    {
        Debug.Log(" MonoBehaviour - Start() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void Update()
    {
        Debug.Log(" MonoBehaviour - Update() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void LateUpdate()
    {
        Debug.Log(" MonoBehaviour - LateUpdate() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void OnEnable()
    {
        Debug.Log(" MonoBehaviour - OnEnable() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void OnDisable()
    {
        Debug.Log(" MonoBehaviour - OnDisable() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void OnDestroy()
    {
        Debug.Log(" MonoBehaviour - OnDestroy() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    // Rendering

    void OnWillRenderObject()
    {
        Debug.Log(" MonoBehaviour - OnWillRenderObject() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void OnPreCull()
    {
        Debug.Log(" MonoBehaviour - OnPreCull() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void OnBecameVisible()
    {
        Debug.Log(" MonoBehaviour - OnBecameVisible() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void OnBecameInvisible()
    {
        Debug.Log(" MonoBehaviour - OnBecameInvisible() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void OnPreRender()
    {
        Debug.Log(" MonoBehaviour - OnPreRender() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void OnRenderObject()
    {
        Debug.Log(" MonoBehaviour - OnRenderObject() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void OnPostRender()
    {
        Debug.Log(" MonoBehaviour - OnPostRender() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src,dst);
        Debug.Log(" MonoBehaviour - OnRenderImage() - "+"<color=yellow>"+this.gameObject.name+"</color>");
    }
}
