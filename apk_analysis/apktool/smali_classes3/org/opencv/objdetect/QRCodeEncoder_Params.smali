.class public Lorg/opencv/objdetect/QRCodeEncoder_Params;
.super Ljava/lang/Object;
.source "QRCodeEncoder_Params.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native QRCodeEncoder_Params_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_correction_level_0(J)I
.end method

.method private static native get_mode_0(J)I
.end method

.method private static native get_structure_number_0(J)I
.end method

.method private static native get_version_0(J)I
.end method

.method private static native set_correction_level_0(JI)V
.end method

.method private static native set_mode_0(JI)V
.end method

.method private static native set_structure_number_0(JI)V
.end method

.method private static native set_version_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 105
    iget-wide v0, p0, Lorg/opencv/objdetect/QRCodeEncoder_Params;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/QRCodeEncoder_Params;->delete(J)V

    return-void
.end method
