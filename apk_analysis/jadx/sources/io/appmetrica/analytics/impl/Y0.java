package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Y0 implements Runnable {
    public final /* synthetic */ C0659v1 a;

    public Y0(C0659v1 c0659v1) {
        this.a = c0659v1;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.a).sendEventsBuffer();
    }
}
