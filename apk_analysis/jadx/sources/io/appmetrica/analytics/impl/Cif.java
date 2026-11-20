package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.plugins.PluginErrorDetails;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.if, reason: invalid class name */
/* JADX INFO: loaded from: classes3.dex */
public final class Cif implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ String b;
    public final /* synthetic */ PluginErrorDetails c;
    public final /* synthetic */ C0361jf d;

    public Cif(C0361jf c0361jf, String str, String str2, PluginErrorDetails pluginErrorDetails) {
        this.d = c0361jf;
        this.a = str;
        this.b = str2;
        this.c = pluginErrorDetails;
    }

    @Override // java.lang.Runnable
    public final void run() {
        ((InterfaceC0435mb) this.d.d.get()).getPluginExtension().reportError(this.a, this.b, this.c);
    }
}
