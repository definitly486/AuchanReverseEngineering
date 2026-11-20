package io.appmetrica.analytics.impl;

import java.util.Collections;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class Al implements InterfaceC0640u8 {
    public final C0495oj a;

    public Al() {
        this(new C0495oj());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final List<Qi> fromModel(C0783zl c0783zl) {
        N8 n8 = new N8();
        n8.a = 1;
        n8.b = new M8();
        Qi qiFromModel = this.a.fromModel(c0783zl.a);
        n8.b.a = (J8) qiFromModel.a;
        C0532q3 c0532q3 = new C0532q3(C0532q3.b(qiFromModel));
        qiFromModel.b.getBytesTruncated();
        return Collections.singletonList(new Qi(n8, c0532q3));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public Al(C0495oj c0495oj) {
        this.a = c0495oj;
    }

    public final C0783zl a(List<Qi> list) {
        throw new UnsupportedOperationException();
    }
}
