package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.g1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0270g1 implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ C0659v1 b;

    public RunnableC0270g1(C0659v1 c0659v1, String str) {
        this.b = c0659v1;
        this.a = str;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.b).b(this.a);
    }
}
