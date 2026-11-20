package com.scanflow.datacapture.barinternal.boofcv.alg;

import com.scanflow.datacapture.barinternal.boofcv.core.image.GeneralizedImageOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public abstract class InputSanityCheck {
    public static ImageBase declareOrReshape(ImageBase imageBase, ImageBase imageBase2) {
        if (imageBase2 == null) {
            return imageBase.createNew(imageBase.width, imageBase.height);
        }
        imageBase2.reshape(imageBase.width, imageBase.height);
        return imageBase2;
    }

    public static ImageGray declareOrReshape(ImageGray imageGray, ImageGray imageGray2, Class cls) {
        if (imageGray2 == null) {
            return GeneralizedImageOps.createSingleBand(cls, imageGray.width, imageGray.height);
        }
        imageGray2.reshape(imageGray.width, imageGray.height);
        return imageGray2;
    }

    public static void checkSameShape(ImageBase imageBase, ImageBase imageBase2) {
        if (imageBase.width == imageBase2.width && imageBase.height == imageBase2.height) {
            return;
        }
        throw new IllegalArgumentException("Image shapes do not match. " + imageBase.width + "x" + imageBase.height + " vs " + imageBase2.width + "x" + imageBase2.height);
    }
}
