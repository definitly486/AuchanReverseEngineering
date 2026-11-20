package crc646e7dac6304ae8ce3;

import android.webkit.WebView;
import crc64f03248cb510113f2.CustomWebViewClient;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class StreamWebViewClient extends CustomWebViewClient implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_shouldOverrideUrlLoading(WebView webView, String str);

    public StreamWebViewClient() {
        if (getClass() == StreamWebViewClient.class) {
            TypeManager.Activate("Auchan.Android.Streams.StreamWebViewClient, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.webkit.WebViewClient
    public boolean shouldOverrideUrlLoading(WebView webView, String str) {
        return n_shouldOverrideUrlLoading(webView, str);
    }

    @Override // crc64f03248cb510113f2.CustomWebViewClient, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.CustomWebViewClient, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
