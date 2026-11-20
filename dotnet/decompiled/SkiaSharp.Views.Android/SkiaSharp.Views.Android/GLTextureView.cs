using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Opengl;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Javax.Microedition.Khronos.Egl;
using Javax.Microedition.Khronos.Opengles;

namespace SkiaSharp.Views.Android;

public class GLTextureView : TextureView, TextureView.ISurfaceTextureListener, IJavaObject, IDisposable, IJavaPeerable, View.IOnLayoutChangeListener
{
	public interface IGLWrapper
	{
		IGL Wrap(IGL gl);
	}

	public interface IEGLConfigChooser
	{
		EGLConfig ChooseConfig(IEGL10 egl, EGLDisplay display);
	}

	public interface IEGLContextFactory
	{
		EGLContext CreateContext(IEGL10 egl, EGLDisplay display, EGLConfig eglConfig);

		void DestroyContext(IEGL10 egl, EGLDisplay display, EGLContext context);
	}

	public interface IEGLWindowSurfaceFactory
	{
		EGLSurface CreateWindowSurface(IEGL10 egl, EGLDisplay display, EGLConfig config, Java.Lang.Object nativeWindow);

		void DestroySurface(IEGL10 egl, EGLDisplay display, EGLSurface surface);
	}

	public interface IRenderer
	{
		void OnDrawFrame(IGL10 gl);

		void OnSurfaceChanged(IGL10 gl, int width, int height);

		void OnSurfaceCreated(IGL10 gl, EGLConfig config);

		void OnSurfaceDestroyed();
	}

	private class DefaultContextFactory : IEGLContextFactory
	{
		private GLTextureView textureView;

		public DefaultContextFactory(GLTextureView textureView)
		{
			this.textureView = textureView;
		}

		public EGLContext CreateContext(IEGL10 egl, EGLDisplay display, EGLConfig config)
		{
			int[] array = new int[3] { 12440, textureView.eglContextClientVersion, 12344 };
			return egl.EglCreateContext(display, config, EGL10.EglNoContext, (textureView.eglContextClientVersion != 0) ? array : null);
		}

		public void DestroyContext(IEGL10 egl, EGLDisplay display, EGLContext context)
		{
			if (!egl.EglDestroyContext(display, context))
			{
				int value = egl.EglGetError();
				throw new System.Exception($"eglDestroyContext failed: {value}");
			}
		}
	}

	private class DefaultWindowSurfaceFactory : IEGLWindowSurfaceFactory
	{
		public EGLSurface CreateWindowSurface(IEGL10 egl, EGLDisplay display, EGLConfig config, Java.Lang.Object nativeWindow)
		{
			EGLSurface result = null;
			try
			{
				result = egl.EglCreateWindowSurface(display, config, nativeWindow, null);
			}
			catch (System.Exception)
			{
			}
			return result;
		}

		public void DestroySurface(IEGL10 egl, EGLDisplay display, EGLSurface surface)
		{
			egl.EglDestroySurface(display, surface);
		}
	}

	private abstract class BaseConfigChooser : IEGLConfigChooser
	{
		private GLTextureView textureView;

		private int[] configSpec;

		public BaseConfigChooser(GLTextureView textureView, int[] configSpec)
		{
			this.textureView = textureView;
			this.configSpec = FilterConfigSpec(configSpec);
		}

		public EGLConfig ChooseConfig(IEGL10 egl, EGLDisplay display)
		{
			int[] array = new int[1];
			if (!egl.EglChooseConfig(display, configSpec, null, 0, array))
			{
				throw new System.Exception("eglChooseConfig failed");
			}
			int num = array[0];
			if (num <= 0)
			{
				throw new System.Exception("No configs match configSpec");
			}
			EGLConfig[] configs = new EGLConfig[num];
			if (!egl.EglChooseConfig(display, configSpec, configs, num, array))
			{
				throw new System.Exception("eglChooseConfig#2 failed");
			}
			EGLConfig eGLConfig = ChooseConfig(egl, display, configs);
			if (eGLConfig == null)
			{
				throw new System.Exception("No config chosen");
			}
			return eGLConfig;
		}

		public abstract EGLConfig ChooseConfig(IEGL10 egl, EGLDisplay display, EGLConfig[] configs);

