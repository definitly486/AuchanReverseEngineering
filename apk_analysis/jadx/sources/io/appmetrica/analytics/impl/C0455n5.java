package io.appmetrica.analytics.impl;

import android.content.Context;
import android.text.TextUtils;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.AppMetrica;
import io.appmetrica.analytics.coreutils.internal.services.PackageManagerUtils;
import io.appmetrica.analytics.coreutils.internal.time.TimePassedChecker;
import io.appmetrica.analytics.internal.CounterConfigurationReporterType;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.Iterator;
import java.util.Set;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.n5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public class C0455n5 implements InterfaceC0383kb, InterfaceC0203db, InterfaceC0701wh {
    public final Context a;
    public final C0274g5 b;
    public final C0544qf c;
    public final C0621tf d;
    public final C0173c7 e;
    public final Gi f;
    public final C0563r9 g;
    public final C0398l0 h;
    public final C0424m0 i;
    public final C0393kl j;
    public final Zg k;
    public final C0278g9 l;
    public final PublicLogger m;
    public final E9 n;
    public final C0326i5 o;
    public final K9 p;
    public final D3 q;
    public final TimePassedChecker r;
    public final Nf s;
    public final Po t;
    public final C0161bl u;
    public final C2 v;

    public C0455n5(Context context, C0706wm c0706wm, C0274g5 c0274g5, F4 f4, InterfaceC0649uh interfaceC0649uh, AbstractC0403l5 abstractC0403l5) {
        this(context, c0274g5, new C0424m0(), new TimePassedChecker(), new C0585s5(context, c0274g5, f4, abstractC0403l5, c0706wm, interfaceC0649uh, Ka.k().w().d(), PackageManagerUtils.getAppVersionCodeInt(context), Ka.k().l(), new C0248f5()), f4);
    }

    public final boolean A() {
        C0727xh c0727xh = (C0727xh) this.k.a();
        return c0727xh.n && this.r.didTimePassSeconds(this.n.k, c0727xh.t, "should force send permissions");
    }

    public final boolean B() {
        C0706wm c0706wm;
        Nf nf = this.s;
        nf.h.a(nf.a);
        boolean z = ((Kf) nf.c()).d;
        Zg zg = this.k;
        synchronized (zg) {
            c0706wm = zg.c.a;
        }
        return !(z && c0706wm.q);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0383kb, io.appmetrica.analytics.impl.InterfaceC0317hm
    public final void a(EnumC0136am enumC0136am, C0706wm c0706wm) {
    }

    public final void b(C0249f6 c0249f6) {
        this.h.a(c0249f6.f);
        C0372k0 c0372k0A = this.h.a();
        C0424m0 c0424m0 = this.i;
        C0544qf c0544qf = this.c;
        synchronized (c0424m0) {
            if (c0372k0A.b > c0544qf.d().b) {
                c0544qf.a(c0372k0A);
                this.m.info("Save new app environment for %s. Value: %s", this.b, c0372k0A.a);
            }
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0203db
    public final void c() {
        Qo qo = this.t.a;
        Qo.a(qo.a);
        Qo.a(qo.b);
        this.e.j.b.flushAsync();
    }

    public final void d() {
        C0398l0 c0398l0 = this.h;
        synchronized (c0398l0) {
            c0398l0.a = new C0127ad();
        }
        this.i.a(this.h.a(), this.c);
    }

    public final synchronized void e() {
        ((A5) this.p).d();
    }

    public final C2 f() {
        return this.v;
    }

    public final D3 g() {
        return this.q;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0203db
    public final Context getContext() {
        return this.a;
    }

    public final C0544qf h() {
        return this.c;
    }

    public final C0173c7 i() {
        return this.e;
    }

    public final C0278g9 j() {
        return this.l;
    }

    public final C0563r9 k() {
        return this.g;
    }

    public final E9 l() {
        return this.n;
    }

    public final K9 m() {
        return this.p;
    }

    public final C0727xh n() {
        return (C0727xh) this.k.a();
    }

    public final String o() {
        return this.c.j();
    }

    public final PublicLogger p() {
        return this.m;
    }

    public final C0621tf q() {
        return this.d;
    }

    public final C0161bl r() {
        return this.u;
    }

    public final C0393kl s() {
        return this.j;
    }

    public final C0706wm t() {
        C0706wm c0706wm;
        Zg zg = this.k;
        synchronized (zg) {
            c0706wm = zg.c.a;
        }
        return c0706wm;
    }

    public final Po u() {
        return this.t;
    }

    public final void v() {
        E9 e9 = this.n;
        int i = e9.j;
        e9.l = i;
        e9.a.a(i);
    }

    public final void w() {
        int iOptInt;
        int libraryApiLevel = AppMetrica.getLibraryApiLevel();
        Po po = this.t;
        synchronized (po) {
            iOptInt = po.a.a().optInt("last_migration_api_level", 0);
        }
        if (iOptInt < libraryApiLevel) {
            this.o.getClass();
            Iterator it = CollectionsKt.listOf(new C0377k5(this)).iterator();
            while (it.hasNext()) {
                ((AbstractC0351j5) it.next()).a(iOptInt);
            }
            this.t.b(libraryApiLevel);
        }
    }

    public final boolean x() {
        C0727xh c0727xh = (C0727xh) this.k.a();
        return c0727xh.n && c0727xh.isIdentifiersValid() && this.r.didTimePassSeconds(this.n.k, c0727xh.s, "need to check permissions");
    }

    public final boolean y() {
        E9 e9 = this.n;
        return e9.l < e9.j && ((C0727xh) this.k.a()).o && ((C0727xh) this.k.a()).isIdentifiersValid();
    }

    public final void z() {
        Zg zg = this.k;
        synchronized (zg) {
            zg.a = null;
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0383kb
    public final void a(C0249f6 c0249f6) {
        String strA = AbstractC0414lg.a("Event received on service", EnumC0721xb.a(c0249f6.d), c0249f6.getName(), c0249f6.getValue());
        if (strA != null) {
            this.m.info(strA, new Object[0]);
        }
        String str = this.b.b;
        if (TextUtils.isEmpty(str) || "-1".equals(str)) {
            return;
        }
        this.f.a(c0249f6, new Fi());
    }

    public CounterConfigurationReporterType b() {
        return CounterConfigurationReporterType.MANUAL;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0383kb, io.appmetrica.analytics.impl.InterfaceC0203db
    public synchronized void a(F4 f4) {
        long jLongValue;
        try {
            this.k.a(f4);
            boolean z = false;
            if (Boolean.TRUE.equals(f4.h)) {
                this.m.setEnabled(true);
            } else {
                if (Boolean.FALSE.equals(f4.h)) {
                    this.m.setEnabled(false);
                }
            }
            C2 c2 = this.v;
            Set<String> set = f4.o;
            long jCurrentTimeMillis = c2.d.currentTimeMillis();
            boolean z2 = false;
            for (String str : set) {
                Long l = (Long) c2.e.get(str);
                if (l != null) {
                    jLongValue = l.longValue();
                } else {
                    jLongValue = -1;
                    z2 = true;
                }
                if (jCurrentTimeMillis - jLongValue > c2.b) {
                    c2.e.put(str, Long.valueOf(jCurrentTimeMillis));
                    z = true;
                }
            }
            if (z) {
                c2.a(c2.e);
                c2.a.a(c2.e);
            }
            if (z2) {
                this.k.e();
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    public C0455n5(Context context, C0274g5 c0274g5, C0424m0 c0424m0, TimePassedChecker timePassedChecker, C0585s5 c0585s5, F4 f4) {
        this.a = context.getApplicationContext();
        this.b = c0274g5;
        this.i = c0424m0;
        this.r = timePassedChecker;
        Po poF = c0585s5.f();
        this.t = poF;
        this.s = Ka.k().t();
        C0544qf c0544qfA = c0585s5.e().a();
        this.c = c0544qfA;
        this.v = c0585s5.a(c0544qfA);
        Zg zgA = c0585s5.a(this);
        this.k = zgA;
        PublicLogger publicLoggerA = c0585s5.d().a();
        this.m = publicLoggerA;
        this.d = Ka.k().y();
        C0398l0 c0398l0A = c0424m0.a(c0274g5, publicLoggerA, c0544qfA);
        this.h = c0398l0A;
        this.l = c0585s5.a();
        C0173c7 c0173c7B = c0585s5.b(this);
        this.e = c0173c7B;
        Ii iiD = c0585s5.d(this);
        this.o = C0585s5.b();
        w();
        C0393kl c0393klA = C0585s5.a(this, poF, new C0429m5(this));
        this.j = c0393klA;
        publicLoggerA.info("Read app environment for component %s. Value: %s", c0274g5.toString(), c0398l0A.a().a);
        C0161bl c0161blC = c0585s5.c();
        this.u = c0161blC;
        this.n = c0585s5.a(c0544qfA, poF, c0393klA, c0173c7B, c0398l0A, c0161blC, iiD);
        C0563r9 c0563r9C = C0585s5.c(this);
        this.g = c0563r9C;
        this.f = C0585s5.a(this, c0563r9C);
        this.q = c0585s5.b(c0544qfA);
        this.p = c0585s5.a(iiD, c0173c7B, zgA, f4, c0274g5, c0544qfA);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0203db
    public final C0274g5 a() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0383kb, io.appmetrica.analytics.impl.InterfaceC0317hm
    public final synchronized void a(C0706wm c0706wm) {
        this.k.a(c0706wm);
        ((A5) this.p).e();
    }

    public final void a(String str) {
        this.c.j(str).a.flushAsync();
    }
}
