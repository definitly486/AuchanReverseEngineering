package com.google.crypto.tink.subtle;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.PublicKeySign;
import com.google.crypto.tink.PublicKeyVerify;
import com.google.crypto.tink.config.internal.TinkFipsUtil;
import com.google.crypto.tink.signature.RsaSsaPkcs1Parameters;
import com.google.crypto.tink.signature.RsaSsaPkcs1PrivateKey;
import com.google.errorprone.annotations.Immutable;
import java.security.GeneralSecurityException;
import java.security.InvalidKeyException;
import java.security.Signature;
import java.security.SignatureException;
import java.security.interfaces.RSAPrivateCrtKey;
import java.security.interfaces.RSAPublicKey;
import java.security.spec.RSAPrivateCrtKeySpec;
import java.security.spec.RSAPublicKeySpec;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class RsaSsaPkcs1SignJce implements PublicKeySign {
    private final byte[] messageSuffix;
    private final byte[] outputPrefix;
    private final RSAPrivateCrtKey privateKey;
    private final RSAPublicKey publicKey;
    private final String signatureAlgorithm;
    public static final TinkFipsUtil.AlgorithmFipsCompatibility FIPS = TinkFipsUtil.AlgorithmFipsCompatibility.ALGORITHM_REQUIRES_BORINGCRYPTO;
    private static final byte[] EMPTY = new byte[0];
    private static final byte[] LEGACY_MESSAGE_SUFFIX = {0};
    private static final byte[] TEST_DATA = {1, 2, 3};

    private RsaSsaPkcs1SignJce(RSAPrivateCrtKey rSAPrivateCrtKey, Enums.HashType hashType, byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        if (!FIPS.isCompatible()) {
            throw new GeneralSecurityException("Can not use RSA PKCS1.5 in FIPS-mode, as BoringCrypto module is not available.");
        }
        Validators.validateSignatureHash(hashType);
        Validators.validateRsaModulusSize(rSAPrivateCrtKey.getModulus().bitLength());
        Validators.validateRsaPublicExponent(rSAPrivateCrtKey.getPublicExponent());
        this.privateKey = rSAPrivateCrtKey;
        this.signatureAlgorithm = SubtleUtil.toRsaSsaPkcs1Algo(hashType);
        this.publicKey = (RSAPublicKey) EngineFactory.KEY_FACTORY.getInstance("RSA").generatePublic(new RSAPublicKeySpec(rSAPrivateCrtKey.getModulus(), rSAPrivateCrtKey.getPublicExponent()));
        this.outputPrefix = bArr;
        this.messageSuffix = bArr2;
    }

    /* JADX WARN: Illegal instructions before constructor call */
    public RsaSsaPkcs1SignJce(RSAPrivateCrtKey rSAPrivateCrtKey, Enums.HashType hashType) {
        byte[] bArr = EMPTY;
        this(rSAPrivateCrtKey, hashType, bArr, bArr);
    }

    @AccessesPartialKey
    public static PublicKeySign create(RsaSsaPkcs1PrivateKey rsaSsaPkcs1PrivateKey) throws GeneralSecurityException {
        byte[] bArr;
        RSAPrivateCrtKey rSAPrivateCrtKey = (RSAPrivateCrtKey) EngineFactory.KEY_FACTORY.getInstance("RSA").generatePrivate(new RSAPrivateCrtKeySpec(rsaSsaPkcs1PrivateKey.getPublicKey().getModulus(), rsaSsaPkcs1PrivateKey.getParameters().getPublicExponent(), rsaSsaPkcs1PrivateKey.getPrivateExponent().getBigInteger(InsecureSecretKeyAccess.get()), rsaSsaPkcs1PrivateKey.getPrimeP().getBigInteger(InsecureSecretKeyAccess.get()), rsaSsaPkcs1PrivateKey.getPrimeQ().getBigInteger(InsecureSecretKeyAccess.get()), rsaSsaPkcs1PrivateKey.getPrimeExponentP().getBigInteger(InsecureSecretKeyAccess.get()), rsaSsaPkcs1PrivateKey.getPrimeExponentQ().getBigInteger(InsecureSecretKeyAccess.get()), rsaSsaPkcs1PrivateKey.getCrtCoefficient().getBigInteger(InsecureSecretKeyAccess.get())));
        Enums.HashType hashType = (Enums.HashType) RsaSsaPkcs1VerifyJce.HASH_TYPE_CONVERTER.toProtoEnum(rsaSsaPkcs1PrivateKey.getParameters().getHashType());
        byte[] byteArray = rsaSsaPkcs1PrivateKey.getOutputPrefix().toByteArray();
        if (rsaSsaPkcs1PrivateKey.getParameters().getVariant().equals(RsaSsaPkcs1Parameters.Variant.LEGACY)) {
            bArr = LEGACY_MESSAGE_SUFFIX;
        } else {
            bArr = EMPTY;
        }
        RsaSsaPkcs1SignJce rsaSsaPkcs1SignJce = new RsaSsaPkcs1SignJce(rSAPrivateCrtKey, hashType, byteArray, bArr);
        PublicKeyVerify publicKeyVerifyCreate = RsaSsaPkcs1VerifyJce.create(rsaSsaPkcs1PrivateKey.getPublicKey());
        try {
            byte[] bArr2 = TEST_DATA;
            publicKeyVerifyCreate.verify(rsaSsaPkcs1SignJce.sign(bArr2), bArr2);
            return rsaSsaPkcs1SignJce;
        } catch (GeneralSecurityException e) {
            throw new GeneralSecurityException("RsaSsaPkcs1 signing with private key followed by verifying with public key failed. The key may be corrupted.", e);
        }
    }

    private byte[] noPrefixSign(byte[] bArr) throws SignatureException, InvalidKeyException {
        EngineFactory<EngineWrapper.TSignature, Signature> engineFactory = EngineFactory.SIGNATURE;
        Signature engineFactory2 = engineFactory.getInstance(this.signatureAlgorithm);
        engineFactory2.initSign(this.privateKey);
        engineFactory2.update(bArr);
        byte[] bArr2 = this.messageSuffix;
        if (bArr2.length > 0) {
            engineFactory2.update(bArr2);
        }
        byte[] bArrSign = engineFactory2.sign();
        Signature engineFactory3 = engineFactory.getInstance(this.signatureAlgorithm);
        engineFactory3.initVerify(this.publicKey);
        engineFactory3.update(bArr);
        byte[] bArr3 = this.messageSuffix;
        if (bArr3.length > 0) {
            engineFactory3.update(bArr3);
        }
        if (engineFactory3.verify(bArrSign)) {
            return bArrSign;
        }
        throw new IllegalStateException("Security bug: RSA signature computation error");
    }

    @Override // com.google.crypto.tink.PublicKeySign
    public byte[] sign(byte[] bArr) throws SignatureException, InvalidKeyException {
        byte[] bArrNoPrefixSign = noPrefixSign(bArr);
        byte[] bArr2 = this.outputPrefix;
        return bArr2.length == 0 ? bArrNoPrefixSign : Bytes.concat(bArr2, bArrNoPrefixSign);
    }
}
