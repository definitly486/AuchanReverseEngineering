package mono.androidx.recyclerview.widget;

import android.view.MotionEvent;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class RecyclerView_OnItemTouchListenerImplementor implements IGCUserPeer, RecyclerView.OnItemTouchListener {
    private ArrayList refList;

    private native boolean n_onInterceptTouchEvent(RecyclerView recyclerView, MotionEvent motionEvent);

    private native void n_onRequestDisallowInterceptTouchEvent(boolean z);

    private native void n_onTouchEvent(RecyclerView recyclerView, MotionEvent motionEvent);

    public RecyclerView_OnItemTouchListenerImplementor() {
        if (getClass() == RecyclerView_OnItemTouchListenerImplementor.class) {
            TypeManager.Activate("AndroidX.RecyclerView.Widget.RecyclerView+IOnItemTouchListenerImplementor, Xamarin.AndroidX.RecyclerView", "", this, new Object[0]);
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.OnItemTouchListener
    public boolean onInterceptTouchEvent(RecyclerView recyclerView, MotionEvent motionEvent) {
        return n_onInterceptTouchEvent(recyclerView, motionEvent);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.OnItemTouchListener
    public void onRequestDisallowInterceptTouchEvent(boolean z) {
        n_onRequestDisallowInterceptTouchEvent(z);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.OnItemTouchListener
    public void onTouchEvent(RecyclerView recyclerView, MotionEvent motionEvent) {
        n_onTouchEvent(recyclerView, motionEvent);
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
