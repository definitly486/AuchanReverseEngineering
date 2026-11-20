package com.google.crypto.tink.subtle;

import com.google.common.primitives.UnsignedBytes;
import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Aead;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.aead.AesEaxKey;
import com.google.crypto.tink.config.internal.TinkFipsUtil;
import com.google.crypto.tink.internal.Util;
import java.security.GeneralSecurityException;
import java.util.Arrays;
import javax.crypto.AEADBadTagException;
import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.ShortBufferException;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;
import org.tensorflow.lite.schema.BuiltinOperator;

/* JADX INFO: loaded from: classes2.dex */
public final class AesEaxJce implements Aead {
    static final /* synthetic */ boolean $assertionsDisabled = false;
    static final int BLOCK_SIZE_IN_BYTES = 16;
    static final int TAG_SIZE_IN_BYTES = 16;
    private final byte[] b;
    private final int ivSizeInBytes;
    private final SecretKeySpec keySpec;
    private final byte[] outputPrefix;
    private final byte[] p;
    public static final TinkFipsUtil.AlgorithmFipsCompatibility FIPS = TinkFipsUtil.AlgorithmFipsCompatibility.ALGORITHM_NOT_FIPS;
    private static final ThreadLocal<Cipher> localEcbCipher = new ThreadLocal<Cipher>() { // from class: com.google.crypto.tink.subtle.AesEaxJce.1
        /* JADX INFO: Access modifiers changed from: protected */
        @Override // java.lang.ThreadLocal
        public Cipher initialValue() {
            try {
                return EngineFactory.CIPHER.getInstance("AES/ECB/NOPADDING");
            } catch (GeneralSecurityException e) {
                throw new IllegalStateException(e);
            }
        }
    };
    private static final ThreadLocal<Cipher> localCtrCipher = new ThreadLocal<Cipher>() { // from class: com.google.crypto.tink.subtle.AesEaxJce.2
        /* JADX INFO: Access modifiers changed from: protected */
        @Override // java.lang.ThreadLocal
        public Cipher initialValue() {
            try {
                return EngineFactory.CIPHER.getInstance("AES/CTR/NOPADDING");
            } catch (GeneralSecurityException e) {
                throw new IllegalStateException(e);
            }
        }
    };

    @AccessesPartialKey
    public static Aead create(AesEaxKey aesEaxKey) throws GeneralSecurityException {
        if (!FIPS.isCompatible()) {
            throw new GeneralSecurityException("Can not use AES-EAX in FIPS-mode.");
        }
        if (aesEaxKey.getParameters().getTagSizeBytes() != 16) {
            throw new GeneralSecurityException("AesEaxJce only supports 16 byte tag size, not " + aesEaxKey.getParameters().getTagSizeBytes());
        }
        return new AesEaxJce(aesEaxKey.getKeyBytes().toByteArray(InsecureSecretKeyAccess.get()), aesEaxKey.getParameters().getIvSizeBytes(), aesEaxKey.getOutputPrefix().toByteArray());
    }

    private AesEaxJce(byte[] bArr, int i, byte[] bArr2) throws GeneralSecurityException {
        if (!FIPS.isCompatible()) {
            throw new GeneralSecurityException("Can not use AES-EAX in FIPS-mode.");
        }
        if (i != 12 && i != 16) {
            throw new IllegalArgumentException("IV size should be either 12 or 16 bytes");
        }
        this.ivSizeInBytes = i;
        Validators.validateAesKeySize(bArr.length);
        SecretKeySpec secretKeySpec = new SecretKeySpec(bArr, "AES");
        this.keySpec = secretKeySpec;
        Cipher cipher = localEcbCipher.get();
        cipher.init(1, secretKeySpec);
        byte[] bArrMultiplyByX = multiplyByX(cipher.doFinal(new byte[16]));
        this.b = bArrMultiplyByX;
        this.p = multiplyByX(bArrMultiplyByX);
        this.outputPrefix = bArr2;
    }

    public AesEaxJce(byte[] bArr, int i) {
        this(bArr, i, new byte[0]);
    }

    private static void xor(byte[] bArr, byte[] bArr2) {
        int length = bArr.length;
        for (int i = 0; i < length; i++) {
            bArr[i] = (byte) (bArr[i] ^ bArr2[i]);
        }
    }

    private static byte[] multiplyByX(byte[] bArr) {
        byte[] bArr2 = new byte[16];
        int i = 0;
        while (i < 15) {
            int i2 = i + 1;
            bArr2[i] = (byte) (((bArr[i] << 1) ^ ((bArr[i2] & UnsignedBytes.MAX_VALUE) >>> 7)) & 255);
            i = i2;
        }
        bArr2[15] = (byte) (((bArr[0] >> 7) & BuiltinOperator.COMPLEX_ABS) ^ (bArr[15] << 1));
        return bArr2;
    }

