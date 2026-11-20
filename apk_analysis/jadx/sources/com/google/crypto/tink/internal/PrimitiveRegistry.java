package com.google.crypto.tink.internal;

import com.google.crypto.tink.Key;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.security.GeneralSecurityException;
import java.util.HashMap;
import java.util.Map;
import java.util.Objects;

/* JADX INFO: loaded from: classes2.dex */
public class PrimitiveRegistry {
    private final Map<PrimitiveConstructorIndex, PrimitiveConstructor<?, ?>> primitiveConstructorMap;
    private final Map<Class<?>, PrimitiveWrapper<?, ?>> primitiveWrapperMap;

    public static final class Builder {
        private final Map<PrimitiveConstructorIndex, PrimitiveConstructor<?, ?>> primitiveConstructorMap;
        private final Map<Class<?>, PrimitiveWrapper<?, ?>> primitiveWrapperMap;

        private Builder() {
            this.primitiveConstructorMap = new HashMap();
            this.primitiveWrapperMap = new HashMap();
        }

        private Builder(PrimitiveRegistry primitiveRegistry) {
            this.primitiveConstructorMap = new HashMap(primitiveRegistry.primitiveConstructorMap);
            this.primitiveWrapperMap = new HashMap(primitiveRegistry.primitiveWrapperMap);
        }

        @CanIgnoreReturnValue
        public <KeyT extends Key, PrimitiveT> Builder registerPrimitiveConstructor(PrimitiveConstructor<KeyT, PrimitiveT> primitiveConstructor) throws GeneralSecurityException {
            if (primitiveConstructor == null) {
                throw new NullPointerException("primitive constructor must be non-null");
            }
            PrimitiveConstructorIndex primitiveConstructorIndex = new PrimitiveConstructorIndex(primitiveConstructor.getKeyClass(), primitiveConstructor.getPrimitiveClass());
            if (this.primitiveConstructorMap.containsKey(primitiveConstructorIndex)) {
                PrimitiveConstructor<?, ?> primitiveConstructor2 = this.primitiveConstructorMap.get(primitiveConstructorIndex);
                if (primitiveConstructor2.equals(primitiveConstructor) && primitiveConstructor.equals(primitiveConstructor2)) {
                    return this;
                }
                throw new GeneralSecurityException("Attempt to register non-equal PrimitiveConstructor object for already existing object of type: " + primitiveConstructorIndex);
            }
            this.primitiveConstructorMap.put(primitiveConstructorIndex, primitiveConstructor);
            return this;
        }

        @CanIgnoreReturnValue
        public <InputPrimitiveT, WrapperPrimitiveT> Builder registerPrimitiveWrapper(PrimitiveWrapper<InputPrimitiveT, WrapperPrimitiveT> primitiveWrapper) throws GeneralSecurityException {
            if (primitiveWrapper == null) {
                throw new NullPointerException("wrapper must be non-null");
            }
            Class<WrapperPrimitiveT> primitiveClass = primitiveWrapper.getPrimitiveClass();
            if (this.primitiveWrapperMap.containsKey(primitiveClass)) {
                PrimitiveWrapper<?, ?> primitiveWrapper2 = this.primitiveWrapperMap.get(primitiveClass);
                if (primitiveWrapper2.equals(primitiveWrapper) && primitiveWrapper.equals(primitiveWrapper2)) {
                    return this;
                }
                throw new GeneralSecurityException("Attempt to register non-equal PrimitiveWrapper object or input class object for already existing object of type" + primitiveClass);
            }
            this.primitiveWrapperMap.put(primitiveClass, primitiveWrapper);
            return this;
        }

        public PrimitiveRegistry build() {
            return new PrimitiveRegistry(this);
        }
    }

    public static Builder builder() {
        return new Builder();
    }

    public static Builder builder(PrimitiveRegistry primitiveRegistry) {
        return new Builder();
    }

    private PrimitiveRegistry(Builder builder) {
        this.primitiveConstructorMap = new HashMap(builder.primitiveConstructorMap);
        this.primitiveWrapperMap = new HashMap(builder.primitiveWrapperMap);
    }

    public <KeyT extends Key, PrimitiveT> PrimitiveT getPrimitive(KeyT keyt, Class<PrimitiveT> cls) throws GeneralSecurityException {
        PrimitiveConstructorIndex primitiveConstructorIndex = new PrimitiveConstructorIndex(keyt.getClass(), cls);
        if (!this.primitiveConstructorMap.containsKey(primitiveConstructorIndex)) {
            throw new GeneralSecurityException("No PrimitiveConstructor for " + primitiveConstructorIndex + " available, see https://developers.google.com/tink/faq/registration_errors");
        }
        return (PrimitiveT) this.primitiveConstructorMap.get(primitiveConstructorIndex).constructPrimitive(keyt);
    }

    public Class<?> getInputPrimitiveClass(Class<?> cls) throws GeneralSecurityException {
        if (!this.primitiveWrapperMap.containsKey(cls)) {
            throw new GeneralSecurityException("No input primitive class for " + cls + " available");
        }
        return this.primitiveWrapperMap.get(cls).getInputPrimitiveClass();
    }

    public <InputPrimitiveT, WrapperPrimitiveT> WrapperPrimitiveT wrap(PrimitiveSet<InputPrimitiveT> primitiveSet, Class<WrapperPrimitiveT> cls) throws GeneralSecurityException {
        if (!this.primitiveWrapperMap.containsKey(cls)) {
            throw new GeneralSecurityException("No wrapper found for " + cls);
        }
        PrimitiveWrapper<?, ?> primitiveWrapper = this.primitiveWrapperMap.get(cls);
        if (!primitiveSet.getPrimitiveClass().equals(primitiveWrapper.getInputPrimitiveClass()) || !primitiveWrapper.getInputPrimitiveClass().equals(primitiveSet.getPrimitiveClass())) {
            throw new GeneralSecurityException("Input primitive type of the wrapper doesn't match the type of primitives in the provided PrimitiveSet");
        }
        return (WrapperPrimitiveT) primitiveWrapper.wrap(primitiveSet);
    }

    private static final class PrimitiveConstructorIndex {
        private final Class<?> keyClass;
        private final Class<?> primitiveClass;

        private PrimitiveConstructorIndex(Class<?> cls, Class<?> cls2) {
            this.keyClass = cls;
            this.primitiveClass = cls2;
        }

        public boolean equals(Object obj) {
            if (!(obj instanceof PrimitiveConstructorIndex)) {
                return false;
            }
            PrimitiveConstructorIndex primitiveConstructorIndex = (PrimitiveConstructorIndex) obj;
            return primitiveConstructorIndex.keyClass.equals(this.keyClass) && primitiveConstructorIndex.primitiveClass.equals(this.primitiveClass);
        }

        public int hashCode() {
            return Objects.hash(this.keyClass, this.primitiveClass);
        }

        public String toString() {
            return this.keyClass.getSimpleName() + " with primitive type: " + this.primitiveClass.getSimpleName();
        }
    }
}
