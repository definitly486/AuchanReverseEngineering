.class public Lorg/opencv/ml/EM;
.super Lorg/opencv/ml/StatModel;
.source "EM.java"


# direct methods
.method private static native create_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native getClustersNumber_0(J)I
.end method

.method private static native getCovarianceMatrixType_0(J)I
.end method

.method private static native getCovs_0(JJ)V
.end method

.method private static native getMeans_0(J)J
.end method

.method private static native getTermCriteria_0(J)[D
.end method

.method private static native getWeights_0(J)J
.end method

.method private static native load_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native load_1(Ljava/lang/String;)J
.end method

.method private static native predict2_0(JJJ)[D
.end method

.method private static native predict_0(JJJI)F
.end method

.method private static native predict_1(JJJ)F
.end method

.method private static native predict_2(JJ)F
.end method

.method private static native setClustersNumber_0(JI)V
.end method

.method private static native setCovarianceMatrixType_0(JI)V
.end method

.method private static native setTermCriteria_0(JIID)V
.end method

.method private static native trainEM_0(JJJJJ)Z
.end method

.method private static native trainEM_1(JJJJ)Z
.end method

.method private static native trainEM_2(JJJ)Z
.end method

.method private static native trainEM_3(JJ)Z
.end method

.method private static native trainE_0(JJJJJJJJ)Z
.end method

.method private static native trainE_1(JJJJJJJ)Z
.end method

.method private static native trainE_2(JJJJJJ)Z
.end method

.method private static native trainE_3(JJJJJ)Z
.end method

.method private static native trainE_4(JJJJ)Z
.end method

.method private static native trainE_5(JJJ)Z
.end method

.method private static native trainM_0(JJJJJJ)Z
.end method

.method private static native trainM_1(JJJJJ)Z
.end method

.method private static native trainM_2(JJJJ)Z
.end method

.method private static native trainM_3(JJJ)Z
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 705
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/ml/EM;->delete(J)V

    return-void
.end method
