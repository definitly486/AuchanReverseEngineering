package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: loaded from: classes3.dex */
public final class N6 implements ProtobufConverter {
    public final Ng a;

    public N6() {
        this(new Ng());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0456n6 fromModel(M6 m6) {
        C0456n6 c0456n6FromModel = this.a.fromModel(m6.a);
        c0456n6FromModel.g = 1;
        C0430m6 c0430m6 = new C0430m6();
        c0456n6FromModel.h = c0430m6;
        c0430m6.a = StringUtils.correctIllFormedString(m6.b);
        return c0456n6FromModel;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public N6(Ng ng) {
        this.a = ng;
    }

    public final M6 a(C0456n6 c0456n6) {
        throw new UnsupportedOperationException();
    }
}
