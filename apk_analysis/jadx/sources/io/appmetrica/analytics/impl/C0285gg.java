package io.appmetrica.analytics.impl;

import android.util.Base64;
import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.gg, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0285gg implements Lo, R8 {
    @Override // io.appmetrica.analytics.impl.R8
    public final int a(EnumC0175c9 enumC0175c9) {
        return 2;
    }

    @Override // io.appmetrica.analytics.impl.Lo
    public final byte[] a(C0304h9 c0304h9, C0727xh c0727xh) {
        return StringUtils.isNullOrEmpty(c0304h9.b) ? new byte[0] : Base64.decode(c0304h9.b, 0);
    }
}
