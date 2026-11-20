package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class C3 implements Converter {
    public final Ra a;

    public C3() {
        this(new Ra(20, 100));
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Qi fromModel(List<String> list) {
        C0241eo c0241eoA = this.a.a((List<Object>) list);
        C0744y8 c0744y8 = new C0744y8();
        c0744y8.a = StringUtils.getUTF8Bytes((List<String>) c0241eoA.a);
        InterfaceC0557r3 interfaceC0557r3 = c0241eoA.b;
        int i = ((E4) interfaceC0557r3).a;
        return new Qi(c0744y8, interfaceC0557r3);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public C3(Ra ra) {
        this.a = ra;
    }

    public final List<String> a(Qi qi) {
        throw new UnsupportedOperationException();
    }
}
