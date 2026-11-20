package mono.android.runtime;

import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class JavaObject implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_equals(Object obj);

    private native int n_hashCode();

    private native String n_toString();

    public JavaObject() {
        if (getClass() == JavaObject.class) {
            TypeManager.Activate("Android.Runtime.JavaObject, Mono.Android", "", this, new Object[0]);
        }
    }

    public boolean equals(Object obj) {
        return n_equals(obj);
    }

    public int hashCode() {
        return n_hashCode();
    }

    public String toString() {
        return n_toString();
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
