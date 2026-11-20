package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ni, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0468ni implements Runnable {
    public final /* synthetic */ X a;
    public final /* synthetic */ C0624ti b;

    public RunnableC0468ni(C0624ti c0624ti, X x) {
        this.b = c0624ti;
        this.a = x;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).a(this.a);
    }
}
