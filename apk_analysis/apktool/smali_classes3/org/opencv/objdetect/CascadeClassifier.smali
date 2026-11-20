.class public Lorg/opencv/objdetect/CascadeClassifier;
.super Ljava/lang/Object;
.source "CascadeClassifier.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native CascadeClassifier_0()J
.end method

.method private static native CascadeClassifier_1(Ljava/lang/String;)J
.end method

.method private static native convert_0(Ljava/lang/String;Ljava/lang/String;)Z
.end method

.method private static native delete(J)V
.end method

.method private static native detectMultiScale2_0(JJJJDIIDDDD)V
.end method

.method private static native detectMultiScale2_1(JJJJDIIDD)V
.end method

.method private static native detectMultiScale2_2(JJJJDII)V
.end method

.method private static native detectMultiScale2_3(JJJJDI)V
.end method

.method private static native detectMultiScale2_4(JJJJD)V
.end method

.method private static native detectMultiScale2_5(JJJJ)V
.end method

.method private static native detectMultiScale3_0(JJJJJDIIDDDDZ)V
.end method

.method private static native detectMultiScale3_1(JJJJJDIIDDDD)V
.end method

.method private static native detectMultiScale3_2(JJJJJDIIDD)V
.end method

.method private static native detectMultiScale3_3(JJJJJDII)V
.end method

.method private static native detectMultiScale3_4(JJJJJDI)V
.end method

.method private static native detectMultiScale3_5(JJJJJD)V
.end method

.method private static native detectMultiScale3_6(JJJJJ)V
.end method

.method private static native detectMultiScale_0(JJJDIIDDDD)V
.end method

.method private static native detectMultiScale_1(JJJDIIDD)V
.end method

.method private static native detectMultiScale_2(JJJDII)V
.end method

.method private static native detectMultiScale_3(JJJDI)V
.end method

.method private static native detectMultiScale_4(JJJD)V
.end method

.method private static native detectMultiScale_5(JJJ)V
.end method

.method private static native empty_0(J)Z
.end method

.method private static native getFeatureType_0(J)I
.end method

.method private static native getOriginalWindowSize_0(J)[D
.end method

.method private static native isOldFormatCascade_0(J)Z
.end method

.method private static native load_0(JLjava/lang/String;)Z
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 588
    iget-wide v0, p0, Lorg/opencv/objdetect/CascadeClassifier;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/CascadeClassifier;->delete(J)V

    return-void
.end method
