package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.plugins.PluginErrorDetails;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.gf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0284gf implements Runnable {
    public final /* synthetic */ PluginErrorDetails a;
    public final /* synthetic */ C0361jf b;

    public RunnableC0284gf(C0361jf c0361jf, PluginErrorDetails pluginErrorDetails) {
        this.b = c0361jf;
        this.a = pluginErrorDetails;
    }

    @Override // java.lang.Runnable
    public final void run() {
        ((InterfaceC0435mb) this.b.d.get()).getPluginExtension().reportUnhandledException(this.a);
    }
}
