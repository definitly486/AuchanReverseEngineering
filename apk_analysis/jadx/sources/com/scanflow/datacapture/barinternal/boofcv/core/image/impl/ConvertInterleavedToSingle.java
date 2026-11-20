package com.scanflow.datacapture.barinternal.boofcv.core.image.impl;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedU8;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvertInterleavedToSingle {
    public static void average(InterleavedU8 interleavedU8, GrayU8 grayU8) {
        int numBands = interleavedU8.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedU8.height; i++) {
                System.arraycopy(interleavedU8.data, interleavedU8.getIndex(0, i), grayU8.data, grayU8.getIndex(0, i), interleavedU8.width);
            }
            return;
        }
        if (numBands == 2) {
            for (int i2 = 0; i2 < interleavedU8.height; i2++) {
                int index = interleavedU8.getIndex(0, i2);
                int index2 = grayU8.getIndex(0, i2);
                int i3 = interleavedU8.width + index2;
                while (index2 < i3) {
                    byte[] bArr = interleavedU8.data;
                    int i4 = index + 1;
                    int i5 = bArr[index] & UnsignedBytes.MAX_VALUE;
                    index += 2;
                    grayU8.data[index2] = (byte) ((i5 + (bArr[i4] & UnsignedBytes.MAX_VALUE)) / 2);
                    index2++;
                }
            }
            return;
        }
        if (numBands == 3) {
            for (int i6 = 0; i6 < interleavedU8.height; i6++) {
                int index3 = interleavedU8.getIndex(0, i6);
                int index4 = grayU8.getIndex(0, i6);
                int i7 = interleavedU8.width + index4;
                while (index4 < i7) {
                    byte[] bArr2 = interleavedU8.data;
                    int i8 = index3 + 2;
                    int i9 = (bArr2[index3] & UnsignedBytes.MAX_VALUE) + (bArr2[index3 + 1] & UnsignedBytes.MAX_VALUE);
                    index3 += 3;
                    grayU8.data[index4] = (byte) ((i9 + (bArr2[i8] & UnsignedBytes.MAX_VALUE)) / 3);
                    index4++;
                }
            }
            return;
        }
        for (int i10 = 0; i10 < interleavedU8.height; i10++) {
            int index5 = interleavedU8.getIndex(0, i10);
            int index6 = grayU8.getIndex(0, i10);
            int i11 = 0;
            while (i11 < interleavedU8.width) {
                int i12 = index5 + numBands;
                int i13 = 0;
                while (index5 < i12) {
                    i13 += interleavedU8.data[index5] & UnsignedBytes.MAX_VALUE;
                    index5++;
                }
                grayU8.data[index6] = (byte) (i13 / numBands);
                i11++;
                index6++;
            }
        }
    }

    public static void average(InterleavedS8 interleavedS8, GrayS8 grayS8) {
        int numBands = interleavedS8.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedS8.height; i++) {
                System.arraycopy(interleavedS8.data, interleavedS8.getIndex(0, i), grayS8.data, grayS8.getIndex(0, i), interleavedS8.width);
            }
            return;
        }
        if (numBands == 2) {
            for (int i2 = 0; i2 < interleavedS8.height; i2++) {
                int index = interleavedS8.getIndex(0, i2);
                int index2 = grayS8.getIndex(0, i2);
                int i3 = interleavedS8.width + index2;
                while (index2 < i3) {
                    byte[] bArr = interleavedS8.data;
                    int i4 = index + 1;
                    byte b = bArr[index];
                    index += 2;
                    grayS8.data[index2] = (byte) ((b + bArr[i4]) / 2);
                    index2++;
                }
            }
            return;
        }
        if (numBands == 3) {
            for (int i5 = 0; i5 < interleavedS8.height; i5++) {
                int index3 = interleavedS8.getIndex(0, i5);
                int index4 = grayS8.getIndex(0, i5);
                int i6 = interleavedS8.width + index4;
                while (index4 < i6) {
                    byte[] bArr2 = interleavedS8.data;
                    int i7 = index3 + 2;
                    int i8 = bArr2[index3] + bArr2[index3 + 1];
                    index3 += 3;
                    grayS8.data[index4] = (byte) ((i8 + bArr2[i7]) / 3);
                    index4++;
                }
            }
            return;
        }
        for (int i9 = 0; i9 < interleavedS8.height; i9++) {
            int index5 = interleavedS8.getIndex(0, i9);
            int index6 = grayS8.getIndex(0, i9);
            int i10 = 0;
            while (i10 < interleavedS8.width) {
                int i11 = index5 + numBands;
                int i12 = 0;
                while (index5 < i11) {
                    i12 += interleavedS8.data[index5];
                    index5++;
                }
                grayS8.data[index6] = (byte) (i12 / numBands);
                i10++;
                index6++;
            }
        }
    }

    public static void average(InterleavedU16 interleavedU16, GrayU16 grayU16) {
        int numBands = interleavedU16.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedU16.height; i++) {
                System.arraycopy(interleavedU16.data, interleavedU16.getIndex(0, i), grayU16.data, grayU16.getIndex(0, i), interleavedU16.width);
            }
            return;
        }
        if (numBands == 2) {
            for (int i2 = 0; i2 < interleavedU16.height; i2++) {
                int index = interleavedU16.getIndex(0, i2);
                int index2 = grayU16.getIndex(0, i2);
                int i3 = interleavedU16.width + index2;
                while (index2 < i3) {
                    short[] sArr = interleavedU16.data;
                    int i4 = index + 1;
                    int i5 = sArr[index] & 65535;
                    index += 2;
                    grayU16.data[index2] = (short) ((i5 + (sArr[i4] & 65535)) / 2);
                    index2++;
                }
            }
            return;
        }
        if (numBands == 3) {
            for (int i6 = 0; i6 < interleavedU16.height; i6++) {
                int index3 = interleavedU16.getIndex(0, i6);
                int index4 = grayU16.getIndex(0, i6);
                int i7 = interleavedU16.width + index4;
                while (index4 < i7) {
                    short[] sArr2 = interleavedU16.data;
                    int i8 = index3 + 2;
                    int i9 = (sArr2[index3] & 65535) + (sArr2[index3 + 1] & 65535);
                    index3 += 3;
                    grayU16.data[index4] = (short) ((i9 + (sArr2[i8] & 65535)) / 3);
                    index4++;
                }
            }
            return;
        }
        for (int i10 = 0; i10 < interleavedU16.height; i10++) {
            int index5 = interleavedU16.getIndex(0, i10);
            int index6 = grayU16.getIndex(0, i10);
            int i11 = 0;
            while (i11 < interleavedU16.width) {
                int i12 = index5 + numBands;
                int i13 = 0;
                while (index5 < i12) {
                    i13 += interleavedU16.data[index5] & 65535;
                    index5++;
                }
                grayU16.data[index6] = (short) (i13 / numBands);
                i11++;
                index6++;
            }
        }
    }

    public static void average(InterleavedS16 interleavedS16, GrayS16 grayS16) {
        int numBands = interleavedS16.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedS16.height; i++) {
                System.arraycopy(interleavedS16.data, interleavedS16.getIndex(0, i), grayS16.data, grayS16.getIndex(0, i), interleavedS16.width);
            }
            return;
        }
        if (numBands == 2) {
            for (int i2 = 0; i2 < interleavedS16.height; i2++) {
                int index = interleavedS16.getIndex(0, i2);
                int index2 = grayS16.getIndex(0, i2);
                int i3 = interleavedS16.width + index2;
                while (index2 < i3) {
                    short[] sArr = interleavedS16.data;
                    int i4 = index + 1;
                    short s = sArr[index];
                    index += 2;
                    grayS16.data[index2] = (short) ((s + sArr[i4]) / 2);
                    index2++;
                }
            }
            return;
        }
        if (numBands == 3) {
            for (int i5 = 0; i5 < interleavedS16.height; i5++) {
                int index3 = interleavedS16.getIndex(0, i5);
                int index4 = grayS16.getIndex(0, i5);
                int i6 = interleavedS16.width + index4;
                while (index4 < i6) {
                    short[] sArr2 = interleavedS16.data;
                    int i7 = index3 + 2;
                    int i8 = sArr2[index3] + sArr2[index3 + 1];
                    index3 += 3;
                    grayS16.data[index4] = (short) ((i8 + sArr2[i7]) / 3);
                    index4++;
                }
            }
            return;
        }
        for (int i9 = 0; i9 < interleavedS16.height; i9++) {
            int index5 = interleavedS16.getIndex(0, i9);
            int index6 = grayS16.getIndex(0, i9);
            int i10 = 0;
            while (i10 < interleavedS16.width) {
                int i11 = index5 + numBands;
                int i12 = 0;
                while (index5 < i11) {
                    i12 += interleavedS16.data[index5];
                    index5++;
                }
                grayS16.data[index6] = (short) (i12 / numBands);
                i10++;
                index6++;
            }
        }
    }

    public static void average(InterleavedS32 interleavedS32, GrayS32 grayS32) {
        int numBands = interleavedS32.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedS32.height; i++) {
                System.arraycopy(interleavedS32.data, interleavedS32.getIndex(0, i), grayS32.data, grayS32.getIndex(0, i), interleavedS32.width);
            }
            return;
        }
        if (numBands == 2) {
            for (int i2 = 0; i2 < interleavedS32.height; i2++) {
                int index = interleavedS32.getIndex(0, i2);
                int index2 = grayS32.getIndex(0, i2);
                int i3 = interleavedS32.width + index2;
                while (index2 < i3) {
                    int[] iArr = interleavedS32.data;
                    int i4 = index + 1;
                    int i5 = iArr[index];
                    index += 2;
                    grayS32.data[index2] = (i5 + iArr[i4]) / 2;
                    index2++;
                }
            }
            return;
        }
        if (numBands == 3) {
            for (int i6 = 0; i6 < interleavedS32.height; i6++) {
                int index3 = interleavedS32.getIndex(0, i6);
                int index4 = grayS32.getIndex(0, i6);
                int i7 = interleavedS32.width + index4;
                while (index4 < i7) {
                    int[] iArr2 = interleavedS32.data;
                    int i8 = index3 + 2;
                    int i9 = iArr2[index3] + iArr2[index3 + 1];
                    index3 += 3;
                    grayS32.data[index4] = (i9 + iArr2[i8]) / 3;
                    index4++;
                }
            }
            return;
        }
        for (int i10 = 0; i10 < interleavedS32.height; i10++) {
            int index5 = interleavedS32.getIndex(0, i10);
            int index6 = grayS32.getIndex(0, i10);
            int i11 = 0;
            while (i11 < interleavedS32.width) {
                int i12 = index5 + numBands;
                int i13 = 0;
                while (index5 < i12) {
                    i13 += interleavedS32.data[index5];
                    index5++;
                }
                grayS32.data[index6] = i13 / numBands;
                i11++;
                index6++;
            }
        }
    }

    public static void average(InterleavedS64 interleavedS64, GrayS64 grayS64) {
        int numBands = interleavedS64.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedS64.height; i++) {
                System.arraycopy(interleavedS64.data, interleavedS64.getIndex(0, i), grayS64.data, grayS64.getIndex(0, i), interleavedS64.width);
            }
            return;
        }
        if (numBands == 2) {
            for (int i2 = 0; i2 < interleavedS64.height; i2++) {
                int index = interleavedS64.getIndex(0, i2);
                int index2 = grayS64.getIndex(0, i2);
                int i3 = interleavedS64.width + index2;
                while (index2 < i3) {
                    long[] jArr = interleavedS64.data;
                    int i4 = index + 1;
                    long j = jArr[index];
                    index += 2;
                    grayS64.data[index2] = (j + jArr[i4]) / 2;
                    index2++;
                }
            }
            return;
        }
        if (numBands == 3) {
            for (int i5 = 0; i5 < interleavedS64.height; i5++) {
                int index3 = interleavedS64.getIndex(0, i5);
                int index4 = grayS64.getIndex(0, i5);
                int i6 = interleavedS64.width + index4;
                while (index4 < i6) {
                    long[] jArr2 = interleavedS64.data;
                    int i7 = index3 + 2;
                    long j2 = jArr2[index3] + jArr2[index3 + 1];
                    index3 += 3;
                    grayS64.data[index4] = (j2 + jArr2[i7]) / 3;
                    index4++;
                }
            }
            return;
        }
        for (int i8 = 0; i8 < interleavedS64.height; i8++) {
            int index5 = interleavedS64.getIndex(0, i8);
            int index6 = grayS64.getIndex(0, i8);
            int i9 = 0;
            while (i9 < interleavedS64.width) {
                int i10 = index5 + numBands;
                long j3 = 0;
                while (index5 < i10) {
                    j3 += interleavedS64.data[index5];
                    index5++;
                }
                grayS64.data[index6] = j3 / ((long) numBands);
                i9++;
                index6++;
            }
        }
    }

    public static void average(InterleavedF32 interleavedF32, GrayF32 grayF32) {
        int numBands = interleavedF32.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedF32.height; i++) {
                System.arraycopy(interleavedF32.data, interleavedF32.getIndex(0, i), grayF32.data, grayF32.getIndex(0, i), interleavedF32.width);
            }
            return;
        }
        if (numBands == 2) {
            for (int i2 = 0; i2 < interleavedF32.height; i2++) {
                int index = interleavedF32.getIndex(0, i2);
                int index2 = grayF32.getIndex(0, i2);
                int i3 = interleavedF32.width + index2;
                while (index2 < i3) {
                    float[] fArr = interleavedF32.data;
                    int i4 = index + 1;
                    float f = fArr[index];
                    index += 2;
                    grayF32.data[index2] = (f + fArr[i4]) / 2.0f;
                    index2++;
                }
            }
            return;
        }
        if (numBands == 3) {
            for (int i5 = 0; i5 < interleavedF32.height; i5++) {
                int index3 = interleavedF32.getIndex(0, i5);
                int index4 = grayF32.getIndex(0, i5);
                int i6 = interleavedF32.width + index4;
                while (index4 < i6) {
                    float[] fArr2 = interleavedF32.data;
                    int i7 = index3 + 2;
                    float f2 = fArr2[index3] + fArr2[index3 + 1];
                    index3 += 3;
                    grayF32.data[index4] = (f2 + fArr2[i7]) / 3.0f;
                    index4++;
                }
            }
            return;
        }
        for (int i8 = 0; i8 < interleavedF32.height; i8++) {
            int index5 = interleavedF32.getIndex(0, i8);
            int index6 = grayF32.getIndex(0, i8);
            int i9 = 0;
            while (i9 < interleavedF32.width) {
                int i10 = index5 + numBands;
                float f3 = 0.0f;
                while (index5 < i10) {
                    f3 += interleavedF32.data[index5];
                    index5++;
                }
                grayF32.data[index6] = f3 / numBands;
                i9++;
                index6++;
            }
        }
    }

    public static void average(InterleavedF64 interleavedF64, GrayF64 grayF64) {
        int numBands = interleavedF64.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedF64.height; i++) {
                System.arraycopy(interleavedF64.data, interleavedF64.getIndex(0, i), grayF64.data, grayF64.getIndex(0, i), interleavedF64.width);
            }
            return;
        }
        if (numBands == 2) {
            for (int i2 = 0; i2 < interleavedF64.height; i2++) {
                int index = interleavedF64.getIndex(0, i2);
                int index2 = grayF64.getIndex(0, i2);
                int i3 = interleavedF64.width + index2;
                while (index2 < i3) {
                    double[] dArr = interleavedF64.data;
                    int i4 = index + 1;
                    double d = dArr[index];
                    index += 2;
                    grayF64.data[index2] = (d + dArr[i4]) / 2.0d;
                    index2++;
                }
            }
            return;
        }
        if (numBands == 3) {
            for (int i5 = 0; i5 < interleavedF64.height; i5++) {
                int index3 = interleavedF64.getIndex(0, i5);
                int index4 = grayF64.getIndex(0, i5);
                int i6 = interleavedF64.width + index4;
                while (index4 < i6) {
                    double[] dArr2 = interleavedF64.data;
                    int i7 = index3 + 2;
                    double d2 = dArr2[index3] + dArr2[index3 + 1];
                    index3 += 3;
                    grayF64.data[index4] = (d2 + dArr2[i7]) / 3.0d;
                    index4++;
                }
            }
            return;
        }
        for (int i8 = 0; i8 < interleavedF64.height; i8++) {
            int index5 = interleavedF64.getIndex(0, i8);
            int index6 = grayF64.getIndex(0, i8);
            int i9 = 0;
            while (i9 < interleavedF64.width) {
                int i10 = index5 + numBands;
                double d3 = 0.0d;
                while (index5 < i10) {
                    d3 += interleavedF64.data[index5];
                    index5++;
                }
                grayF64.data[index6] = d3 / ((double) numBands);
                i9++;
                index6++;
            }
        }
    }
}
