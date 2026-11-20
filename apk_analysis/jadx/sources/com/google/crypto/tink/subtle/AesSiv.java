package com.google.crypto.tink.subtle;

import com.google.common.base.Ascii;
import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.DeterministicAead;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.config.internal.TinkFipsUtil;
import com.google.crypto.tink.daead.AesSivKey;
import com.google.crypto.tink.internal.Util;
import com.google.crypto.tink.mac.internal.AesUtil;
import java.security.GeneralSecurityException;
import java.security.InvalidKeyException;
import java.util.Arrays;
import java.util.Collection;
import javax.crypto.AEADBadTagException;
import javax.crypto.Cipher;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;

/* JADX INFO: loaded from: classes2.dex */
public final class AesSiv implements DeterministicAead {
    private final byte[] aesCtrKey;
    private final PrfAesCmac cmacForS2V;
    private final byte[] outputPrefix;
    public static final TinkFipsUtil.AlgorithmFipsCompatibility FIPS = TinkFipsUtil.AlgorithmFipsCompatibility.ALGORITHM_NOT_FIPS;
    private static final Collection<Integer> KEY_SIZES = Arrays.asList(64);
    private static final byte[] BLOCK_ZERO = new byte[16];
    private static final byte[] BLOCK_ONE = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1};
    private static final ThreadLocal<Cipher> localAesCtrCipher = new ThreadLocal<Cipher>() { // from class: com.google.crypto.tink.subtle.AesSiv.1
        /* JADX INFO: Access modifiers changed from: protected */
        @Override // java.lang.ThreadLocal
        public Cipher initialValue() {
            try {
                return EngineFactory.CIPHER.getInstance("AES/CTR/NoPadding");
            } catch (GeneralSecurityException e) {
                throw new IllegalStateException(e);
            }
        }
    };

    @AccessesPartialKey
    public static DeterministicAead create(AesSivKey aesSivKey) {
        return new AesSiv(aesSivKey.getKeyBytes().toByteArray(InsecureSecretKeyAccess.get()), aesSivKey.getOutputPrefix());
    }

    private AesSiv(byte[] bArr, com.google.crypto.tink.util.Bytes bytes) throws GeneralSecurityException {
        if (!FIPS.isCompatible()) {
            throw new GeneralSecurityException("Can not use AES-SIV in FIPS-mode.");
        }
        if (!KEY_SIZES.contains(Integer.valueOf(bArr.length))) {
            throw new InvalidKeyException("invalid key size: " + bArr.length + " bytes; key must have 64 bytes");
        }
        byte[] bArrCopyOfRange = Arrays.copyOfRange(bArr, 0, bArr.length / 2);
        this.aesCtrKey = Arrays.copyOfRange(bArr, bArr.length / 2, bArr.length);
        this.cmacForS2V = new PrfAesCmac(bArrCopyOfRange);
        this.outputPrefix = bytes.toByteArray();
    }

    public AesSiv(byte[] bArr) {
        this(bArr, com.google.crypto.tink.util.Bytes.copyFrom(new byte[0]));
    }

    private byte[] s2v(byte[]... bArr) throws GeneralSecurityException {
        byte[] bArrXor;
        if (bArr.length == 0) {
            return this.cmacForS2V.compute(BLOCK_ONE, 16);
        }
        byte[] bArrCompute = this.cmacForS2V.compute(BLOCK_ZERO, 16);
        for (int i = 0; i < bArr.length - 1; i++) {
            byte[] bArr2 = bArr[i];
            if (bArr2 == null) {
                bArr2 = new byte[0];
            }
            bArrCompute = Bytes.xor(AesUtil.dbl(bArrCompute), this.cmacForS2V.compute(bArr2, 16));
        }
        byte[] bArr3 = bArr[bArr.length - 1];
        if (bArr3.length >= 16) {
            bArrXor = Bytes.xorEnd(bArr3, bArrCompute);
        } else {
            bArrXor = Bytes.xor(AesUtil.cmacPad(bArr3), AesUtil.dbl(bArrCompute));
        }
        return this.cmacForS2V.compute(bArrXor, 16);
    }

    @Override // com.google.crypto.tink.DeterministicAead
    public byte[] encryptDeterministically(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        if (bArr.length > 2147483631 - this.outputPrefix.length) {
            throw new GeneralSecurityException("plaintext too long");
        }
        Cipher cipher = localAesCtrCipher.get();
        byte[] bArrS2v = s2v(bArr2, bArr);
        byte[] bArr3 = (byte[]) bArrS2v.clone();
        bArr3[8] = (byte) (bArr3[8] & Ascii.DEL);
        bArr3[12] = (byte) (bArr3[12] & Ascii.DEL);
        cipher.init(1, new SecretKeySpec(this.aesCtrKey, "AES"), new IvParameterSpec(bArr3));
        byte[] bArr4 = this.outputPrefix;
        byte[] bArrCopyOf = Arrays.copyOf(bArr4, bArr4.length + bArrS2v.length + bArr.length);
        System.arraycopy(bArrS2v, 0, bArrCopyOf, this.outputPrefix.length, bArrS2v.length);
        if (cipher.doFinal(bArr, 0, bArr.length, bArrCopyOf, this.outputPrefix.length + bArrS2v.length) == bArr.length) {
            return bArrCopyOf;
        }
        throw new GeneralSecurityException("not enough data written");
    }

    @Override // com.google.crypto.tink.DeterministicAead
    public byte[] decryptDeterministically(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        int length = bArr.length;
        byte[] bArr3 = this.outputPrefix;
        if (length < bArr3.length + 16) {
            throw new GeneralSecurityException("Ciphertext too short.");
        }
        if (!Util.isPrefix(bArr3, bArr)) {
            throw new GeneralSecurityException("Decryption failed (OutputPrefix mismatch).");
        }
        Cipher cipher = localAesCtrCipher.get();
        byte[] bArr4 = this.outputPrefix;
        byte[] bArrCopyOfRange = Arrays.copyOfRange(bArr, bArr4.length, bArr4.length + 16);
        byte[] bArr5 = (byte[]) bArrCopyOfRange.clone();
        bArr5[8] = (byte) (bArr5[8] & Ascii.DEL);
        bArr5[12] = (byte) (bArr5[12] & Ascii.DEL);
        cipher.init(2, new SecretKeySpec(this.aesCtrKey, "AES"), new IvParameterSpec(bArr5));
        int length2 = this.outputPrefix.length + 16;
        int length3 = bArr.length - length2;
        byte[] bArrDoFinal = cipher.doFinal(bArr, length2, length3);
        if (length3 == 0 && bArrDoFinal == null && SubtleUtil.isAndroid()) {
            bArrDoFinal = new byte[0];
        }
        if (Bytes.equal(bArrCopyOfRange, s2v(bArr2, bArrDoFinal))) {
            return bArrDoFinal;
        }
        throw new AEADBadTagException("Integrity check failed.");
    }
}
