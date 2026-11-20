package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.qi, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0547qi implements Runnable {
    public final /* synthetic */ C0624ti a;

    public RunnableC0547qi(C0624ti c0624ti) {
        this.a = c0624ti;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.a;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).clearAppEnvironment();
    }
}
