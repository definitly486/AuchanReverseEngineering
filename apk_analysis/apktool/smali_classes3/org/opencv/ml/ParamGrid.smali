.class public Lorg/opencv/ml/ParamGrid;
.super Ljava/lang/Object;
.source "ParamGrid.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native create_0(DDD)J
.end method

.method private static native create_1(DD)J
.end method

.method private static native create_2(D)J
.end method

.method private static native create_3()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_logStep_0(J)D
.end method

.method private static native get_maxVal_0(J)D
.end method

.method private static native get_minVal_0(J)D
.end method

.method private static native set_logStep_0(JD)V
.end method

.method private static native set_maxVal_0(JD)V
.end method

.method private static native set_minVal_0(JD)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 128
    iget-wide v0, p0, Lorg/opencv/ml/ParamGrid;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/ml/ParamGrid;->delete(J)V

    return-void
.end method
