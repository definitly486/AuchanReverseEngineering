.class public abstract Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lcom/scanflow/datacapture/core/camera/ICamera;
.implements Lcom/scanflow/datacapture/core/camera/ICameraControl;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$Companion;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnWebServiceScanResultCallback;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextComponentScanResult;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$TextScanResult;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullScanResult;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;,
        Lcom/scanflow/datacapture/core/camera/ScanflowReader$WebServiceScanResult;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/core/camera/ScanflowReader$Companion;

.field private static LENS_FACING_BACK:I

.field private static LENS_FACING_FRONT:I

.field private static SCAN_RESULT:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->Companion:Lcom/scanflow/datacapture/core/camera/ScanflowReader$Companion;

    const-string v0, "SCAN_RESULT"

    sput-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->SCAN_RESULT:Ljava/lang/String;

    const/4 v0, 0x1

    sput v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->LENS_FACING_BACK:I

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static final synthetic access$getLENS_FACING_BACK$cp()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->LENS_FACING_BACK:I

    return v0
.end method

.method public static final synthetic access$getLENS_FACING_FRONT$cp()I
    .locals 1

    .line 0
    sget v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->LENS_FACING_FRONT:I

    return v0
.end method

.method public static final synthetic access$getSCAN_RESULT$cp()Ljava/lang/String;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->SCAN_RESULT:Ljava/lang/String;

    return-object v0
.end method

.method public static final synthetic access$setLENS_FACING_BACK$cp(I)V
    .locals 0

    .line 0
    sput p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->LENS_FACING_BACK:I

    return-void
.end method

.method public static final synthetic access$setLENS_FACING_FRONT$cp(I)V
    .locals 0

    .line 0
    sput p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->LENS_FACING_FRONT:I

    return-void
.end method

.method public static final synthetic access$setSCAN_RESULT$cp(Ljava/lang/String;)V
    .locals 0

    .line 0
    sput-object p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader;->SCAN_RESULT:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public abstract bindFlashlightView(Landroid/view/View;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract bindSliderView(Lcom/google/android/material/slider/Slider;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract captureBatchInventory()V
.end method

.method public abstract captureToScan()V
.end method

.method public abstract doValidateLicense()Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract doValidateLicenseWithRetry()Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract enableSplitView(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract enableTouchZoom(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract performOneTouchClick()Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract resetOneToManyCodes()Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setAutoExposure(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setAutoFlashlight(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setAutoZoom(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setBeepSoundResource(I)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setCameraResolution(Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setEchanceTextCount(I)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setEnableDataTracking(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setEnableLocationTracking(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setEnableTireAngleDetection(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setEnableTirePreProcessing(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setEnhanceTextResult(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setIsBatchScanning(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setIsContinuousScan(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOnBarcodeScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOnCameraResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOnIDCardScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOnLicenseValidationCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOnOneTouchCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOnTextComponentScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOnTextComponentVinPlateScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOnTextComponentVinStickerScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOnTextScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOnWebServiceScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnWebServiceScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOneToManyCodes(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setOneToManyCodesKeepCurrent(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setPlayBeep(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setQrBarcodeDetection(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setSwitchCategory(Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setVibrate(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract setVinNumberColor(Lcom/scanflow/datacapture/config/VinNumberColorConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method

.method public abstract updateConfidenceValue(F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end method
