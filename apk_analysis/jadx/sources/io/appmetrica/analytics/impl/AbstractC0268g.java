package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import java.util.concurrent.TimeUnit;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.g, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0268g implements InterfaceC0513pb {
    public final C0455n5 a;
    public final C0367jl b;
    public final C0497ol c;
    public final C0316hl d;
    public final InterfaceC0435mb e;
    public final SystemTimeProvider f;

    public AbstractC0268g(C0455n5 c0455n5, C0367jl c0367jl, C0497ol c0497ol, C0316hl c0316hl, InterfaceC0435mb interfaceC0435mb, SystemTimeProvider systemTimeProvider) {
        this.a = c0455n5;
        this.b = c0367jl;
        this.c = c0497ol;
        this.d = c0316hl;
        this.e = interfaceC0435mb;
        this.f = systemTimeProvider;
    }

    public final Xk b() {
        Wk wk = new Wk(this.d);
        wk.h = this.c.c.a(C0497ol.j);
        wk.g = this.c.c.b(C0497ol.g);
        wk.d = this.c.c.b(C0497ol.h);
        wk.e = this.c.c.b(C0497ol.i);
        wk.c = this.c.c.b(C0497ol.f);
        wk.i = this.c.c.b(C0497ol.d);
        wk.a = this.c.c.b(C0497ol.e);
        wk.j = this.c.c.a(C0497ol.k);
        return new Xk(wk);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0513pb
    public final Uk a() {
        if (this.c.i()) {
            return new Uk(this.a, this.c, b(), this.f);
        }
        return null;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0513pb
    public final Uk a(Vk vk) {
        boolean zB;
        if (this.c.i()) {
            this.e.reportEvent("create session with non-empty storage");
        }
        C0455n5 c0455n5 = this.a;
        C0497ol c0497ol = this.c;
        long jA = this.b.a();
        C0497ol c0497ol2 = this.c;
        c0497ol2.a(C0497ol.f, Long.valueOf(jA));
        c0497ol2.a(C0497ol.d, Long.valueOf(vk.a));
        c0497ol2.a(C0497ol.h, Long.valueOf(vk.a));
        c0497ol2.a(C0497ol.i, Long.valueOf(vk.b));
        c0497ol2.a(C0497ol.g, 0L);
        c0497ol2.a(C0497ol.j, Boolean.TRUE);
        c0497ol2.a();
        C0173c7 c0173c7 = this.a.e;
        EnumC0523pl enumC0523pl = this.d.a;
        long seconds = TimeUnit.MILLISECONDS.toSeconds(vk.b);
        c0173c7.getClass();
        K7 k7 = new K7(null, 1, null);
        C0727xh c0727xh = (C0727xh) c0173c7.e.k.a();
        Long lValueOf = Long.valueOf(jA);
        Long lValueOf2 = Long.valueOf(seconds);
        String strA = L7.a(c0727xh);
        Long lValueOf3 = Long.valueOf(AbstractC0138ao.a());
        C0496ok c0496ok = AbstractC0470nk.a;
        synchronized (c0496ok) {
            zB = c0496ok.b.b(true);
        }
        c0173c7.a(k7.fromModel(new J7(lValueOf, enumC0523pl, strA, new I7(lValueOf2, lValueOf3, Boolean.valueOf(zB)))));
        return new Uk(c0455n5, c0497ol, b(), new SystemTimeProvider());
    }
}
