.class public Lorg/opencv/objdetect/CharucoParameters;
.super Ljava/lang/Object;
.source "CharucoParameters.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native CharucoParameters_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_cameraMatrix_0(J)J
.end method

.method private static native get_checkMarkers_0(J)Z
.end method

.method private static native get_distCoeffs_0(J)J
.end method

.method private static native get_minMarkers_0(J)I
.end method

.method private static native get_tryRefineMarkers_0(J)Z
.end method

.method private static native set_cameraMatrix_0(JJ)V
.end method

.method private static native set_checkMarkers_0(JZ)V
.end method

.method private static native set_distCoeffs_0(JJ)V
.end method

.method private static native set_minMarkers_0(JI)V
.end method

.method private static native set_tryRefineMarkers_0(JZ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 121
    iget-wide v0, p0, Lorg/opencv/objdetect/CharucoParameters;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/CharucoParameters;->delete(J)V

    return-void
.end method
