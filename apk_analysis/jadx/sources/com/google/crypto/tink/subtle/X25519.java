package com.google.crypto.tink.subtle;

import com.google.common.base.Ascii;
import com.google.common.primitives.UnsignedBytes;
import com.google.crypto.tink.annotations.Alpha;
import com.google.crypto.tink.internal.Curve25519;
import com.google.crypto.tink.internal.Field25519;
import java.security.InvalidKeyException;
import java.util.Arrays;
import org.tensorflow.lite.schema.BuiltinOptions;

/* JADX INFO: loaded from: classes2.dex */
@Alpha
public final class X25519 {
    public static byte[] generatePrivateKey() {
        byte[] bArrRandBytes = Random.randBytes(32);
        bArrRandBytes[0] = (byte) (bArrRandBytes[0] | 7);
        byte b = (byte) (bArrRandBytes[31] & BuiltinOptions.LogicalNotOptions);
        bArrRandBytes[31] = b;
        bArrRandBytes[31] = (byte) (b | UnsignedBytes.MAX_POWER_OF_TWO);
        return bArrRandBytes;
    }

    public static byte[] computeSharedSecret(byte[] bArr, byte[] bArr2) throws InvalidKeyException {
        if (bArr.length != 32) {
            throw new InvalidKeyException("Private key must have 32 bytes.");
        }
        long[] jArr = new long[11];
        byte[] bArrCopyOf = Arrays.copyOf(bArr, 32);
        bArrCopyOf[0] = (byte) (bArrCopyOf[0] & 248);
        byte b = (byte) (bArrCopyOf[31] & Ascii.DEL);
        bArrCopyOf[31] = b;
        bArrCopyOf[31] = (byte) (b | 64);
        Curve25519.curveMult(jArr, bArrCopyOf, bArr2);
        return Field25519.contract(jArr);
    }

    public static byte[] publicFromPrivate(byte[] bArr) throws InvalidKeyException {
        if (bArr.length != 32) {
            throw new InvalidKeyException("Private key must have 32 bytes.");
        }
        byte[] bArr2 = new byte[32];
        bArr2[0] = 9;
        return computeSharedSecret(bArr, bArr2);
    }

    private X25519() {
    }
}
