package com.scanflow.datacapture.barinternal.boofcv.core.image;

import com.scanflow.datacapture.barinternal.boofcv.concurrency.BoofConcurrency;
import com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle;
import com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT;
import com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray;
import com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.Planar;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvertImage {
    public static GrayU8 average(Planar planar, GrayU8 grayU8) {
        if (grayU8 == null) {
            grayU8 = new GrayU8(planar.width, planar.height);
        } else {
            grayU8.reshapeTo(planar);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvertPlanarToGray_MT.average(planar, grayU8);
            return grayU8;
        }
        ImplConvertPlanarToGray.average(planar, grayU8);
        return grayU8;
    }

    public static GrayU8 average(InterleavedU8 interleavedU8, GrayU8 grayU8) {
        if (grayU8 == null) {
            grayU8 = new GrayU8(interleavedU8.width, interleavedU8.height);
        } else {
            grayU8.reshapeTo(interleavedU8);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ConvertInterleavedToSingle_MT.average(interleavedU8, grayU8);
            return grayU8;
        }
        ConvertInterleavedToSingle.average(interleavedU8, grayU8);
        return grayU8;
    }

    public static GrayS8 average(Planar planar, GrayS8 grayS8) {
        if (grayS8 == null) {
            grayS8 = new GrayS8(planar.width, planar.height);
        } else {
            grayS8.reshapeTo(planar);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvertPlanarToGray_MT.average(planar, grayS8);
            return grayS8;
        }
        ImplConvertPlanarToGray.average(planar, grayS8);
        return grayS8;
    }

    public static GrayS8 average(InterleavedS8 interleavedS8, GrayS8 grayS8) {
        if (grayS8 == null) {
            grayS8 = new GrayS8(interleavedS8.width, interleavedS8.height);
        } else {
            grayS8.reshapeTo(interleavedS8);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ConvertInterleavedToSingle_MT.average(interleavedS8, grayS8);
            return grayS8;
        }
        ConvertInterleavedToSingle.average(interleavedS8, grayS8);
        return grayS8;
    }

    public static GrayU16 average(Planar planar, GrayU16 grayU16) {
        if (grayU16 == null) {
            grayU16 = new GrayU16(planar.width, planar.height);
        } else {
            grayU16.reshapeTo(planar);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvertPlanarToGray_MT.average(planar, grayU16);
            return grayU16;
        }
        ImplConvertPlanarToGray.average(planar, grayU16);
        return grayU16;
    }

    public static GrayU16 average(InterleavedU16 interleavedU16, GrayU16 grayU16) {
        if (grayU16 == null) {
            grayU16 = new GrayU16(interleavedU16.width, interleavedU16.height);
        } else {
            grayU16.reshapeTo(interleavedU16);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ConvertInterleavedToSingle_MT.average(interleavedU16, grayU16);
            return grayU16;
        }
        ConvertInterleavedToSingle.average(interleavedU16, grayU16);
        return grayU16;
    }

    public static GrayS16 average(Planar planar, GrayS16 grayS16) {
        if (grayS16 == null) {
            grayS16 = new GrayS16(planar.width, planar.height);
        } else {
            grayS16.reshapeTo(planar);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvertPlanarToGray_MT.average(planar, grayS16);
            return grayS16;
        }
        ImplConvertPlanarToGray.average(planar, grayS16);
        return grayS16;
    }

    public static GrayS16 average(InterleavedS16 interleavedS16, GrayS16 grayS16) {
        if (grayS16 == null) {
            grayS16 = new GrayS16(interleavedS16.width, interleavedS16.height);
        } else {
            grayS16.reshapeTo(interleavedS16);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ConvertInterleavedToSingle_MT.average(interleavedS16, grayS16);
            return grayS16;
        }
        ConvertInterleavedToSingle.average(interleavedS16, grayS16);
        return grayS16;
    }

    public static GrayS32 average(Planar planar, GrayS32 grayS32) {
        if (grayS32 == null) {
            grayS32 = new GrayS32(planar.width, planar.height);
        } else {
            grayS32.reshapeTo(planar);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvertPlanarToGray_MT.average(planar, grayS32);
            return grayS32;
        }
        ImplConvertPlanarToGray.average(planar, grayS32);
        return grayS32;
    }

    public static GrayS32 average(InterleavedS32 interleavedS32, GrayS32 grayS32) {
        if (grayS32 == null) {
            grayS32 = new GrayS32(interleavedS32.width, interleavedS32.height);
        } else {
            grayS32.reshapeTo(interleavedS32);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ConvertInterleavedToSingle_MT.average(interleavedS32, grayS32);
            return grayS32;
        }
        ConvertInterleavedToSingle.average(interleavedS32, grayS32);
        return grayS32;
    }

    public static GrayS64 average(Planar planar, GrayS64 grayS64) {
        if (grayS64 == null) {
            grayS64 = new GrayS64(planar.width, planar.height);
        } else {
            grayS64.reshapeTo(planar);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvertPlanarToGray_MT.average(planar, grayS64);
            return grayS64;
        }
        ImplConvertPlanarToGray.average(planar, grayS64);
        return grayS64;
    }

    public static GrayS64 average(InterleavedS64 interleavedS64, GrayS64 grayS64) {
        if (grayS64 == null) {
            grayS64 = new GrayS64(interleavedS64.width, interleavedS64.height);
        } else {
            grayS64.reshapeTo(interleavedS64);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ConvertInterleavedToSingle_MT.average(interleavedS64, grayS64);
            return grayS64;
        }
        ConvertInterleavedToSingle.average(interleavedS64, grayS64);
        return grayS64;
    }

    public static GrayF32 average(Planar planar, GrayF32 grayF32) {
        if (grayF32 == null) {
            grayF32 = new GrayF32(planar.width, planar.height);
        } else {
            grayF32.reshapeTo(planar);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvertPlanarToGray_MT.average(planar, grayF32);
            return grayF32;
        }
        ImplConvertPlanarToGray.average(planar, grayF32);
        return grayF32;
    }

    public static GrayF32 average(InterleavedF32 interleavedF32, GrayF32 grayF32) {
        if (grayF32 == null) {
            grayF32 = new GrayF32(interleavedF32.width, interleavedF32.height);
        } else {
            grayF32.reshapeTo(interleavedF32);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ConvertInterleavedToSingle_MT.average(interleavedF32, grayF32);
            return grayF32;
        }
        ConvertInterleavedToSingle.average(interleavedF32, grayF32);
        return grayF32;
    }

    public static GrayF64 average(Planar planar, GrayF64 grayF64) {
        if (grayF64 == null) {
            grayF64 = new GrayF64(planar.width, planar.height);
        } else {
            grayF64.reshapeTo(planar);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvertPlanarToGray_MT.average(planar, grayF64);
            return grayF64;
        }
        ImplConvertPlanarToGray.average(planar, grayF64);
        return grayF64;
    }

    public static GrayF64 average(InterleavedF64 interleavedF64, GrayF64 grayF64) {
        if (grayF64 == null) {
            grayF64 = new GrayF64(interleavedF64.width, interleavedF64.height);
        } else {
            grayF64.reshapeTo(interleavedF64);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            ConvertInterleavedToSingle_MT.average(interleavedF64, grayF64);
            return grayF64;
        }
        ConvertInterleavedToSingle.average(interleavedF64, grayF64);
        return grayF64;
    }
}
