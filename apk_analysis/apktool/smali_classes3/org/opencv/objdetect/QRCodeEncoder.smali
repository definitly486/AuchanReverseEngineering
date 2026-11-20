.class public Lorg/opencv/objdetect/QRCodeEncoder;
.super Ljava/lang/Object;
.source "QRCodeEncoder.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native create_0(J)J
.end method

.method private static native create_1()J
.end method

.method private static native delete(J)V
.end method

.method private static native encodeStructuredAppend_0(JLjava/lang/String;J)V
.end method

.method private static native encode_0(JLjava/lang/String;J)V
.end method

.method private static native encode_1(J[BJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 121
    iget-wide v0, p0, Lorg/opencv/objdetect/QRCodeEncoder;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/QRCodeEncoder;->delete(J)V

    return-void
.end method
