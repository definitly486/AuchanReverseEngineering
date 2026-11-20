package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Wh implements Runnable {
    public final /* synthetic */ Throwable a;
    public final /* synthetic */ C0624ti b;

    public Wh(C0624ti c0624ti, Throwable th) {
        this.b = c0624ti;
        this.a = th;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportUnhandledException(this.a);
    }
}
