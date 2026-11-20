.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoMimeInfo;
.super Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/MimeInfo;
.source "VideoMimeInfo.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoMimeInfo$Builder;
    }
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 35
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/MimeInfo;-><init>()V

    return-void
.end method

.method public static builder(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoMimeInfo$Builder;
    .locals 1

    .line 49
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AutoValue_VideoMimeInfo$Builder;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AutoValue_VideoMimeInfo$Builder;-><init>()V

    .line 50
    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AutoValue_VideoMimeInfo$Builder;->setMimeType(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoMimeInfo$Builder;

    move-result-object p0

    const/4 v0, -0x1

    .line 51
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/MimeInfo$Builder;->setProfile(I)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/VideoMimeInfo$Builder;

    return-object p0
.end method


# virtual methods
.method public abstract getCompatibleVideoProfile()Landroidx/camera/core/impl/EncoderProfilesProxy$VideoProfileProxy;
.end method
