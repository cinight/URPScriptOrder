#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using System.IO;
#endif
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

internal class CustomRenderer : ScriptableRenderer
{
    public string name = "CustomRenderer";
    
    public CustomRenderer(ScriptableRendererData data) : base(data)
    {
        Debug.Log("ScriptableRenderPass - Constructor - "+"<color=yellow>"+name+"</color>");
    }

    public override void Setup(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        var cam = renderingData.cameraData.camera.name;
        Debug.Log("ScriptableRenderer - Setup() - "+"<color=yellow>"+name+" - "+cam+"</color>");
    }
    
    public override void SetupLights(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        var cam = renderingData.cameraData.camera.name;
        Debug.Log("ScriptableRenderer - SetupLights() - "+"<color=yellow>"+name+" - "+cam+"</color>");
    }
    
    public override void SetupCullingParameters(ref ScriptableCullingParameters cullingParameters, ref CameraData cameraData)
    {
        var cam = cameraData.camera.name;
        Debug.Log("ScriptableRenderer - SetupCullingParameters() - "+"<color=yellow>"+name+" - "+cam+"</color>");
    }
    
    public override void FinishRendering(CommandBuffer cmd)
    {
        Debug.Log("ScriptableRenderPass - FinishRendering() - "+"<color=yellow>"+name+"</color>");
    }
    
    public override void OnBeginRenderGraphFrame()
    {
        Debug.Log("ScriptableRenderPass - OnBeginRenderGraphFrame() - "+"<color=yellow>"+name+"</color>");
    }
    
    public override void OnEndRenderGraphFrame()
    {
        Debug.Log("ScriptableRenderPass - OnEndRenderGraphFrame() - "+"<color=yellow>"+name+"</color>");
    }
}

internal class CustomRendererData : ScriptableRendererData
{
    protected override ScriptableRenderer Create()
    {
        return new CustomRenderer(this);
    }
    
#if UNITY_EDITOR //from UniversalRendererData.cs
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812")]
    internal class CreateCustomRendererAsset : EndNameEditAction
    {
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            var instance = CreateRendererAsset(pathName, RendererType.UniversalRenderer, false) as CustomRendererData;
            Selection.activeObject = instance;
        }
    }

    [MenuItem("Assets/Create/Rendering/Custom Renderer", priority = CoreUtils.Sections.section3 + CoreUtils.Priorities.assetsCreateRenderingMenuPriority + 2)]
    static void CreateCustomRendererData()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, CreateInstance<CreateCustomRendererAsset>(), "New Custom Renderer Data.asset", null, null);
    }
    
    internal static ScriptableRendererData CreateRendererAsset(string path, RendererType type, bool relativePath = true, string suffix = "Renderer")
    {
        ScriptableRendererData data = CreateInstance<CustomRendererData>();
        string dataPath;
        if (relativePath)
            dataPath =
                $"{Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path))}_{suffix}{Path.GetExtension(path)}";
        else
            dataPath = path;
        AssetDatabase.CreateAsset(data, dataPath);
        //ResourceReloader.ReloadAllNullIn(data, packagePath);
        return data;
    }
#endif
}

