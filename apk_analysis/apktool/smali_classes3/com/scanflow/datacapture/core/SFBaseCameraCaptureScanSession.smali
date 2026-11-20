.class public final Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;

    invoke-direct {v0}, Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;->INSTANCE:Lcom/scanflow/datacapture/core/SFBaseCameraCaptureScanSession;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public createLicenseSession(Landroid/app/Activity;Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "appContext"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;)V

    return-object v0
.end method

.method public createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sfbarcode/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "Ljava/lang/Object;",
            ">;)",
            "Lcom/scanflow/datacapture/core/camera/ScanflowReader;"
        }
    .end annotation

    .line 1
    const-string v0, "activity"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-direct {v0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;)V

    return-object v0
.end method

.method public createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sfbarcode/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "Ljava/lang/Object;",
            ">;F)",
            "Lcom/scanflow/datacapture/core/camera/ScanflowReader;"
        }
    .end annotation

    .line 2
    const-string v0, "activity"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    move v6, p5

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V

    return-object v1
.end method

.method public createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfcamera/SFCameraView;F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 7

    .line 3
    const-string v0, "appContext"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    new-instance v5, Lcom/scanflow/datacapture/barinternal/b/a;

    invoke-direct {v5, p1, p3, p2}, Lcom/scanflow/datacapture/barinternal/b/a;-><init>(Landroid/app/Activity;Lcom/scanflow/datacapture/sfcamera/SFCameraView;Ljava/lang/String;)V

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move v6, p4

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfcamera/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V

    return-object v1
.end method

.method public createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfcamera/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sfcamera/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "Ljava/lang/Object;",
            ">;F)",
            "Lcom/scanflow/datacapture/core/camera/ScanflowReader;"
        }
    .end annotation

    .line 4
    const-string v0, "appContext"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    move v6, p5

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfcamera/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V

    return-object v1
.end method

.method public createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfdocument/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 9
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sfdocument/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "Ljava/lang/Object;",
            ">;)",
            "Lcom/scanflow/datacapture/core/camera/ScanflowReader;"
        }
    .end annotation

    .line 5
    const-string v0, "appContext"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    const/16 v7, 0x10

    const/4 v8, 0x0

    const/4 v6, 0x0

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    invoke-direct/range {v1 .. v8}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfdocument/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;FILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v1
.end method

.method public createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfidcard/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 9
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sfidcard/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "Ljava/lang/Object;",
            ">;)",
            "Lcom/scanflow/datacapture/core/camera/ScanflowReader;"
        }
    .end annotation

    .line 6
    const-string v0, "appContext"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    const/16 v7, 0x10

    const/4 v8, 0x0

    const/4 v6, 0x0

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    invoke-direct/range {v1 .. v8}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfidcard/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;FILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v1
.end method

.method public createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sftext/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sftext/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "Ljava/lang/Object;",
            ">;)",
            "Lcom/scanflow/datacapture/core/camera/ScanflowReader;"
        }
    .end annotation

    .line 7
    const-string v0, "appContext"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-direct {v0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sftext/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;)V

    return-object v0
.end method

.method public createScanSession(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sftext/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sftext/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "Ljava/lang/Object;",
            ">;F)",
            "Lcom/scanflow/datacapture/core/camera/ScanflowReader;"
        }
    .end annotation

    .line 8
    const-string v0, "appContext"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    move v6, p5

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sftext/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V

    return-object v1
.end method
