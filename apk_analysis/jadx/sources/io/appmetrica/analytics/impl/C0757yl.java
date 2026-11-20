package io.appmetrica.analytics.impl;

import java.util.Collections;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.yl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0757yl implements InterfaceC0640u8 {
    public final C0156bg a;
    public final C0596sg b;

    public C0757yl() {
        this(new C0156bg(), new C0596sg());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final List<Qi> fromModel(C0731xl c0731xl) {
        Qi qiFromModel;
        N8 n8 = new N8();
        n8.a = 3;
        n8.d = new L8();
        Qi qiFromModel2 = this.a.fromModel(c0731xl.a);
        n8.d.a = (G8) qiFromModel2.a;
        Gg gg = c0731xl.b;
        if (gg != null) {
            qiFromModel = this.b.fromModel(gg);
            n8.d.b = (I8) qiFromModel.a;
        } else {
            qiFromModel = null;
        }
        return Collections.singletonList(new Qi(n8, new C0532q3(C0532q3.b(qiFromModel2, qiFromModel))));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C0757yl(C0156bg c0156bg, C0596sg c0596sg) {
        this.a = c0156bg;
        this.b = c0596sg;
    }

    public final C0731xl a(List<Qi> list) {
        throw new UnsupportedOperationException();
    }
}
