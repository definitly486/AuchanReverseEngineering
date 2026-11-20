package com.google.crypto.tink.aead.subtle;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Aead;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.aead.AesGcmSivKey;
import com.google.crypto.tink.annotations.Alpha;
import com.google.crypto.tink.internal.Util;
import com.google.crypto.tink.subtle.Bytes;
import com.google.crypto.tink.subtle.EngineFactory;
import com.google.crypto.tink.subtle.Hex;
import com.google.crypto.tink.subtle.Random;
import com.google.crypto.tink.subtle.Validators;
import java.security.GeneralSecurityException;
import java.security.InvalidAlgorithmParameterException;
import java.security.spec.AlgorithmParameterSpec;
import java.util.Arrays;
import javax.crypto.Cipher;
import javax.crypto.SecretKey;
import javax.crypto.spec.GCMParameterSpec;
import javax.crypto.spec.SecretKeySpec;

/* JADX INFO: loaded from: classes2.dex */
@Alpha
public final class AesGcmSiv implements Aead {
    private static final int IV_SIZE_IN_BYTES = 12;
    private static final int TAG_SIZE_IN_BYTES = 16;
    private final SecretKey keySpec;
    private final byte[] outputPrefix;
    private static final byte[] TEST_PLAINTEXT = Hex.decode("7a806c");
    private static final byte[] TEST_AAD = Hex.decode("46bb91c3c5");
    private static final byte[] TEST_KEY = Hex.decode("36864200e0eaf5284d884a0e77d31646");
    private static final byte[] TEST_NOUNCE = Hex.decode("bae8e37fc83441b16034566b");
    private static final byte[] TEST_RESULT = Hex.decode("af60eb711bd85bc1e4d3e0a462e074eea428a8");
    private static final ThreadLocal<Cipher> localAesGcmSivCipher = new ThreadLocal<Cipher>() { // from class: com.google.crypto.tink.aead.subtle.AesGcmSiv.1
        /* JADX INFO: Access modifiers changed from: protected */
        @Override // java.lang.ThreadLocal
        public Cipher initialValue() {
            try {
                Cipher engineFactory = EngineFactory.CIPHER.getInstance("AES/GCM-SIV/NoPadding");
                if (AesGcmSiv.isAesGcmSivCipher(engineFactory)) {
                    return engineFactory;
                }
                return null;
            } catch (GeneralSecurityException e) {
                throw new IllegalStateException(e);
            }
        }
    };

    /* JADX INFO: Access modifiers changed from: private */
    public static boolean isAesGcmSivCipher(Cipher cipher) {
        try {
            cipher.init(2, new SecretKeySpec(TEST_KEY, "AES"), getParams(TEST_NOUNCE));
            cipher.updateAAD(TEST_AAD);
            byte[] bArr = TEST_RESULT;
            return Bytes.equal(cipher.doFinal(bArr, 0, bArr.length), TEST_PLAINTEXT);
        } catch (GeneralSecurityException unused) {
            return false;
        }
    }

    @AccessesPartialKey
    public static Aead create(AesGcmSivKey aesGcmSivKey) {
        return new AesGcmSiv(aesGcmSivKey.getKeyBytes().toByteArray(InsecureSecretKeyAccess.get()), aesGcmSivKey.getOutputPrefix().toByteArray());
    }

    private AesGcmSiv(byte[] bArr, byte[] bArr2) throws InvalidAlgorithmParameterException {
        this.outputPrefix = bArr2;
        Validators.validateAesKeySize(bArr.length);
        this.keySpec = new SecretKeySpec(bArr, "AES");
    }

    public AesGcmSiv(byte[] bArr) {
        this(bArr, new byte[0]);
    }

    private Cipher getAesGcmSivCipher() throws GeneralSecurityException {
        Cipher cipher = localAesGcmSivCipher.get();
        if (cipher != null) {
            return cipher;
        }
        throw new GeneralSecurityException("AES GCM SIV cipher is not available or is invalid.");
    }

    private byte[] rawEncrypt(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        Cipher aesGcmSivCipher = getAesGcmSivCipher();
        if (bArr.length > 2147483619) {
            throw new GeneralSecurityException("plaintext too long");
        }
        byte[] bArr3 = new byte[bArr.length + 28];
        byte[] bArrRandBytes = Random.randBytes(12);
        System.arraycopy(bArrRandBytes, 0, bArr3, 0, 12);
        aesGcmSivCipher.init(1, this.keySpec, getParams(bArrRandBytes));
        if (bArr2 != null && bArr2.length != 0) {
            aesGcmSivCipher.updateAAD(bArr2);
        }
        int iDoFinal = aesGcmSivCipher.doFinal(bArr, 0, bArr.length, bArr3, 12);
        if (iDoFinal == bArr.length + 16) {
            return bArr3;
        }
        throw new GeneralSecurityException(String.format("encryption failed; GCM tag must be %s bytes, but got only %s bytes", 16, Integer.valueOf(iDoFinal - bArr.length)));
    }

    @Override // com.google.crypto.tink.Aead
    public byte[] encrypt(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        byte[] bArrRawEncrypt = rawEncrypt(bArr, bArr2);
        byte[] bArr3 = this.outputPrefix;
        return bArr3.length == 0 ? bArrRawEncrypt : Bytes.concat(bArr3, bArrRawEncrypt);
    }

    private byte[] rawDecrypt(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        Cipher aesGcmSivCipher = getAesGcmSivCipher();
        if (bArr.length < 28) {
            throw new GeneralSecurityException("ciphertext too short");
        }
        aesGcmSivCipher.init(2, this.keySpec, getParams(bArr, 0, 12));
        if (bArr2 != null && bArr2.length != 0) {
            aesGcmSivCipher.updateAAD(bArr2);
        }
        return aesGcmSivCipher.doFinal(bArr, 12, bArr.length - 12);
    }

    @Override // com.google.crypto.tink.Aead
    public byte[] decrypt(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        byte[] bArr3 = this.outputPrefix;
        if (bArr3.length == 0) {
            return rawDecrypt(bArr, bArr2);
        }
        if (!Util.isPrefix(bArr3, bArr)) {
            throw new GeneralSecurityException("Decryption failed (OutputPrefix mismatch).");
        }
        return rawDecrypt(Arrays.copyOfRange(bArr, this.outputPrefix.length, bArr.length), bArr2);
    }

    private static AlgorithmParameterSpec getParams(byte[] bArr) {
        return getParams(bArr, 0, bArr.length);
    }

    private static AlgorithmParameterSpec getParams(byte[] bArr, int i, int i2) {
        return new GCMParameterSpec(128, bArr, i, i2);
    }
}
