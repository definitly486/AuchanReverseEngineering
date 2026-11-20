package io.appmetrica.analytics.impl;

import androidx.core.location.LocationRequestCompat;
import java.io.Closeable;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.nio.ByteBuffer;
import java.nio.channels.FileChannel;
import java.nio.channels.FileLock;
import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ib, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0332ib {
    public static String a(File file) {
        byte[] bArrArray;
        RandomAccessFile randomAccessFile;
        FileLock fileLockLock;
        if (file == null || !file.exists()) {
            bArrArray = null;
        } else {
            try {
                randomAccessFile = new RandomAccessFile(file, "r");
                try {
                    FileChannel channel = randomAccessFile.getChannel();
                    fileLockLock = channel.lock(0L, LocationRequestCompat.PASSIVE_INTERVAL, true);
                    try {
                        ByteBuffer byteBufferAllocate = ByteBuffer.allocate((int) file.length());
                        channel.read(byteBufferAllocate);
                        byteBufferAllocate.flip();
                        bArrArray = byteBufferAllocate.array();
                        file.getAbsolutePath();
                        a(fileLockLock);
                        Do.a((Closeable) randomAccessFile);
                    } catch (IOException | SecurityException unused) {
                        file.getAbsolutePath();
                        a(fileLockLock);
                        Do.a((Closeable) randomAccessFile);
                        bArrArray = null;
                    } catch (Throwable th) {
                        th = th;
                        try {
                            C0263fk c0263fk = Dj.a;
                            c0263fk.getClass();
                            c0263fk.a(new Ej("error_during_file_reading", th));
                            file.getAbsolutePath();
                            a(fileLockLock);
                            Do.a((Closeable) randomAccessFile);
                            bArrArray = null;
                        } catch (Throwable th2) {
                            file.getAbsolutePath();
                            a(fileLockLock);
                            Do.a((Closeable) randomAccessFile);
                            throw th2;
                        }
                    }
                } catch (IOException | SecurityException unused2) {
                    fileLockLock = null;
                } catch (Throwable th3) {
                    th = th3;
                    fileLockLock = null;
                }
            } catch (IOException | SecurityException unused3) {
                randomAccessFile = null;
                fileLockLock = null;
            } catch (Throwable th4) {
                th = th4;
                randomAccessFile = null;
                fileLockLock = null;
            }
        }
        if (bArrArray != null) {
            return new String(bArrArray, StandardCharsets.UTF_8);
        }
        return null;
    }

    public static void a(FileLock fileLock) {
        if (fileLock == null || !fileLock.isValid()) {
            return;
        }
        try {
            fileLock.release();
        } catch (IOException unused) {
        }
    }

    public static void a(String str, FileOutputStream fileOutputStream) {
        FileLock fileLockLock = null;
        try {
            FileChannel channel = fileOutputStream.getChannel();
            fileLockLock = channel.lock();
            byte[] bytes = str.getBytes(StandardCharsets.UTF_8);
            ByteBuffer byteBufferAllocate = ByteBuffer.allocate(bytes.length);
            byteBufferAllocate.put(bytes);
            byteBufferAllocate.flip();
            channel.write(byteBufferAllocate);
            channel.force(true);
        } catch (IOException unused) {
        } finally {
            a(fileLockLock);
            Do.a((Closeable) fileOutputStream);
        }
    }

    public static byte[] a(String str) {
        try {
            return MessageDigest.getInstance("MD5").digest(str.getBytes(StandardCharsets.UTF_8));
        } catch (NoSuchAlgorithmException unused) {
            return new byte[0];
        }
    }
}
