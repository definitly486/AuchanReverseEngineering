package crc6459efab142bb48047;

import android.view.MotionEvent;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class HorizontalSwipeTouchListener extends RecyclerView.SimpleOnItemTouchListener implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_onInterceptTouchEvent(RecyclerView recyclerView, MotionEvent motionEvent);

    public HorizontalSwipeTouchListener() {
        if (getClass() == HorizontalSwipeTouchListener.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.HorizontalSwipeTouchListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.SimpleOnItemTouchListener, androidx.recyclerview.widget.RecyclerView.OnItemTouchListener
    public boolean onInterceptTouchEvent(RecyclerView recyclerView, MotionEvent motionEvent) {
        return n_onInterceptTouchEvent(recyclerView, motionEvent);
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
