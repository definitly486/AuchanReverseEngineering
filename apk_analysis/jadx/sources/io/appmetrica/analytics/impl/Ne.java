package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class Ne implements Converter {
    public final Va a;

    public Ne() {
        this(new Va(20480, 100, 1000));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Qi fromModel(Map<String, String> map) {
        C0241eo c0241eoA = this.a.a(map);
        E8 e8 = new E8();
        e8.b = ((E4) c0241eoA.b).b;
        Map map2 = (Map) c0241eoA.a;
        if (map2 != null) {
            e8.a = new D8[map2.size()];
            int i = 0;
            for (Map.Entry entry : map2.entrySet()) {
                e8.a[i] = new D8();
                e8.a[i].a = StringUtils.getUTF8Bytes((String) entry.getKey());
                e8.a[i].b = StringUtils.getUTF8Bytes((String) entry.getValue());
                i++;
            }
        }
        InterfaceC0557r3 interfaceC0557r3 = c0241eoA.b;
        int i2 = ((E4) interfaceC0557r3).a;
        return new Qi(e8, interfaceC0557r3);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public Ne(Va va) {
        this.a = va;
    }

    public final Map<String, String> a(Qi qi) {
        throw new UnsupportedOperationException();
    }
}
