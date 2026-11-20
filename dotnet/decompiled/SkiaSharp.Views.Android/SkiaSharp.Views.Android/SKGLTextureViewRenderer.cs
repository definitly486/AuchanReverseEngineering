using Android.Opengl;
using Java.Lang;
using Javax.Microedition.Khronos.Egl;
using Javax.Microedition.Khronos.Opengles;

namespace SkiaSharp.Views.Android;

public abstract class SKGLTextureViewRenderer : Object, GLTextureView.IRenderer
{
	private GRContext context;

	private GRGlFramebufferInfo glInfo;

	private GRBackendRenderTarget renderTarget;

	private SKSurface surface;

	private SKCanvas canvas;

	private SKSizeI lastSize;

	private SKSizeI newSize;

	public SKSize CanvasSize => lastSize;

	public GRContext GRContext => context;

	protected virtual void OnPaintSurface(SKPaintGLSurfaceEventArgs e)
	{
	}

	public void OnDrawFrame(IGL10 gl)
	{
		GLES10.GlClear(17664);
		if (context == null)
		{
			GRGlInterface backendContext = GRGlInterface.Create();
			context = GRContext.CreateGl(backendContext);
		}
		if (renderTarget == null || lastSize != newSize || !renderTarget.IsValid)
		{
			lastSize = newSize;
			int[] array = new int[3];
			GLES20.GlGetIntegerv(36006, array, 0);
			GLES20.GlGetIntegerv(3415, array, 1);
			GLES20.GlGetIntegerv(32937, array, 2);
			int num = array[2];
			int maxSurfaceSampleCount = context.GetMaxSurfaceSampleCount(SKColorType.Rgba8888);
			if (num > maxSurfaceSampleCount)
			{
				num = maxSurfaceSampleCount;
			}
			glInfo = new GRGlFramebufferInfo((uint)array[0], SKColorType.Rgba8888.ToGlSizedFormat());
			surface?.Dispose();
			surface = null;
			canvas = null;
			renderTarget?.Dispose();
			renderTarget = new GRBackendRenderTarget(newSize.Width, newSize.Height, num, array[1], glInfo);
		}
		if (surface == null)
		{
			surface = SKSurface.Create(context, renderTarget, GRSurfaceOrigin.BottomLeft, SKColorType.Rgba8888);
			canvas = surface.Canvas;
		}
		using (new SKAutoCanvasRestore(canvas, doSave: true))
		{
			SKPaintGLSurfaceEventArgs e = new SKPaintGLSurfaceEventArgs(surface, renderTarget, GRSurfaceOrigin.BottomLeft, SKColorType.Rgba8888);
			OnPaintSurface(e);
		}
		canvas.Flush();
		context.Flush();
	}

	public void OnSurfaceChanged(IGL10 gl, int width, int height)
	{
		GLES20.GlViewport(0, 0, width, height);
		newSize = new SKSizeI(width, height);
	}

	public void OnSurfaceCreated(IGL10 gl, EGLConfig config)
	{
		FreeContext();
	}

	public void OnSurfaceDestroyed()
	{
		FreeContext();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			FreeContext();
		}
		base.Dispose(disposing);
	}

	private void FreeContext()
	{
		surface?.Dispose();
		surface = null;
		renderTarget?.Dispose();
		renderTarget = null;
		context?.Dispose();
		context = null;
	}
}
