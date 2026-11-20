package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.ReporterConfig;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.nb, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public interface InterfaceC0461nb extends InterfaceC0487ob {
    InterfaceC0306hb a(AppMetricaConfig appMetricaConfig, PublicLogger publicLogger, C0450n0 c0450n0);

    @Override // io.appmetrica.analytics.impl.InterfaceC0487ob
    /* synthetic */ InterfaceC0461nb a();

    InterfaceC0540qb a(AppMetricaConfig appMetricaConfig);

    void a(ReporterConfig reporterConfig);

    InterfaceC0306hb b(AppMetricaConfig appMetricaConfig, PublicLogger publicLogger, C0450n0 c0450n0);

    InterfaceC0435mb b(ReporterConfig reporterConfig);
}
