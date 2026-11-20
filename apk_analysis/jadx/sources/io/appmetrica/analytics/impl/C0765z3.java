package io.appmetrica.analytics.impl;

import java.util.Collections;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.z3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0765z3 implements InterfaceC0640u8 {
    public final A3 a;

    public C0765z3() {
        this(new A3());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final List<Qi> fromModel(C0739y3 c0739y3) {
        N8 n8 = new N8();
        n8.e = new C0692w8();
        Qi qiFromModel = this.a.fromModel(c0739y3.b);
        n8.e.a = (C0718x8) qiFromModel.a;
        n8.a = c0739y3.a;
        return Collections.singletonList(new Qi(n8, new C0532q3(C0532q3.b(qiFromModel))));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C0765z3(A3 a3) {
        this.a = a3;
    }

    public final C0739y3 a(List<Qi> list) {
        throw new UnsupportedOperationException();
    }
}
