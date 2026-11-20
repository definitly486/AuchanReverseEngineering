package io.appmetrica.analytics.internal.js;

import android.webkit.JavascriptInterface;
import io.appmetrica.analytics.impl.C0659v1;

/* JADX INFO: loaded from: classes3.dex */
public class AppMetricaJsInterface {
    private final C0659v1 a;

    public AppMetricaJsInterface(C0659v1 c0659v1) {
        this.a = c0659v1;
    }

    @JavascriptInterface
    public void reportEvent(String str, String str2) {
        this.a.d(str, str2);
    }
}
