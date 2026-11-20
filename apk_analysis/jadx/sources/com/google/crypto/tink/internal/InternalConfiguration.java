package com.google.crypto.tink.internal;

import com.google.crypto.tink.Configuration;
import com.google.crypto.tink.Key;

/* JADX INFO: loaded from: classes2.dex */
public abstract class InternalConfiguration extends Configuration {
    public abstract Class<?> getInputPrimitiveClass(Class<?> cls);

    public abstract <P> P getPrimitive(Key key, Class<P> cls);

    public abstract <B, P> P wrap(PrimitiveSet<B> primitiveSet, Class<P> cls);

    public static InternalConfiguration createFromPrimitiveRegistry(PrimitiveRegistry primitiveRegistry) {
        return new InternalConfigurationImpl(primitiveRegistry);
    }

    private static class InternalConfigurationImpl extends InternalConfiguration {
        private final PrimitiveRegistry registry;

        private InternalConfigurationImpl(PrimitiveRegistry primitiveRegistry) {
            this.registry = primitiveRegistry;
        }

        @Override // com.google.crypto.tink.internal.InternalConfiguration
        public <P> P getPrimitive(Key key, Class<P> cls) {
            return (P) this.registry.getPrimitive(key, cls);
        }

        @Override // com.google.crypto.tink.internal.InternalConfiguration
        public Class<?> getInputPrimitiveClass(Class<?> cls) {
            return this.registry.getInputPrimitiveClass(cls);
        }

        @Override // com.google.crypto.tink.internal.InternalConfiguration
        public <B, P> P wrap(PrimitiveSet<B> primitiveSet, Class<P> cls) {
            return (P) this.registry.wrap(primitiveSet, cls);
        }
    }
}
