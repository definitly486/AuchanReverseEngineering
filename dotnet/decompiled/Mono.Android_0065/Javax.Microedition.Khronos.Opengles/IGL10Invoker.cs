using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Nio;

namespace Javax.Microedition.Khronos.Opengles;

[Register("javax/microedition/khronos/opengles/GL10", DoNotGenerateAcw = true)]
internal class IGL10Invoker : Java.Lang.Object, IGL10, IGL, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_javax_microedition_khronos_opengles_GL = new XAPeerMembers("javax/microedition/khronos/opengles/GL", typeof(IGL10Invoker));

	private static readonly JniPeerMembers _members_javax_microedition_khronos_opengles_GL10 = new XAPeerMembers("javax/microedition/khronos/opengles/GL10", typeof(IGL10Invoker));

	private static Delegate? cb_glActiveTexture_GlActiveTexture_I_V;

	private static Delegate? cb_glAlphaFunc_GlAlphaFunc_IF_V;

	private static Delegate? cb_glAlphaFuncx_GlAlphaFuncx_II_V;

	private static Delegate? cb_glBindTexture_GlBindTexture_II_V;

	private static Delegate? cb_glBlendFunc_GlBlendFunc_II_V;

	private static Delegate? cb_glClear_GlClear_I_V;

	private static Delegate? cb_glClearColor_GlClearColor_FFFF_V;

	private static Delegate? cb_glClearColorx_GlClearColorx_IIII_V;

	private static Delegate? cb_glClearDepthf_GlClearDepthf_F_V;

	private static Delegate? cb_glClearDepthx_GlClearDepthx_I_V;

	private static Delegate? cb_glClearStencil_GlClearStencil_I_V;

	private static Delegate? cb_glClientActiveTexture_GlClientActiveTexture_I_V;

	private static Delegate? cb_glColor4f_GlColor4f_FFFF_V;

	private static Delegate? cb_glColor4x_GlColor4x_IIII_V;

	private static Delegate? cb_glColorMask_GlColorMask_ZZZZ_V;

	private static Delegate? cb_glColorPointer_GlColorPointer_IIILjava_nio_Buffer__V;

	private static Delegate? cb_glCompressedTexImage2D_GlCompressedTexImage2D_IIIIIIILjava_nio_Buffer__V;

	private static Delegate? cb_glCompressedTexSubImage2D_GlCompressedTexSubImage2D_IIIIIIIILjava_nio_Buffer__V;

	private static Delegate? cb_glCopyTexImage2D_GlCopyTexImage2D_IIIIIIII_V;

	private static Delegate? cb_glCopyTexSubImage2D_GlCopyTexSubImage2D_IIIIIIII_V;

	private static Delegate? cb_glCullFace_GlCullFace_I_V;

	private static Delegate? cb_glDeleteTextures_GlDeleteTextures_IarrayII_V;

	private static Delegate? cb_glDeleteTextures_GlDeleteTextures_ILjava_nio_IntBuffer__V;

	private static Delegate? cb_glDepthFunc_GlDepthFunc_I_V;

	private static Delegate? cb_glDepthMask_GlDepthMask_Z_V;

	private static Delegate? cb_glDepthRangef_GlDepthRangef_FF_V;

	private static Delegate? cb_glDepthRangex_GlDepthRangex_II_V;

	private static Delegate? cb_glDisable_GlDisable_I_V;

	private static Delegate? cb_glDisableClientState_GlDisableClientState_I_V;

	private static Delegate? cb_glDrawArrays_GlDrawArrays_III_V;

	private static Delegate? cb_glDrawElements_GlDrawElements_IIILjava_nio_Buffer__V;

	private static Delegate? cb_glEnable_GlEnable_I_V;

	private static Delegate? cb_glEnableClientState_GlEnableClientState_I_V;

	private static Delegate? cb_glFinish_GlFinish_V;

	private static Delegate? cb_glFlush_GlFlush_V;

	private static Delegate? cb_glFogf_GlFogf_IF_V;

	private static Delegate? cb_glFogfv_GlFogfv_IarrayFI_V;

	private static Delegate? cb_glFogfv_GlFogfv_ILjava_nio_FloatBuffer__V;

	private static Delegate? cb_glFogx_GlFogx_II_V;

	private static Delegate? cb_glFogxv_GlFogxv_IarrayII_V;

	private static Delegate? cb_glFogxv_GlFogxv_ILjava_nio_IntBuffer__V;

	private static Delegate? cb_glFrontFace_GlFrontFace_I_V;

	private static Delegate? cb_glFrustumf_GlFrustumf_FFFFFF_V;

	private static Delegate? cb_glFrustumx_GlFrustumx_IIIIII_V;

	private static Delegate? cb_glGenTextures_GlGenTextures_IarrayII_V;

	private static Delegate? cb_glGenTextures_GlGenTextures_ILjava_nio_IntBuffer__V;

	private static Delegate? cb_glGetError_GlGetError_I;

	private static Delegate? cb_glGetIntegerv_GlGetIntegerv_IarrayII_V;

	private static Delegate? cb_glGetIntegerv_GlGetIntegerv_ILjava_nio_IntBuffer__V;

	private static Delegate? cb_glGetString_GlGetString_I_Ljava_lang_String_;

	private static Delegate? cb_glHint_GlHint_II_V;

	private static Delegate? cb_glLightf_GlLightf_IIF_V;

	private static Delegate? cb_glLightfv_GlLightfv_IIarrayFI_V;

	private static Delegate? cb_glLightfv_GlLightfv_IILjava_nio_FloatBuffer__V;

	private static Delegate? cb_glLightModelf_GlLightModelf_IF_V;

	private static Delegate? cb_glLightModelfv_GlLightModelfv_IarrayFI_V;

	private static Delegate? cb_glLightModelfv_GlLightModelfv_ILjava_nio_FloatBuffer__V;

	private static Delegate? cb_glLightModelx_GlLightModelx_II_V;

	private static Delegate? cb_glLightModelxv_GlLightModelxv_IarrayII_V;

	private static Delegate? cb_glLightModelxv_GlLightModelxv_ILjava_nio_IntBuffer__V;

	private static Delegate? cb_glLightx_GlLightx_III_V;

	private static Delegate? cb_glLightxv_GlLightxv_IIarrayII_V;

	private static Delegate? cb_glLightxv_GlLightxv_IILjava_nio_IntBuffer__V;

	private static Delegate? cb_glLineWidth_GlLineWidth_F_V;

	private static Delegate? cb_glLineWidthx_GlLineWidthx_I_V;

	private static Delegate? cb_glLoadIdentity_GlLoadIdentity_V;

	private static Delegate? cb_glLoadMatrixf_GlLoadMatrixf_arrayFI_V;

	private static Delegate? cb_glLoadMatrixf_GlLoadMatrixf_Ljava_nio_FloatBuffer__V;

	private static Delegate? cb_glLoadMatrixx_GlLoadMatrixx_arrayII_V;

	private static Delegate? cb_glLoadMatrixx_GlLoadMatrixx_Ljava_nio_IntBuffer__V;

	private static Delegate? cb_glLogicOp_GlLogicOp_I_V;

	private static Delegate? cb_glMaterialf_GlMaterialf_IIF_V;

	private static Delegate? cb_glMaterialfv_GlMaterialfv_IIarrayFI_V;

	private static Delegate? cb_glMaterialfv_GlMaterialfv_IILjava_nio_FloatBuffer__V;

	private static Delegate? cb_glMaterialx_GlMaterialx_III_V;

	private static Delegate? cb_glMaterialxv_GlMaterialxv_IIarrayII_V;

	private static Delegate? cb_glMaterialxv_GlMaterialxv_IILjava_nio_IntBuffer__V;

	private static Delegate? cb_glMatrixMode_GlMatrixMode_I_V;

	private static Delegate? cb_glMultiTexCoord4f_GlMultiTexCoord4f_IFFFF_V;

	private static Delegate? cb_glMultiTexCoord4x_GlMultiTexCoord4x_IIIII_V;

	private static Delegate? cb_glMultMatrixf_GlMultMatrixf_arrayFI_V;

	private static Delegate? cb_glMultMatrixf_GlMultMatrixf_Ljava_nio_FloatBuffer__V;

	private static Delegate? cb_glMultMatrixx_GlMultMatrixx_arrayII_V;

	private static Delegate? cb_glMultMatrixx_GlMultMatrixx_Ljava_nio_IntBuffer__V;

	private static Delegate? cb_glNormal3f_GlNormal3f_FFF_V;

	private static Delegate? cb_glNormal3x_GlNormal3x_III_V;

	private static Delegate? cb_glNormalPointer_GlNormalPointer_IILjava_nio_Buffer__V;

	private static Delegate? cb_glOrthof_GlOrthof_FFFFFF_V;

	private static Delegate? cb_glOrthox_GlOrthox_IIIIII_V;

	private static Delegate? cb_glPixelStorei_GlPixelStorei_II_V;

	private static Delegate? cb_glPointSize_GlPointSize_F_V;

	private static Delegate? cb_glPointSizex_GlPointSizex_I_V;

	private static Delegate? cb_glPolygonOffset_GlPolygonOffset_FF_V;

	private static Delegate? cb_glPolygonOffsetx_GlPolygonOffsetx_II_V;

	private static Delegate? cb_glPopMatrix_GlPopMatrix_V;

	private static Delegate? cb_glPushMatrix_GlPushMatrix_V;

	private static Delegate? cb_glReadPixels_GlReadPixels_IIIIIILjava_nio_Buffer__V;

	private static Delegate? cb_glRotatef_GlRotatef_FFFF_V;

	private static Delegate? cb_glRotatex_GlRotatex_IIII_V;

	private static Delegate? cb_glSampleCoverage_GlSampleCoverage_FZ_V;

	private static Delegate? cb_glSampleCoveragex_GlSampleCoveragex_IZ_V;

	private static Delegate? cb_glScalef_GlScalef_FFF_V;

	private static Delegate? cb_glScalex_GlScalex_III_V;

	private static Delegate? cb_glScissor_GlScissor_IIII_V;

	private static Delegate? cb_glShadeModel_GlShadeModel_I_V;

	private static Delegate? cb_glStencilFunc_GlStencilFunc_III_V;

	private static Delegate? cb_glStencilMask_GlStencilMask_I_V;

	private static Delegate? cb_glStencilOp_GlStencilOp_III_V;

	private static Delegate? cb_glTexCoordPointer_GlTexCoordPointer_IIILjava_nio_Buffer__V;

	private static Delegate? cb_glTexEnvf_GlTexEnvf_IIF_V;

	private static Delegate? cb_glTexEnvfv_GlTexEnvfv_IIarrayFI_V;

	private static Delegate? cb_glTexEnvfv_GlTexEnvfv_IILjava_nio_FloatBuffer__V;

	private static Delegate? cb_glTexEnvx_GlTexEnvx_III_V;

	private static Delegate? cb_glTexEnvxv_GlTexEnvxv_IIarrayII_V;

	private static Delegate? cb_glTexEnvxv_GlTexEnvxv_IILjava_nio_IntBuffer__V;

	private static Delegate? cb_glTexImage2D_GlTexImage2D_IIIIIIIILjava_nio_Buffer__V;

	private static Delegate? cb_glTexParameterf_GlTexParameterf_IIF_V;

	private static Delegate? cb_glTexParameterx_GlTexParameterx_III_V;

	private static Delegate? cb_glTexSubImage2D_GlTexSubImage2D_IIIIIIIILjava_nio_Buffer__V;

	private static Delegate? cb_glTranslatef_GlTranslatef_FFF_V;

	private static Delegate? cb_glTranslatex_GlTranslatex_III_V;

	private static Delegate? cb_glVertexPointer_GlVertexPointer_IIILjava_nio_Buffer__V;

	private static Delegate? cb_glViewport_GlViewport_IIII_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_javax_microedition_khronos_opengles_GL10;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_javax_microedition_khronos_opengles_GL10.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_javax_microedition_khronos_opengles_GL10.ManagedPeerType;

	public IGL10Invoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGlActiveTexture_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlActiveTexture_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlActiveTexture_I(nint jnienv, nint native__this, int texture)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlActiveTexture(texture);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlActiveTexture(int texture)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(texture);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glActiveTexture.(I)V", this, ptr);
	}

	private static Delegate GetGlAlphaFunc_IFHandler()
	{
		return new _JniMarshal_PPIF_V(n_GlAlphaFunc_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlAlphaFunc_IF(nint jnienv, nint native__this, int func, float @ref)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlAlphaFunc(func, @ref);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlAlphaFunc(int func, float @ref)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(func);
		ptr[1] = new JniArgumentValue(@ref);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glAlphaFunc.(IF)V", this, ptr);
	}

	private static Delegate GetGlAlphaFuncx_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_GlAlphaFuncx_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlAlphaFuncx_II(nint jnienv, nint native__this, int func, int @ref)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlAlphaFuncx(func, @ref);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlAlphaFuncx(int func, int @ref)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(func);
		ptr[1] = new JniArgumentValue(@ref);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glAlphaFuncx.(II)V", this, ptr);
	}

	private static Delegate GetGlBindTexture_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_GlBindTexture_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlBindTexture_II(nint jnienv, nint native__this, int target, int texture)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlBindTexture(target, texture);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlBindTexture(int target, int texture)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(target);
		ptr[1] = new JniArgumentValue(texture);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glBindTexture.(II)V", this, ptr);
	}

	private static Delegate GetGlBlendFunc_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_GlBlendFunc_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlBlendFunc_II(nint jnienv, nint native__this, int sfactor, int dfactor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlBlendFunc(sfactor, dfactor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlBlendFunc(int sfactor, int dfactor)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(sfactor);
		ptr[1] = new JniArgumentValue(dfactor);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glBlendFunc.(II)V", this, ptr);
	}

	private static Delegate GetGlClear_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlClear_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlClear_I(nint jnienv, nint native__this, int mask)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlClear(mask);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlClear(int mask)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mask);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glClear.(I)V", this, ptr);
	}

	private static Delegate GetGlClearColor_FFFFHandler()
	{
		return new _JniMarshal_PPFFFF_V(n_GlClearColor_FFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlClearColor_FFFF(nint jnienv, nint native__this, float red, float green, float blue, float alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlClearColor(red, green, blue, alpha);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlClearColor(float red, float green, float blue, float alpha)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(red);
		ptr[1] = new JniArgumentValue(green);
		ptr[2] = new JniArgumentValue(blue);
		ptr[3] = new JniArgumentValue(alpha);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glClearColor.(FFFF)V", this, ptr);
	}

	private static Delegate GetGlClearColorx_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_V(n_GlClearColorx_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlClearColorx_IIII(nint jnienv, nint native__this, int red, int green, int blue, int alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlClearColorx(red, green, blue, alpha);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlClearColorx(int red, int green, int blue, int alpha)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(red);
		ptr[1] = new JniArgumentValue(green);
		ptr[2] = new JniArgumentValue(blue);
		ptr[3] = new JniArgumentValue(alpha);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glClearColorx.(IIII)V", this, ptr);
	}

	private static Delegate GetGlClearDepthf_FHandler()
	{
		return new _JniMarshal_PPF_V(n_GlClearDepthf_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlClearDepthf_F(nint jnienv, nint native__this, float depth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlClearDepthf(depth);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlClearDepthf(float depth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(depth);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glClearDepthf.(F)V", this, ptr);
	}

	private static Delegate GetGlClearDepthx_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlClearDepthx_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlClearDepthx_I(nint jnienv, nint native__this, int depth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlClearDepthx(depth);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlClearDepthx(int depth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(depth);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glClearDepthx.(I)V", this, ptr);
	}

	private static Delegate GetGlClearStencil_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlClearStencil_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlClearStencil_I(nint jnienv, nint native__this, int s)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlClearStencil(s);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlClearStencil(int s)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(s);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glClearStencil.(I)V", this, ptr);
	}

	private static Delegate GetGlClientActiveTexture_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlClientActiveTexture_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlClientActiveTexture_I(nint jnienv, nint native__this, int texture)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlClientActiveTexture(texture);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlClientActiveTexture(int texture)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(texture);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glClientActiveTexture.(I)V", this, ptr);
	}

	private static Delegate GetGlColor4f_FFFFHandler()
	{
		return new _JniMarshal_PPFFFF_V(n_GlColor4f_FFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlColor4f_FFFF(nint jnienv, nint native__this, float red, float green, float blue, float alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlColor4f(red, green, blue, alpha);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlColor4f(float red, float green, float blue, float alpha)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(red);
		ptr[1] = new JniArgumentValue(green);
		ptr[2] = new JniArgumentValue(blue);
		ptr[3] = new JniArgumentValue(alpha);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glColor4f.(FFFF)V", this, ptr);
	}

	private static Delegate GetGlColor4x_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_V(n_GlColor4x_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlColor4x_IIII(nint jnienv, nint native__this, int red, int green, int blue, int alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlColor4x(red, green, blue, alpha);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlColor4x(int red, int green, int blue, int alpha)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(red);
		ptr[1] = new JniArgumentValue(green);
		ptr[2] = new JniArgumentValue(blue);
		ptr[3] = new JniArgumentValue(alpha);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glColor4x.(IIII)V", this, ptr);
	}

	private static Delegate GetGlColorMask_ZZZZHandler()
	{
		return new _JniMarshal_PPBBBB_V(n_GlColorMask_ZZZZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlColorMask_ZZZZ(nint jnienv, nint native__this, sbyte native_red, sbyte native_green, sbyte native_blue, sbyte native_alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool red = native_red != 0;
			bool green = native_green != 0;
			bool blue = native_blue != 0;
			bool alpha = native_alpha != 0;
			iGL.GlColorMask(red, green, blue, alpha);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlColorMask(bool red, bool green, bool blue, bool alpha)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(red ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(green ? ((sbyte)1) : ((sbyte)0));
		ptr[2] = new JniArgumentValue(blue ? ((sbyte)1) : ((sbyte)0));
		ptr[3] = new JniArgumentValue(alpha ? ((sbyte)1) : ((sbyte)0));
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glColorMask.(ZZZZ)V", this, ptr);
	}

	private static Delegate GetGlColorPointer_IIILjava_nio_Buffer_Handler()
	{
		return new _JniMarshal_PPIIIL_V(n_GlColorPointer_IIILjava_nio_Buffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlColorPointer_IIILjava_nio_Buffer_(nint jnienv, nint native__this, int size, int type, int stride, nint native_pointer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Nio.Buffer pointer = Java.Lang.Object.GetObject<Java.Nio.Buffer>(native_pointer, JniHandleOwnership.DoNotTransfer);
			iGL.GlColorPointer(size, type, stride, pointer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlColorPointer(int size, int type, int stride, Java.Nio.Buffer? pointer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(size);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(stride);
			ptr[3] = new JniArgumentValue(pointer?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glColorPointer.(IIILjava/nio/Buffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pointer);
		}
	}

	private static Delegate GetGlCompressedTexImage2D_IIIIIIILjava_nio_Buffer_Handler()
	{
		return new _JniMarshal_PPIIIIIIIL_V(n_GlCompressedTexImage2D_IIIIIIILjava_nio_Buffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlCompressedTexImage2D_IIIIIIILjava_nio_Buffer_(nint jnienv, nint native__this, int target, int level, int internalformat, int width, int height, int border, int imageSize, nint native_data)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Nio.Buffer data = Java.Lang.Object.GetObject<Java.Nio.Buffer>(native_data, JniHandleOwnership.DoNotTransfer);
			iGL.GlCompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlCompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, int imageSize, Java.Nio.Buffer? data)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(target);
			ptr[1] = new JniArgumentValue(level);
			ptr[2] = new JniArgumentValue(internalformat);
			ptr[3] = new JniArgumentValue(width);
			ptr[4] = new JniArgumentValue(height);
			ptr[5] = new JniArgumentValue(border);
			ptr[6] = new JniArgumentValue(imageSize);
			ptr[7] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glCompressedTexImage2D.(IIIIIIILjava/nio/Buffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(data);
		}
	}

	private static Delegate GetGlCompressedTexSubImage2D_IIIIIIIILjava_nio_Buffer_Handler()
	{
		return new _JniMarshal_PPIIIIIIIIL_V(n_GlCompressedTexSubImage2D_IIIIIIIILjava_nio_Buffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlCompressedTexSubImage2D_IIIIIIIILjava_nio_Buffer_(nint jnienv, nint native__this, int target, int level, int xoffset, int yoffset, int width, int height, int format, int imageSize, nint native_data)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Nio.Buffer data = Java.Lang.Object.GetObject<Java.Nio.Buffer>(native_data, JniHandleOwnership.DoNotTransfer);
			iGL.GlCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlCompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int imageSize, Java.Nio.Buffer? data)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(target);
			ptr[1] = new JniArgumentValue(level);
			ptr[2] = new JniArgumentValue(xoffset);
			ptr[3] = new JniArgumentValue(yoffset);
			ptr[4] = new JniArgumentValue(width);
			ptr[5] = new JniArgumentValue(height);
			ptr[6] = new JniArgumentValue(format);
			ptr[7] = new JniArgumentValue(imageSize);
			ptr[8] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glCompressedTexSubImage2D.(IIIIIIIILjava/nio/Buffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(data);
		}
	}

	private static Delegate GetGlCopyTexImage2D_IIIIIIIIHandler()
	{
		return new _JniMarshal_PPIIIIIIII_V(n_GlCopyTexImage2D_IIIIIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlCopyTexImage2D_IIIIIIII(nint jnienv, nint native__this, int target, int level, int internalformat, int x, int y, int width, int height, int border)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlCopyTexImage2D(int target, int level, int internalformat, int x, int y, int width, int height, int border)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
		*ptr = new JniArgumentValue(target);
		ptr[1] = new JniArgumentValue(level);
		ptr[2] = new JniArgumentValue(internalformat);
		ptr[3] = new JniArgumentValue(x);
		ptr[4] = new JniArgumentValue(y);
		ptr[5] = new JniArgumentValue(width);
		ptr[6] = new JniArgumentValue(height);
		ptr[7] = new JniArgumentValue(border);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glCopyTexImage2D.(IIIIIIII)V", this, ptr);
	}

	private static Delegate GetGlCopyTexSubImage2D_IIIIIIIIHandler()
	{
		return new _JniMarshal_PPIIIIIIII_V(n_GlCopyTexSubImage2D_IIIIIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlCopyTexSubImage2D_IIIIIIII(nint jnienv, nint native__this, int target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlCopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
		*ptr = new JniArgumentValue(target);
		ptr[1] = new JniArgumentValue(level);
		ptr[2] = new JniArgumentValue(xoffset);
		ptr[3] = new JniArgumentValue(yoffset);
		ptr[4] = new JniArgumentValue(x);
		ptr[5] = new JniArgumentValue(y);
		ptr[6] = new JniArgumentValue(width);
		ptr[7] = new JniArgumentValue(height);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glCopyTexSubImage2D.(IIIIIIII)V", this, ptr);
	}

	private static Delegate GetGlCullFace_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlCullFace_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlCullFace_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlCullFace(mode);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlCullFace(int mode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mode);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glCullFace.(I)V", this, ptr);
	}

	private static Delegate GetGlDeleteTextures_IarrayIIHandler()
	{
		return new _JniMarshal_PPILI_V(n_GlDeleteTextures_IarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlDeleteTextures_IarrayII(nint jnienv, nint native__this, int n, nint native_textures, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_textures, JniHandleOwnership.DoNotTransfer, typeof(int));
			iGL.GlDeleteTextures(n, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_textures);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlDeleteTextures(int n, int[]? textures, int offset)
	{
		nint num = JNIEnv.NewArray(textures);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(n);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glDeleteTextures.(I[II)V", this, ptr);
		}
		finally
		{
			if (textures != null)
			{
				JNIEnv.CopyArray(num, textures);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(textures);
		}
	}

	private static Delegate GetGlDeleteTextures_ILjava_nio_IntBuffer_Handler()
	{
		return new _JniMarshal_PPIL_V(n_GlDeleteTextures_ILjava_nio_IntBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlDeleteTextures_ILjava_nio_IntBuffer_(nint jnienv, nint native__this, int n, nint native_textures)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntBuffer textures = Java.Lang.Object.GetObject<IntBuffer>(native_textures, JniHandleOwnership.DoNotTransfer);
			iGL.GlDeleteTextures(n, textures);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlDeleteTextures(int n, IntBuffer? textures)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(n);
			ptr[1] = new JniArgumentValue(textures?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glDeleteTextures.(ILjava/nio/IntBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(textures);
		}
	}

	private static Delegate GetGlDepthFunc_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlDepthFunc_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlDepthFunc_I(nint jnienv, nint native__this, int func)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlDepthFunc(func);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlDepthFunc(int func)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(func);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glDepthFunc.(I)V", this, ptr);
	}

	private static Delegate GetGlDepthMask_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_GlDepthMask_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlDepthMask_Z(nint jnienv, nint native__this, sbyte native_flag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool flag = native_flag != 0;
			iGL.GlDepthMask(flag);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlDepthMask(bool flag)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(flag ? ((sbyte)1) : ((sbyte)0));
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glDepthMask.(Z)V", this, ptr);
	}

	private static Delegate GetGlDepthRangef_FFHandler()
	{
		return new _JniMarshal_PPFF_V(n_GlDepthRangef_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlDepthRangef_FF(nint jnienv, nint native__this, float zNear, float zFar)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlDepthRangef(zNear, zFar);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlDepthRangef(float zNear, float zFar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(zNear);
		ptr[1] = new JniArgumentValue(zFar);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glDepthRangef.(FF)V", this, ptr);
	}

	private static Delegate GetGlDepthRangex_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_GlDepthRangex_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlDepthRangex_II(nint jnienv, nint native__this, int zNear, int zFar)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlDepthRangex(zNear, zFar);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlDepthRangex(int zNear, int zFar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(zNear);
		ptr[1] = new JniArgumentValue(zFar);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glDepthRangex.(II)V", this, ptr);
	}

	private static Delegate GetGlDisable_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlDisable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlDisable_I(nint jnienv, nint native__this, int cap)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlDisable(cap);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlDisable(int cap)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(cap);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glDisable.(I)V", this, ptr);
	}

	private static Delegate GetGlDisableClientState_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlDisableClientState_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlDisableClientState_I(nint jnienv, nint native__this, int array)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlDisableClientState(array);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlDisableClientState(int array)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(array);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glDisableClientState.(I)V", this, ptr);
	}

	private static Delegate GetGlDrawArrays_IIIHandler()
	{
		return new _JniMarshal_PPIII_V(n_GlDrawArrays_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlDrawArrays_III(nint jnienv, nint native__this, int mode, int first, int count)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlDrawArrays(mode, first, count);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlDrawArrays(int mode, int first, int count)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(mode);
		ptr[1] = new JniArgumentValue(first);
		ptr[2] = new JniArgumentValue(count);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glDrawArrays.(III)V", this, ptr);
	}

	private static Delegate GetGlDrawElements_IIILjava_nio_Buffer_Handler()
	{
		return new _JniMarshal_PPIIIL_V(n_GlDrawElements_IIILjava_nio_Buffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlDrawElements_IIILjava_nio_Buffer_(nint jnienv, nint native__this, int mode, int count, int type, nint native_indices)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Nio.Buffer indices = Java.Lang.Object.GetObject<Java.Nio.Buffer>(native_indices, JniHandleOwnership.DoNotTransfer);
			iGL.GlDrawElements(mode, count, type, indices);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlDrawElements(int mode, int count, int type, Java.Nio.Buffer? indices)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(mode);
			ptr[1] = new JniArgumentValue(count);
			ptr[2] = new JniArgumentValue(type);
			ptr[3] = new JniArgumentValue(indices?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glDrawElements.(IIILjava/nio/Buffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(indices);
		}
	}

	private static Delegate GetGlEnable_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlEnable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlEnable_I(nint jnienv, nint native__this, int cap)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlEnable(cap);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlEnable(int cap)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(cap);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glEnable.(I)V", this, ptr);
	}

	private static Delegate GetGlEnableClientState_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlEnableClientState_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlEnableClientState_I(nint jnienv, nint native__this, int array)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlEnableClientState(array);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlEnableClientState(int array)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(array);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glEnableClientState.(I)V", this, ptr);
	}

	private static Delegate GetGlFinishHandler()
	{
		return new _JniMarshal_PP_V(n_GlFinish);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFinish(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlFinish();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFinish()
	{
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFinish.()V", this, null);
	}

	private static Delegate GetGlFlushHandler()
	{
		return new _JniMarshal_PP_V(n_GlFlush);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFlush(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlFlush();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFlush()
	{
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFlush.()V", this, null);
	}

	private static Delegate GetGlFogf_IFHandler()
	{
		return new _JniMarshal_PPIF_V(n_GlFogf_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFogf_IF(nint jnienv, nint native__this, int pname, float param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlFogf(pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFogf(int pname, float param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(pname);
		ptr[1] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFogf.(IF)V", this, ptr);
	}

	private static Delegate GetGlFogfv_IarrayFIHandler()
	{
		return new _JniMarshal_PPILI_V(n_GlFogfv_IarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFogfv_IarrayFI(nint jnienv, nint native__this, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(float));
			iGL.GlFogfv(pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFogfv(int pname, float[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFogfv.(I[FI)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlFogfv_ILjava_nio_FloatBuffer_Handler()
	{
		return new _JniMarshal_PPIL_V(n_GlFogfv_ILjava_nio_FloatBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFogfv_ILjava_nio_FloatBuffer_(nint jnienv, nint native__this, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatBuffer floatBuffer = Java.Lang.Object.GetObject<FloatBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlFogfv(pname, floatBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFogfv(int pname, FloatBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFogfv.(ILjava/nio/FloatBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlFogx_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_GlFogx_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFogx_II(nint jnienv, nint native__this, int pname, int param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlFogx(pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFogx(int pname, int param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(pname);
		ptr[1] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFogx.(II)V", this, ptr);
	}

	private static Delegate GetGlFogxv_IarrayIIHandler()
	{
		return new _JniMarshal_PPILI_V(n_GlFogxv_IarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFogxv_IarrayII(nint jnienv, nint native__this, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(int));
			iGL.GlFogxv(pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFogxv(int pname, int[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFogxv.(I[II)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlFogxv_ILjava_nio_IntBuffer_Handler()
	{
		return new _JniMarshal_PPIL_V(n_GlFogxv_ILjava_nio_IntBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFogxv_ILjava_nio_IntBuffer_(nint jnienv, nint native__this, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntBuffer intBuffer = Java.Lang.Object.GetObject<IntBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlFogxv(pname, intBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFogxv(int pname, IntBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFogxv.(ILjava/nio/IntBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlFrontFace_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlFrontFace_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFrontFace_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlFrontFace(mode);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFrontFace(int mode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mode);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFrontFace.(I)V", this, ptr);
	}

	private static Delegate GetGlFrustumf_FFFFFFHandler()
	{
		return new _JniMarshal_PPFFFFFF_V(n_GlFrustumf_FFFFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFrustumf_FFFFFF(nint jnienv, nint native__this, float left, float right, float bottom, float top, float zNear, float zFar)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlFrustumf(left, right, bottom, top, zNear, zFar);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFrustumf(float left, float right, float bottom, float top, float zNear, float zFar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(right);
		ptr[2] = new JniArgumentValue(bottom);
		ptr[3] = new JniArgumentValue(top);
		ptr[4] = new JniArgumentValue(zNear);
		ptr[5] = new JniArgumentValue(zFar);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFrustumf.(FFFFFF)V", this, ptr);
	}

	private static Delegate GetGlFrustumx_IIIIIIHandler()
	{
		return new _JniMarshal_PPIIIIII_V(n_GlFrustumx_IIIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlFrustumx_IIIIII(nint jnienv, nint native__this, int left, int right, int bottom, int top, int zNear, int zFar)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlFrustumx(left, right, bottom, top, zNear, zFar);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlFrustumx(int left, int right, int bottom, int top, int zNear, int zFar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(right);
		ptr[2] = new JniArgumentValue(bottom);
		ptr[3] = new JniArgumentValue(top);
		ptr[4] = new JniArgumentValue(zNear);
		ptr[5] = new JniArgumentValue(zFar);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glFrustumx.(IIIIII)V", this, ptr);
	}

	private static Delegate GetGlGenTextures_IarrayIIHandler()
	{
		return new _JniMarshal_PPILI_V(n_GlGenTextures_IarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlGenTextures_IarrayII(nint jnienv, nint native__this, int n, nint native_textures, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_textures, JniHandleOwnership.DoNotTransfer, typeof(int));
			iGL.GlGenTextures(n, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_textures);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlGenTextures(int n, int[]? textures, int offset)
	{
		nint num = JNIEnv.NewArray(textures);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(n);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glGenTextures.(I[II)V", this, ptr);
		}
		finally
		{
			if (textures != null)
			{
				JNIEnv.CopyArray(num, textures);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(textures);
		}
	}

	private static Delegate GetGlGenTextures_ILjava_nio_IntBuffer_Handler()
	{
		return new _JniMarshal_PPIL_V(n_GlGenTextures_ILjava_nio_IntBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlGenTextures_ILjava_nio_IntBuffer_(nint jnienv, nint native__this, int n, nint native_textures)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntBuffer textures = Java.Lang.Object.GetObject<IntBuffer>(native_textures, JniHandleOwnership.DoNotTransfer);
			iGL.GlGenTextures(n, textures);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlGenTextures(int n, IntBuffer? textures)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(n);
			ptr[1] = new JniArgumentValue(textures?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glGenTextures.(ILjava/nio/IntBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(textures);
		}
	}

	private static Delegate GetGlGetErrorHandler()
	{
		return new _JniMarshal_PP_I(n_GlGetError);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GlGetError(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlGetError();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe int GlGetError()
	{
		return _members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractInt32Method("glGetError.()I", this, null);
	}

	private static Delegate GetGlGetIntegerv_IarrayIIHandler()
	{
		return new _JniMarshal_PPILI_V(n_GlGetIntegerv_IarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlGetIntegerv_IarrayII(nint jnienv, nint native__this, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(int));
			iGL.GlGetIntegerv(pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlGetIntegerv(int pname, int[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glGetIntegerv.(I[II)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlGetIntegerv_ILjava_nio_IntBuffer_Handler()
	{
		return new _JniMarshal_PPIL_V(n_GlGetIntegerv_ILjava_nio_IntBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlGetIntegerv_ILjava_nio_IntBuffer_(nint jnienv, nint native__this, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntBuffer intBuffer = Java.Lang.Object.GetObject<IntBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlGetIntegerv(pname, intBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlGetIntegerv(int pname, IntBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glGetIntegerv.(ILjava/nio/IntBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlGetString_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GlGetString_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GlGetString_I(nint jnienv, nint native__this, int name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlGetString(name));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe string? GlGetString(int name)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(name);
		return JNIEnv.GetString(_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractObjectMethod("glGetString.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGlHint_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_GlHint_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlHint_II(nint jnienv, nint native__this, int target, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlHint(target, mode);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlHint(int target, int mode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(target);
		ptr[1] = new JniArgumentValue(mode);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glHint.(II)V", this, ptr);
	}

	private static Delegate GetGlLightf_IIFHandler()
	{
		return new _JniMarshal_PPIIF_V(n_GlLightf_IIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightf_IIF(nint jnienv, nint native__this, int light, int pname, float param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlLightf(light, pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightf(int light, int pname, float param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(light);
		ptr[1] = new JniArgumentValue(pname);
		ptr[2] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightf.(IIF)V", this, ptr);
	}

	private static Delegate GetGlLightfv_IIarrayFIHandler()
	{
		return new _JniMarshal_PPIILI_V(n_GlLightfv_IIarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightfv_IIarrayFI(nint jnienv, nint native__this, int light, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(float));
			iGL.GlLightfv(light, pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightfv(int light, int pname, float[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(light);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightfv.(II[FI)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlLightfv_IILjava_nio_FloatBuffer_Handler()
	{
		return new _JniMarshal_PPIIL_V(n_GlLightfv_IILjava_nio_FloatBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightfv_IILjava_nio_FloatBuffer_(nint jnienv, nint native__this, int light, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatBuffer floatBuffer = Java.Lang.Object.GetObject<FloatBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlLightfv(light, pname, floatBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightfv(int light, int pname, FloatBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(light);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightfv.(IILjava/nio/FloatBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlLightModelf_IFHandler()
	{
		return new _JniMarshal_PPIF_V(n_GlLightModelf_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightModelf_IF(nint jnienv, nint native__this, int pname, float param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlLightModelf(pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightModelf(int pname, float param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(pname);
		ptr[1] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightModelf.(IF)V", this, ptr);
	}

	private static Delegate GetGlLightModelfv_IarrayFIHandler()
	{
		return new _JniMarshal_PPILI_V(n_GlLightModelfv_IarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightModelfv_IarrayFI(nint jnienv, nint native__this, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(float));
			iGL.GlLightModelfv(pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightModelfv(int pname, float[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightModelfv.(I[FI)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlLightModelfv_ILjava_nio_FloatBuffer_Handler()
	{
		return new _JniMarshal_PPIL_V(n_GlLightModelfv_ILjava_nio_FloatBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightModelfv_ILjava_nio_FloatBuffer_(nint jnienv, nint native__this, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatBuffer floatBuffer = Java.Lang.Object.GetObject<FloatBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlLightModelfv(pname, floatBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightModelfv(int pname, FloatBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightModelfv.(ILjava/nio/FloatBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlLightModelx_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_GlLightModelx_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightModelx_II(nint jnienv, nint native__this, int pname, int param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlLightModelx(pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightModelx(int pname, int param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(pname);
		ptr[1] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightModelx.(II)V", this, ptr);
	}

	private static Delegate GetGlLightModelxv_IarrayIIHandler()
	{
		return new _JniMarshal_PPILI_V(n_GlLightModelxv_IarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightModelxv_IarrayII(nint jnienv, nint native__this, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(int));
			iGL.GlLightModelxv(pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightModelxv(int pname, int[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightModelxv.(I[II)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlLightModelxv_ILjava_nio_IntBuffer_Handler()
	{
		return new _JniMarshal_PPIL_V(n_GlLightModelxv_ILjava_nio_IntBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightModelxv_ILjava_nio_IntBuffer_(nint jnienv, nint native__this, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntBuffer intBuffer = Java.Lang.Object.GetObject<IntBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlLightModelxv(pname, intBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightModelxv(int pname, IntBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(pname);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightModelxv.(ILjava/nio/IntBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlLightx_IIIHandler()
	{
		return new _JniMarshal_PPIII_V(n_GlLightx_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightx_III(nint jnienv, nint native__this, int light, int pname, int param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlLightx(light, pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightx(int light, int pname, int param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(light);
		ptr[1] = new JniArgumentValue(pname);
		ptr[2] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightx.(III)V", this, ptr);
	}

	private static Delegate GetGlLightxv_IIarrayIIHandler()
	{
		return new _JniMarshal_PPIILI_V(n_GlLightxv_IIarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightxv_IIarrayII(nint jnienv, nint native__this, int light, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(int));
			iGL.GlLightxv(light, pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightxv(int light, int pname, int[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(light);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightxv.(II[II)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlLightxv_IILjava_nio_IntBuffer_Handler()
	{
		return new _JniMarshal_PPIIL_V(n_GlLightxv_IILjava_nio_IntBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLightxv_IILjava_nio_IntBuffer_(nint jnienv, nint native__this, int light, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntBuffer intBuffer = Java.Lang.Object.GetObject<IntBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlLightxv(light, pname, intBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLightxv(int light, int pname, IntBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(light);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLightxv.(IILjava/nio/IntBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlLineWidth_FHandler()
	{
		return new _JniMarshal_PPF_V(n_GlLineWidth_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLineWidth_F(nint jnienv, nint native__this, float width)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlLineWidth(width);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLineWidth(float width)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(width);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLineWidth.(F)V", this, ptr);
	}

	private static Delegate GetGlLineWidthx_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlLineWidthx_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLineWidthx_I(nint jnienv, nint native__this, int width)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlLineWidthx(width);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLineWidthx(int width)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(width);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLineWidthx.(I)V", this, ptr);
	}

	private static Delegate GetGlLoadIdentityHandler()
	{
		return new _JniMarshal_PP_V(n_GlLoadIdentity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLoadIdentity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlLoadIdentity();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLoadIdentity()
	{
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLoadIdentity.()V", this, null);
	}

	private static Delegate GetGlLoadMatrixf_arrayFIHandler()
	{
		return new _JniMarshal_PPLI_V(n_GlLoadMatrixf_arrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLoadMatrixf_arrayFI(nint jnienv, nint native__this, nint native_m, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_m, JniHandleOwnership.DoNotTransfer, typeof(float));
			iGL.GlLoadMatrixf(array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_m);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLoadMatrixf(float[]? m, int offset)
	{
		nint num = JNIEnv.NewArray(m);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLoadMatrixf.([FI)V", this, ptr);
		}
		finally
		{
			if (m != null)
			{
				JNIEnv.CopyArray(num, m);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(m);
		}
	}

	private static Delegate GetGlLoadMatrixf_Ljava_nio_FloatBuffer_Handler()
	{
		return new _JniMarshal_PPL_V(n_GlLoadMatrixf_Ljava_nio_FloatBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLoadMatrixf_Ljava_nio_FloatBuffer_(nint jnienv, nint native__this, nint native_m)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatBuffer m = Java.Lang.Object.GetObject<FloatBuffer>(native_m, JniHandleOwnership.DoNotTransfer);
			iGL.GlLoadMatrixf(m);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLoadMatrixf(FloatBuffer? m)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(m?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLoadMatrixf.(Ljava/nio/FloatBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(m);
		}
	}

	private static Delegate GetGlLoadMatrixx_arrayIIHandler()
	{
		return new _JniMarshal_PPLI_V(n_GlLoadMatrixx_arrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLoadMatrixx_arrayII(nint jnienv, nint native__this, nint native_m, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_m, JniHandleOwnership.DoNotTransfer, typeof(int));
			iGL.GlLoadMatrixx(array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_m);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLoadMatrixx(int[]? m, int offset)
	{
		nint num = JNIEnv.NewArray(m);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLoadMatrixx.([II)V", this, ptr);
		}
		finally
		{
			if (m != null)
			{
				JNIEnv.CopyArray(num, m);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(m);
		}
	}

	private static Delegate GetGlLoadMatrixx_Ljava_nio_IntBuffer_Handler()
	{
		return new _JniMarshal_PPL_V(n_GlLoadMatrixx_Ljava_nio_IntBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLoadMatrixx_Ljava_nio_IntBuffer_(nint jnienv, nint native__this, nint native_m)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntBuffer m = Java.Lang.Object.GetObject<IntBuffer>(native_m, JniHandleOwnership.DoNotTransfer);
			iGL.GlLoadMatrixx(m);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLoadMatrixx(IntBuffer? m)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(m?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLoadMatrixx.(Ljava/nio/IntBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(m);
		}
	}

	private static Delegate GetGlLogicOp_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlLogicOp_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlLogicOp_I(nint jnienv, nint native__this, int opcode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlLogicOp(opcode);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlLogicOp(int opcode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(opcode);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glLogicOp.(I)V", this, ptr);
	}

	private static Delegate GetGlMaterialf_IIFHandler()
	{
		return new _JniMarshal_PPIIF_V(n_GlMaterialf_IIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMaterialf_IIF(nint jnienv, nint native__this, int face, int pname, float param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlMaterialf(face, pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMaterialf(int face, int pname, float param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(face);
		ptr[1] = new JniArgumentValue(pname);
		ptr[2] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMaterialf.(IIF)V", this, ptr);
	}

	private static Delegate GetGlMaterialfv_IIarrayFIHandler()
	{
		return new _JniMarshal_PPIILI_V(n_GlMaterialfv_IIarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMaterialfv_IIarrayFI(nint jnienv, nint native__this, int face, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(float));
			iGL.GlMaterialfv(face, pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMaterialfv(int face, int pname, float[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(face);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMaterialfv.(II[FI)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlMaterialfv_IILjava_nio_FloatBuffer_Handler()
	{
		return new _JniMarshal_PPIIL_V(n_GlMaterialfv_IILjava_nio_FloatBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMaterialfv_IILjava_nio_FloatBuffer_(nint jnienv, nint native__this, int face, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatBuffer floatBuffer = Java.Lang.Object.GetObject<FloatBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlMaterialfv(face, pname, floatBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMaterialfv(int face, int pname, FloatBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(face);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMaterialfv.(IILjava/nio/FloatBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlMaterialx_IIIHandler()
	{
		return new _JniMarshal_PPIII_V(n_GlMaterialx_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMaterialx_III(nint jnienv, nint native__this, int face, int pname, int param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlMaterialx(face, pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMaterialx(int face, int pname, int param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(face);
		ptr[1] = new JniArgumentValue(pname);
		ptr[2] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMaterialx.(III)V", this, ptr);
	}

	private static Delegate GetGlMaterialxv_IIarrayIIHandler()
	{
		return new _JniMarshal_PPIILI_V(n_GlMaterialxv_IIarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMaterialxv_IIarrayII(nint jnienv, nint native__this, int face, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(int));
			iGL.GlMaterialxv(face, pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMaterialxv(int face, int pname, int[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(face);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMaterialxv.(II[II)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlMaterialxv_IILjava_nio_IntBuffer_Handler()
	{
		return new _JniMarshal_PPIIL_V(n_GlMaterialxv_IILjava_nio_IntBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMaterialxv_IILjava_nio_IntBuffer_(nint jnienv, nint native__this, int face, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntBuffer intBuffer = Java.Lang.Object.GetObject<IntBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlMaterialxv(face, pname, intBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMaterialxv(int face, int pname, IntBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(face);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMaterialxv.(IILjava/nio/IntBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlMatrixMode_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlMatrixMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMatrixMode_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlMatrixMode(mode);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMatrixMode(int mode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mode);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMatrixMode.(I)V", this, ptr);
	}

	private static Delegate GetGlMultiTexCoord4f_IFFFFHandler()
	{
		return new _JniMarshal_PPIFFFF_V(n_GlMultiTexCoord4f_IFFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMultiTexCoord4f_IFFFF(nint jnienv, nint native__this, int target, float s, float t, float r, float q)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlMultiTexCoord4f(target, s, t, r, q);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMultiTexCoord4f(int target, float s, float t, float r, float q)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(target);
		ptr[1] = new JniArgumentValue(s);
		ptr[2] = new JniArgumentValue(t);
		ptr[3] = new JniArgumentValue(r);
		ptr[4] = new JniArgumentValue(q);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMultiTexCoord4f.(IFFFF)V", this, ptr);
	}

	private static Delegate GetGlMultiTexCoord4x_IIIIIHandler()
	{
		return new _JniMarshal_PPIIIII_V(n_GlMultiTexCoord4x_IIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMultiTexCoord4x_IIIII(nint jnienv, nint native__this, int target, int s, int t, int r, int q)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlMultiTexCoord4x(target, s, t, r, q);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMultiTexCoord4x(int target, int s, int t, int r, int q)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(target);
		ptr[1] = new JniArgumentValue(s);
		ptr[2] = new JniArgumentValue(t);
		ptr[3] = new JniArgumentValue(r);
		ptr[4] = new JniArgumentValue(q);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMultiTexCoord4x.(IIIII)V", this, ptr);
	}

	private static Delegate GetGlMultMatrixf_arrayFIHandler()
	{
		return new _JniMarshal_PPLI_V(n_GlMultMatrixf_arrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMultMatrixf_arrayFI(nint jnienv, nint native__this, nint native_m, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_m, JniHandleOwnership.DoNotTransfer, typeof(float));
			iGL.GlMultMatrixf(array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_m);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMultMatrixf(float[]? m, int offset)
	{
		nint num = JNIEnv.NewArray(m);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMultMatrixf.([FI)V", this, ptr);
		}
		finally
		{
			if (m != null)
			{
				JNIEnv.CopyArray(num, m);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(m);
		}
	}

	private static Delegate GetGlMultMatrixf_Ljava_nio_FloatBuffer_Handler()
	{
		return new _JniMarshal_PPL_V(n_GlMultMatrixf_Ljava_nio_FloatBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMultMatrixf_Ljava_nio_FloatBuffer_(nint jnienv, nint native__this, nint native_m)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatBuffer m = Java.Lang.Object.GetObject<FloatBuffer>(native_m, JniHandleOwnership.DoNotTransfer);
			iGL.GlMultMatrixf(m);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMultMatrixf(FloatBuffer? m)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(m?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMultMatrixf.(Ljava/nio/FloatBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(m);
		}
	}

	private static Delegate GetGlMultMatrixx_arrayIIHandler()
	{
		return new _JniMarshal_PPLI_V(n_GlMultMatrixx_arrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMultMatrixx_arrayII(nint jnienv, nint native__this, nint native_m, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_m, JniHandleOwnership.DoNotTransfer, typeof(int));
			iGL.GlMultMatrixx(array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_m);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMultMatrixx(int[]? m, int offset)
	{
		nint num = JNIEnv.NewArray(m);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMultMatrixx.([II)V", this, ptr);
		}
		finally
		{
			if (m != null)
			{
				JNIEnv.CopyArray(num, m);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(m);
		}
	}

	private static Delegate GetGlMultMatrixx_Ljava_nio_IntBuffer_Handler()
	{
		return new _JniMarshal_PPL_V(n_GlMultMatrixx_Ljava_nio_IntBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlMultMatrixx_Ljava_nio_IntBuffer_(nint jnienv, nint native__this, nint native_m)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntBuffer m = Java.Lang.Object.GetObject<IntBuffer>(native_m, JniHandleOwnership.DoNotTransfer);
			iGL.GlMultMatrixx(m);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlMultMatrixx(IntBuffer? m)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(m?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glMultMatrixx.(Ljava/nio/IntBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(m);
		}
	}

	private static Delegate GetGlNormal3f_FFFHandler()
	{
		return new _JniMarshal_PPFFF_V(n_GlNormal3f_FFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlNormal3f_FFF(nint jnienv, nint native__this, float nx, float ny, float nz)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlNormal3f(nx, ny, nz);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlNormal3f(float nx, float ny, float nz)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(nx);
		ptr[1] = new JniArgumentValue(ny);
		ptr[2] = new JniArgumentValue(nz);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glNormal3f.(FFF)V", this, ptr);
	}

	private static Delegate GetGlNormal3x_IIIHandler()
	{
		return new _JniMarshal_PPIII_V(n_GlNormal3x_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlNormal3x_III(nint jnienv, nint native__this, int nx, int ny, int nz)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlNormal3x(nx, ny, nz);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlNormal3x(int nx, int ny, int nz)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(nx);
		ptr[1] = new JniArgumentValue(ny);
		ptr[2] = new JniArgumentValue(nz);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glNormal3x.(III)V", this, ptr);
	}

	private static Delegate GetGlNormalPointer_IILjava_nio_Buffer_Handler()
	{
		return new _JniMarshal_PPIIL_V(n_GlNormalPointer_IILjava_nio_Buffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlNormalPointer_IILjava_nio_Buffer_(nint jnienv, nint native__this, int type, int stride, nint native_pointer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Nio.Buffer pointer = Java.Lang.Object.GetObject<Java.Nio.Buffer>(native_pointer, JniHandleOwnership.DoNotTransfer);
			iGL.GlNormalPointer(type, stride, pointer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlNormalPointer(int type, int stride, Java.Nio.Buffer? pointer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(type);
			ptr[1] = new JniArgumentValue(stride);
			ptr[2] = new JniArgumentValue(pointer?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glNormalPointer.(IILjava/nio/Buffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pointer);
		}
	}

	private static Delegate GetGlOrthof_FFFFFFHandler()
	{
		return new _JniMarshal_PPFFFFFF_V(n_GlOrthof_FFFFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlOrthof_FFFFFF(nint jnienv, nint native__this, float left, float right, float bottom, float top, float zNear, float zFar)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlOrthof(left, right, bottom, top, zNear, zFar);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlOrthof(float left, float right, float bottom, float top, float zNear, float zFar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(right);
		ptr[2] = new JniArgumentValue(bottom);
		ptr[3] = new JniArgumentValue(top);
		ptr[4] = new JniArgumentValue(zNear);
		ptr[5] = new JniArgumentValue(zFar);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glOrthof.(FFFFFF)V", this, ptr);
	}

	private static Delegate GetGlOrthox_IIIIIIHandler()
	{
		return new _JniMarshal_PPIIIIII_V(n_GlOrthox_IIIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlOrthox_IIIIII(nint jnienv, nint native__this, int left, int right, int bottom, int top, int zNear, int zFar)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlOrthox(left, right, bottom, top, zNear, zFar);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlOrthox(int left, int right, int bottom, int top, int zNear, int zFar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(right);
		ptr[2] = new JniArgumentValue(bottom);
		ptr[3] = new JniArgumentValue(top);
		ptr[4] = new JniArgumentValue(zNear);
		ptr[5] = new JniArgumentValue(zFar);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glOrthox.(IIIIII)V", this, ptr);
	}

	private static Delegate GetGlPixelStorei_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_GlPixelStorei_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlPixelStorei_II(nint jnienv, nint native__this, int pname, int param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlPixelStorei(pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlPixelStorei(int pname, int param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(pname);
		ptr[1] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glPixelStorei.(II)V", this, ptr);
	}

	private static Delegate GetGlPointSize_FHandler()
	{
		return new _JniMarshal_PPF_V(n_GlPointSize_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlPointSize_F(nint jnienv, nint native__this, float size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlPointSize(size);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlPointSize(float size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(size);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glPointSize.(F)V", this, ptr);
	}

	private static Delegate GetGlPointSizex_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlPointSizex_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlPointSizex_I(nint jnienv, nint native__this, int size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlPointSizex(size);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlPointSizex(int size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(size);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glPointSizex.(I)V", this, ptr);
	}

	private static Delegate GetGlPolygonOffset_FFHandler()
	{
		return new _JniMarshal_PPFF_V(n_GlPolygonOffset_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlPolygonOffset_FF(nint jnienv, nint native__this, float factor, float units)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlPolygonOffset(factor, units);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlPolygonOffset(float factor, float units)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(factor);
		ptr[1] = new JniArgumentValue(units);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glPolygonOffset.(FF)V", this, ptr);
	}

	private static Delegate GetGlPolygonOffsetx_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_GlPolygonOffsetx_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlPolygonOffsetx_II(nint jnienv, nint native__this, int factor, int units)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlPolygonOffsetx(factor, units);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlPolygonOffsetx(int factor, int units)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(factor);
		ptr[1] = new JniArgumentValue(units);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glPolygonOffsetx.(II)V", this, ptr);
	}

	private static Delegate GetGlPopMatrixHandler()
	{
		return new _JniMarshal_PP_V(n_GlPopMatrix);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlPopMatrix(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlPopMatrix();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlPopMatrix()
	{
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glPopMatrix.()V", this, null);
	}

	private static Delegate GetGlPushMatrixHandler()
	{
		return new _JniMarshal_PP_V(n_GlPushMatrix);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlPushMatrix(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlPushMatrix();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlPushMatrix()
	{
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glPushMatrix.()V", this, null);
	}

	private static Delegate GetGlReadPixels_IIIIIILjava_nio_Buffer_Handler()
	{
		return new _JniMarshal_PPIIIIIIL_V(n_GlReadPixels_IIIIIILjava_nio_Buffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlReadPixels_IIIIIILjava_nio_Buffer_(nint jnienv, nint native__this, int x, int y, int width, int height, int format, int type, nint native_pixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Nio.Buffer pixels = Java.Lang.Object.GetObject<Java.Nio.Buffer>(native_pixels, JniHandleOwnership.DoNotTransfer);
			iGL.GlReadPixels(x, y, width, height, format, type, pixels);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlReadPixels(int x, int y, int width, int height, int format, int type, Java.Nio.Buffer? pixels)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			ptr[2] = new JniArgumentValue(width);
			ptr[3] = new JniArgumentValue(height);
			ptr[4] = new JniArgumentValue(format);
			ptr[5] = new JniArgumentValue(type);
			ptr[6] = new JniArgumentValue(pixels?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glReadPixels.(IIIIIILjava/nio/Buffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pixels);
		}
	}

	private static Delegate GetGlRotatef_FFFFHandler()
	{
		return new _JniMarshal_PPFFFF_V(n_GlRotatef_FFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlRotatef_FFFF(nint jnienv, nint native__this, float angle, float x, float y, float z)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlRotatef(angle, x, y, z);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlRotatef(float angle, float x, float y, float z)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(angle);
		ptr[1] = new JniArgumentValue(x);
		ptr[2] = new JniArgumentValue(y);
		ptr[3] = new JniArgumentValue(z);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glRotatef.(FFFF)V", this, ptr);
	}

	private static Delegate GetGlRotatex_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_V(n_GlRotatex_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlRotatex_IIII(nint jnienv, nint native__this, int angle, int x, int y, int z)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlRotatex(angle, x, y, z);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlRotatex(int angle, int x, int y, int z)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(angle);
		ptr[1] = new JniArgumentValue(x);
		ptr[2] = new JniArgumentValue(y);
		ptr[3] = new JniArgumentValue(z);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glRotatex.(IIII)V", this, ptr);
	}

	private static Delegate GetGlSampleCoverage_FZHandler()
	{
		return new _JniMarshal_PPFB_V(n_GlSampleCoverage_FZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlSampleCoverage_FZ(nint jnienv, nint native__this, float value, sbyte native_invert)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool invert = native_invert != 0;
			iGL.GlSampleCoverage(value, invert);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlSampleCoverage(float value, bool invert)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(value);
		ptr[1] = new JniArgumentValue(invert ? ((sbyte)1) : ((sbyte)0));
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glSampleCoverage.(FZ)V", this, ptr);
	}

	private static Delegate GetGlSampleCoveragex_IZHandler()
	{
		return new _JniMarshal_PPIB_V(n_GlSampleCoveragex_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlSampleCoveragex_IZ(nint jnienv, nint native__this, int value, sbyte native_invert)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool invert = native_invert != 0;
			iGL.GlSampleCoveragex(value, invert);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlSampleCoveragex(int value, bool invert)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(value);
		ptr[1] = new JniArgumentValue(invert ? ((sbyte)1) : ((sbyte)0));
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glSampleCoveragex.(IZ)V", this, ptr);
	}

	private static Delegate GetGlScalef_FFFHandler()
	{
		return new _JniMarshal_PPFFF_V(n_GlScalef_FFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlScalef_FFF(nint jnienv, nint native__this, float x, float y, float z)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlScalef(x, y, z);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlScalef(float x, float y, float z)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		ptr[2] = new JniArgumentValue(z);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glScalef.(FFF)V", this, ptr);
	}

	private static Delegate GetGlScalex_IIIHandler()
	{
		return new _JniMarshal_PPIII_V(n_GlScalex_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlScalex_III(nint jnienv, nint native__this, int x, int y, int z)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlScalex(x, y, z);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlScalex(int x, int y, int z)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		ptr[2] = new JniArgumentValue(z);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glScalex.(III)V", this, ptr);
	}

	private static Delegate GetGlScissor_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_V(n_GlScissor_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlScissor_IIII(nint jnienv, nint native__this, int x, int y, int width, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlScissor(x, y, width, height);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlScissor(int x, int y, int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		ptr[2] = new JniArgumentValue(width);
		ptr[3] = new JniArgumentValue(height);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glScissor.(IIII)V", this, ptr);
	}

	private static Delegate GetGlShadeModel_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlShadeModel_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlShadeModel_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlShadeModel(mode);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlShadeModel(int mode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mode);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glShadeModel.(I)V", this, ptr);
	}

	private static Delegate GetGlStencilFunc_IIIHandler()
	{
		return new _JniMarshal_PPIII_V(n_GlStencilFunc_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlStencilFunc_III(nint jnienv, nint native__this, int func, int @ref, int mask)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlStencilFunc(func, @ref, mask);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlStencilFunc(int func, int @ref, int mask)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(func);
		ptr[1] = new JniArgumentValue(@ref);
		ptr[2] = new JniArgumentValue(mask);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glStencilFunc.(III)V", this, ptr);
	}

	private static Delegate GetGlStencilMask_IHandler()
	{
		return new _JniMarshal_PPI_V(n_GlStencilMask_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlStencilMask_I(nint jnienv, nint native__this, int mask)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlStencilMask(mask);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlStencilMask(int mask)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mask);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glStencilMask.(I)V", this, ptr);
	}

	private static Delegate GetGlStencilOp_IIIHandler()
	{
		return new _JniMarshal_PPIII_V(n_GlStencilOp_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlStencilOp_III(nint jnienv, nint native__this, int fail, int zfail, int zpass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlStencilOp(fail, zfail, zpass);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlStencilOp(int fail, int zfail, int zpass)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(fail);
		ptr[1] = new JniArgumentValue(zfail);
		ptr[2] = new JniArgumentValue(zpass);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glStencilOp.(III)V", this, ptr);
	}

	private static Delegate GetGlTexCoordPointer_IIILjava_nio_Buffer_Handler()
	{
		return new _JniMarshal_PPIIIL_V(n_GlTexCoordPointer_IIILjava_nio_Buffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexCoordPointer_IIILjava_nio_Buffer_(nint jnienv, nint native__this, int size, int type, int stride, nint native_pointer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Nio.Buffer pointer = Java.Lang.Object.GetObject<Java.Nio.Buffer>(native_pointer, JniHandleOwnership.DoNotTransfer);
			iGL.GlTexCoordPointer(size, type, stride, pointer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexCoordPointer(int size, int type, int stride, Java.Nio.Buffer? pointer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(size);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(stride);
			ptr[3] = new JniArgumentValue(pointer?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexCoordPointer.(IIILjava/nio/Buffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pointer);
		}
	}

	private static Delegate GetGlTexEnvf_IIFHandler()
	{
		return new _JniMarshal_PPIIF_V(n_GlTexEnvf_IIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexEnvf_IIF(nint jnienv, nint native__this, int target, int pname, float param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlTexEnvf(target, pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexEnvf(int target, int pname, float param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(target);
		ptr[1] = new JniArgumentValue(pname);
		ptr[2] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexEnvf.(IIF)V", this, ptr);
	}

	private static Delegate GetGlTexEnvfv_IIarrayFIHandler()
	{
		return new _JniMarshal_PPIILI_V(n_GlTexEnvfv_IIarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexEnvfv_IIarrayFI(nint jnienv, nint native__this, int target, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(float));
			iGL.GlTexEnvfv(target, pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexEnvfv(int target, int pname, float[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(target);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexEnvfv.(II[FI)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlTexEnvfv_IILjava_nio_FloatBuffer_Handler()
	{
		return new _JniMarshal_PPIIL_V(n_GlTexEnvfv_IILjava_nio_FloatBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexEnvfv_IILjava_nio_FloatBuffer_(nint jnienv, nint native__this, int target, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatBuffer floatBuffer = Java.Lang.Object.GetObject<FloatBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlTexEnvfv(target, pname, floatBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexEnvfv(int target, int pname, FloatBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(target);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexEnvfv.(IILjava/nio/FloatBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlTexEnvx_IIIHandler()
	{
		return new _JniMarshal_PPIII_V(n_GlTexEnvx_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexEnvx_III(nint jnienv, nint native__this, int target, int pname, int param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlTexEnvx(target, pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexEnvx(int target, int pname, int param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(target);
		ptr[1] = new JniArgumentValue(pname);
		ptr[2] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexEnvx.(III)V", this, ptr);
	}

	private static Delegate GetGlTexEnvxv_IIarrayIIHandler()
	{
		return new _JniMarshal_PPIILI_V(n_GlTexEnvxv_IIarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexEnvxv_IIarrayII(nint jnienv, nint native__this, int target, int pname, nint native__params, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native__params, JniHandleOwnership.DoNotTransfer, typeof(int));
			iGL.GlTexEnvxv(target, pname, array, offset);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__params);
			}
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexEnvxv(int target, int pname, int[]? @params, int offset)
	{
		nint num = JNIEnv.NewArray(@params);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(target);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(offset);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexEnvxv.(II[II)V", this, ptr);
		}
		finally
		{
			if (@params != null)
			{
				JNIEnv.CopyArray(num, @params);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlTexEnvxv_IILjava_nio_IntBuffer_Handler()
	{
		return new _JniMarshal_PPIIL_V(n_GlTexEnvxv_IILjava_nio_IntBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexEnvxv_IILjava_nio_IntBuffer_(nint jnienv, nint native__this, int target, int pname, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IntBuffer intBuffer = Java.Lang.Object.GetObject<IntBuffer>(native__params, JniHandleOwnership.DoNotTransfer);
			iGL.GlTexEnvxv(target, pname, intBuffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexEnvxv(int target, int pname, IntBuffer? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(target);
			ptr[1] = new JniArgumentValue(pname);
			ptr[2] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexEnvxv.(IILjava/nio/IntBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetGlTexImage2D_IIIIIIIILjava_nio_Buffer_Handler()
	{
		return new _JniMarshal_PPIIIIIIIIL_V(n_GlTexImage2D_IIIIIIIILjava_nio_Buffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexImage2D_IIIIIIIILjava_nio_Buffer_(nint jnienv, nint native__this, int target, int level, int internalformat, int width, int height, int border, int format, int type, nint native_pixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Nio.Buffer pixels = Java.Lang.Object.GetObject<Java.Nio.Buffer>(native_pixels, JniHandleOwnership.DoNotTransfer);
			iGL.GlTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, Java.Nio.Buffer? pixels)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(target);
			ptr[1] = new JniArgumentValue(level);
			ptr[2] = new JniArgumentValue(internalformat);
			ptr[3] = new JniArgumentValue(width);
			ptr[4] = new JniArgumentValue(height);
			ptr[5] = new JniArgumentValue(border);
			ptr[6] = new JniArgumentValue(format);
			ptr[7] = new JniArgumentValue(type);
			ptr[8] = new JniArgumentValue(pixels?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexImage2D.(IIIIIIIILjava/nio/Buffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pixels);
		}
	}

	private static Delegate GetGlTexParameterf_IIFHandler()
	{
		return new _JniMarshal_PPIIF_V(n_GlTexParameterf_IIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexParameterf_IIF(nint jnienv, nint native__this, int target, int pname, float param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlTexParameterf(target, pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexParameterf(int target, int pname, float param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(target);
		ptr[1] = new JniArgumentValue(pname);
		ptr[2] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexParameterf.(IIF)V", this, ptr);
	}

	private static Delegate GetGlTexParameterx_IIIHandler()
	{
		return new _JniMarshal_PPIII_V(n_GlTexParameterx_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexParameterx_III(nint jnienv, nint native__this, int target, int pname, int param)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlTexParameterx(target, pname, param);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexParameterx(int target, int pname, int param)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(target);
		ptr[1] = new JniArgumentValue(pname);
		ptr[2] = new JniArgumentValue(param);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexParameterx.(III)V", this, ptr);
	}

	private static Delegate GetGlTexSubImage2D_IIIIIIIILjava_nio_Buffer_Handler()
	{
		return new _JniMarshal_PPIIIIIIIIL_V(n_GlTexSubImage2D_IIIIIIIILjava_nio_Buffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTexSubImage2D_IIIIIIIILjava_nio_Buffer_(nint jnienv, nint native__this, int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, nint native_pixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Nio.Buffer pixels = Java.Lang.Object.GetObject<Java.Nio.Buffer>(native_pixels, JniHandleOwnership.DoNotTransfer);
			iGL.GlTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, Java.Nio.Buffer? pixels)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(target);
			ptr[1] = new JniArgumentValue(level);
			ptr[2] = new JniArgumentValue(xoffset);
			ptr[3] = new JniArgumentValue(yoffset);
			ptr[4] = new JniArgumentValue(width);
			ptr[5] = new JniArgumentValue(height);
			ptr[6] = new JniArgumentValue(format);
			ptr[7] = new JniArgumentValue(type);
			ptr[8] = new JniArgumentValue(pixels?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTexSubImage2D.(IIIIIIIILjava/nio/Buffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pixels);
		}
	}

	private static Delegate GetGlTranslatef_FFFHandler()
	{
		return new _JniMarshal_PPFFF_V(n_GlTranslatef_FFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTranslatef_FFF(nint jnienv, nint native__this, float x, float y, float z)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlTranslatef(x, y, z);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTranslatef(float x, float y, float z)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		ptr[2] = new JniArgumentValue(z);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTranslatef.(FFF)V", this, ptr);
	}

	private static Delegate GetGlTranslatex_IIIHandler()
	{
		return new _JniMarshal_PPIII_V(n_GlTranslatex_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlTranslatex_III(nint jnienv, nint native__this, int x, int y, int z)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlTranslatex(x, y, z);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlTranslatex(int x, int y, int z)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		ptr[2] = new JniArgumentValue(z);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glTranslatex.(III)V", this, ptr);
	}

	private static Delegate GetGlVertexPointer_IIILjava_nio_Buffer_Handler()
	{
		return new _JniMarshal_PPIIIL_V(n_GlVertexPointer_IIILjava_nio_Buffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlVertexPointer_IIILjava_nio_Buffer_(nint jnienv, nint native__this, int size, int type, int stride, nint native_pointer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IGL10? iGL = Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Nio.Buffer pointer = Java.Lang.Object.GetObject<Java.Nio.Buffer>(native_pointer, JniHandleOwnership.DoNotTransfer);
			iGL.GlVertexPointer(size, type, stride, pointer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlVertexPointer(int size, int type, int stride, Java.Nio.Buffer? pointer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(size);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(stride);
			ptr[3] = new JniArgumentValue(pointer?.Handle ?? IntPtr.Zero);
			_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glVertexPointer.(IIILjava/nio/Buffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pointer);
		}
	}

	private static Delegate GetGlViewport_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_V(n_GlViewport_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GlViewport_IIII(nint jnienv, nint native__this, int x, int y, int width, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GlViewport(x, y, width, height);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void GlViewport(int x, int y, int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		ptr[2] = new JniArgumentValue(width);
		ptr[3] = new JniArgumentValue(height);
		_members_javax_microedition_khronos_opengles_GL10.InstanceMethods.InvokeAbstractVoidMethod("glViewport.(IIII)V", this, ptr);
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
