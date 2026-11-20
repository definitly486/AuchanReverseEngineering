.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;
.super Ljava/lang/Object;
.source "CaptureRequestOptions.java"

# interfaces
.implements Landroidx/camera/core/ExtendableBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation


# instance fields
.field private final mMutableOptionsBundle:Landroidx/camera/core/impl/MutableOptionsBundle;


# direct methods
.method public static synthetic $r8$lambda$jyNmS9SnLFcF7Ou8YJFvxTgYDso(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;Landroidx/camera/core/impl/Config;Landroidx/camera/core/impl/Config$Option;)Z
    .locals 1

    .line 125
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;->getMutableConfig()Landroidx/camera/core/impl/MutableConfig;

    move-result-object p0

    .line 126
    invoke-interface {p1, p2}, Landroidx/camera/core/impl/Config;->getOptionPriority(Landroidx/camera/core/impl/Config$Option;)Landroidx/camera/core/impl/Config$OptionPriority;

    move-result-object v0

    .line 127
    invoke-interface {p1, p2}, Landroidx/camera/core/impl/Config;->retrieveOption(Landroidx/camera/core/impl/Config$Option;)Ljava/lang/Object;

    move-result-object p1

    .line 125
    invoke-interface {p0, p2, v0, p1}, Landroidx/camera/core/impl/MutableConfig;->insertOption(Landroidx/camera/core/impl/Config$Option;Landroidx/camera/core/impl/Config$OptionPriority;Ljava/lang/Object;)V

    const/4 p0, 0x1

    return p0
.end method

.method public constructor <init>()V
    .locals 1

    .line 103
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 105
    invoke-static {}, Landroidx/camera/core/impl/MutableOptionsBundle;->create()Landroidx/camera/core/impl/MutableOptionsBundle;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;->mMutableOptionsBundle:Landroidx/camera/core/impl/MutableOptionsBundle;

    return-void
.end method

.method public static from(Landroidx/camera/core/impl/Config;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;
    .locals 3

    .line 116
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;-><init>()V

    .line 117
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder$$ExternalSyntheticLambda0;

    invoke-direct {v1, v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;Landroidx/camera/core/impl/Config;)V

    const-string v2, "camera2.captureRequest.option."

    invoke-interface {p0, v2, v1}, Landroidx/camera/core/impl/Config;->findOptions(Ljava/lang/String;Landroidx/camera/core/impl/Config$OptionMatcher;)V

    return-object v0
.end method


# virtual methods
.method public build()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions;
    .locals 2

    .line 175
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;->mMutableOptionsBundle:Landroidx/camera/core/impl/MutableOptionsBundle;

    invoke-static {v1}, Landroidx/camera/core/impl/OptionsBundle;->from(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/OptionsBundle;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions;-><init>(Landroidx/camera/core/impl/Config;)V

    return-object v0
.end method

.method public bridge synthetic build()Ljava/lang/Object;
    .locals 1

    .line 103
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;->build()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions;

    move-result-object v0

    return-object v0
.end method

.method public getMutableConfig()Landroidx/camera/core/impl/MutableConfig;
    .locals 1

    .line 141
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;->mMutableOptionsBundle:Landroidx/camera/core/impl/MutableOptionsBundle;

    return-object v0
.end method

.method public setCaptureRequestOption(Landroid/hardware/camera2/CaptureRequest$Key;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;
    .locals 1

    .line 150
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/impl/Camera2ImplConfig;->createCaptureRequestOption(Landroid/hardware/camera2/CaptureRequest$Key;)Landroidx/camera/core/impl/Config$Option;

    move-result-object p1

    .line 151
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;->mMutableOptionsBundle:Landroidx/camera/core/impl/MutableOptionsBundle;

    invoke-virtual {v0, p1, p2}, Landroidx/camera/core/impl/MutableOptionsBundle;->insertOption(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)V

    return-object p0
.end method
