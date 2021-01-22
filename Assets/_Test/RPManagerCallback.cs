using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RPManagerCallback : MonoBehaviour
{
    void Start()
    {
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        RenderPipelineManager.beginFrameRendering += OnBeginFrameRendering;

        RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
        RenderPipelineManager.endFrameRendering += OnEndFrameRendering;

    }

    void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        Debug.Log("RenderPipelineManager - OnBeginCameraRendering()");
    }

    void OnBeginFrameRendering(ScriptableRenderContext context, Camera[] cameras)
    {
        Debug.Log("RenderPipelineManager - OnBeginFrameRendering()");
    }

    void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        Debug.Log("RenderPipelineManager - OnEndCameraRendering()");
    }

    void OnEndFrameRendering(ScriptableRenderContext context, Camera[] cameras)
    {
        Debug.Log("RenderPipelineManager - OnEndFrameRendering()");
    }

    void OnDestroy()
    {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        RenderPipelineManager.beginFrameRendering -= OnBeginFrameRendering;

        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
        RenderPipelineManager.endFrameRendering -= OnEndFrameRendering;
    }
}
