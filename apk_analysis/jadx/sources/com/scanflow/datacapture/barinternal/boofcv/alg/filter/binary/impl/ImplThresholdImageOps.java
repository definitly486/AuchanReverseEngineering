package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.blur.BlurImageOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplThresholdImageOps {
    public static GrayU8 threshold(GrayF32 grayF32, GrayU8 grayU8, float f, boolean z) {
        if (z) {
            for (int i = 0; i < grayF32.height; i++) {
                int i2 = grayF32.startIndex + (grayF32.stride * i);
                int i3 = grayU8.startIndex + (grayU8.stride * i);
                int i4 = grayF32.width;
                while (i4 > 0) {
                    int i5 = i3 + 1;
                    int i6 = i2 + 1;
                    grayU8.data[i3] = (byte) (grayF32.data[i2] <= f ? 1 : 0);
                    i4--;
                    i3 = i5;
                    i2 = i6;
                }
            }
        } else {
            for (int i7 = 0; i7 < grayF32.height; i7++) {
                int i8 = grayF32.startIndex + (grayF32.stride * i7);
                int i9 = grayU8.startIndex + (grayU8.stride * i7);
                int i10 = grayF32.width;
                while (i10 > 0) {
                    int i11 = i9 + 1;
                    int i12 = i8 + 1;
                    grayU8.data[i9] = (byte) (grayF32.data[i8] > f ? 1 : 0);
                    i10--;
                    i9 = i11;
                    i8 = i12;
                }
            }
        }
        return grayU8;
    }

    public static GrayU8 threshold(GrayF64 grayF64, GrayU8 grayU8, double d, boolean z) {
        if (z) {
            for (int i = 0; i < grayF64.height; i++) {
                int i2 = grayF64.startIndex + (grayF64.stride * i);
                int i3 = grayU8.startIndex + (grayU8.stride * i);
                int i4 = grayF64.width;
                while (i4 > 0) {
                    int i5 = i3 + 1;
                    int i6 = i2 + 1;
                    grayU8.data[i3] = (byte) (grayF64.data[i2] <= d ? 1 : 0);
                    i4--;
                    i3 = i5;
                    i2 = i6;
                }
            }
        } else {
            for (int i7 = 0; i7 < grayF64.height; i7++) {
                int i8 = grayF64.startIndex + (grayF64.stride * i7);
                int i9 = grayU8.startIndex + (grayU8.stride * i7);
                int i10 = grayF64.width;
                while (i10 > 0) {
                    int i11 = i9 + 1;
                    int i12 = i8 + 1;
                    grayU8.data[i9] = (byte) (grayF64.data[i8] > d ? 1 : 0);
                    i10--;
                    i9 = i11;
                    i8 = i12;
                }
            }
        }
        return grayU8;
    }

    public static GrayU8 threshold(GrayU8 grayU8, GrayU8 grayU9, int i, boolean z) {
        if (z) {
            for (int i2 = 0; i2 < grayU8.height; i2++) {
                int i3 = grayU8.startIndex + (grayU8.stride * i2);
                int i4 = grayU9.startIndex + (grayU9.stride * i2);
                int i5 = grayU8.width;
                while (i5 > 0) {
                    int i6 = i4 + 1;
                    int i7 = i3 + 1;
                    grayU9.data[i4] = (byte) ((grayU8.data[i3] & UnsignedBytes.MAX_VALUE) <= i ? 1 : 0);
                    i5--;
                    i4 = i6;
                    i3 = i7;
                }
            }
        } else {
            for (int i8 = 0; i8 < grayU8.height; i8++) {
                int i9 = grayU8.startIndex + (grayU8.stride * i8);
                int i10 = grayU9.startIndex + (grayU9.stride * i8);
                int i11 = grayU8.width;
                while (i11 > 0) {
                    int i12 = i10 + 1;
                    int i13 = i9 + 1;
                    grayU9.data[i10] = (byte) ((grayU8.data[i9] & UnsignedBytes.MAX_VALUE) > i ? 1 : 0);
                    i11--;
                    i10 = i12;
                    i9 = i13;
                }
            }
        }
        return grayU9;
    }

    public static GrayU8 threshold(GrayS16 grayS16, GrayU8 grayU8, int i, boolean z) {
        if (z) {
            for (int i2 = 0; i2 < grayS16.height; i2++) {
                int i3 = grayS16.startIndex + (grayS16.stride * i2);
                int i4 = grayU8.startIndex + (grayU8.stride * i2);
                int i5 = grayS16.width;
                while (i5 > 0) {
                    int i6 = i4 + 1;
                    int i7 = i3 + 1;
                    grayU8.data[i4] = (byte) (grayS16.data[i3] <= i ? 1 : 0);
                    i5--;
                    i4 = i6;
                    i3 = i7;
                }
            }
        } else {
            for (int i8 = 0; i8 < grayS16.height; i8++) {
                int i9 = grayS16.startIndex + (grayS16.stride * i8);
                int i10 = grayU8.startIndex + (grayU8.stride * i8);
                int i11 = grayS16.width;
                while (i11 > 0) {
                    int i12 = i10 + 1;
                    int i13 = i9 + 1;
                    grayU8.data[i10] = (byte) (grayS16.data[i9] > i ? 1 : 0);
                    i11--;
                    i10 = i12;
                    i9 = i13;
                }
            }
        }
        return grayU8;
    }

    public static GrayU8 threshold(GrayU16 grayU16, GrayU8 grayU8, int i, boolean z) {
        if (z) {
            for (int i2 = 0; i2 < grayU16.height; i2++) {
                int i3 = grayU16.startIndex + (grayU16.stride * i2);
                int i4 = grayU8.startIndex + (grayU8.stride * i2);
                int i5 = grayU16.width;
                while (i5 > 0) {
                    int i6 = i4 + 1;
                    int i7 = i3 + 1;
                    grayU8.data[i4] = (byte) ((grayU16.data[i3] & 65535) <= i ? 1 : 0);
                    i5--;
                    i4 = i6;
                    i3 = i7;
                }
            }
        } else {
            for (int i8 = 0; i8 < grayU16.height; i8++) {
                int i9 = grayU16.startIndex + (grayU16.stride * i8);
                int i10 = grayU8.startIndex + (grayU8.stride * i8);
                int i11 = grayU16.width;
                while (i11 > 0) {
                    int i12 = i10 + 1;
                    int i13 = i9 + 1;
                    grayU8.data[i10] = (byte) ((grayU16.data[i9] & 65535) > i ? 1 : 0);
                    i11--;
                    i10 = i12;
                    i9 = i13;
                }
            }
        }
        return grayU8;
    }

    public static GrayU8 threshold(GrayS32 grayS32, GrayU8 grayU8, int i, boolean z) {
        if (z) {
            for (int i2 = 0; i2 < grayS32.height; i2++) {
                int i3 = grayS32.startIndex + (grayS32.stride * i2);
                int i4 = grayU8.startIndex + (grayU8.stride * i2);
                int i5 = grayS32.width;
                while (i5 > 0) {
                    int i6 = i4 + 1;
                    int i7 = i3 + 1;
                    grayU8.data[i4] = (byte) (grayS32.data[i3] <= i ? 1 : 0);
                    i5--;
                    i4 = i6;
                    i3 = i7;
                }
            }
        } else {
            for (int i8 = 0; i8 < grayS32.height; i8++) {
                int i9 = grayS32.startIndex + (grayS32.stride * i8);
                int i10 = grayU8.startIndex + (grayU8.stride * i8);
                int i11 = grayS32.width;
                while (i11 > 0) {
                    int i12 = i10 + 1;
                    int i13 = i9 + 1;
                    grayU8.data[i10] = (byte) (grayS32.data[i9] > i ? 1 : 0);
                    i11--;
                    i10 = i12;
                    i9 = i13;
                }
            }
        }
        return grayU8;
    }

    public static GrayU8 localMean(GrayU8 grayU8, GrayU8 grayU9, ConfigLength configLength, float f, boolean z, GrayU8 grayU10, GrayU8 grayU11, GrowArray growArray) {
        BlurImageOps.mean(grayU8, grayU10, configLength.computeI(Math.min(grayU8.width, grayU8.height)) / 2, grayU11, growArray);
        if (z) {
            for (int i = 0; i < grayU8.height; i++) {
                int i2 = grayU8.startIndex + (grayU8.stride * i);
                int i3 = grayU9.startIndex + (grayU9.stride * i);
                int i4 = grayU10.startIndex + (grayU10.stride * i);
                int i5 = grayU8.width + i2;
                while (i2 < i5) {
                    int i6 = i4 + 1;
                    int i7 = i3 + 1;
                    int i8 = i2 + 1;
                    grayU9.data[i3] = ((float) (grayU8.data[i2] & UnsignedBytes.MAX_VALUE)) <= ((float) (grayU10.data[i4] & UnsignedBytes.MAX_VALUE)) * f ? (byte) 1 : (byte) 0;
                    i4 = i6;
                    i3 = i7;
                    i2 = i8;
                }
            }
        } else {
            for (int i9 = 0; i9 < grayU8.height; i9++) {
                int i10 = grayU8.startIndex + (grayU8.stride * i9);
                int i11 = grayU9.startIndex + (grayU9.stride * i9);
                int i12 = grayU10.startIndex + (grayU10.stride * i9);
                int i13 = grayU8.width + i10;
                while (i10 < i13) {
                    int i14 = i12 + 1;
                    int i15 = i11 + 1;
                    int i16 = i10 + 1;
                    grayU9.data[i11] = ((float) (grayU8.data[i10] & UnsignedBytes.MAX_VALUE)) * f > ((float) (grayU10.data[i12] & UnsignedBytes.MAX_VALUE)) ? (byte) 1 : (byte) 0;
                    i12 = i14;
                    i11 = i15;
                    i10 = i16;
                }
            }
        }
        return grayU9;
    }

    public static GrayU8 localGaussian(GrayU8 grayU8, GrayU8 grayU9, ConfigLength configLength, float f, boolean z, GrayU8 grayU10, GrayU8 grayU11) {
        BlurImageOps.gaussian(grayU8, grayU10, -1.0d, configLength.computeI(Math.min(grayU8.width, grayU8.height)) / 2, grayU11);
        if (z) {
            for (int i = 0; i < grayU8.height; i++) {
                int i2 = grayU8.startIndex + (grayU8.stride * i);
                int i3 = grayU9.startIndex + (grayU9.stride * i);
                int i4 = grayU10.startIndex + (grayU10.stride * i);
                int i5 = grayU8.width + i2;
                while (i2 < i5) {
                    if ((grayU8.data[i2] & UnsignedBytes.MAX_VALUE) <= (grayU10.data[i4] & UnsignedBytes.MAX_VALUE) * f) {
                        grayU9.data[i3] = 1;
                    } else {
                        grayU9.data[i3] = 0;
                    }
                    i2++;
                    i3++;
                    i4++;
                }
            }
        } else {
            for (int i6 = 0; i6 < grayU8.height; i6++) {
                int i7 = grayU8.startIndex + (grayU8.stride * i6);
                int i8 = grayU9.startIndex + (grayU9.stride * i6);
                int i9 = grayU10.startIndex + (grayU10.stride * i6);
                int i10 = grayU8.width + i7;
                while (i7 < i10) {
                    if ((grayU8.data[i7] & UnsignedBytes.MAX_VALUE) * f > (grayU10.data[i9] & UnsignedBytes.MAX_VALUE)) {
                        grayU9.data[i8] = 1;
                    } else {
                        grayU9.data[i8] = 0;
                    }
                    i7++;
                    i8++;
                    i9++;
                }
            }
        }
        return grayU9;
    }

    public static GrayU8 localMean(GrayU16 grayU16, GrayU8 grayU8, ConfigLength configLength, float f, boolean z, GrayU16 grayU17, GrayU16 grayU18, GrowArray growArray) {
        BlurImageOps.mean(grayU16, grayU17, configLength.computeI(Math.min(grayU16.width, grayU16.height)) / 2, grayU18, growArray);
        if (z) {
            for (int i = 0; i < grayU16.height; i++) {
                int i2 = grayU16.startIndex + (grayU16.stride * i);
                int i3 = grayU8.startIndex + (grayU8.stride * i);
                int i4 = grayU17.startIndex + (grayU17.stride * i);
                int i5 = grayU16.width + i2;
                while (i2 < i5) {
                    int i6 = i4 + 1;
                    int i7 = i3 + 1;
                    int i8 = i2 + 1;
                    grayU8.data[i3] = ((float) (grayU16.data[i2] & 65535)) <= ((float) (grayU17.data[i4] & 65535)) * f ? (byte) 1 : (byte) 0;
                    i4 = i6;
                    i3 = i7;
                    i2 = i8;
                }
            }
        } else {
            for (int i9 = 0; i9 < grayU16.height; i9++) {
                int i10 = grayU16.startIndex + (grayU16.stride * i9);
                int i11 = grayU8.startIndex + (grayU8.stride * i9);
                int i12 = grayU17.startIndex + (grayU17.stride * i9);
                int i13 = grayU16.width + i10;
                while (i10 < i13) {
                    int i14 = i12 + 1;
                    int i15 = i11 + 1;
                    int i16 = i10 + 1;
                    grayU8.data[i11] = ((float) (grayU16.data[i10] & 65535)) * f > ((float) (grayU17.data[i12] & 65535)) ? (byte) 1 : (byte) 0;
                    i12 = i14;
                    i11 = i15;
                    i10 = i16;
                }
            }
        }
        return grayU8;
    }

    public static GrayU8 localGaussian(GrayU16 grayU16, GrayU8 grayU8, ConfigLength configLength, float f, boolean z, GrayU16 grayU17, GrayU16 grayU18) {
        BlurImageOps.gaussian(grayU16, grayU17, -1.0d, configLength.computeI(Math.min(grayU16.width, grayU16.height)) / 2, grayU18);
        if (z) {
            for (int i = 0; i < grayU16.height; i++) {
                int i2 = grayU16.startIndex + (grayU16.stride * i);
                int i3 = grayU8.startIndex + (grayU8.stride * i);
                int i4 = grayU17.startIndex + (grayU17.stride * i);
                int i5 = grayU16.width + i2;
                while (i2 < i5) {
                    if ((grayU16.data[i2] & 65535) <= (grayU17.data[i4] & 65535) * f) {
                        grayU8.data[i3] = 1;
                    } else {
                        grayU8.data[i3] = 0;
                    }
                    i2++;
                    i3++;
                    i4++;
                }
            }
        } else {
            for (int i6 = 0; i6 < grayU16.height; i6++) {
                int i7 = grayU16.startIndex + (grayU16.stride * i6);
                int i8 = grayU8.startIndex + (grayU8.stride * i6);
                int i9 = grayU17.startIndex + (grayU17.stride * i6);
                int i10 = grayU16.width + i7;
                while (i7 < i10) {
                    if ((grayU16.data[i7] & 65535) * f > (grayU17.data[i9] & 65535)) {
                        grayU8.data[i8] = 1;
                    } else {
                        grayU8.data[i8] = 0;
                    }
                    i7++;
                    i8++;
                    i9++;
                }
            }
        }
        return grayU8;
    }

    public static GrayU8 localMean(GrayF32 grayF32, GrayU8 grayU8, ConfigLength configLength, float f, boolean z, GrayF32 grayF33, GrayF32 grayF34, GrowArray growArray) {
        BlurImageOps.mean(grayF32, grayF33, configLength.computeI(Math.min(grayF32.width, grayF32.height)) / 2, grayF34, growArray);
        if (z) {
            for (int i = 0; i < grayF32.height; i++) {
                int i2 = grayF32.startIndex + (grayF32.stride * i);
                int i3 = grayU8.startIndex + (grayU8.stride * i);
                int i4 = grayF33.startIndex + (grayF33.stride * i);
                int i5 = grayF32.width + i2;
                while (i2 < i5) {
                    int i6 = i4 + 1;
                    int i7 = i3 + 1;
                    int i8 = i2 + 1;
                    grayU8.data[i3] = grayF32.data[i2] <= grayF33.data[i4] * f ? (byte) 1 : (byte) 0;
                    i4 = i6;
                    i3 = i7;
                    i2 = i8;
                }
            }
        } else {
            for (int i9 = 0; i9 < grayF32.height; i9++) {
                int i10 = grayF32.startIndex + (grayF32.stride * i9);
                int i11 = grayU8.startIndex + (grayU8.stride * i9);
                int i12 = grayF33.startIndex + (grayF33.stride * i9);
                int i13 = grayF32.width + i10;
                while (i10 < i13) {
                    int i14 = i12 + 1;
                    int i15 = i11 + 1;
                    int i16 = i10 + 1;
                    grayU8.data[i11] = grayF32.data[i10] * f > grayF33.data[i12] ? (byte) 1 : (byte) 0;
                    i12 = i14;
                    i11 = i15;
                    i10 = i16;
                }
            }
        }
        return grayU8;
    }

    public static GrayU8 localGaussian(GrayF32 grayF32, GrayU8 grayU8, ConfigLength configLength, float f, boolean z, GrayF32 grayF33, GrayF32 grayF34) {
        BlurImageOps.gaussian(grayF32, grayF33, -1.0d, configLength.computeI(Math.min(grayF32.width, grayF32.height)) / 2, grayF34);
        if (z) {
            for (int i = 0; i < grayF32.height; i++) {
                int i2 = grayF32.startIndex + (grayF32.stride * i);
                int i3 = grayU8.startIndex + (grayU8.stride * i);
                int i4 = grayF33.startIndex + (grayF33.stride * i);
                int i5 = grayF32.width + i2;
                while (i2 < i5) {
                    if (grayF32.data[i2] <= grayF33.data[i4] * f) {
                        grayU8.data[i3] = 1;
                    } else {
                        grayU8.data[i3] = 0;
                    }
                    i2++;
                    i3++;
                    i4++;
                }
            }
        } else {
            for (int i6 = 0; i6 < grayF32.height; i6++) {
                int i7 = grayF32.startIndex + (grayF32.stride * i6);
                int i8 = grayU8.startIndex + (grayU8.stride * i6);
                int i9 = grayF33.startIndex + (grayF33.stride * i6);
                int i10 = grayF32.width + i7;
                while (i7 < i10) {
                    if (grayF32.data[i7] * f > grayF33.data[i9]) {
                        grayU8.data[i8] = 1;
                    } else {
                        grayU8.data[i8] = 0;
                    }
                    i7++;
                    i8++;
                    i9++;
                }
            }
        }
        return grayU8;
    }
}
