package com.google.crypto.tink.internal;

import com.google.crypto.tink.Key;
import com.google.crypto.tink.Registry;
import com.google.errorprone.annotations.DoNotCall;

/* JADX INFO: loaded from: classes2.dex */
public final class RegistryConfiguration extends InternalConfiguration {
    private static final RegistryConfiguration CONFIG = new RegistryConfiguration();

    public static RegistryConfiguration get() {
        return CONFIG;
    }

    private RegistryConfiguration() {
    }

    @Override // com.google.crypto.tink.internal.InternalConfiguration
    public <P> P getPrimitive(Key key, Class<P> cls) {
        return (P) MutablePrimitiveRegistry.globalInstance().getPrimitive(key, cls);
    }

    @Override // com.google.crypto.tink.internal.InternalConfiguration
    public <B, P> P wrap(PrimitiveSet<B> primitiveSet, Class<P> cls) {
        return (P) Registry.wrap(primitiveSet, cls);
    }

    @Override // com.google.crypto.tink.internal.InternalConfiguration
    public Class<?> getInputPrimitiveClass(Class<?> cls) {
        return Registry.getInputPrimitive(cls);
    }

    @DoNotCall
    public static InternalConfiguration createFromPrimitiveRegistry(PrimitiveRegistry primitiveRegistry) {
        throw new UnsupportedOperationException("Cannot create RegistryConfiguration from a PrimitiveRegistry");
    }
}
