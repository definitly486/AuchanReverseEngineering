package org.opencv.photo;

/* JADX INFO: loaded from: classes3.dex */
public class Photo {
    private static native void colorChange_0(long j, long j2, long j3, float f, float f2, float f3);

    private static native void colorChange_1(long j, long j2, long j3, float f, float f2);

    private static native void colorChange_2(long j, long j2, long j3, float f);

    private static native void colorChange_3(long j, long j2, long j3);

    private static native long createAlignMTB_0(int i, int i2, boolean z);

    private static native long createAlignMTB_1(int i, int i2);

    private static native long createAlignMTB_2(int i);

    private static native long createAlignMTB_3();

    private static native long createCalibrateDebevec_0(int i, float f, boolean z);

    private static native long createCalibrateDebevec_1(int i, float f);

    private static native long createCalibrateDebevec_2(int i);

    private static native long createCalibrateDebevec_3();

    private static native long createCalibrateRobertson_0(int i, float f);

    private static native long createCalibrateRobertson_1(int i);

    private static native long createCalibrateRobertson_2();

    private static native long createMergeDebevec_0();

    private static native long createMergeMertens_0(float f, float f2, float f3);

    private static native long createMergeMertens_1(float f, float f2);

    private static native long createMergeMertens_2(float f);

    private static native long createMergeMertens_3();

    private static native long createMergeRobertson_0();

    private static native long createTonemapDrago_0(float f, float f2, float f3);

    private static native long createTonemapDrago_1(float f, float f2);

    private static native long createTonemapDrago_2(float f);

    private static native long createTonemapDrago_3();

    private static native long createTonemapMantiuk_0(float f, float f2, float f3);

    private static native long createTonemapMantiuk_1(float f, float f2);

    private static native long createTonemapMantiuk_2(float f);

    private static native long createTonemapMantiuk_3();

    private static native long createTonemapReinhard_0(float f, float f2, float f3, float f4);

    private static native long createTonemapReinhard_1(float f, float f2, float f3);

    private static native long createTonemapReinhard_2(float f, float f2);

    private static native long createTonemapReinhard_3(float f);

    private static native long createTonemapReinhard_4();

    private static native long createTonemap_0(float f);

    private static native long createTonemap_1();

    private static native void decolor_0(long j, long j2, long j3);

    private static native void denoise_TVL1_0(long j, long j2, double d, int i);

    private static native void denoise_TVL1_1(long j, long j2, double d);

    private static native void denoise_TVL1_2(long j, long j2);

    private static native void detailEnhance_0(long j, long j2, float f, float f2);

    private static native void detailEnhance_1(long j, long j2, float f);

    private static native void detailEnhance_2(long j, long j2);

    private static native void edgePreservingFilter_0(long j, long j2, int i, float f, float f2);

    private static native void edgePreservingFilter_1(long j, long j2, int i, float f);

    private static native void edgePreservingFilter_2(long j, long j2, int i);

    private static native void edgePreservingFilter_3(long j, long j2);

    private static native void fastNlMeansDenoisingColoredMulti_0(long j, long j2, int i, int i2, float f, float f2, int i3, int i4);

    private static native void fastNlMeansDenoisingColoredMulti_1(long j, long j2, int i, int i2, float f, float f2, int i3);

    private static native void fastNlMeansDenoisingColoredMulti_2(long j, long j2, int i, int i2, float f, float f2);

    private static native void fastNlMeansDenoisingColoredMulti_3(long j, long j2, int i, int i2, float f);

    private static native void fastNlMeansDenoisingColoredMulti_4(long j, long j2, int i, int i2);

    private static native void fastNlMeansDenoisingColored_0(long j, long j2, float f, float f2, int i, int i2);

    private static native void fastNlMeansDenoisingColored_1(long j, long j2, float f, float f2, int i);

    private static native void fastNlMeansDenoisingColored_2(long j, long j2, float f, float f2);

    private static native void fastNlMeansDenoisingColored_3(long j, long j2, float f);

    private static native void fastNlMeansDenoisingColored_4(long j, long j2);

    private static native void fastNlMeansDenoisingMulti_0(long j, long j2, int i, int i2, float f, int i3, int i4);

    private static native void fastNlMeansDenoisingMulti_1(long j, long j2, int i, int i2, float f, int i3);

    private static native void fastNlMeansDenoisingMulti_2(long j, long j2, int i, int i2, float f);

    private static native void fastNlMeansDenoisingMulti_3(long j, long j2, int i, int i2);

    private static native void fastNlMeansDenoisingMulti_4(long j, long j2, int i, int i2, long j3, int i3, int i4, int i5);

    private static native void fastNlMeansDenoisingMulti_5(long j, long j2, int i, int i2, long j3, int i3, int i4);

    private static native void fastNlMeansDenoisingMulti_6(long j, long j2, int i, int i2, long j3, int i3);

    private static native void fastNlMeansDenoisingMulti_7(long j, long j2, int i, int i2, long j3);

    private static native void fastNlMeansDenoising_0(long j, long j2, float f, int i, int i2);

    private static native void fastNlMeansDenoising_1(long j, long j2, float f, int i);

    private static native void fastNlMeansDenoising_2(long j, long j2, float f);

    private static native void fastNlMeansDenoising_3(long j, long j2);

    private static native void fastNlMeansDenoising_4(long j, long j2, long j3, int i, int i2, int i3);

    private static native void fastNlMeansDenoising_5(long j, long j2, long j3, int i, int i2);

    private static native void fastNlMeansDenoising_6(long j, long j2, long j3, int i);

    private static native void fastNlMeansDenoising_7(long j, long j2, long j3);

    private static native void illuminationChange_0(long j, long j2, long j3, float f, float f2);

    private static native void illuminationChange_1(long j, long j2, long j3, float f);

    private static native void illuminationChange_2(long j, long j2, long j3);

    private static native void inpaint_0(long j, long j2, long j3, double d, int i);

    private static native void pencilSketch_0(long j, long j2, long j3, float f, float f2, float f3);

    private static native void pencilSketch_1(long j, long j2, long j3, float f, float f2);

    private static native void pencilSketch_2(long j, long j2, long j3, float f);

    private static native void pencilSketch_3(long j, long j2, long j3);

    private static native void seamlessClone_0(long j, long j2, long j3, double d, double d2, long j4, int i);

    private static native void stylization_0(long j, long j2, float f, float f2);

    private static native void stylization_1(long j, long j2, float f);

    private static native void stylization_2(long j, long j2);

    private static native void textureFlattening_0(long j, long j2, long j3, float f, float f2, int i);

    private static native void textureFlattening_1(long j, long j2, long j3, float f, float f2);

    private static native void textureFlattening_2(long j, long j2, long j3, float f);

    private static native void textureFlattening_3(long j, long j2, long j3);
}
