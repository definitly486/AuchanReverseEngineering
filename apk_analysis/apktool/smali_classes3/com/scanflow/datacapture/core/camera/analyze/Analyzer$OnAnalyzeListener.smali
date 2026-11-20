.class public interface abstract Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "OnAnalyzeListener"
.end annotation


# virtual methods
.method public abstract OnOneTouchCallbackCompleted()V
.end method

.method public abstract OnOneTouchCallbackDisable()V
.end method

.method public abstract OnOneTouchCallbackStarted()V
.end method

.method public abstract onFailure()V
.end method

.method public abstract onLicenseFailed(Ljava/lang/String;)V
.end method

.method public abstract onPerformCaptureScan()V
.end method

.method public abstract onSuccess(Ljava/lang/String;)V
.end method
