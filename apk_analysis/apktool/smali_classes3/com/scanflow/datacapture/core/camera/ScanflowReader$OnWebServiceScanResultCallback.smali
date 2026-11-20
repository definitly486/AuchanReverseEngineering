.class public interface abstract Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnWebServiceScanResultCallback;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "OnWebServiceScanResultCallback"
.end annotation


# virtual methods
.method public abstract onScanResultFailure(Ljava/lang/String;)V
.end method

.method public abstract onScanResultSuccess(Lcom/scanflow/datacapture/core/camera/ScanflowReader$WebServiceScanResult;)V
.end method
