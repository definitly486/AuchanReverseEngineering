.class public interface abstract Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "<T:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;"
    }
.end annotation


# virtual methods
.method public abstract analyze(Landroidx/camera/core/ImageProxy;Landroidx/camera/core/Camera;Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Ljava/lang/Object;)V
.end method
