package com.scanflow.datacapture.barinternal.boofcv.android;

import android.graphics.Bitmap;
import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplConvertBitmap {
    private static final int[] table5 = new int[256];
    private static final int[] table6 = new int[256];

    static {
        int i = 0;
        while (true) {
            int[] iArr = table5;
            if (i >= iArr.length) {
                return;
            }
            iArr[i] = (int) Math.round(((double) (i * 31)) / 255.0d);
            table6[i] = (int) Math.round(((double) (i * 63)) / 255.0d);
            i++;
        }
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.boofcv.android.ImplConvertBitmap$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$android$graphics$Bitmap$Config;

        static {
            int[] iArr = new int[Bitmap.Config.values().length];
            $SwitchMap$android$graphics$Bitmap$Config = iArr;
            try {
                iArr[Bitmap.Config.ARGB_8888.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$android$graphics$Bitmap$Config[Bitmap.Config.RGB_565.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$android$graphics$Bitmap$Config[Bitmap.Config.ALPHA_8.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$android$graphics$Bitmap$Config[Bitmap.Config.ARGB_4444.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
        }
    }

    public static void arrayToGray(byte[] bArr, Bitmap.Config config, GrayU8 grayU8) {
        int i = grayU8.height;
        int i2 = grayU8.width;
        int i3 = AnonymousClass1.$SwitchMap$android$graphics$Bitmap$Config[config.ordinal()];
        if (i3 == 1) {
            int i4 = 0;
            for (int i5 = 0; i5 < i; i5++) {
                int i6 = grayU8.startIndex + (grayU8.stride * i5);
                int i7 = i6 + i2;
                while (i6 < i7) {
                    grayU8.data[i6] = (byte) ((((bArr[i4] & UnsignedBytes.MAX_VALUE) + (bArr[i4 + 1] & UnsignedBytes.MAX_VALUE)) + (bArr[i4 + 2] & UnsignedBytes.MAX_VALUE)) / 3);
                    i4 += 4;
                    i6++;
                }
            }
            return;
        }
        if (i3 != 2) {
            if (i3 == 3) {
                throw new RuntimeException("ALPHA_8 seems to have some weired internal format and is not currently supported");
            }
            if (i3 == 4) {
                throw new RuntimeException("Isn't 4444 deprecated?");
            }
            throw new RuntimeException("Unsupported format: " + config);
        }
        int i8 = 0;
        for (int i9 = 0; i9 < i; i9++) {
            int i10 = grayU8.startIndex + (grayU8.stride * i9);
            int i11 = 0;
            while (i11 < i2) {
                int i12 = i8 + 1;
                int i13 = bArr[i8] & UnsignedBytes.MAX_VALUE;
                i8 += 2;
                int i14 = ((bArr[i12] & UnsignedBytes.MAX_VALUE) << 8) | i13;
                grayU8.data[i10] = (byte) ((((((i14 >> 11) * 256) / 32) + ((((i14 & 2016) >> 5) * 256) / 64)) + (((i14 & 31) * 256) / 32)) / 3);
                i11++;
                i10++;
            }
        }
    }
}
