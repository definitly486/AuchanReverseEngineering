package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.backport.Provider;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.plugins.IPluginReporter;
import io.appmetrica.analytics.plugins.PluginErrorDetails;
import java.util.Collection;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.jf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0361jf implements IPluginReporter {
    public final C0439mf a = new C0439mf();
    public final C0465nf b = new C0465nf();
    public final IHandlerExecutor c = C0584s4.l().g().a();
    public final Provider d;

    public C0361jf(Provider<InterfaceC0435mb> provider) {
        this.d = provider;
    }

    @Override // io.appmetrica.analytics.plugins.IPluginReporter
    public final void reportError(PluginErrorDetails pluginErrorDetails, String str) {
        C0439mf c0439mf = this.a;
        c0439mf.a.a(pluginErrorDetails);
        if (c0439mf.c.a((Collection<Object>) (pluginErrorDetails != null ? pluginErrorDetails.getStacktrace() : null)).a) {
            this.b.getClass();
            this.c.execute(new RunnableC0310hf(this, pluginErrorDetails, str));
        }
    }

    @Override // io.appmetrica.analytics.plugins.IPluginReporter
    public final void reportUnhandledException(PluginErrorDetails pluginErrorDetails) {
        this.a.a.a(pluginErrorDetails);
        this.b.getClass();
        this.c.execute(new RunnableC0284gf(this, pluginErrorDetails));
    }

    @Override // io.appmetrica.analytics.plugins.IPluginReporter
    public final void reportError(String str, String str2, PluginErrorDetails pluginErrorDetails) {
        this.a.b.a(str);
        this.b.getClass();
        this.c.execute(new Cif(this, str, str2, pluginErrorDetails));
    }
}
