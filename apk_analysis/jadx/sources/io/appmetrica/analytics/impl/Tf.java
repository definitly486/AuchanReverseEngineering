package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: loaded from: classes3.dex */
public final class Tf extends Qa {
    public Tf(int i) {
        super(i);
    }

    @Override // io.appmetrica.analytics.impl.Qa
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final int b(C0140b0 c0140b0) {
        if (c0140b0 == null) {
            return 0;
        }
        return StringUtils.getUtf8BytesLength(c0140b0.b) + 12;
    }
}
