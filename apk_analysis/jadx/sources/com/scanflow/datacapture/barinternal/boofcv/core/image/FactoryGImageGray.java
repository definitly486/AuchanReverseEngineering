package com.scanflow.datacapture.barinternal.boofcv.core.image;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryGImageGray {
    public static GImageGray create(Class cls) {
        if (cls == GrayU8.class) {
            return new GSingle_U8(null);
        }
        if (cls == GrayS8.class) {
            return new GSingle_S8(null);
        }
        if (cls == GrayU16.class) {
            return new GSingle_U16(null);
        }
        if (cls == GrayS16.class) {
            return new GSingle_S16(null);
        }
        if (cls == GrayS32.class) {
            return new GSingle_S32(null);
        }
        if (cls == GrayS64.class) {
            return new GSingle_I64(null);
        }
        if (cls == GrayF32.class) {
            return new GSingle_F32(null);
        }
        if (cls == GrayF64.class) {
            return new GSingle_F64(null);
        }
        throw new IllegalArgumentException("Unknown image type: " + cls);
    }

    public static class GSingle_U8 extends GSingleBaseInt {
        public GSingle_U8(GrayU8 grayU8) {
            super(grayU8);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public double unsafe_getD(int i, int i2) {
            return ((GrayU8) this.image).unsafe_get(i, i2);
        }
    }

    public static class GSingle_S8 extends GSingleBaseInt {
        public GSingle_S8(GrayS8 grayS8) {
            super(grayS8);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public double unsafe_getD(int i, int i2) {
            return ((GrayS8) this.image).unsafe_get(i, i2);
        }
    }

    public static class GSingle_U16 extends GSingleBaseInt {
        public GSingle_U16(GrayU16 grayU16) {
            super(grayU16);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public double unsafe_getD(int i, int i2) {
            return ((GrayU16) this.image).unsafe_get(i, i2);
        }
    }

    public static class GSingle_S16 extends GSingleBaseInt {
        public GSingle_S16(GrayS16 grayS16) {
            super(grayS16);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public double unsafe_getD(int i, int i2) {
            return ((GrayS16) this.image).unsafe_get(i, i2);
        }
    }

    public static class GSingle_S32 extends GSingleBaseInt {
        public GSingle_S32(GrayS32 grayS32) {
            super(grayS32);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public double unsafe_getD(int i, int i2) {
            return ((GrayS32) this.image).unsafe_get(i, i2);
        }
    }

    public static class GSingle_I64 extends GSingleBaseInt {
        public GSingle_I64(GrayS64 grayS64) {
            super(grayS64);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public double unsafe_getD(int i, int i2) {
            return ((GrayS64) this.image).unsafe_get(i, i2);
        }
    }

    public static class GSingle_F32 extends GSingleBase {
        public GSingle_F32(GrayF32 grayF32) {
            super(grayF32);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public double unsafe_getD(int i, int i2) {
            return ((GrayF32) this.image).unsafe_get(i, i2);
        }
    }

    public static class GSingle_F64 extends GSingleBase {
        public GSingle_F64(GrayF64 grayF64) {
            super(grayF64);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public double unsafe_getD(int i, int i2) {
            ImageGray imageGray = this.image;
            return ((GrayF64) imageGray).data[((GrayF64) imageGray).getIndex(i, i2)];
        }
    }

    public static abstract class GSingleBaseInt extends GSingleBase {
        protected GSingleBaseInt(ImageGray imageGray) {
            super(imageGray);
        }
    }

    public static abstract class GSingleBase implements GImageGray {
        protected ImageGray image;

        protected GSingleBase(ImageGray imageGray) {
            this.image = imageGray;
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public void wrap(ImageGray imageGray) {
            this.image = imageGray;
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public int getWidth() {
            return this.image.getWidth();
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray
        public int getHeight() {
            return this.image.getHeight();
        }
    }
}
