package com.google.crypto.tink.streamingaead.internal;

import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.Registry;
import com.google.crypto.tink.StreamingAead;
import com.google.crypto.tink.internal.LegacyProtoKey;
import com.google.crypto.tink.internal.ProtoKeySerialization;
import com.google.crypto.tink.proto.KeyData;
import java.io.InputStream;
import java.io.OutputStream;
import java.nio.channels.ReadableByteChannel;
import java.nio.channels.SeekableByteChannel;
import java.nio.channels.WritableByteChannel;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
public class LegacyFullStreamingAead implements StreamingAead {
    private final StreamingAead rawStreamingAead;

    public static StreamingAead create(LegacyProtoKey legacyProtoKey) throws GeneralSecurityException {
        ProtoKeySerialization serialization = legacyProtoKey.getSerialization(InsecureSecretKeyAccess.get());
        return new LegacyFullStreamingAead((StreamingAead) Registry.getPrimitive(KeyData.newBuilder().setTypeUrl(serialization.getTypeUrl()).setValue(serialization.getValue()).setKeyMaterialType(serialization.getKeyMaterialType()).build(), StreamingAead.class));
    }

    private LegacyFullStreamingAead(StreamingAead streamingAead) {
        this.rawStreamingAead = streamingAead;
    }

    @Override // com.google.crypto.tink.StreamingAead
    public WritableByteChannel newEncryptingChannel(WritableByteChannel writableByteChannel, byte[] bArr) {
        return this.rawStreamingAead.newEncryptingChannel(writableByteChannel, bArr);
    }

    @Override // com.google.crypto.tink.StreamingAead
    public SeekableByteChannel newSeekableDecryptingChannel(SeekableByteChannel seekableByteChannel, byte[] bArr) {
        return this.rawStreamingAead.newSeekableDecryptingChannel(seekableByteChannel, bArr);
    }

    @Override // com.google.crypto.tink.StreamingAead
    public ReadableByteChannel newDecryptingChannel(ReadableByteChannel readableByteChannel, byte[] bArr) {
        return this.rawStreamingAead.newDecryptingChannel(readableByteChannel, bArr);
    }

    @Override // com.google.crypto.tink.StreamingAead
    public OutputStream newEncryptingStream(OutputStream outputStream, byte[] bArr) {
        return this.rawStreamingAead.newEncryptingStream(outputStream, bArr);
    }

    @Override // com.google.crypto.tink.StreamingAead
    public InputStream newDecryptingStream(InputStream inputStream, byte[] bArr) {
        return this.rawStreamingAead.newDecryptingStream(inputStream, bArr);
    }
}
