.class public Lorg/opencv/objdetect/QRCodeDetector;
.super Lorg/opencv/objdetect/GraphicalCodeDetector;
.source "QRCodeDetector.java"


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 23
    invoke-static {}, Lorg/opencv/objdetect/QRCodeDetector;->QRCodeDetector_0()J

    move-result-wide v0

    invoke-direct {p0, v0, v1}, Lorg/opencv/objdetect/GraphicalCodeDetector;-><init>(J)V

    return-void
.end method

.method private static native QRCodeDetector_0()J
.end method

.method private static native decodeCurved_0(JJJJ)Ljava/lang/String;
.end method

.method private static native decodeCurved_1(JJJ)Ljava/lang/String;
.end method

.method private static native delete(J)V
.end method

.method private static native detectAndDecodeCurved_0(JJJJ)Ljava/lang/String;
.end method

.method private static native detectAndDecodeCurved_1(JJJ)Ljava/lang/String;
.end method

.method private static native detectAndDecodeCurved_2(JJ)Ljava/lang/String;
.end method

.method private static native getEncoding_0(JI)I
.end method

.method private static native getEncoding_1(J)I
.end method

.method private static native setEpsX_0(JD)J
.end method

.method private static native setEpsY_0(JD)J
.end method

.method private static native setUseAlignmentMarkers_0(JZ)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 169
    iget-wide v0, p0, Lorg/opencv/objdetect/GraphicalCodeDetector;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/QRCodeDetector;->delete(J)V

    return-void
.end method
