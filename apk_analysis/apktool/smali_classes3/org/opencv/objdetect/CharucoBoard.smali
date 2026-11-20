.class public Lorg/opencv/objdetect/CharucoBoard;
.super Lorg/opencv/objdetect/Board;
.source "CharucoBoard.java"


# direct methods
.method private static native CharucoBoard_0(DDFFJJ)J
.end method

.method private static native CharucoBoard_1(DDFFJ)J
.end method

.method private static native checkCharucoCornersCollinear_0(JJ)Z
.end method

.method private static native delete(J)V
.end method

.method private static native getChessboardCorners_0(J)J
.end method

.method private static native getChessboardSize_0(J)[D
.end method

.method private static native getLegacyPattern_0(J)Z
.end method

.method private static native getMarkerLength_0(J)F
.end method

.method private static native getSquareLength_0(J)F
.end method

.method private static native setLegacyPattern_0(JZ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 153
    iget-wide v0, p0, Lorg/opencv/objdetect/Board;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/CharucoBoard;->delete(J)V

    return-void
.end method
