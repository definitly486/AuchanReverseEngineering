package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ListConverter;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class Sl implements ListConverter {
    public final Tl a = new Tl();

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0508p6[] fromModel(List<Ul> list) {
        C0508p6[] c0508p6Arr = new C0508p6[list.size()];
        Iterator<Ul> it = list.iterator();
        int i = 0;
        while (it.hasNext()) {
            c0508p6Arr[i] = this.a.fromModel(it.next());
            i++;
        }
        return c0508p6Arr;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public final List<Ul> a(C0508p6[] c0508p6Arr) {
        throw new UnsupportedOperationException();
    }
}
