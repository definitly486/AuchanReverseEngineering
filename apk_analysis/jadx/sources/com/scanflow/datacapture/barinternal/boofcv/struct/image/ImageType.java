package com.scanflow.datacapture.barinternal.boofcv.struct.image;

import java.io.Serializable;

/* JADX INFO: loaded from: classes.dex */
public class ImageType implements Serializable {
    ImageDataType dataType;
    Family family;
    public int numBands;
    public static final ImageType SB_U8 = single(GrayU8.class);
    public static final ImageType SB_S8 = single(GrayS8.class);
    public static final ImageType SB_U16 = single(GrayU16.class);
    public static final ImageType SB_S16 = single(GrayS16.class);
    public static final ImageType SB_S32 = single(GrayS32.class);
    public static final ImageType SB_S64 = single(GrayS64.class);
    public static final ImageType SB_F32 = single(GrayF32.class);
    public static final ImageType SB_F64 = single(GrayF64.class);
    public static final ImageType IL_U8 = il(0, InterleavedU8.class);
    public static final ImageType IL_S8 = il(0, InterleavedS8.class);
    public static final ImageType IL_U16 = il(0, InterleavedU16.class);
    public static final ImageType IL_S16 = il(0, InterleavedS16.class);
    public static final ImageType IL_S32 = il(0, InterleavedS32.class);
    public static final ImageType IL_S64 = il(0, InterleavedS64.class);
    public static final ImageType IL_F32 = il(0, InterleavedF32.class);
    public static final ImageType IL_F64 = il(0, InterleavedF64.class);
    public static final ImageType PL_U8 = pl(0, GrayU8.class);
    public static final ImageType PL_S8 = pl(0, GrayS8.class);
    public static final ImageType PL_U16 = pl(0, GrayU16.class);
    public static final ImageType PL_S16 = pl(0, GrayS16.class);
    public static final ImageType PL_S32 = pl(0, GrayS32.class);
    public static final ImageType PL_S64 = pl(0, GrayS64.class);
    public static final ImageType PL_F32 = pl(0, GrayF32.class);
    public static final ImageType PL_F64 = pl(0, GrayF64.class);

    public enum Family {
        GRAY,
        PLANAR,
        INTERLEAVED
    }

    public ImageType(Family family, ImageDataType imageDataType, int i) {
        this.family = family;
        this.dataType = imageDataType;
        this.numBands = i;
    }

    public static ImageType single(Class cls) {
        return new ImageType(Family.GRAY, ImageDataType.classToType(cls), 1);
    }

    public static ImageType pl(int i, Class cls) {
        return new ImageType(Family.PLANAR, ImageDataType.classToType(cls), i);
    }

    public static ImageType il(int i, Class cls) {
        return new ImageType(Family.INTERLEAVED, ImageDataType.classToType(cls), i);
    }

    public ImageDataType getDataType() {
        return this.dataType;
    }

    public ImageBase createImage(int i, int i2) {
        int i3 = AnonymousClass1.$SwitchMap$boofcv$struct$image$ImageType$Family[this.family.ordinal()];
        if (i3 == 1) {
            return ImageGray.create(getImageClass(), i, i2);
        }
        if (i3 == 2) {
            return ImageInterleaved.create(getImageClass(), i, i2, this.numBands);
        }
        if (i3 == 3) {
            return new Planar(getImageClass(), i, i2, this.numBands);
        }
        throw new IllegalArgumentException("Type not yet supported");
    }

    public int getNumBands() {
        return this.numBands;
    }

    public Class getImageClass() {
        return getImageClass(this.family, this.dataType);
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$boofcv$struct$image$ImageDataType;
        static final /* synthetic */ int[] $SwitchMap$boofcv$struct$image$ImageType$Family;

        static {
            int[] iArr = new int[ImageDataType.values().length];
            $SwitchMap$boofcv$struct$image$ImageDataType = iArr;
            try {
                iArr[ImageDataType.F32.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageDataType[ImageDataType.F64.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageDataType[ImageDataType.U8.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageDataType[ImageDataType.S8.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageDataType[ImageDataType.U16.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageDataType[ImageDataType.S16.ordinal()] = 6;
            } catch (NoSuchFieldError unused6) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageDataType[ImageDataType.S32.ordinal()] = 7;
            } catch (NoSuchFieldError unused7) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageDataType[ImageDataType.S64.ordinal()] = 8;
            } catch (NoSuchFieldError unused8) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageDataType[ImageDataType.I8.ordinal()] = 9;
            } catch (NoSuchFieldError unused9) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageDataType[ImageDataType.I16.ordinal()] = 10;
            } catch (NoSuchFieldError unused10) {
            }
            int[] iArr2 = new int[Family.values().length];
            $SwitchMap$boofcv$struct$image$ImageType$Family = iArr2;
            try {
                iArr2[Family.GRAY.ordinal()] = 1;
            } catch (NoSuchFieldError unused11) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageType$Family[Family.INTERLEAVED.ordinal()] = 2;
            } catch (NoSuchFieldError unused12) {
            }
            try {
                $SwitchMap$boofcv$struct$image$ImageType$Family[Family.PLANAR.ordinal()] = 3;
            } catch (NoSuchFieldError unused13) {
            }
        }
    }

    public static Class getImageClass(Family family, ImageDataType imageDataType) {
        int i = AnonymousClass1.$SwitchMap$boofcv$struct$image$ImageType$Family[family.ordinal()];
        if (i != 1) {
            if (i == 2) {
                switch (AnonymousClass1.$SwitchMap$boofcv$struct$image$ImageDataType[imageDataType.ordinal()]) {
                    case 1:
                        return InterleavedF32.class;
                    case 2:
                        return InterleavedF64.class;
                    case 3:
                        return InterleavedU8.class;
                    case 4:
                        return InterleavedS8.class;
                    case 5:
                        return InterleavedU16.class;
                    case 6:
                        return InterleavedS16.class;
                    case 7:
                        return InterleavedS32.class;
                    case 8:
                        return InterleavedS64.class;
                    case 9:
                        return InterleavedI8.class;
                    case 10:
                        return InterleavedI16.class;
                    default:
                        throw new RuntimeException("Support this image type thing");
                }
            }
            if (i != 3) {
                throw new IncompatibleClassChangeError();
            }
        }
        switch (AnonymousClass1.$SwitchMap$boofcv$struct$image$ImageDataType[imageDataType.ordinal()]) {
            case 1:
                return GrayF32.class;
            case 2:
                return GrayF64.class;
            case 3:
                return GrayU8.class;
            case 4:
                return GrayS8.class;
            case 5:
                return GrayU16.class;
            case 6:
                return GrayS16.class;
            case 7:
                return GrayS32.class;
            case 8:
                return GrayS64.class;
            case 9:
                return GrayI8.class;
            case 10:
                return GrayI16.class;
            default:
                throw new RuntimeException("Support this image type thing");
        }
    }

    public String toString() {
        return "ImageType( " + this.family + " " + this.dataType + " " + this.numBands + " )";
    }

    public boolean isSameType(ImageType imageType) {
        return this.family == imageType.family && this.dataType == imageType.dataType && this.numBands == imageType.numBands;
    }
}
