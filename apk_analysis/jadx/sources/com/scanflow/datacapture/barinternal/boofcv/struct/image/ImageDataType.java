package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX WARN: Enum visitor error
jadx.core.utils.exceptions.JadxRuntimeException: Init of enum field 'U8' uses external variables
	at jadx.core.dex.visitors.EnumVisitor.createEnumFieldByConstructor(EnumVisitor.java:485)
	at jadx.core.dex.visitors.EnumVisitor.processEnumFieldByField(EnumVisitor.java:399)
	at jadx.core.dex.visitors.EnumVisitor.processEnumFieldByWrappedInsn(EnumVisitor.java:364)
	at jadx.core.dex.visitors.EnumVisitor.extractEnumFieldsFromFilledArray(EnumVisitor.java:349)
	at jadx.core.dex.visitors.EnumVisitor.extractEnumFieldsFromInsn(EnumVisitor.java:284)
	at jadx.core.dex.visitors.EnumVisitor.extractEnumFieldsFromInvoke(EnumVisitor.java:315)
	at jadx.core.dex.visitors.EnumVisitor.extractEnumFieldsFromInsn(EnumVisitor.java:288)
	at jadx.core.dex.visitors.EnumVisitor.convertToEnum(EnumVisitor.java:153)
	at jadx.core.dex.visitors.EnumVisitor.visit(EnumVisitor.java:102)
 */
/* JADX WARN: Failed to restore enum class, 'enum' modifier and super class removed */
/* JADX INFO: loaded from: classes.dex */
public final class ImageDataType {
    private static final /* synthetic */ ImageDataType[] $VALUES;
    public static final ImageDataType F;
    public static final ImageDataType F32;
    public static final ImageDataType F64;
    public static final ImageDataType I;
    public static final ImageDataType I16;
    public static final ImageDataType I8;
    public static final ImageDataType S16;
    public static final ImageDataType S32;
    public static final ImageDataType S64;
    public static final ImageDataType S8;
    public static final ImageDataType U16;
    public static final ImageDataType U8;
    private final CreateArray createArray;
    private final Class dataType;
    private final boolean isAbstract;
    private final boolean isInteger;
    private final boolean isSigned;
    private final double maxValue;
    private final double minValue;
    private final int numBits;
    private final Class sumType;

    /* JADX INFO: Access modifiers changed from: private */
    interface CreateArray {
    }

    private static /* synthetic */ ImageDataType[] $values() {
        return new ImageDataType[]{U8, S8, U16, S16, S32, S64, F32, F64, I8, I16, I, F};
    }

    public static ImageDataType valueOf(String str) {
        return (ImageDataType) Enum.valueOf(ImageDataType.class, str);
    }

    public static ImageDataType[] values() {
        return (ImageDataType[]) $VALUES.clone();
    }

    static {
        ImageDataType$$ExternalSyntheticLambda0 imageDataType$$ExternalSyntheticLambda0 = new ImageDataType$$ExternalSyntheticLambda0();
        Class cls = Byte.TYPE;
        U8 = new ImageDataType("U8", 0, false, cls, imageDataType$$ExternalSyntheticLambda0);
        S8 = new ImageDataType("S8", 1, true, cls, new ImageDataType$$ExternalSyntheticLambda0());
        ImageDataType$$ExternalSyntheticLambda0 imageDataType$$ExternalSyntheticLambda1 = new ImageDataType$$ExternalSyntheticLambda0();
        Class cls2 = Short.TYPE;
        U16 = new ImageDataType("U16", 2, false, cls2, imageDataType$$ExternalSyntheticLambda1);
        S16 = new ImageDataType("S16", 3, true, cls2, new ImageDataType$$ExternalSyntheticLambda0());
        S32 = new ImageDataType("S32", 4, true, Integer.TYPE, new ImageDataType$$ExternalSyntheticLambda0());
        S64 = new ImageDataType("S64", 5, true, Long.TYPE, new ImageDataType$$ExternalSyntheticLambda0());
        F32 = new ImageDataType("F32", 6, true, Float.TYPE, new ImageDataType$$ExternalSyntheticLambda0());
        F64 = new ImageDataType("F64", 7, true, Double.TYPE, new ImageDataType$$ExternalSyntheticLambda0());
        I8 = new ImageDataType("I8", 8, cls);
        I16 = new ImageDataType("I16", 9, cls2);
        I = new ImageDataType("I", 10, true);
        F = new ImageDataType("F", 11, true);
        $VALUES = $values();
    }

    public int getNumBits() {
        return this.numBits;
    }

    public boolean isInteger() {
        return this.isInteger;
    }

    public Class getDataType() {
        return this.dataType;
    }

    private ImageDataType(String str, int i, boolean z) {
        super(str, i);
        this.isAbstract = true;
        this.isInteger = z;
        this.isSigned = false;
        this.numBits = -1;
        this.dataType = Object.class;
        this.sumType = Object.class;
        this.minValue = Double.NaN;
        this.maxValue = Double.NaN;
        this.createArray = new ImageDataType$$ExternalSyntheticLambda0();
    }

    private ImageDataType(String str, int i, Class cls) {
        super(str, i);
        this.isAbstract = true;
        this.dataType = cls;
        this.isSigned = false;
        this.numBits = selectNumBits(cls);
        this.isInteger = selectInteger(cls);
        this.sumType = selectSumType(cls);
        this.createArray = new ImageDataType$$ExternalSyntheticLambda0();
        this.minValue = Double.NaN;
        this.maxValue = Double.NaN;
    }

