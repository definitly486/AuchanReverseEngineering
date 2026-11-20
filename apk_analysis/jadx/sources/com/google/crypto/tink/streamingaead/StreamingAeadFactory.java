package com.google.crypto.tink.streamingaead;

import com.google.crypto.tink.KeysetHandle;
import com.google.crypto.tink.RegistryConfiguration;
import com.google.crypto.tink.StreamingAead;

/* JADX INFO: loaded from: classes2.dex */
@Deprecated
public final class StreamingAeadFactory {
    public static StreamingAead getPrimitive(KeysetHandle keysetHandle) {
        StreamingAeadWrapper.register();
        return (StreamingAead) keysetHandle.getPrimitive(RegistryConfiguration.get(), StreamingAead.class);
    }

    private StreamingAeadFactory() {
    }
}
