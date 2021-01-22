# URPScriptOrder

Unity 2020.2.2f1 + URP 10.2.2

### Playmode:

After hitting play, these are called in this order:

- ScriptableRendererFeature - Dispose()
- ScriptableRendererFeature - Constructor
- ScriptableRendererFeature - Create() * 3 <--- _This happens in parallel of below MonoBehaviour events_
- Object - MonoBehaviour - Awake()
- Object - MonoBehaviour - OnEnable()
- Object - MonoBehaviour - Start()

And then every frame:

- Object - MonoBehaviour - Update()
- Object - MonoBehaviour - LateUpdate()
- RenderPipelineManager - OnBeginFrameRendering()
- RenderPipelineManager - OnBeginCameraRendering()
- Renderer - MonoBehaviour - OnBecameVisible()  <--- _Only once_
- Renderer - MonoBehaviour - OnWillRenderObject()
- ScriptableRendererFeature - AddRenderPasses()
- ScriptableRenderPass - Constructor
- ScriptableRenderPass - Execute()
- Object - MonoBehaviour - OnRenderObject()
- RenderPipelineManager - OnEndCameraRendering()
- RenderPipelineManager - OnEndFrameRendering()

### Editmode:

After exiting play, these are called in this order:

- Object - MonoBehaviour - OnDisable()
- Object - MonoBehaviour - OnDestroy()
- Renderer - MonoBehaviour - OnBecameInvisible()
- ScriptableRendererFeature - Dispose()
- ScriptableRendererFeature - Create()

And then every frame:

- ScriptableRendererFeature - AddRenderPasses()
- ScriptableRenderPass - Constructor
- ScriptableRenderPass - Execute()
