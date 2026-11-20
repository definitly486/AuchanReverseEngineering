package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class B5 implements Runnable {
    public final /* synthetic */ InterfaceC0672ve a;
    public final /* synthetic */ C5 b;

    public B5(C5 c5, InterfaceC0672ve interfaceC0672ve) {
        this.b = c5;
        this.a = interfaceC0672ve;
    }

    @Override // java.lang.Runnable
    public final void run() {
        synchronized (this.b) {
            try {
                C5 c5 = this.b;
                Object obj = c5.a;
                if (obj == null) {
                    c5.b.add(this.a);
                } else {
                    this.a.consume(obj);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }
}
