.class public Lorg/opencv/objdetect/GraphicalCodeDetector;
.super Ljava/lang/Object;
.source "GraphicalCodeDetector.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method protected constructor <init>(J)V
    .locals 0

    .line 16
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-wide p1, p0, Lorg/opencv/objdetect/GraphicalCodeDetector;->nativeObj:J

    return-void
.end method

.method private static native decodeBytesMulti_0(JJJLjava/util/List;J)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJJ",
            "Ljava/util/List<",
            "[B>;J)Z"
        }
    .end annotation
.end method

.method private static native decodeBytesMulti_1(JJJLjava/util/List;)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJJ",
            "Ljava/util/List<",
            "[B>;)Z"
        }
    .end annotation
.end method

.method private static native decodeBytes_0(JJJJ)[B
.end method

.method private static native decodeBytes_1(JJJ)[B
.end method

.method private static native decodeMulti_0(JJJLjava/util/List;J)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJJ",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;J)Z"
        }
    .end annotation
.end method

.method private static native decodeMulti_1(JJJLjava/util/List;)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJJ",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)Z"
        }
    .end annotation
.end method

.method private static native decode_0(JJJJ)Ljava/lang/String;
.end method

.method private static native decode_1(JJJ)Ljava/lang/String;
.end method

.method private static native delete(J)V
.end method

.method private static native detectAndDecodeBytesMulti_0(JJLjava/util/List;JJ)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJ",
            "Ljava/util/List<",
            "[B>;JJ)Z"
        }
    .end annotation
.end method

.method private static native detectAndDecodeBytesMulti_1(JJLjava/util/List;J)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJ",
            "Ljava/util/List<",
            "[B>;J)Z"
        }
    .end annotation
.end method

.method private static native detectAndDecodeBytesMulti_2(JJLjava/util/List;)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJ",
            "Ljava/util/List<",
            "[B>;)Z"
        }
    .end annotation
.end method

.method private static native detectAndDecodeBytes_0(JJJJ)[B
.end method

.method private static native detectAndDecodeBytes_1(JJJ)[B
.end method

.method private static native detectAndDecodeBytes_2(JJ)[B
.end method

.method private static native detectAndDecodeMulti_0(JJLjava/util/List;JJ)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJ",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;JJ)Z"
        }
    .end annotation
.end method

.method private static native detectAndDecodeMulti_1(JJLjava/util/List;J)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJ",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;J)Z"
        }
    .end annotation
.end method

.method private static native detectAndDecodeMulti_2(JJLjava/util/List;)Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(JJ",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)Z"
        }
    .end annotation
.end method

.method private static native detectAndDecode_0(JJJJ)Ljava/lang/String;
.end method

.method private static native detectAndDecode_1(JJJ)Ljava/lang/String;
.end method

.method private static native detectAndDecode_2(JJ)Ljava/lang/String;
.end method

.method private static native detectMulti_0(JJJ)Z
.end method

.method private static native detect_0(JJJ)Z
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 289
    iget-wide v0, p0, Lorg/opencv/objdetect/GraphicalCodeDetector;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/GraphicalCodeDetector;->delete(J)V

    return-void
.end method
