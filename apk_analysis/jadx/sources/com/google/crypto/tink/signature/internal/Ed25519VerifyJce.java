package com.google.crypto.tink.signature.internal;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.PublicKeyVerify;
import com.google.crypto.tink.config.internal.TinkFipsUtil;
import com.google.crypto.tink.internal.Util;
import com.google.crypto.tink.signature.Ed25519Parameters;
import com.google.crypto.tink.signature.Ed25519PublicKey;
import com.google.crypto.tink.subtle.Bytes;
import com.google.crypto.tink.subtle.EngineFactory;
import com.google.errorprone.annotations.Immutable;
import java.security.GeneralSecurityException;
import java.security.PublicKey;
import java.security.Signature;
import java.security.spec.X509EncodedKeySpec;
import org.tensorflow.lite.schema.BuiltinOptions;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class Ed25519VerifyJce implements PublicKeyVerify {
    private static final String ALGORITHM_NAME = "Ed25519";
    private static final int PUBLIC_KEY_LEN = 32;
    private static final int SIGNATURE_LEN = 64;
    private final byte[] messageSuffix;
    private final byte[] outputPrefix;
    private final PublicKey publicKey;
    public static final TinkFipsUtil.AlgorithmFipsCompatibility FIPS = TinkFipsUtil.AlgorithmFipsCompatibility.ALGORITHM_NOT_FIPS;
    private static final byte[] ED25519_X509_PREFIX = {BuiltinOptions.SliceOptions, BuiltinOptions.NegOptions, BuiltinOptions.SliceOptions, 5, 6, 3, BuiltinOptions.PadV2Options, BuiltinOptions.BatchMatMulOptions, BuiltinOptions.ReadVariableOptions, 3, BuiltinOptions.ExpOptions, 0};

    static byte[] x509EncodePublicKey(byte[] bArr) {
        if (bArr.length != 32) {
            throw new IllegalArgumentException(String.format("Given public key's length is not %s.", 32));
        }
        return Bytes.concat(ED25519_X509_PREFIX, bArr);
    }

    @AccessesPartialKey
    public static PublicKeyVerify create(Ed25519PublicKey ed25519PublicKey) throws GeneralSecurityException {
        byte[] bArr;
        if (!FIPS.isCompatible()) {
            throw new GeneralSecurityException("Can not use Ed25519 in FIPS-mode.");
        }
        byte[] byteArray = ed25519PublicKey.getPublicKeyBytes().toByteArray();
        byte[] byteArray2 = ed25519PublicKey.getOutputPrefix().toByteArray();
        if (ed25519PublicKey.getParameters().getVariant().equals(Ed25519Parameters.Variant.LEGACY)) {
            bArr = new byte[]{0};
        } else {
            bArr = new byte[0];
        }
        return new Ed25519VerifyJce(byteArray, byteArray2, bArr);
    }

    Ed25519VerifyJce(byte[] bArr) {
        this(bArr, new byte[0], new byte[0]);
    }

    private Ed25519VerifyJce(byte[] bArr, byte[] bArr2, byte[] bArr3) throws GeneralSecurityException {
        if (!FIPS.isCompatible()) {
            throw new GeneralSecurityException("Can not use Ed25519 in FIPS-mode.");
        }
        this.publicKey = EngineFactory.KEY_FACTORY.getInstance(ALGORITHM_NAME).generatePublic(new X509EncodedKeySpec(x509EncodePublicKey(bArr)));
        this.outputPrefix = bArr2;
        this.messageSuffix = bArr3;
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

    @Override // com.google.crypto.tink.PublicKeyVerify
    public void verify(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        boolean zVerify;
        int length = bArr.length;
        byte[] bArr3 = this.outputPrefix;
        if (length != bArr3.length + 64) {
            throw new GeneralSecurityException(String.format("Invalid signature length: %s", 64));
        }
        if (!Util.isPrefix(bArr3, bArr)) {
            throw new GeneralSecurityException("Invalid signature (output prefix mismatch)");
        }
        Signature engineFactory = EngineFactory.SIGNATURE.getInstance(ALGORITHM_NAME);
        engineFactory.initVerify(this.publicKey);
        engineFactory.update(bArr2);
        engineFactory.update(this.messageSuffix);
        try {
            zVerify = engineFactory.verify(bArr, this.outputPrefix.length, 64);
        } catch (RuntimeException unused) {
            zVerify = false;
        }
        if (!zVerify) {
            throw new GeneralSecurityException("Signature check failed.");
        }
    }
}