    private byte[] pad(byte[] bArr, int i, int i2) {
        byte[] bArrCopyOfRange = Arrays.copyOfRange(bArr, i, i2);
        if (bArrCopyOfRange.length == 16) {
            xor(bArrCopyOfRange, this.b);
            return bArrCopyOfRange;
        }
        byte[] bArrCopyOf = Arrays.copyOf(this.p, 16);
        for (int i3 = 0; i3 < bArrCopyOfRange.length; i3++) {
            bArrCopyOf[i3] = (byte) (bArrCopyOf[i3] ^ bArrCopyOfRange[i3]);
        }
        bArrCopyOf[bArrCopyOfRange.length] = (byte) (bArrCopyOf[bArrCopyOfRange.length] ^ UnsignedBytes.MAX_POWER_OF_TWO);
        return bArrCopyOf;
    }

    private byte[] omac(Cipher cipher, int i, byte[] bArr, int i2, int i3) throws BadPaddingException, IllegalBlockSizeException, ShortBufferException {
        byte[] bArr2 = new byte[16];
        bArr2[15] = (byte) i;
        if (i3 == 0) {
            xor(bArr2, this.b);
            return cipher.doFinal(bArr2);
        }
        byte[] bArr3 = new byte[16];
        cipher.doFinal(bArr2, 0, 16, bArr3);
        byte[] bArr4 = bArr3;
        byte[] bArr5 = bArr2;
        int i4 = 0;
        while (i3 - i4 > 16) {
            for (int i5 = 0; i5 < 16; i5++) {
                bArr4[i5] = (byte) (bArr4[i5] ^ bArr[(i2 + i4) + i5]);
            }
            cipher.doFinal(bArr4, 0, 16, bArr5);
            i4 += 16;
            byte[] bArr6 = bArr4;
            bArr4 = bArr5;
            bArr5 = bArr6;
        }
        xor(bArr4, pad(bArr, i4 + i2, i2 + i3));
        cipher.doFinal(bArr4, 0, 16, bArr5);
        return bArr5;
    }

    @Override // com.google.crypto.tink.Aead
    public byte[] encrypt(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        int length = bArr.length;
        byte[] bArr3 = this.outputPrefix;
        int length2 = Integer.MAX_VALUE - bArr3.length;
        int i = this.ivSizeInBytes;
        if (length > (length2 - i) - 16) {
            throw new GeneralSecurityException("plaintext too long");
        }
        byte[] bArrCopyOf = Arrays.copyOf(bArr3, bArr3.length + i + bArr.length + 16);
        byte[] bArrRandBytes = Random.randBytes(this.ivSizeInBytes);
        System.arraycopy(bArrRandBytes, 0, bArrCopyOf, this.outputPrefix.length, this.ivSizeInBytes);
        Cipher cipher = localEcbCipher.get();
        cipher.init(1, this.keySpec);
        byte[] bArrOmac = omac(cipher, 0, bArrRandBytes, 0, bArrRandBytes.length);
        byte[] bArr4 = bArr2 == null ? new byte[0] : bArr2;
        byte[] bArrOmac2 = omac(cipher, 1, bArr4, 0, bArr4.length);
        Cipher cipher2 = localCtrCipher.get();
        cipher2.init(1, this.keySpec, new IvParameterSpec(bArrOmac));
        cipher2.doFinal(bArr, 0, bArr.length, bArrCopyOf, this.outputPrefix.length + this.ivSizeInBytes);
        byte[] bArrOmac3 = omac(cipher, 2, bArrCopyOf, this.outputPrefix.length + this.ivSizeInBytes, bArr.length);
        int length3 = this.outputPrefix.length + bArr.length + this.ivSizeInBytes;
        for (int i2 = 0; i2 < 16; i2++) {
            bArrCopyOf[length3 + i2] = (byte) ((bArrOmac2[i2] ^ bArrOmac[i2]) ^ bArrOmac3[i2]);
        }
        return bArrCopyOf;
    }

    @Override // com.google.crypto.tink.Aead
    public byte[] decrypt(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
        int length = bArr.length;
        byte[] bArr3 = this.outputPrefix;
        int length2 = ((length - bArr3.length) - this.ivSizeInBytes) - 16;
        if (length2 < 0) {
            throw new GeneralSecurityException("ciphertext too short");
        }
        if (!Util.isPrefix(bArr3, bArr)) {
            throw new GeneralSecurityException("Decryption failed (OutputPrefix mismatch).");
        }
        Cipher cipher = localEcbCipher.get();
        cipher.init(1, this.keySpec);
        byte[] bArrOmac = omac(cipher, 0, bArr, this.outputPrefix.length, this.ivSizeInBytes);
        byte[] bArr4 = bArr2 == null ? new byte[0] : bArr2;
        byte[] bArrOmac2 = omac(cipher, 1, bArr4, 0, bArr4.length);
        byte[] bArrOmac3 = omac(cipher, 2, bArr, this.outputPrefix.length + this.ivSizeInBytes, length2);
        int length3 = bArr.length - 16;
        byte b = 0;
        for (int i = 0; i < 16; i++) {
            b = (byte) (b | (((bArr[length3 + i] ^ bArrOmac2[i]) ^ bArrOmac[i]) ^ bArrOmac3[i]));
        }
        if (b != 0) {
            throw new AEADBadTagException("tag mismatch");
        }
        Cipher cipher2 = localCtrCipher.get();
        cipher2.init(1, this.keySpec, new IvParameterSpec(bArrOmac));
        return cipher2.doFinal(bArr, this.outputPrefix.length + this.ivSizeInBytes, length2);
    }
}
