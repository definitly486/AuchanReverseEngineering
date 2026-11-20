package crc646e7dac6304ae8ce3;

import android.webkit.JavascriptInterface;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class WebAppInterface implements IGCUserPeer {
    public static final String __md_methods = "n_AddProduct:(Ljava/lang/String;)V:__export__\nn_OpenProduct:(Ljava/lang/String;)V:__export__\n";
    private ArrayList refList;

    private native void n_AddProduct(String str);

    private native void n_OpenProduct(String str);

    static {
        Runtime.register("Auchan.Android.Streams.WebAppInterface, Auchan.Android.Net", WebAppInterface.class, __md_methods);
    }

    public WebAppInterface() {
        if (getClass() == WebAppInterface.class) {
            TypeManager.Activate("Auchan.Android.Streams.WebAppInterface, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @JavascriptInterface
    public void addProduct(String str) {
        n_AddProduct(str);
    }

    @JavascriptInterface
    public void openProduct(String str) {
        n_OpenProduct(str);
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