		private int[] FilterConfigSpec(int[] spec)
		{
			if (textureView.eglContextClientVersion != 2)
			{
				return spec;
			}
			int num = spec.Length;
			int[] array = new int[num + 2];
			Array.Copy(spec, 0, array, 0, num - 1);
			array[num - 1] = 12352;
			array[num] = 4;
			array[num + 1] = 12344;
			return array;
		}
	}

	private class ComponentSizeChooser : BaseConfigChooser
	{
		private int[] value;

		private int redSize;

		private int greenSize;

		private int blueSize;

		private int alphaSize;

		private int depthSize;

		private int stencilSize;

		public ComponentSizeChooser(GLTextureView textureView, int redSize, int greenSize, int blueSize, int alphaSize, int depthSize, int stencilSize)
		{
			int[] obj = new int[13]
			{
				12324, 0, 12323, 0, 12322, 0, 12321, 0, 12325, 0,
				12326, 0, 12344
			};
			obj[1] = redSize;
			obj[3] = greenSize;
			obj[5] = blueSize;
			obj[7] = alphaSize;
			obj[9] = depthSize;
			obj[11] = stencilSize;
			base._002Ector(textureView, obj);
			value = new int[1];
			this.redSize = redSize;
			this.greenSize = greenSize;
			this.blueSize = blueSize;
			this.alphaSize = alphaSize;
			this.depthSize = depthSize;
			this.stencilSize = stencilSize;
		}

		public override EGLConfig ChooseConfig(IEGL10 egl, EGLDisplay display, EGLConfig[] configs)
		{
			foreach (EGLConfig eGLConfig in configs)
			{
				int num = FindConfigAttrib(egl, display, eGLConfig, 12325, 0);
				int num2 = FindConfigAttrib(egl, display, eGLConfig, 12326, 0);
				if (num >= depthSize && num2 >= stencilSize)
				{
					int num3 = FindConfigAttrib(egl, display, eGLConfig, 12324, 0);
					int num4 = FindConfigAttrib(egl, display, eGLConfig, 12323, 0);
					int num5 = FindConfigAttrib(egl, display, eGLConfig, 12322, 0);
					int num6 = FindConfigAttrib(egl, display, eGLConfig, 12321, 0);
					if (num3 == redSize && num4 == greenSize && num5 == blueSize && num6 == alphaSize)
					{
						return eGLConfig;
					}
				}
			}
			return null;
		}

		private int FindConfigAttrib(IEGL10 egl, EGLDisplay display, EGLConfig config, int attribute, int defaultValue)
		{
			if (egl.EglGetConfigAttrib(display, config, attribute, value))
			{
				return value[0];
			}
			return defaultValue;
		}
	}

	private class SimpleEGLConfigChooser : ComponentSizeChooser
	{
		public SimpleEGLConfigChooser(GLTextureView textureView, bool withDepthBuffer)
			: base(textureView, 8, 8, 8, 0, withDepthBuffer ? 16 : 0, 0)
		{
		}
	}

	private class EglHelper
	{
		private WeakReference<GLTextureView> textureViewWeakRef;

		private IEGL10 egl;

		private EGLDisplay eglDisplay;

		private EGLSurface eglSurface;

		private EGLContext eglContext;

		private EGLConfig eglConfig;

		public EGLConfig EglConfig => eglConfig;

		public EglHelper(WeakReference<GLTextureView> glTextureViewWeakRef)
		{
			textureViewWeakRef = glTextureViewWeakRef;
		}

		public void Start()
		{
			egl = Extensions.JavaCast<IEGL10>(EGLContext.EGL);
			eglDisplay = egl.EglGetDisplay(EGL10.EglDefaultDisplay);
			if (eglDisplay == EGL10.EglNoDisplay)
			{
				throw new System.Exception("eglGetDisplay failed");
			}
			int[] major_minor = new int[2];
			if (!egl.EglInitialize(eglDisplay, major_minor))
			{
				throw new System.Exception("eglInitialize failed");
			}
			if (!textureViewWeakRef.TryGetTarget(out var target))
			{
				eglConfig = null;
				eglContext = null;
			}
			else
			{
				eglConfig = target.eglConfigChooser.ChooseConfig(egl, eglDisplay);
				eglContext = target.eglContextFactory.CreateContext(egl, eglDisplay, eglConfig);
			}
			if (eglContext == null || eglContext == EGL10.EglNoContext)
			{
				eglContext = null;
				int value = egl.EglGetError();
				throw new System.Exception($"createContext failed: {value}");
			}
			eglSurface = null;
		}

