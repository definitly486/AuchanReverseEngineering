package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import java.util.Iterator;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.j9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0355j9 implements ProtobufConverter {
    public static O9 a(C0330i9 c0330i9) {
        O9 o9 = new O9();
        o9.d = new int[c0330i9.b.size()];
        Iterator it = c0330i9.b.iterator();
        int i = 0;
        while (it.hasNext()) {
            o9.d[i] = ((Integer) it.next()).intValue();
            i++;
        }
        o9.c = c0330i9.d;
        o9.b = c0330i9.c;
        o9.a = c0330i9.a;
        return o9;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final /* bridge */ /* synthetic */ Object fromModel(Object obj) {
        return a((C0330i9) obj);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        O9 o9 = (O9) obj;
        return new C0330i9(o9.a, o9.b, o9.c, CollectionUtils.hashSetFromIntArray(o9.d));
    }
}
