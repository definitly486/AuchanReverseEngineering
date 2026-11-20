package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AdRevenue;

/* JADX INFO: loaded from: classes3.dex */
public final class Z0 implements Runnable {
    public final /* synthetic */ AdRevenue a;
    public final /* synthetic */ C0659v1 b;

    public Z0(C0659v1 c0659v1, AdRevenue adRevenue) {
        this.b = c0659v1;
        this.a = adRevenue;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.b).reportAdRevenue(this.a);
    }
}
