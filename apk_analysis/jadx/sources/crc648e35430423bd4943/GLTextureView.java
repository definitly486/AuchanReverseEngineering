package crc648e35430423bd4943;

import android.content.Context;
import android.graphics.SurfaceTexture;
import android.util.AttributeSet;
import android.view.TextureView;
import android.view.View;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class GLTextureView extends TextureView implements IGCUserPeer, TextureView.SurfaceTextureListener, View.OnLayoutChangeListener {
    private ArrayList refList;

    private native void n_onAttachedToWindow();

    private native void n_onDetachedFromWindow();

    private native void n_onLayoutChange(View view, int i, int i2, int i3, int i4, int i5, int i6, int i7, int i8);

    private native void n_onSurfaceTextureAvailable(SurfaceTexture surfaceTexture, int i, int i2);

    private native boolean n_onSurfaceTextureDestroyed(SurfaceTexture surfaceTexture);

    private native void n_onSurfaceTextureSizeChanged(SurfaceTexture surfaceTexture, int i, int i2);

    private native void n_onSurfaceTextureUpdated(SurfaceTexture surfaceTexture);

    public GLTextureView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == GLTextureView.class) {
            TypeManager.Activate("SkiaSharp.Views.Android.GLTextureView, SkiaSharp.Views.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public GLTextureView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == GLTextureView.class) {
            TypeManager.Activate("SkiaSharp.Views.Android.GLTextureView, SkiaSharp.Views.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public GLTextureView(Context context) {
        super(context);
        if (getClass() == GLTextureView.class) {
            TypeManager.Activate("SkiaSharp.Views.Android.GLTextureView, SkiaSharp.Views.Android", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // android.view.TextureView, android.view.View
    public void onAttachedToWindow() {
        n_onAttachedToWindow();
    }

    @Override // android.view.View
    public void onDetachedFromWindow() {
        n_onDetachedFromWindow();
    }

    @Override // android.view.TextureView.SurfaceTextureListener
    public void onSurfaceTextureAvailable(SurfaceTexture surfaceTexture, int i, int i2) {
        n_onSurfaceTextureAvailable(surfaceTexture, i, i2);
    }

    @Override // android.view.TextureView.SurfaceTextureListener
    public boolean onSurfaceTextureDestroyed(SurfaceTexture surfaceTexture) {
        return n_onSurfaceTextureDestroyed(surfaceTexture);
    }

    @Override // android.view.TextureView.SurfaceTextureListener
    public void onSurfaceTextureSizeChanged(SurfaceTexture surfaceTexture, int i, int i2) {
        n_onSurfaceTextureSizeChanged(surfaceTexture, i, i2);
    }

    @Override // android.view.TextureView.SurfaceTextureListener
    public void onSurfaceTextureUpdated(SurfaceTexture surfaceTexture) {
        n_onSurfaceTextureUpdated(surfaceTexture);
    }

    @Override // android.view.View.OnLayoutChangeListener
    public void onLayoutChange(View view, int i, int i2, int i3, int i4, int i5, int i6, int i7, int i8) {
        n_onLayoutChange(view, i, i2, i3, i4, i5, i6, i7, i8);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
