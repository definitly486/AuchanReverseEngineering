package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.io.Base64Utils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ho, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0319ho implements Lo {
    public final C0149b9 a;

    public C0319ho() {
        this(new C0149b9());
    }

    @Override // io.appmetrica.analytics.impl.Lo
    public final byte[] a(C0304h9 c0304h9, C0727xh c0727xh) {
        byte[] bArrDecompressBase64GzipAsBytes = new byte[0];
        try {
            bArrDecompressBase64GzipAsBytes = Base64Utils.decompressBase64GzipAsBytes(c0304h9.b);
        } catch (Throwable unused) {
        }
        byte[] bArrA = ((InterfaceC0123a9) this.a.a.a(c0304h9.o)).a(bArrDecompressBase64GzipAsBytes);
        return bArrA == null ? new byte[0] : bArrA;
    }

    public C0319ho(C0149b9 c0149b9) {
        this.a = c0149b9;
    }

    public final C0149b9 a() {
        return this.a;
    }
}
