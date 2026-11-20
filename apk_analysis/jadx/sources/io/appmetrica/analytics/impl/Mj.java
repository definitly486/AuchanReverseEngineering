package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceEvent;

/* JADX INFO: loaded from: classes3.dex */
public final class Mj implements InterfaceC0409lb {
    public final /* synthetic */ ECommerceEvent a;

    public Mj(ECommerceEvent eCommerceEvent) {
        this.a = eCommerceEvent;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportECommerce(this.a);
    }
}
