.class public abstract Lcom/scanflow/datacapture/barcode/SFBarcodeReader;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;
    }
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public abstract setOnBarcodeScanResultCallback(Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;)Lcom/scanflow/datacapture/barcode/SFBarcodeReader;
.end method
