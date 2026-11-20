package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ModuleEvent;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ii, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0338ii implements Runnable {
    public final /* synthetic */ ModuleEvent a;
    public final /* synthetic */ C0624ti b;

    public RunnableC0338ii(C0624ti c0624ti, ModuleEvent moduleEvent) {
        this.b = c0624ti;
        this.a = moduleEvent;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportEvent(this.a);
    }
}
