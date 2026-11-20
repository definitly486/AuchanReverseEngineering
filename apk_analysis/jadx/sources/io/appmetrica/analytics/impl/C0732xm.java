package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.networktasks.internal.RetryPolicyConfig;
import java.util.Arrays;
import java.util.List;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.xm, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0732xm implements ProtobufConverter {
    public final Te a = new Te();
    public final Ca b = new Ca();
    public final Ym c = new Ym();
    public final C0661v3 d = new C0661v3();
    public final A2 e = new A2();
    public final O6 f = new O6();
    public final Um g = new Um();
    public final Jd h = new Jd();
    public final X9 i = new X9();

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Nm fromModel(Am am) {
        Nm nm = new Nm();
        nm.s = am.u;
        nm.t = am.v;
        String str = am.a;
        if (str != null) {
            nm.a = str;
        }
        List list = am.f;
        if (list != null) {
            nm.f = (String[]) list.toArray(new String[list.size()]);
        }
        List list2 = am.g;
        if (list2 != null) {
            nm.g = (String[]) list2.toArray(new String[list2.size()]);
        }
        List list3 = am.b;
        if (list3 != null) {
            nm.c = (String[]) list3.toArray(new String[list3.size()]);
        }
        List list4 = am.h;
        if (list4 != null) {
            nm.o = (String[]) list4.toArray(new String[list4.size()]);
        }
        Map<String, ? extends List<String>> map = am.i;
        if (map != null) {
            nm.h = this.f.fromModel(map);
        }
        Se se = am.s;
        if (se != null) {
            nm.v = this.a.fromModel(se);
        }
        String str2 = am.j;
        if (str2 != null) {
            nm.j = str2;
        }
        String str3 = am.c;
        if (str3 != null) {
            nm.d = str3;
        }
        String str4 = am.d;
        if (str4 != null) {
            nm.e = str4;
        }
        String str5 = am.e;
        if (str5 != null) {
            nm.r = str5;
        }
        nm.i = this.b.fromModel(am.m);
        String str6 = am.k;
        if (str6 != null) {
            nm.k = str6;
        }
        String str7 = am.l;
        if (str7 != null) {
            nm.l = str7;
        }
        nm.m = am.p;
        nm.b = am.n;
        nm.q = am.o;
        RetryPolicyConfig retryPolicyConfig = am.t;
        nm.w = retryPolicyConfig.maxIntervalSeconds;
        nm.x = retryPolicyConfig.exponentialMultiplier;
        String str8 = am.q;
        if (str8 != null) {
            nm.n = str8;
        }
        Xm xm = am.r;
        if (xm != null) {
            this.c.getClass();
            Mm mm = new Mm();
            mm.a = xm.a;
            nm.p = mm;
        }
        nm.u = am.w;
        C0609t3 c0609t3 = am.x;
        if (c0609t3 != null) {
            this.d.getClass();
            Fm fm = new Fm();
            fm.a = c0609t3.a;
            nm.y = fm;
        }
        C0764z2 c0764z2 = am.y;
        if (c0764z2 != null) {
            nm.z = this.e.fromModel(c0764z2);
        }
        nm.A = this.g.fromModel(am.z);
        nm.B = this.h.fromModel(am.A);
        nm.C = this.i.fromModel(am.B);
        return nm;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Am toModel(Nm nm) {
        C0784zm c0784zm = new C0784zm(this.b.toModel(nm.i));
        c0784zm.a = nm.a;
        c0784zm.j = nm.j;
        c0784zm.c = nm.d;
        c0784zm.b = Arrays.asList(nm.c);
        c0784zm.g = Arrays.asList(nm.g);
        c0784zm.f = Arrays.asList(nm.f);
        c0784zm.d = nm.e;
        c0784zm.e = nm.r;
        c0784zm.h = Arrays.asList(nm.o);
        c0784zm.k = nm.k;
        c0784zm.l = nm.l;
        c0784zm.q = nm.m;
        c0784zm.o = nm.b;
        c0784zm.p = nm.q;
        c0784zm.t = nm.s;
        c0784zm.u = nm.t;
        c0784zm.r = nm.n;
        c0784zm.v = nm.u;
        c0784zm.w = new RetryPolicyConfig(nm.w, nm.x);
        c0784zm.i = this.f.toModel(nm.h);
        Km km = nm.v;
        if (km != null) {
            this.a.getClass();
            c0784zm.n = new Se(km.a, km.b);
        }
        Mm mm = nm.p;
        if (mm != null) {
            this.c.getClass();
            c0784zm.s = new Xm(mm.a);
        }
        Fm fm = nm.y;
        if (fm != null) {
            this.d.getClass();
            c0784zm.x = new C0609t3(fm.a);
        }
        Em em = nm.z;
        if (em != null) {
            c0784zm.y = this.e.toModel(em);
        }
        Lm lm = nm.A;
        if (lm != null) {
            this.g.getClass();
            c0784zm.z = new Tm(lm.a);
        }
        c0784zm.A = this.h.toModel(nm.B);
        Hm hm = nm.C;
        if (hm != null) {
            this.i.getClass();
            c0784zm.B = new W9(hm.a);
        }
        return new Am(c0784zm);
    }
}
