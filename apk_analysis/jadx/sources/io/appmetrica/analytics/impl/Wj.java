package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AdRevenue;

/* JADX INFO: loaded from: classes3.dex */
public final class Wj implements InterfaceC0409lb {
    public final /* synthetic */ AdRevenue a;
    public final /* synthetic */ boolean b;

    public Wj(AdRevenue adRevenue, boolean z) {
        this.a = adRevenue;
        this.b = z;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportAdRevenue(this.a, this.b);
    }
}
