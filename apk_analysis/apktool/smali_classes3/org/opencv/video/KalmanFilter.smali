.class public Lorg/opencv/video/KalmanFilter;
.super Ljava/lang/Object;
.source "KalmanFilter.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native KalmanFilter_0()J
.end method

.method private static native KalmanFilter_1(IIII)J
.end method

.method private static native KalmanFilter_2(III)J
.end method

.method private static native KalmanFilter_3(II)J
.end method

.method private static native correct_0(JJ)J
.end method

.method private static native delete(J)V
.end method

.method private static native get_controlMatrix_0(J)J
.end method

.method private static native get_errorCovPost_0(J)J
.end method

.method private static native get_errorCovPre_0(J)J
.end method

.method private static native get_gain_0(J)J
.end method

.method private static native get_measurementMatrix_0(J)J
.end method

.method private static native get_measurementNoiseCov_0(J)J
.end method

.method private static native get_processNoiseCov_0(J)J
.end method

.method private static native get_statePost_0(J)J
.end method

.method private static native get_statePre_0(J)J
.end method

.method private static native get_transitionMatrix_0(J)J
.end method

.method private static native predict_0(JJ)J
.end method

.method private static native predict_1(J)J
.end method

.method private static native set_controlMatrix_0(JJ)V
.end method

.method private static native set_errorCovPost_0(JJ)V
.end method

.method private static native set_errorCovPre_0(JJ)V
.end method

.method private static native set_gain_0(JJ)V
.end method

.method private static native set_measurementMatrix_0(JJ)V
.end method

.method private static native set_measurementNoiseCov_0(JJ)V
.end method

.method private static native set_processNoiseCov_0(JJ)V
.end method

.method private static native set_statePost_0(JJ)V
.end method

.method private static native set_statePre_0(JJ)V
.end method

.method private static native set_transitionMatrix_0(JJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 293
    iget-wide v0, p0, Lorg/opencv/video/KalmanFilter;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/KalmanFilter;->delete(J)V

    return-void
.end method