    private ImageDataType(String str, int i, boolean z, Class cls, CreateArray createArray) {
        super(str, i);
        this.isAbstract = false;
        this.isSigned = z;
        this.dataType = cls;
        this.createArray = createArray;
        this.numBits = selectNumBits(cls);
        this.isInteger = selectInteger(cls);
        this.sumType = selectSumType(cls);
        this.minValue = selectMinValue();
        this.maxValue = selectMaxValue();
    }

    public static ImageDataType classToType(Class cls) {
        if (GrayU8.class.isAssignableFrom(cls)) {
            return U8;
        }
        if (GrayS8.class.isAssignableFrom(cls)) {
            return S8;
        }
        if (GrayU16.class.isAssignableFrom(cls)) {
            return U16;
        }
        if (GrayS16.class.isAssignableFrom(cls)) {
            return S16;
        }
        if (GrayS32.class.isAssignableFrom(cls)) {
            return S32;
        }
        if (GrayS64.class.isAssignableFrom(cls)) {
            return S64;
        }
        if (GrayF32.class.isAssignableFrom(cls)) {
            return F32;
        }
        if (GrayF64.class.isAssignableFrom(cls)) {
            return F64;
        }
        if (GrayI8.class.isAssignableFrom(cls)) {
            return I8;
        }
        if (GrayI16.class.isAssignableFrom(cls)) {
            return I16;
        }
        if (GrayI.class.isAssignableFrom(cls)) {
            return I;
        }
        if (GrayF.class.isAssignableFrom(cls)) {
            return F;
        }
        if (InterleavedU8.class.isAssignableFrom(cls)) {
            return U8;
        }
        if (InterleavedS8.class.isAssignableFrom(cls)) {
            return S8;
        }
        if (InterleavedU16.class.isAssignableFrom(cls)) {
            return U16;
        }
        if (InterleavedS16.class.isAssignableFrom(cls)) {
            return S16;
        }
        if (InterleavedS32.class.isAssignableFrom(cls)) {
            return S32;
        }
        if (InterleavedS64.class.isAssignableFrom(cls)) {
            return S64;
        }
        if (InterleavedF32.class.isAssignableFrom(cls)) {
            return F32;
        }
        if (InterleavedF64.class.isAssignableFrom(cls)) {
            return F64;
        }
        if (InterleavedI8.class.isAssignableFrom(cls)) {
            return I8;
        }
        if (InterleavedI16.class.isAssignableFrom(cls)) {
            return I16;
        }
        throw new IllegalArgumentException("Unknown image type. class=" + cls.getCanonicalName());
    }

    private int selectNumBits(Class cls) {
        Class cls2 = Float.TYPE;
        if (cls == cls2 || cls == Double.TYPE) {
            return cls == cls2 ? 32 : 64;
        }
        if (cls == Byte.TYPE) {
            return 8;
        }
        if (cls == Short.TYPE) {
            return 16;
        }
        if (cls == Integer.TYPE) {
            return 32;
        }
        return cls == Long.TYPE ? 64 : -1;
    }

    private boolean selectInteger(Class cls) {
        return (cls == Float.TYPE || cls == Double.TYPE) ? false : true;
    }

    private Class selectSumType(Class cls) {
        if (cls == Float.TYPE || cls == Double.TYPE) {
            return cls;
        }
        if (this.numBits <= 32) {
            return Integer.TYPE;
        }
        return Long.TYPE;
    }

    private double selectMinValue() {
        boolean z = this.isInteger;
        if (z && !this.isSigned) {
            return 0.0d;
        }
        if (z) {
            int i = this.numBits;
            if (i == 8) {
                return -128.0d;
            }
            if (i == 16) {
                return -32768.0d;
            }
            if (i == 32) {
                return -2.147483648E9d;
            }
            if (i == 64) {
                return -9.223372036854776E18d;
            }
            throw new RuntimeException("Unexpected number of bits for integer type: " + this.numBits);
        }
        int i2 = this.numBits;
        if (i2 == 32) {
            return -3.4028234663852886E38d;
        }
        if (i2 == 64) {
            return -1.7976931348623157E308d;
        }
        throw new RuntimeException("Unexpected number of bits for float type: " + this.numBits);
    }

    private double selectMaxValue() {
        double d;
        double d2;
        if (this.isInteger) {
            int i = this.numBits;
            if (i == 8) {
                d = this.isSigned ? 0 : -128;
                d2 = 127.0d;
            } else if (i == 16) {
                d = this.isSigned ? 0 : -32768;
                d2 = 32767.0d;
            } else if (i == 32) {
                d = this.isSigned ? 0 : Integer.MIN_VALUE;
                d2 = 2.147483647E9d;
            } else if (i == 64) {
                d = this.isSigned ? 0L : Long.MIN_VALUE;
                d2 = 9.223372036854776E18d;
            } else {
                throw new RuntimeException("Unexpected number of bits for integer type: " + this.numBits);
            }
            return d2 - d;
        }
        int i2 = this.numBits;
        if (i2 == 32) {
            return 3.4028234663852886E38d;
        }
        if (i2 == 64) {
            return Double.MAX_VALUE;
        }
        throw new RuntimeException("Unexpected number of bits for float type: " + this.numBits);
    }
}
