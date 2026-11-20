package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: loaded from: classes3.dex */
public final class D0 implements Rc {
    public final /* synthetic */ E0 a;
    public final /* synthetic */ AppMetricaConfig b;
    public final /* synthetic */ PublicLogger c;

    public D0(E0 e0, AppMetricaConfig appMetricaConfig, PublicLogger publicLogger) {
        this.a = e0;
        this.b = appMetricaConfig;
        this.c = publicLogger;
    }

    @Override // io.appmetrica.analytics.impl.Rc
    public final Dc a() {
        E0 e0 = this.a;
        C0702wi c0702wi = e0.g;
        AppMetricaConfig appMetricaConfig = this.b;
        PublicLogger publicLogger = this.c;
        V7 v7 = e0.i;
        return c0702wi.b(appMetricaConfig, publicLogger, new C0450n0(v7.j, v7.h));
    }
}
