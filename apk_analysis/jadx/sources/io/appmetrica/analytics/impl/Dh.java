package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Dh extends AbstractC0131ah {
    public Dh(C0455n5 c0455n5) {
        super(c0455n5);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        Uk ukA;
        ((A5) this.a.p).e();
        C0393kl c0393kl = this.a.j;
        synchronized (c0393kl) {
            try {
                if (c0393kl.g == 0) {
                    ukA = c0393kl.c.a();
                    Uk ukA2 = c0393kl.d.a();
                    long j = -1;
                    long j2 = ukA == null ? -1L : ukA.d;
                    if (ukA2 != null) {
                        j = ukA2.d;
                    }
                    if (j2 <= j) {
                        ukA = ukA2;
                    }
                } else {
                    ukA = c0393kl.f;
                }
                if (ukA != null) {
                    ukA.b();
                    if (ukA.h) {
                        ukA.h = false;
                        C0497ol c0497ol = ukA.b;
                        c0497ol.a(C0497ol.j, Boolean.FALSE);
                        c0497ol.a();
                    }
                    c0393kl.g = 0;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return true;
    }
}
