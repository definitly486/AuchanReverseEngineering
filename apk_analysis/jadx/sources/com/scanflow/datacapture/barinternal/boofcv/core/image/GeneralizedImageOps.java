package com.scanflow.datacapture.barinternal.boofcv.core.image;

import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily$$ExternalSyntheticLambda0;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageStandard_SB$$ExternalSyntheticLambda0;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageDataType;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedU8;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I64;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class GeneralizedImageOps {
    public static ImageGray createSingleBand(ImageDataType imageDataType, int i, int i2) {
        return createSingleBand(ImageType.getImageClass(ImageType.Family.GRAY, imageDataType), i, i2);
    }

    public static ImageGray createSingleBand(Class cls, int i, int i2) {
        return ImageGray.create((Class) convertGenericToSpecificType(cls), i, i2);
    }

    public static GrowArray createGrowArray(ImageType imageType) {
        if (imageType.getDataType().isInteger()) {
            if (imageType.getDataType().getNumBits() < 64) {
                return new GrowArray(new ConvolveImageStandard_SB$$ExternalSyntheticLambda0());
            }
            return new GrowArray(new ConcurrencyOps.NewInstance() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.GeneralizedImageOps$$ExternalSyntheticLambda0
                @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps.NewInstance
                public final Object newInstance() {
                    return new DogArray_I64();
                }
            });
        }
        if (imageType.getDataType().getNumBits() < 64) {
            return new GrowArray(new ThresholdNiblackFamily$$ExternalSyntheticLambda0());
        }
        return new GrowArray(new ConcurrencyOps.NewInstance() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.GeneralizedImageOps$$ExternalSyntheticLambda1
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps.NewInstance
            public final Object newInstance() {
                return new DogArray_F64();
            }
        });
    }

    public static Object convertGenericToSpecificType(Class cls) {
        if (cls == GrayI8.class) {
            return GrayU8.class;
        }
        if (cls == GrayI16.class) {
            return GrayS16.class;
        }
        if (cls == InterleavedI8.class) {
            return InterleavedU8.class;
        }
        return cls == InterleavedI16.class ? InterleavedS16.class : cls;
    }
}
