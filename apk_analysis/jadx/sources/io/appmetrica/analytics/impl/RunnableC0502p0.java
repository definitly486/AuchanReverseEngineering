package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.p0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0502p0 implements Runnable {
    public final /* synthetic */ C0554r0 a;

    public RunnableC0502p0(C0554r0 c0554r0) {
        this.a = c0554r0;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0554r0 c0554r0 = this.a;
        synchronized (c0554r0) {
            if (c0554r0.a != null && c0554r0.a()) {
                try {
                    c0554r0.d = null;
                    c0554r0.a.unbindService(c0554r0.j);
                } catch (Throwable unused) {
                }
            }
            c0554r0.d = null;
        }
    }
}
