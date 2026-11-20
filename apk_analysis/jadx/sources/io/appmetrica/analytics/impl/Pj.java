package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AdRevenue;

/* JADX INFO: loaded from: classes3.dex */
public final class Pj implements InterfaceC0409lb {
    public final /* synthetic */ AdRevenue a;

    public Pj(AdRevenue adRevenue) {
        this.a = adRevenue;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportAdRevenue(this.a);
    }
}
