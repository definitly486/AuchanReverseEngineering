package io.appmetrica.analytics.impl;

import android.text.TextUtils;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.coreutils.internal.WrapUtils;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class Ng implements ProtobufConverter {
    public final Xn a;
    public final Y b;
    public final C0716x6 c;
    public final Sl d;
    public final C0181cf e;
    public final C0207df f;

    public Ng() {
        this(new Xn(), new Y(new Pn()), new C0716x6(), new Sl(), new C0181cf(), new C0207df());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0456n6 fromModel(Mg mg) {
        C0456n6 c0456n6 = new C0456n6();
        c0456n6.f = StringUtils.correctIllFormedString((String) WrapUtils.getOrDefault(mg.a, c0456n6.f));
        C0344io c0344io = mg.b;
        if (c0344io != null) {
            Yn yn = c0344io.a;
            if (yn != null) {
                c0456n6.a = this.a.fromModel(yn);
            }
            X x = c0344io.b;
            if (x != null) {
                c0456n6.b = this.b.fromModel(x);
            }
            List<Ul> list = c0344io.c;
            if (list != null) {
                c0456n6.e = this.d.fromModel(list);
            }
            c0456n6.c = (String) WrapUtils.getOrDefault(c0344io.g, c0456n6.c);
            c0456n6.d = this.c.a(c0344io.h);
            if (!TextUtils.isEmpty(c0344io.d)) {
                c0456n6.i = this.e.fromModel(c0344io.d);
            }
            if (!TextUtils.isEmpty(c0344io.e)) {
                c0456n6.j = c0344io.e.getBytes();
            }
            if (!Do.a(c0344io.f)) {
                c0456n6.k = this.f.fromModel(c0344io.f);
            }
        }
        return c0456n6;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public Ng(Xn xn, Y y, C0716x6 c0716x6, Sl sl, C0181cf c0181cf, C0207df c0207df) {
        this.a = xn;
        this.b = y;
        this.c = c0716x6;
        this.d = sl;
        this.e = c0181cf;
        this.f = c0207df;
    }

    public final Mg a(C0456n6 c0456n6) {
        throw new UnsupportedOperationException();
    }
}
