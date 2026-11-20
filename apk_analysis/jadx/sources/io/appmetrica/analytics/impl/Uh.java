package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Uh implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ Throwable b;
    public final /* synthetic */ C0624ti c;

    public Uh(C0624ti c0624ti, String str, Throwable th) {
        this.c = c0624ti;
        this.a = str;
        this.b = th;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.c;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportError(this.a, this.b);
    }
}
