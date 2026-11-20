package io.appmetrica.analytics.impl;

import java.util.concurrent.TimeUnit;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.k5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0377k5 extends AbstractC0351j5 {
    public C0377k5(C0455n5 c0455n5) {
        super(c0455n5);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0351j5
    public final boolean b(int i) {
        return i < 113;
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0351j5
    public final void c() {
        C0544qf c0544qf = this.a.c;
        try {
            C0497ol c0497ol = new C0497ol(c0544qf, M2.g);
            Long lB = c0497ol.c.b(C0497ol.d);
            if (lB != null) {
                c0497ol.a(C0497ol.d, Long.valueOf(TimeUnit.SECONDS.toMillis(lB.longValue())));
            }
            Long lB2 = c0497ol.c.b(C0497ol.e);
            if (lB2 != null) {
                c0497ol.a(C0497ol.e, Long.valueOf(TimeUnit.SECONDS.toMillis(lB2.longValue())));
            }
        } catch (Throwable unused) {
        }
        try {
            C0497ol c0497ol2 = new C0497ol(c0544qf, Ea.g);
            Long lB3 = c0497ol2.c.b(C0497ol.d);
            if (lB3 != null) {
                c0497ol2.a(C0497ol.d, Long.valueOf(TimeUnit.SECONDS.toMillis(lB3.longValue())));
            }
            Long lB4 = c0497ol2.c.b(C0497ol.e);
            if (lB4 != null) {
                c0497ol2.a(C0497ol.e, Long.valueOf(TimeUnit.SECONDS.toMillis(lB4.longValue())));
            }
        } catch (Throwable unused2) {
        }
    }
}
