package com.google.crypto.tink.signature.internal;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.PublicKeyVerify;
import com.google.crypto.tink.config.internal.TinkFipsUtil;
import com.google.crypto.tink.internal.ConscryptUtil;
import com.google.crypto.tink.internal.Util;
import com.google.crypto.tink.signature.RsaSsaPkcs1Parameters;
import com.google.crypto.tink.signature.RsaSsaPkcs1PublicKey;
import com.google.crypto.tink.subtle.Validators;
import com.google.errorprone.annotations.Immutable;
import java.security.GeneralSecurityException;
import java.security.KeyFactory;
import java.security.NoSuchProviderException;
import java.security.Provider;
import java.security.Signature;
import java.security.interfaces.RSAPublicKey;
import java.security.spec.RSAPublicKeySpec;
import java.util.Arrays;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class RsaSsaPkcs1VerifyConscrypt implements PublicKeyVerify {
    private final Provider conscrypt;
    private final byte[] messageSuffix;
    private final byte[] outputPrefix;
    private final RSAPublicKey publicKey;
    private final String signatureAlgorithm;
    public static final TinkFipsUtil.AlgorithmFipsCompatibility FIPS = TinkFipsUtil.AlgorithmFipsCompatibility.ALGORITHM_REQUIRES_BORINGCRYPTO;
    private static final byte[] EMPTY = new byte[0];
    private static final byte[] LEGACY_MESSAGE_SUFFIX = {0};

    private static Provider conscryptProviderOrNull() {
        if (!Util.isAndroid() || Util.getAndroidApiLevel().intValue() > 21) {
            return ConscryptUtil.providerOrNull();
        }
        return null;
    }

    public static String toRsaSsaPkcs1Algo(RsaSsaPkcs1Parameters.HashType hashType) throws GeneralSecurityException {
        if (hashType == RsaSsaPkcs1Parameters.HashType.SHA256) {
            return "SHA256withRSA";
        }
        if (hashType == RsaSsaPkcs1Parameters.HashType.SHA384) {
            return "SHA384withRSA";
        }
        if (hashType == RsaSsaPkcs1Parameters.HashType.SHA512) {
            return "SHA512withRSA";
        }
        throw new GeneralSecurityException("unknown hash type");
    }

    @AccessesPartialKey
    public static PublicKeyVerify create(RsaSsaPkcs1PublicKey rsaSsaPkcs1PublicKey) throws NoSuchProviderException {
        byte[] bArr;
        Provider providerConscryptProviderOrNull = conscryptProviderOrNull();
        if (providerConscryptProviderOrNull == null) {
            throw new NoSuchProviderException("RSA-PKCS1.5 using Conscrypt is not supported.");
        }
        RSAPublicKey rSAPublicKey = (RSAPublicKey) KeyFactory.getInstance("RSA", providerConscryptProviderOrNull).generatePublic(new RSAPublicKeySpec(rsaSsaPkcs1PublicKey.getModulus(), rsaSsaPkcs1PublicKey.getParameters().getPublicExponent()));
        RsaSsaPkcs1Parameters.HashType hashType = rsaSsaPkcs1PublicKey.getParameters().getHashType();
        byte[] byteArray = rsaSsaPkcs1PublicKey.getOutputPrefix().toByteArray();
        if (rsaSsaPkcs1PublicKey.getParameters().getVariant().equals(RsaSsaPkcs1Parameters.Variant.LEGACY)) {
            bArr = LEGACY_MESSAGE_SUFFIX;
        } else {
            bArr = EMPTY;
        }
        return new RsaSsaPkcs1VerifyConscrypt(rSAPublicKey, hashType, byteArray, bArr, providerConscryptProviderOrNull);
    }

    private RsaSsaPkcs1VerifyConscrypt(RSAPublicKey rSAPublicKey, RsaSsaPkcs1Parameters.HashType hashType, byte[] bArr, byte[] bArr2, Provider provider) throws GeneralSecurityException {
        if (!FIPS.isCompatible()) {
            throw new GeneralSecurityException("Can not use RSA-PKCS1.5 in FIPS-mode, as BoringCrypto module is not available.");
        }
        Validators.validateRsaModulusSize(rSAPublicKey.getModulus().bitLength());
        Validators.validateRsaPublicExponent(rSAPublicKey.getPublicExponent());
        this.publicKey = rSAPublicKey;
        this.signatureAlgorithm = toRsaSsaPkcs1Algo(hashType);
        this.outputPrefix = bArr;
        this.messageSuffix = bArr2;
        this.conscrypt = provider;
    }

    @Override // com.google.crypto.tink.PublicKeyVerify
    public void verify(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        boolean zVerify;
        if (!Util.isPrefix(this.outputPrefix, bArr)) {
            throw new GeneralSecurityException("Invalid signature (output prefix mismatch)");
        }
        Signature signature = Signature.getInstance(this.signatureAlgorithm, this.conscrypt);
        signature.initVerify(this.publicKey);
        signature.update(bArr2);
        byte[] bArr3 = this.messageSuffix;
        if (bArr3.length > 0) {
            signature.update(bArr3);
        }
        try {
            zVerify = signature.verify(Arrays.copyOfRange(bArr, this.outputPrefix.length, bArr.length));
        } catch (RuntimeException unused) {
            zVerify = false;
        }
        if (!zVerify) {
            throw new GeneralSecurityException("Invalid signature");
        }
    }
}
