.class public Lorg/opencv/features2d/BOWKMeansTrainer;
.super Lorg/opencv/features2d/BOWTrainer;
.source "BOWKMeansTrainer.java"


# direct methods
.method private static native BOWKMeansTrainer_0(IIIDII)J
.end method

.method private static native BOWKMeansTrainer_1(IIIDI)J
.end method

.method private static native BOWKMeansTrainer_2(IIID)J
.end method

.method private static native BOWKMeansTrainer_3(I)J
.end method

.method private static native cluster_0(J)J
.end method

.method private static native cluster_1(JJ)J
.end method

.method private static native delete(J)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 92
    iget-wide v0, p0, Lorg/opencv/features2d/BOWTrainer;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/BOWKMeansTrainer;->delete(J)V

    return-void
.end method
