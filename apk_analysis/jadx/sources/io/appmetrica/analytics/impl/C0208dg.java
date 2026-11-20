package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.dg, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0208dg implements Converter {
    public final Ra a;

    public C0208dg() {
        this(new Ra(20, 100));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Qi fromModel(List<String> list) {
        C0241eo c0241eoA = this.a.a((List<Object>) list);
        List list2 = (List) c0241eoA.a;
        H8[] h8Arr = new H8[0];
        if (list2 != null) {
            h8Arr = new H8[list2.size()];
            for (int i = 0; i < list2.size(); i++) {
                H8 h8 = new H8();
                h8Arr[i] = h8;
                h8.a = StringUtils.getUTF8Bytes((String) list2.get(i));
            }
        }
        c0241eoA.b.getBytesTruncated();
        return new Qi(h8Arr, c0241eoA.b);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C0208dg(Ra ra) {
        this.a = ra;
    }

    public final List<String> a(Qi qi) {
        throw new UnsupportedOperationException();
    }
}
