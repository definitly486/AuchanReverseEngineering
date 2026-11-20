package crc640f0d77cc801286dd;

import android.view.GestureDetector;
import android.view.MotionEvent;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ZoomableImageSliderFragment_PhotoViewDoubleTapListener implements IGCUserPeer, GestureDetector.OnDoubleTapListener {
    private ArrayList refList;

    private native boolean n_onDoubleTap(MotionEvent motionEvent);

    private native boolean n_onDoubleTapEvent(MotionEvent motionEvent);

    private native boolean n_onSingleTapConfirmed(MotionEvent motionEvent);

    public ZoomableImageSliderFragment_PhotoViewDoubleTapListener() {
        if (getClass() == ZoomableImageSliderFragment_PhotoViewDoubleTapListener.class) {
            TypeManager.Activate("Auchan.Android.Controls.ZoomableImageSlider.ZoomableImageSliderFragment+PhotoViewDoubleTapListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.view.GestureDetector.OnDoubleTapListener
    public boolean onDoubleTap(MotionEvent motionEvent) {
        return n_onDoubleTap(motionEvent);
    }

    @Override // android.view.GestureDetector.OnDoubleTapListener
    public boolean onDoubleTapEvent(MotionEvent motionEvent) {
        return n_onDoubleTapEvent(motionEvent);
    }

    @Override // android.view.GestureDetector.OnDoubleTapListener
    public boolean onSingleTapConfirmed(MotionEvent motionEvent) {
        return n_onSingleTapConfirmed(motionEvent);
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
