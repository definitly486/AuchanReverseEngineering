package okio;

import java.io.RandomAccessFile;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: JvmFileHandle.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class JvmFileHandle extends FileHandle {
    private final RandomAccessFile randomAccessFile;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public JvmFileHandle(boolean z, RandomAccessFile randomAccessFile) {
        super(z);
        Intrinsics.checkNotNullParameter(randomAccessFile, "randomAccessFile");
        this.randomAccessFile = randomAccessFile;
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
                    this.randomAccessFile.setLength(j);
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
        return this.randomAccessFile.length();
    }

    @Override // okio.FileHandle
    protected synchronized int protectedRead(long j, byte[] array, int i, int i2) {
        Intrinsics.checkNotNullParameter(array, "array");
        this.randomAccessFile.seek(j);
        int i3 = 0;
        while (i3 < i2) {
            int i4 = this.randomAccessFile.read(array, i, i2 - i3);
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
        this.randomAccessFile.seek(j);
        this.randomAccessFile.write(array, i, i2);
    }

    @Override // okio.FileHandle
    protected synchronized void protectedFlush() {
        this.randomAccessFile.getFD().sync();
    }

    @Override // okio.FileHandle
    protected synchronized void protectedClose() {
        this.randomAccessFile.close();
    }
}
