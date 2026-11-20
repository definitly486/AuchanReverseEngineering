package com.google.crypto.tink.streamingaead;

import com.google.crypto.tink.StreamingAead;
import java.io.InputStream;
import java.io.OutputStream;
import java.nio.channels.ReadableByteChannel;
import java.nio.channels.SeekableByteChannel;
import java.nio.channels.WritableByteChannel;
import java.util.List;

/* JADX INFO: loaded from: classes2.dex */
final class StreamingAeadHelper implements StreamingAead {
    private final List<StreamingAead> allPrimitives;
    private final StreamingAead primary;

    public StreamingAeadHelper(List<StreamingAead> list, StreamingAead streamingAead) {
        this.allPrimitives = list;
        this.primary = streamingAead;
    }

    @Override // com.google.crypto.tink.StreamingAead
    public WritableByteChannel newEncryptingChannel(WritableByteChannel writableByteChannel, byte[] bArr) {
        return this.primary.newEncryptingChannel(writableByteChannel, bArr);
    }

    @Override // com.google.crypto.tink.StreamingAead
    public ReadableByteChannel newDecryptingChannel(ReadableByteChannel readableByteChannel, byte[] bArr) {
        return new ReadableByteChannelDecrypter(this.allPrimitives, readableByteChannel, bArr);
    }

    @Override // com.google.crypto.tink.StreamingAead
    public SeekableByteChannel newSeekableDecryptingChannel(SeekableByteChannel seekableByteChannel, byte[] bArr) {
        return new SeekableByteChannelDecrypter(this.allPrimitives, seekableByteChannel, bArr);
    }

    @Override // com.google.crypto.tink.StreamingAead
    public InputStream newDecryptingStream(InputStream inputStream, byte[] bArr) {
        return new InputStreamDecrypter(this.allPrimitives, inputStream, bArr);
    }

    @Override // com.google.crypto.tink.StreamingAead
    public OutputStream newEncryptingStream(OutputStream outputStream, byte[] bArr) {
        return this.primary.newEncryptingStream(outputStream, bArr);
    }
}
