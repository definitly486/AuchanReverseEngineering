package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AppMetricaConfig;

/* JADX INFO: loaded from: classes3.dex */
public final class Bc extends AbstractC0500oo {
    public final AppMetricaConfig b;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public Bc(InterfaceC0487ob interfaceC0487ob, AppMetricaConfig appMetricaConfig) {
        super(interfaceC0487ob);
        String str = appMetricaConfig.apiKey;
        this.b = appMetricaConfig;
    }

    public final InterfaceC0540qb a() {
        return this.a.a().a(this.b);
    }
}
