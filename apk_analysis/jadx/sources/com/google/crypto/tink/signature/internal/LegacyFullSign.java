package com.google.crypto.tink.signature.internal;

import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.PublicKeySign;
import com.google.crypto.tink.Registry;
import com.google.crypto.tink.internal.LegacyProtoKey;
import com.google.crypto.tink.internal.ProtoKeySerialization;
import com.google.crypto.tink.proto.KeyData;
import com.google.crypto.tink.subtle.Bytes;
import com.google.errorprone.annotations.Immutable;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class LegacyFullSign implements PublicKeySign {
    private final byte[] messageSuffix;
    private final byte[] outputPrefix;
    private final PublicKeySign rawSigner;

    public static PublicKeySign create(LegacyProtoKey legacyProtoKey) throws GeneralSecurityException {
        ProtoKeySerialization serialization = legacyProtoKey.getSerialization(InsecureSecretKeyAccess.get());
        return new LegacyFullSign((PublicKeySign) Registry.getPrimitive(KeyData.newBuilder().setTypeUrl(serialization.getTypeUrl()).setValue(serialization.getValue()).setKeyMaterialType(serialization.getKeyMaterialType()).build(), PublicKeySign.class), LegacyFullVerify.getOutputPrefix(serialization), LegacyFullVerify.getMessageSuffix(serialization));
    }

    private LegacyFullSign(PublicKeySign publicKeySign, byte[] bArr, byte[] bArr2) {
        this.rawSigner = publicKeySign;
        this.outputPrefix = bArr;
        this.messageSuffix = bArr2;
    }

    @Override // com.google.crypto.tink.PublicKeySign
    public byte[] sign(byte[] bArr) {
        byte[] bArrSign;
        byte[] bArr2 = this.messageSuffix;
        if (bArr2.length == 0) {
            bArrSign = this.rawSigner.sign(bArr);
        } else {
            bArrSign = this.rawSigner.sign(Bytes.concat(bArr, bArr2));
        }
        byte[] bArr3 = this.outputPrefix;
        return bArr3.length == 0 ? bArrSign : Bytes.concat(bArr3, bArrSign);
    }
}
