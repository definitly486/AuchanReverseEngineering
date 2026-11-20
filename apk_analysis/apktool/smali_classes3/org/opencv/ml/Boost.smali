.class public Lorg/opencv/ml/Boost;
.super Lorg/opencv/ml/DTrees;
.source "Boost.java"


# direct methods
.method private static native create_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native getBoostType_0(J)I
.end method

.method private static native getWeakCount_0(J)I
.end method

.method private static native getWeightTrimRate_0(J)D
.end method

.method private static native load_0(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native load_1(Ljava/lang/String;)J
.end method

.method private static native setBoostType_0(JI)V
.end method

.method private static native setWeakCount_0(JI)V
.end method

.method private static native setWeightTrimRate_0(JD)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 158
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/ml/Boost;->delete(J)V

    return-void
.end method
