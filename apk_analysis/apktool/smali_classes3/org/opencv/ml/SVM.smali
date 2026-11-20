.class public Lorg/opencv/ml/SVM;
.super Lorg/opencv/ml/StatModel;
.source "SVM.java"


# direct methods
.method private static native create_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native getC_0(J)D
.end method

.method private static native getClassWeights_0(J)J
.end method

.method private static native getCoef0_0(J)D
.end method

.method private static native getDecisionFunction_0(JIJJ)D
.end method

.method private static native getDefaultGridPtr_0(I)J
.end method

.method private static native getDegree_0(J)D
.end method

.method private static native getGamma_0(J)D
.end method

.method private static native getKernelType_0(J)I
.end method

.method private static native getNu_0(J)D
.end method

.method private static native getP_0(J)D
.end method

.method private static native getSupportVectors_0(J)J
.end method

.method private static native getTermCriteria_0(J)[D
.end method

.method private static native getType_0(J)I
.end method

.method private static native getUncompressedSupportVectors_0(J)J
.end method

.method private static native load_0(Ljava/lang/String;)J
.end method

.method private static native setC_0(JD)V
.end method

.method private static native setClassWeights_0(JJ)V
.end method

.method private static native setCoef0_0(JD)V
.end method

.method private static native setDegree_0(JD)V
.end method

.method private static native setGamma_0(JD)V
.end method

.method private static native setKernel_0(JI)V
.end method

.method private static native setNu_0(JD)V
.end method

.method private static native setP_0(JD)V
.end method

.method private static native setTermCriteria_0(JIID)V
.end method

.method private static native setType_0(JI)V
.end method

.method private static native trainAuto_0(JJIJIJJJJJJZ)Z
.end method

.method private static native trainAuto_1(JJIJIJJJJJJ)Z
.end method

.method private static native trainAuto_2(JJIJIJJJJJ)Z
.end method

.method private static native trainAuto_3(JJIJIJJJJ)Z
.end method

.method private static native trainAuto_4(JJIJIJJJ)Z
.end method

.method private static native trainAuto_5(JJIJIJJ)Z
.end method

.method private static native trainAuto_6(JJIJIJ)Z
.end method

.method private static native trainAuto_7(JJIJI)Z
.end method

.method private static native trainAuto_8(JJIJ)Z
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 705
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/ml/SVM;->delete(J)V

    return-void
.end method
