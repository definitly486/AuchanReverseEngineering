package com.google.crypto.tink;

/* JADX INFO: loaded from: classes2.dex */
public class RegistryConfiguration {
    private RegistryConfiguration() {
    }

    public static Configuration get() {
        return com.google.crypto.tink.internal.RegistryConfiguration.get();
    }
}
