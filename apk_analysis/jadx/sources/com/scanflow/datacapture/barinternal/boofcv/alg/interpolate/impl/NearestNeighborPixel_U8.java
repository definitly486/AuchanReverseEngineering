package com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.NearestNeighborPixelS;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public class NearestNeighborPixel_U8 extends NearestNeighborPixelS {
    private byte[] data;

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixel
    public void setImage(GrayU8 grayU8) {
        super.setImage((ImageGray) grayU8);
        this.data = ((GrayU8) this.orig).data;
    }

    public float get_border(float f, float f2) {
        return ((ImageBorder_S32) this.border).get((int) Math.floor(f), (int) Math.floor(f2));
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixelS
    public float get(float f, float f2) {
        if (f < 0.0f || f2 < 0.0f || f > this.width - 1 || f2 > this.height - 1) {
            return get_border(f, f2);
        }
        return this.data[((GrayU8) this.orig).startIndex + (((int) f2) * this.stride) + ((int) f)] & UnsignedBytes.MAX_VALUE;
    }
}
