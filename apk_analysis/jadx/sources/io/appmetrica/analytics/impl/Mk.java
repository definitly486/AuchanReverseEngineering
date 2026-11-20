package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceComponentModuleConfig;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceComponentModuleReporter;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceModuleReporterComponentContext;

/* JADX INFO: loaded from: classes3.dex */
public final class Mk implements ServiceModuleReporterComponentContext {
    public final C0574rk a;
    public final C0549qk b;

    public Mk(C0455n5 c0455n5, F4 f4) {
        this.a = new C0574rk(c0455n5, null, 2, null);
        this.b = new C0549qk(f4);
    }

    public final C0549qk a() {
        return this.b;
    }

    public final C0574rk b() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceModuleReporterComponentContext
    public final ServiceComponentModuleConfig getConfig() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceModuleReporterComponentContext
    public final ServiceComponentModuleReporter getReporter() {
        return this.a;
    }
}
