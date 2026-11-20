package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Yh implements Runnable {
    public final /* synthetic */ C0624ti a;

    public Yh(C0624ti c0624ti) {
        this.a = c0624ti;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.a;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).pauseSession();
    }
}
