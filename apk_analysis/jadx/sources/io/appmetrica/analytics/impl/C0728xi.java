package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.ReporterConfig;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.xi, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0728xi implements InterfaceC0461nb {
    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb, io.appmetrica.analytics.impl.InterfaceC0487ob
    public final InterfaceC0461nb a() {
        return this;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb
    public final void a(ReporterConfig reporterConfig) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb
    public final InterfaceC0306hb b(AppMetricaConfig appMetricaConfig, PublicLogger publicLogger, C0450n0 c0450n0) {
        return new Sc();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb
    public final InterfaceC0435mb b(ReporterConfig reporterConfig) {
        return new C0650ui();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb
    public final InterfaceC0306hb a(AppMetricaConfig appMetricaConfig, PublicLogger publicLogger, C0450n0 c0450n0) {
        return new Sc();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb
    public final InterfaceC0540qb a(AppMetricaConfig appMetricaConfig) {
        return new C0650ui();
    }
}
