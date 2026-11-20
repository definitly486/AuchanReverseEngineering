package io.appmetrica.analytics.impl;

import android.util.Base64;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ga, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0279ga implements InterfaceC0123a9 {
    @Override // io.appmetrica.analytics.impl.InterfaceC0123a9
    public final S8 a(C0249f6 c0249f6) {
        throw new UnsupportedOperationException();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0123a9
    public final byte[] a(byte[] bArr) {
        try {
            return Base64.decode(bArr, 0);
        } catch (Throwable unused) {
            return new byte[0];
        }
    }

    public final EnumC0175c9 a() {
        return EnumC0175c9.EXTERNALLY_ENCRYPTED_EVENT_CRYPTER;
    }
}
