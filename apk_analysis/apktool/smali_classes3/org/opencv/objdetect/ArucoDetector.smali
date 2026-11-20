.class public Lorg/opencv/objdetect/ArucoDetector;
.super Lorg/opencv/core/Algorithm;
.source "ArucoDetector.java"


# direct methods
.method private static native ArucoDetector_0(JJJ)J
.end method

.method private static native ArucoDetector_1(JJ)J
.end method

.method private static native ArucoDetector_2(J)J
.end method

.method private static native ArucoDetector_3()J
.end method

.method private static native delete(J)V
.end method

.method private static native detectMarkersMultiDict_0(JJJJJJ)V
.end method

.method private static native detectMarkersMultiDict_1(JJJJJ)V
.end method

.method private static native detectMarkersMultiDict_2(JJJJ)V
.end method

.method private static native detectMarkers_0(JJJJJ)V
.end method

.method private static native detectMarkers_1(JJJJ)V
.end method

.method private static native getDetectorParameters_0(J)J
.end method

.method private static native getDictionary_0(J)J
.end method

.method private static native getRefineParameters_0(J)J
.end method

.method private static native refineDetectedMarkers_0(JJJJJJJJJ)V
.end method

.method private static native refineDetectedMarkers_1(JJJJJJJJ)V
.end method

.method private static native refineDetectedMarkers_2(JJJJJJJ)V
.end method

.method private static native refineDetectedMarkers_3(JJJJJJ)V
.end method

.method private static native setDetectorParameters_0(JJ)V
.end method

.method private static native setDictionary_0(JJ)V
.end method

.method private static native setRefineParameters_0(JJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 476
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/ArucoDetector;->delete(J)V

    return-void
.end method
