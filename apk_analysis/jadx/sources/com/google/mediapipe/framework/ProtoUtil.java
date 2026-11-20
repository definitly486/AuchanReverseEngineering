package com.google.mediapipe.framework;

import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.InvalidProtocolBufferException;
import com.google.protobuf.MessageLite;
import java.util.NoSuchElementException;

/* JADX INFO: loaded from: classes3.dex */
public final class ProtoUtil {
    static TypeNameRegistry typeNameRegistry = new TypeNameRegistryConcrete();

    public static <T extends MessageLite> void registerTypeName(Class<T> cls, String str) {
        typeNameRegistry.registerTypeName(cls, str);
    }

    public static <T extends MessageLite> String getTypeName(Class<T> cls) {
        return typeNameRegistry.getTypeName(cls);
    }

    public static ExtensionRegistryLite getExtensionRegistry() {
        return ExtensionRegistryLite.getEmptyRegistry();
    }

    public static <T extends MessageLite> SerializedMessage pack(T t) {
        SerializedMessage serializedMessage = new SerializedMessage();
        String typeName = getTypeName(t.getClass());
        serializedMessage.typeName = typeName;
        if (typeName == null) {
            throw new NoSuchElementException("Cannot determine the protobuf type name for class: " + t.getClass() + ". Have you called ProtoUtil.registerTypeName?");
        }
        serializedMessage.value = t.toByteArray();
        return serializedMessage;
    }

    public static <T extends MessageLite> T unpack(SerializedMessage serializedMessage, T t) throws InvalidProtocolBufferException {
        String typeName = getTypeName(t.getClass());
        if (!serializedMessage.typeName.equals(typeName)) {
            throw new InvalidProtocolBufferException("Message type does not match the expected type. Expected: " + typeName + " Got: " + serializedMessage.typeName);
        }
        return (T) t.getParserForType().parseFrom(serializedMessage.value, getExtensionRegistry());
    }

    private ProtoUtil() {
    }

    static class SerializedMessage {
        public String typeName;
        public byte[] value;

        SerializedMessage() {
        }
    }
}
