package com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl;

import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.NearestNeighborPixelS;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public class NearestNeighborPixel_U16 extends NearestNeighborPixelS {
    private short[] data;

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixel
    public void setImage(GrayU16 grayU16) {
        super.setImage((ImageGray) grayU16);
        this.data = ((GrayU16) this.orig).data;
    }

    public float get_border(float f, float f2) {
        return ((ImageBorder_S32) this.border).get((int) Math.floor(f), (int) Math.floor(f2));
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixelS
    public float get(float f, float f2) {
        if (f < 0.0f || f2 < 0.0f || f > this.width - 1 || f2 > this.height - 1) {
            return get_border(f, f2);
        }
        return this.data[((GrayU16) this.orig).startIndex + (((int) f2) * this.stride) + ((int) f)] & 65535;
    }
}
