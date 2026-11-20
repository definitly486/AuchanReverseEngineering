package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.li, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0416li implements Runnable {
    public final /* synthetic */ C0344io a;
    public final /* synthetic */ C0624ti b;

    public RunnableC0416li(C0624ti c0624ti, C0344io c0344io) {
        this.b = c0624ti;
        this.a = c0344io;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).a(this.a);
    }
}
