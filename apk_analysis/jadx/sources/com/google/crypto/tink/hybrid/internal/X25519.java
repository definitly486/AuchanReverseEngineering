package com.google.crypto.tink.hybrid.internal;

import com.google.errorprone.annotations.Immutable;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public interface X25519 {
    byte[] computeSharedSecret(byte[] bArr, byte[] bArr2);

    KeyPair generateKeyPair();

    public static final class KeyPair {
        public final byte[] privateKey;
        public final byte[] publicKey;

        public KeyPair(byte[] bArr, byte[] bArr2) {
            this.privateKey = bArr;
            this.publicKey = bArr2;
        }
    }
}
