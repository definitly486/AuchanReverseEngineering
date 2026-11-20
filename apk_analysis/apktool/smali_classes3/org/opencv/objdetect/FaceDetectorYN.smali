.class public Lorg/opencv/objdetect/FaceDetectorYN;
.super Ljava/lang/Object;
.source "FaceDetectorYN.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native create_0(Ljava/lang/String;Ljava/lang/String;DDFFIII)J
.end method

.method private static native create_1(Ljava/lang/String;Ljava/lang/String;DDFFII)J
.end method

.method private static native create_10(Ljava/lang/String;JJDDF)J
.end method

.method private static native create_11(Ljava/lang/String;JJDD)J
.end method

.method private static native create_2(Ljava/lang/String;Ljava/lang/String;DDFFI)J
.end method

.method private static native create_3(Ljava/lang/String;Ljava/lang/String;DDFF)J
.end method

.method private static native create_4(Ljava/lang/String;Ljava/lang/String;DDF)J
.end method

.method private static native create_5(Ljava/lang/String;Ljava/lang/String;DD)J
.end method

.method private static native create_6(Ljava/lang/String;JJDDFFIII)J
.end method

.method private static native create_7(Ljava/lang/String;JJDDFFII)J
.end method

.method private static native create_8(Ljava/lang/String;JJDDFFI)J
.end method

.method private static native create_9(Ljava/lang/String;JJDDFF)J
.end method

.method private static native delete(J)V
.end method

.method private static native detect_0(JJJ)I
.end method

.method private static native getInputSize_0(J)[D
.end method

.method private static native getNMSThreshold_0(J)F
.end method

.method private static native getScoreThreshold_0(J)F
.end method

.method private static native getTopK_0(J)I
.end method

.method private static native setInputSize_0(JDD)V
.end method

.method private static native setNMSThreshold_0(JF)V
.end method

.method private static native setScoreThreshold_0(JF)V
.end method

.method private static native setTopK_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 352
    iget-wide v0, p0, Lorg/opencv/objdetect/FaceDetectorYN;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/FaceDetectorYN;->delete(J)V

    return-void
.end method
