package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.plugins.PluginErrorDetails;

/* JADX INFO: loaded from: classes3.dex */
public final class Qj implements InterfaceC0409lb {
    public final /* synthetic */ PluginErrorDetails a;

    public Qj(PluginErrorDetails pluginErrorDetails) {
        this.a = pluginErrorDetails;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.getPluginExtension().reportUnhandledException(this.a);
    }
}
