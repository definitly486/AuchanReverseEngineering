package com.google.crypto.tink.keyderivation.internal;

import com.google.crypto.tink.Key;
import com.google.errorprone.annotations.Immutable;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public interface KeyDeriver {
    Key deriveKey(byte[] bArr);
}
