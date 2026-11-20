package io.appmetrica.analytics.screenshot.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class V implements Converter {
    public final C0793g a;
    public final Z b;
    public final r c;

    public V() {
        this(null, null, null, 7, null);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final N fromModel(T t) {
        N n = new N();
        C0791e c0791e = t.a;
        n.a = c0791e != null ? this.a.fromModel(c0791e) : null;
        X x = t.b;
        n.b = x != null ? this.b.fromModel(x) : null;
        C0802p c0802p = t.c;
        n.c = c0802p != null ? this.c.fromModel(c0802p) : null;
        return n;
    }

    public V(C0793g c0793g, Z z, r rVar) {
        this.a = c0793g;
        this.b = z;
        this.c = rVar;
    }

    public /* synthetic */ V(C0793g c0793g, Z z, r rVar, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? new C0793g() : c0793g, (i & 2) != 0 ? new Z() : z, (i & 4) != 0 ? new r() : rVar);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final T toModel(N n) {
        C0791e c0791e;
        X x;
        K k = n.a;
        if (k != null) {
            this.a.getClass();
            c0791e = new C0791e(k.a);
        } else {
            c0791e = null;
        }
        M m = n.b;
        if (m != null) {
            this.b.getClass();
            x = new X(m.a, m.b);
        } else {
            x = null;
        }
        L l = n.c;
        return new T(c0791e, x, l != null ? this.c.toModel(l) : null);
    }
}
