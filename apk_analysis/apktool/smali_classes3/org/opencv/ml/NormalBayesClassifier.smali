.class public Lorg/opencv/ml/NormalBayesClassifier;
.super Lorg/opencv/ml/StatModel;
.source "NormalBayesClassifier.java"


# direct methods
.method private static native create_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native load_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native load_1(Ljava/lang/String;)J
.end method

.method private static native predictProb_0(JJJJI)F
.end method

.method private static native predictProb_1(JJJJ)F
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 113
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/ml/NormalBayesClassifier;->delete(J)V

    return-void
.end method
