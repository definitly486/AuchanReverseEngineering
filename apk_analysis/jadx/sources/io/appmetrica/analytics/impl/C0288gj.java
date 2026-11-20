package io.appmetrica.analytics.impl;

import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.gj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0288gj implements N9 {
    @Override // io.appmetrica.analytics.impl.N9
    public final Integer a(C0304h9 c0304h9) {
        EnumC0721xb enumC0721xb = c0304h9.h;
        if (enumC0721xb != null) {
            return (Integer) AbstractC0388kg.c.get(enumC0721xb);
        }
        Map map = AbstractC0388kg.a;
        return null;
    }
}
