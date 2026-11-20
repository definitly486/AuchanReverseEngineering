package com.scanflow.datacapture.barinternal.boofcv.factory.interpolate;

import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixelS;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.ImplBilinearPixel_F32;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.ImplBilinearPixel_F64;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.ImplBilinearPixel_S16;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.ImplBilinearPixel_S32;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.ImplBilinearPixel_U16;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.ImplBilinearPixel_U8;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.NearestNeighborPixel_F32;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.NearestNeighborPixel_S16;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.NearestNeighborPixel_S32;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.NearestNeighborPixel_U16;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.impl.NearestNeighborPixel_U8;
import com.scanflow.datacapture.barinternal.boofcv.core.image.border.FactoryImageBorder;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.BorderType;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryInterpolation {
    public static InterpolatePixelS bilinearPixelS(Class cls, BorderType borderType) {
        InterpolatePixelS implBilinearPixel_S32;
        if (cls == GrayF32.class) {
            implBilinearPixel_S32 = new ImplBilinearPixel_F32();
        } else if (cls == GrayF64.class) {
            implBilinearPixel_S32 = new ImplBilinearPixel_F64();
        } else if (cls == GrayU8.class) {
            implBilinearPixel_S32 = new ImplBilinearPixel_U8();
        } else if (cls == GrayU16.class) {
            implBilinearPixel_S32 = new ImplBilinearPixel_U16();
        } else if (cls == GrayS16.class) {
            implBilinearPixel_S32 = new ImplBilinearPixel_S16();
        } else if (cls == GrayS32.class) {
            implBilinearPixel_S32 = new ImplBilinearPixel_S32();
        } else {
            throw new RuntimeException("Unknown image type: " + typeName(cls));
        }
        if (borderType != null) {
            implBilinearPixel_S32.setBorder(FactoryImageBorder.single(borderType, cls));
        }
        return implBilinearPixel_S32;
    }

    private static String typeName(Class cls) {
        return cls == null ? "null" : cls.getName();
    }

    public static InterpolatePixelS nearestNeighborPixelS(Class cls) {
        if (cls == GrayF32.class) {
            return new NearestNeighborPixel_F32();
        }
        if (cls == GrayU8.class) {
            return new NearestNeighborPixel_U8();
        }
        if (cls == GrayS16.class) {
            return new NearestNeighborPixel_S16();
        }
        if (cls == GrayU16.class) {
            return new NearestNeighborPixel_U16();
        }
        if (cls == GrayS32.class) {
            return new NearestNeighborPixel_S32();
        }
        throw new RuntimeException("Unknown image type: " + typeName(cls));
    }
}
