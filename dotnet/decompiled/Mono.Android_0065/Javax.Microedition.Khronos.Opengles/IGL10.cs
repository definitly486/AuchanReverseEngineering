using System;
using Android.Runtime;
using Java.Interop;
using Java.Nio;

namespace Javax.Microedition.Khronos.Opengles;

[Register("javax/microedition/khronos/opengles/GL10", "", "Javax.Microedition.Khronos.Opengles.IGL10Invoker")]
public interface IGL10 : IGL, IJavaObject, IDisposable, IJavaPeerable
{
	void GlActiveTexture(int texture);

	void GlAlphaFunc(int func, float @ref);

	void GlAlphaFuncx(int func, int @ref);

	void GlBindTexture(int target, int texture);

	void GlBlendFunc(int sfactor, int dfactor);

	void GlClear(int mask);

	void GlClearColor(float red, float green, float blue, float alpha);

	void GlClearColorx(int red, int green, int blue, int alpha);

	void GlClearDepthf(float depth);

	void GlClearDepthx(int depth);

	void GlClearStencil(int s);

	void GlClientActiveTexture(int texture);

	void GlColor4f(float red, float green, float blue, float alpha);

	void GlColor4x(int red, int green, int blue, int alpha);

	void GlColorMask(bool red, bool green, bool blue, bool alpha);

	void GlColorPointer(int size, int type, int stride, Java.Nio.Buffer? pointer);

	void GlCompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, int imageSize, Java.Nio.Buffer? data);

	void GlCompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int imageSize, Java.Nio.Buffer? data);

	void GlCopyTexImage2D(int target, int level, int internalformat, int x, int y, int width, int height, int border);

	void GlCopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height);

	void GlCullFace(int mode);

	void GlDeleteTextures(int n, int[]? textures, int offset);

	void GlDeleteTextures(int n, IntBuffer? textures);

	void GlDepthFunc(int func);

	void GlDepthMask(bool flag);

	void GlDepthRangef(float zNear, float zFar);

	void GlDepthRangex(int zNear, int zFar);

	void GlDisable(int cap);

	void GlDisableClientState(int array);

	void GlDrawArrays(int mode, int first, int count);

	void GlDrawElements(int mode, int count, int type, Java.Nio.Buffer? indices);

	void GlEnable(int cap);

	void GlEnableClientState(int array);

	void GlFinish();

	void GlFlush();

	void GlFogf(int pname, float param);

	void GlFogfv(int pname, float[]? @params, int offset);

	void GlFogfv(int pname, FloatBuffer? @params);

	void GlFogx(int pname, int param);

	void GlFogxv(int pname, int[]? @params, int offset);

	void GlFogxv(int pname, IntBuffer? @params);

	void GlFrontFace(int mode);

	void GlFrustumf(float left, float right, float bottom, float top, float zNear, float zFar);

	void GlFrustumx(int left, int right, int bottom, int top, int zNear, int zFar);

	void GlGenTextures(int n, int[]? textures, int offset);

	void GlGenTextures(int n, IntBuffer? textures);

	int GlGetError();

	void GlGetIntegerv(int pname, int[]? @params, int offset);

	void GlGetIntegerv(int pname, IntBuffer? @params);

	string? GlGetString(int name);

	void GlHint(int target, int mode);

	void GlLightf(int light, int pname, float param);

	void GlLightfv(int light, int pname, float[]? @params, int offset);

	void GlLightfv(int light, int pname, FloatBuffer? @params);

	void GlLightModelf(int pname, float param);

	void GlLightModelfv(int pname, float[]? @params, int offset);

	void GlLightModelfv(int pname, FloatBuffer? @params);

	void GlLightModelx(int pname, int param);

	void GlLightModelxv(int pname, int[]? @params, int offset);

	void GlLightModelxv(int pname, IntBuffer? @params);

	void GlLightx(int light, int pname, int param);

	void GlLightxv(int light, int pname, int[]? @params, int offset);

	void GlLightxv(int light, int pname, IntBuffer? @params);

	void GlLineWidth(float width);

	void GlLineWidthx(int width);

	void GlLoadIdentity();

	void GlLoadMatrixf(float[]? m, int offset);

	void GlLoadMatrixf(FloatBuffer? m);

	void GlLoadMatrixx(int[]? m, int offset);

	void GlLoadMatrixx(IntBuffer? m);

	void GlLogicOp(int opcode);

	void GlMaterialf(int face, int pname, float param);

	void GlMaterialfv(int face, int pname, float[]? @params, int offset);

	void GlMaterialfv(int face, int pname, FloatBuffer? @params);

	void GlMaterialx(int face, int pname, int param);

	void GlMaterialxv(int face, int pname, int[]? @params, int offset);

	void GlMaterialxv(int face, int pname, IntBuffer? @params);

	void GlMatrixMode(int mode);

	void GlMultiTexCoord4f(int target, float s, float t, float r, float q);

	void GlMultiTexCoord4x(int target, int s, int t, int r, int q);

	void GlMultMatrixf(float[]? m, int offset);

	void GlMultMatrixf(FloatBuffer? m);

	void GlMultMatrixx(int[]? m, int offset);

	void GlMultMatrixx(IntBuffer? m);

	void GlNormal3f(float nx, float ny, float nz);

	void GlNormal3x(int nx, int ny, int nz);

	void GlNormalPointer(int type, int stride, Java.Nio.Buffer? pointer);

	void GlOrthof(float left, float right, float bottom, float top, float zNear, float zFar);

	void GlOrthox(int left, int right, int bottom, int top, int zNear, int zFar);

	void GlPixelStorei(int pname, int param);

	void GlPointSize(float size);

	void GlPointSizex(int size);

	void GlPolygonOffset(float factor, float units);

	void GlPolygonOffsetx(int factor, int units);

	void GlPopMatrix();

	void GlPushMatrix();

	void GlReadPixels(int x, int y, int width, int height, int format, int type, Java.Nio.Buffer? pixels);

	void GlRotatef(float angle, float x, float y, float z);

	void GlRotatex(int angle, int x, int y, int z);

	void GlSampleCoverage(float value, bool invert);

	void GlSampleCoveragex(int value, bool invert);

	void GlScalef(float x, float y, float z);

	void GlScalex(int x, int y, int z);

	void GlScissor(int x, int y, int width, int height);

	void GlShadeModel(int mode);

	void GlStencilFunc(int func, int @ref, int mask);

	void GlStencilMask(int mask);

	void GlStencilOp(int fail, int zfail, int zpass);

	void GlTexCoordPointer(int size, int type, int stride, Java.Nio.Buffer? pointer);

	void GlTexEnvf(int target, int pname, float param);

	void GlTexEnvfv(int target, int pname, float[]? @params, int offset);

	void GlTexEnvfv(int target, int pname, FloatBuffer? @params);

	void GlTexEnvx(int target, int pname, int param);

	void GlTexEnvxv(int target, int pname, int[]? @params, int offset);

	void GlTexEnvxv(int target, int pname, IntBuffer? @params);

	void GlTexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, Java.Nio.Buffer? pixels);

	void GlTexParameterf(int target, int pname, float param);

	void GlTexParameterx(int target, int pname, int param);

	void GlTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, Java.Nio.Buffer? pixels);

	void GlTranslatef(float x, float y, float z);

	void GlTranslatex(int x, int y, int z);

	void GlVertexPointer(int size, int type, int stride, Java.Nio.Buffer? pointer);

	void GlViewport(int x, int y, int width, int height);
}