		public bool CreateSurface()
		{
			if (egl == null)
			{
				throw new System.Exception("egl not initialized");
			}
			if (eglDisplay == null)
			{
				throw new System.Exception("eglDisplay not initialized");
			}
			if (eglConfig == null)
			{
				throw new System.Exception("mEglConfig not initialized");
			}
			DestroySurfaceImpl();
			if (textureViewWeakRef.TryGetTarget(out var target))
			{
				eglSurface = target.eglWindowSurfaceFactory.CreateWindowSurface(egl, eglDisplay, eglConfig, target.SurfaceTexture);
			}
			else
			{
				eglSurface = null;
			}
			if (eglSurface == null || eglSurface == EGL10.EglNoSurface)
			{
				int num = egl.EglGetError();
				_ = 12299;
				return false;
			}
			if (!egl.EglMakeCurrent(eglDisplay, eglSurface, eglSurface, eglContext))
			{
				return false;
			}
			return true;
		}

		public IGL CreateGL()
		{
			IGL iGL = eglContext.GL;
			if (textureViewWeakRef.TryGetTarget(out var target))
			{
				if (target.glWrapper != null)
				{
					iGL = target.glWrapper.Wrap(iGL);
				}
				if (target.DebugFlags.HasFlag(DebugFlags.CheckGlError | DebugFlags.LogGlCalls))
				{
					int num = 0;
					Writer log = null;
					if (target.DebugFlags.HasFlag(DebugFlags.CheckGlError))
					{
						num |= 1;
					}
					if (target.DebugFlags.HasFlag(DebugFlags.LogGlCalls))
					{
						log = new LogWriter();
					}
					iGL = GLDebugHelper.Wrap(iGL, num, log);
				}
			}
			return iGL;
		}

		public int Swap()
		{
			if (!egl.EglSwapBuffers(eglDisplay, eglSurface))
			{
				return egl.EglGetError();
			}
			return 12288;
		}

		public void DestroySurface()
		{
			if (textureViewWeakRef.TryGetTarget(out var target))
			{
				target.renderer.OnSurfaceDestroyed();
			}
			DestroySurfaceImpl();
		}

		private void DestroySurfaceImpl()
		{
			if (eglSurface != null && eglSurface != EGL10.EglNoSurface)
			{
				egl.EglMakeCurrent(eglDisplay, EGL10.EglNoSurface, EGL10.EglNoSurface, EGL10.EglNoContext);
				if (textureViewWeakRef.TryGetTarget(out var target))
				{
					target.eglWindowSurfaceFactory.DestroySurface(egl, eglDisplay, eglSurface);
				}
				eglSurface = null;
			}
		}

		public void Finish()
		{
			if (eglContext != null)
			{
				if (textureViewWeakRef.TryGetTarget(out var target))
				{
					target.eglContextFactory.DestroyContext(egl, eglDisplay, eglContext);
				}
				eglContext = null;
			}
			if (eglDisplay != null)
			{
				egl.EglTerminate(eglDisplay);
				eglDisplay = null;
			}
		}
	}

	private class GLThread
	{
		private System.Threading.Thread thread;

		private GLThreadManager threadManager;

		private EglHelper eglHelper;

		private WeakReference<GLTextureView> textureViewWeakRef;

		private bool shouldExit;

		public bool exited;

		private bool requestPaused;

		private bool paused;

		private bool hasSurface;

		private bool surfaceIsBad;

		private bool waitingForSurface;

		private bool haveEglContext;

		private bool haveEglSurface;

		private bool finishedCreatingEglSurface;

		private bool shouldReleaseEglContext;

		private int width;

		private int height;

		private Rendermode renderMode;

		private bool requestRender;

		private bool renderComplete;

		private Queue<IRunnable> eventQueue = new Queue<IRunnable>();

		private bool surfaceSizeChanged = true;

		public GLThread(WeakReference<GLTextureView> glTextureViewWeakRef)
		{
			threadManager = new GLThreadManager();
			width = 0;
			height = 0;
			requestRender = true;
			renderMode = Rendermode.Continuously;
			textureViewWeakRef = glTextureViewWeakRef;
			thread = new System.Threading.Thread(Run);
		}

		public void Start()
		{
			thread.Start();
		}

