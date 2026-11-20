package io.appmetrica.analytics.coreutils.internal.io;

import android.util.Base64;
import com.scanflow.datacapture.barinternal.kotlin.io.ByteStreamsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import java.io.ByteArrayInputStream;
import java.util.zip.GZIPInputStream;

/* JADX INFO: loaded from: classes3.dex */
public final class Base64Utils {
    public static final Base64Utils INSTANCE = new Base64Utils();
    public static final int IO_BUFFER_SIZE = 4096;

    private Base64Utils() {
    }

    public static final String compressBase64(byte[] bArr) {
        try {
            return Base64.encodeToString(GZIPUtils.gzipBytes(bArr), 0);
        } catch (Throwable unused) {
            return null;
        }
    }

    public static final String compressBase64String(String str) {
        byte[] bytes;
        if (str != null) {
            try {
                bytes = str.getBytes(Charsets.UTF_8);
            } catch (Throwable unused) {
                return null;
            }
        } else {
            bytes = null;
        }
        return compressBase64(bytes);
    }

    public static final byte[] decompressBase64GzipAsBytes(String str) {
        GZIPInputStream gZIPInputStream;
        byte[] bytes;
        ByteArrayInputStream byteArrayInputStream = null;
        try {
            ByteArrayInputStream byteArrayInputStream2 = new ByteArrayInputStream(Base64.decode(str, 0));
            try {
                gZIPInputStream = new GZIPInputStream(byteArrayInputStream2);
                try {
                    bytes = ByteStreamsKt.readBytes(gZIPInputStream);
                } catch (Throwable unused) {
                    byteArrayInputStream = byteArrayInputStream2;
                    try {
                        bytes = new byte[0];
                        byteArrayInputStream2 = byteArrayInputStream;
                    } finally {
                        CloseableUtils.closeSafely(gZIPInputStream);
                        CloseableUtils.closeSafely(byteArrayInputStream);
                    }
                }
            } catch (Throwable unused2) {
                gZIPInputStream = null;
            }
        } catch (Throwable unused3) {
            gZIPInputStream = null;
        }
        return bytes;
    }

    public static final String decompressBase64GzipAsString(String str) {
        try {
            return new String(decompressBase64GzipAsBytes(str), Charsets.UTF_8);
        } catch (Throwable unused) {
            return null;
        }
    }
}
