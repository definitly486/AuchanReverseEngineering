.class public Lorg/opencv/objdetect/GridBoard;
.super Lorg/opencv/objdetect/Board;
.source "GridBoard.java"


# direct methods
.method private static native GridBoard_0(DDFFJJ)J
.end method

.method private static native GridBoard_1(DDFFJ)J
.end method

.method private static native delete(J)V
.end method

.method private static native getGridSize_0(J)[D
.end method

.method private static native getMarkerLength_0(J)F
.end method

.method private static native getMarkerSeparation_0(J)F
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 84
    iget-wide v0, p0, Lorg/opencv/objdetect/Board;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/GridBoard;->delete(J)V

    return-void
.end method
