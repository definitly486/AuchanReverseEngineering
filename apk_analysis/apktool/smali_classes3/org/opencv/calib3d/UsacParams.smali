.class public Lorg/opencv/calib3d/UsacParams;
.super Ljava/lang/Object;
.source "UsacParams.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native UsacParams_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_confidence_0(J)D
.end method

.method private static native get_final_polisher_0(J)I
.end method

.method private static native get_final_polisher_iterations_0(J)I
.end method

.method private static native get_isParallel_0(J)Z
.end method

.method private static native get_loIterations_0(J)I
.end method

.method private static native get_loMethod_0(J)I
.end method

.method private static native get_loSampleSize_0(J)I
.end method

.method private static native get_maxIterations_0(J)I
.end method

.method private static native get_neighborsSearch_0(J)I
.end method

.method private static native get_randomGeneratorState_0(J)I
.end method

.method private static native get_sampler_0(J)I
.end method

.method private static native get_score_0(J)I
.end method

.method private static native get_threshold_0(J)D
.end method

.method private static native set_confidence_0(JD)V
.end method

.method private static native set_final_polisher_0(JI)V
.end method

.method private static native set_final_polisher_iterations_0(JI)V
.end method

.method private static native set_isParallel_0(JZ)V
.end method

.method private static native set_loIterations_0(JI)V
.end method

.method private static native set_loMethod_0(JI)V
.end method

.method private static native set_loSampleSize_0(JI)V
.end method

.method private static native set_maxIterations_0(JI)V
.end method

.method private static native set_neighborsSearch_0(JI)V
.end method

.method private static native set_randomGeneratorState_0(JI)V
.end method

.method private static native set_sampler_0(JI)V
.end method

.method private static native set_score_0(JI)V
.end method

.method private static native set_threshold_0(JD)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 265
    iget-wide v0, p0, Lorg/opencv/calib3d/UsacParams;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/calib3d/UsacParams;->delete(J)V

    return-void
.end method
