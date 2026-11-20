package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AdRevenue;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ci, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0184ci implements Runnable {
    public final /* synthetic */ AdRevenue a;
    public final /* synthetic */ C0624ti b;

    public RunnableC0184ci(C0624ti c0624ti, AdRevenue adRevenue) {
        this.b = c0624ti;
        this.a = adRevenue;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportAdRevenue(this.a);
    }
}
