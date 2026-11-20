.class public Lorg/opencv/videoio/Videoio;
.super Ljava/lang/Object;
.source "Videoio.java"


# direct methods
.method private static native getBackendName_0(I)Ljava/lang/String;
.end method

.method private static native getBackends_0()Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation
.end method

.method private static native getCameraBackendPluginVersion_0(I[D[D)Ljava/lang/String;
.end method

.method private static native getCameraBackends_0()Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation
.end method

.method private static native getStreamBackendPluginVersion_0(I[D[D)Ljava/lang/String;
.end method

.method private static native getStreamBackends_0()Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation
.end method

.method private static native getStreamBufferedBackendPluginVersion_0(I[D[D)Ljava/lang/String;
.end method

.method private static native getStreamBufferedBackends_0()Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation
.end method

.method private static native getWriterBackendPluginVersion_0(I[D[D)Ljava/lang/String;
.end method

.method private static native getWriterBackends_0()Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation
.end method

.method private static native hasBackend_0(I)Z
.end method

.method private static native isBackendBuiltIn_0(I)Z
.end method
