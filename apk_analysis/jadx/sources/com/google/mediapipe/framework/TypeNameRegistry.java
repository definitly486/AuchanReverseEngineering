package com.google.mediapipe.framework;

import com.google.protobuf.MessageLite;

/* JADX INFO: loaded from: classes3.dex */
interface TypeNameRegistry {
    <T extends MessageLite> String getTypeName(Class<T> cls);

    <T extends MessageLite> void registerTypeName(Class<T> cls, String str);
}
