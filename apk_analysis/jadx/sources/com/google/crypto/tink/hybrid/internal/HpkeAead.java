package com.google.crypto.tink.hybrid.internal;

import com.google.errorprone.annotations.Immutable;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public interface HpkeAead {
    byte[] getAeadId();

    int getKeyLength();

    int getNonceLength();

    byte[] open(byte[] bArr, byte[] bArr2, byte[] bArr3, int i, byte[] bArr4);

    byte[] seal(byte[] bArr, byte[] bArr2, byte[] bArr3, int i, byte[] bArr4);

    default byte[] seal(byte[] bArr, byte[] bArr2, byte[] bArr3, byte[] bArr4) {
        return seal(bArr, bArr2, bArr3, 0, bArr4);
    }

    default byte[] open(byte[] bArr, byte[] bArr2, byte[] bArr3, byte[] bArr4) {
        return open(bArr, bArr2, bArr3, 0, bArr4);
    }
}
