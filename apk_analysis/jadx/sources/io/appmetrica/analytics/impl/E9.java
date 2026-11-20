package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import io.appmetrica.analytics.coreutils.internal.time.TimeProvider;
import java.util.HashMap;
import java.util.Map;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class E9 {
    public final C0544qf a;
    public final Po b;
    public final C0393kl c;
    public final C0173c7 d;
    public final C0149b9 e;
    public final C0161bl f;
    public final C0398l0 g;
    public final C0507p5 h;
    public final TimeProvider i;
    public final int j;
    public long k;
    public int l;

    public E9(C0544qf c0544qf, Po po, C0393kl c0393kl, C0173c7 c0173c7, C0398l0 c0398l0, C0149b9 c0149b9, C0161bl c0161bl, int i, C0507p5 c0507p5, SystemTimeProvider systemTimeProvider) {
        this.a = c0544qf;
        this.b = po;
        this.c = c0393kl;
        this.d = c0173c7;
        this.g = c0398l0;
        this.e = c0149b9;
        this.f = c0161bl;
        this.j = i;
        this.i = systemTimeProvider;
        this.h = c0507p5;
        this.k = c0544qf.i();
        this.l = c0544qf.h();
    }

    public final void a(C0249f6 c0249f6, C0471nl c0471nl) {
        long jOptLong;
        Map map = c0249f6.p;
        C0161bl c0161bl = this.f;
        c0161bl.getClass();
        map.putAll(new HashMap(c0161bl.b));
        c0249f6.c(this.a.j());
        c0249f6.o = Integer.valueOf(this.b.b());
        C0372k0 c0372k0A = this.g.a();
        C0149b9 c0149b9 = this.e;
        c0149b9.getClass();
        InterfaceC0123a9 interfaceC0123a9 = (InterfaceC0123a9) c0149b9.b.a(EnumC0721xb.a(c0249f6.d));
        C0173c7 c0173c7 = this.d;
        S8 s8A = interfaceC0123a9.a(c0249f6);
        int i = c0249f6.d;
        Po po = this.b;
        C0743y7 c0743y7 = new C0743y7(c0173c7.d, c0471nl, i, po, s8A, (C0727xh) c0173c7.e.k.a(), c0372k0A);
        Long lValueOf = Long.valueOf(c0471nl.a);
        EnumC0523pl enumC0523pl = c0471nl.d;
        Long lValueOf2 = Long.valueOf(c0471nl.b);
        EnumC0721xb enumC0721xbA = EnumC0721xb.a(c0743y7.h.d);
        long j = 0;
        if (!Q9.g.contains(EnumC0721xb.a(i))) {
            synchronized (po) {
                JSONObject jSONObjectA = po.a.a();
                jOptLong = jSONObjectA.optLong("global_number", 0L);
                po.a.a(jSONObjectA.put("global_number", jOptLong + 1));
            }
            j = jOptLong;
        }
        ContentValues contentValuesFromModel = c0173c7.i.fromModel(new C0665v7(lValueOf, enumC0523pl, lValueOf2, enumC0721xbA, Long.valueOf(j), Long.valueOf(c0471nl.c), c0743y7.a()));
        Integer asInteger = contentValuesFromModel.getAsInteger("type");
        asInteger.intValue();
        c0173c7.j.b.submit(contentValuesFromModel, AbstractC0630to.a.contains(asInteger));
        this.h.a.h();
    }
}
