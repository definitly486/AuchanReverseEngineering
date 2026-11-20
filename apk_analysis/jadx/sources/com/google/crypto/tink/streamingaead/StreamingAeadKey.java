package com.google.crypto.tink.streamingaead;

import com.google.crypto.tink.Key;

/* JADX INFO: loaded from: classes2.dex */
public abstract class StreamingAeadKey extends Key {
    @Override // com.google.crypto.tink.Key
    public final Integer getIdRequirementOrNull() {
        return null;
    }

    @Override // com.google.crypto.tink.Key
    public abstract StreamingAeadParameters getParameters();
}
