package com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl;

import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.BilinearPixelS;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public class ImplBilinearPixel_S32 extends BilinearPixelS {
    public float get_fast(float f, float f2) {
        int i = (int) f;
        int i2 = (int) f2;
        float f3 = f - i;
        float f4 = f2 - i2;
        ImageGray imageGray = this.orig;
        int i3 = ((GrayS32) imageGray).startIndex;
        int i4 = this.stride;
        int i5 = i3 + (i2 * i4) + i;
        int[] iArr = ((GrayS32) imageGray).data;
        float f5 = 1.0f - f3;
        float f6 = 1.0f - f4;
        int i6 = i5 + 1;
        return (f5 * f6 * iArr[i5]) + (f6 * f3 * iArr[i6]) + (f3 * f4 * iArr[i6 + i4]) + (f5 * f4 * iArr[i5 + i4]);
    }

    public float get_border(float f, float f2) {
        float fFloor = (float) Math.floor(f);
        float fFloor2 = (float) Math.floor(f2);
        int i = (int) fFloor;
        int i2 = (int) fFloor2;
        float f3 = f - fFloor;
        float f4 = f2 - fFloor2;
        ImageBorder_S32 imageBorder_S32 = (ImageBorder_S32) this.border;
        float f5 = 1.0f - f3;
        float f6 = 1.0f - f4;
        int i3 = i + 1;
        float f7 = (f5 * f6 * imageBorder_S32.get(i, i2)) + (f6 * f3 * imageBorder_S32.get(i3, i2));
        int i4 = i2 + 1;
        return f7 + (f3 * f4 * imageBorder_S32.get(i3, i4)) + (f5 * f4 * imageBorder_S32.get(i, i4));
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixelS
    public float get(float f, float f2) {
        if (f < 0.0f || f2 < 0.0f || f > this.width - 2 || f2 > this.height - 2) {
            return get_border(f, f2);
        }
        return get_fast(f, f2);
    }
}
