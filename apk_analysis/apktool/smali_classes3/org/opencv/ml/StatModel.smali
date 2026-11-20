.class public Lorg/opencv/ml/StatModel;
.super Lorg/opencv/core/Algorithm;
.source "StatModel.java"


# direct methods
.method private static native calcError_0(JJZJ)F
.end method

.method private static native delete(J)V
.end method

.method private static native empty_0(J)Z
.end method

.method private static native getVarCount_0(J)I
.end method

.method private static native isClassifier_0(J)Z
.end method

.method private static native isTrained_0(J)Z
.end method

.method private static native predict_0(JJJI)F
.end method

.method private static native predict_1(JJJ)F
.end method

.method private static native predict_2(JJ)F
.end method

.method private static native train_0(JJI)Z
.end method

.method private static native train_1(JJ)Z
.end method

.method private static native train_2(JJIJ)Z
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 188
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/ml/StatModel;->delete(J)V

    return-void
.end method
