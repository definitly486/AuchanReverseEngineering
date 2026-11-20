package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.Revenue;

/* JADX INFO: loaded from: classes3.dex */
public final class X0 implements Runnable {
    public final /* synthetic */ Revenue a;
    public final /* synthetic */ C0659v1 b;

    public X0(C0659v1 c0659v1, Revenue revenue) {
        this.b = c0659v1;
        this.a = revenue;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.b).reportRevenue(this.a);
    }
}
