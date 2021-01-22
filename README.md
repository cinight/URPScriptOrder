# URPScriptOrder

Unity 2020.2.2f1 + URP 10.2.2

### Playmode:

After hitting play, these are called in this order:

- ScriptableRendererFeature - Dispose()
- ScriptableRendererFeature - Constructor
- ScriptableRendererFeature - Create() * 3

And then every frame:

- RenderPipelineManager - OnBeginFrameRendering()
- RenderPipelineManager - OnBeginCameraRendering()
- ~Renderer - MonoBehaviour - OnBecameVisible()~ Only once
- Renderer - MonoBehaviour - OnWillRenderObject()
- ScriptableRendererFeature - AddRenderPasses()
- ScriptableRenderPass - Constructor
- ScriptableRenderPass - Execute()
- Object - MonoBehaviour - OnRenderObject()
- RenderPipelineManager - OnEndCameraRendering()
- RenderPipelineManager - OnEndFrameRendering()

### Editmode:

After exiting play, these are called in this order:

- Renderer - MonoBehaviour - OnBecameInvisible()
- ScriptableRendererFeature - Dispose()
- ScriptableRendererFeature - Create()

And then every frame:

- ScriptableRendererFeature - AddRenderPasses()
- ScriptableRenderPass - Constructor
- ScriptableRenderPass - Execute
