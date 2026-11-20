package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.normalized;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveNormalized_JustBorder_SB {
    public static void horizontal(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        GrayF32 grayF34 = grayF32;
        float[] fArr = grayF34.data;
        float[] fArr2 = grayF33.data;
        float[] fArr3 = kernel1D_F32.data;
        int width = kernel1D_F32.getWidth();
        int offset = kernel1D_F32.getOffset();
        int i = width - offset;
        int i2 = i - 1;
        int width2 = grayF34.getWidth();
        int height = grayF34.getHeight();
        int i3 = 0;
        while (i3 < height) {
            int i4 = grayF33.startIndex + (grayF33.stride * i3);
            int i5 = grayF34.startIndex + (grayF34.stride * i3);
            int i6 = i5 + offset;
            int i7 = i5;
            while (true) {
                float f = 0.0f;
                if (i7 >= i6) {
                    break;
                }
                int i8 = i5;
                int i9 = width - ((i + i7) - i5);
                float f2 = 0.0f;
                while (i9 < width) {
                    float f3 = fArr3[i9];
                    f2 += f3;
                    f += fArr[i8] * f3;
                    i9++;
                    i8++;
                }
                fArr2[i4] = f / f2;
                i7++;
                i4++;
            }
            int i10 = width2 - (offset + i2);
            int i11 = i7 + i10;
            int i12 = i4 + i10;
            int i13 = i5 + width2;
            while (i11 < i13) {
                int i14 = i11 - offset;
                int i15 = i13 - i14;
                int i16 = i14;
                float f4 = 0.0f;
                float f5 = 0.0f;
                int i17 = 0;
                while (i17 < i15) {
                    float f6 = fArr3[i17];
                    f5 += f6;
                    f4 += fArr[i16] * f6;
                    i17++;
                    i16++;
                }
                fArr2[i12] = f4 / f5;
                i11++;
                i12++;
            }
            i3++;
            grayF34 = grayF32;
        }
    }

    public static void vertical(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        GrayF32 grayF34 = grayF33;
        float[] fArr = grayF32.data;
        float[] fArr2 = grayF34.data;
        float[] fArr3 = kernel1D_F32.data;
        int width = kernel1D_F32.getWidth();
        int offset = kernel1D_F32.getOffset();
        int width2 = grayF34.getWidth();
        int height = grayF34.getHeight();
        int i = height - ((width - offset) - 1);
        for (int i2 = 0; i2 < offset; i2++) {
            int i3 = grayF34.startIndex + (grayF34.stride * i2);
            int i4 = grayF32.startIndex + (grayF32.stride * i2);
            int i5 = i4 + width2;
            int i6 = offset - i2;
            float f = 0.0f;
            for (int i7 = i6; i7 < width; i7++) {
                f += fArr3[i7];
            }
            while (i4 < i5) {
                int i8 = i4 - (grayF32.stride * i2);
                int i9 = i6;
                float f2 = 0.0f;
                while (i9 < width) {
                    f2 += fArr[i8] * fArr3[i9];
                    i9++;
                    i8 += grayF32.stride;
                    fArr = fArr;
                }
                fArr2[i3] = f2 / f;
                i4++;
                i3++;
                fArr = fArr;
            }
        }
        float[] fArr4 = fArr;
        while (i < height) {
            int i10 = grayF34.startIndex + (grayF34.stride * i);
            int i11 = grayF32.startIndex + (grayF32.stride * i);
            int i12 = i11 + width2;
            int i13 = height - (i - offset);
            float f3 = 0.0f;
            for (int i14 = 0; i14 < i13; i14++) {
                f3 += fArr3[i14];
            }
            while (i11 < i12) {
                int i15 = i11 - (grayF32.stride * offset);
                int i16 = 0;
                float f4 = 0.0f;
                while (i16 < i13) {
                    f4 += fArr4[i15] * fArr3[i16];
                    i16++;
                    i15 += grayF32.stride;
                }
                fArr2[i10] = f4 / f3;
                i11++;
                i10++;
            }
            i++;
            grayF34 = grayF33;
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8) {
        GrayU8 grayU9 = grayU8;
        byte[] bArr = grayU9.data;
        byte[] bArr2 = grayI8.data;
        int[] iArr = kernel1D_S32.data;
        int width = kernel1D_S32.getWidth();
        int offset = kernel1D_S32.getOffset();
        int i = width - offset;
        int i2 = i - 1;
        int width2 = grayU9.getWidth();
        int height = grayU9.getHeight();
        int i3 = 0;
        while (i3 < height) {
            int i4 = grayI8.startIndex + (grayI8.stride * i3);
            int i5 = grayU9.startIndex + (grayU9.stride * i3);
            int i6 = i5 + offset;
            int i7 = i5;
            while (i7 < i6) {
                int i8 = i5;
                int i9 = width - ((i + i7) - i5);
                int i10 = 0;
                int i11 = 0;
                while (i9 < width) {
                    int i12 = iArr[i9];
                    i11 += i12;
                    i10 += (bArr[i8] & UnsignedBytes.MAX_VALUE) * i12;
                    i9++;
                    i8++;
                }
                bArr2[i4] = (byte) ((i10 + (i11 / 2)) / i11);
                i7++;
                i4++;
            }
            int i13 = width2 - (offset + i2);
            int i14 = i7 + i13;
            int i15 = i4 + i13;
            int i16 = i5 + width2;
            while (i14 < i16) {
                int i17 = i14 - offset;
                int i18 = i16 - i17;
                int i19 = i17;
                int i20 = 0;
                int i21 = 0;
                int i22 = 0;
                while (i20 < i18) {
                    int i23 = iArr[i20];
                    i22 += i23;
                    i21 += (bArr[i19] & UnsignedBytes.MAX_VALUE) * i23;
                    i20++;
                    i19++;
                }
                bArr2[i15] = (byte) ((i21 + (i22 / 2)) / i22);
                i14++;
                i15++;
            }
            i3++;
            grayU9 = grayU8;
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8) {
        GrayI8 grayI9 = grayI8;
        byte[] bArr = grayU8.data;
        byte[] bArr2 = grayI9.data;
        int[] iArr = kernel1D_S32.data;
        int width = kernel1D_S32.getWidth();
        int offset = kernel1D_S32.getOffset();
        int width2 = grayI9.getWidth();
        int height = grayI9.getHeight();
        int i = height - ((width - offset) - 1);
        for (int i2 = 0; i2 < offset; i2++) {
            int i3 = grayI9.startIndex + (grayI9.stride * i2);
            int i4 = grayU8.startIndex + (grayU8.stride * i2);
            int i5 = i4 + width2;
            int i6 = offset - i2;
            int i7 = 0;
            for (int i8 = i6; i8 < width; i8++) {
                i7 += iArr[i8];
            }
            while (i4 < i5) {
                int i9 = i4 - (grayU8.stride * i2);
                byte[] bArr3 = bArr;
                int i10 = i6;
                int i11 = 0;
                while (i10 < width) {
                    int i12 = i10;
                    i11 += (bArr3[i9] & UnsignedBytes.MAX_VALUE) * iArr[i12];
                    i9 += grayU8.stride;
                    i10 = i12 + 1;
                }
                bArr2[i3] = (byte) ((i11 + (i7 / 2)) / i7);
                i4++;
                i3++;
                bArr = bArr3;
            }
        }
        byte[] bArr4 = bArr;
        while (i < height) {
            int i13 = grayI9.startIndex + (grayI9.stride * i);
            int i14 = grayU8.startIndex + (grayU8.stride * i);
            int i15 = i14 + width2;
            int i16 = height - (i - offset);
            int i17 = 0;
            for (int i18 = 0; i18 < i16; i18++) {
                i17 += iArr[i18];
            }
            while (i14 < i15) {
                int i19 = i14 - (grayU8.stride * offset);
                int i20 = 0;
                int i21 = 0;
                while (i20 < i16) {
                    i21 += (bArr4[i19] & UnsignedBytes.MAX_VALUE) * iArr[i20];
                    i20++;
                    i19 += grayU8.stride;
                }
                bArr2[i13] = (byte) ((i21 + (i17 / 2)) / i17);
                i14++;
                i13++;
            }
            i++;
            grayI9 = grayI8;
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16) {
        GrayU16 grayU17 = grayU16;
        short[] sArr = grayU17.data;
        short[] sArr2 = grayI16.data;
        int[] iArr = kernel1D_S32.data;
        int width = kernel1D_S32.getWidth();
        int offset = kernel1D_S32.getOffset();
        int i = width - offset;
        int i2 = i - 1;
        int width2 = grayU17.getWidth();
        int height = grayU17.getHeight();
        int i3 = 0;
        while (i3 < height) {
            int i4 = grayI16.startIndex + (grayI16.stride * i3);
            int i5 = grayU17.startIndex + (grayU17.stride * i3);
            int i6 = i5 + offset;
            int i7 = i5;
            while (i7 < i6) {
                int i8 = i5;
                int i9 = width - ((i + i7) - i5);
                int i10 = 0;
                int i11 = 0;
                while (i9 < width) {
                    int i12 = iArr[i9];
                    i11 += i12;
                    i10 += (sArr[i8] & 65535) * i12;
                    i9++;
                    i8++;
                }
                sArr2[i4] = (short) ((i10 + (i11 / 2)) / i11);
                i7++;
                i4++;
            }
            int i13 = width2 - (offset + i2);
            int i14 = i7 + i13;
            int i15 = i4 + i13;
            int i16 = i5 + width2;
            while (i14 < i16) {
                int i17 = i14 - offset;
                int i18 = i16 - i17;
                int i19 = i17;
                int i20 = 0;
                int i21 = 0;
                int i22 = 0;
                while (i20 < i18) {
                    int i23 = iArr[i20];
                    i22 += i23;
                    i21 += (sArr[i19] & 65535) * i23;
                    i20++;
                    i19++;
                }
                sArr2[i15] = (short) ((i21 + (i22 / 2)) / i22);
                i14++;
                i15++;
            }
            i3++;
            grayU17 = grayU16;
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16) {
        GrayI16 grayI17 = grayI16;
        short[] sArr = grayU16.data;
        short[] sArr2 = grayI17.data;
        int[] iArr = kernel1D_S32.data;
        int width = kernel1D_S32.getWidth();
        int offset = kernel1D_S32.getOffset();
        int width2 = grayI17.getWidth();
        int height = grayI17.getHeight();
        int i = height - ((width - offset) - 1);
        for (int i2 = 0; i2 < offset; i2++) {
            int i3 = grayI17.startIndex + (grayI17.stride * i2);
            int i4 = grayU16.startIndex + (grayU16.stride * i2);
            int i5 = i4 + width2;
            int i6 = offset - i2;
            int i7 = 0;
            for (int i8 = i6; i8 < width; i8++) {
                i7 += iArr[i8];
            }
            while (i4 < i5) {
                int i9 = i4 - (grayU16.stride * i2);
                int i10 = i6;
                int i11 = 0;
                while (i10 < width) {
                    i11 += (sArr[i9] & 65535) * iArr[i10];
                    i10++;
                    i9 += grayU16.stride;
                    sArr = sArr;
                }
                sArr2[i3] = (short) ((i11 + (i7 / 2)) / i7);
                i4++;
                i3++;
                sArr = sArr;
            }
        }
        short[] sArr3 = sArr;
        while (i < height) {
            int i12 = grayI17.startIndex + (grayI17.stride * i);
            int i13 = grayU16.startIndex + (grayU16.stride * i);
            int i14 = i13 + width2;
            int i15 = height - (i - offset);
            int i16 = 0;
            for (int i17 = 0; i17 < i15; i17++) {
                i16 += iArr[i17];
            }
            while (i13 < i14) {
                int i18 = i13 - (grayU16.stride * offset);
                int i19 = 0;
                int i20 = 0;
                while (i19 < i15) {
                    i20 += (sArr3[i18] & 65535) * iArr[i19];
                    i19++;
                    i18 += grayU16.stride;
                }
                sArr2[i12] = (short) ((i20 + (i16 / 2)) / i16);
                i13++;
                i12++;
            }
            i++;
            grayI17 = grayI16;
        }
    }
}
