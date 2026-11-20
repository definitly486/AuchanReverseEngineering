.class public Lorg/opencv/objdetect/BarcodeDetector;
.super Lorg/opencv/objdetect/GraphicalCodeDetector;
.source "BarcodeDetector.java"


# direct methods
.method private static native BarcodeDetector_0()J
.end method

.method private static native BarcodeDetector_1(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native decodeWithType_0(JJJLjava/util/List;Ljava/util/List;)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJJ",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)Z"
        }
    .end annotation
.end method

.method private static native delete(J)V
.end method

.method private static native detectAndDecodeWithType_0(JJLjava/util/List;Ljava/util/List;J)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJ",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;J)Z"
        }
    .end annotation
.end method

.method private static native detectAndDecodeWithType_1(JJLjava/util/List;Ljava/util/List;)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJ",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)Z"
        }
    .end annotation
.end method

.method private static native getDetectorScales_0(JJ)V
.end method

.method private static native getDownsamplingThreshold_0(J)D
.end method

.method private static native getGradientThreshold_0(J)D
.end method

.method private static native setDetectorScales_0(JJ)J
.end method

.method private static native setDownsamplingThreshold_0(JD)J
.end method

.method private static native setGradientThreshold_0(JD)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 201
    iget-wide v0, p0, Lorg/opencv/objdetect/GraphicalCodeDetector;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/BarcodeDetector;->delete(J)V

    return-void
.end method
