.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil$CodecFailedException;
.super Ljava/lang/Exception;
.source "ImageUtil.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "CodecFailedException"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil$CodecFailedException$FailureType;
    }
.end annotation


# instance fields
.field private final mFailureType:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil$CodecFailedException$FailureType;


# direct methods
.method constructor <init>(Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil$CodecFailedException$FailureType;)V
    .locals 0

    .line 505
    invoke-direct {p0, p1}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    .line 506
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil$CodecFailedException;->mFailureType:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/ImageUtil$CodecFailedException$FailureType;

    return-void
.end method
