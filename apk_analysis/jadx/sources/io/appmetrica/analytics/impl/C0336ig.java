package io.appmetrica.analytics.impl;

import android.util.Base64;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.protobuf.nano.MessageNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ig, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0336ig implements Lo {
    @Override // io.appmetrica.analytics.impl.Lo
    public final byte[] a(C0304h9 c0304h9, C0727xh c0727xh) {
        if (!StringUtils.isNullOrEmpty(c0304h9.b)) {
            try {
                byte[] bArrDecode = Base64.decode(c0304h9.b, 0);
                C0674vg c0674vg = (bArrDecode == null || bArrDecode.length == 0) ? null : new C0674vg(bArrDecode);
                C0545qg c0545qg = new C0545qg();
                String str = c0674vg.a;
                c0545qg.a = str == null ? new byte[0] : str.getBytes();
                c0545qg.c = c0674vg.b;
                c0545qg.b = c0674vg.c;
                int iA = AbstractC0174c8.a(c0674vg.d);
                int i = 1;
                if (iA != 1) {
                    i = 2;
                    if (iA != 2) {
                        i = 0;
                    }
                }
                c0545qg.d = i;
                return MessageNano.toByteArray(c0545qg);
            } catch (Throwable unused) {
            }
        }
        return new byte[0];
    }
}
