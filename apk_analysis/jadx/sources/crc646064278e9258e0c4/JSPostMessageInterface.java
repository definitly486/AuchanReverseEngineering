package crc646064278e9258e0c4;

import android.webkit.JavascriptInterface;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class JSPostMessageInterface implements IGCUserPeer {
    public static final String __md_methods = "n_OnPostMessage:(Ljava/lang/String;)V:__export__\n";
    private ArrayList refList;

    private native void n_OnPostMessage(String str);

    static {
        Runtime.register("Auchan.Android.Common.JSPostMessageInterface, Auchan.Android.Net", JSPostMessageInterface.class, __md_methods);
    }

    public JSPostMessageInterface() {
        if (getClass() == JSPostMessageInterface.class) {
            TypeManager.Activate("Auchan.Android.Common.JSPostMessageInterface, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @JavascriptInterface
    public void OnPostMessage(String str) {
        n_OnPostMessage(str);
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
