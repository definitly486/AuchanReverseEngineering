package io.appmetrica.analytics.impl;

import android.content.ContentValues;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.h9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0304h9 {
    public final String a;
    public String b;
    public final Long c;
    public final Long d;
    public final Long e;
    public final Long f;
    public final C0769z7 g;
    public final EnumC0721xb h;
    public final Integer i;
    public final String j;
    public final Integer k;
    public final Integer l;
    public final String m;
    public final String n;
    public final EnumC0175c9 o;
    public final Aa p;
    public final G9 q;
    public final Boolean r;
    public final Integer s;
    public final byte[] t;
    public final String u;
    public final long v;

    /* JADX WARN: Multi-variable type inference failed */
    public C0304h9(ContentValues contentValues) {
        C0665v7 model = new C0691w7(null, 1, 0 == true ? 1 : 0).toModel(contentValues);
        this.a = model.a().l();
        this.b = model.a().r();
        this.c = model.c();
        this.d = model.b();
        this.e = model.a().m();
        this.f = model.d();
        this.g = model.a().k();
        this.h = model.e();
        this.i = model.a().f();
        this.j = model.a().h();
        this.k = model.a().q();
        this.l = model.a().e();
        this.m = model.a().d();
        this.n = model.a().o();
        EnumC0175c9 enumC0175c9G = model.a().g();
        this.o = enumC0175c9G == null ? EnumC0175c9.a(null) : enumC0175c9G;
        Aa aaJ = model.a().j();
        this.p = aaJ == null ? Aa.a(null) : aaJ;
        this.q = model.a().p();
        this.r = model.a().c();
        this.s = model.a().n();
        this.t = model.a().i();
        String strA = model.a().a();
        this.u = strA == null ? "" : strA;
        Long lB = model.a().b();
        this.v = lB != null ? lB.longValue() : 0L;
    }
}
