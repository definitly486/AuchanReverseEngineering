using System;
using Android.Runtime;
using Java.Interop;
using Java.Nio;

namespace Javax.Microedition.Khronos.Opengles;

[Register("javax/microedition/khronos/opengles/GL10", "", "Javax.Microedition.Khronos.Opengles.IGL10Invoker")]
public interface IGL10 : IGL, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("glActiveTexture", "(I)V", "GetGlActiveTexture_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlActiveTexture(int texture);

	[Register("glAlphaFunc", "(IF)V", "GetGlAlphaFunc_IFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlAlphaFunc(int func, float @ref);

	[Register("glAlphaFuncx", "(II)V", "GetGlAlphaFuncx_IIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlAlphaFuncx(int func, int @ref);

	[Register("glBindTexture", "(II)V", "GetGlBindTexture_IIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlBindTexture(int target, int texture);

	[Register("glBlendFunc", "(II)V", "GetGlBlendFunc_IIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlBlendFunc(int sfactor, int dfactor);

	[Register("glClear", "(I)V", "GetGlClear_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlClear(int mask);

	[Register("glClearColor", "(FFFF)V", "GetGlClearColor_FFFFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlClearColor(float red, float green, float blue, float alpha);

	[Register("glClearColorx", "(IIII)V", "GetGlClearColorx_IIIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlClearColorx(int red, int green, int blue, int alpha);

	[Register("glClearDepthf", "(F)V", "GetGlClearDepthf_FHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlClearDepthf(float depth);

	[Register("glClearDepthx", "(I)V", "GetGlClearDepthx_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlClearDepthx(int depth);

	[Register("glClearStencil", "(I)V", "GetGlClearStencil_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlClearStencil(int s);

	[Register("glClientActiveTexture", "(I)V", "GetGlClientActiveTexture_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlClientActiveTexture(int texture);

	[Register("glColor4f", "(FFFF)V", "GetGlColor4f_FFFFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlColor4f(float red, float green, float blue, float alpha);

	[Register("glColor4x", "(IIII)V", "GetGlColor4x_IIIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlColor4x(int red, int green, int blue, int alpha);

	[Register("glColorMask", "(ZZZZ)V", "GetGlColorMask_ZZZZHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlColorMask(bool red, bool green, bool blue, bool alpha);

	[Register("glColorPointer", "(IIILjava/nio/Buffer;)V", "GetGlColorPointer_IIILjava_nio_Buffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlColorPointer(int size, int type, int stride, Java.Nio.Buffer? pointer);

	[Register("glCompressedTexImage2D", "(IIIIIIILjava/nio/Buffer;)V", "GetGlCompressedTexImage2D_IIIIIIILjava_nio_Buffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlCompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, int imageSize, Java.Nio.Buffer? data);

	[Register("glCompressedTexSubImage2D", "(IIIIIIIILjava/nio/Buffer;)V", "GetGlCompressedTexSubImage2D_IIIIIIIILjava_nio_Buffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlCompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int imageSize, Java.Nio.Buffer? data);

	[Register("glCopyTexImage2D", "(IIIIIIII)V", "GetGlCopyTexImage2D_IIIIIIIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlCopyTexImage2D(int target, int level, int internalformat, int x, int y, int width, int height, int border);

	[Register("glCopyTexSubImage2D", "(IIIIIIII)V", "GetGlCopyTexSubImage2D_IIIIIIIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlCopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height);

	[Register("glCullFace", "(I)V", "GetGlCullFace_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlCullFace(int mode);

	[Register("glDeleteTextures", "(I[II)V", "GetGlDeleteTextures_IarrayIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlDeleteTextures(int n, int[]? textures, int offset);

	[Register("glDeleteTextures", "(ILjava/nio/IntBuffer;)V", "GetGlDeleteTextures_ILjava_nio_IntBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlDeleteTextures(int n, IntBuffer? textures);

	[Register("glDepthFunc", "(I)V", "GetGlDepthFunc_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlDepthFunc(int func);

	[Register("glDepthMask", "(Z)V", "GetGlDepthMask_ZHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlDepthMask(bool flag);

	[Register("glDepthRangef", "(FF)V", "GetGlDepthRangef_FFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlDepthRangef(float zNear, float zFar);

	[Register("glDepthRangex", "(II)V", "GetGlDepthRangex_IIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlDepthRangex(int zNear, int zFar);

	[Register("glDisable", "(I)V", "GetGlDisable_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlDisable(int cap);

	[Register("glDisableClientState", "(I)V", "GetGlDisableClientState_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlDisableClientState(int array);

	[Register("glDrawArrays", "(III)V", "GetGlDrawArrays_IIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlDrawArrays(int mode, int first, int count);

	[Register("glDrawElements", "(IIILjava/nio/Buffer;)V", "GetGlDrawElements_IIILjava_nio_Buffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlDrawElements(int mode, int count, int type, Java.Nio.Buffer? indices);

	[Register("glEnable", "(I)V", "GetGlEnable_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlEnable(int cap);

	[Register("glEnableClientState", "(I)V", "GetGlEnableClientState_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlEnableClientState(int array);

	[Register("glFinish", "()V", "GetGlFinishHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFinish();

	[Register("glFlush", "()V", "GetGlFlushHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFlush();

	[Register("glFogf", "(IF)V", "GetGlFogf_IFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFogf(int pname, float param);

	[Register("glFogfv", "(I[FI)V", "GetGlFogfv_IarrayFIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFogfv(int pname, float[]? @params, int offset);

	[Register("glFogfv", "(ILjava/nio/FloatBuffer;)V", "GetGlFogfv_ILjava_nio_FloatBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFogfv(int pname, FloatBuffer? @params);

	[Register("glFogx", "(II)V", "GetGlFogx_IIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFogx(int pname, int param);

	[Register("glFogxv", "(I[II)V", "GetGlFogxv_IarrayIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFogxv(int pname, int[]? @params, int offset);

	[Register("glFogxv", "(ILjava/nio/IntBuffer;)V", "GetGlFogxv_ILjava_nio_IntBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFogxv(int pname, IntBuffer? @params);

	[Register("glFrontFace", "(I)V", "GetGlFrontFace_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFrontFace(int mode);

	[Register("glFrustumf", "(FFFFFF)V", "GetGlFrustumf_FFFFFFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFrustumf(float left, float right, float bottom, float top, float zNear, float zFar);

	[Register("glFrustumx", "(IIIIII)V", "GetGlFrustumx_IIIIIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlFrustumx(int left, int right, int bottom, int top, int zNear, int zFar);

	[Register("glGenTextures", "(I[II)V", "GetGlGenTextures_IarrayIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlGenTextures(int n, int[]? textures, int offset);

	[Register("glGenTextures", "(ILjava/nio/IntBuffer;)V", "GetGlGenTextures_ILjava_nio_IntBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlGenTextures(int n, IntBuffer? textures);

	[Register("glGetError", "()I", "GetGlGetErrorHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GlGetError();

	[Register("glGetIntegerv", "(I[II)V", "GetGlGetIntegerv_IarrayIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlGetIntegerv(int pname, int[]? @params, int offset);

	[Register("glGetIntegerv", "(ILjava/nio/IntBuffer;)V", "GetGlGetIntegerv_ILjava_nio_IntBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlGetIntegerv(int pname, IntBuffer? @params);

	[Register("glGetString", "(I)Ljava/lang/String;", "GetGlGetString_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GlGetString(int name);

	[Register("glHint", "(II)V", "GetGlHint_IIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlHint(int target, int mode);

	[Register("glLightf", "(IIF)V", "GetGlLightf_IIFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightf(int light, int pname, float param);

	[Register("glLightfv", "(II[FI)V", "GetGlLightfv_IIarrayFIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightfv(int light, int pname, float[]? @params, int offset);

	[Register("glLightfv", "(IILjava/nio/FloatBuffer;)V", "GetGlLightfv_IILjava_nio_FloatBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightfv(int light, int pname, FloatBuffer? @params);

	[Register("glLightModelf", "(IF)V", "GetGlLightModelf_IFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightModelf(int pname, float param);

	[Register("glLightModelfv", "(I[FI)V", "GetGlLightModelfv_IarrayFIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightModelfv(int pname, float[]? @params, int offset);

	[Register("glLightModelfv", "(ILjava/nio/FloatBuffer;)V", "GetGlLightModelfv_ILjava_nio_FloatBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightModelfv(int pname, FloatBuffer? @params);

	[Register("glLightModelx", "(II)V", "GetGlLightModelx_IIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightModelx(int pname, int param);

	[Register("glLightModelxv", "(I[II)V", "GetGlLightModelxv_IarrayIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightModelxv(int pname, int[]? @params, int offset);

	[Register("glLightModelxv", "(ILjava/nio/IntBuffer;)V", "GetGlLightModelxv_ILjava_nio_IntBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightModelxv(int pname, IntBuffer? @params);

	[Register("glLightx", "(III)V", "GetGlLightx_IIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightx(int light, int pname, int param);

	[Register("glLightxv", "(II[II)V", "GetGlLightxv_IIarrayIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightxv(int light, int pname, int[]? @params, int offset);

	[Register("glLightxv", "(IILjava/nio/IntBuffer;)V", "GetGlLightxv_IILjava_nio_IntBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLightxv(int light, int pname, IntBuffer? @params);

	[Register("glLineWidth", "(F)V", "GetGlLineWidth_FHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLineWidth(float width);

	[Register("glLineWidthx", "(I)V", "GetGlLineWidthx_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLineWidthx(int width);

	[Register("glLoadIdentity", "()V", "GetGlLoadIdentityHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLoadIdentity();

	[Register("glLoadMatrixf", "([FI)V", "GetGlLoadMatrixf_arrayFIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLoadMatrixf(float[]? m, int offset);

	[Register("glLoadMatrixf", "(Ljava/nio/FloatBuffer;)V", "GetGlLoadMatrixf_Ljava_nio_FloatBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLoadMatrixf(FloatBuffer? m);

	[Register("glLoadMatrixx", "([II)V", "GetGlLoadMatrixx_arrayIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLoadMatrixx(int[]? m, int offset);

	[Register("glLoadMatrixx", "(Ljava/nio/IntBuffer;)V", "GetGlLoadMatrixx_Ljava_nio_IntBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLoadMatrixx(IntBuffer? m);

	[Register("glLogicOp", "(I)V", "GetGlLogicOp_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlLogicOp(int opcode);

	[Register("glMaterialf", "(IIF)V", "GetGlMaterialf_IIFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMaterialf(int face, int pname, float param);

	[Register("glMaterialfv", "(II[FI)V", "GetGlMaterialfv_IIarrayFIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMaterialfv(int face, int pname, float[]? @params, int offset);

	[Register("glMaterialfv", "(IILjava/nio/FloatBuffer;)V", "GetGlMaterialfv_IILjava_nio_FloatBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMaterialfv(int face, int pname, FloatBuffer? @params);

	[Register("glMaterialx", "(III)V", "GetGlMaterialx_IIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMaterialx(int face, int pname, int param);

	[Register("glMaterialxv", "(II[II)V", "GetGlMaterialxv_IIarrayIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMaterialxv(int face, int pname, int[]? @params, int offset);

	[Register("glMaterialxv", "(IILjava/nio/IntBuffer;)V", "GetGlMaterialxv_IILjava_nio_IntBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMaterialxv(int face, int pname, IntBuffer? @params);

	[Register("glMatrixMode", "(I)V", "GetGlMatrixMode_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMatrixMode(int mode);

	[Register("glMultiTexCoord4f", "(IFFFF)V", "GetGlMultiTexCoord4f_IFFFFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMultiTexCoord4f(int target, float s, float t, float r, float q);

	[Register("glMultiTexCoord4x", "(IIIII)V", "GetGlMultiTexCoord4x_IIIIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMultiTexCoord4x(int target, int s, int t, int r, int q);

	[Register("glMultMatrixf", "([FI)V", "GetGlMultMatrixf_arrayFIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMultMatrixf(float[]? m, int offset);

	[Register("glMultMatrixf", "(Ljava/nio/FloatBuffer;)V", "GetGlMultMatrixf_Ljava_nio_FloatBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMultMatrixf(FloatBuffer? m);

	[Register("glMultMatrixx", "([II)V", "GetGlMultMatrixx_arrayIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMultMatrixx(int[]? m, int offset);

	[Register("glMultMatrixx", "(Ljava/nio/IntBuffer;)V", "GetGlMultMatrixx_Ljava_nio_IntBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlMultMatrixx(IntBuffer? m);

	[Register("glNormal3f", "(FFF)V", "GetGlNormal3f_FFFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlNormal3f(float nx, float ny, float nz);

	[Register("glNormal3x", "(III)V", "GetGlNormal3x_IIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlNormal3x(int nx, int ny, int nz);

	[Register("glNormalPointer", "(IILjava/nio/Buffer;)V", "GetGlNormalPointer_IILjava_nio_Buffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlNormalPointer(int type, int stride, Java.Nio.Buffer? pointer);

	[Register("glOrthof", "(FFFFFF)V", "GetGlOrthof_FFFFFFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlOrthof(float left, float right, float bottom, float top, float zNear, float zFar);

	[Register("glOrthox", "(IIIIII)V", "GetGlOrthox_IIIIIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlOrthox(int left, int right, int bottom, int top, int zNear, int zFar);

	[Register("glPixelStorei", "(II)V", "GetGlPixelStorei_IIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlPixelStorei(int pname, int param);

	[Register("glPointSize", "(F)V", "GetGlPointSize_FHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlPointSize(float size);

	[Register("glPointSizex", "(I)V", "GetGlPointSizex_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlPointSizex(int size);

	[Register("glPolygonOffset", "(FF)V", "GetGlPolygonOffset_FFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlPolygonOffset(float factor, float units);

	[Register("glPolygonOffsetx", "(II)V", "GetGlPolygonOffsetx_IIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlPolygonOffsetx(int factor, int units);

	[Register("glPopMatrix", "()V", "GetGlPopMatrixHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlPopMatrix();

	[Register("glPushMatrix", "()V", "GetGlPushMatrixHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlPushMatrix();

	[Register("glReadPixels", "(IIIIIILjava/nio/Buffer;)V", "GetGlReadPixels_IIIIIILjava_nio_Buffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlReadPixels(int x, int y, int width, int height, int format, int type, Java.Nio.Buffer? pixels);

	[Register("glRotatef", "(FFFF)V", "GetGlRotatef_FFFFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlRotatef(float angle, float x, float y, float z);

	[Register("glRotatex", "(IIII)V", "GetGlRotatex_IIIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlRotatex(int angle, int x, int y, int z);

	[Register("glSampleCoverage", "(FZ)V", "GetGlSampleCoverage_FZHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlSampleCoverage(float value, bool invert);

	[Register("glSampleCoveragex", "(IZ)V", "GetGlSampleCoveragex_IZHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlSampleCoveragex(int value, bool invert);

	[Register("glScalef", "(FFF)V", "GetGlScalef_FFFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlScalef(float x, float y, float z);

	[Register("glScalex", "(III)V", "GetGlScalex_IIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlScalex(int x, int y, int z);

	[Register("glScissor", "(IIII)V", "GetGlScissor_IIIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlScissor(int x, int y, int width, int height);

	[Register("glShadeModel", "(I)V", "GetGlShadeModel_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlShadeModel(int mode);

	[Register("glStencilFunc", "(III)V", "GetGlStencilFunc_IIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlStencilFunc(int func, int @ref, int mask);

	[Register("glStencilMask", "(I)V", "GetGlStencilMask_IHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlStencilMask(int mask);

	[Register("glStencilOp", "(III)V", "GetGlStencilOp_IIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlStencilOp(int fail, int zfail, int zpass);

	[Register("glTexCoordPointer", "(IIILjava/nio/Buffer;)V", "GetGlTexCoordPointer_IIILjava_nio_Buffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexCoordPointer(int size, int type, int stride, Java.Nio.Buffer? pointer);

	[Register("glTexEnvf", "(IIF)V", "GetGlTexEnvf_IIFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexEnvf(int target, int pname, float param);

	[Register("glTexEnvfv", "(II[FI)V", "GetGlTexEnvfv_IIarrayFIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexEnvfv(int target, int pname, float[]? @params, int offset);

	[Register("glTexEnvfv", "(IILjava/nio/FloatBuffer;)V", "GetGlTexEnvfv_IILjava_nio_FloatBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexEnvfv(int target, int pname, FloatBuffer? @params);

	[Register("glTexEnvx", "(III)V", "GetGlTexEnvx_IIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexEnvx(int target, int pname, int param);

	[Register("glTexEnvxv", "(II[II)V", "GetGlTexEnvxv_IIarrayIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexEnvxv(int target, int pname, int[]? @params, int offset);

	[Register("glTexEnvxv", "(IILjava/nio/IntBuffer;)V", "GetGlTexEnvxv_IILjava_nio_IntBuffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexEnvxv(int target, int pname, IntBuffer? @params);

	[Register("glTexImage2D", "(IIIIIIIILjava/nio/Buffer;)V", "GetGlTexImage2D_IIIIIIIILjava_nio_Buffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, Java.Nio.Buffer? pixels);

	[Register("glTexParameterf", "(IIF)V", "GetGlTexParameterf_IIFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexParameterf(int target, int pname, float param);

	[Register("glTexParameterx", "(III)V", "GetGlTexParameterx_IIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexParameterx(int target, int pname, int param);

	[Register("glTexSubImage2D", "(IIIIIIIILjava/nio/Buffer;)V", "GetGlTexSubImage2D_IIIIIIIILjava_nio_Buffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, Java.Nio.Buffer? pixels);

	[Register("glTranslatef", "(FFF)V", "GetGlTranslatef_FFFHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTranslatef(float x, float y, float z);

	[Register("glTranslatex", "(III)V", "GetGlTranslatex_IIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlTranslatex(int x, int y, int z);

	[Register("glVertexPointer", "(IIILjava/nio/Buffer;)V", "GetGlVertexPointer_IIILjava_nio_Buffer_Handler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlVertexPointer(int size, int type, int stride, Java.Nio.Buffer? pointer);

	[Register("glViewport", "(IIII)V", "GetGlViewport_IIIIHandler:Javax.Microedition.Khronos.Opengles.IGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void GlViewport(int x, int y, int width, int height);
}