		public void Run()
		{
			thread.Name = "GLThread " + thread.ManagedThreadId;
			try
			{
				GuardedRun();
			}
			finally
			{
				threadManager.ThreadExiting(this);
			}
		}

		private void StopEglSurfaceLocked()
		{
			if (haveEglSurface)
			{
				haveEglSurface = false;
				eglHelper.DestroySurface();
			}
		}

		private void StopEglContextLocked()
		{
			if (haveEglContext)
			{
				eglHelper.Finish();
				haveEglContext = false;
				threadManager.ReleaseEglContextLocked(this);
			}
		}

		private void GuardedRun()
		{
			eglHelper = new EglHelper(textureViewWeakRef);
			haveEglContext = false;
			haveEglSurface = false;
			try
			{
				IGL10 gl = null;
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				bool flag8 = false;
				int num = 0;
				int num2 = 0;
				IRunnable runnable = null;
				while (true)
				{
					lock (threadManager)
					{
						while (true)
						{
							if (shouldExit)
							{
								return;
							}
							if (eventQueue.Count > 0)
							{
								runnable = eventQueue.Dequeue();
								break;
							}
							bool flag9 = false;
							if (paused != requestPaused)
							{
								flag9 = requestPaused;
								paused = requestPaused;
								Monitor.PulseAll(threadManager);
							}
							if (shouldReleaseEglContext)
							{
								StopEglSurfaceLocked();
								StopEglContextLocked();
								shouldReleaseEglContext = false;
								flag8 = true;
							}
							if (flag4)
							{
								StopEglSurfaceLocked();
								StopEglContextLocked();
								flag4 = false;
							}
							if (flag9 && haveEglSurface)
							{
								StopEglSurfaceLocked();
							}
							if (flag9 && haveEglContext)
							{
								textureViewWeakRef.TryGetTarget(out var target);
								if (target == null || !target.PreserveEGLContextOnPause || threadManager.ShouldReleaseEGLContextWhenPausing())
								{
									StopEglContextLocked();
								}
							}
							if (flag9 && threadManager.ShouldTerminateEGLWhenPausing())
							{
								eglHelper.Finish();
							}
							if (!hasSurface && !waitingForSurface)
							{
								if (haveEglSurface)
								{
									StopEglSurfaceLocked();
								}
								waitingForSurface = true;
								surfaceIsBad = false;
								Monitor.PulseAll(threadManager);
							}
							if (hasSurface && waitingForSurface)
							{
								waitingForSurface = false;
								Monitor.PulseAll(threadManager);
							}
							if (flag7)
							{
								flag6 = false;
								flag7 = false;
								renderComplete = true;
								Monitor.PulseAll(threadManager);
							}
							if (IsReadyToDraw())
							{
								if (!haveEglContext)
								{
									if (flag8)
									{
										flag8 = false;
									}
									else if (threadManager.TryAcquireEglContextLocked(this))
									{
										try
										{
											eglHelper.Start();
										}
										catch (System.Exception)
										{
											threadManager.ReleaseEglContextLocked(this);
											throw;
										}
										haveEglContext = true;
										flag = true;
										Monitor.PulseAll(threadManager);
									}
								}
								if (haveEglContext && !haveEglSurface)
								{
									haveEglSurface = true;
									flag2 = true;
									flag3 = true;
									flag5 = true;
								}
								if (haveEglSurface)
								{
									if (surfaceSizeChanged)
									{
										flag5 = true;
										num = width;
										num2 = height;
										flag6 = true;
										flag2 = true;
										surfaceSizeChanged = false;
									}
									requestRender = false;
									Monitor.PulseAll(threadManager);
									break;
								}
							}
							Monitor.Wait(threadManager);
						}
					}
					if (runnable != null)
					{
						runnable.Run();
						runnable = null;
						continue;
					}
					if (flag2)
					{
						if (!eglHelper.CreateSurface())
						{
							lock (threadManager)
							{
								finishedCreatingEglSurface = true;
								surfaceIsBad = true;
								Monitor.PulseAll(threadManager);
							}
							continue;
						}
						lock (threadManager)
						{
							finishedCreatingEglSurface = true;
							Monitor.PulseAll(threadManager);
						}
						flag2 = false;
					}
					if (flag3)
					{
						gl = Extensions.JavaCast<IGL10>(eglHelper.CreateGL());
						threadManager.CheckGLDriver(gl);
						flag3 = false;
					}
					if (flag)
					{
						if (textureViewWeakRef.TryGetTarget(out var target2))
						{
							target2.renderer.OnSurfaceCreated(gl, eglHelper.EglConfig);
						}
						flag = false;
					}
					if (flag5)
					{
						if (textureViewWeakRef.TryGetTarget(out var target3))
						{
							target3.renderer.OnSurfaceChanged(gl, num, num2);
						}
						flag5 = false;
					}
					if (textureViewWeakRef.TryGetTarget(out var target4))
					{
						target4.renderer.OnDrawFrame(gl);
					}
					switch (eglHelper.Swap())
					{
					case 12302:
						flag4 = true;
						break;
					default:
						lock (threadManager)
						{
							surfaceIsBad = true;
							Monitor.PulseAll(threadManager);
						}
						break;
					case 12288:
						break;
					}
					if (flag6)
					{
						flag7 = true;
					}
				}
			}
			finally
			{
				lock (threadManager)
				{
					StopEglSurfaceLocked();
					StopEglContextLocked();
				}
			}
		}

