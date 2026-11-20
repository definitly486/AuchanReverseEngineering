package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class Pn implements ProtobufConverter {
    public final Sl a;

    public Pn() {
        this(new Sl());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0535q6 fromModel(On on) {
        C0535q6 c0535q6 = new C0535q6();
        Integer num = on.e;
        c0535q6.e = num == null ? -1 : num.intValue();
        c0535q6.d = on.d;
        c0535q6.b = on.b;
        c0535q6.a = on.a;
        c0535q6.c = on.c;
        Sl sl = this.a;
        List list = on.f;
        ArrayList arrayList = new ArrayList();
        Iterator it = list.iterator();
        while (it.hasNext()) {
            arrayList.add(new Ul((StackTraceElement) it.next()));
        }
        c0535q6.f = sl.fromModel(arrayList);
        return c0535q6;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public Pn(Sl sl) {
        this.a = sl;
    }

    public final On a(C0535q6 c0535q6) {
        throw new UnsupportedOperationException();
    }
}
