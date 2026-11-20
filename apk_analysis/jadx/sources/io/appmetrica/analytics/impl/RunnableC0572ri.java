package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ri, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0572ri implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ C0624ti b;

    public RunnableC0572ri(C0624ti c0624ti, String str) {
        this.b = c0624ti;
        this.a = str;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportEvent(this.a);
    }
}
