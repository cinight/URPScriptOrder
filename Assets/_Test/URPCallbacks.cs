using System;
using System.Collections.Generic;
using UnityEngine;
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
        Debug.Log("ScriptableRendererFeature - AddRenderPasses()");

        var cameraColorTarget = renderer.cameraColorTarget;
        var pass = new URPCallbackPass(Event);
        renderer.EnqueuePass(pass);
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

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            Debug.Log("ScriptableRenderPass - Execute()");
            var cmd = CommandBufferPool.Get("URP Callback Pass");

            //Execute commandbuffer
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}