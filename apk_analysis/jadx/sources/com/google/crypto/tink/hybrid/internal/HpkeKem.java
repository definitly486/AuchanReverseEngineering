package com.google.crypto.tink.hybrid.internal;

import com.google.errorprone.annotations.Immutable;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public interface HpkeKem {
    byte[] authDecapsulate(byte[] bArr, HpkeKemPrivateKey hpkeKemPrivateKey, byte[] bArr2);

    HpkeKemEncapOutput authEncapsulate(byte[] bArr, HpkeKemPrivateKey hpkeKemPrivateKey);

    byte[] decapsulate(byte[] bArr, HpkeKemPrivateKey hpkeKemPrivateKey);

    HpkeKemEncapOutput encapsulate(byte[] bArr);

    byte[] getKemId();
}
