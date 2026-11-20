package com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ContourPacked;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.LinearExternalContours;
import com.scanflow.datacapture.barinternal.boofcv.alg.misc.ImageMiscOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConnectRule;
import com.scanflow.datacapture.barinternal.boofcv.struct.PackedSetsPoint2D_I32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class BinaryContourFinderLinearExternal implements BinaryContourFinder, BinaryContourInterface.Padded {
    int adjustX;
    int adjustY;
    boolean copyForPadding = true;
    GrayU8 work = new GrayU8(1, 1);
    DogArray contours = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourFinderLinearExternal$$ExternalSyntheticLambda0
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new ContourPacked();
        }
    });
    LinearExternalContours alg = new LinearExternalContours(ConnectRule.FOUR);

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourFinder
    public void process(GrayU8 grayU8) {
        if (this.copyForPadding) {
            this.work.reshape(grayU8.width + 2, grayU8.height + 2);
            ImageMiscOps.copy(0, 0, 1, 1, grayU8.width, grayU8.height, grayU8, this.work);
            this.alg.process(this.work, 1, 1);
        } else {
            this.alg.process(grayU8, this.adjustX, this.adjustY);
        }
        this.contours.reset();
        PackedSetsPoint2D_I32 externalContours = this.alg.getExternalContours();
        for (int i = 0; i < externalContours.size(); i++) {
            ContourPacked contourPacked = (ContourPacked) this.contours.grow();
            contourPacked.externalIndex = i;
            contourPacked.id = i;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface
    public List getContours() {
        return this.contours.toList();
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface
    public void loadContour(int i, DogArray dogArray) {
        this.alg.getExternalContours().getSet(i, dogArray);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface
    public void setSaveInnerContour(boolean z) {
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface
    public void setMinContour(ConfigLength configLength) {
        this.alg.setMinContourLength(configLength);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface
    public ConfigLength getMinContour(ConfigLength configLength) {
        if (configLength == null) {
            configLength = new ConfigLength();
        }
        configLength.setTo(this.alg.getMinContourLength());
        return configLength;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface
    public void setMaxContour(ConfigLength configLength) {
        this.alg.setMaxContourLength(configLength);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface
    public void setConnectRule(ConnectRule connectRule) {
        this.alg.setConnectRule(connectRule);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface.Padded
    public void setCreatePaddedCopy(boolean z) {
        this.copyForPadding = z;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface.Padded
    public boolean isCreatePaddedCopy() {
        return this.copyForPadding;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface.Padded
    public void setCoordinateAdjustment(int i, int i2) {
        this.adjustX = i;
        this.adjustY = i2;
    }
}
