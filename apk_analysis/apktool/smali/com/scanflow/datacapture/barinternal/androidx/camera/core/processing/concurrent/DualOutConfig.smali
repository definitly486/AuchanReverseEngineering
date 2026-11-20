.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualOutConfig;
.super Ljava/lang/Object;
.source "DualOutConfig.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 28
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static of(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/OutConfig;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/OutConfig;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualOutConfig;
    .locals 1

    .line 49
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/AutoValue_DualOutConfig;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/AutoValue_DualOutConfig;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/OutConfig;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/OutConfig;)V

    return-object v0
.end method


# virtual methods
.method public abstract getPrimaryOutConfig()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/OutConfig;
.end method

.method public abstract getSecondaryOutConfig()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/OutConfig;
.end method
