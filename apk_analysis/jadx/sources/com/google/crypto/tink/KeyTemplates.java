package com.google.crypto.tink;

import com.google.crypto.tink.internal.MutableParametersRegistry;

/* JADX INFO: loaded from: classes2.dex */
public final class KeyTemplates {
    public static KeyTemplate get(String str) {
        return KeyTemplate.createFrom(MutableParametersRegistry.globalInstance().get(str));
    }

    private KeyTemplates() {
    }
}
