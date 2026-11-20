package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ro, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0578ro extends AbstractC0131ah {
    public C0578ro(C0455n5 c0455n5) {
        super(c0455n5);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        String strJ = this.a.c.j();
        String str = c0249f6.h;
        this.a.a(str);
        if (StringUtils.equalsNullSafety(strJ, str)) {
            return false;
        }
        this.a.a(C0196d4.o());
        return false;
    }
}
