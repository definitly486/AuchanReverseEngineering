.class public final Landroidx/camera/core/CameraSelector$Builder;
.super Ljava/lang/Object;
.source "CameraSelector.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Landroidx/camera/core/CameraSelector;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation


# instance fields
.field private final mCameraFilterSet:Ljava/util/LinkedHashSet;

.field private mPhysicalCameraId:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 242
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 243
    new-instance v0, Ljava/util/LinkedHashSet;

    invoke-direct {v0}, Ljava/util/LinkedHashSet;-><init>()V

    iput-object v0, p0, Landroidx/camera/core/CameraSelector$Builder;->mCameraFilterSet:Ljava/util/LinkedHashSet;

    return-void
.end method


# virtual methods
.method public addCameraFilter(Landroidx/camera/core/CameraFilter;)Landroidx/camera/core/CameraSelector$Builder;
    .locals 1

    .line 286
    iget-object v0, p0, Landroidx/camera/core/CameraSelector$Builder;->mCameraFilterSet:Ljava/util/LinkedHashSet;

    invoke-virtual {v0, p1}, Ljava/util/AbstractCollection;->add(Ljava/lang/Object;)Z

    return-object p0
.end method

.method public build()Landroidx/camera/core/CameraSelector;
    .locals 3

    .line 341
    new-instance v0, Landroidx/camera/core/CameraSelector;

    iget-object v1, p0, Landroidx/camera/core/CameraSelector$Builder;->mCameraFilterSet:Ljava/util/LinkedHashSet;

    iget-object v2, p0, Landroidx/camera/core/CameraSelector$Builder;->mPhysicalCameraId:Ljava/lang/String;

    invoke-direct {v0, v1, v2}, Landroidx/camera/core/CameraSelector;-><init>(Ljava/util/LinkedHashSet;Ljava/lang/String;)V

    return-object v0
.end method

.method public requireLensFacing(I)Landroidx/camera/core/CameraSelector$Builder;
    .locals 2

    const/4 v0, -0x1

    if-eq p1, v0, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    .line 267
    :goto_0
    const-string v1, "The specified lens facing is invalid."

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkState(ZLjava/lang/String;)V

    .line 269
    iget-object v0, p0, Landroidx/camera/core/CameraSelector$Builder;->mCameraFilterSet:Ljava/util/LinkedHashSet;

    new-instance v1, Landroidx/camera/core/impl/LensFacingCameraFilter;

    invoke-direct {v1, p1}, Landroidx/camera/core/impl/LensFacingCameraFilter;-><init>(I)V

    invoke-virtual {v0, v1}, Ljava/util/AbstractCollection;->add(Ljava/lang/Object;)Z

    return-object p0
.end method
