package com.google.crypto.tink.subtle;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.Mac;
import com.google.crypto.tink.mac.AesCmacKey;
import com.google.crypto.tink.mac.AesCmacParameters;
import com.google.crypto.tink.mac.HmacKey;
import com.google.crypto.tink.mac.HmacParameters;
import com.google.crypto.tink.prf.Prf;
import com.google.errorprone.annotations.Immutable;
import java.security.GeneralSecurityException;
import java.security.InvalidAlgorithmParameterException;
import java.util.Arrays;
import javax.crypto.spec.SecretKeySpec;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
@AccessesPartialKey
public class PrfMac implements Mac {
    private static final byte[] FORMAT_VERSION = {0};
    static final int MIN_TAG_SIZE_IN_BYTES = 10;
    private final byte[] outputPrefix;
    private final byte[] plaintextLegacySuffix;
    private final int tagSize;
    private final Prf wrappedPrf;

    public PrfMac(Prf prf, int i) throws InvalidAlgorithmParameterException {
        this.wrappedPrf = prf;
        this.tagSize = i;
        this.outputPrefix = new byte[0];
        this.plaintextLegacySuffix = new byte[0];
        if (i < 10) {
            throw new InvalidAlgorithmParameterException("tag size too small, need at least 10 bytes");
        }
        prf.compute(new byte[0], i);
    }

    private PrfMac(AesCmacKey aesCmacKey) {
        this.wrappedPrf = new PrfAesCmac(aesCmacKey.getAesKey().toByteArray(InsecureSecretKeyAccess.get()));
        this.tagSize = aesCmacKey.getParameters().getCryptographicTagSizeBytes();
        this.outputPrefix = aesCmacKey.getOutputPrefix().toByteArray();
        if (aesCmacKey.getParameters().getVariant().equals(AesCmacParameters.Variant.LEGACY)) {
            byte[] bArr = FORMAT_VERSION;
            this.plaintextLegacySuffix = Arrays.copyOf(bArr, bArr.length);
        } else {
            this.plaintextLegacySuffix = new byte[0];
        }
    }

    private PrfMac(HmacKey hmacKey) {
        this.wrappedPrf = new PrfHmacJce("HMAC" + hmacKey.getParameters().getHashType(), new SecretKeySpec(hmacKey.getKeyBytes().toByteArray(InsecureSecretKeyAccess.get()), "HMAC"));
        this.tagSize = hmacKey.getParameters().getCryptographicTagSizeBytes();
        this.outputPrefix = hmacKey.getOutputPrefix().toByteArray();
        if (hmacKey.getParameters().getVariant().equals(HmacParameters.Variant.LEGACY)) {
            byte[] bArr = FORMAT_VERSION;
            this.plaintextLegacySuffix = Arrays.copyOf(bArr, bArr.length);
        } else {
            this.plaintextLegacySuffix = new byte[0];
        }
    }

    public static Mac create(AesCmacKey aesCmacKey) {
        return new PrfMac(aesCmacKey);
    }

    public static Mac create(HmacKey hmacKey) {
        return new PrfMac(hmacKey);
    }

    @Override // com.google.crypto.tink.Mac
    public byte[] computeMac(byte[] bArr) {
        byte[] bArr2 = this.plaintextLegacySuffix;
        if (bArr2.length > 0) {
            return Bytes.concat(this.outputPrefix, this.wrappedPrf.compute(Bytes.concat(bArr, bArr2), this.tagSize));
        }
        return Bytes.concat(this.outputPrefix, this.wrappedPrf.compute(bArr, this.tagSize));
    }

    @Override // com.google.crypto.tink.Mac
    public void verifyMac(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        if (!Bytes.equal(computeMac(bArr2), bArr)) {
            throw new GeneralSecurityException("invalid MAC");
        }
    }
}
