package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.plugins.PluginErrorDetails;

/* JADX INFO: loaded from: classes3.dex */
public final class Sj implements InterfaceC0409lb {
    public final /* synthetic */ String a;
    public final /* synthetic */ String b;
    public final /* synthetic */ PluginErrorDetails c;

    public Sj(String str, String str2, PluginErrorDetails pluginErrorDetails) {
        this.a = str;
        this.b = str2;
        this.c = pluginErrorDetails;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.getPluginExtension().reportError(this.a, this.b, this.c);
    }
}
