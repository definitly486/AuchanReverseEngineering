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
import com.scanflow.datacapture.barinternal.boofcv.struct.image.Planar;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplConvertPlanarToGray {
    public static void average(Planar planar, GrayU8 grayU8) {
        int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayU8.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            GrayU8 grayU9 = (GrayU8) planar.getBand(0);
            GrayU8 grayU10 = (GrayU8) planar.getBand(1);
            GrayU8 grayU11 = (GrayU8) planar.getBand(2);
            for (int i = 0; i < planar.height; i++) {
                int index = planar.getIndex(0, i);
                int index2 = grayU8.getIndex(0, i);
                int i2 = 0;
                while (i2 < planar.width) {
                    grayU8.data[index2] = (byte) ((((grayU9.data[index] & UnsignedBytes.MAX_VALUE) + (grayU10.data[index] & UnsignedBytes.MAX_VALUE)) + (grayU11.data[index] & UnsignedBytes.MAX_VALUE)) / 3);
                    i2++;
                    index++;
                    index2++;
                }
            }
            return;
        }
        for (int i3 = 0; i3 < planar.height; i3++) {
            int index3 = planar.getIndex(0, i3);
            int index4 = grayU8.getIndex(0, i3);
            int i4 = 0;
            while (i4 < planar.width) {
                int i5 = 0;
                for (int i6 = 0; i6 < numBands; i6++) {
                    i5 += ((GrayU8[]) planar.bands)[i6].data[index3] & UnsignedBytes.MAX_VALUE;
                }
                grayU8.data[index4] = (byte) (i5 / numBands);
                i4++;
                index3++;
                index4++;
            }
        }
    }

    public static void average(Planar planar, GrayS8 grayS8) {
        int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayS8.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            GrayS8 grayS9 = (GrayS8) planar.getBand(0);
            GrayS8 grayS10 = (GrayS8) planar.getBand(1);
            GrayS8 grayS11 = (GrayS8) planar.getBand(2);
            for (int i = 0; i < planar.height; i++) {
                int index = planar.getIndex(0, i);
                int index2 = grayS8.getIndex(0, i);
                int i2 = 0;
                while (i2 < planar.width) {
                    grayS8.data[index2] = (byte) (((grayS9.data[index] + grayS10.data[index]) + grayS11.data[index]) / 3);
                    i2++;
                    index++;
                    index2++;
                }
            }
            return;
        }
        for (int i3 = 0; i3 < planar.height; i3++) {
            int index3 = planar.getIndex(0, i3);
            int index4 = grayS8.getIndex(0, i3);
            int i4 = 0;
            while (i4 < planar.width) {
                int i5 = 0;
                for (int i6 = 0; i6 < numBands; i6++) {
                    i5 += ((GrayS8[]) planar.bands)[i6].data[index3];
                }
                grayS8.data[index4] = (byte) (i5 / numBands);
                i4++;
                index3++;
                index4++;
            }
        }
    }

    public static void average(Planar planar, GrayU16 grayU16) {
        int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayU16.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            GrayU16 grayU17 = (GrayU16) planar.getBand(0);
            GrayU16 grayU18 = (GrayU16) planar.getBand(1);
            GrayU16 grayU19 = (GrayU16) planar.getBand(2);
            for (int i = 0; i < planar.height; i++) {
                int index = planar.getIndex(0, i);
                int index2 = grayU16.getIndex(0, i);
                int i2 = 0;
                while (i2 < planar.width) {
                    grayU16.data[index2] = (short) ((((grayU17.data[index] & 65535) + (grayU18.data[index] & 65535)) + (grayU19.data[index] & 65535)) / 3);
                    i2++;
                    index++;
                    index2++;
                }
            }
            return;
        }
        for (int i3 = 0; i3 < planar.height; i3++) {
            int index3 = planar.getIndex(0, i3);
            int index4 = grayU16.getIndex(0, i3);
            int i4 = 0;
            while (i4 < planar.width) {
                int i5 = 0;
                for (int i6 = 0; i6 < numBands; i6++) {
                    i5 += ((GrayU16[]) planar.bands)[i6].data[index3] & 65535;
                }
                grayU16.data[index4] = (short) (i5 / numBands);
                i4++;
                index3++;
                index4++;
            }
        }
    }

    public static void average(Planar planar, GrayS16 grayS16) {
        int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayS16.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            GrayS16 grayS17 = (GrayS16) planar.getBand(0);
            GrayS16 grayS18 = (GrayS16) planar.getBand(1);
            GrayS16 grayS19 = (GrayS16) planar.getBand(2);
            for (int i = 0; i < planar.height; i++) {
                int index = planar.getIndex(0, i);
                int index2 = grayS16.getIndex(0, i);
                int i2 = 0;
                while (i2 < planar.width) {
                    grayS16.data[index2] = (short) (((grayS17.data[index] + grayS18.data[index]) + grayS19.data[index]) / 3);
                    i2++;
                    index++;
                    index2++;
                }
            }
            return;
        }
        for (int i3 = 0; i3 < planar.height; i3++) {
            int index3 = planar.getIndex(0, i3);
            int index4 = grayS16.getIndex(0, i3);
            int i4 = 0;
            while (i4 < planar.width) {
                int i5 = 0;
                for (int i6 = 0; i6 < numBands; i6++) {
                    i5 += ((GrayS16[]) planar.bands)[i6].data[index3];
                }
                grayS16.data[index4] = (short) (i5 / numBands);
                i4++;
                index3++;
                index4++;
            }
        }
    }

    public static void average(Planar planar, GrayS32 grayS32) {
        int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayS32.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            GrayS32 grayS33 = (GrayS32) planar.getBand(0);
            GrayS32 grayS34 = (GrayS32) planar.getBand(1);
            GrayS32 grayS35 = (GrayS32) planar.getBand(2);
            for (int i = 0; i < planar.height; i++) {
                int index = planar.getIndex(0, i);
                int index2 = grayS32.getIndex(0, i);
                int i2 = 0;
                while (i2 < planar.width) {
                    grayS32.data[index2] = ((grayS33.data[index] + grayS34.data[index]) + grayS35.data[index]) / 3;
                    i2++;
                    index++;
                    index2++;
                }
            }
            return;
        }
        for (int i3 = 0; i3 < planar.height; i3++) {
            int index3 = planar.getIndex(0, i3);
            int index4 = grayS32.getIndex(0, i3);
            int i4 = 0;
            while (i4 < planar.width) {
                int i5 = 0;
                for (int i6 = 0; i6 < numBands; i6++) {
                    i5 += ((GrayS32[]) planar.bands)[i6].data[index3];
                }
                grayS32.data[index4] = i5 / numBands;
                i4++;
                index3++;
                index4++;
            }
        }
    }

    public static void average(Planar planar, GrayS64 grayS64) {
        int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayS64.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            GrayS64 grayS65 = (GrayS64) planar.getBand(0);
            GrayS64 grayS66 = (GrayS64) planar.getBand(1);
            GrayS64 grayS67 = (GrayS64) planar.getBand(2);
            for (int i = 0; i < planar.height; i++) {
                int index = planar.getIndex(0, i);
                int index2 = grayS64.getIndex(0, i);
                int i2 = 0;
                while (i2 < planar.width) {
                    grayS64.data[index2] = ((grayS65.data[index] + grayS66.data[index]) + grayS67.data[index]) / 3;
                    i2++;
                    index++;
                    index2++;
                }
            }
            return;
        }
        for (int i3 = 0; i3 < planar.height; i3++) {
            int index3 = planar.getIndex(0, i3);
            int index4 = grayS64.getIndex(0, i3);
            int i4 = 0;
            while (i4 < planar.width) {
                long j = 0;
                for (int i5 = 0; i5 < numBands; i5++) {
                    j += ((GrayS64[]) planar.bands)[i5].data[index3];
                }
                grayS64.data[index4] = j / ((long) numBands);
                i4++;
                index3++;
                index4++;
            }
        }
    }

    public static void average(Planar planar, GrayF32 grayF32) {
        int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayF32.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            GrayF32 grayF33 = (GrayF32) planar.getBand(0);
            GrayF32 grayF34 = (GrayF32) planar.getBand(1);
            GrayF32 grayF35 = (GrayF32) planar.getBand(2);
            for (int i = 0; i < planar.height; i++) {
                int index = planar.getIndex(0, i);
                int index2 = grayF32.getIndex(0, i);
                int i2 = 0;
                while (i2 < planar.width) {
                    grayF32.data[index2] = ((grayF33.data[index] + grayF34.data[index]) + grayF35.data[index]) / 3.0f;
                    i2++;
                    index++;
                    index2++;
                }
            }
            return;
        }
        for (int i3 = 0; i3 < planar.height; i3++) {
            int index3 = planar.getIndex(0, i3);
            int index4 = grayF32.getIndex(0, i3);
            int i4 = 0;
            while (i4 < planar.width) {
                float f = 0.0f;
                for (int i5 = 0; i5 < numBands; i5++) {
                    f += ((GrayF32[]) planar.bands)[i5].data[index3];
                }
                grayF32.data[index4] = f / numBands;
                i4++;
                index3++;
                index4++;
            }
        }
    }

    public static void average(Planar planar, GrayF64 grayF64) {
        int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayF64.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            GrayF64 grayF65 = (GrayF64) planar.getBand(0);
            GrayF64 grayF66 = (GrayF64) planar.getBand(1);
            GrayF64 grayF67 = (GrayF64) planar.getBand(2);
            for (int i = 0; i < planar.height; i++) {
                int index = planar.getIndex(0, i);
                int index2 = grayF64.getIndex(0, i);
                int i2 = 0;
                while (i2 < planar.width) {
                    grayF64.data[index2] = ((grayF65.data[index] + grayF66.data[index]) + grayF67.data[index]) / 3.0d;
                    i2++;
                    index++;
                    index2++;
                }
            }
            return;
        }
        for (int i3 = 0; i3 < planar.height; i3++) {
            int index3 = planar.getIndex(0, i3);
            int index4 = grayF64.getIndex(0, i3);
            int i4 = 0;
            while (i4 < planar.width) {
                double d = 0.0d;
                for (int i5 = 0; i5 < numBands; i5++) {
                    d += ((GrayF64[]) planar.bands)[i5].data[index3];
                }
                grayF64.data[index4] = d / ((double) numBands);
                i4++;
                index3++;
                index4++;
            }
        }
    }
}
