package com.google.crypto.tink.internal;

import com.google.crypto.tink.Key;
import com.google.crypto.tink.Parameters;
import com.google.crypto.tink.SecretKeyAccess;
import java.util.concurrent.atomic.AtomicReference;

/* JADX INFO: loaded from: classes2.dex */
public final class MutableSerializationRegistry {
    private static final MutableSerializationRegistry GLOBAL_INSTANCE = (MutableSerializationRegistry) TinkBugException.exceptionIsBug(new TinkBugException.ThrowingSupplier() { // from class: com.google.crypto.tink.internal.MutableSerializationRegistry$$ExternalSyntheticLambda0
        @Override // com.google.crypto.tink.internal.TinkBugException.ThrowingSupplier
        public final Object get() {
            return MutableSerializationRegistry.createGlobalInstance();
        }
    });
    private final AtomicReference<SerializationRegistry> registry = new AtomicReference<>(new SerializationRegistry.Builder().build());

    /* JADX INFO: Access modifiers changed from: private */
    public static MutableSerializationRegistry createGlobalInstance() {
        MutableSerializationRegistry mutableSerializationRegistry = new MutableSerializationRegistry();
        mutableSerializationRegistry.registerKeySerializer(KeySerializer.create(new KeySerializer.KeySerializationFunction() { // from class: com.google.crypto.tink.internal.MutableSerializationRegistry$$ExternalSyntheticLambda1
            @Override // com.google.crypto.tink.internal.KeySerializer.KeySerializationFunction
            public final Serialization serializeKey(Key key, SecretKeyAccess secretKeyAccess) {
                return ((LegacyProtoKey) key).getSerialization(secretKeyAccess);
            }
        }, LegacyProtoKey.class, ProtoKeySerialization.class));
        return mutableSerializationRegistry;
    }

    public static MutableSerializationRegistry globalInstance() {
        return GLOBAL_INSTANCE;
    }

    public synchronized <KeyT extends Key, SerializationT extends Serialization> void registerKeySerializer(KeySerializer<KeyT, SerializationT> keySerializer) {
        this.registry.set(new SerializationRegistry.Builder(this.registry.get()).registerKeySerializer(keySerializer).build());
    }

    public synchronized <SerializationT extends Serialization> void registerKeyParser(KeyParser<SerializationT> keyParser) {
        this.registry.set(new SerializationRegistry.Builder(this.registry.get()).registerKeyParser(keyParser).build());
    }

    public synchronized <ParametersT extends Parameters, SerializationT extends Serialization> void registerParametersSerializer(ParametersSerializer<ParametersT, SerializationT> parametersSerializer) {
        this.registry.set(new SerializationRegistry.Builder(this.registry.get()).registerParametersSerializer(parametersSerializer).build());
    }

    public synchronized <SerializationT extends Serialization> void registerParametersParser(ParametersParser<SerializationT> parametersParser) {
        this.registry.set(new SerializationRegistry.Builder(this.registry.get()).registerParametersParser(parametersParser).build());
    }

    public <SerializationT extends Serialization> boolean hasParserForKey(SerializationT serializationt) {
        return this.registry.get().hasParserForKey(serializationt);
    }

    public <SerializationT extends Serialization> Key parseKey(SerializationT serializationt, SecretKeyAccess secretKeyAccess) {
        return this.registry.get().parseKey(serializationt, secretKeyAccess);
    }

    public Key parseKeyWithLegacyFallback(ProtoKeySerialization protoKeySerialization, SecretKeyAccess secretKeyAccess) {
        if (!hasParserForKey(protoKeySerialization)) {
            return new LegacyProtoKey(protoKeySerialization, secretKeyAccess);
        }
        return parseKey(protoKeySerialization, secretKeyAccess);
    }

    public <KeyT extends Key, SerializationT extends Serialization> boolean hasSerializerForKey(KeyT keyt, Class<SerializationT> cls) {
        return this.registry.get().hasSerializerForKey(keyt, cls);
    }

    public <KeyT extends Key, SerializationT extends Serialization> SerializationT serializeKey(KeyT keyt, Class<SerializationT> cls, SecretKeyAccess secretKeyAccess) {
        return (SerializationT) this.registry.get().serializeKey(keyt, cls, secretKeyAccess);
    }

    public <SerializationT extends Serialization> boolean hasParserForParameters(SerializationT serializationt) {
        return this.registry.get().hasParserForParameters(serializationt);
    }

    public <SerializationT extends Serialization> Parameters parseParameters(SerializationT serializationt) {
        return this.registry.get().parseParameters(serializationt);
    }

    public Parameters parseParametersWithLegacyFallback(ProtoParametersSerialization protoParametersSerialization) {
        if (!hasParserForParameters(protoParametersSerialization)) {
            return new LegacyProtoParameters(protoParametersSerialization);
        }
        return parseParameters(protoParametersSerialization);
    }

    public <ParametersT extends Parameters, SerializationT extends Serialization> boolean hasSerializerForParameters(ParametersT parameterst, Class<SerializationT> cls) {
        return this.registry.get().hasSerializerForParameters(parameterst, cls);
    }

    public <ParametersT extends Parameters, SerializationT extends Serialization> SerializationT serializeParameters(ParametersT parameterst, Class<SerializationT> cls) {
        return (SerializationT) this.registry.get().serializeParameters(parameterst, cls);
    }
}
