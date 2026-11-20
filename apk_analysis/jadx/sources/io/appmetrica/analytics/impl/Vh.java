package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Vh implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ String b;
    public final /* synthetic */ Throwable c;
    public final /* synthetic */ C0624ti d;

    public Vh(C0624ti c0624ti, String str, String str2, Throwable th) {
        this.d = c0624ti;
        this.a = str;
        this.b = str2;
        this.c = th;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.d;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportError(this.a, this.b, this.c);
    }
}
