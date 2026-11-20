package com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class BinaryContourHelper {
    GrayU8 binary = new GrayU8(1, 1);
    BinaryContourInterface.Padded padded;
    GrayU8 subimage;

    public BinaryContourHelper(BinaryContourInterface binaryContourInterface, boolean z) {
        if (z || !(binaryContourInterface instanceof BinaryContourInterface.Padded)) {
            return;
        }
        this.padded = (BinaryContourInterface.Padded) binaryContourInterface;
        this.subimage = new GrayU8();
        this.padded.setCreatePaddedCopy(false);
        this.padded.setCoordinateAdjustment(1, 1);
    }

    public void reshape(int i, int i2) {
        if (this.padded == null) {
            this.binary.reshape(i, i2);
            return;
        }
        this.binary.reshape(i + 2, i2 + 2);
        GrayU8 grayU8 = this.subimage;
        Objects.requireNonNull(grayU8);
        this.binary.subimage(1, 1, i + 1, i2 + 1, grayU8);
    }

    public GrayU8 padded() {
        return this.binary;
    }

    public GrayU8 withoutPadding() {
        if (this.padded == null) {
            return this.binary;
        }
        GrayU8 grayU8 = this.subimage;
        Objects.requireNonNull(grayU8);
        return grayU8;
    }
}
