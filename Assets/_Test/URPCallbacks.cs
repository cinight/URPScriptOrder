using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu]
public class URPCallbacks : ScriptableRendererFeature
{
    public RenderPassEvent Event = RenderPassEvent.AfterRenderingPostProcessing;

	public URPCallbacks()
	{
        Debug.Log("ScriptableRendererFeature - Constructor");
	}

	public override void Create()
    {
        Debug.Log("ScriptableRendererFeature - Create()");
	}

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        var cam = renderingData.cameraData.camera.name;
        Debug.Log("ScriptableRendererFeature - AddRenderPasses() - "+cam);

        var cameraColorTarget = renderer.cameraColorTarget;
        var pass = new URPCallbackPass(Event);
        renderer.EnqueuePass(pass);
    }
    
    public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
    {
        var cam = renderingData.cameraData.camera.name;
        Debug.Log("ScriptableRendererFeature - SetupRenderPasses() - "+cam);
    }
    
    public override void OnCameraPreCull(ScriptableRenderer renderer, in CameraData cameraData)
    {
        var cam = cameraData.camera.name;
        Debug.Log("ScriptableRendererFeature - OnCameraPreCull() - "+cam);
    }

    protected override void Dispose(bool disposing)
    {
        Debug.Log("ScriptableRendererFeature - Dispose()");
    }

    //========================================================================================================
    internal class URPCallbackPass : ScriptableRenderPass
    {
        public URPCallbackPass(RenderPassEvent renderPassEvent)
        {
            Debug.Log("ScriptableRenderPass - Constructor");
            this.renderPassEvent = renderPassEvent;
        }
        
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            Debug.Log("ScriptableRenderPass - Configure()");
        }
        
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            var cam = renderingData.cameraData.camera.name;
            Debug.Log("ScriptableRenderPass - OnCameraSetup() - "+cam);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var cam = renderingData.cameraData.camera.name;
            Debug.Log("ScriptableRenderPass - Execute() - "+cam);
            
            //Execute commandbuffer
            var cmd = CommandBufferPool.Get("URP Callback Pass");
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
        
        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            Debug.Log("ScriptableRenderPass - OnCameraCleanup()");
        }
        
        public override void OnFinishCameraStackRendering(CommandBuffer cmd)
        {
            Debug.Log("ScriptableRenderPass - OnFinishCameraStackRendering()");
        }
    }
}