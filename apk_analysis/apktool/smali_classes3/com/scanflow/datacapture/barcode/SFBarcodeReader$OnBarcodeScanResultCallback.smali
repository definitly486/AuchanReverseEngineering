.class public interface abstract Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barcode/SFBarcodeReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "OnBarcodeScanResultCallback"
.end annotation


# virtual methods
.method public abstract onBatchScanResultSuccess(Ljava/util/ArrayList;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList<",
            "Lcom/scanflow/datacapture/model/ScanResultSuccess;",
            ">;)V"
        }
    .end annotation
.end method

.method public abstract onOneOfManyCodeResult(Ljava/util/HashSet;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/HashSet<",
            "Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;",
            ">;)V"
        }
    .end annotation
.end method

.method public abstract onOneofManyCodeRemoved(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V
.end method

.method public abstract onOneofManyCodeSelected(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V
.end method

.method public abstract onScanBarcodeDetection(Z)V
.end method

.method public abstract onScanResultFailure(Ljava/lang/String;)V
.end method

.method public abstract onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V
.end method