		public bool IsAbleToDraw()
		{
			if (haveEglContext && haveEglSurface)
			{
				return IsReadyToDraw();
			}
			return false;
		}

		private bool IsReadyToDraw()
		{
			if (!paused && hasSurface && !surfaceIsBad && width > 0 && height > 0)
			{
				if (!requestRender)
				{
					return renderMode == Rendermode.Continuously;
				}
				return true;
			}
			return false;
		}

		public void SetRenderMode(Rendermode mode)
		{
			lock (threadManager)
			{
				renderMode = mode;
				Monitor.PulseAll(threadManager);
			}
		}

		public Rendermode GetRenderMode()
		{
			lock (threadManager)
			{
				return renderMode;
			}
		}

		public void RequestRender()
		{
			lock (threadManager)
			{
				requestRender = true;
				Monitor.PulseAll(threadManager);
			}
		}

		public void OnSurfaceCreated()
		{
			lock (threadManager)
			{
				hasSurface = true;
				finishedCreatingEglSurface = false;
				Monitor.PulseAll(threadManager);
				while (waitingForSurface && !finishedCreatingEglSurface && !exited)
				{
					try
					{
						Monitor.Wait(threadManager);
					}
					catch (System.Exception)
					{
						System.Threading.Thread.CurrentThread.Interrupt();
					}
				}
			}
		}

		public void OnSurfaceDestroyed()
		{
			lock (threadManager)
			{
				hasSurface = false;
				Monitor.PulseAll(threadManager);
				while (!waitingForSurface && !exited)
				{
					try
					{
						Monitor.Wait(threadManager);
					}
					catch (System.Exception)
					{
						System.Threading.Thread.CurrentThread.Interrupt();
					}
				}
			}
		}

		public void OnPause()
		{
			lock (threadManager)
			{
				requestPaused = true;
				Monitor.PulseAll(threadManager);
				while (!exited && !paused)
				{
					try
					{
						Monitor.Wait(threadManager);
					}
					catch (System.Exception)
					{
						System.Threading.Thread.CurrentThread.Interrupt();
					}
				}
			}
		}

		public void OnResume()
		{
			lock (threadManager)
			{
				requestPaused = false;
				requestRender = true;
				renderComplete = false;
				Monitor.PulseAll(threadManager);
				while (!exited && paused && !renderComplete)
				{
					try
					{
						Monitor.Wait(threadManager);
					}
					catch (System.Exception)
					{
						System.Threading.Thread.CurrentThread.Interrupt();
					}
				}
			}
		}

		public void OnWindowResize(int w, int h)
		{
			lock (threadManager)
			{
				width = w;
				height = h;
				surfaceSizeChanged = true;
				requestRender = true;
				renderComplete = false;
				Monitor.PulseAll(threadManager);
				while (!exited && !paused && !renderComplete && IsAbleToDraw())
				{
					try
					{
						Monitor.Wait(threadManager);
					}
					catch (System.Exception)
					{
						System.Threading.Thread.CurrentThread.Interrupt();
					}
				}
			}
		}

		public void RequestExitAndWait()
		{
			lock (threadManager)
			{
				shouldExit = true;
				Monitor.PulseAll(threadManager);
				while (!exited)
				{
					try
					{
						Monitor.Wait(threadManager);
					}
					catch (System.Exception)
					{
						System.Threading.Thread.CurrentThread.Interrupt();
					}
				}
			}
		}

