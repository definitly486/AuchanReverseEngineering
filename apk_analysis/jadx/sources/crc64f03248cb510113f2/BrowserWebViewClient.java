package crc64f03248cb510113f2;

import android.webkit.WebResourceRequest;
import android.webkit.WebView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class BrowserWebViewClient extends CustomWebViewClient implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_shouldOverrideUrlLoading(WebView webView, WebResourceRequest webResourceRequest);

    private native boolean n_shouldOverrideUrlLoading(WebView webView, String str);

    public BrowserWebViewClient() {
        if (getClass() == BrowserWebViewClient.class) {
            TypeManager.Activate("Auchan.Android.Base.BrowserWebViewClient, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.webkit.WebViewClient
    public boolean shouldOverrideUrlLoading(WebView webView, String str) {
        return n_shouldOverrideUrlLoading(webView, str);
    }

    @Override // crc64f03248cb510113f2.CustomWebViewClient, android.webkit.WebViewClient
    public boolean shouldOverrideUrlLoading(WebView webView, WebResourceRequest webResourceRequest) {
        return n_shouldOverrideUrlLoading(webView, webResourceRequest);
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
