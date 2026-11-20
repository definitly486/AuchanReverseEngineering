package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.util.List;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.bg, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0156bg implements Converter {
    public final Ne a;
    public final Sf b;
    public final C3 c;
    public final C0208dg d;
    public final Sa e;
    public final Sa f;

    public C0156bg() {
        this(new Ne(), new Sf(), new C3(), new C0208dg(), new Sa(100), new Sa(1000));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Qi fromModel(C0182cg c0182cg) {
        Qi qiFromModel;
        Qi qiFromModel2;
        Qi qiA;
        Qi qiA2;
        G8 g8 = new G8();
        C0241eo c0241eoA = this.e.a(c0182cg.a);
        g8.a = StringUtils.getUTF8Bytes((String) c0241eoA.a);
        C0241eo c0241eoA2 = this.f.a(c0182cg.b);
        g8.b = StringUtils.getUTF8Bytes((String) c0241eoA2.a);
        List<String> list = c0182cg.c;
        Qi qiFromModel3 = null;
        if (list != null) {
            qiFromModel = this.c.fromModel(list);
            g8.c = (C0744y8) qiFromModel.a;
        } else {
            qiFromModel = null;
        }
        Map<String, String> map = c0182cg.d;
        if (map != null) {
            qiFromModel2 = this.a.fromModel(map);
            g8.d = (E8) qiFromModel2.a;
        } else {
            qiFromModel2 = null;
        }
        Uf uf = c0182cg.e;
        if (uf != null) {
            qiA = this.b.fromModel(uf);
            g8.e = (F8) qiA.a;
        } else {
            qiA = null;
        }
        Uf uf2 = c0182cg.f;
        if (uf2 != null) {
            qiA2 = this.b.fromModel(uf2);
            g8.f = (F8) qiA2.a;
        } else {
            qiA2 = null;
        }
        List<String> list2 = c0182cg.g;
        if (list2 != null) {
            qiFromModel3 = this.d.fromModel(list2);
            g8.g = (H8[]) qiFromModel3.a;
        }
        return new Qi(g8, new C0532q3(C0532q3.b(c0241eoA, c0241eoA2, qiFromModel, qiFromModel2, qiA, qiA2, qiFromModel3)));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C0156bg(Ne ne, Sf sf, C3 c3, C0208dg c0208dg, Sa sa, Sa sa2) {
        this.a = ne;
        this.b = sf;
        this.c = c3;
        this.d = c0208dg;
        this.e = sa;
        this.f = sa2;
    }

    public final C0182cg a(Qi qi) {
        throw new UnsupportedOperationException();
    }
}
