package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.services.SafePackageManager;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import java.util.LinkedHashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.s5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public class C0585s5 {
    public final C0534q5 a;
    public final C0559r5 b;
    protected final Context c;
    public final C0274g5 d;
    public final F4 e;
    public final AbstractC0403l5 f;
    protected final C0706wm g;
    public final InterfaceC0649uh h;
    public final C0149b9 i;
    public final ICommonExecutor j;
    public final C0152bc k;
    public final M9 l;
    public final int m;

    public C0585s5(Context context, C0274g5 c0274g5, F4 f4, AbstractC0403l5 abstractC0403l5, C0706wm c0706wm, InterfaceC0649uh interfaceC0649uh, ICommonExecutor iCommonExecutor, int i, C0152bc c0152bc, M9 m9) {
        this(context, c0274g5, f4, abstractC0403l5, c0706wm, interfaceC0649uh, iCommonExecutor, new C0149b9(), i, new C0534q5(f4.a), new C0559r5(context, c0274g5), c0152bc, m9);
    }

    public static C0563r9 c(C0455n5 c0455n5) {
        return new C0563r9(c0455n5);
    }

    public final C0278g9 a() {
        Context context = this.c;
        C0274g5 c0274g5 = this.d;
        return new C0278g9(new C0407l9(context, c0274g5), this.m);
    }

    public final C0173c7 b(C0455n5 c0455n5) {
        return new C0173c7(c0455n5, Ka.I.B().c(this.c, this.d), new Z6(c0455n5.b()), new C0691w7());
    }

    public final C0534q5 d() {
        return this.a;
    }

    public final C0559r5 e() {
        return this.b;
    }

    public final Po f() {
        Po po;
        To c0746ya;
        So soD = Ka.I.D();
        C0274g5 c0274g5 = this.d;
        synchronized (soD) {
            try {
                String strValueOf = String.valueOf(c0274g5);
                LinkedHashMap linkedHashMap = soD.b;
                Object po2 = linkedHashMap.get(strValueOf);
                if (po2 == null) {
                    C0544qf c0544qf = new C0544qf(Ka.I.B().b(soD.a, c0274g5));
                    IHandlerExecutor iHandlerExecutorE = Ka.I.d.e();
                    if (c0274g5.d()) {
                        String str = "appmetrica_vital_" + c0274g5.b + ".dat";
                        c0746ya = new C0689w5(CollectionsKt.listOf((Object[]) new Pair[]{TuplesKt.to(str, new C0746ya(soD.a, str, iHandlerExecutorE, 0L, 8, null)), TuplesKt.to("appmetrica_vital_main.dat", new C0746ya(soD.a, "appmetrica_vital_main.dat", iHandlerExecutorE, 0L, 8, null))}));
                    } else {
                        c0746ya = new C0746ya(soD.a, "appmetrica_vital_" + c0274g5.b + ".dat", iHandlerExecutorE, 0L, 8, null);
                    }
                    po2 = new Po(c0544qf, c0746ya, strValueOf);
                    linkedHashMap.put(strValueOf, po2);
                }
                po = (Po) po2;
            } catch (Throwable th) {
                throw th;
            }
        }
        return po;
    }

    public C0585s5(Context context, C0274g5 c0274g5, F4 f4, AbstractC0403l5 abstractC0403l5, C0706wm c0706wm, InterfaceC0649uh interfaceC0649uh, ICommonExecutor iCommonExecutor, C0149b9 c0149b9, int i, C0534q5 c0534q5, C0559r5 c0559r5, C0152bc c0152bc, M9 m9) {
        this.c = context;
        this.d = c0274g5;
        this.e = f4;
        this.f = abstractC0403l5;
        this.g = c0706wm;
        this.h = interfaceC0649uh;
        this.j = iCommonExecutor;
        this.i = c0149b9;
        this.m = i;
        this.a = c0534q5;
        this.b = c0559r5;
        this.k = c0152bc;
        this.l = m9;
    }

    public final C0161bl c() {
        return new C0161bl(this.c, this.d);
    }

    public final Ii d(C0455n5 c0455n5) {
        Ii ii = new Ii(c0455n5, this.f.a(), this.j);
        C0152bc c0152bc = this.k;
        synchronized (c0152bc) {
            c0152bc.c.add(ii);
        }
        return ii;
    }

    public final Zg a(C0455n5 c0455n5) {
        return new Zg(new C0675vh(c0455n5, this.h, new T3()), this.g, new C0597sh(this.e));
    }

    public static C0393kl a(C0455n5 c0455n5, Po po, C0429m5 c0429m5) {
        C0367jl c0367jl = new C0367jl(po);
        return new C0393kl(c0455n5, c0429m5, new Ea(c0455n5, c0367jl, new C0497ol(c0455n5.h(), Ea.g), AbstractC0763z1.a(), new SystemTimeProvider()), new M2(c0455n5, c0367jl, new C0497ol(c0455n5.h(), M2.g), AbstractC0763z1.a(), new SystemTimeProvider()), new C0341il(c0455n5, c0367jl));
    }

    public static C0326i5 b() {
        return new C0326i5();
    }

    public final D3 b(C0544qf c0544qf) {
        Context context = this.c;
        return new D3(context, c0544qf, context.getPackageName(), new SafePackageManager());
    }

    public final E9 a(C0544qf c0544qf, Po po, C0393kl c0393kl, C0173c7 c0173c7, C0398l0 c0398l0, C0161bl c0161bl, Ii ii) {
        return new E9(c0544qf, po, c0393kl, c0173c7, c0398l0, this.i, c0161bl, this.m, new C0507p5(ii), new SystemTimeProvider());
    }

    public static Gi a(C0455n5 c0455n5, C0563r9 c0563r9) {
        return new Gi(c0563r9, c0455n5);
    }

    public K9 a(P9 p9, C0173c7 c0173c7, Zg zg, F4 f4, C0274g5 c0274g5, C0544qf c0544qf) {
        return this.l.a(p9, c0173c7, zg, f4, c0274g5, c0544qf).a();
    }

    public final C2 a(C0544qf c0544qf) {
        return new C2(this.d, c0544qf);
    }
}
