.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig$Builder;
.super Ljava/lang/Object;
.source "RequestOptionConfig.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Builder"
.end annotation


# instance fields
.field private mMutableOptionsBundle:Landroidx/camera/core/impl/MutableOptionsBundle;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 58
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 59
    invoke-static {}, Landroidx/camera/core/impl/MutableOptionsBundle;->create()Landroidx/camera/core/impl/MutableOptionsBundle;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig$Builder;->mMutableOptionsBundle:Landroidx/camera/core/impl/MutableOptionsBundle;

    return-void
.end method


# virtual methods
.method public build()Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig;
    .locals 3

    .line 97
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig$Builder;->mMutableOptionsBundle:Landroidx/camera/core/impl/MutableOptionsBundle;

    invoke-static {v1}, Landroidx/camera/core/impl/OptionsBundle;->from(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/OptionsBundle;

    move-result-object v1

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig;-><init>(Landroidx/camera/core/impl/Config;Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig$1;)V

    return-object v0
.end method

.method public setCaptureRequestOption(Landroid/hardware/camera2/CaptureRequest$Key;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig$Builder;
    .locals 1

    .line 87
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig;->createOptionFromKey(Landroid/hardware/camera2/CaptureRequest$Key;)Landroidx/camera/core/impl/Config$Option;

    move-result-object p1

    .line 88
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/extensions/internal/RequestOptionConfig$Builder;->mMutableOptionsBundle:Landroidx/camera/core/impl/MutableOptionsBundle;

    invoke-virtual {v0, p1, p2}, Landroidx/camera/core/impl/MutableOptionsBundle;->insertOption(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)V

    return-object p0
.end method
