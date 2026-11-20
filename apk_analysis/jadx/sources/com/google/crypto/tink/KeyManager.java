package com.google.crypto.tink;

import com.google.crypto.tink.proto.KeyData;
import com.google.crypto.tink.shaded.protobuf.ByteString;
import com.google.crypto.tink.shaded.protobuf.MessageLite;

/* JADX INFO: loaded from: classes2.dex */
public interface KeyManager<P> {
    String getKeyType();

    P getPrimitive(ByteString byteString);

    Class<P> getPrimitiveClass();

    KeyData newKeyData(ByteString byteString);

    @Deprecated
    default P getPrimitive(MessageLite messageLite) {
        throw new UnsupportedOperationException();
    }

    @Deprecated
    default MessageLite newKey(ByteString byteString) {
        throw new UnsupportedOperationException();
    }

    @Deprecated
    default MessageLite newKey(MessageLite messageLite) {
        throw new UnsupportedOperationException();
    }

    @Deprecated
    default boolean doesSupport(String str) {
        throw new UnsupportedOperationException();
    }

    @Deprecated
    default int getVersion() {
        throw new UnsupportedOperationException();
    }
}
