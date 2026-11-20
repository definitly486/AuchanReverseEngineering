.class public final Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;

.field private static sFBarcodeScannerAnalyzer:Lcom/scanflow/datacapture/barinternal/M;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;->INSTANCE:Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public changeScanMode(Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)V
    .locals 2

    const-string v0, "decodeConfig"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    sget-object v1, Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;->sFBarcodeScannerAnalyzer:Lcom/scanflow/datacapture/barinternal/M;

    if-eqz v1, :cond_0

    .line 1
    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v1, p1}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)V

    :cond_0
    return-void
.end method

.method public clearMatrixScannedList()V
    .locals 2

    sget-object v0, Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;->sFBarcodeScannerAnalyzer:Lcom/scanflow/datacapture/barinternal/M;

    if-eqz v0, :cond_0

    .line 1
    new-instance v1, Ljava/util/HashSet;

    invoke-direct {v1}, Ljava/util/HashSet;-><init>()V

    iput-object v1, v0, Lcom/scanflow/datacapture/barinternal/M;->b0:Ljava/util/HashSet;

    :cond_0
    return-void
.end method

.method public createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 2

    .line 1
    const-string v0, "appContext"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "decodeConfig"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/scanflow/datacapture/barinternal/M;

    invoke-direct {v0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/M;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)V

    sput-object v0, Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;->sFBarcodeScannerAnalyzer:Lcom/scanflow/datacapture/barinternal/M;

    sget-object p4, Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;->INSTANCE:Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;

    sget-object v0, Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;->sFBarcodeScannerAnalyzer:Lcom/scanflow/datacapture/barinternal/M;

    const-string v1, "null cannot be cast to non-null type com.scanflow.datacapture.core.camera.analyze.Analyzer<kotlin.Any>"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p4, p1, p2, p3, v0}, Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;->createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;

    move-result-object p1

    return-object p1
.end method

.method public createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 7

    .line 2
    const-string v0, "appContext"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "decodeConfig"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/scanflow/datacapture/barinternal/M;

    invoke-direct {v0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/M;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)V

    sput-object v0, Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;->sFBarcodeScannerAnalyzer:Lcom/scanflow/datacapture/barinternal/M;

    sget-object v1, Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;->INSTANCE:Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;

    sget-object v5, Lcom/scanflow/datacapture/barcode/SFBarcodeCaptureSession;->sFBarcodeScannerAnalyzer:Lcom/scanflow/datacapture/barinternal/M;

    const-string p4, "null cannot be cast to non-null type com.scanflow.datacapture.core.camera.analyze.Analyzer<kotlin.Any>"

    invoke-static {v5, p4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move v6, p5

    invoke-virtual/range {v1 .. v6}, Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;->createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;

    move-result-object p1

    return-object p1
.end method

.method public scanBitmap(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;Landroid/graphics/Bitmap;)Lcom/scanflow/datacapture/barcode/SFBarcodeReader;
    .locals 7

    .line 0
    const-string v0, "appContext"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "decodeConfig"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "callback"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "bitmap"

    invoke-static {p5, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/barcode/b;

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    move-object v6, p5

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/barcode/b;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;Landroid/graphics/Bitmap;)V

    return-object v1
.end method
