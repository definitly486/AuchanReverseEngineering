package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.alg.misc.GImageStatistics;
import com.scanflow.datacapture.barinternal.boofcv.alg.misc.HistogramStatistics;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class GThresholdImageOps {
    public static double computeOtsu(ImageGray imageGray, double d, double d2) {
        int i = (int) ((d2 + 1.0d) - d);
        int[] iArr = new int[i];
        GImageStatistics.histogram(imageGray, d, iArr);
        return ((double) computeOtsu(iArr, i, imageGray.width * imageGray.height)) + d;
    }

    public static int computeOtsu(int[] iArr, int i, int i2) {
        double d;
        int i3 = i;
        double d2 = i3;
        double d3 = 0.0d;
        double d4 = 0.0d;
        for (int i4 = 0; i4 < i3; i4++) {
            d4 += (((double) i4) / d2) * ((double) iArr[i4]);
        }
        int i5 = 0;
        int i6 = 0;
        int i7 = 0;
        double d5 = 0.0d;
        while (i5 < i3) {
            int i8 = iArr[i5];
            i6 += i8;
            if (i6 == 0) {
                d = d2;
            } else {
                int i9 = i2 - i6;
                if (i9 == 0) {
                    break;
                }
                d = d2;
                d3 += (((double) i5) / d2) * ((double) i8);
                double d6 = i6;
                double d7 = i9;
                double d8 = (d3 / d6) - ((d4 - d3) / d7);
                double d9 = d6 * d7 * d8 * d8;
                if (d9 > d5) {
                    d5 = d9;
                    i7 = i5;
                }
            }
            i5++;
            i3 = i;
            d2 = d;
        }
        return i7;
    }

    public static double computeLi(ImageGray imageGray, double d, double d2) {
        int i = (int) ((d2 + 1.0d) - d);
        int[] iArr = new int[i];
        GImageStatistics.histogram(imageGray, d, iArr);
        return ((double) computeLi(iArr, i)) + d;
    }

    public static int computeLi(int[] iArr, int i) {
        double d = 0.5d;
        int iMean = (int) (HistogramStatistics.mean(iArr, i) + 0.5d);
        while (true) {
            int i2 = (int) (((double) iMean) + d);
            long j = 0;
            long j2 = 0;
            long j3 = 0;
            for (int i3 = 0; i3 <= i2; i3++) {
                int i4 = iArr[i3];
                j3 += ((long) i3) * ((long) i4);
                j2 += (long) i4;
            }
            double d2 = j2 == 0 ? 0.0d : j3 / j2;
            int i5 = i2 + 1;
            double d3 = d;
            long j4 = 0;
            long j5 = 0;
            while (i5 < i) {
                int i6 = iArr[i5];
                j4 += ((long) i5) * ((long) i6);
                j5 += (long) i6;
                i5++;
                j = j;
            }
            double d4 = j5 == j ? 0.0d : j4 / j5;
            double dLog = (d2 - d4) / (Math.log(d2) - Math.log(d4));
            int i7 = (int) (dLog < (-UtilEjml.EPS) ? dLog - d3 : dLog + d3);
            if (Math.abs(i7 - iMean) <= d3) {
                return i2;
            }
            iMean = i7;
            d = d3;
        }
    }

    public static double computeHuang(ImageGray imageGray, double d, double d2) {
        int i = (int) ((d2 + 1.0d) - d);
        int[] iArr = new int[i];
        GImageStatistics.histogram(imageGray, d, iArr);
        return ((double) computeHuang(iArr, i)) + d;
    }

    public static int computeHuang(int[] iArr, int i) {
        double d;
        int i2 = 0;
        for (int i3 = 0; i3 < i; i3++) {
            if (iArr[i3] != 0) {
                i2 = i3;
                break;
            }
        }
        int i4 = i - 1;
        for (int i5 = i4; i5 >= i2; i5--) {
            if (iArr[i5] != 0) {
                i4 = i5;
                break;
            }
        }
        double d2 = 1.0d;
        double d3 = 1.0d / ((double) (i4 - i2));
        double[] dArr = new double[i];
        int i6 = i2;
        long j = 0;
        long j2 = 0;
        while (i6 < i) {
            int i7 = iArr[i6];
            j += ((long) i6) * ((long) i7);
            j2 += (long) i7;
            dArr[i6] = j / j2;
            i6++;
            d2 = d2;
            d3 = d3;
        }
        double d4 = d3;
        double d5 = d2;
        double[] dArr2 = new double[i];
        int i8 = i4;
        long j3 = 0;
        long j4 = 0;
        while (i8 >= 0) {
            int i9 = iArr[i8];
            j3 += ((long) i8) * ((long) i9);
            long j5 = j4 + ((long) i9);
            dArr2[i8] = j3 / j5;
            i8--;
            j4 = j5;
        }
        int i10 = -1;
        double d6 = Double.MAX_VALUE;
        int i11 = i2;
        while (i11 <= i4) {
            double dLog = 0.0d;
            int i12 = i2;
            while (true) {
                d = 1.0E-6d;
                if (i12 > i11) {
                    break;
                }
                double dAbs = d5 / ((Math.abs(((double) i12) - dArr[i11]) * d4) + d5);
                if (dAbs >= 1.0E-6d && dAbs <= 0.999999d) {
                    double d7 = iArr[i12];
                    double dLog2 = (-dAbs) * Math.log(dAbs);
                    double d8 = d5 - dAbs;
                    dLog += d7 * (dLog2 - (d8 * Math.log(d8)));
                }
                i12++;
                i2 = i2;
                dArr2 = dArr2;
            }
            double[] dArr3 = dArr2;
            int i13 = i2;
            int i14 = i11 + 1;
            int i15 = i14;
            while (i15 <= i4) {
                double dAbs2 = d5 / ((Math.abs(((double) i15) - dArr3[i11]) * d4) + d5);
                if (dAbs2 >= d && dAbs2 <= 0.999999d) {
                    double d9 = iArr[i15];
                    double dLog3 = (-dAbs2) * Math.log(dAbs2);
                    double d10 = d5 - dAbs2;
                    dLog += d9 * (dLog3 - (d10 * Math.log(d10)));
                }
                i15++;
                i14 = i14;
                d = 1.0E-6d;
            }
            int i16 = i14;
            if (dLog < d6) {
                i10 = i11;
                d6 = dLog;
            }
            i11 = i16;
            i2 = i13;
            dArr2 = dArr3;
        }
        return i10;
    }

    public static double computeEntropy(ImageGray imageGray, double d, double d2) {
        int i = (int) ((d2 + 1.0d) - d);
        int[] iArr = new int[i];
        GImageStatistics.histogram(imageGray, d, iArr);
        return ((double) computeEntropy(iArr, i, imageGray.width * imageGray.height)) + d;
    }

    public static int computeEntropy(int[] iArr, int i, int i2) {
        double[] dArr = new double[i];
        for (int i3 = 0; i3 < i; i3++) {
            int i4 = iArr[i3];
            if (i4 == 0) {
                dArr[i3] = 0.0d;
            } else {
                double d = ((double) i4) / ((double) i2);
                dArr[i3] = d;
                dArr[i3] = d * Math.log(d);
            }
        }
        int i5 = 0;
        int i6 = 0;
        double d2 = 0.0d;
        for (int i7 = 0; i7 < i; i7++) {
            i6 += iArr[i7];
            double d3 = ((double) i6) / ((double) i2);
            if (d3 != 0.0d && d3 != 1.0d) {
                double d4 = 1.0d - d3;
                double d5 = 0.0d;
                for (int i8 = 0; i8 <= i7; i8++) {
                    d5 += dArr[i8];
                }
                double d6 = d5 / d3;
                double d7 = 0.0d;
                for (int i9 = i7 + 1; i9 < i; i9++) {
                    d7 += dArr[i9];
                }
                double dLog = ((Math.log(d3) + Math.log(d4)) - d6) - (d7 / d4);
                if (dLog > d2) {
                    i5 = i7;
                    d2 = dLog;
                }
            }
        }
        return i5;
    }

    public static GrayU8 threshold(ImageGray imageGray, GrayU8 grayU8, double d, boolean z) {
        if (imageGray instanceof GrayF32) {
            return ThresholdImageOps.threshold((GrayF32) imageGray, grayU8, (float) d, z);
        }
        if (imageGray instanceof GrayU8) {
            return ThresholdImageOps.threshold((GrayU8) imageGray, grayU8, (int) d, z);
        }
        if (imageGray instanceof GrayU16) {
            return ThresholdImageOps.threshold((GrayU16) imageGray, grayU8, (int) d, z);
        }
        if (imageGray instanceof GrayS16) {
            return ThresholdImageOps.threshold((GrayS16) imageGray, grayU8, (int) d, z);
        }
        if (imageGray instanceof GrayS32) {
            return ThresholdImageOps.threshold((GrayS32) imageGray, grayU8, (int) d, z);
        }
        if (imageGray instanceof GrayF64) {
            return ThresholdImageOps.threshold((GrayF64) imageGray, grayU8, d, z);
        }
        throw new IllegalArgumentException("Unknown image type: " + imageGray.getClass().getSimpleName());
    }

    public static GrayU8 localMean(ImageGray imageGray, GrayU8 grayU8, ConfigLength configLength, double d, boolean z, ImageGray imageGray2, ImageGray imageGray3, GrowArray growArray) {
        if (imageGray instanceof GrayF32) {
            return ThresholdImageOps.localMean((GrayF32) imageGray, grayU8, configLength, (float) d, z, (GrayF32) imageGray2, (GrayF32) imageGray3, growArray);
        }
        if (imageGray instanceof GrayU8) {
            return ThresholdImageOps.localMean((GrayU8) imageGray, grayU8, configLength, (float) d, z, (GrayU8) imageGray2, (GrayU8) imageGray3, growArray);
        }
        if (imageGray instanceof GrayU16) {
            return ThresholdImageOps.localMean((GrayU16) imageGray, grayU8, configLength, (float) d, z, (GrayU16) imageGray2, (GrayU16) imageGray3, growArray);
        }
        throw new IllegalArgumentException("Unknown image type: " + imageGray.getClass().getSimpleName());
    }

    public static GrayU8 localGaussian(ImageGray imageGray, GrayU8 grayU8, ConfigLength configLength, double d, boolean z, ImageGray imageGray2, ImageGray imageGray3) {
        if (imageGray instanceof GrayF32) {
            return ThresholdImageOps.localGaussian((GrayF32) imageGray, grayU8, configLength, (float) d, z, (GrayF32) imageGray2, (GrayF32) imageGray3);
        }
        if (imageGray instanceof GrayU8) {
            return ThresholdImageOps.localGaussian((GrayU8) imageGray, grayU8, configLength, (float) d, z, (GrayU8) imageGray2, (GrayU8) imageGray3);
        }
        if (imageGray instanceof GrayU16) {
            return ThresholdImageOps.localGaussian((GrayU16) imageGray, grayU8, configLength, (float) d, z, (GrayU16) imageGray2, (GrayU16) imageGray3);
        }
        throw new IllegalArgumentException("Unknown image type: " + imageGray.getClass().getSimpleName());
    }
}
