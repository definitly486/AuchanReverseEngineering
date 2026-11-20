package org.opencv.ml;

import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class TrainData {
    protected final long nativeObj;

    private static native long create_0(long j, int i, long j2, long j3, long j4, long j5, long j6);

    private static native long create_1(long j, int i, long j2, long j3, long j4, long j5);

    private static native long create_2(long j, int i, long j2, long j3, long j4);

    private static native long create_3(long j, int i, long j2, long j3);

    private static native long create_4(long j, int i, long j2);

    private static native void delete(long j);

    private static native int getCatCount_0(long j, int i);

    private static native long getCatMap_0(long j);

    private static native long getCatOfs_0(long j);

    private static native long getClassLabels_0(long j);

    private static native long getDefaultSubstValues_0(long j);

    private static native int getLayout_0(long j);

    private static native long getMissing_0(long j);

    private static native int getNAllVars_0(long j);

    private static native int getNSamples_0(long j);

    private static native int getNTestSamples_0(long j);

    private static native int getNTrainSamples_0(long j);

    private static native int getNVars_0(long j);

    private static native void getNames_0(long j, List<String> list);

    private static native long getNormCatResponses_0(long j);

    private static native int getResponseType_0(long j);

    private static native long getResponses_0(long j);

    private static native long getSampleWeights_0(long j);

    private static native void getSample_0(long j, long j2, int i, float f);

    private static native long getSamples_0(long j);

    private static native long getSubMatrix_0(long j, long j2, int i);

    private static native long getSubVector_0(long j, long j2);

    private static native long getTestNormCatResponses_0(long j);

    private static native long getTestResponses_0(long j);

    private static native long getTestSampleIdx_0(long j);

    private static native long getTestSampleWeights_0(long j);

    private static native long getTestSamples_0(long j);

    private static native long getTrainNormCatResponses_0(long j);

    private static native long getTrainResponses_0(long j);

    private static native long getTrainSampleIdx_0(long j);

    private static native long getTrainSampleWeights_0(long j);

    private static native long getTrainSamples_0(long j, int i, boolean z, boolean z2);

    private static native long getTrainSamples_1(long j, int i, boolean z);

    private static native long getTrainSamples_2(long j, int i);

    private static native long getTrainSamples_3(long j);

    private static native void getValues_0(long j, int i, long j2, float f);

    private static native long getVarIdx_0(long j);

    private static native long getVarSymbolFlags_0(long j);

    private static native long getVarType_0(long j);

    private static native void setTrainTestSplitRatio_0(long j, double d, boolean z);

    private static native void setTrainTestSplitRatio_1(long j, double d);

    private static native void setTrainTestSplit_0(long j, int i, boolean z);

    private static native void setTrainTestSplit_1(long j, int i);

    private static native void shuffleTrainTest_0(long j);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
