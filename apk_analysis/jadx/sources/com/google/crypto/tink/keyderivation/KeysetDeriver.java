package com.google.crypto.tink.keyderivation;

import com.google.crypto.tink.KeysetHandle;
import com.google.errorprone.annotations.Immutable;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public interface KeysetDeriver {
    KeysetHandle deriveKeyset(byte[] bArr);
}
