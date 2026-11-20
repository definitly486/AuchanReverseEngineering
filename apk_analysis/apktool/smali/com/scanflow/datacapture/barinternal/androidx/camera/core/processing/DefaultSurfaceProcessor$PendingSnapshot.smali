.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$PendingSnapshot;
.super Ljava/lang/Object;
.source "DefaultSurfaceProcessor.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x408
    name = "PendingSnapshot"
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 411
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static of(IILandroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/AutoValue_DefaultSurfaceProcessor_PendingSnapshot;
    .locals 1

    .line 427
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/AutoValue_DefaultSurfaceProcessor_PendingSnapshot;

    invoke-direct {v0, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/AutoValue_DefaultSurfaceProcessor_PendingSnapshot;-><init>(IILandroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V

    return-object v0
.end method


# virtual methods
.method abstract getCompleter()Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;
.end method

.method abstract getJpegQuality()I
.end method

.method abstract getRotationDegrees()I
.end method
