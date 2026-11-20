package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceComponentModuleConfig;
import io.appmetrica.analytics.coreutils.internal.WrapUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.qk, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0549qk implements ServiceComponentModuleConfig {
    public final F4 a;

    public C0549qk(F4 f4) {
        this.a = f4;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceComponentModuleConfig
    public final boolean isRevenueAutoTrackingEnabled() {
        return ((Boolean) WrapUtils.getOrDefault(this.a.m, Boolean.TRUE)).booleanValue();
    }
}
