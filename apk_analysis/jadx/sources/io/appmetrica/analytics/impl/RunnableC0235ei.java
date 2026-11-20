package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceEvent;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ei, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0235ei implements Runnable {
    public final /* synthetic */ ECommerceEvent a;
    public final /* synthetic */ C0624ti b;

    public RunnableC0235ei(C0624ti c0624ti, ECommerceEvent eCommerceEvent) {
        this.b = c0624ti;
        this.a = eCommerceEvent;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportECommerce(this.a);
    }
}
