package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import java.util.Collection;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class Sf implements Converter {
    public final C0114a0 a;
    public final Tf b;

    public Sf() {
        this(new C0114a0(), new Tf(30));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Qi fromModel(Uf uf) {
        int bytesTruncated;
        F8 f8 = new F8();
        Qi qiFromModel = this.a.fromModel(uf.a);
        f8.a = (C0666v8) qiFromModel.a;
        C0241eo c0241eoA = this.b.a(uf.b);
        if (Do.a((Collection) c0241eoA.a)) {
            bytesTruncated = 0;
        } else {
            f8.b = new C0666v8[((List) c0241eoA.a).size()];
            bytesTruncated = 0;
            for (int i = 0; i < ((List) c0241eoA.a).size(); i++) {
                Qi qiFromModel2 = this.a.fromModel((C0140b0) ((List) c0241eoA.a).get(i));
                f8.b[i] = (C0666v8) qiFromModel2.a;
                bytesTruncated += qiFromModel2.b.getBytesTruncated();
            }
        }
        return new Qi(f8, new C0532q3(C0532q3.b(qiFromModel, c0241eoA, new C0532q3(bytesTruncated))));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public Sf(C0114a0 c0114a0, Tf tf) {
        this.a = c0114a0;
        this.b = tf;
    }

    public final Uf a(Qi qi) {
        throw new UnsupportedOperationException();
    }
}
