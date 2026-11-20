package io.appmetrica.analytics.impl;

import android.text.TextUtils;
import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.qn, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0552qn implements Lo {
    @Override // io.appmetrica.analytics.impl.Lo
    public final byte[] a(C0304h9 c0304h9, C0727xh c0727xh) {
        return !TextUtils.isEmpty(c0304h9.b) ? StringUtils.getUTF8Bytes(c0304h9.b) : new byte[0];
    }
}
