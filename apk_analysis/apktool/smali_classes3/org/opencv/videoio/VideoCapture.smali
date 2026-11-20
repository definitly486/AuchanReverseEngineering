.class public Lorg/opencv/videoio/VideoCapture;
.super Ljava/lang/Object;
.source "VideoCapture.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native VideoCapture_0()J
.end method

.method private static native VideoCapture_1(Ljava/lang/String;I)J
.end method

.method private static native VideoCapture_2(Ljava/lang/String;)J
.end method

.method private static native VideoCapture_3(Ljava/lang/String;IJ)J
.end method

.method private static native VideoCapture_4(II)J
.end method

.method private static native VideoCapture_5(I)J
.end method

.method private static native VideoCapture_6(IIJ)J
.end method

.method private static native VideoCapture_7(Lorg/opencv/videoio/IStreamReader;IJ)J
.end method

.method private static native delete(J)V
.end method

.method private static native getBackendName_0(J)Ljava/lang/String;
.end method

.method private static native getExceptionMode_0(J)Z
.end method

.method private static native get_0(JI)D
.end method

.method private static native grab_0(J)Z
.end method

.method private static native isOpened_0(J)Z
.end method

.method private static native open_0(JLjava/lang/String;I)Z
.end method

.method private static native open_1(JLjava/lang/String;)Z
.end method

.method private static native open_2(JLjava/lang/String;IJ)Z
.end method

.method private static native open_3(JII)Z
.end method

.method private static native open_4(JI)Z
.end method

.method private static native open_5(JIIJ)Z
.end method

.method private static native open_6(JLorg/opencv/videoio/IStreamReader;IJ)Z
.end method

.method private static native read_0(JJ)Z
.end method

.method private static native release_0(J)V
.end method

.method private static native retrieve_0(JJI)Z
.end method

.method private static native retrieve_1(JJ)Z
.end method

.method private static native setExceptionMode_0(JZ)V
.end method

.method private static native set_0(JID)Z
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 598
    iget-wide v0, p0, Lorg/opencv/videoio/VideoCapture;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/videoio/VideoCapture;->delete(J)V

    return-void
.end method
