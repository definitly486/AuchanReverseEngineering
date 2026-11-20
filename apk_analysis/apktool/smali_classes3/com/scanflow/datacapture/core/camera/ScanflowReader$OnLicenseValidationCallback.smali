.class public interface abstract Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "OnLicenseValidationCallback"
.end annotation


# virtual methods
.method public abstract onLicenseFailure(Ljava/lang/String;)V
.end method

.method public abstract onLicenseSuccess(Ljava/lang/String;)V
.end method
