package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.lj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0417lj extends AbstractC0131ah {
    public C0417lj(C0455n5 c0455n5) {
        super(c0455n5);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        String str = c0249f6.h;
        if (StringUtils.isNullOrEmpty(str)) {
            return false;
        }
        this.a.a(str);
        return false;
    }
}
