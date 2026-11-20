package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.networktasks.internal.BaseRequestConfig;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.vh, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0675vh extends AbstractC0172c6 {
    public final C0455n5 b;
    public final InterfaceC0649uh c;
    public final T3 d;

    public C0675vh(C0455n5 c0455n5, InterfaceC0649uh interfaceC0649uh) {
        this(c0455n5, interfaceC0649uh, new T3());
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // io.appmetrica.analytics.impl.AbstractC0172c6, io.appmetrica.analytics.networktasks.internal.BaseRequestConfig.ComponentLoader, io.appmetrica.analytics.networktasks.internal.BaseRequestConfig.RequestConfigLoader
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] and merged with bridge method [inline-methods] and merged with bridge method [inline-methods] */
    public final C0727xh load(C0146b6 c0146b6) {
        C0727xh c0727xh = (C0727xh) super.load(c0146b6);
        c0727xh.m = ((C0597sh) c0146b6.componentArguments).a;
        c0727xh.r = this.b.t.a();
        c0727xh.w = this.b.q.a();
        C0597sh c0597sh = (C0597sh) c0146b6.componentArguments;
        c0727xh.d = c0597sh.b;
        c0727xh.e = c0597sh.c;
        c0727xh.f = c0597sh.d;
        c0727xh.i = c0597sh.e;
        c0727xh.g = c0597sh.f;
        c0727xh.h = c0597sh.g;
        Boolean boolValueOf = Boolean.valueOf(c0597sh.h);
        InterfaceC0649uh interfaceC0649uh = this.c;
        c0727xh.j = boolValueOf;
        c0727xh.k = interfaceC0649uh;
        C0597sh c0597sh2 = (C0597sh) c0146b6.componentArguments;
        c0727xh.v = c0597sh2.j;
        C0706wm c0706wm = c0146b6.a;
        C4 c4 = c0706wm.n;
        c0727xh.n = c4.a;
        Se se = c0706wm.s;
        if (se != null) {
            c0727xh.s = se.a;
            c0727xh.t = se.b;
        }
        c0727xh.o = c4.b;
        c0727xh.q = c0706wm.e;
        c0727xh.p = c0706wm.k;
        T3 t3 = this.d;
        Map<String, String> map = c0597sh2.i;
        Q3 q3F = Ka.I.f();
        t3.getClass();
        c0727xh.u = T3.a(map, c0706wm, q3F);
        c0727xh.x = this.b.v.e.keySet();
        return c0727xh;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.BaseRequestConfig.ComponentLoader
    public final BaseRequestConfig createBlankConfig() {
        return new C0727xh(this.b);
    }

    public C0675vh(C0455n5 c0455n5, InterfaceC0649uh interfaceC0649uh, T3 t3) {
        super(c0455n5.getContext(), c0455n5.a().c());
        this.b = c0455n5;
        this.c = interfaceC0649uh;
        this.d = t3;
    }

    public final C0727xh a() {
        return new C0727xh(this.b);
    }
}
