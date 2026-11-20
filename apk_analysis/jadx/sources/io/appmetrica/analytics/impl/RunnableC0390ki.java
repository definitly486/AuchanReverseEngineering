package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AdRevenue;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ki, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0390ki implements Runnable {
    public final /* synthetic */ AdRevenue a;
    public final /* synthetic */ boolean b;
    public final /* synthetic */ C0624ti c;

    public RunnableC0390ki(C0624ti c0624ti, AdRevenue adRevenue, boolean z) {
        this.c = c0624ti;
        this.a = adRevenue;
        this.b = z;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.c;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportAdRevenue(this.a, this.b);
    }
}
