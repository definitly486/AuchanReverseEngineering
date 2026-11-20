package com.google.crypto.tink.subtle;

import com.google.crypto.tink.PublicKeySign;
import com.google.crypto.tink.signature.EcdsaPrivateKey;
import com.google.errorprone.annotations.Immutable;
import java.security.interfaces.ECPrivateKey;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class EcdsaSignJce implements PublicKeySign {
    private final PublicKeySign signer;

    public static PublicKeySign create(EcdsaPrivateKey ecdsaPrivateKey) {
        return com.google.crypto.tink.signature.internal.EcdsaSignJce.create(ecdsaPrivateKey);
    }

    public EcdsaSignJce(ECPrivateKey eCPrivateKey, Enums.HashType hashType, EllipticCurves.EcdsaEncoding ecdsaEncoding) {
        this.signer = new com.google.crypto.tink.signature.internal.EcdsaSignJce(eCPrivateKey, hashType, ecdsaEncoding);
    }

    @Override // com.google.crypto.tink.PublicKeySign
    public byte[] sign(byte[] bArr) {
        return this.signer.sign(bArr);
    }
}
