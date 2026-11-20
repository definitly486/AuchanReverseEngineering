package android.runtime;

import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class JavaProxyThrowable extends Error implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Android.Runtime.JavaProxyThrowable, Mono.Android", JavaProxyThrowable.class, "");
    }

    public JavaProxyThrowable(String str) {
        super(str);
        if (getClass() == JavaProxyThrowable.class) {
            TypeManager.Activate("Android.Runtime.JavaProxyThrowable, Mono.Android", "System.String, System.Private.CoreLib", this, new Object[]{str});
        }
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
