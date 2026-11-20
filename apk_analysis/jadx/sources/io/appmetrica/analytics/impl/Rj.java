package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.plugins.PluginErrorDetails;

/* JADX INFO: loaded from: classes3.dex */
public final class Rj implements InterfaceC0409lb {
    public final /* synthetic */ PluginErrorDetails a;
    public final /* synthetic */ String b;

    public Rj(PluginErrorDetails pluginErrorDetails, String str) {
        this.a = pluginErrorDetails;
        this.b = str;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.getPluginExtension().reportError(this.a, this.b);
    }
}
