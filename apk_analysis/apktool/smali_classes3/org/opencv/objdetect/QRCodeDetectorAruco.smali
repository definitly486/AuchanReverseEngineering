.class public Lorg/opencv/objdetect/QRCodeDetectorAruco;
.super Lorg/opencv/objdetect/GraphicalCodeDetector;
.source "QRCodeDetectorAruco.java"


# direct methods
.method private static native QRCodeDetectorAruco_0()J
.end method

.method private static native QRCodeDetectorAruco_1(J)J
.end method

.method private static native delete(J)V
.end method

.method private static native getDetectorParameters_0(J)J
.end method

.method private static native setDetectorParameters_0(JJ)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 83
    iget-wide v0, p0, Lorg/opencv/objdetect/GraphicalCodeDetector;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/QRCodeDetectorAruco;->delete(J)V

    return-void
.end method
