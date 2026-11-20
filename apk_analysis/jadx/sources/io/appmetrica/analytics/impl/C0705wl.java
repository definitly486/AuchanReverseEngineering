package io.appmetrica.analytics.impl;

import java.util.Collections;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.wl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0705wl implements InterfaceC0640u8 {
    public final C0495oj a;
    public final C0156bg b;

    public C0705wl() {
        this(new C0495oj(), new C0156bg());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final List<Qi> fromModel(C0679vl c0679vl) {
        N8 n8 = new N8();
        n8.a = 2;
        n8.c = new K8();
        Qi qiFromModel = this.a.fromModel(c0679vl.b);
        n8.c.b = (J8) qiFromModel.a;
        Qi qiFromModel2 = this.b.fromModel(c0679vl.a);
        n8.c.a = (G8) qiFromModel2.a;
        return Collections.singletonList(new Qi(n8, new C0532q3(C0532q3.b(qiFromModel, qiFromModel2))));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C0705wl(C0495oj c0495oj, C0156bg c0156bg) {
        this.a = c0495oj;
        this.b = c0156bg;
    }

    public final C0679vl a(List<Qi> list) {
        throw new UnsupportedOperationException();
    }
}
