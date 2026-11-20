package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import java.util.Iterator;

/* JADX INFO: loaded from: classes3.dex */
public final class Y implements ProtobufConverter {
    public final Pn a;

    public Y(Pn pn) {
        this.a = pn;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0301h6 fromModel(X x) {
        C0301h6 c0301h6 = new C0301h6();
        On on = x.a;
        if (on != null) {
            c0301h6.a = this.a.fromModel(on);
        }
        c0301h6.b = new C0535q6[x.b.size()];
        Iterator it = x.b.iterator();
        int i = 0;
        while (it.hasNext()) {
            c0301h6.b[i] = this.a.fromModel((On) it.next());
            i++;
        }
        String str = x.c;
        if (str != null) {
            c0301h6.c = str;
        }
        return c0301h6;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public final X a(C0301h6 c0301h6) {
        throw new UnsupportedOperationException();
    }
}
