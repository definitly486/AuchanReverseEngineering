package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.TimeUnit;
import kotlin.jvm.internal.Intrinsics;
import okhttp3.internal.connection.RealConnection;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.kl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0393kl {
    public final C0455n5 a;
    public final C0429m5 b;
    public final InterfaceC0513pb c;
    public final InterfaceC0513pb d;
    public final InterfaceC0513pb e;
    public Uk f;
    public int g = 0;
    public Long h = null;

    public C0393kl(C0455n5 c0455n5, C0429m5 c0429m5, Ea ea, M2 m2, C0341il c0341il) {
        this.a = c0455n5;
        this.b = c0429m5;
        this.c = ea;
        this.d = m2;
        this.e = c0341il;
    }

    public final synchronized long a() {
        Long l;
        l = this.h;
        return l != null ? l.longValue() : RealConnection.IDLE_CONNECTION_HEALTHY_NS;
    }

    public final synchronized Uk b(C0249f6 c0249f6) {
        try {
            d(c0249f6);
            if (this.g != 1 && !a(this.f, c0249f6)) {
                this.g = 1;
                this.f = null;
            }
            int iA = AbstractC0174c8.a(this.g);
            if (iA == 1) {
                Uk uk = this.f;
                long j = c0249f6.i;
                uk.i = j;
                C0497ol c0497ol = uk.b;
                c0497ol.a(C0497ol.d, Long.valueOf(j));
                c0497ol.a();
                return this.f;
            }
            if (iA == 2) {
                return this.f;
            }
            this.a.m.info("Start background session", new Object[0]);
            this.g = 2;
            long j2 = c0249f6.i;
            Uk ukA = this.d.a(new Vk(j2, c0249f6.j, null));
            a(ukA.d);
            if (this.a.t.c()) {
                C0429m5 c0429m5 = this.b;
                c0429m5.a.n.a(C0249f6.a(c0249f6, Ka.I.i()), a(ukA, c0249f6.i));
            } else {
                int i = c0249f6.d;
                EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
                if (i == 6145) {
                    C0429m5 c0429m6 = this.b;
                    c0429m6.a.n.a(c0249f6, a(ukA, j2));
                    C0429m5 c0429m7 = this.b;
                    c0429m7.a.n.a(C0249f6.a(c0249f6, Ka.I.i()), a(ukA, j2));
                }
            }
            this.f = ukA;
            return ukA;
        } catch (Throwable th) {
            throw th;
        }
    }

    public final synchronized void c(C0249f6 c0249f6) {
        try {
            d(c0249f6);
            int iA = AbstractC0174c8.a(this.g);
            if (iA == 0) {
                this.f = a(c0249f6);
            } else if (iA == 1) {
                b(this.f, c0249f6);
                this.f = a(c0249f6);
            } else if (iA == 2) {
                if (a(this.f, c0249f6)) {
                    Uk uk = this.f;
                    long j = c0249f6.i;
                    uk.i = j;
                    C0497ol c0497ol = uk.b;
                    c0497ol.a(C0497ol.d, Long.valueOf(j));
                    c0497ol.a();
                } else {
                    this.f = a(c0249f6);
                }
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    public final void d(C0249f6 c0249f6) {
        if (this.g == 0) {
            Uk ukA = this.c.a();
            if (ukA != null) {
                a(ukA.d);
            }
            if (a(ukA, c0249f6)) {
                this.f = ukA;
                this.g = 3;
                return;
            }
            Uk ukA2 = this.d.a();
            if (ukA2 != null) {
                a(ukA2.d);
            }
            if (a(ukA2, c0249f6)) {
                this.f = ukA2;
                this.g = 2;
            } else {
                this.f = null;
                this.g = 1;
            }
        }
    }

    public final void a(long j) {
        Long l = this.h;
        if (l == null || j < l.longValue()) {
            this.h = Long.valueOf(j);
        }
    }

    public final Uk a(C0249f6 c0249f6) {
        this.a.m.info("Start foreground session", new Object[0]);
        long j = c0249f6.i;
        Uk ukA = this.c.a(new Vk(j, c0249f6.j, null));
        a(ukA.d);
        this.g = 3;
        ((A5) this.a.p).e();
        C0429m5 c0429m5 = this.b;
        c0429m5.a.n.a(C0249f6.a(c0249f6, Ka.I.i()), a(ukA, j));
        return ukA;
    }

    /* JADX WARN: Code duplicated, block: B:47:0x0101  */
    public final boolean a(Uk uk, C0249f6 c0249f6) {
        boolean z;
        boolean z2;
        if (uk == null) {
            return false;
        }
        long j = c0249f6.i;
        long j2 = uk.d;
        boolean z3 = j2 >= 0;
        C0419ll c0419llA = uk.a.e.a(j2, uk.c.a);
        if (c0419llA != null) {
            C0727xh c0727xh = (C0727xh) uk.a.k.a();
            List listListOf = CollectionsKt.listOf((Object[]) new Boolean[]{Boolean.valueOf(Intrinsics.areEqual(c0727xh.getAnalyticsSdkVersionName(), c0419llA.n)), Boolean.valueOf(Intrinsics.areEqual(c0727xh.getAnalyticsSdkBuildNumber(), c0419llA.o)), Boolean.valueOf(Intrinsics.areEqual(c0727xh.getAppVersion(), c0419llA.d)), Boolean.valueOf(Intrinsics.areEqual(c0727xh.getAppBuildNumber(), c0419llA.e)), Boolean.valueOf(Intrinsics.areEqual(c0727xh.getOsVersion(), c0419llA.g)), Boolean.valueOf(c0419llA.h == c0727xh.getOsApiLevel()), Boolean.valueOf(c0419llA.m == c0727xh.r)});
            if (!(listListOf instanceof Collection) || !listListOf.isEmpty()) {
                Iterator it = listListOf.iterator();
                while (true) {
                    if (it.hasNext()) {
                        if (!((Boolean) it.next()).booleanValue()) {
                            z = false;
                        }
                    }
                }
            }
            z = true;
        } else {
            z = false;
        }
        long jElapsedRealtime = uk.l.elapsedRealtime();
        long j3 = uk.i;
        boolean z4 = jElapsedRealtime < j3;
        long j4 = j - j3;
        long j5 = j - uk.e;
        if (z4) {
            z2 = true;
        } else {
            TimeUnit timeUnit = TimeUnit.SECONDS;
            Xk xk = uk.c;
            int iIntValue = ((C0727xh) uk.a.k.a()).f;
            Integer num = xk.e;
            if (num != null) {
                iIntValue = num.intValue();
            }
            if (j4 >= timeUnit.toMillis(iIntValue) || j5 >= timeUnit.toMillis(Yk.a)) {
                z2 = true;
            } else {
                z2 = false;
            }
        }
        if (z3 && z && !z2 && !uk.k) {
            return true;
        }
        b(uk, c0249f6);
        return false;
    }

    public final void b(Uk uk, C0249f6 c0249f6) {
        if (uk.h && uk.d > 0) {
            C0429m5 c0429m5 = this.b;
            C0249f6 c0249f6A = C0249f6.a(c0249f6, EnumC0721xb.EVENT_TYPE_ALIVE);
            C0471nl c0471nl = new C0471nl();
            c0471nl.a = uk.d;
            c0471nl.d = uk.c.a;
            long andIncrement = uk.g.getAndIncrement();
            C0497ol c0497ol = uk.b;
            c0497ol.a(C0497ol.g, Long.valueOf(uk.g.get()));
            c0497ol.a();
            c0471nl.b = andIncrement;
            c0471nl.c = TimeUnit.MILLISECONDS.toSeconds(Math.max(uk.i - uk.e, uk.j));
            c0429m5.a.n.a(c0249f6A, c0471nl);
            if (uk.h) {
                uk.h = false;
                C0497ol c0497ol2 = uk.b;
                c0497ol2.a(C0497ol.j, Boolean.FALSE);
                c0497ol2.a();
            }
        }
        PublicLogger publicLogger = this.a.m;
        int iOrdinal = uk.c.a.ordinal();
        if (iOrdinal == 0) {
            publicLogger.info("Finish foreground session", new Object[0]);
        } else if (iOrdinal == 1) {
            publicLogger.info("Finish background session", new Object[0]);
        }
        synchronized (uk) {
            C0497ol c0497ol3 = uk.b;
            c0497ol3.getClass();
            c0497ol3.c = new Bb();
            c0497ol3.a();
        }
    }

    public static C0471nl a(Uk uk, long j) {
        C0471nl c0471nl = new C0471nl();
        c0471nl.a = uk.d;
        long andIncrement = uk.g.getAndIncrement();
        C0497ol c0497ol = uk.b;
        c0497ol.a(C0497ol.g, Long.valueOf(uk.g.get()));
        c0497ol.a();
        c0471nl.b = andIncrement;
        C0497ol c0497ol2 = uk.b;
        long j2 = j - uk.e;
        uk.j = j2;
        c0497ol2.a(C0497ol.e, Long.valueOf(j2));
        c0497ol2.a();
        c0471nl.c = TimeUnit.MILLISECONDS.toSeconds(uk.j);
        c0471nl.d = uk.c.a;
        return c0471nl;
    }
}
