package crc64f03248cb510113f2;

import android.os.Message;
import android.webkit.WebChromeClient;
import android.webkit.WebView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ExternalLinkWebChromeClient extends WebChromeClient implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_onCreateWindow(WebView webView, boolean z, boolean z2, Message message);

    public ExternalLinkWebChromeClient() {
        if (getClass() == ExternalLinkWebChromeClient.class) {
            TypeManager.Activate("Auchan.Android.Base.ExternalLinkWebChromeClient, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.webkit.WebChromeClient
    public boolean onCreateWindow(WebView webView, boolean z, boolean z2, Message message) {
        return n_onCreateWindow(webView, z, z2, message);
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
