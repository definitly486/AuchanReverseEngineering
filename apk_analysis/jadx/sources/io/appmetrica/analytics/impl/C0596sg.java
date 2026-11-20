package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.sg, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0596sg implements Converter {
    public final C0495oj a;
    public final Sa b;
    public final Sa c;

    public C0596sg() {
        this(new C0495oj(), new Sa(100), new Sa(2048));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Qi fromModel(Gg gg) {
        Qi qiFromModel;
        I8 i8 = new I8();
        C0241eo c0241eoA = this.b.a(gg.a);
        i8.a = StringUtils.getUTF8Bytes((String) c0241eoA.a);
        C0241eo c0241eoA2 = this.c.a(gg.b);
        i8.b = StringUtils.getUTF8Bytes((String) c0241eoA2.a);
        C0599sj c0599sj = gg.c;
        if (c0599sj != null) {
            qiFromModel = this.a.fromModel(c0599sj);
            i8.c = (J8) qiFromModel.a;
        } else {
            qiFromModel = null;
        }
        return new Qi(i8, new C0532q3(C0532q3.b(c0241eoA, c0241eoA2, qiFromModel)));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C0596sg(C0495oj c0495oj, Sa sa, Sa sa2) {
        this.a = c0495oj;
        this.b = sa;
        this.c = sa2;
    }

    public final Gg a(Qi qi) {
        throw new UnsupportedOperationException();
    }
}
