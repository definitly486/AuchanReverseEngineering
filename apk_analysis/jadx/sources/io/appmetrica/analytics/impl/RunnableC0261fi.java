package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.fi, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0261fi implements Runnable {
    public final /* synthetic */ boolean a;
    public final /* synthetic */ C0624ti b;

    public RunnableC0261fi(C0624ti c0624ti, boolean z) {
        this.b = c0624ti;
        this.a = z;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).setDataSendingEnabled(this.a);
    }
}
