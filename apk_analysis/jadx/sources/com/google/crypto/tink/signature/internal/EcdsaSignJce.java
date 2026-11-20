package com.google.crypto.tink.signature.internal;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.PublicKeySign;
import com.google.crypto.tink.config.internal.TinkFipsUtil;
import com.google.crypto.tink.internal.ConscryptUtil;
import com.google.crypto.tink.signature.EcdsaParameters;
import com.google.crypto.tink.signature.EcdsaPrivateKey;
import com.google.crypto.tink.subtle.Bytes;
import com.google.crypto.tink.subtle.EllipticCurves;
import com.google.crypto.tink.subtle.EngineFactory;
import com.google.crypto.tink.subtle.Enums;
import com.google.crypto.tink.subtle.SubtleUtil;
import com.google.errorprone.annotations.Immutable;
import java.security.GeneralSecurityException;
import java.security.KeyFactory;
import java.security.NoSuchAlgorithmException;
import java.security.Provider;
import java.security.Signature;
import java.security.interfaces.ECPrivateKey;
import java.security.spec.ECPrivateKeySpec;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class EcdsaSignJce implements PublicKeySign {
    private final EllipticCurves.EcdsaEncoding encoding;
    private final byte[] messageSuffix;
    private final byte[] outputPrefix;
    private final ECPrivateKey privateKey;
    private final Provider provider;
    private final String signatureAlgorithm;
    public static final TinkFipsUtil.AlgorithmFipsCompatibility FIPS = TinkFipsUtil.AlgorithmFipsCompatibility.ALGORITHM_REQUIRES_BORINGCRYPTO;
    private static final byte[] EMPTY = new byte[0];
    private static final byte[] legacyMessageSuffix = {0};

    private EcdsaSignJce(ECPrivateKey eCPrivateKey, Enums.HashType hashType, EllipticCurves.EcdsaEncoding ecdsaEncoding, byte[] bArr, byte[] bArr2, Provider provider) throws GeneralSecurityException {
        if (!FIPS.isCompatible()) {
            throw new GeneralSecurityException("Can not use ECDSA in FIPS-mode, as BoringCrypto is not available.");
        }
        this.privateKey = eCPrivateKey;
        this.signatureAlgorithm = SubtleUtil.toEcdsaAlgo(hashType);
        this.encoding = ecdsaEncoding;
        this.outputPrefix = bArr;
        this.messageSuffix = bArr2;
        this.provider = provider;
    }

    /* JADX WARN: Illegal instructions before constructor call */
    public EcdsaSignJce(ECPrivateKey eCPrivateKey, Enums.HashType hashType, EllipticCurves.EcdsaEncoding ecdsaEncoding) {
        byte[] bArr = EMPTY;
        this(eCPrivateKey, hashType, ecdsaEncoding, bArr, bArr, ConscryptUtil.providerOrNull());
    }

    @AccessesPartialKey
    public static PublicKeySign create(EcdsaPrivateKey ecdsaPrivateKey) throws NoSuchAlgorithmException {
        KeyFactory engineFactory;
        byte[] bArr;
        Enums.HashType hashType = (Enums.HashType) EcdsaVerifyJce.HASH_TYPE_CONVERTER.toProtoEnum(ecdsaPrivateKey.getParameters().getHashType());
        EllipticCurves.EcdsaEncoding ecdsaEncoding = (EllipticCurves.EcdsaEncoding) EcdsaVerifyJce.ENCODING_CONVERTER.toProtoEnum(ecdsaPrivateKey.getParameters().getSignatureEncoding());
        EllipticCurves.CurveType curveType = (EllipticCurves.CurveType) EcdsaVerifyJce.CURVE_TYPE_CONVERTER.toProtoEnum(ecdsaPrivateKey.getParameters().getCurveType());
        Provider providerProviderOrNull = ConscryptUtil.providerOrNull();
        ECPrivateKeySpec eCPrivateKeySpec = new ECPrivateKeySpec(ecdsaPrivateKey.getPrivateValue().getBigInteger(InsecureSecretKeyAccess.get()), EllipticCurves.getCurveSpec(curveType));
        if (providerProviderOrNull == null) {
            engineFactory = EngineFactory.KEY_FACTORY.getInstance("EC");
        } else {
            engineFactory = KeyFactory.getInstance("EC", providerProviderOrNull);
        }
        ECPrivateKey eCPrivateKey = (ECPrivateKey) engineFactory.generatePrivate(eCPrivateKeySpec);
        byte[] byteArray = ecdsaPrivateKey.getOutputPrefix().toByteArray();
        if (ecdsaPrivateKey.getParameters().getVariant().equals(EcdsaParameters.Variant.LEGACY)) {
            bArr = legacyMessageSuffix;
        } else {
            bArr = EMPTY;
        }
        return new EcdsaSignJce(eCPrivateKey, hashType, ecdsaEncoding, byteArray, bArr, providerProviderOrNull);
    }

    private Signature getInstance(String str) {
        Provider provider = this.provider;
        if (provider != null) {
            return Signature.getInstance(str, provider);
        }
        return EngineFactory.SIGNATURE.getInstance(str);
    }

    @Override // com.google.crypto.tink.PublicKeySign
    public byte[] sign(byte[] bArr) throws GeneralSecurityException {
        Signature ecdsaSignJce = getInstance(this.signatureAlgorithm);
        ecdsaSignJce.initSign(this.privateKey);
        ecdsaSignJce.update(bArr);
        byte[] bArr2 = this.messageSuffix;
        if (bArr2.length > 0) {
            ecdsaSignJce.update(bArr2);
        }
        byte[] bArrSign = ecdsaSignJce.sign();
        if (this.encoding == EllipticCurves.EcdsaEncoding.IEEE_P1363) {
            bArrSign = EllipticCurves.ecdsaDer2Ieee(bArrSign, EllipticCurves.fieldSizeInBytes(this.privateKey.getParams().getCurve()) * 2);
        }
        byte[] bArr3 = this.outputPrefix;
        return bArr3.length == 0 ? bArrSign : Bytes.concat(bArr3, bArrSign);
    }
}
