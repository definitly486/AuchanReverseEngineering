.class public Lorg/opencv/videoio/VideoWriter;
.super Ljava/lang/Object;
.source "VideoWriter.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native VideoWriter_0()J
.end method

.method private static native VideoWriter_1(Ljava/lang/String;IDDDZ)J
.end method

.method private static native VideoWriter_2(Ljava/lang/String;IDDD)J
.end method

.method private static native VideoWriter_3(Ljava/lang/String;IIDDDZ)J
.end method

.method private static native VideoWriter_4(Ljava/lang/String;IIDDD)J
.end method

.method private static native VideoWriter_5(Ljava/lang/String;IDDDJ)J
.end method

.method private static native VideoWriter_6(Ljava/lang/String;IIDDDJ)J
.end method

.method private static native delete(J)V
.end method

.method private static native fourcc_0(CCCC)I
.end method

.method private static native getBackendName_0(J)Ljava/lang/String;
.end method

.method private static native get_0(JI)D
.end method

.method private static native isOpened_0(J)Z
.end method

.method private static native open_0(JLjava/lang/String;IDDDZ)Z
.end method

.method private static native open_1(JLjava/lang/String;IDDD)Z
.end method

.method private static native open_2(JLjava/lang/String;IIDDDZ)Z
.end method

.method private static native open_3(JLjava/lang/String;IIDDD)Z
.end method

.method private static native open_4(JLjava/lang/String;IDDDJ)Z
.end method

.method private static native open_5(JLjava/lang/String;IIDDDJ)Z
.end method

.method private static native release_0(J)V
.end method

.method private static native set_0(JID)Z
.end method

.method private static native write_0(JJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 400
    iget-wide v0, p0, Lorg/opencv/videoio/VideoWriter;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/videoio/VideoWriter;->delete(J)V

    return-void
.end method
