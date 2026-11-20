package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.plugins.PluginErrorDetails;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.hf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0310hf implements Runnable {
    public final /* synthetic */ PluginErrorDetails a;
    public final /* synthetic */ String b;
    public final /* synthetic */ C0361jf c;

    public RunnableC0310hf(C0361jf c0361jf, PluginErrorDetails pluginErrorDetails, String str) {
        this.c = c0361jf;
        this.a = pluginErrorDetails;
        this.b = str;
    }

    @Override // java.lang.Runnable
    public final void run() {
        ((InterfaceC0435mb) this.c.d.get()).getPluginExtension().reportError(this.a, this.b);
    }
}
