package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import java.util.concurrent.TimeUnit;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.il, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0341il implements InterfaceC0513pb {
    public final C0455n5 a;
    public final C0367jl b;
    public final C0497ol c;
    public final C0316hl d = C0316hl.a(EnumC0523pl.BACKGROUND).b().a();

    public C0341il(C0455n5 c0455n5, C0367jl c0367jl) {
        this.a = c0455n5;
        this.b = c0367jl;
        this.c = new C0497ol(c0455n5.h(), M2.g);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0513pb
    public final Uk a() {
        return null;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0513pb
    public final Uk a(Vk vk) {
        String strA;
        boolean zB;
        long jA = this.b.a();
        C0497ol c0497ol = this.c;
        c0497ol.a(C0497ol.f, Long.valueOf(jA));
        c0497ol.a(C0497ol.d, Long.valueOf(vk.a));
        c0497ol.a(C0497ol.h, Long.valueOf(vk.a));
        c0497ol.a(C0497ol.i, Long.valueOf(vk.b));
        c0497ol.a(C0497ol.g, 0L);
        c0497ol.a(C0497ol.j, Boolean.FALSE);
        c0497ol.a();
        C0173c7 c0173c7 = this.a.e;
        EnumC0523pl enumC0523pl = EnumC0523pl.BACKGROUND;
        long seconds = TimeUnit.MILLISECONDS.toSeconds(vk.b);
        C0419ll c0419ll = vk.c;
        c0173c7.getClass();
        K7 k7 = new K7(null, 1, null);
        C0727xh c0727xh = (C0727xh) c0173c7.e.k.a();
        Long lValueOf = Long.valueOf(jA);
        Long lValueOf2 = Long.valueOf(seconds);
        if (c0419ll == null || (strA = c0419ll.a) == null) {
            strA = L7.a(c0727xh);
        }
        Long lValueOf3 = Long.valueOf(AbstractC0138ao.a());
        C0496ok c0496ok = AbstractC0470nk.a;
        synchronized (c0496ok) {
            zB = c0496ok.b.b(true);
        }
        c0173c7.a(k7.fromModel(new J7(lValueOf, enumC0523pl, strA, new I7(lValueOf2, lValueOf3, Boolean.valueOf(zB)))));
        Wk wk = new Wk(this.d);
        wk.h = this.c.c.a(C0497ol.j);
        wk.g = this.c.c.b(C0497ol.g);
        wk.d = this.c.c.b(C0497ol.h);
        wk.e = this.c.c.b(C0497ol.i);
        wk.c = this.c.c.b(C0497ol.f);
        wk.i = this.c.c.b(C0497ol.d);
        wk.a = this.c.c.b(C0497ol.e);
        return new Uk(this.a, this.c, new Xk(wk), new SystemTimeProvider());
    }
}
