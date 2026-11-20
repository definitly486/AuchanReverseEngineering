package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.ModuleAdRevenueProcessorsHolder;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.a6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0120a6 implements Z5 {
    public final C0741y5 a;

    public C0120a6(C0741y5 c0741y5) {
        this.a = c0741y5;
    }

    @Override // io.appmetrica.analytics.impl.Z5, io.appmetrica.analytics.modulesapi.internal.client.adrevenue.ModuleAdRevenueContext
    public final C0741y5 getAdRevenueProcessorsHolder() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.client.adrevenue.ModuleAdRevenueContext
    public final ModuleAdRevenueProcessorsHolder getAdRevenueProcessorsHolder() {
        return this.a;
    }
}
