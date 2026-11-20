.class public Lorg/opencv/objdetect/FaceRecognizerSF;
.super Ljava/lang/Object;
.source "FaceRecognizerSF.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native alignCrop_0(JJJJ)V
.end method

.method private static native create_0(Ljava/lang/String;Ljava/lang/String;II)J
.end method

.method private static native create_1(Ljava/lang/String;Ljava/lang/String;I)J
.end method

.method private static native create_2(Ljava/lang/String;Ljava/lang/String;)J
.end method

.method private static native create_3(Ljava/lang/String;JJII)J
.end method

.method private static native create_4(Ljava/lang/String;JJI)J
.end method

.method private static native create_5(Ljava/lang/String;JJ)J
.end method

.method private static native delete(J)V
.end method

.method private static native feature_0(JJJ)V
.end method

.method private static native match_0(JJJI)D
.end method

.method private static native match_1(JJJ)D
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 180
    iget-wide v0, p0, Lorg/opencv/objdetect/FaceRecognizerSF;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/FaceRecognizerSF;->delete(J)V

    return-void
.end method
