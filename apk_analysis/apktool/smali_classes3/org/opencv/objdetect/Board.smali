.class public Lorg/opencv/objdetect/Board;
.super Ljava/lang/Object;
.source "Board.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native Board_0(JJJ)J
.end method

.method private static native delete(J)V
.end method

.method private static native generateImage_0(JDDJII)V
.end method

.method private static native generateImage_1(JDDJI)V
.end method

.method private static native generateImage_2(JDDJ)V
.end method

.method private static native getDictionary_0(J)J
.end method

.method private static native getIds_0(J)J
.end method

.method private static native getObjPoints_0(J)J
.end method

.method private static native getRightBottomCorner_0(J)[D
.end method

.method private static native matchImagePoints_0(JJJJJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 195
    iget-wide v0, p0, Lorg/opencv/objdetect/Board;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/Board;->delete(J)V

    return-void
.end method
