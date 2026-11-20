package com.google.crypto.tink.signature.internal;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.PublicKeySign;
import com.google.crypto.tink.config.internal.TinkFipsUtil;
import com.google.crypto.tink.signature.Ed25519Parameters;
import com.google.crypto.tink.signature.Ed25519PrivateKey;
import com.google.crypto.tink.subtle.Bytes;
import com.google.crypto.tink.subtle.EngineFactory;
import com.google.errorprone.annotations.Immutable;
import java.security.GeneralSecurityException;
import java.security.InvalidKeyException;
import java.security.PrivateKey;
import java.security.Signature;
import java.security.SignatureException;
import java.security.spec.PKCS8EncodedKeySpec;
import org.tensorflow.lite.schema.BuiltinOptions;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class Ed25519SignJce implements PublicKeySign {
    private static final String ALGORITHM_NAME = "Ed25519";
    public static final int SECRET_KEY_LEN = 32;
    public static final int SIGNATURE_LEN = 64;
    private final byte[] messageSuffix;
    private final byte[] outputPrefix;
    private final PrivateKey privateKey;
    public static final TinkFipsUtil.AlgorithmFipsCompatibility FIPS = TinkFipsUtil.AlgorithmFipsCompatibility.ALGORITHM_NOT_FIPS;
    private static final byte[] ED25519_PKCS8_PREFIX = {BuiltinOptions.SliceOptions, BuiltinOptions.LessEqualOptions, 2, 1, 0, BuiltinOptions.SliceOptions, 5, 6, 3, BuiltinOptions.PadV2Options, BuiltinOptions.BatchMatMulOptions, BuiltinOptions.ReadVariableOptions, 4, BuiltinOptions.TopKV2Options, 4, 32};

    static byte[] pkcs8EncodePrivateKey(byte[] bArr) {
        if (bArr.length != 32) {
            throw new IllegalArgumentException(String.format("Given private key's length is not %s", 32));
        }
        return Bytes.concat(ED25519_PKCS8_PREFIX, bArr);
    }

    @AccessesPartialKey
    public static PublicKeySign create(Ed25519PrivateKey ed25519PrivateKey) {
        byte[] bArr;
        byte[] byteArray = ed25519PrivateKey.getPrivateKeyBytes().toByteArray(InsecureSecretKeyAccess.get());
        byte[] byteArray2 = ed25519PrivateKey.getOutputPrefix().toByteArray();
        if (ed25519PrivateKey.getParameters().getVariant().equals(Ed25519Parameters.Variant.LEGACY)) {
            bArr = new byte[]{0};
        } else {
            bArr = new byte[0];
        }
        return new Ed25519SignJce(byteArray, byteArray2, bArr);
    }

    private Ed25519SignJce(byte[] bArr, byte[] bArr2, byte[] bArr3) throws GeneralSecurityException {
        if (!FIPS.isCompatible()) {
            throw new GeneralSecurityException("Can not use Ed25519 in FIPS-mode.");
        }
        this.outputPrefix = bArr2;
        this.messageSuffix = bArr3;
        this.privateKey = EngineFactory.KEY_FACTORY.getInstance(ALGORITHM_NAME).generatePrivate(new PKCS8EncodedKeySpec(pkcs8EncodePrivateKey(bArr)));
    }

    public Ed25519SignJce(byte[] bArr) {
        this(bArr, new byte[0], new byte[0]);
    }

    public static boolean isSupported() {
        try {
            EngineFactory.KEY_FACTORY.getInstance(ALGORITHM_NAME);
            EngineFactory.SIGNATURE.getInstance(ALGORITHM_NAME);
            return true;
        } catch (GeneralSecurityException unused) {
            return false;
        }
    }

    @Override // com.google.crypto.tink.PublicKeySign
    public byte[] sign(byte[] bArr) throws SignatureException, InvalidKeyException {
        Signature engineFactory = EngineFactory.SIGNATURE.getInstance(ALGORITHM_NAME);
        engineFactory.initSign(this.privateKey);
        engineFactory.update(bArr);
        engineFactory.update(this.messageSuffix);
        byte[] bArrSign = engineFactory.sign();
        byte[] bArr2 = this.outputPrefix;
        return bArr2.length == 0 ? bArrSign : Bytes.concat(bArr2, bArrSign);
    }
}
