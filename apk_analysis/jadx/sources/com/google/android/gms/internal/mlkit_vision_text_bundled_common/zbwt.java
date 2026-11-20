package com.google.android.gms.internal.mlkit_vision_text_bundled_common;

import org.tensorflow.lite.schema.BuiltinOptions;

/* JADX INFO: compiled from: com.google.mlkit:text-recognition-bundled-common@@17.0.0 */
/* JADX INFO: loaded from: classes2.dex */
final class zbwt {
    static /* bridge */ /* synthetic */ void zba(byte b, byte b2, byte b3, byte b4, char[] cArr, int i) throws zbuq {
        if (zbe(b2) || (((b << 28) + (b2 + BuiltinOptions.ReadVariableOptions)) >> 30) != 0 || zbe(b3) || zbe(b4)) {
            throw new zbuq("Protocol message had invalid UTF-8.");
        }
        int i2 = ((b & 7) << 18) | ((b2 & BuiltinOptions.LogicalNotOptions) << 12) | ((b3 & BuiltinOptions.LogicalNotOptions) << 6) | (b4 & BuiltinOptions.LogicalNotOptions);
        cArr[i] = (char) ((i2 >>> 10) + 55232);
        cArr[i + 1] = (char) ((i2 & 1023) + 56320);
    }

    static /* bridge */ /* synthetic */ void zbc(byte b, byte b2, char[] cArr, int i) throws zbuq {
        if (b < -62 || zbe(b2)) {
            throw new zbuq("Protocol message had invalid UTF-8.");
        }
        cArr[i] = (char) (((b & 31) << 6) | (b2 & BuiltinOptions.LogicalNotOptions));
    }

    static /* bridge */ /* synthetic */ boolean zbd(byte b) {
        return b >= 0;
    }

    private static boolean zbe(byte b) {
        return b > -65;
    }

    /* JADX WARN: Code duplicated, block: B:10:0x0013 A[DONT_INVERT] */
    /* JADX WARN: Code duplicated, block: B:11:0x0015  */
    /* JADX WARN: Code duplicated, block: B:12:0x0016 A[PHI: r2
      0x0016: PHI (r2v3 byte) = (r2v2 byte), (r2v9 byte) binds: [B:9:0x0011, B:11:0x0015] A[DONT_GENERATE, DONT_INLINE]] */
    /* JADX WARN: Code duplicated, block: B:14:0x001c  */
    static /* bridge */ /* synthetic */ void zbb(byte b, byte b2, byte b3, char[] cArr, int i) throws zbuq {
        if (!zbe(b2)) {
            if (b != -32) {
                if (b != -19) {
                    if (!zbe(b3)) {
                        cArr[i] = (char) (((b & 15) << 12) | ((b2 & BuiltinOptions.LogicalNotOptions) << 6) | (b3 & BuiltinOptions.LogicalNotOptions));
                        return;
                    }
                } else if (b2 < -96) {
                    b = -19;
                    if (!zbe(b3)) {
                        cArr[i] = (char) (((b & 15) << 12) | ((b2 & BuiltinOptions.LogicalNotOptions) << 6) | (b3 & BuiltinOptions.LogicalNotOptions));
                        return;
                    }
                }
            } else if (b2 >= -96) {
                b = -32;
                if (b != -19) {
                    if (!zbe(b3)) {
                        cArr[i] = (char) (((b & 15) << 12) | ((b2 & BuiltinOptions.LogicalNotOptions) << 6) | (b3 & BuiltinOptions.LogicalNotOptions));
                        return;
                    }
                } else if (b2 < -96) {
                    b = -19;
                    if (!zbe(b3)) {
                        cArr[i] = (char) (((b & 15) << 12) | ((b2 & BuiltinOptions.LogicalNotOptions) << 6) | (b3 & BuiltinOptions.LogicalNotOptions));
                        return;
                    }
                }
            }
        }
        throw new zbuq("Protocol message had invalid UTF-8.");
    }
}
