.class public abstract Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;
.super Lcrc64f03248cb510113f2/BaseFragment_1;
.source "BaseScannerFragment_1.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;
.implements Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 14
    invoke-direct {p0}, Lcrc64f03248cb510113f2/BaseFragment_1;-><init>()V

    .line 15
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 16
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Ecom.PriceChecker.BaseScannerFragment`1, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(I)V
    .locals 2

    .line 22
    invoke-direct {p0, p1}, Lcrc64f03248cb510113f2/BaseFragment_1;-><init>(I)V

    .line 23
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;

    if-ne v0, v1, :cond_0

    .line 24
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v0, "Auchan.Android.Ecom.PriceChecker.BaseScannerFragment`1, Auchan.Android.Net"

    const-string v1, "System.Int32, System.Private.CoreLib"

    invoke-static {v0, v1, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onBatchScanResultSuccess(Ljava/util/ArrayList;)V
.end method

.method private native n_onCreate(Landroid/os/Bundle;)V
.end method

.method private native n_onLicenseFailure(Ljava/lang/String;)V
.end method

.method private native n_onLicenseSuccess(Ljava/lang/String;)V
.end method

.method private native n_onOneOfManyCodeResult(Ljava/util/HashSet;)V
.end method

.method private native n_onOneofManyCodeRemoved(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V
.end method

.method private native n_onOneofManyCodeSelected(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V
.end method

.method private native n_onScanBarcodeDetection(Z)V
.end method

.method private native n_onScanResultFailure(Ljava/lang/String;)V
.end method

.method private native n_onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V
.end method

.method private native n_onStart()V
.end method

.method private native n_onStop()V
.end method

.method private native n_onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 122
    iget-object v0, p0, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 123
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->refList:Ljava/util/ArrayList;

    .line 124
    :cond_0
    iget-object v0, p0, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 129
    iget-object v0, p0, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 130
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onBatchScanResultSuccess(Ljava/util/ArrayList;)V
    .locals 0

    .line 58
    invoke-direct {p0, p1}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onBatchScanResultSuccess(Ljava/util/ArrayList;)V

    return-void
.end method

.method public onCreate(Landroid/os/Bundle;)V
    .locals 0

    .line 30
    invoke-direct {p0, p1}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onCreate(Landroid/os/Bundle;)V

    return-void
.end method

.method public onLicenseFailure(Ljava/lang/String;)V
    .locals 0

    .line 107
    invoke-direct {p0, p1}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onLicenseFailure(Ljava/lang/String;)V

    return-void
.end method

.method public onLicenseSuccess(Ljava/lang/String;)V
    .locals 0

    .line 114
    invoke-direct {p0, p1}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onLicenseSuccess(Ljava/lang/String;)V

    return-void
.end method

.method public onOneOfManyCodeResult(Ljava/util/HashSet;)V
    .locals 0

    .line 65
    invoke-direct {p0, p1}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onOneOfManyCodeResult(Ljava/util/HashSet;)V

    return-void
.end method

.method public onOneofManyCodeRemoved(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V
    .locals 0

    .line 72
    invoke-direct {p0, p1}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onOneofManyCodeRemoved(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V

    return-void
.end method

.method public onOneofManyCodeSelected(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V
    .locals 0

    .line 79
    invoke-direct {p0, p1}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onOneofManyCodeSelected(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V

    return-void
.end method

.method public onScanBarcodeDetection(Z)V
    .locals 0

    .line 86
    invoke-direct {p0, p1}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onScanBarcodeDetection(Z)V

    return-void
.end method

.method public onScanResultFailure(Ljava/lang/String;)V
    .locals 0

    .line 93
    invoke-direct {p0, p1}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onScanResultFailure(Ljava/lang/String;)V

    return-void
.end method

.method public onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V
    .locals 0

    .line 100
    invoke-direct {p0, p1}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V

    return-void
.end method

.method public onStart()V
    .locals 0

    .line 44
    invoke-direct {p0}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onStart()V

    return-void
.end method

.method public onStop()V
    .locals 0

    .line 51
    invoke-direct {p0}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onStop()V

    return-void
.end method

.method public onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V
    .locals 0

    .line 37
    invoke-direct {p0, p1, p2}, Lcrc6477abdb5b4de0290f/BaseScannerFragment_1;->n_onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V

    return-void
.end method
