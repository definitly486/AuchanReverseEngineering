package mono.java.lang;

import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class RunnableImplementor implements IGCUserPeer, java.lang.Runnable {
    private ArrayList refList;

    private native void n_run();

    public RunnableImplementor() {
        if (getClass() == RunnableImplementor.class) {
            TypeManager.Activate("Java.Lang.Thread+RunnableImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // java.lang.Runnable
    public void run() {
        n_run();
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
