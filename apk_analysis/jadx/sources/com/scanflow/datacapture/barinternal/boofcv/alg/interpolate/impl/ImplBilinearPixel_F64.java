package com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl;

import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.BilinearPixelS;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_F64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public class ImplBilinearPixel_F64 extends BilinearPixelS {
    public float get_fast(float f, float f2) {
        int i = (int) f;
        int i2 = (int) f2;
        double d = f - i;
        double d2 = f2 - i2;
        ImageGray imageGray = this.orig;
        int i3 = ((GrayF64) imageGray).startIndex;
        int i4 = this.stride;
        int i5 = i3 + (i2 * i4) + i;
        double[] dArr = ((GrayF64) imageGray).data;
        double d3 = 1.0d - d;
        double d4 = 1.0d - d2;
        int i6 = i5 + 1;
        return (float) ((d3 * d4 * dArr[i5]) + (d4 * d * dArr[i6]) + (d * d2 * dArr[i6 + i4]) + (d3 * d2 * dArr[i5 + i4]));
    }

    public float get_border(float f, float f2) {
        double d = f;
        double dFloor = Math.floor(d);
        double d2 = f2;
        double dFloor2 = Math.floor(d2);
        int i = (int) dFloor;
        int i2 = (int) dFloor2;
        double d3 = d - dFloor;
        double d4 = d2 - dFloor2;
        ImageBorder_F64 imageBorder_F64 = (ImageBorder_F64) this.border;
        double d5 = 1.0d - d3;
        double d6 = 1.0d - d4;
        int i3 = i + 1;
        double d7 = (d5 * d6 * imageBorder_F64.get(i, i2)) + (d6 * d3 * imageBorder_F64.get(i3, i2));
        int i4 = i2 + 1;
        return (float) (d7 + (d3 * d4 * imageBorder_F64.get(i3, i4)) + (d5 * d4 * imageBorder_F64.get(i, i4)));
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixelS
    public float get(float f, float f2) {
        if (f < 0.0f || f2 < 0.0f || f > this.width - 2 || f2 > this.height - 2) {
            return get_border(f, f2);
        }
        return get_fast(f, f2);
    }
}
