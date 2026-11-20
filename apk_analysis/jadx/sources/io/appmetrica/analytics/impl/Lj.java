package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.Revenue;

/* JADX INFO: loaded from: classes3.dex */
public final class Lj implements InterfaceC0409lb {
    public final /* synthetic */ Revenue a;

    public Lj(Revenue revenue) {
        this.a = revenue;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportRevenue(this.a);
    }
}