		public void RequestReleaseEglContextLocked()
		{
			shouldReleaseEglContext = true;
			Monitor.PulseAll(threadManager);
		}

		public void QueueEvent(IRunnable r)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			lock (threadManager)
			{
				eventQueue.Enqueue(r);
				Monitor.PulseAll(threadManager);
			}
		}
	}

	private class LogWriter : Writer
	{
		private StringBuilder builder = new StringBuilder();

		public override void Close()
		{
			FlushBuilder();
		}

		public override void Flush()
		{
			FlushBuilder();
		}

		public override void Write(char[] buf, int offset, int count)
		{
			for (int i = 0; i < count; i++)
			{
				char c = buf[offset + i];
				if (c == '\n')
				{
					FlushBuilder();
				}
				else
				{
					builder.Append(c);
				}
			}
		}

		private void FlushBuilder()
		{
			if (builder.Length() > 0)
			{
				builder.Delete(0, builder.Length());
			}
		}
	}

	private class GLThreadManager
	{
		private bool glesVersionCheckComplete;

		private int glesVersion;

		private bool glesDriverCheckComplete;

		private bool multipleGLESContextsAllowed;

		private bool limitedGLESContexts;

		private GLThread eglOwner;

		public void ThreadExiting(GLThread thread)
		{
			lock (this)
			{
				thread.exited = true;
				if (eglOwner == thread)
				{
					eglOwner = null;
				}
				Monitor.PulseAll(this);
			}
		}

		public bool TryAcquireEglContextLocked(GLThread thread)
		{
			if (eglOwner == thread || eglOwner == null)
			{
				eglOwner = thread;
				Monitor.PulseAll(this);
				return true;
			}
			CheckGLESVersion();
			if (multipleGLESContextsAllowed)
			{
				return true;
			}
			if (eglOwner != null)
			{
				eglOwner.RequestReleaseEglContextLocked();
			}
			return false;
		}

		public void ReleaseEglContextLocked(GLThread thread)
		{
			if (eglOwner == thread)
			{
				eglOwner = null;
			}
			Monitor.PulseAll(this);
		}

		public bool ShouldReleaseEGLContextWhenPausing()
		{
			lock (this)
			{
				return limitedGLESContexts;
			}
		}

		public bool ShouldTerminateEGLWhenPausing()
		{
			lock (this)
			{
				CheckGLESVersion();
				return !multipleGLESContextsAllowed;
			}
		}

		public void CheckGLDriver(IGL10 gl)
		{
			lock (this)
			{
				if (!glesDriverCheckComplete)
				{
					CheckGLESVersion();
					string text = gl.GlGetString(7937);
					if (glesVersion < 131072)
					{
						multipleGLESContextsAllowed = !text.StartsWith("Q3Dimension MSM7500 ");
						Monitor.PulseAll(this);
					}
					limitedGLESContexts = !multipleGLESContextsAllowed;
					glesDriverCheckComplete = true;
				}
			}
		}

		private void CheckGLESVersion()
		{
			if (!glesVersionCheckComplete)
			{
				ActivityManager activityManager = ActivityManager.FromContext(Application.Context);
				ConfigurationInfo deviceConfigurationInfo = activityManager.DeviceConfigurationInfo;
				if (deviceConfigurationInfo.ReqGlEsVersion != 0)
				{
					glesVersion = deviceConfigurationInfo.ReqGlEsVersion;
				}
				else
				{
					glesVersion = 65536;
				}
				if (glesVersion >= 131072)
				{
					multipleGLESContextsAllowed = true;
				}
				glesVersionCheckComplete = true;
			}
		}
	}

	internal static bool EnableLogging;

	private WeakReference<GLTextureView> thisWeakRef;

	private GLThread glThread;

	private IRenderer renderer;

	private bool detachedFromWindow;

	private IEGLConfigChooser eglConfigChooser;

	private IEGLContextFactory eglContextFactory;

	private IEGLWindowSurfaceFactory eglWindowSurfaceFactory;

	private IGLWrapper glWrapper;

	private int eglContextClientVersion;

	public bool PreserveEGLContextOnPause { get; set; }

	public DebugFlags DebugFlags { get; set; }

	public Rendermode RenderMode
	{
		get
		{
			return glThread.GetRenderMode();
		}
		set
		{
			glThread.SetRenderMode(value);
		}
	}

	public GLTextureView(Context context)
		: base(context)
	{
		Initialize();
	}

	public GLTextureView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize();
	}

	private void Initialize()
	{
		thisWeakRef = new WeakReference<GLTextureView>(this);
		SurfaceTextureListener = this;
		AddOnLayoutChangeListener(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && glThread != null)
		{
			glThread.RequestExitAndWait();
		}
		base.Dispose(disposing);
	}

	public void SetGLWrapper(IGLWrapper glWrapper)
	{
		this.glWrapper = glWrapper;
	}

	public void SetRenderer(IRenderer renderer)
	{
		CheckRenderThreadState();
		if (eglConfigChooser == null)
		{
			eglConfigChooser = new SimpleEGLConfigChooser(this, withDepthBuffer: true);
		}
		if (eglContextFactory == null)
		{
			eglContextFactory = new DefaultContextFactory(this);
		}
		if (eglWindowSurfaceFactory == null)
		{
			eglWindowSurfaceFactory = new DefaultWindowSurfaceFactory();
		}
		this.renderer = renderer;
		glThread = new GLThread(thisWeakRef);
		glThread.Start();
	}

	public void SetEGLContextFactory(IEGLContextFactory factory)
	{
		CheckRenderThreadState();
		eglContextFactory = factory;
	}

	public void SetEGLWindowSurfaceFactory(IEGLWindowSurfaceFactory factory)
	{
		CheckRenderThreadState();
		eglWindowSurfaceFactory = factory;
	}

	public void SetEGLConfigChooser(IEGLConfigChooser configChooser)
	{
		CheckRenderThreadState();
		eglConfigChooser = configChooser;
	}

	public void SetEGLConfigChooser(bool needDepth)
	{
		SetEGLConfigChooser(new SimpleEGLConfigChooser(this, needDepth));
	}

	public void SetEGLConfigChooser(int redSize, int greenSize, int blueSize, int alphaSize, int depthSize, int stencilSize)
	{
		SetEGLConfigChooser(new ComponentSizeChooser(this, redSize, greenSize, blueSize, alphaSize, depthSize, stencilSize));
	}

	public void SetEGLContextClientVersion(int version)
	{
		CheckRenderThreadState();
		eglContextClientVersion = version;
	}

	public void RequestRender()
	{
		glThread.RequestRender();
	}

	public void OnSurfaceTextureUpdated(SurfaceTexture surface)
	{
	}

	public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
	{
		glThread.OnSurfaceCreated();
		glThread.RequestRender();
	}

	public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
	{
		glThread.OnSurfaceDestroyed();
		return true;
	}

	public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int w, int h)
	{
		glThread.OnWindowResize(w, h);
	}

	public void OnPause()
	{
		glThread.OnPause();
	}

	public void OnResume()
	{
		glThread.OnResume();
	}

	public void QueueEvent(Action r)
	{
		QueueEvent(new Runnable(r));
	}

	public void QueueEvent(IRunnable r)
	{
		glThread.QueueEvent(r);
	}

	protected override void OnAttachedToWindow()
	{
		base.OnAttachedToWindow();
		if (detachedFromWindow && renderer != null)
		{
			Rendermode rendermode = Rendermode.Continuously;
			if (glThread != null)
			{
				rendermode = glThread.GetRenderMode();
			}
			glThread = new GLThread(thisWeakRef);
			if (rendermode != Rendermode.Continuously)
			{
				glThread.SetRenderMode(rendermode);
			}
			glThread.Start();
		}
		detachedFromWindow = false;
	}

	protected override void OnDetachedFromWindow()
	{
		if (glThread != null)
		{
			glThread.RequestExitAndWait();
		}
		detachedFromWindow = true;
		base.OnDetachedFromWindow();
	}

	private void CheckRenderThreadState()
	{
		if (glThread != null)
		{
			throw new System.Exception("setRenderer has already been called for this instance.");
		}
	}

	public void OnLayoutChange(View v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
	{
		OnSurfaceTextureSizeChanged(SurfaceTexture, right - left, bottom - top);
	}

	[Conditional("DEBUG")]
	private static void LogDebug(string message)
	{
		if (EnableLogging)
		{
			Log.Debug("GLTextureView", message);
		}
	}

	[Conditional("DEBUG")]
	private static void LogError(string message)
	{
		Log.Error("GLTextureView", message);
	}
}
