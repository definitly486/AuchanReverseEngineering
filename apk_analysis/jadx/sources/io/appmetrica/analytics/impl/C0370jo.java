package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.jo, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0370jo implements ProtobufConverter {
    public final Xn a;
    public final Y b;
    public final C0716x6 c;
    public final Sl d;
    public final C0181cf e;
    public final C0207df f;

    public C0370jo() {
        this(new Xn(), new Y(new Pn()), new C0716x6(), new Sl(), new C0181cf(), new C0207df());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0404l6 fromModel(C0344io c0344io) {
        C0404l6 c0404l6 = new C0404l6();
        Yn yn = c0344io.a;
        if (yn != null) {
            c0404l6.a = this.a.fromModel(yn);
        }
        X x = c0344io.b;
        if (x != null) {
            c0404l6.b = this.b.fromModel(x);
        }
        List<Ul> list = c0344io.c;
        if (list != null) {
            c0404l6.e = this.d.fromModel(list);
        }
        String str = c0344io.g;
        if (str != null) {
            c0404l6.c = str;
        }
        c0404l6.d = this.c.a(c0344io.h);
        if (!StringUtils.isNullOrEmpty(c0344io.d)) {
            c0404l6.h = this.e.fromModel(c0344io.d);
        }
        if (!StringUtils.isNullOrEmpty(c0344io.e)) {
            c0404l6.i = c0344io.e.getBytes();
        }
        if (!Do.a(c0344io.f)) {
            c0404l6.j = this.f.fromModel(c0344io.f);
        }
        return c0404l6;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C0370jo(Xn xn, Y y, C0716x6 c0716x6, Sl sl, C0181cf c0181cf, C0207df c0207df) {
        this.b = y;
        this.a = xn;
        this.c = c0716x6;
        this.d = sl;
        this.e = c0181cf;
        this.f = c0207df;
    }

    public final C0344io a(C0404l6 c0404l6) {
        throw new UnsupportedOperationException();
    }
}
