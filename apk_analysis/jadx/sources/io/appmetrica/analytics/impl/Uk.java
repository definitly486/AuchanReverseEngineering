package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import java.util.concurrent.atomic.AtomicLong;

/* JADX INFO: loaded from: classes3.dex */
public final class Uk {
    public final C0455n5 a;
    public final C0497ol b;
    public final Xk c;
    public long d;
    public long e;
    public long f;
    public AtomicLong g;
    public boolean h;
    public long i;
    public long j;
    public boolean k;
    public final SystemTimeProvider l;

    public Uk(C0455n5 c0455n5, C0497ol c0497ol, Xk xk, SystemTimeProvider systemTimeProvider) {
        this.a = c0455n5;
        this.b = c0497ol;
        this.c = xk;
        this.l = systemTimeProvider;
        a();
    }

    public final void a() {
        Xk xk = this.c;
        long jElapsedRealtime = this.l.elapsedRealtime();
        Long l = xk.c;
        if (l != null) {
            jElapsedRealtime = l.longValue();
        }
        this.e = jElapsedRealtime;
        Xk xk2 = this.c;
        long jCurrentTimeMillis = this.l.currentTimeMillis();
        Long l2 = xk2.d;
        if (l2 != null) {
            jCurrentTimeMillis = l2.longValue();
        }
        this.f = jCurrentTimeMillis;
        Long l3 = this.c.b;
        this.d = l3 == null ? -1L : l3.longValue();
        Long l4 = this.c.f;
        this.g = new AtomicLong(l4 == null ? 0L : l4.longValue());
        Boolean bool = this.c.g;
        this.h = bool == null ? true : bool.booleanValue();
        Long l5 = this.c.h;
        long jLongValue = l5 != null ? l5.longValue() : 0L;
        this.i = jLongValue;
        Xk xk3 = this.c;
        long jLongValue2 = jLongValue - this.e;
        Long l6 = xk3.i;
        if (l6 != null) {
            jLongValue2 = l6.longValue();
        }
        this.j = jLongValue2;
        Boolean bool2 = this.c.j;
        this.k = bool2 == null ? false : bool2.booleanValue();
    }

    public final synchronized void b() {
        this.k = true;
        C0497ol c0497ol = this.b;
        c0497ol.a(C0497ol.k, Boolean.TRUE);
        c0497ol.a();
    }

    public final String toString() {
        return "Session{id=" + this.d + ", creationTime=" + this.e + ", sessionCreationCurrentTimeMillis=" + this.f + ", currentReportId=" + this.g + ", sessionRequestParams=null, sleepStart=" + this.i + ", aliveNeeded=" + this.h + ", crashedSession=" + this.k + '}';
    }
}
