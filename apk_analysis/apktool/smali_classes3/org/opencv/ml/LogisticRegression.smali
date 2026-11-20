.class public Lorg/opencv/ml/LogisticRegression;
.super Lorg/opencv/ml/StatModel;
.source "LogisticRegression.java"


# direct methods
.method private static native create_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native getIterations_0(J)I
.end method

.method private static native getLearningRate_0(J)D
.end method

.method private static native getMiniBatchSize_0(J)I
.end method

.method private static native getRegularization_0(J)I
.end method

.method private static native getTermCriteria_0(J)[D
.end method

.method private static native getTrainMethod_0(J)I
.end method

.method private static native get_learnt_thetas_0(J)J
.end method

.method private static native load_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native load_1(Ljava/lang/String;)J
.end method

.method private static native predict_0(JJJI)F
.end method

.method private static native predict_1(JJJ)F
.end method

.method private static native predict_2(JJ)F
.end method

.method private static native setIterations_0(JI)V
.end method

.method private static native setLearningRate_0(JD)V
.end method

.method private static native setMiniBatchSize_0(JI)V
.end method

.method private static native setRegularization_0(JI)V
.end method

.method private static native setTermCriteria_0(JIID)V
.end method

.method private static native setTrainMethod_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 301
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/ml/LogisticRegression;->delete(J)V

    return-void
.end method
