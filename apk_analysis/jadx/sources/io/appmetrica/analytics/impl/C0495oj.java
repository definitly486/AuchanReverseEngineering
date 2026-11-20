package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.util.List;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.oj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0495oj implements Converter {
    public final Ne a;
    public final C3 b;
    public final Sa c;
    public final Sa d;

    public C0495oj() {
        this(new Ne(), new C3(), new Sa(100), new Sa(1000));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Qi fromModel(C0599sj c0599sj) {
        Qi qiFromModel;
        J8 j8 = new J8();
        C0241eo c0241eoA = this.c.a(c0599sj.a);
        j8.a = StringUtils.getUTF8Bytes((String) c0241eoA.a);
        List<String> list = c0599sj.b;
        Qi qiA = null;
        if (list != null) {
            qiFromModel = this.b.fromModel(list);
            j8.b = (C0744y8) qiFromModel.a;
        } else {
            qiFromModel = null;
        }
        C0241eo c0241eoA2 = this.d.a(c0599sj.c);
        j8.c = StringUtils.getUTF8Bytes((String) c0241eoA2.a);
        Map<String, String> map = c0599sj.d;
        if (map != null) {
            qiA = this.a.fromModel(map);
            j8.d = (E8) qiA.a;
        }
        return new Qi(j8, new C0532q3(C0532q3.b(c0241eoA, qiFromModel, c0241eoA2, qiA)));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C0495oj(Ne ne, C3 c3, Sa sa, Sa sa2) {
        this.a = ne;
        this.b = c3;
        this.c = sa;
        this.d = sa2;
    }

    public final C0599sj a(Qi qi) {
        throw new UnsupportedOperationException();
    }
}
