package com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl;

import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.NearestNeighborPixelS;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public class NearestNeighborPixel_S32 extends NearestNeighborPixelS {
    private int[] data;

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixel
    public void setImage(GrayS32 grayS32) {
        super.setImage((ImageGray) grayS32);
        this.data = ((GrayS32) this.orig).data;
    }

    public float get_border(float f, float f2) {
        return ((ImageBorder_S32) this.border).get((int) Math.floor(f), (int) Math.floor(f2));
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixelS
    public float get(float f, float f2) {
        if (f < 0.0f || f2 < 0.0f || f > this.width - 1 || f2 > this.height - 1) {
            return get_border(f, f2);
        }
        return this.data[((GrayS32) this.orig).startIndex + (((int) f2) * this.stride) + ((int) f)];
    }
}
