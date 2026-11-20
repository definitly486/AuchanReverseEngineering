package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.s1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0581s1 implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ Throwable b;
    public final /* synthetic */ C0659v1 c;

    public RunnableC0581s1(C0659v1 c0659v1, String str, Throwable th) {
        this.c = c0659v1;
        this.a = str;
        this.b = th;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.c).reportError(this.a, this.b);
    }
}
