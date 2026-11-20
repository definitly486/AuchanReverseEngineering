package org.tensorflow.lite.support.metadata;

import com.google.common.primitives.UnsignedBytes;
import java.io.InputStream;
import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes4.dex */
final class BoundedInputStream extends InputStream {
    private final SeekableByteChannelCompat channel;
    private final long end;
    private long position;
    private final ByteBuffer singleByteBuffer = ByteBuffer.allocate(1);

    BoundedInputStream(SeekableByteChannelCompat seekableByteChannelCompat, long j, long j2) {
        Preconditions.checkArgument(j2 >= 0 && j >= 0, String.format("Invalid length of stream at offset=%d, length=%d", Long.valueOf(j), Long.valueOf(j2)));
        this.end = j2 + j;
        this.channel = seekableByteChannelCompat;
        this.position = j;
    }

    @Override // java.io.InputStream
    public int available() {
        return (int) (Math.min(this.end, this.channel.size()) - this.position);
    }

    @Override // java.io.InputStream
    public int read() {
        if (this.position >= this.end) {
            return -1;
        }
        this.singleByteBuffer.rewind();
        int i = read(this.position, this.singleByteBuffer);
        if (i < 0) {
            return i;
        }
        this.position++;
        return this.singleByteBuffer.get() & UnsignedBytes.MAX_VALUE;
    }

    @Override // java.io.InputStream
    public int read(byte[] bArr, int i, int i2) {
        Preconditions.checkNotNull(bArr);
        Preconditions.checkElementIndex(i, bArr.length, "The start offset");
        Preconditions.checkElementIndex(i2, (bArr.length - i) + 1, "The maximumn number of bytes to read");
        if (i2 == 0) {
            return 0;
        }
        long j = i2;
        long j2 = this.end;
        long j3 = this.position;
        if (j > j2 - j3) {
            if (j3 >= j2) {
                return -1;
            }
            i2 = (int) (j2 - j3);
        }
        int i3 = read(this.position, ByteBuffer.wrap(bArr, i, i2));
        if (i3 > 0) {
            this.position += (long) i3;
        }
        return i3;
    }

    private int read(long j, ByteBuffer byteBuffer) {
        int i;
        synchronized (this.channel) {
            this.channel.position(j);
            i = this.channel.read(byteBuffer);
        }
        byteBuffer.flip();
        return i;
    }
}
