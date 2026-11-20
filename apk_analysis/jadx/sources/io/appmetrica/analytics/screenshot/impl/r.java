package io.appmetrica.analytics.screenshot.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import io.appmetrica.analytics.coreapi.internal.data.Converter;

/* JADX INFO: loaded from: classes3.dex */
public final class r implements Converter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final L fromModel(C0802p c0802p) {
        L l = new L();
        l.a = c0802p.a;
        l.c = (String[]) c0802p.b.toArray(new String[0]);
        l.b = c0802p.c;
        return l;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0802p toModel(L l) {
        return new C0802p(l.a, ArraysKt.toList(l.c), l.b);
    }
}
