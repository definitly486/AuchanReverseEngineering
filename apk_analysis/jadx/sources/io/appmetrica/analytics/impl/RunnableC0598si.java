package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.si, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0598si implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ String b;
    public final /* synthetic */ C0624ti c;

    public RunnableC0598si(C0624ti c0624ti, String str, String str2) {
        this.c = c0624ti;
        this.a = str;
        this.b = str2;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.c;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportEvent(this.a, this.b);
    }
}
