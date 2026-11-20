package com.google.crypto.tink;

import com.google.crypto.tink.internal.PrimitiveWrapper;

/* JADX INFO: loaded from: classes2.dex */
@Deprecated
public interface Catalogue<P> {
    KeyManager<P> getKeyManager(String str, String str2, int i);

    PrimitiveWrapper<?, P> getPrimitiveWrapper();
}
