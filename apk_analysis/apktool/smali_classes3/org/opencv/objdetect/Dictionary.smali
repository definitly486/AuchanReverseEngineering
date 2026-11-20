.class public Lorg/opencv/objdetect/Dictionary;
.super Ljava/lang/Object;
.source "Dictionary.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native Dictionary_0()J
.end method

.method private static native Dictionary_1(JII)J
.end method

.method private static native Dictionary_2(JI)J
.end method

.method private static native delete(J)V
.end method

.method private static native generateImageMarker_0(JIIJI)V
.end method

.method private static native generateImageMarker_1(JIIJ)V
.end method

.method private static native getBitsFromByteList_0(JI)J
.end method

.method private static native getByteListFromBits_0(J)J
.end method

.method private static native getDistanceToId_0(JJIZ)I
.end method

.method private static native getDistanceToId_1(JJI)I
.end method

.method private static native get_bytesList_0(J)J
.end method

.method private static native get_markerSize_0(J)I
.end method

.method private static native get_maxCorrectionBits_0(J)I
.end method

.method private static native identify_0(JJ[D[DD)Z
.end method

.method private static native set_bytesList_0(JJ)V
.end method

.method private static native set_markerSize_0(JI)V
.end method

.method private static native set_maxCorrectionBits_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 247
    iget-wide v0, p0, Lorg/opencv/objdetect/Dictionary;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/Dictionary;->delete(J)V

    return-void
.end method
