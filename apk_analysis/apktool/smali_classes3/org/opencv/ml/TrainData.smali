.class public Lorg/opencv/ml/TrainData;
.super Ljava/lang/Object;
.source "TrainData.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native create_0(JIJJJJJ)J
.end method

.method private static native create_1(JIJJJJ)J
.end method

.method private static native create_2(JIJJJ)J
.end method

.method private static native create_3(JIJJ)J
.end method

.method private static native create_4(JIJ)J
.end method

.method private static native delete(J)V
.end method

.method private static native getCatCount_0(JI)I
.end method

.method private static native getCatMap_0(J)J
.end method

.method private static native getCatOfs_0(J)J
.end method

.method private static native getClassLabels_0(J)J
.end method

.method private static native getDefaultSubstValues_0(J)J
.end method

.method private static native getLayout_0(J)I
.end method

.method private static native getMissing_0(J)J
.end method

.method private static native getNAllVars_0(J)I
.end method

.method private static native getNSamples_0(J)I
.end method

.method private static native getNTestSamples_0(J)I
.end method

.method private static native getNTrainSamples_0(J)I
.end method

.method private static native getNVars_0(J)I
.end method

.method private static native getNames_0(JLjava/util/List;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(J",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation
.end method

.method private static native getNormCatResponses_0(J)J
.end method

.method private static native getResponseType_0(J)I
.end method

.method private static native getResponses_0(J)J
.end method

.method private static native getSampleWeights_0(J)J
.end method

.method private static native getSample_0(JJIF)V
.end method

.method private static native getSamples_0(J)J
.end method

.method private static native getSubMatrix_0(JJI)J
.end method

.method private static native getSubVector_0(JJ)J
.end method

.method private static native getTestNormCatResponses_0(J)J
.end method

.method private static native getTestResponses_0(J)J
.end method

.method private static native getTestSampleIdx_0(J)J
.end method

.method private static native getTestSampleWeights_0(J)J
.end method

.method private static native getTestSamples_0(J)J
.end method

.method private static native getTrainNormCatResponses_0(J)J
.end method

.method private static native getTrainResponses_0(J)J
.end method

.method private static native getTrainSampleIdx_0(J)J
.end method

.method private static native getTrainSampleWeights_0(J)J
.end method

.method private static native getTrainSamples_0(JIZZ)J
.end method

.method private static native getTrainSamples_1(JIZ)J
.end method

.method private static native getTrainSamples_2(JI)J
.end method

.method private static native getTrainSamples_3(J)J
.end method

.method private static native getValues_0(JIJF)V
.end method

.method private static native getVarIdx_0(J)J
.end method

.method private static native getVarSymbolFlags_0(J)J
.end method

.method private static native getVarType_0(J)J
.end method

.method private static native setTrainTestSplitRatio_0(JDZ)V
.end method

.method private static native setTrainTestSplitRatio_1(JD)V
.end method

.method private static native setTrainTestSplit_0(JIZ)V
.end method

.method private static native setTrainTestSplit_1(JI)V
.end method

.method private static native shuffleTrainTest_0(J)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 641
    iget-wide v0, p0, Lorg/opencv/ml/TrainData;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/ml/TrainData;->delete(J)V

    return-void
.end method
