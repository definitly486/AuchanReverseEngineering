package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Zb implements InterfaceC0165c {
    public final InterfaceC0321i0 a;
    public final Vn b = new Vn();

    public Zb(InterfaceC0321i0 interfaceC0321i0) {
        this.a = interfaceC0321i0;
    }

    public static final void a(Zb zb, X x) {
        zb.a.a(x);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0165c
    public final void onAppNotResponding() {
        StackTraceElement[] stackTraceElementArrB;
        Vn vn = this.b;
        Thread threadA = vn.a.a();
        try {
            stackTraceElementArrB = vn.a.b();
            if (stackTraceElementArrB == null) {
                try {
                    stackTraceElementArrB = threadA.getStackTrace();
                } catch (SecurityException unused) {
                }
            }
        } catch (SecurityException unused2) {
            stackTraceElementArrB = null;
        }
        final X x = new X((On) vn.b.apply(threadA, stackTraceElementArrB), vn.a(threadA, null), vn.c.a());
        ((U9) C0584s4.l().c.a()).b.post(new Runnable() { // from class: io.appmetrica.analytics.impl.Zb$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                Zb.a(this.f$0, x);
            }
        });
    }
}
