package com.scanflow.datacapture.barinternal.boofcv.core.image.border;

import com.scanflow.datacapture.barinternal.boofcv.struct.border.BorderIndex1D;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.BorderType;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.FactoryBorderIndex1D;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder1D_F64;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder1D_S64;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_F64;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryImageBorder {

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.boofcv.core.image.border.FactoryImageBorder$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$boofcv$struct$border$BorderType;
        static final /* synthetic */ int[] $SwitchMap$boofcv$struct$image$ImageType$Family;

        static {
            int[] iArr = new int[BorderType.values().length];
            $SwitchMap$boofcv$struct$border$BorderType = iArr;
            try {
                iArr[BorderType.SKIP.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$boofcv$struct$border$BorderType[BorderType.NORMALIZED.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$boofcv$struct$border$BorderType[BorderType.REFLECT.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$boofcv$struct$border$BorderType[BorderType.EXTENDED.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                $SwitchMap$boofcv$struct$border$BorderType[BorderType.WRAP.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
            try {
                $SwitchMap$boofcv$struct$border$BorderType[BorderType.ZERO.ordinal()] = 6;
            } catch (NoSuchFieldError unused6) {
            }
            int[] iArr2 = new int[ImageType.Family.values().length];
            $SwitchMap$boofcv$struct$image$ImageType$Family = iArr2;
            try {
                iArr2[ImageType.Family.GRAY.ordinal()] = 1;
            } catch (NoSuchFieldError unused7) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageType$Family[ImageType.Family.PLANAR.ordinal()] = 2;
            } catch (NoSuchFieldError unused8) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageType$Family[ImageType.Family.INTERLEAVED.ordinal()] = 3;
            } catch (NoSuchFieldError unused9) {
            }
        }
    }

    public static ImageBorder single(BorderType borderType, Class cls) {
        FactoryBorderIndex1D factoryBorderIndex1D;
        switch (AnonymousClass1.$SwitchMap$boofcv$struct$border$BorderType[borderType.ordinal()]) {
            case 1:
                throw new IllegalArgumentException("Skip border can't be implemented here and has to be done externally. Instead pass in EXTENDED and manually skip over the in a pixel by pixel basis.");
            case 2:
                throw new IllegalArgumentException("Normalized can't be supported by this border interface");
            case 3:
                factoryBorderIndex1D = new FactoryBorderIndex1D() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.border.FactoryImageBorder$$ExternalSyntheticLambda0
                    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.FactoryBorderIndex1D
                    public final BorderIndex1D newInstance() {
                        return new BorderIndex1D_Reflect();
                    }
                };
                break;
            case 4:
                factoryBorderIndex1D = new FactoryBorderIndex1D() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.border.FactoryImageBorder$$ExternalSyntheticLambda1
                    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.FactoryBorderIndex1D
                    public final BorderIndex1D newInstance() {
                        return new BorderIndex1D_Extend();
                    }
                };
                break;
            case 5:
                factoryBorderIndex1D = new FactoryBorderIndex1D() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.border.FactoryImageBorder$$ExternalSyntheticLambda2
                    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.FactoryBorderIndex1D
                    public final BorderIndex1D newInstance() {
                        return new BorderIndex1D_Wrap();
                    }
                };
                break;
            case 6:
                return singleValue(0.0d, cls);
            default:
                throw new IllegalArgumentException("Border type not supported: " + borderType);
        }
        if (cls == GrayF32.class) {
            return new ImageBorder1D_F32(factoryBorderIndex1D);
        }
        if (cls == GrayF64.class) {
            return new ImageBorder1D_F64(factoryBorderIndex1D);
        }
        if (GrayI.class.isAssignableFrom(cls)) {
            return new ImageBorder1D_S32(factoryBorderIndex1D);
        }
        if (cls == GrayS64.class) {
            return new ImageBorder1D_S64(factoryBorderIndex1D);
        }
        throw new IllegalArgumentException("Unknown image type: " + cls.getSimpleName());
    }

    public static ImageBorder singleValue(final double d, Class cls) {
        if (cls == GrayF32.class) {
            final float f = (float) d;
            return new ImageBorder_F32(f) { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.ImageBorderValue$Value_F32
                public float value;

                {
                    this.value = f;
                }

                @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_F32
                public float getOutside(int i, int i2) {
                    return this.value;
                }
            };
        }
        if (cls == GrayF64.class) {
            return new ImageBorder_F64(d) { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.ImageBorderValue$Value_F64
                public double value;

                {
                    this.value = d;
                }

                @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_F64
                public double getOutside(int i, int i2) {
                    return this.value;
                }
            };
        }
        if (GrayI.class.isAssignableFrom(cls)) {
            final int i = (int) d;
            return new ImageBorder_S32(i) { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.ImageBorderValue$Value_I
                public int value;

                {
                    this.value = i;
                }

                @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_S32
                public int getOutside(int i2, int i3) {
                    return this.value;
                }
            };
        }
        throw new IllegalArgumentException("Unknown image type: " + cls.getSimpleName());
    }
}
