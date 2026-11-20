package io.appmetrica.analytics.impl;

import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.o9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0485o9 {
    public static final Map h;
    public static final C0485o9 i;
    public final Rd a;
    public final Lo b;
    public final R8 c;
    public final N9 d;
    public final InterfaceC0566rc e;
    public final InterfaceC0516pe f;
    public final InterfaceC0331ia g;

    static {
        HashMap map = new HashMap();
        map.put(Aa.FIRST_OCCURRENCE, 1);
        map.put(Aa.NON_FIRST_OCCURENCE, 0);
        map.put(Aa.UNKNOWN, -1);
        h = Collections.unmodifiableMap(map);
        i = new C0485o9(new C0314hj(), new C0552qn(), new C0724xe(), new C0288gj(), new Ga(), new Ha(), new Fa());
    }

    public C0485o9(C0459n9 c0459n9) {
        this(c0459n9.a, c0459n9.b, c0459n9.c, c0459n9.d, c0459n9.e, c0459n9.f, c0459n9.g);
    }

    public final C0745y9 a(C0304h9 c0304h9, C0727xh c0727xh) {
        C0745y9 c0745y9 = new C0745y9();
        C0719x9 c0719x9A = this.f.a(c0304h9.l, c0304h9.m);
        C0615t9 c0615t9A = this.e.a(c0304h9.g);
        if (c0719x9A != null) {
            c0745y9.g = c0719x9A;
        }
        if (c0615t9A != null) {
            c0745y9.f = c0615t9A;
        }
        String strA = this.a.a(c0304h9.a);
        if (strA != null) {
            c0745y9.d = strA;
        }
        c0745y9.e = this.b.a(c0304h9, c0727xh);
        String str = c0304h9.j;
        if (str != null) {
            c0745y9.h = str;
        }
        Integer numA = this.d.a(c0304h9);
        if (numA != null) {
            c0745y9.c = numA.intValue();
        }
        Long l = c0304h9.c;
        if (l != null) {
            c0745y9.a = l.longValue();
        }
        Long l2 = c0304h9.d;
        if (l2 != null) {
            c0745y9.n = l2.longValue();
        }
        Long l3 = c0304h9.e;
        if (l3 != null) {
            c0745y9.o = l3.longValue();
        }
        Long l4 = c0304h9.f;
        if (l4 != null) {
            c0745y9.b = l4.longValue();
        }
        Integer num = c0304h9.k;
        if (num != null) {
            c0745y9.i = num.intValue();
        }
        c0745y9.j = this.c.a(c0304h9.o);
        C0769z7 c0769z7 = c0304h9.g;
        c0745y9.k = c0769z7 != null ? new C0716x6().a(c0769z7.a) : -1;
        String str2 = c0304h9.n;
        if (str2 != null) {
            c0745y9.l = str2.getBytes();
        }
        Aa aa = c0304h9.p;
        Integer num2 = aa != null ? (Integer) h.get(aa) : null;
        if (num2 != null) {
            c0745y9.m = num2.intValue();
        }
        G9 g9 = c0304h9.q;
        if (g9 != null) {
            int iOrdinal = g9.ordinal();
            if (iOrdinal == 0) {
                c0745y9.p = 0;
            } else if (iOrdinal == 1) {
                c0745y9.p = 1;
            } else if (iOrdinal == 2) {
                c0745y9.p = 2;
            }
        }
        Boolean bool = c0304h9.r;
        if (bool != null) {
            c0745y9.q = bool.booleanValue();
        }
        Integer num3 = c0304h9.s;
        if (num3 != null) {
            c0745y9.r = num3.intValue();
        }
        c0745y9.s = ((Fa) this.g).a(c0304h9.t);
        return c0745y9;
    }

    public C0485o9(Rd rd, Lo lo, R8 r8, N9 n9, InterfaceC0566rc interfaceC0566rc, InterfaceC0516pe interfaceC0516pe, InterfaceC0331ia interfaceC0331ia) {
        this.a = rd;
        this.b = lo;
        this.c = r8;
        this.d = n9;
        this.e = interfaceC0566rc;
        this.f = interfaceC0516pe;
        this.g = interfaceC0331ia;
    }

    public static C0459n9 a() {
        return new C0459n9(i);
    }
}
