package com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;

/* JADX INFO: loaded from: classes.dex */
public interface InputToBinary {
    ImageType getInputType();

    void process(ImageBase imageBase, GrayU8 grayU8);
}
