package com.google.mediapipe.framework;

import com.google.protobuf.MessageLite;
import java.util.HashMap;
import java.util.Map;

/* JADX INFO: compiled from: TypeNameRegistryLite.java */
/* JADX INFO: loaded from: classes3.dex */
final class TypeNameRegistryConcrete implements TypeNameRegistry {
    private final Map<Class<? extends MessageLite>, String> typeNames = new HashMap();

    TypeNameRegistryConcrete() {
    }

    @Override // com.google.mediapipe.framework.TypeNameRegistry
    public <T extends MessageLite> String getTypeName(Class<T> cls) {
        return this.typeNames.get(cls);
    }

    @Override // com.google.mediapipe.framework.TypeNameRegistry
    public <T extends MessageLite> void registerTypeName(Class<T> cls, String str) {
        if (this.typeNames.containsKey(cls) && !this.typeNames.get(cls).equals(str)) {
            throw new MediaPipeException(MediaPipeException.StatusCode.ALREADY_EXISTS.ordinal(), "Protobuf type name: " + str + " conflicts with: " + this.typeNames.get(cls));
        }
        this.typeNames.put(cls, str);
    }
}
