package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceEvent;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.a1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0115a1 implements Runnable {
    public final /* synthetic */ ECommerceEvent a;
    public final /* synthetic */ C0659v1 b;

    public RunnableC0115a1(C0659v1 c0659v1, ECommerceEvent eCommerceEvent) {
        this.b = c0659v1;
        this.a = eCommerceEvent;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.b).reportECommerce(this.a);
    }
}
