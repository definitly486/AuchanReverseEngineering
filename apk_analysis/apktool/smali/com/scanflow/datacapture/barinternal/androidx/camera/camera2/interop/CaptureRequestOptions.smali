.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions;
.super Ljava/lang/Object;
.source "CaptureRequestOptions.java"

# interfaces
.implements Landroidx/camera/core/impl/ReadableConfig;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions$Builder;
    }
.end annotation


# instance fields
.field private final mConfig:Landroidx/camera/core/impl/Config;


# direct methods
.method public constructor <init>(Landroidx/camera/core/impl/Config;)V
    .locals 0

    .line 48
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 49
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions;->mConfig:Landroidx/camera/core/impl/Config;

    return-void
.end method


# virtual methods
.method public getConfig()Landroidx/camera/core/impl/Config;
    .locals 1

    .line 97
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/interop/CaptureRequestOptions;->mConfig:Landroidx/camera/core/impl/Config;

    return-object v0
.end method
