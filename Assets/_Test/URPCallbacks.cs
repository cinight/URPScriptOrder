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
    public string name = "Feature1";
    public RenderPassEvent Event = RenderPassEvent.AfterRenderingPostProcessing;

	public URPCallbacks()
	{
        Debug.Log("ScriptableRendererFeature - Constructor - "+"<color=yellow>"+name+"</color>");
	}

	public override void Create()
    {
        Debug.Log("ScriptableRendererFeature - Create() - "+"<color=yellow>"+name+"</color>");
	}

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        var cam = renderingData.cameraData.camera.name;
        Debug.Log("ScriptableRendererFeature - AddRenderPasses() - "+"<color=yellow>"+name+" - "+cam+"</color>");
        
        var pass1 = new URPCallbackPass(Event, name+"_Pass1");
        renderer.EnqueuePass(pass1);
        
        var pass2 = new URPCallbackPass(Event, name+"_Pass2");
        renderer.EnqueuePass(pass2);
    }
    
    public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
    {
        var cam = renderingData.cameraData.camera.name;
        Debug.Log("ScriptableRendererFeature - SetupRenderPasses() - "+"<color=yellow>"+name+" - "+cam+"</color>");
    }
    
    public override void OnCameraPreCull(ScriptableRenderer renderer, in CameraData cameraData)
    {
        var cam = cameraData.camera.name;
        Debug.Log("ScriptableRendererFeature - OnCameraPreCull() - "+"<color=yellow>"+name+" - "+cam+"</color>");
    }

    protected override void Dispose(bool disposing)
    {
        Debug.Log("ScriptableRendererFeature - Dispose() - "+"<color=yellow>"+name+"</color>");
    }

    //========================================================================================================
    internal class URPCallbackPass : ScriptableRenderPass
    {
        private string m_Name;
        
        public URPCallbackPass(RenderPassEvent renderPassEvent, string name)
        {
            //Debug.Log("ScriptableRenderPass - Constructor"); Not important as you can customize when to create the pass
            this.renderPassEvent = renderPassEvent;
            m_Name = name;
        }
        
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            Debug.Log("ScriptableRenderPass - Configure() - "+"<color=yellow>"+m_Name+"</color>");
        }
        
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            var cam = renderingData.cameraData.camera.name;
            Debug.Log("ScriptableRenderPass - OnCameraSetup() - "+"<color=yellow>"+m_Name+" - "+cam+"</color>");
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var cam = renderingData.cameraData.camera.name;
            Debug.Log("ScriptableRenderPass - Execute() - "+"<color=yellow>"+m_Name+" - "+cam+"</color>");
            
            //Execute commandbuffer
            var cmd = CommandBufferPool.Get("URP Callback Pass");
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
        
        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            Debug.Log("ScriptableRenderPass - OnCameraCleanup() - "+"<color=yellow>"+m_Name+"</color>");
        }
        
        public override void OnFinishCameraStackRendering(CommandBuffer cmd)
        {
            Debug.Log("ScriptableRenderPass - OnFinishCameraStackRendering() - "+"<color=yellow>"+m_Name+"</color>");
        }
    }
}