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
        
        RenderPipelineManager.beginContextRendering += OnBeginContextRendering;
        RenderPipelineManager.endContextRendering += OnEndContextRendering;

    }

    void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        Debug.Log("RenderPipelineManager - OnBeginCameraRendering() - "+"<color=yellow>"+camera.name+"</color>");
    }

    void OnBeginFrameRendering(ScriptableRenderContext context, Camera[] cameras)
    {
        Debug.Log("RenderPipelineManager - OnBeginFrameRendering()");
    }

    void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        Debug.Log("RenderPipelineManager - OnEndCameraRendering() - "+"<color=yellow>"+camera.name+"</color>");
    }

    void OnEndFrameRendering(ScriptableRenderContext context, Camera[] cameras)
    {
        Debug.Log("RenderPipelineManager - OnEndFrameRendering()");
    }
    
    void OnBeginContextRendering(ScriptableRenderContext context, List<Camera> cameras)
    {
        Debug.Log("RenderPipelineManager - OnBeginContextRendering()");
    }
    
    void OnEndContextRendering(ScriptableRenderContext context, List<Camera> cameras)
    {
        Debug.Log("RenderPipelineManager - OnEndContextRendering()");
    }

    void OnDestroy()
    {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        RenderPipelineManager.beginFrameRendering -= OnBeginFrameRendering;

        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
        RenderPipelineManager.endFrameRendering -= OnEndFrameRendering;
        
        RenderPipelineManager.beginContextRendering -= OnBeginContextRendering;
        RenderPipelineManager.endContextRendering -= OnEndContextRendering;
    }
}
