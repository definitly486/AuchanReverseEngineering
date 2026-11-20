package com.scanflow.datacapture.barinternal.boofcv.abst.fiducial;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public interface QrCodeDetector {
    List getDetections();

    void process(ImageGray imageGray);
}
