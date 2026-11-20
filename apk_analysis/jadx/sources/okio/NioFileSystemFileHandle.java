package okio;

import java.nio.ByteBuffer;
import java.nio.channels.FileChannel;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: NioFileSystemFileHandle.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class NioFileSystemFileHandle extends FileHandle {
    private final FileChannel fileChannel;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public NioFileSystemFileHandle(boolean z, FileChannel fileChannel) {
        super(z);
        Intrinsics.checkNotNullParameter(fileChannel, "fileChannel");
        this.fileChannel = fileChannel;
    }

    @Override // okio.FileHandle
    protected synchronized void protectedResize(long j) throws Throwable {
        try {
            try {
                long size = size();
                long j2 = j - size;
                if (j2 > 0) {
                    int i = (int) j2;
                    protectedWrite(size, new byte[i], 0, i);
                } else {
                    this.fileChannel.truncate(j);
                }
            } catch (Throwable th) {
                th = th;
                throw th;
            }
        } catch (Throwable th2) {
            th = th2;
            throw th;
        }
    }

    @Override // okio.FileHandle
    protected synchronized long protectedSize() {
        return this.fileChannel.size();
    }

    @Override // okio.FileHandle
    protected synchronized int protectedRead(long j, byte[] array, int i, int i2) {
        Intrinsics.checkNotNullParameter(array, "array");
        this.fileChannel.position(j);
        ByteBuffer byteBufferWrap = ByteBuffer.wrap(array, i, i2);
        int i3 = 0;
        while (i3 < i2) {
            int i4 = this.fileChannel.read(byteBufferWrap);
            if (i4 == -1) {
                if (i3 != 0) {
                    break;
                }
                return -1;
            }
            i3 += i4;
        }
        return i3;
    }

    @Override // okio.FileHandle
    protected synchronized void protectedWrite(long j, byte[] array, int i, int i2) {
        Intrinsics.checkNotNullParameter(array, "array");
        this.fileChannel.position(j);
        this.fileChannel.write(ByteBuffer.wrap(array, i, i2));
    }

    @Override // okio.FileHandle
    protected synchronized void protectedFlush() {
        this.fileChannel.force(true);
    }

    @Override // okio.FileHandle
    protected synchronized void protectedClose() {
        this.fileChannel.close();
    }
}
