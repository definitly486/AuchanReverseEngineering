package com.google.crypto.tink.aead;

import com.google.crypto.tink.Aead;
import com.google.crypto.tink.KeysetHandle;
import com.google.crypto.tink.RegistryConfiguration;

/* JADX INFO: loaded from: classes2.dex */
@Deprecated
public final class AeadFactory {
    @Deprecated
    public static Aead getPrimitive(KeysetHandle keysetHandle) {
        AeadWrapper.register();
        return (Aead) keysetHandle.getPrimitive(RegistryConfiguration.get(), Aead.class);
    }

    private AeadFactory() {
    }
}
