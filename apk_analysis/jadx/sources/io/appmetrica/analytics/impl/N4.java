package io.appmetrica.analytics.impl;

import android.content.Context;
import android.os.ResultReceiver;
import io.appmetrica.analytics.internal.CounterConfigurationReporterType;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class N4 implements InterfaceC0203db, InterfaceC0317hm, InterfaceC0254fb {
    public final Context a;
    public final C0274g5 b;
    public final Rm c;
    public final Mh d;
    public final U4 e;
    public final Bn f;
    public ArrayList g;
    public final C0300h5 h;
    public final C0376k4 i;
    public final C0778zg j;
    public final Object k;

    public N4(Context context, Yl yl, C0274g5 c0274g5, G4 g4) {
        this(context, yl, c0274g5, g4, new Mh(g4.b), new C0300h5(), new P4());
    }

    public static void b(G4 g4) {
        Ka.I.c().b(!Boolean.FALSE.equals(g4.b.n));
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0203db
    public final void a(F4 f4) {
        Mh mh = this.d;
        mh.a = mh.a.mergeFrom(f4);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0203db
    public final void c() {
    }

    public final C0376k4 d() {
        return this.i;
    }

    public final F4 e() {
        return this.d.a;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0203db
    public final Context getContext() {
        return this.a;
    }

    public N4(Context context, Yl yl, C0274g5 c0274g5, G4 g4, Mh mh, C0300h5 c0300h5, P4 p4) {
        this.g = new ArrayList();
        this.k = new Object();
        Context applicationContext = context.getApplicationContext();
        this.a = applicationContext;
        this.b = c0274g5;
        this.d = mh;
        this.h = c0300h5;
        this.e = P4.a(this);
        b(g4);
        Rm rmA = yl.a(applicationContext, c0274g5, g4.a);
        this.c = rmA;
        this.i = AbstractC0402l4.a(rmA, Ka.k().c());
        this.f = p4.a(this, rmA);
        C0778zg c0778zgU = Ka.k().u();
        this.j = c0778zgU;
        c0778zgU.a();
        yl.a(c0274g5, this);
    }

    public final synchronized void a(L4 l4) {
        this.h.a.add(l4);
        T6.a(l4.c, this.i.a(Wm.a(this.c.e().l)));
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0203db
    public final CounterConfigurationReporterType b() {
        return CounterConfigurationReporterType.COMMUTATION;
    }

    public final synchronized void b(L4 l4) {
        this.h.a.remove(l4);
    }

    public final void a(C0249f6 c0249f6, L4 l4) {
        U4 u4 = this.e;
        u4.getClass();
        u4.a(c0249f6, new T4(l4));
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0203db
    public final C0274g5 a() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0317hm
    public final void a(EnumC0136am enumC0136am, C0706wm c0706wm) {
        synchronized (this.k) {
            try {
                ArrayList arrayList = this.g;
                int size = arrayList.size();
                int i = 0;
                while (i < size) {
                    Object obj = arrayList.get(i);
                    i++;
                    C0617tb c0617tb = (C0617tb) obj;
                    T6.a(c0617tb.a, enumC0136am, this.i.a(c0617tb.c));
                }
                this.g.clear();
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0317hm
    public final void a(C0706wm c0706wm) {
        synchronized (this.k) {
            try {
                for (L4 l4 : this.h.a) {
                    T6.a(l4.c, this.i.a(Wm.a(c0706wm.l)));
                }
                ArrayList arrayList = new ArrayList();
                ArrayList arrayList2 = this.g;
                int size = arrayList2.size();
                int i = 0;
                while (i < size) {
                    Object obj = arrayList2.get(i);
                    i++;
                    C0617tb c0617tb = (C0617tb) obj;
                    if (AbstractC0628tm.a(c0706wm, c0617tb.b, c0617tb.c, new C0565rb())) {
                        T6.a(c0617tb.a, this.i.a(c0617tb.c));
                    } else {
                        arrayList.add(c0617tb);
                    }
                }
                this.g = new ArrayList(arrayList);
                if (!arrayList.isEmpty()) {
                    this.f.c();
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public final void a(C0617tb c0617tb) {
        ResultReceiver resultReceiver;
        HashMap map;
        List<String> list;
        HashMap map2 = new HashMap();
        if (c0617tb != null) {
            list = c0617tb.b;
            resultReceiver = c0617tb.a;
            map = c0617tb.c;
        } else {
            resultReceiver = null;
            map = map2;
            list = null;
        }
        boolean zA = this.c.a(list, map);
        if (!zA) {
            T6.a(resultReceiver, this.i.a(map));
        }
        if (!this.c.g()) {
            if (zA) {
                T6.a(resultReceiver, this.i.a(map));
                return;
            }
            return;
        }
        synchronized (this.k) {
            if (zA && c0617tb != null) {
                try {
                    this.g.add(c0617tb);
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        this.f.c();
    }

    public final void a(final ResultReceiver resultReceiver) {
        C0778zg c0778zg = this.j;
        InterfaceC0726xg interfaceC0726xg = new InterfaceC0726xg() { // from class: io.appmetrica.analytics.impl.N4$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.impl.InterfaceC0726xg
            public final void a(Eg eg) {
                Fg.a(resultReceiver, eg.a());
            }
        };
        c0778zg.getClass();
        c0778zg.a.a(new C0236ej(interfaceC0726xg));
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0254fb
    public final void a(G4 g4) {
        this.c.a(g4.a);
        a(g4.b);
    }
}
