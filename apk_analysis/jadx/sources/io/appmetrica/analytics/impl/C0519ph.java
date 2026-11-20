package io.appmetrica.analytics.impl;

import java.util.concurrent.TimeUnit;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ph, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0519ph extends AbstractC0131ah {
    public C0519ph(C0455n5 c0455n5) {
        super(c0455n5);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        Uk ukA;
        C0471nl c0471nl;
        boolean z;
        boolean z2;
        E9 e9 = this.a.n;
        C0393kl c0393kl = e9.c;
        if (c0393kl.g == 0) {
            ukA = c0393kl.c.a();
            Uk ukA2 = c0393kl.d.a();
            if ((ukA == null ? -1L : ukA.d) <= (ukA2 != null ? ukA2.d : -1L)) {
                ukA = ukA2;
            }
        } else {
            ukA = c0393kl.f;
        }
        if (ukA != null) {
            synchronized (ukA) {
                z2 = ukA.k;
            }
            if (z2) {
                C0419ll c0419llA = c0393kl.a.e.a(ukA.d, ukA.c.a);
                long j = c0249f6.i;
                long j2 = c0249f6.j;
                c0393kl.g = 2;
                Uk ukA3 = c0393kl.e.a(new Vk(j, j2, c0419llA));
                c0393kl.f = ukA3;
                c0393kl.a(ukA3.d);
                c0471nl = C0393kl.a(c0393kl.f, j);
            } else {
                c0471nl = new C0471nl();
                c0471nl.a = ukA.d;
                long andIncrement = ukA.g.getAndIncrement();
                C0497ol c0497ol = ukA.b;
                c0497ol.a(C0497ol.g, Long.valueOf(ukA.g.get()));
                c0497ol.a();
                c0471nl.b = andIncrement;
                long j3 = c0249f6.j;
                long j4 = c0249f6.i;
                TimeUnit timeUnit = TimeUnit.MILLISECONDS;
                long seconds = timeUnit.toSeconds(j3 - ukA.f);
                C0497ol c0497ol2 = ukA.b;
                long j5 = j4 - ukA.e;
                ukA.j = j5;
                c0497ol2.a(C0497ol.e, Long.valueOf(j5));
                c0497ol2.a();
                c0471nl.c = Math.max(seconds, timeUnit.toSeconds(ukA.j));
                c0471nl.d = ukA.c.a;
            }
        } else {
            c0471nl = null;
        }
        if (c0471nl != null) {
            e9.a(c0249f6, c0471nl);
            z = true;
        } else {
            z = false;
        }
        return !z;
    }
}
