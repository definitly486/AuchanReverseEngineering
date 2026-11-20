package io.appmetrica.analytics.internal.js;

import android.webkit.JavascriptInterface;
import io.appmetrica.analytics.impl.C0659v1;

/* JADX INFO: loaded from: classes3.dex */
public class AppMetricaInitializerJsInterface {
    private final C0659v1 a;

    public AppMetricaInitializerJsInterface(C0659v1 c0659v1) {
        this.a = c0659v1;
    }

    @JavascriptInterface
    public void init(String str) {
        this.a.c(str);
    }
}
