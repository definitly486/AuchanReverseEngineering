package com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.GlobalBinaryFilter;
import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.GlobalFixedBinaryFilter;
import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary;
import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinarySwitch;
import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.LocalGaussianBinaryFilter;
import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.LocalMeanBinaryFilter;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlockOtsu;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock_MT;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdLocalOtsu;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdLocalOtsu_MT;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily_MT;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNick;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ThresholdBlockMean_F32;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ThresholdBlockMean_U8;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ThresholdBlockMinMax_F32;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ThresholdBlockMinMax_U8;
import com.scanflow.datacapture.barinternal.boofcv.concurrency.BoofConcurrency;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryThresholdBinary {
    public static InputToBinary localGaussian(ConfigLength configLength, double d, boolean z, Class cls) {
        int i = BOverrideFactoryThresholdBinary.$r8$clinit;
        return new LocalGaussianBinaryFilter(configLength, d, z, ImageType.single(cls));
    }

    public static InputToBinary localSauvola(ConfigLength configLength, boolean z, float f, Class cls) {
        return localNiblackFamily(ThresholdNiblackFamily.Variant.SAUVOLA, configLength, z, f, cls);
    }

    public static InputToBinary localWolf(ConfigLength configLength, boolean z, float f, Class cls) {
        return localNiblackFamily(ThresholdNiblackFamily.Variant.WOLF_JOLION, configLength, z, f, cls);
    }

    public static InputToBinary localNiblack(ConfigLength configLength, boolean z, float f, Class cls) {
        return localNiblackFamily(ThresholdNiblackFamily.Variant.NIBLACK, configLength, z, f, cls);
    }

    protected static InputToBinary localNiblackFamily(ThresholdNiblackFamily.Variant variant, ConfigLength configLength, boolean z, float f, Class cls) {
        InputToBinary thresholdNiblackFamily;
        int i = BOverrideFactoryThresholdBinary.$r8$clinit;
        if (BoofConcurrency.USE_CONCURRENT) {
            thresholdNiblackFamily = new ThresholdNiblackFamily_MT(configLength, f, z, variant);
        } else {
            thresholdNiblackFamily = new ThresholdNiblackFamily(configLength, f, z, variant);
        }
        return new InputToBinarySwitch(thresholdNiblackFamily, cls);
    }

    public static InputToBinary localNick(ConfigLength configLength, boolean z, float f, Class cls) {
        return new InputToBinarySwitch(new ThresholdNick(configLength, f, z), cls);
    }

    public static InputToBinary localMean(ConfigLength configLength, double d, boolean z, Class cls) {
        int i = BOverrideFactoryThresholdBinary.$r8$clinit;
        return new LocalMeanBinaryFilter(configLength, d, z, ImageType.single(cls));
    }

    public static InputToBinary localOtsu(ConfigLength configLength, double d, boolean z, boolean z2, double d2, Class cls) {
        ThresholdLocalOtsu thresholdLocalOtsu;
        int i = BOverrideFactoryThresholdBinary.$r8$clinit;
        if (BoofConcurrency.USE_CONCURRENT) {
            thresholdLocalOtsu = new ThresholdLocalOtsu_MT(z2, configLength, d2, d, z);
        } else {
            thresholdLocalOtsu = new ThresholdLocalOtsu(z2, configLength, d2, d, z);
        }
        return new InputToBinarySwitch(thresholdLocalOtsu, cls);
    }

    public static InputToBinary blockMinMax(ConfigLength configLength, double d, boolean z, boolean z2, double d2, Class cls) {
        ThresholdBlock.BlockProcessor thresholdBlockMinMax_F32;
        int i = BOverrideFactoryThresholdBinary.$r8$clinit;
        if (cls == GrayU8.class) {
            thresholdBlockMinMax_F32 = new ThresholdBlockMinMax_U8(d2, d, z);
        } else {
            thresholdBlockMinMax_F32 = new ThresholdBlockMinMax_F32((float) d2, (float) d, z);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            return new ThresholdBlock_MT(thresholdBlockMinMax_F32, configLength, z2, cls);
        }
        return new ThresholdBlock(thresholdBlockMinMax_F32, configLength, z2, cls);
    }

    public static InputToBinary blockMean(ConfigLength configLength, double d, boolean z, boolean z2, Class cls) {
        ThresholdBlock.BlockProcessor thresholdBlockMean_F32;
        int i = BOverrideFactoryThresholdBinary.$r8$clinit;
        if (cls == GrayU8.class) {
            thresholdBlockMean_F32 = new ThresholdBlockMean_U8(d, z);
        } else {
            thresholdBlockMean_F32 = new ThresholdBlockMean_F32((float) d, z);
        }
        if (BoofConcurrency.USE_CONCURRENT) {
            return new ThresholdBlock_MT(thresholdBlockMean_F32, configLength, z2, cls);
        }
        return new ThresholdBlock(thresholdBlockMean_F32, configLength, z2, cls);
    }

    public static InputToBinary blockOtsu(ConfigLength configLength, double d, boolean z, boolean z2, boolean z3, double d2, Class cls) {
        InputToBinary thresholdBlock;
        int i = BOverrideFactoryThresholdBinary.$r8$clinit;
        ThresholdBlockOtsu thresholdBlockOtsu = new ThresholdBlockOtsu(z3, d2, d, z);
        if (BoofConcurrency.USE_CONCURRENT) {
            thresholdBlock = new ThresholdBlock_MT(thresholdBlockOtsu, configLength, z2, GrayU8.class);
        } else {
            thresholdBlock = new ThresholdBlock(thresholdBlockOtsu, configLength, z2, GrayU8.class);
        }
        return new InputToBinarySwitch(thresholdBlock, cls);
    }

    public static InputToBinary globalEntropy(int i, int i2, double d, boolean z, Class cls) {
        int i3 = BOverrideFactoryThresholdBinary.$r8$clinit;
        return new GlobalBinaryFilter.Entropy(i, i2, d, z, ImageType.single(cls));
    }

    public static InputToBinary globalFixed(double d, boolean z, Class cls) {
        int i = BOverrideFactoryThresholdBinary.$r8$clinit;
        return new GlobalFixedBinaryFilter(d, z, ImageType.single(cls));
    }

    public static InputToBinary globalOtsu(double d, double d2, double d3, boolean z, Class cls) {
        int i = BOverrideFactoryThresholdBinary.$r8$clinit;
        return new GlobalBinaryFilter.Otsu(d, d2, d3, z, ImageType.single(cls));
    }

    public static InputToBinary globalLi(double d, double d2, double d3, boolean z, Class cls) {
        return new GlobalBinaryFilter.Li(d, d2, d3, z, ImageType.single(cls));
    }

    public static InputToBinary globalHuang(double d, double d2, double d3, boolean z, Class cls) {
        return new GlobalBinaryFilter.Huang(d, d2, d3, z, ImageType.single(cls));
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary.FactoryThresholdBinary$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$boofcv$factory$filter$binary$ThresholdType;

        static {
            int[] iArr = new int[ThresholdType.values().length];
            $SwitchMap$boofcv$factory$filter$binary$ThresholdType = iArr;
            try {
                iArr[ThresholdType.FIXED.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.GLOBAL_OTSU.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.GLOBAL_ENTROPY.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.GLOBAL_LI.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.GLOBAL_HUANG.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.LOCAL_GAUSSIAN.ordinal()] = 6;
            } catch (NoSuchFieldError unused6) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.LOCAL_NIBLACK.ordinal()] = 7;
            } catch (NoSuchFieldError unused7) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.LOCAL_SAVOLA.ordinal()] = 8;
            } catch (NoSuchFieldError unused8) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.LOCAL_WOLF.ordinal()] = 9;
            } catch (NoSuchFieldError unused9) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.LOCAL_NICK.ordinal()] = 10;
            } catch (NoSuchFieldError unused10) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.LOCAL_MEAN.ordinal()] = 11;
            } catch (NoSuchFieldError unused11) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.LOCAL_OTSU.ordinal()] = 12;
            } catch (NoSuchFieldError unused12) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.BLOCK_MIN_MAX.ordinal()] = 13;
            } catch (NoSuchFieldError unused13) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.BLOCK_MEAN.ordinal()] = 14;
            } catch (NoSuchFieldError unused14) {
            }
            try {
                $SwitchMap$boofcv$factory$filter$binary$ThresholdType[ThresholdType.BLOCK_OTSU.ordinal()] = 15;
            } catch (NoSuchFieldError unused15) {
            }
        }
    }

    public static InputToBinary threshold(ConfigThreshold configThreshold, Class cls) {
        switch (AnonymousClass1.$SwitchMap$boofcv$factory$filter$binary$ThresholdType[configThreshold.type.ordinal()]) {
            case 1:
                return globalFixed(configThreshold.fixedThreshold, configThreshold.down, cls);
            case 2:
                return globalOtsu(configThreshold.minPixelValue, configThreshold.maxPixelValue, configThreshold.scale, configThreshold.down, cls);
            case 3:
                return globalEntropy(configThreshold.minPixelValue, configThreshold.maxPixelValue, configThreshold.scale, configThreshold.down, cls);
            case 4:
                return globalLi(configThreshold.minPixelValue, configThreshold.maxPixelValue, configThreshold.scale, configThreshold.down, cls);
            case 5:
                return globalHuang(configThreshold.minPixelValue, configThreshold.maxPixelValue, configThreshold.scale, configThreshold.down, cls);
            case 6:
                return localGaussian(configThreshold.width, configThreshold.scale, configThreshold.down, cls);
            case 7:
                return localNiblack(configThreshold.width, configThreshold.down, configThreshold.niblackK, cls);
            case 8:
                return localSauvola(configThreshold.width, configThreshold.down, configThreshold.niblackK, cls);
            case 9:
                return localWolf(configThreshold.width, configThreshold.down, configThreshold.niblackK, cls);
            case 10:
                return localNick(configThreshold.width, configThreshold.down, configThreshold.nickK, cls);
            case 11:
                return localMean(configThreshold.width, configThreshold.scale, configThreshold.down, cls);
            case 12:
                ConfigThresholdLocalOtsu configThresholdLocalOtsu = (ConfigThresholdLocalOtsu) configThreshold;
                return localOtsu(configThreshold.width, configThreshold.scale, configThreshold.down, configThresholdLocalOtsu.useOtsu2, configThresholdLocalOtsu.tuning, cls);
            case 13:
                ConfigThresholdBlockMinMax configThresholdBlockMinMax = (ConfigThresholdBlockMinMax) configThreshold;
                return blockMinMax(configThresholdBlockMinMax.width, configThresholdBlockMinMax.scale, configThresholdBlockMinMax.down, configThresholdBlockMinMax.thresholdFromLocalBlocks, configThresholdBlockMinMax.minimumSpread, cls);
            case 14:
                return blockMean(configThreshold.width, configThreshold.scale, configThreshold.down, configThreshold.thresholdFromLocalBlocks, cls);
            case 15:
                ConfigThresholdLocalOtsu configThresholdLocalOtsu2 = (ConfigThresholdLocalOtsu) configThreshold;
                return blockOtsu(configThresholdLocalOtsu2.width, configThresholdLocalOtsu2.scale, configThresholdLocalOtsu2.down, configThresholdLocalOtsu2.thresholdFromLocalBlocks, configThresholdLocalOtsu2.useOtsu2, configThresholdLocalOtsu2.tuning, cls);
            default:
                throw new IncompatibleClassChangeError();
        }
    }
}
