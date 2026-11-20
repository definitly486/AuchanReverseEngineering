package com.google.android.gms.internal.mlkit_vision_text_bundled_common;

import com.bumptech.glide.load.Key;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;

/* JADX INFO: compiled from: com.google.mlkit:text-recognition-bundled-common@@17.0.0 */
/* JADX INFO: loaded from: classes2.dex */
public final class zbuo {
    static final Charset zba;
    public static final byte[] zbb;

    static {
        Charset.forName("US-ASCII");
        zba = Charset.forName(Key.STRING_CHARSET_NAME);
        Charset.forName("ISO-8859-1");
        byte[] bArr = new byte[0];
        zbb = bArr;
        ByteBuffer.wrap(bArr);
        int i = zbtg.zba;
        try {
            new zbte(bArr, 0, 0, false, null).zba(0);
        } catch (zbuq e) {
            throw new IllegalArgumentException(e);
        }
    }

    public static int zba(boolean z) {
        return z ? 1231 : 1237;
    }

    static int zbb(int i, byte[] bArr, int i2, int i3) {
        for (int i4 = 0; i4 < i3; i4++) {
            i = (i * 31) + bArr[i4];
        }
        return i;
    }

    static Object zbc(Object obj, String str) {
        if (obj != null) {
            return obj;
        }
        throw new NullPointerException("messageType");
    }

    static boolean zbd(zbvm zbvmVar) {
        if (zbvmVar instanceof zbsk) {
            throw null;
        }
        return false;
    }
}
