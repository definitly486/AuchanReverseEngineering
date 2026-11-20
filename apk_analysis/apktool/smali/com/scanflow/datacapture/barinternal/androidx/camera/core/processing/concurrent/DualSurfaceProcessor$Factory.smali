.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$Factory;
.super Ljava/lang/Object;
.source "DualSurfaceProcessor.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Factory"
.end annotation


# static fields
.field private static sSupplier:Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 267
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$Factory$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$Factory$$ExternalSyntheticLambda0;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$Factory;->sSupplier:Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    return-void
.end method

.method public static newInstance(Landroidx/camera/core/DynamicRange;Landroidx/camera/core/LayoutSettings;Landroidx/camera/core/LayoutSettings;)Landroidx/camera/core/processing/SurfaceProcessorInternal;
    .locals 1

    .line 277
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$Factory;->sSupplier:Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;

    invoke-interface {v0, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/functions/Function3;->invoke(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Landroidx/camera/core/processing/SurfaceProcessorInternal;

    return-object p0
.end method
