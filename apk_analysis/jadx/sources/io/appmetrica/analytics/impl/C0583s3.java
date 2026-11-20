package io.appmetrica.analytics.impl;

import android.util.Base64;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.s3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0583s3 implements Lo {
    public final C0149b9 a;

    public C0583s3() {
        this(new C0149b9());
    }

    @Override // io.appmetrica.analytics.impl.Lo
    public final byte[] a(C0304h9 c0304h9, C0727xh c0727xh) {
        byte[] bArrDecode = new byte[0];
        String str = c0304h9.b;
        if (str != null) {
            try {
                bArrDecode = Base64.decode(str, 0);
            } catch (Throwable unused) {
            }
        }
        C0149b9 c0149b9 = this.a;
        return ((InterfaceC0123a9) c0149b9.a.a(c0304h9.o)).a(bArrDecode);
    }

    public C0583s3(C0149b9 c0149b9) {
        this.a = c0149b9;
    }
}
