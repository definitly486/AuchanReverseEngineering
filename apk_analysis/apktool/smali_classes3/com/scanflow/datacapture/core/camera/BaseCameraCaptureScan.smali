.class public final Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;
.super Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.source "SourceFile"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/e/a$a;
.implements Landroidx/lifecycle/LifecycleOwner;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "<T:",
        "Ljava/lang/Object;",
        ">",
        "Lcom/scanflow/datacapture/core/camera/ScanflowReader;",
        "Lcom/scanflow/datacapture/barinternal/e/a$a;",
        "Landroidx/lifecycle/LifecycleOwner;"
    }
.end annotation


# static fields
.field public static final synthetic E0:I


# instance fields
.field public A:Lcom/scanflow/datacapture/barinternal/e/a;

.field public A0:Landroidx/camera/core/UseCaseGroup;

.field public B:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

.field public B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

.field public C:Z

.field public final C0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

.field public D:Z

.field public final D0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

.field public E:Z

.field public final F:F

.field public G:Z

.field public H:Z

.field public I:J

.field public J:Z

.field public K:F

.field public L:F

.field public M:F

.field public N:F

.field public O:Ljava/lang/Integer;

.field public final P:Ljava/util/concurrent/ExecutorService;

.field public Q:Landroid/content/SharedPreferences;

.field public R:Ljava/lang/String;

.field public S:Z

.field public T:Lcom/scanflow/datacapture/barinternal/j/c;

.field public U:Landroid/content/SharedPreferences;

.field public V:Lcom/scanflow/datacapture/barinternal/h/b;

.field public W:Z

.field public final X:Ljava/lang/String;

.field public final Y:Ljava/lang/String;

.field public final Z:Ljava/lang/String;

.field public final a:Landroid/app/Activity;

.field public final a0:Ljava/lang/String;

.field public final b:Landroid/app/Activity;

.field public final b0:Ljava/lang/String;

.field public final c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

.field public final c0:Ljava/lang/String;

.field public d:Landroid/util/Size;

.field public final d0:Ljava/lang/String;

.field public e:Landroid/util/Size;

.field public final e0:Ljava/lang/String;

.field public final f:Landroidx/camera/view/PreviewView;

.field public f0:Z

.field public g:Lcom/google/common/util/concurrent/ListenableFuture;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/common/util/concurrent/ListenableFuture<",
            "Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;",
            ">;"
        }
    .end annotation
.end field

.field public g0:Z

.field public h:Landroidx/camera/core/Camera;

.field public h0:Z

.field public i:Lcom/scanflow/datacapture/barinternal/d/a;

.field public i0:Z

.field public j:Landroidx/camera/core/ImageCapture;

.field public j0:Landroid/location/LocationManager;

.field public k:Landroid/util/Size;

.field public k0:D

.field public l:Landroidx/camera/core/ViewPort;

.field public l0:D

.field public m:Landroid/view/View;

.field public final m0:Ljava/lang/String;

.field public n:Lcom/google/android/material/slider/Slider;

.field public final n0:Lkotlin/coroutines/AbstractCoroutineContextElement;

.field public o:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;

.field public final o0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "TT;>;"
        }
    .end annotation
.end field

.field public p:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback;

.field public final p0:Z

.field public q:Landroidx/lifecycle/MutableLiveData;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Landroidx/lifecycle/MutableLiveData<",
            "TT;>;"
        }
    .end annotation
.end field

.field public q0:Z

.field public r:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

.field public volatile r0:Z

.field public s:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback;

.field public s0:Landroidx/security/crypto/MasterKey;

.field public t:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback;

.field public t0:Landroid/content/SharedPreferences;

.field public u:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback;

.field public u0:Z

.field public v:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback;

.field public v0:Z

.field public w:Ljava/lang/Object;

.field public w0:Z

.field public x:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;

.field public x0:I

.field public y:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;

.field public y0:Ljava/lang/String;

.field public z:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

.field public final z0:Landroidx/lifecycle/LifecycleRegistry;


# direct methods
.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;)V
    .locals 3

    .line 1
    const-string v0, "activity"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;-><init>()V

    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->getSize()Landroid/util/Size;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    const v0, 0x3dcccccd    # 0.1f

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->G:Z

    invoke-static {}, Ljava/util/concurrent/Executors;->newSingleThreadExecutor()Ljava/util/concurrent/ExecutorService;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->P:Ljava/util/concurrent/ExecutorService;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    const-string v1, ""

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    const-string v2, "SCANFLOW_LICENSE_PREF_NAME_"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    const-string v2, "SECRET_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    const-string v2, "SALTVALUE_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    const-string v2, "MODEL_FILE_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b0:Ljava/lang/String;

    const-string v2, "123456789"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c0:Ljava/lang/String;

    const-string v2, "abcdefg"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d0:Ljava/lang/String;

    const-string v2, "MyDifficultPassw"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e0:Ljava/lang/String;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    new-instance v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$n;

    invoke-direct {v2, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$n;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n0:Lkotlin/coroutines/AbstractCoroutineContextElement;

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->p0:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u0:Z

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x0:I

    const-string v0, "dashboard"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y0:Ljava/lang/String;

    new-instance v0, Landroidx/lifecycle/LifecycleRegistry;

    invoke-direct {v0, p0}, Landroidx/lifecycle/LifecycleRegistry;-><init>(Landroidx/lifecycle/LifecycleOwner;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v1, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    sget-object v1, Landroidx/lifecycle/Lifecycle$State;->CREATED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v0, v1}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    const-string v0, "opencv_java4"

    invoke-static {v0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v1, "DefaultCameraScan"

    const-string v2, "Session Init"

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    const-string v0, "License_Verification"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    iput-object p0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    new-instance v0, Landroidx/camera/view/PreviewView;

    if-nez p1, :cond_0

    const-string p1, "mContext"

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 p1, 0x0

    :cond_0
    invoke-direct {v0, p1}, Landroidx/camera/view/PreviewView;-><init>(Landroid/content/Context;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c()V

    return-void
.end method

.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sfbarcode/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "TT;>;)V"
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

    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;-><init>()V

    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->getSize()Landroid/util/Size;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    const v0, 0x3dcccccd    # 0.1f

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->G:Z

    invoke-static {}, Ljava/util/concurrent/Executors;->newSingleThreadExecutor()Ljava/util/concurrent/ExecutorService;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->P:Ljava/util/concurrent/ExecutorService;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    const-string v1, ""

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    const-string v2, "SCANFLOW_LICENSE_PREF_NAME_"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    const-string v2, "SECRET_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    const-string v2, "SALTVALUE_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    const-string v2, "MODEL_FILE_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b0:Ljava/lang/String;

    const-string v2, "123456789"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c0:Ljava/lang/String;

    const-string v2, "abcdefg"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d0:Ljava/lang/String;

    const-string v2, "MyDifficultPassw"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e0:Ljava/lang/String;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    new-instance v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$g;

    invoke-direct {v2, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$g;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n0:Lkotlin/coroutines/AbstractCoroutineContextElement;

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->p0:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u0:Z

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x0:I

    const-string v0, "dashboard"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y0:Ljava/lang/String;

    new-instance v0, Landroidx/lifecycle/LifecycleRegistry;

    invoke-direct {v0, p0}, Landroidx/lifecycle/LifecycleRegistry;-><init>(Landroidx/lifecycle/LifecycleOwner;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v1, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    sget-object v1, Landroidx/lifecycle/Lifecycle$State;->CREATED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v0, v1}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    const-string v0, "opencv_java4"

    invoke-static {v0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v1, "DefaultCameraScan"

    const-string v2, "Session Init"

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    const-string v0, "Barcode_Capture"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    iput-object p0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->getPreviewView()Landroidx/camera/view/PreviewView;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c()V

    return-void
.end method

.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sfbarcode/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "TT;>;F)V"
        }
    .end annotation

    .line 3
    const-string v0, "activity"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;-><init>()V

    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->getSize()Landroid/util/Size;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    const v0, 0x3dcccccd    # 0.1f

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->G:Z

    invoke-static {}, Ljava/util/concurrent/Executors;->newSingleThreadExecutor()Ljava/util/concurrent/ExecutorService;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->P:Ljava/util/concurrent/ExecutorService;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    const-string v1, ""

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    const-string v2, "SCANFLOW_LICENSE_PREF_NAME_"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    const-string v2, "SECRET_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    const-string v2, "SALTVALUE_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    const-string v2, "MODEL_FILE_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b0:Ljava/lang/String;

    const-string v2, "123456789"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c0:Ljava/lang/String;

    const-string v2, "abcdefg"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d0:Ljava/lang/String;

    const-string v2, "MyDifficultPassw"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e0:Ljava/lang/String;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    new-instance v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$h;

    invoke-direct {v2, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$h;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n0:Lkotlin/coroutines/AbstractCoroutineContextElement;

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->p0:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u0:Z

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x0:I

    const-string v0, "dashboard"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y0:Ljava/lang/String;

    new-instance v0, Landroidx/lifecycle/LifecycleRegistry;

    invoke-direct {v0, p0}, Landroidx/lifecycle/LifecycleRegistry;-><init>(Landroidx/lifecycle/LifecycleOwner;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v1, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    sget-object v1, Landroidx/lifecycle/Lifecycle$State;->CREATED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v0, v1}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    const-string v0, "opencv_java4"

    invoke-static {v0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v1, "DefaultCameraScan"

    const-string v2, "Session Init"

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    const-string v0, "Barcode_Capture"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    iput-object p0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->getPreviewView()Landroidx/camera/view/PreviewView;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;

    iput p5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c()V

    return-void
.end method

.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfcamera/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sfcamera/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "TT;>;F)V"
        }
    .end annotation

    .line 4
    const-string v0, "activity"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;-><init>()V

    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->getSize()Landroid/util/Size;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    const v0, 0x3dcccccd    # 0.1f

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->G:Z

    invoke-static {}, Ljava/util/concurrent/Executors;->newSingleThreadExecutor()Ljava/util/concurrent/ExecutorService;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->P:Ljava/util/concurrent/ExecutorService;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    const-string v1, ""

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    const-string v2, "SCANFLOW_LICENSE_PREF_NAME_"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    const-string v2, "SECRET_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    const-string v2, "SALTVALUE_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    const-string v2, "MODEL_FILE_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b0:Ljava/lang/String;

    const-string v2, "123456789"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c0:Ljava/lang/String;

    const-string v2, "abcdefg"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d0:Ljava/lang/String;

    const-string v2, "MyDifficultPassw"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e0:Ljava/lang/String;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    new-instance v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$m;

    invoke-direct {v2, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$m;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n0:Lkotlin/coroutines/AbstractCoroutineContextElement;

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->p0:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u0:Z

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x0:I

    const-string v0, "dashboard"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y0:Ljava/lang/String;

    new-instance v0, Landroidx/lifecycle/LifecycleRegistry;

    invoke-direct {v0, p0}, Landroidx/lifecycle/LifecycleRegistry;-><init>(Landroidx/lifecycle/LifecycleOwner;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v1, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    sget-object v1, Landroidx/lifecycle/Lifecycle$State;->CREATED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v0, v1}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    const-string v0, "opencv_java4"

    invoke-static {v0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    const-string v0, "Text_Capture"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    iput-object p0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->getPreviewView()Landroidx/camera/view/PreviewView;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    iput p5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c()V

    return-void
.end method

.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfdocument/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sfdocument/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "TT;>;F)V"
        }
    .end annotation

    .line 5
    const-string v0, "activity"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;-><init>()V

    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->getSize()Landroid/util/Size;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    const v0, 0x3dcccccd    # 0.1f

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->G:Z

    invoke-static {}, Ljava/util/concurrent/Executors;->newSingleThreadExecutor()Ljava/util/concurrent/ExecutorService;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->P:Ljava/util/concurrent/ExecutorService;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    const-string v1, ""

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    const-string v2, "SCANFLOW_LICENSE_PREF_NAME_"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    const-string v2, "SECRET_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    const-string v2, "SALTVALUE_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    const-string v2, "MODEL_FILE_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b0:Ljava/lang/String;

    const-string v2, "123456789"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c0:Ljava/lang/String;

    const-string v2, "abcdefg"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d0:Ljava/lang/String;

    const-string v2, "MyDifficultPassw"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e0:Ljava/lang/String;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    new-instance v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$j;

    invoke-direct {v2, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$j;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n0:Lkotlin/coroutines/AbstractCoroutineContextElement;

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->p0:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u0:Z

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x0:I

    const-string v0, "dashboard"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y0:Ljava/lang/String;

    new-instance v0, Landroidx/lifecycle/LifecycleRegistry;

    invoke-direct {v0, p0}, Landroidx/lifecycle/LifecycleRegistry;-><init>(Landroidx/lifecycle/LifecycleOwner;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v1, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    sget-object v1, Landroidx/lifecycle/Lifecycle$State;->CREATED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v0, v1}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    const-string v0, "opencv_java4"

    invoke-static {v0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    const-string v0, "Document_Capture"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    iput-object p0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->getPreviewView()Landroidx/camera/view/PreviewView;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    iput p5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c()V

    return-void
.end method

.method public synthetic constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfdocument/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;FILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 6

    and-int/lit8 p6, p6, 0x10

    if-eqz p6, :cond_0

    const p5, 0x3dcccccd    # 0.1f

    :cond_0
    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move v5, p5

    .line 6
    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfdocument/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V

    return-void
.end method

.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfidcard/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sfidcard/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "TT;>;F)V"
        }
    .end annotation

    .line 7
    const-string v0, "activity"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;-><init>()V

    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->getSize()Landroid/util/Size;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    const v0, 0x3dcccccd    # 0.1f

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->G:Z

    invoke-static {}, Ljava/util/concurrent/Executors;->newSingleThreadExecutor()Ljava/util/concurrent/ExecutorService;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->P:Ljava/util/concurrent/ExecutorService;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    const-string v1, ""

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    const-string v2, "SCANFLOW_LICENSE_PREF_NAME_"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    const-string v2, "SECRET_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    const-string v2, "SALTVALUE_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    const-string v2, "MODEL_FILE_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b0:Ljava/lang/String;

    const-string v2, "123456789"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c0:Ljava/lang/String;

    const-string v2, "abcdefg"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d0:Ljava/lang/String;

    const-string v2, "MyDifficultPassw"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e0:Ljava/lang/String;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    new-instance v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$i;

    invoke-direct {v2, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$i;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n0:Lkotlin/coroutines/AbstractCoroutineContextElement;

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->p0:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u0:Z

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x0:I

    const-string v0, "dashboard"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y0:Ljava/lang/String;

    new-instance v0, Landroidx/lifecycle/LifecycleRegistry;

    invoke-direct {v0, p0}, Landroidx/lifecycle/LifecycleRegistry;-><init>(Landroidx/lifecycle/LifecycleOwner;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v1, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    sget-object v1, Landroidx/lifecycle/Lifecycle$State;->CREATED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v0, v1}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    const-string v0, "opencv_java4"

    invoke-static {v0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    const-string v0, "Id_Capture"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    iput-object p0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/sfidcard/SFCameraView;->getPreviewView()Landroidx/camera/view/PreviewView;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    iput p5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c()V

    return-void
.end method

.method public synthetic constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfidcard/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;FILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 6

    and-int/lit8 p6, p6, 0x10

    if-eqz p6, :cond_0

    const p5, 0x3dcccccd    # 0.1f

    :cond_0
    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move v5, p5

    .line 8
    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;-><init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfidcard/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V

    return-void
.end method

.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sftext/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sftext/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "TT;>;)V"
        }
    .end annotation

    .line 9
    const-string v0, "activity"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;-><init>()V

    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->getSize()Landroid/util/Size;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    const v0, 0x3dcccccd    # 0.1f

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->G:Z

    invoke-static {}, Ljava/util/concurrent/Executors;->newSingleThreadExecutor()Ljava/util/concurrent/ExecutorService;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->P:Ljava/util/concurrent/ExecutorService;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    const-string v1, ""

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    const-string v2, "SCANFLOW_LICENSE_PREF_NAME_"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    const-string v2, "SECRET_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    const-string v2, "SALTVALUE_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    const-string v2, "MODEL_FILE_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b0:Ljava/lang/String;

    const-string v2, "123456789"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c0:Ljava/lang/String;

    const-string v2, "abcdefg"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d0:Ljava/lang/String;

    const-string v2, "MyDifficultPassw"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e0:Ljava/lang/String;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    new-instance v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$k;

    invoke-direct {v2, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$k;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n0:Lkotlin/coroutines/AbstractCoroutineContextElement;

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->p0:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u0:Z

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x0:I

    const-string v0, "dashboard"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y0:Ljava/lang/String;

    new-instance v0, Landroidx/lifecycle/LifecycleRegistry;

    invoke-direct {v0, p0}, Landroidx/lifecycle/LifecycleRegistry;-><init>(Landroidx/lifecycle/LifecycleOwner;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v1, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    sget-object v1, Landroidx/lifecycle/Lifecycle$State;->CREATED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v0, v1}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    const-string v0, "opencv_java4"

    invoke-static {v0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    const-string v0, "Text_Capture"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    iput-object p0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/sftext/SFCameraView;->getPreviewView()Landroidx/camera/view/PreviewView;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c()V

    return-void
.end method

.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sftext/SFCameraView;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;F)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Lcom/scanflow/datacapture/sftext/SFCameraView;",
            "Lcom/scanflow/datacapture/core/camera/analyze/Analyzer<",
            "TT;>;F)V"
        }
    .end annotation

    .line 10
    const-string v0, "activity"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "analyzer"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader;-><init>()V

    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->getSize()Landroid/util/Size;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    const v0, 0x3dcccccd    # 0.1f

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->G:Z

    invoke-static {}, Ljava/util/concurrent/Executors;->newSingleThreadExecutor()Ljava/util/concurrent/ExecutorService;

    move-result-object v1

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->P:Ljava/util/concurrent/ExecutorService;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    const-string v1, ""

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    const-string v2, "SCANFLOW_LICENSE_PREF_NAME_"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    const-string v2, "SECRET_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    const-string v2, "SALTVALUE_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    const-string v2, "MODEL_FILE_KEY_PREF_NAME"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b0:Ljava/lang/String;

    const-string v2, "123456789"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c0:Ljava/lang/String;

    const-string v2, "abcdefg"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d0:Ljava/lang/String;

    const-string v2, "MyDifficultPassw"

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e0:Ljava/lang/String;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    new-instance v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$l;

    invoke-direct {v2, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$l;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n0:Lkotlin/coroutines/AbstractCoroutineContextElement;

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->p0:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u0:Z

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x0:I

    const-string v0, "dashboard"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y0:Ljava/lang/String;

    new-instance v0, Landroidx/lifecycle/LifecycleRegistry;

    invoke-direct {v0, p0}, Landroidx/lifecycle/LifecycleRegistry;-><init>(Landroidx/lifecycle/LifecycleOwner;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v1, Lcom/scanflow/datacapture/config/VinNumberColorConfig;->SILVER:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    sget-object v1, Landroidx/lifecycle/Lifecycle$State;->CREATED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v0, v1}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    const-string v0, "opencv_java4"

    invoke-static {v0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V

    const-string v0, "Text_Capture"

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    iput-object p0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/sftext/SFCameraView;->getPreviewView()Landroidx/camera/view/PreviewView;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    iput p5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c()V

    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Ljava/lang/Boolean;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 11
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Ljava/lang/Integer;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 7
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 10
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V
    .locals 2

    .line 6
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    if-nez v0, :cond_0

    const-string v0, "mPreviewView"

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 v0, 0x0

    :cond_0
    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$c;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$c;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    invoke-virtual {v0, v1}, Landroid/view/View;->addOnLayoutChangeListener(Landroid/view/View$OnLayoutChangeListener;)V

    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;I)V
    .locals 7

    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->i:Lcom/scanflow/datacapture/barinternal/d/a;

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    new-instance v0, Landroidx/camera/core/Preview$Builder;

    invoke-direct {v0}, Landroidx/camera/core/Preview$Builder;-><init>()V

    invoke-virtual {v0, p1}, Landroidx/camera/core/Preview$Builder;->setTargetRotation(I)Landroidx/camera/core/Preview$Builder;

    move-result-object v0

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    invoke-virtual {v0, v2}, Landroidx/camera/core/Preview$Builder;->setTargetResolution(Landroid/util/Size;)Landroidx/camera/core/Preview$Builder;

    move-result-object v0

    const-string v2, "setTargetResolution(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/d/a;->a(Landroidx/camera/core/Preview$Builder;)Landroidx/camera/core/Preview;

    move-result-object v0

    goto :goto_0

    :cond_0
    move-object v0, v1

    :goto_0
    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->i:Lcom/scanflow/datacapture/barinternal/d/a;

    if-eqz v2, :cond_1

    new-instance v2, Landroidx/camera/core/CameraSelector$Builder;

    invoke-direct {v2}, Landroidx/camera/core/CameraSelector$Builder;-><init>()V

    .line 22
    const-string v3, "builder"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v2}, Landroidx/camera/core/CameraSelector$Builder;->build()Landroidx/camera/core/CameraSelector;

    move-result-object v2

    const-string v3, "build(...)"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    :cond_1
    move-object v2, v1

    :goto_1
    const-string v3, "mPreviewView"

    if-eqz v0, :cond_3

    .line 23
    :try_start_1
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    if-nez v4, :cond_2

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_2
    invoke-virtual {v4}, Landroidx/camera/view/PreviewView;->getSurfaceProvider()Landroidx/camera/core/Preview$SurfaceProvider;

    move-result-object v4

    invoke-virtual {v0, v4}, Landroidx/camera/core/Preview;->setSurfaceProvider(Landroidx/camera/core/Preview$SurfaceProvider;)V

    :cond_3
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->i:Lcom/scanflow/datacapture/barinternal/d/a;

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    new-instance v5, Landroidx/camera/core/ImageAnalysis$Builder;

    invoke-direct {v5}, Landroidx/camera/core/ImageAnalysis$Builder;-><init>()V

    invoke-virtual {v5, p1}, Landroidx/camera/core/ImageAnalysis$Builder;->setTargetRotation(I)Landroidx/camera/core/ImageAnalysis$Builder;

    move-result-object p1

    iget-object v5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    invoke-virtual {p1, v5}, Landroidx/camera/core/ImageAnalysis$Builder;->setTargetResolution(Landroid/util/Size;)Landroidx/camera/core/ImageAnalysis$Builder;

    move-result-object p1

    const/4 v5, 0x0

    invoke-virtual {p1, v5}, Landroidx/camera/core/ImageAnalysis$Builder;->setBackpressureStrategy(I)Landroidx/camera/core/ImageAnalysis$Builder;

    move-result-object p1

    const-string v6, "setBackpressureStrategy(...)"

    invoke-static {p1, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v4}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/d/a;->a(Landroidx/camera/core/ImageAnalysis$Builder;)Landroidx/camera/core/ImageAnalysis;

    move-result-object p1

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->P:Ljava/util/concurrent/ExecutorService;

    new-instance v6, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda10;

    invoke-direct {v6, p0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda10;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    invoke-virtual {p1, v4, v6}, Landroidx/camera/core/ImageAnalysis;->setAnalyzer(Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageAnalysis$Analyzer;)V

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v4, :cond_4

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->g:Lcom/google/common/util/concurrent/ListenableFuture;

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v4}, Ljava/util/concurrent/Future;->get()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->unbindAll()V

    :cond_4
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    if-nez v4, :cond_5

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_5
    invoke-virtual {v4}, Landroidx/camera/view/PreviewView;->getViewPort()Landroidx/camera/core/ViewPort;

    move-result-object v4

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iput-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->l:Landroidx/camera/core/ViewPort;

    new-instance v4, Landroidx/camera/core/ImageCapture$Builder;

    invoke-direct {v4}, Landroidx/camera/core/ImageCapture$Builder;-><init>()V

    invoke-virtual {v4, v5}, Landroidx/camera/core/ImageCapture$Builder;->setCaptureMode(I)Landroidx/camera/core/ImageCapture$Builder;

    move-result-object v4

    iget-object v5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    if-nez v5, :cond_6

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v5, v1

    :cond_6
    invoke-virtual {v5}, Landroid/view/View;->getDisplay()Landroid/view/Display;

    move-result-object v3

    invoke-virtual {v3}, Landroid/view/Display;->getOrientation()I

    move-result v3

    invoke-virtual {v4, v3}, Landroidx/camera/core/ImageCapture$Builder;->setTargetRotation(I)Landroidx/camera/core/ImageCapture$Builder;

    move-result-object v3

    const/16 v4, 0x64

    invoke-virtual {v3, v4}, Landroidx/camera/core/ImageCapture$Builder;->setJpegQuality(I)Landroidx/camera/core/ImageCapture$Builder;

    move-result-object v3

    invoke-virtual {v3}, Landroidx/camera/core/ImageCapture$Builder;->build()Landroidx/camera/core/ImageCapture;

    move-result-object v3

    iput-object v3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->j:Landroidx/camera/core/ImageCapture;

    new-instance v3, Landroidx/camera/core/UseCaseGroup$Builder;

    invoke-direct {v3}, Landroidx/camera/core/UseCaseGroup$Builder;-><init>()V

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v3, v0}, Landroidx/camera/core/UseCaseGroup$Builder;->addUseCase(Landroidx/camera/core/UseCase;)Landroidx/camera/core/UseCaseGroup$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Landroidx/camera/core/UseCaseGroup$Builder;->addUseCase(Landroidx/camera/core/UseCase;)Landroidx/camera/core/UseCaseGroup$Builder;

    move-result-object p1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->j:Landroidx/camera/core/ImageCapture;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p1, v0}, Landroidx/camera/core/UseCaseGroup$Builder;->addUseCase(Landroidx/camera/core/UseCase;)Landroidx/camera/core/UseCaseGroup$Builder;

    move-result-object p1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->l:Landroidx/camera/core/ViewPort;

    if-nez v0, :cond_7

    const-string v0, "viewPort"

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v1

    :cond_7
    invoke-virtual {p1, v0}, Landroidx/camera/core/UseCaseGroup$Builder;->setViewPort(Landroidx/camera/core/ViewPort;)Landroidx/camera/core/UseCaseGroup$Builder;

    move-result-object p1

    invoke-virtual {p1}, Landroidx/camera/core/UseCaseGroup$Builder;->build()Landroidx/camera/core/UseCaseGroup;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->A0:Landroidx/camera/core/UseCaseGroup;

    if-eqz v2, :cond_a

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->g:Lcom/google/common/util/concurrent/ListenableFuture;

    if-eqz p1, :cond_a

    invoke-interface {p1}, Ljava/util/concurrent/Future;->get()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    if-eqz p1, :cond_a

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    if-nez v0, :cond_8

    const-string v0, "mLifecycleOwner"

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v1

    :cond_8
    iget-object v3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->A0:Landroidx/camera/core/UseCaseGroup;

    if-nez v3, :cond_9

    const-string v3, "useCaseGroup"

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    goto :goto_2

    :cond_9
    move-object v1, v3

    :goto_2
    invoke-virtual {p1, v0, v2, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->bindToLifecycle(Landroidx/lifecycle/LifecycleOwner;Landroidx/camera/core/CameraSelector;Landroidx/camera/core/UseCaseGroup;)Landroidx/camera/core/Camera;

    move-result-object v1

    :cond_a
    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v1, :cond_b

    invoke-interface {v1}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object p1

    if-eqz p1, :cond_b

    invoke-interface {p1}, Landroidx/camera/core/CameraControl;->cancelFocusAndMetering()Lcom/google/common/util/concurrent/ListenableFuture;

    .line 24
    :cond_b
    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v0, Landroidx/lifecycle/Lifecycle$State;->STARTED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {p1, v0}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    .line 25
    iget p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->lineZoomTo(F)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e()V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    return-void

    :catch_0
    move-exception p0

    sget-object p1, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    invoke-static {p0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p0

    const-string v0, "DefaultCameraScan"

    invoke-virtual {p1, v0, p0}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Landroid/location/Location;)V
    .locals 2

    .line 5
    const-string v0, "location"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p1}, Landroid/location/Location;->getLatitude()D

    move-result-wide v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->k0:D

    invoke-virtual {p1}, Landroid/location/Location;->getLongitude()D

    move-result-wide v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->l0:D

    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Landroidx/camera/core/ImageProxy;)V
    .locals 28

    move-object/from16 v0, p0

    .line 26
    const-string v1, "image"

    move-object/from16 v3, p1

    invoke-static {v3, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-boolean v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->p0:Z

    if-eqz v1, :cond_2

    iget-boolean v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->r0:Z

    if-nez v1, :cond_2

    iget-object v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;

    if-eqz v1, :cond_2

    const/4 v1, 0x1

    iput-boolean v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->r0:Z

    iget-object v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->t0:Landroid/content/SharedPreferences;

    const/4 v2, 0x0

    if-nez v1, :cond_0

    const-string v1, "licenseSharedPreferences"

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v1, v2

    :cond_0
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v5, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v5, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    const-string v5, ""

    invoke-interface {v1, v4, v5}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v12

    move-object v1, v2

    iget-object v2, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o0:Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;

    if-eqz v2, :cond_2

    iget-object v4, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    new-instance v5, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;

    move-object v6, v4

    move-object v4, v5

    iget-boolean v5, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->G:Z

    move-object v7, v6

    iget-boolean v6, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->H:Z

    move-object v8, v7

    iget-boolean v7, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->E:Z

    move-object v9, v8

    iget-boolean v8, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->S:Z

    move-object v10, v9

    iget-object v9, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    move-object v11, v10

    iget-boolean v10, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->W:Z

    move-object v13, v11

    iget-object v11, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    move-object v14, v13

    iget-object v13, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->O:Ljava/lang/Integer;

    move-object v15, v14

    iget-boolean v14, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u0:Z

    move-object/from16 v16, v15

    iget-boolean v15, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->v0:Z

    iget-boolean v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f0:Z

    move/from16 v17, v1

    iget-boolean v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->g0:Z

    move/from16 v18, v1

    iget-boolean v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h0:Z

    move/from16 v19, v1

    move-object/from16 v27, v2

    iget-wide v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->k0:D

    move-wide/from16 v20, v1

    iget-wide v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->l0:D

    move-wide/from16 v22, v1

    iget-boolean v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w0:Z

    iget v2, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x0:I

    move/from16 v24, v1

    iget-object v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    move-object/from16 v25, v1

    iget-object v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y0:Ljava/lang/String;

    move-object/from16 v26, v1

    move-object/from16 v1, v16

    move/from16 v16, v17

    move/from16 v17, v18

    move/from16 v18, v19

    move-wide/from16 v19, v20

    move-wide/from16 v21, v22

    move/from16 v23, v24

    move/from16 v24, v2

    invoke-direct/range {v4 .. v26}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;-><init>(ZZZZLandroid/util/Size;ZLcom/scanflow/datacapture/core/camera/manager/BeepManager;Ljava/lang/String;Ljava/lang/Integer;ZZZZZDDZILcom/scanflow/datacapture/config/VinNumberColorConfig;Ljava/lang/String;)V

    iget-object v2, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;

    if-nez v2, :cond_1

    const-string v2, "mOnAnalyzeListener"

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 v6, 0x0

    goto :goto_0

    :cond_1
    move-object v6, v2

    :goto_0
    iget-object v7, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w:Ljava/lang/Object;

    move-object v5, v4

    move-object/from16 v2, v27

    move-object v4, v1

    invoke-interface/range {v2 .. v7}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;->analyze(Landroidx/camera/core/ImageProxy;Landroidx/camera/core/Camera;Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Ljava/lang/Object;)V

    :cond_2
    invoke-interface/range {p1 .. p1}, Landroidx/camera/core/ImageProxy;->close()V

    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Lcom/scanflow/datacapture/barinternal/j/d;)V
    .locals 0

    .line 20
    iget-boolean p1, p1, Lcom/scanflow/datacapture/barinternal/j/d;->a:Z

    .line 21
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->W:Z

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b(Ljava/lang/String;)V

    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Ljava/lang/Object;)V
    .locals 0

    const/4 p1, 0x0

    .line 9
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->r0:Z

    return-void
.end method

.method public static final a(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)V
    .locals 0

    .line 8
    invoke-interface {p0, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method public static final a(Landroid/view/GestureDetector;Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Landroid/view/ScaleGestureDetector;Landroid/view/View;Landroid/view/MotionEvent;)Z
    .locals 5

    const-string p3, "event"

    invoke-static {p4, p3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0, p4}, Landroid/view/GestureDetector;->onTouchEvent(Landroid/view/MotionEvent;)Z

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 12
    invoke-virtual {p4}, Landroid/view/MotionEvent;->getPointerCount()I

    move-result p0

    const/4 p3, 0x1

    if-ne p0, p3, :cond_9

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getAction()I

    move-result p0

    if-eqz p0, :cond_8

    if-eq p0, p3, :cond_3

    const/4 v0, 0x2

    if-eq p0, v0, :cond_0

    goto/16 :goto_1

    :cond_0
    iget p0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->K:F

    iget v0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->L:F

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getX()F

    move-result v1

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getY()F

    move-result v2

    sub-float/2addr p0, v1

    float-to-double v3, p0

    sub-float/2addr v0, v2

    float-to-double v0, v0

    mul-double/2addr v3, v3

    mul-double/2addr v0, v0

    add-double/2addr v0, v3

    .line 13
    invoke-static {v0, v1}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    double-to-float p0, v0

    const/high16 v0, 0x41a00000    # 20.0f

    cmpg-float p0, p0, v0

    const/4 v1, 0x0

    if-gez p0, :cond_1

    move p0, p3

    goto :goto_0

    :cond_1
    move p0, v1

    .line 14
    :goto_0
    iput-boolean p0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->J:Z

    iget p0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->L:F

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getY()F

    move-result v2

    sub-float/2addr p0, v2

    invoke-static {p0}, Ljava/lang/Math;->abs(F)F

    move-result p0

    iget v2, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->K:F

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getX()F

    move-result v3

    sub-float/2addr v2, v3

    invoke-static {v2}, Ljava/lang/Math;->abs(F)F

    move-result v2

    cmpl-float p0, p0, v0

    if-lez p0, :cond_9

    const/high16 p0, 0x42a00000    # 80.0f

    cmpg-float p0, v2, p0

    if-gez p0, :cond_9

    iget p0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->L:F

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getY()F

    move-result v0

    cmpg-float p0, p0, v0

    if-gez p0, :cond_2

    invoke-virtual {p1, p3}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b(Z)V

    goto/16 :goto_1

    :cond_2
    iget p0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->L:F

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getY()F

    move-result p3

    cmpl-float p0, p0, p3

    if-lez p0, :cond_9

    invoke-virtual {p1, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b(Z)V

    goto/16 :goto_1

    :cond_3
    iget-object p0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    if-eqz p0, :cond_4

    const/16 p3, 0x8

    invoke-virtual {p0, p3}, Landroid/view/View;->setVisibility(I)V

    :cond_4
    iget-boolean p0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->J:Z

    if-eqz p0, :cond_9

    iget-wide v0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->I:J

    const/16 p0, 0x96

    int-to-long v2, p0

    add-long/2addr v0, v2

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    cmp-long p0, v0, v2

    if-lez p0, :cond_9

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getX()F

    move-result p0

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getY()F

    move-result p3

    .line 15
    iget-object v0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-nez v0, :cond_5

    goto :goto_1

    :cond_5
    iget-object v0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    if-nez v0, :cond_6

    const-string v0, "mPreviewView"

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 v0, 0x0

    :cond_6
    invoke-virtual {v0}, Landroidx/camera/view/PreviewView;->getMeteringPointFactory()Landroidx/camera/core/MeteringPointFactory;

    move-result-object v0

    invoke-virtual {v0, p0, p3}, Landroidx/camera/core/MeteringPointFactory;->createPoint(FF)Landroidx/camera/core/MeteringPoint;

    move-result-object v0

    const-string v1, "createPoint(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object p1, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz p1, :cond_7

    invoke-interface {p1}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object p1

    if-eqz p1, :cond_7

    new-instance v1, Landroidx/camera/core/FocusMeteringAction$Builder;

    invoke-direct {v1, v0}, Landroidx/camera/core/FocusMeteringAction$Builder;-><init>(Landroidx/camera/core/MeteringPoint;)V

    invoke-virtual {v1}, Landroidx/camera/core/FocusMeteringAction$Builder;->build()Landroidx/camera/core/FocusMeteringAction;

    move-result-object v0

    invoke-interface {p1, v0}, Landroidx/camera/core/CameraControl;->startFocusAndMetering(Landroidx/camera/core/FocusMeteringAction;)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_7
    sget-object p1, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "StartFocusAndMetering (x,y): "

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    const/16 p0, 0x2c

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p3}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    const-string p3, "DefaultCameraScan"

    invoke-virtual {p1, p3, p0}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_1

    .line 16
    :cond_8
    iput-boolean p3, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->J:Z

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getX()F

    move-result p0

    iput p0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->K:F

    invoke-virtual {p4}, Landroid/view/MotionEvent;->getY()F

    move-result p0

    iput p0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->L:F

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iput-wide v0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->I:J

    .line 17
    :cond_9
    :goto_1
    invoke-virtual {p2, p4}, Landroid/view/ScaleGestureDetector;->onTouchEvent(Landroid/view/MotionEvent;)Z

    move-result p0

    return p0
.end method

.method public static final b(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 0

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    sget-object p0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p0
.end method

.method public static final b(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)V
    .locals 0

    .line 12
    invoke-interface {p0, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method public static final c(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)V
    .locals 0

    .line 34
    invoke-interface {p0, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method public static final d(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)V
    .locals 0

    .line 1
    invoke-interface {p0, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method public final a()V
    .locals 7

    .line 3
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;

    if-eqz v0, :cond_0

    const-string v1, "Error 9, Error 10, Error 11 - Validation Failed\nPlease check your internet connection or contact administrator."

    invoke-interface {v0, v1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;->onLicenseFailure(Ljava/lang/String;)V

    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->t0:Landroid/content/SharedPreferences;

    if-nez v0, :cond_1

    const-string v0, "licenseSharedPreferences"

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 v0, 0x0

    :cond_1
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    const-string v2, ""

    invoke-interface {v0, v1, v2}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v0

    if-nez v0, :cond_2

    iget-object v6, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    new-instance v1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    const-string v4, "Error"

    const/4 v5, 0x0

    const-string v2, "Error 9, Error 10, Error 11 - Validation Failed\nPlease check your internet connection or contact administrator."

    const/4 v3, 0x0

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/model/subscription/Result;Ljava/lang/String;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;)V

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)V

    :cond_2
    return-void
.end method

.method public final a(Landroid/app/Activity;)V
    .locals 6

    .line 4
    const-string v0, "android.permission.ACCESS_FINE_LOCATION"

    invoke-static {p1, v0}, Landroidx/core/content/ContextCompat;->checkSelfPermission(Landroid/content/Context;Ljava/lang/String;)I

    move-result v0

    if-eqz v0, :cond_1

    const-string v0, "android.permission.ACCESS_COARSE_LOCATION"

    invoke-static {p1, v0}, Landroidx/core/content/ContextCompat;->checkSelfPermission(Landroid/content/Context;Ljava/lang/String;)I

    move-result p1

    if-nez p1, :cond_0

    goto :goto_0

    :cond_0
    return-void

    :cond_1
    :goto_0
    new-instance v5, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda12;

    invoke-direct {v5, p0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda12;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->j0:Landroid/location/LocationManager;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const-wide/16 v2, 0x0

    const/4 v4, 0x0

    const-string v1, "gps"

    invoke-virtual/range {v0 .. v5}, Landroid/location/LocationManager;->requestLocationUpdates(Ljava/lang/String;JFLandroid/location/LocationListener;)V

    return-void
.end method

.method public final a(Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)V
    .locals 10

    new-instance v0, Lcom/google/gson/Gson;

    invoke-direct {v0}, Lcom/google/gson/Gson;-><init>()V

    invoke-virtual {v0, p1}, Lcom/google/gson/Gson;->toJson(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    .line 27
    const-string v0, "PBKDF2WithHmacSHA256"

    invoke-static {v0}, Ljavax/crypto/SecretKeyFactory;->getInstance(Ljava/lang/String;)Ljavax/crypto/SecretKeyFactory;

    move-result-object v0

    new-instance v1, Ljavax/crypto/spec/PBEKeySpec;

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->t0:Landroid/content/SharedPreferences;

    const/4 v3, 0x0

    const-string v4, "licenseSharedPreferences"

    if-nez v2, :cond_0

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v3

    :cond_0
    iget-object v5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    const-string v6, ""

    invoke-interface {v2, v5, v6}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/String;->toCharArray()[C

    move-result-object v2

    const-string v5, "toCharArray(...)"

    invoke-static {v2, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->t0:Landroid/content/SharedPreferences;

    if-nez v5, :cond_1

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v5, v3

    :cond_1
    iget-object v7, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    invoke-interface {v5, v7, v6}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    invoke-static {v5}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v5

    sget-object v6, Lcom/scanflow/datacapture/barinternal/kotlin/text/Charsets;->UTF_8:Ljava/nio/charset/Charset;

    invoke-virtual {v5, v6}, Ljava/lang/String;->getBytes(Ljava/nio/charset/Charset;)[B

    move-result-object v5

    const-string v7, "getBytes(...)"

    invoke-static {v5, v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    const/high16 v8, 0x10000

    const/16 v9, 0x100

    invoke-direct {v1, v2, v5, v8, v9}, Ljavax/crypto/spec/PBEKeySpec;-><init>([C[BII)V

    invoke-virtual {v0, v1}, Ljavax/crypto/SecretKeyFactory;->generateSecret(Ljava/security/spec/KeySpec;)Ljavax/crypto/SecretKey;

    move-result-object v0

    new-instance v1, Ljavax/crypto/spec/SecretKeySpec;

    invoke-interface {v0}, Ljava/security/Key;->getEncoded()[B

    move-result-object v0

    const-string v2, "AES"

    invoke-direct {v1, v0, v2}, Ljavax/crypto/spec/SecretKeySpec;-><init>([BLjava/lang/String;)V

    const-string v0, "AES/GCM/NoPadding"

    invoke-static {v0}, Ljavax/crypto/Cipher;->getInstance(Ljava/lang/String;)Ljavax/crypto/Cipher;

    move-result-object v0

    const/16 v2, 0xc

    new-array v5, v2, [B

    new-instance v8, Ljava/security/SecureRandom;

    invoke-direct {v8}, Ljava/security/SecureRandom;-><init>()V

    invoke-virtual {v8, v5}, Ljava/security/SecureRandom;->nextBytes([B)V

    new-instance v8, Ljavax/crypto/spec/GCMParameterSpec;

    const/16 v9, 0x80

    invoke-direct {v8, v9, v5}, Ljavax/crypto/spec/GCMParameterSpec;-><init>(I[B)V

    const/4 v9, 0x1

    invoke-virtual {v0, v9, v1, v8}, Ljavax/crypto/Cipher;->init(ILjava/security/Key;Ljava/security/spec/AlgorithmParameterSpec;)V

    invoke-virtual {p1, v6}, Ljava/lang/String;->getBytes(Ljava/nio/charset/Charset;)[B

    move-result-object p1

    invoke-static {p1, v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v0, p1}, Ljavax/crypto/Cipher;->doFinal([B)[B

    move-result-object p1

    array-length v0, p1

    add-int/2addr v0, v2

    new-array v0, v0, [B

    const/4 v1, 0x0

    invoke-static {v5, v1, v0, v1, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    array-length v5, p1

    invoke-static {p1, v1, v0, v2, v5}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    invoke-static {}, Ljava/util/Base64;->getEncoder()Ljava/util/Base64$Encoder;

    move-result-object p1

    invoke-virtual {p1, v0}, Ljava/util/Base64$Encoder;->encodeToString([B)Ljava/lang/String;

    move-result-object p1

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    .line 28
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->t0:Landroid/content/SharedPreferences;

    if-nez v0, :cond_2

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    goto :goto_0

    :cond_2
    move-object v3, v0

    :goto_0
    invoke-interface {v3}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-interface {v0, v1, p1}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->apply()V

    return-void
.end method

.method public final a(Ljava/lang/Integer;)V
    .locals 4

    new-instance v0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    const/4 v2, 0x0

    const-string v3, "mContext"

    if-nez v1, :cond_0

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v1, v2

    :cond_0
    invoke-direct {v0, v1, p1}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;-><init>(Landroid/content/Context;Ljava/lang/Integer;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/e/a;

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    if-nez v0, :cond_1

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    goto :goto_0

    :cond_1
    move-object v2, v0

    :goto_0
    invoke-direct {p1, v2}, Lcom/scanflow/datacapture/barinternal/e/a;-><init>(Landroid/content/Context;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->A:Lcom/scanflow/datacapture/barinternal/e/a;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/e/a;->a()V

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->A:Lcom/scanflow/datacapture/barinternal/e/a;

    if-eqz p1, :cond_2

    .line 18
    const-string v0, "listener"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p0, p1, Lcom/scanflow/datacapture/barinternal/e/a;->e:Lcom/scanflow/datacapture/barinternal/e/a$a;

    :cond_2
    return-void
.end method

.method public final a(Ljava/lang/String;)V
    .locals 11

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->q0:Z

    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v1

    if-nez v1, :cond_0

    goto :goto_0

    :cond_0
    const/4 v1, 0x0

    const/4 v2, 0x2

    const-string v3, "SCANFLOW LICENSE"

    const/4 v4, 0x0

    invoke-static {p1, v3, v1, v2, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_2

    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;

    if-eqz v0, :cond_1

    const-string v1, "Error 12 - License Key Missing\nNo License key was set. Please set a valid license key"

    invoke-interface {v0, v1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;->onLicenseFailure(Ljava/lang/String;)V

    :cond_1
    new-instance v2, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    const-string v5, "Error"

    const/4 v6, 0x0

    const-string v3, "Error 12 - License Key Missing\nNo License key was set. Please set a valid license key"

    const/4 v4, 0x0

    move-object v7, p1

    invoke-direct/range {v2 .. v7}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/model/subscription/Result;Ljava/lang/String;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;)V

    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)V

    return-void

    :cond_2
    move-object v7, p1

    new-instance v5, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    const-string v8, "Error"

    const/4 v9, 0x0

    const-string v6, "Please wait while your license key is being verified"

    move-object v10, v7

    const/4 v7, 0x0

    invoke-direct/range {v5 .. v10}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/model/subscription/Result;Ljava/lang/String;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;)V

    move-object v7, v10

    invoke-virtual {p0, v5}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez p1, :cond_3

    const-string p1, "mActivity"

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object p1, v4

    :cond_3
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m0:Ljava/lang/String;

    invoke-static {p1, v1}, Lcom/scanflow/datacapture/barinternal/e/b;->a(Landroid/app/Activity;Ljava/lang/String;)Lcom/scanflow/datacapture/model/DeviceInfo;

    move-result-object p1

    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    const-string v2, "platform"

    const-string v3, "Android"

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/DeviceInfo;->getDeviceMake()Ljava/lang/String;

    move-result-object v2

    const-string v3, "deviceMake"

    invoke-virtual {v1, v3, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/DeviceInfo;->getDeviceModel()Ljava/lang/String;

    move-result-object v2

    const-string v3, "deviceModel"

    invoke-virtual {v1, v3, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/DeviceInfo;->getOsVersion()Ljava/lang/String;

    move-result-object v2

    const-string v3, "osVersion"

    invoke-virtual {v1, v3, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/DeviceInfo;->getBundleId()Ljava/lang/String;

    move-result-object v2

    const-string v3, "bundleId"

    invoke-virtual {v1, v3, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/DeviceInfo;->getDeviceId()Ljava/lang/String;

    move-result-object v2

    const-string v3, "deviceUId"

    invoke-virtual {v1, v3, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/DeviceInfo;->getProductType()Ljava/lang/String;

    move-result-object v2

    const-string v3, "productType"

    invoke-virtual {v1, v3, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1
    const-string v2, "apiUrl"

    const-string v3, "https://scanflowprod.azurewebsites.net/"

    invoke-static {v3, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v2, Lokhttp3/logging/HttpLoggingInterceptor;

    invoke-direct {v2, v4, v0, v4}, Lokhttp3/logging/HttpLoggingInterceptor;-><init>(Lokhttp3/logging/HttpLoggingInterceptor$Logger;ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    sget-object v0, Lokhttp3/logging/HttpLoggingInterceptor$Level;->NONE:Lokhttp3/logging/HttpLoggingInterceptor$Level;

    invoke-virtual {v2, v0}, Lokhttp3/logging/HttpLoggingInterceptor;->setLevel(Lokhttp3/logging/HttpLoggingInterceptor$Level;)Lokhttp3/logging/HttpLoggingInterceptor;

    new-instance v0, Lokhttp3/OkHttpClient$Builder;

    invoke-direct {v0}, Lokhttp3/OkHttpClient$Builder;-><init>()V

    sget-object v4, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    const-wide/16 v5, 0x3c

    invoke-virtual {v0, v5, v6, v4}, Lokhttp3/OkHttpClient$Builder;->connectTimeout(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;

    move-result-object v0

    invoke-virtual {v0, v5, v6, v4}, Lokhttp3/OkHttpClient$Builder;->writeTimeout(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;

    move-result-object v0

    invoke-virtual {v0, v5, v6, v4}, Lokhttp3/OkHttpClient$Builder;->readTimeout(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;

    move-result-object v0

    invoke-virtual {v0, v2}, Lokhttp3/OkHttpClient$Builder;->addInterceptor(Lokhttp3/Interceptor;)Lokhttp3/OkHttpClient$Builder;

    move-result-object v0

    invoke-virtual {v0}, Lokhttp3/OkHttpClient$Builder;->build()Lokhttp3/OkHttpClient;

    move-result-object v0

    new-instance v2, Lretrofit2/Retrofit$Builder;

    invoke-direct {v2}, Lretrofit2/Retrofit$Builder;-><init>()V

    invoke-virtual {v2, v3}, Lretrofit2/Retrofit$Builder;->baseUrl(Ljava/lang/String;)Lretrofit2/Retrofit$Builder;

    move-result-object v2

    invoke-virtual {v2, v0}, Lretrofit2/Retrofit$Builder;->client(Lokhttp3/OkHttpClient;)Lretrofit2/Retrofit$Builder;

    move-result-object v0

    invoke-static {}, Lretrofit2/converter/gson/GsonConverterFactory;->create()Lretrofit2/converter/gson/GsonConverterFactory;

    move-result-object v2

    invoke-virtual {v0, v2}, Lretrofit2/Retrofit$Builder;->addConverterFactory(Lretrofit2/Converter$Factory;)Lretrofit2/Retrofit$Builder;

    move-result-object v0

    invoke-virtual {v0}, Lretrofit2/Retrofit$Builder;->build()Lretrofit2/Retrofit;

    move-result-object v0

    const-class v2, Lcom/scanflow/datacapture/barinternal/g/a;

    invoke-virtual {v0, v2}, Lretrofit2/Retrofit;->create(Ljava/lang/Class;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/g/a;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    .line 2
    invoke-interface {v0, v7, v1}, Lcom/scanflow/datacapture/barinternal/g/a;->a(Ljava/lang/String;Ljava/util/HashMap;)Lretrofit2/Call;

    move-result-object v0

    new-instance v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;

    invoke-direct {v1, p0, p1, v7}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$b;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;)V

    invoke-interface {v0, v1}, Lretrofit2/Call;->enqueue(Lretrofit2/Callback;)V

    return-void
.end method

.method public final a(Z)V
    .locals 2

    .line 19
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m:Landroid/view/View;

    if-eqz v0, :cond_6

    const/4 v1, 0x0

    if-eqz p1, :cond_3

    iget-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C:Z

    if-eqz p1, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->isTorchEnabled()Z

    move-result p1

    if-nez p1, :cond_6

    const/4 p1, 0x1

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->enableTorch(Z)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m:Landroid/view/View;

    if-eqz v0, :cond_6

    invoke-virtual {v0, p1}, Landroid/view/View;->setSelected(Z)V

    return-void

    :cond_0
    invoke-virtual {v0}, Landroid/view/View;->getVisibility()I

    move-result p1

    if-nez p1, :cond_1

    goto :goto_0

    :cond_1
    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m:Landroid/view/View;

    if-eqz p1, :cond_2

    invoke-virtual {p1, v1}, Landroid/view/View;->setVisibility(I)V

    :cond_2
    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m:Landroid/view/View;

    if-eqz p1, :cond_6

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->isTorchEnabled()Z

    move-result v0

    invoke-virtual {p1, v0}, Landroid/view/View;->setSelected(Z)V

    return-void

    :cond_3
    invoke-virtual {v0}, Landroid/view/View;->getVisibility()I

    move-result p1

    if-nez p1, :cond_4

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->isTorchEnabled()Z

    move-result p1

    if-eqz p1, :cond_5

    :cond_4
    iget-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C:Z

    if-eqz p1, :cond_6

    :cond_5
    iget-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C:Z

    if-eqz p1, :cond_6

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->isTorchEnabled()Z

    move-result p1

    if-eqz p1, :cond_6

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->enableTorch(Z)V

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m:Landroid/view/View;

    if-eqz p1, :cond_6

    invoke-virtual {p1, v1}, Landroid/view/View;->setSelected(Z)V

    :cond_6
    :goto_0
    return-void
.end method

.method public final b()V
    .locals 3

    .line 11
    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v1, "DefaultCameraScan"

    const-string v2, "initCameraView()"

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v0, :cond_0

    const-string v0, "mActivity"

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 v0, 0x0

    :cond_0
    new-instance v1, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda11;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda11;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    return-void
.end method

.method public final b(Ljava/lang/String;)V
    .locals 11

    const-string v1, "Error occured during decryption: "

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->t0:Landroid/content/SharedPreferences;

    const-string v2, "licenseSharedPreferences"

    const/4 v3, 0x0

    if-nez v0, :cond_0

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v3

    :cond_0
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v5, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Y:Ljava/lang/String;

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    const-string v5, ""

    invoke-interface {v0, v4, v5}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    iget-boolean v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->W:Z

    if-eqz v4, :cond_7

    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v4

    if-lez v4, :cond_5

    .line 1
    :try_start_0
    invoke-static {}, Ljava/util/Base64;->getDecoder()Ljava/util/Base64$Decoder;

    move-result-object v4

    invoke-virtual {v4, v0}, Ljava/util/Base64$Decoder;->decode(Ljava/lang/String;)[B

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v4, 0x0

    const/16 v6, 0xc

    invoke-static {v0, v4, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyOfRange([BII)[B

    move-result-object v4

    array-length v7, v0

    invoke-static {v0, v6, v7}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyOfRange([BII)[B

    move-result-object v0

    new-instance v6, Ljavax/crypto/spec/GCMParameterSpec;

    const/16 v7, 0x80

    invoke-direct {v6, v7, v4}, Ljavax/crypto/spec/GCMParameterSpec;-><init>(I[B)V

    const-string v4, "PBKDF2WithHmacSHA256"

    invoke-static {v4}, Ljavax/crypto/SecretKeyFactory;->getInstance(Ljava/lang/String;)Ljavax/crypto/SecretKeyFactory;

    move-result-object v4

    new-instance v7, Ljavax/crypto/spec/PBEKeySpec;

    iget-object v8, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->t0:Landroid/content/SharedPreferences;

    if-nez v8, :cond_1

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v8, v3

    goto :goto_0

    :catch_0
    move-exception v0

    goto :goto_1

    :catch_1
    move-exception v0

    goto/16 :goto_2

    :catch_2
    move-exception v0

    goto/16 :goto_3

    :catch_3
    move-exception v0

    goto/16 :goto_4

    :catch_4
    move-exception v0

    goto/16 :goto_5

    :catch_5
    move-exception v0

    goto/16 :goto_6

    :catch_6
    move-exception v0

    goto/16 :goto_7

    :cond_1
    :goto_0
    iget-object v9, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    invoke-interface {v8, v9, v5}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v8

    invoke-static {v8}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/String;->toCharArray()[C

    move-result-object v8

    const-string v9, "toCharArray(...)"

    invoke-static {v8, v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v9, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->t0:Landroid/content/SharedPreferences;

    if-nez v9, :cond_2

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v9, v3

    :cond_2
    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    invoke-interface {v9, v2, v5}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    sget-object v5, Lcom/scanflow/datacapture/barinternal/kotlin/text/Charsets;->UTF_8:Ljava/nio/charset/Charset;

    invoke-virtual {v2, v5}, Ljava/lang/String;->getBytes(Ljava/nio/charset/Charset;)[B

    move-result-object v2

    const-string v9, "getBytes(...)"

    invoke-static {v2, v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    const/high16 v9, 0x10000

    const/16 v10, 0x100

    invoke-direct {v7, v8, v2, v9, v10}, Ljavax/crypto/spec/PBEKeySpec;-><init>([C[BII)V

    invoke-virtual {v4, v7}, Ljavax/crypto/SecretKeyFactory;->generateSecret(Ljava/security/spec/KeySpec;)Ljavax/crypto/SecretKey;

    move-result-object v2

    new-instance v4, Ljavax/crypto/spec/SecretKeySpec;

    invoke-interface {v2}, Ljava/security/Key;->getEncoded()[B

    move-result-object v2

    const-string v7, "AES"

    invoke-direct {v4, v2, v7}, Ljavax/crypto/spec/SecretKeySpec;-><init>([BLjava/lang/String;)V

    const-string v2, "AES/GCM/NoPadding"

    invoke-static {v2}, Ljavax/crypto/Cipher;->getInstance(Ljava/lang/String;)Ljavax/crypto/Cipher;

    move-result-object v2

    const/4 v7, 0x2

    invoke-virtual {v2, v7, v4, v6}, Ljavax/crypto/Cipher;->init(ILjava/security/Key;Ljava/security/spec/AlgorithmParameterSpec;)V

    invoke-virtual {v2, v0}, Ljavax/crypto/Cipher;->doFinal([B)[B

    move-result-object v0

    const-string v2, "doFinal(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v2, Ljava/lang/String;

    invoke-direct {v2, v0, v5}, Ljava/lang/String;-><init>([BLjava/nio/charset/Charset;)V
    :try_end_0
    .catch Ljava/security/InvalidAlgorithmParameterException; {:try_start_0 .. :try_end_0} :catch_6
    .catch Ljava/security/InvalidKeyException; {:try_start_0 .. :try_end_0} :catch_5
    .catch Ljava/security/NoSuchAlgorithmException; {:try_start_0 .. :try_end_0} :catch_4
    .catch Ljava/security/spec/InvalidKeySpecException; {:try_start_0 .. :try_end_0} :catch_3
    .catch Ljavax/crypto/BadPaddingException; {:try_start_0 .. :try_end_0} :catch_2
    .catch Ljavax/crypto/IllegalBlockSizeException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljavax/crypto/NoSuchPaddingException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_9

    :goto_1
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_2
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_3
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_4
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_5
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_6
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_7
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    :goto_8
    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    sget-object v1, Ljava/lang/System;->out:Ljava/io/PrintStream;

    invoke-virtual {v1, v0}, Ljava/io/PrintStream;->println(Ljava/lang/Object;)V

    move-object v2, v3

    .line 2
    :goto_9
    new-instance v0, Lcom/google/gson/Gson;

    invoke-direct {v0}, Lcom/google/gson/Gson;-><init>()V

    const-class v1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    invoke-virtual {v0, v2, v1}, Lcom/google/gson/Gson;->fromJson(Ljava/lang/String;Ljava/lang/Class;)Ljava/lang/Object;

    move-result-object v0

    const-string v1, "fromJson(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getResult()Lcom/scanflow/datacapture/model/subscription/Result;

    move-result-object v1

    if-eqz v1, :cond_5

    invoke-virtual {v1}, Lcom/scanflow/datacapture/model/subscription/Result;->getAnalyticsId()Ljava/lang/String;

    move-result-object v1

    if-eqz v1, :cond_5

    invoke-virtual {v0}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getResult()Lcom/scanflow/datacapture/model/subscription/Result;

    move-result-object v1

    if-eqz v1, :cond_5

    .line 3
    new-instance p1, Ljava/text/SimpleDateFormat;

    const-string v1, "yyyy-MM-dd\'T\'HH:mm:ss.SSS"

    invoke-direct {p1, v1}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getResult()Lcom/scanflow/datacapture/model/subscription/Result;

    move-result-object v2

    if-eqz v2, :cond_3

    invoke-virtual {v2}, Lcom/scanflow/datacapture/model/subscription/Result;->getSubscriptionEndDate()Ljava/lang/String;

    move-result-object v2

    if-eqz v2, :cond_3

    .line 4
    const-string v4, "UTC"

    invoke-static {v4}, Ljava/util/TimeZone;->getTimeZone(Ljava/lang/String;)Ljava/util/TimeZone;

    move-result-object v4

    .line 5
    const-string v5, "<this>"

    invoke-static {v2, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "dateFormat"

    invoke-static {v1, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v7, "timeZone"

    invoke-static {v4, v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v8, Ljava/text/SimpleDateFormat;

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v9

    invoke-direct {v8, v1, v9}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    invoke-virtual {v8, v4}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    invoke-virtual {v8, v2}, Ljava/text/DateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;

    move-result-object v2

    if-eqz v2, :cond_3

    .line 7
    invoke-static {}, Ljava/util/TimeZone;->getDefault()Ljava/util/TimeZone;

    move-result-object v4

    .line 8
    invoke-static {v2, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v1, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v4, v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v5, Ljava/text/SimpleDateFormat;

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v6

    invoke-direct {v5, v1, v6}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    invoke-virtual {v5, v4}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    invoke-virtual {v5, v2}, Ljava/text/DateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v1

    if-eqz v1, :cond_3

    .line 9
    invoke-virtual {p1, v1}, Ljava/text/DateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;

    move-result-object v1

    goto :goto_a

    :cond_3
    move-object v1, v3

    :goto_a
    new-instance v2, Ljava/util/Date;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-direct {v2, v4, v5}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v2, v1}, Ljava/util/Date;->after(Ljava/util/Date;)Z

    move-result v1

    if-eqz v1, :cond_6

    invoke-virtual {v0}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getResult()Lcom/scanflow/datacapture/model/subscription/Result;

    move-result-object v0

    if-eqz v0, :cond_4

    invoke-virtual {v0}, Lcom/scanflow/datacapture/model/subscription/Result;->getLastSyncDate()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_4

    invoke-virtual {p1, v0}, Ljava/text/DateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;

    move-result-object v3

    :cond_4
    if-eqz v3, :cond_6

    invoke-virtual {v3, v2}, Ljava/util/Date;->before(Ljava/util/Date;)Z

    move-result p1

    if-eqz p1, :cond_6

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Ljava/lang/String;)V

    goto :goto_b

    .line 10
    :cond_5
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Ljava/lang/String;)V

    :cond_6
    :goto_b
    return-void

    :cond_7
    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v0

    if-nez v0, :cond_9

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;

    if-eqz v0, :cond_8

    const-string v1, "Error 19 - Device Activation Failed\nThe device activation failed. Please connect to the Internet and restart the app."

    invoke-interface {v0, v1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;->onLicenseFailure(Ljava/lang/String;)V

    :cond_8
    new-instance v2, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    const-string v5, "Error"

    const/4 v6, 0x0

    const-string v3, "Error 19 - Device Activation Failed\nThe device activation failed. Please connect to the Internet and restart the app."

    const/4 v4, 0x0

    move-object v7, p1

    invoke-direct/range {v2 .. v7}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/model/subscription/Result;Ljava/lang/String;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;)V

    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)V

    return-void

    :cond_9
    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a()V

    return-void
.end method

.method public final b(Z)V
    .locals 4

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    if-eqz v0, :cond_6

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D:Z

    if-nez v1, :cond_6

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Landroid/view/View;->setVisibility(I)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/google/android/material/slider/Slider;->getValue()F

    move-result v0

    goto :goto_0

    :cond_0
    move v0, v1

    :goto_0
    cmpg-float v2, v1, v0

    if-gtz v2, :cond_6

    iget v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->M:F

    cmpg-float v3, v0, v2

    if-gtz v3, :cond_6

    if-eqz p1, :cond_1

    iget p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->N:F

    sub-float/2addr v0, p1

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    if-eqz p1, :cond_4

    cmpl-float v2, v0, v1

    if-lez v2, :cond_3

    :goto_1
    move v1, v0

    goto :goto_2

    :cond_1
    iget p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->N:F

    add-float/2addr v0, p1

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    if-eqz p1, :cond_4

    cmpg-float v1, v0, v2

    if-gez v1, :cond_2

    goto :goto_1

    :goto_2
    move v0, v1

    goto :goto_3

    :cond_2
    move v1, v2

    :cond_3
    :goto_3
    invoke-virtual {p1, v1}, Lcom/google/android/material/slider/Slider;->setValue(F)V

    :cond_4
    float-to-int p1, v0

    .line 14
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_6

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v1

    invoke-interface {v1}, Landroidx/camera/core/CameraInfo;->getExposureState()Landroidx/camera/core/ExposureState;

    move-result-object v1

    invoke-interface {v1}, Landroidx/camera/core/ExposureState;->getExposureCompensationIndex()I

    move-result v1

    if-eq v1, p1, :cond_6

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v0

    if-eqz v0, :cond_5

    invoke-interface {v0, p1}, Landroidx/camera/core/CameraControl;->setExposureCompensationIndex(I)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_5
    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "EXPOSURE: "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    const-string v1, "DefaultCameraScan"

    invoke-virtual {v0, v1, p1}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    :cond_6
    return-void
.end method

.method public final bindFlashlightView(Landroid/view/View;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m:Landroid/view/View;

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->A:Lcom/scanflow/datacapture/barinternal/e/a;

    if-eqz v0, :cond_1

    if-eqz p1, :cond_0

    const/4 p1, 0x1

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    .line 1
    :goto_0
    iput-boolean p1, v0, Lcom/scanflow/datacapture/barinternal/e/a;->d:Z

    :cond_1
    return-object p0
.end method

.method public final bindSliderView(Lcom/google/android/material/slider/Slider;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    return-object p0
.end method

.method public final c()V
    .locals 14

    const-string v0, "mContext"

    sget-object v1, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v2, "initData()"

    const-string v3, "DefaultCameraScan"

    invoke-virtual {v1, v3, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    const/4 v1, 0x0

    :try_start_0
    sget-object v2, Lcom/scanflow/datacapture/utils/StorageUtils;->INSTANCE:Lcom/scanflow/datacapture/utils/StorageUtils;

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    if-nez v4, :cond_0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_0
    const-string v5, "Scanflow"

    invoke-virtual {v2, v4, v5}, Lcom/scanflow/datacapture/utils/StorageUtils;->deleteDirectory(Landroid/content/Context;Ljava/lang/String;)Z

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->O:Ljava/lang/Integer;

    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Ljava/lang/Integer;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    new-instance v2, Landroidx/security/crypto/MasterKey$Builder;

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    const-string v5, "mActivity"

    if-nez v4, :cond_1

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_1
    const-string v6, "_androidx_security_master_key_"

    invoke-direct {v2, v4, v6}, Landroidx/security/crypto/MasterKey$Builder;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    sget-object v4, Landroidx/security/crypto/MasterKey$KeyScheme;->AES256_GCM:Landroidx/security/crypto/MasterKey$KeyScheme;

    invoke-virtual {v2, v4}, Landroidx/security/crypto/MasterKey$Builder;->setKeyScheme(Landroidx/security/crypto/MasterKey$KeyScheme;)Landroidx/security/crypto/MasterKey$Builder;

    move-result-object v2

    invoke-virtual {v2}, Landroidx/security/crypto/MasterKey$Builder;->build()Landroidx/security/crypto/MasterKey;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->s0:Landroidx/security/crypto/MasterKey;

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    if-nez v2, :cond_2

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    :cond_2
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    iget-object v6, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->s0:Landroidx/security/crypto/MasterKey;

    if-nez v6, :cond_3

    const-string v6, "masterKey"

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v6, v1

    :cond_3
    sget-object v7, Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;->AES256_SIV:Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;

    sget-object v8, Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;->AES256_GCM:Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;

    invoke-static {v2, v4, v6, v7, v8}, Landroidx/security/crypto/EncryptedSharedPreferences;->create(Landroid/content/Context;Ljava/lang/String;Landroidx/security/crypto/MasterKey;Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;)Landroid/content/SharedPreferences;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->t0:Landroid/content/SharedPreferences;

    if-nez v2, :cond_4

    const-string v2, "licenseSharedPreferences"

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    :cond_4
    invoke-interface {v2}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v2

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Z:Ljava/lang/String;

    iget-object v6, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c0:Ljava/lang/String;

    invoke-interface {v2, v4, v6}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a0:Ljava/lang/String;

    iget-object v6, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d0:Ljava/lang/String;

    invoke-interface {v2, v4, v6}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b0:Ljava/lang/String;

    iget-object v6, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e0:Ljava/lang/String;

    invoke-interface {v2, v4, v6}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    invoke-interface {v2}, Landroid/content/SharedPreferences$Editor;->apply()V

    new-instance v2, Landroidx/lifecycle/MutableLiveData;

    invoke-direct {v2}, Landroidx/lifecycle/MutableLiveData;-><init>()V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->q:Landroidx/lifecycle/MutableLiveData;

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    const-string v6, "mLifecycleOwner"

    if-nez v4, :cond_5

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_5
    new-instance v7, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda1;

    invoke-direct {v7, p0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    invoke-virtual {v2, v4, v7}, Landroidx/lifecycle/LiveData;->observe(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V

    new-instance v2, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;

    invoke-direct {v2, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;

    new-instance v2, Lcom/scanflow/datacapture/barinternal/j/c;

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    if-nez v4, :cond_6

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_6
    invoke-direct {v2, v4}, Lcom/scanflow/datacapture/barinternal/j/c;-><init>(Landroid/content/Context;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->T:Lcom/scanflow/datacapture/barinternal/j/c;

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v2, :cond_7

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    :cond_7
    const-string v4, "Scanflow_pref"

    const/4 v7, 0x0

    invoke-virtual {v2, v4, v7}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Q:Landroid/content/SharedPreferences;

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v2, :cond_8

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    :cond_8
    const-string v4, "scanflow_datastore"

    invoke-virtual {v2, v4, v7}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    .line 1
    const-string v4, "<set-?>"

    invoke-static {v2, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->U:Landroid/content/SharedPreferences;

    .line 2
    new-instance v2, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    iget-object v8, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    if-nez v8, :cond_9

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v8, v1

    :cond_9
    sget v9, Lcom/scanflow/datacapture/R$raw;->oneofmany_beep:I

    invoke-static {v9}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v9

    invoke-direct {v2, v8, v9}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;-><init>(Landroid/content/Context;Ljava/lang/Integer;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    invoke-virtual {v2, v7}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setVibrate(Z)V

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v2, :cond_a

    const/4 v8, 0x1

    invoke-virtual {v2, v8}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setPlayBeep(Z)V

    :cond_a
    new-instance v2, Landroidx/lifecycle/ViewModelProvider$AndroidViewModelFactory;

    iget-object v8, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v8, :cond_b

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v8, v1

    :cond_b
    invoke-virtual {v8}, Landroid/app/Activity;->getApplication()Landroid/app/Application;

    move-result-object v8

    const-string v9, "getApplication(...)"

    invoke-static {v8, v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {v2, v8}, Landroidx/lifecycle/ViewModelProvider$AndroidViewModelFactory;-><init>(Landroid/app/Application;)V

    const-class v8, Lcom/scanflow/datacapture/barinternal/h/b;

    invoke-virtual {v2, v8}, Landroidx/lifecycle/ViewModelProvider$AndroidViewModelFactory;->create(Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/h/b;

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->V:Lcom/scanflow/datacapture/barinternal/h/b;

    const-string v8, "sharedPreferenceViewModel"

    if-nez v2, :cond_c

    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    .line 3
    :cond_c
    iget-object v9, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->U:Landroid/content/SharedPreferences;

    if-eqz v9, :cond_d

    goto :goto_0

    :cond_d
    const-string v9, "sharedPref"

    invoke-static {v9}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v9, v1

    .line 4
    :goto_0
    invoke-virtual {v2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 5
    const-string v10, "sharedPreferences"

    invoke-static {v9, v10}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 6
    invoke-static {v9, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 7
    sget-object v10, Lcom/scanflow/datacapture/barinternal/h/c;->a:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    .line 8
    invoke-static {v9, v10}, Lcom/scanflow/datacapture/barinternal/h/d;->a(Landroid/content/SharedPreferences;Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Lcom/scanflow/datacapture/barinternal/h/a;

    move-result-object v10

    .line 9
    invoke-static {v10, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object v10, v2, Lcom/scanflow/datacapture/barinternal/h/b;->a:Lcom/scanflow/datacapture/barinternal/h/a;

    .line 10
    sget-object v10, Lcom/scanflow/datacapture/barinternal/h/c;->b:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    .line 11
    invoke-static {v9, v10}, Lcom/scanflow/datacapture/barinternal/h/d;->a(Landroid/content/SharedPreferences;Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Lcom/scanflow/datacapture/barinternal/h/a;

    move-result-object v10

    .line 12
    invoke-static {v10, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object v10, v2, Lcom/scanflow/datacapture/barinternal/h/b;->b:Lcom/scanflow/datacapture/barinternal/h/a;

    .line 13
    sget-object v10, Lcom/scanflow/datacapture/barinternal/h/c;->c:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    .line 14
    invoke-static {v9, v10}, Lcom/scanflow/datacapture/barinternal/h/d;->a(Landroid/content/SharedPreferences;Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Lcom/scanflow/datacapture/barinternal/h/a;

    move-result-object v10

    .line 15
    invoke-static {v10, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object v10, v2, Lcom/scanflow/datacapture/barinternal/h/b;->c:Lcom/scanflow/datacapture/barinternal/h/a;

    .line 16
    sget-object v10, Lcom/scanflow/datacapture/barinternal/h/c;->d:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    .line 17
    invoke-static {v9, v10}, Lcom/scanflow/datacapture/barinternal/h/d;->a(Landroid/content/SharedPreferences;Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Lcom/scanflow/datacapture/barinternal/h/a;

    move-result-object v9

    .line 18
    invoke-static {v9, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object v9, v2, Lcom/scanflow/datacapture/barinternal/h/b;->d:Lcom/scanflow/datacapture/barinternal/h/a;

    .line 19
    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v2, :cond_e

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    :cond_e
    invoke-virtual {v2}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    const-string v4, "com.usec.containermanagement"

    const/4 v9, 0x2

    invoke-static {v2, v4, v7, v9, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->equals$default(Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Z

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->V:Lcom/scanflow/datacapture/barinternal/h/b;

    if-nez v2, :cond_f

    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    .line 20
    :cond_f
    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/h/b;->a:Lcom/scanflow/datacapture/barinternal/h/a;

    if-eqz v2, :cond_10

    goto :goto_1

    .line 21
    :cond_10
    const-string v2, "DS_EXP_DATE"

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    .line 22
    :goto_1
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    if-nez v4, :cond_11

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_11
    new-instance v10, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda2;

    invoke-direct {v10, p0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    new-instance v11, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda3;

    invoke-direct {v11, v10}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda3;-><init>(Lkotlin/jvm/functions/Function1;)V

    invoke-virtual {v2, v4, v11}, Landroidx/lifecycle/LiveData;->observe(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->V:Lcom/scanflow/datacapture/barinternal/h/b;

    if-nez v2, :cond_12

    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    .line 23
    :cond_12
    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/h/b;->b:Lcom/scanflow/datacapture/barinternal/h/a;

    if-eqz v2, :cond_13

    goto :goto_2

    .line 24
    :cond_13
    const-string v2, "DS_EXP_MESSAGE"

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    .line 25
    :goto_2
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    if-nez v4, :cond_14

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_14
    new-instance v10, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda4;

    invoke-direct {v10, p0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    new-instance v11, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda5;

    invoke-direct {v11, v10}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda5;-><init>(Lkotlin/jvm/functions/Function1;)V

    invoke-virtual {v2, v4, v11}, Landroidx/lifecycle/LiveData;->observe(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->V:Lcom/scanflow/datacapture/barinternal/h/b;

    if-nez v2, :cond_15

    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    .line 26
    :cond_15
    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/h/b;->d:Lcom/scanflow/datacapture/barinternal/h/a;

    if-eqz v2, :cond_16

    goto :goto_3

    .line 27
    :cond_16
    const-string v2, "DS_RESTRICT_SCAN"

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    .line 28
    :goto_3
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    if-nez v4, :cond_17

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_17
    new-instance v10, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda6;

    invoke-direct {v10, p0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda6;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    new-instance v11, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda7;

    invoke-direct {v11, v10}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda7;-><init>(Lkotlin/jvm/functions/Function1;)V

    invoke-virtual {v2, v4, v11}, Landroidx/lifecycle/LiveData;->observe(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->V:Lcom/scanflow/datacapture/barinternal/h/b;

    if-nez v2, :cond_18

    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    .line 29
    :cond_18
    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/h/b;->c:Lcom/scanflow/datacapture/barinternal/h/a;

    if-eqz v2, :cond_19

    goto :goto_4

    .line 30
    :cond_19
    const-string v2, "DS_DEFAULT_EXPDAY"

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    .line 31
    :goto_4
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    if-nez v4, :cond_1a

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_1a
    new-instance v6, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda8;

    invoke-direct {v6, p0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda8;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    new-instance v8, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda9;

    invoke-direct {v8, v6}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda9;-><init>(Lkotlin/jvm/functions/Function1;)V

    invoke-virtual {v2, v4, v8}, Landroidx/lifecycle/LiveData;->observe(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Q:Landroid/content/SharedPreferences;

    const-string v4, "preference"

    if-nez v2, :cond_1b

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    :cond_1b
    const-string v6, ""

    const-string v8, "uniqueid"

    invoke-interface {v2, v8, v6}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->R:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v2

    if-nez v2, :cond_1e

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v6, "PlayStore/PROD_"

    invoke-direct {v2, v6}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-static {}, Ljava/util/UUID;->randomUUID()Ljava/util/UUID;

    move-result-object v6

    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    iput-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->R:Ljava/lang/String;

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->Q:Landroid/content/SharedPreferences;

    if-nez v2, :cond_1c

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    :cond_1c
    invoke-interface {v2}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v2

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->R:Ljava/lang/String;

    if-nez v4, :cond_1d

    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_1d
    invoke-interface {v2, v8, v4}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    invoke-interface {v2}, Landroid/content/SharedPreferences$Editor;->commit()Z

    :cond_1e
    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v2, :cond_1f

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v1

    :cond_1f
    invoke-virtual {v2}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    const-string v4, "com.scanflow.demoapp"

    invoke-static {v2, v4, v7, v9, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->equals$default(Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Z

    sget-object v2, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    invoke-virtual {v2, v7}, Lcom/scanflow/datacapture/utils/ScanflowLog;->enable(Z)V

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    if-nez v4, :cond_20

    const-string v4, "mPreviewView"

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    :cond_20
    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d()V

    .line 32
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    if-nez v4, :cond_21

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v1

    :cond_21
    invoke-virtual {v4}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v0

    if-eqz v0, :cond_22

    invoke-virtual {v0}, Landroid/content/res/Resources;->getDisplayMetrics()Landroid/util/DisplayMetrics;

    move-result-object v0

    goto :goto_5

    :cond_22
    move-object v0, v1

    :goto_5
    if-eqz v0, :cond_23

    iget v4, v0, Landroid/util/DisplayMetrics;->widthPixels:I

    goto :goto_6

    :cond_23
    const/16 v4, 0x1e0

    :goto_6
    if-eqz v0, :cond_24

    iget v0, v0, Landroid/util/DisplayMetrics;->heightPixels:I

    goto :goto_7

    :cond_24
    const/16 v0, 0x280

    :goto_7
    const-wide v10, 0x3fe6666666666666L    # 0.7

    if-ge v4, v0, :cond_26

    int-to-float v6, v4

    int-to-float v8, v0

    div-float/2addr v6, v8

    float-to-double v12, v6

    cmpl-double v6, v12, v10

    if-lez v6, :cond_25

    new-instance v6, Landroid/util/Size;

    div-int/lit8 v8, v4, 0x3

    mul-int/lit8 v8, v8, 0x4

    invoke-direct {v6, v4, v8}, Landroid/util/Size;-><init>(II)V

    goto :goto_8

    :cond_25
    new-instance v6, Landroid/util/Size;

    div-int/lit8 v8, v4, 0x9

    mul-int/lit8 v8, v8, 0x10

    invoke-direct {v6, v4, v8}, Landroid/util/Size;-><init>(II)V

    goto :goto_8

    :cond_26
    int-to-float v6, v0

    int-to-float v8, v4

    div-float/2addr v6, v8

    float-to-double v12, v6

    cmpl-double v6, v12, v10

    if-lez v6, :cond_27

    new-instance v6, Landroid/util/Size;

    div-int/lit8 v8, v0, 0x3

    mul-int/lit8 v8, v8, 0x4

    invoke-direct {v6, v8, v0}, Landroid/util/Size;-><init>(II)V

    goto :goto_8

    :cond_27
    new-instance v6, Landroid/util/Size;

    div-int/lit8 v8, v0, 0x9

    mul-int/lit8 v8, v8, 0x10

    invoke-direct {v6, v8, v0}, Landroid/util/Size;-><init>(II)V

    :goto_8
    iput-object v6, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->k:Landroid/util/Size;

    sget-object v6, Lkotlin/jvm/internal/StringCompanionObject;->INSTANCE:Lkotlin/jvm/internal/StringCompanionObject;

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    filled-new-array {v4, v0}, [Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0, v9}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v0

    const-string v4, "DisplayMetrics : %dx%d"

    invoke-static {v4, v0}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    const-string v4, "format(...)"

    invoke-static {v0, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v2, v3, v0}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    new-instance v0, Ljava/lang/StringBuilder;

    const-string v4, "TargetSize: "

    invoke-direct {v0, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->k:Landroid/util/Size;

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v2, v3, v0}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    .line 33
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v0, :cond_28

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v1

    :cond_28
    invoke-virtual {v0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v0

    const-string v2, "com.scanflow.demo.barcode"

    invoke-static {v0, v2, v7, v9, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->equals$default(Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Z

    return-void
.end method

.method public final captureBatchInventory()V
    .locals 7

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->j:Landroidx/camera/core/ImageCapture;

    if-eqz v0, :cond_3

    new-instance v1, Ljava/text/SimpleDateFormat;

    sget-object v2, Ljava/util/Locale;->US:Ljava/util/Locale;

    const-string v3, "yyyy-MM-dd-HH-mm-ss-SSS"

    invoke-direct {v1, v3, v2}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/text/Format;->format(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    new-instance v2, Landroid/content/ContentValues;

    invoke-direct {v2}, Landroid/content/ContentValues;-><init>()V

    const-string v3, "_display_name"

    invoke-virtual {v2, v3, v1}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    const-string v1, "mime_type"

    const-string v3, "image/jpeg"

    invoke-virtual {v2, v1, v3}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v3, 0x1c

    if-le v1, v3, :cond_0

    const-string v1, "relative_path"

    const-string v3, "Pictures/PATH"

    invoke-virtual {v2, v1, v3}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    :cond_0
    new-instance v1, Landroidx/camera/core/ImageCapture$OutputFileOptions$Builder;

    iget-object v3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    const/4 v4, 0x0

    const-string v5, "mActivity"

    if-nez v3, :cond_1

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v3, v4

    :cond_1
    invoke-virtual {v3}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object v3

    sget-object v6, Landroid/provider/MediaStore$Images$Media;->EXTERNAL_CONTENT_URI:Landroid/net/Uri;

    invoke-direct {v1, v3, v6, v2}, Landroidx/camera/core/ImageCapture$OutputFileOptions$Builder;-><init>(Landroid/content/ContentResolver;Landroid/net/Uri;Landroid/content/ContentValues;)V

    invoke-virtual {v1}, Landroidx/camera/core/ImageCapture$OutputFileOptions$Builder;->build()Landroidx/camera/core/ImageCapture$OutputFileOptions;

    move-result-object v1

    const-string v2, "build(...)"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v2, :cond_2

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    goto :goto_0

    :cond_2
    move-object v4, v2

    :goto_0
    invoke-static {v4}, Landroidx/core/content/ContextCompat;->getMainExecutor(Landroid/content/Context;)Ljava/util/concurrent/Executor;

    move-result-object v2

    new-instance v3, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$a;

    invoke-direct {v3, p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$a;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    invoke-virtual {v0, v1, v2, v3}, Landroidx/camera/core/ImageCapture;->takePicture(Landroidx/camera/core/ImageCapture$OutputFileOptions;Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageCapture$OnImageSavedCallback;)V

    :cond_3
    return-void
.end method

.method public final captureToScan()V
    .locals 1

    .line 0
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->H:Z

    return-void
.end method

.method public final d()V
    .locals 5
    .annotation build Landroid/annotation/SuppressLint;
        value = {
            "ClickableViewAccessibility"
        }
    .end annotation

    .line 2
    new-instance v0, Landroid/view/ScaleGestureDetector;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    const-string v2, "mContext"

    const/4 v3, 0x0

    if-nez v1, :cond_0

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v1, v3

    :cond_0
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$f;

    invoke-direct {v0, v1, v4}, Landroid/view/ScaleGestureDetector;-><init>(Landroid/content/Context;Landroid/view/ScaleGestureDetector$OnScaleGestureListener;)V

    new-instance v1, Landroid/view/GestureDetector;

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    if-nez v4, :cond_1

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v4, v3

    :cond_1
    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D0:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$e;

    invoke-direct {v1, v4, v2}, Landroid/view/GestureDetector;-><init>(Landroid/content/Context;Landroid/view/GestureDetector$OnGestureListener;)V

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    if-nez v2, :cond_2

    const-string v2, "mPreviewView"

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    goto :goto_0

    :cond_2
    move-object v3, v2

    :goto_0
    new-instance v2, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda0;

    invoke-direct {v2, v1, p0, v0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda0;-><init>(Landroid/view/GestureDetector;Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;Landroid/view/ScaleGestureDetector;)V

    invoke-virtual {v3, v2}, Landroid/view/View;->setOnTouchListener(Landroid/view/View$OnTouchListener;)V

    return-void
.end method

.method public final doValidateLicense()Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 2

    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->q0:Z

    if-nez v0, :cond_4

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v0, :cond_0

    const-string v0, "mActivity"

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 v0, 0x0

    .line 1
    :cond_0
    const-string v1, "context"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v1, "connectivity"

    invoke-virtual {v0, v1}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    const-string v1, "null cannot be cast to non-null type android.net.ConnectivityManager"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v0, Landroid/net/ConnectivityManager;

    invoke-virtual {v0}, Landroid/net/ConnectivityManager;->getActiveNetwork()Landroid/net/Network;

    move-result-object v1

    if-nez v1, :cond_1

    goto :goto_0

    :cond_1
    invoke-virtual {v0, v1}, Landroid/net/ConnectivityManager;->getNetworkCapabilities(Landroid/net/Network;)Landroid/net/NetworkCapabilities;

    move-result-object v0

    if-nez v0, :cond_2

    goto :goto_0

    :cond_2
    const/16 v1, 0xc

    invoke-virtual {v0, v1}, Landroid/net/NetworkCapabilities;->hasCapability(I)Z

    move-result v1

    if-eqz v1, :cond_3

    const/16 v1, 0x10

    invoke-virtual {v0, v1}, Landroid/net/NetworkCapabilities;->hasCapability(I)Z

    move-result v0

    if-eqz v0, :cond_3

    const/4 v0, 0x1

    goto :goto_1

    :cond_3
    :goto_0
    const/4 v0, 0x0

    .line 2
    :goto_1
    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->W:Z

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b(Ljava/lang/String;)V

    :cond_4
    return-object p0
.end method

.method public final doValidateLicenseWithRetry()Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->q0:Z

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->X:Ljava/lang/String;

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Ljava/lang/String;)V

    :cond_0
    return-object p0
.end method

.method public final e()V
    .locals 3

    .line 1
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getExposureState()Landroidx/camera/core/ExposureState;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-interface {v0}, Landroidx/camera/core/ExposureState;->isExposureCompensationSupported()Z

    move-result v0

    goto :goto_0

    :cond_0
    move v0, v1

    :goto_0
    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v2, :cond_1

    if-eqz v0, :cond_1

    invoke-interface {v2}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getExposureState()Landroidx/camera/core/ExposureState;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroidx/camera/core/ExposureState;->getExposureCompensationRange()Landroid/util/Range;

    move-result-object v0

    goto :goto_1

    :cond_1
    const/4 v0, 0x0

    :goto_1
    if-nez v0, :cond_3

    .line 2
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    if-eqz v0, :cond_2

    const/16 v2, 0x8

    invoke-virtual {v0, v2}, Landroid/view/View;->setVisibility(I)V

    :cond_2
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    if-eqz v0, :cond_7

    invoke-virtual {v0, v1}, Lcom/google/android/material/slider/Slider;->setEnabled(Z)V

    return-void

    :cond_3
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    if-eqz v1, :cond_4

    const/4 v2, 0x1

    invoke-virtual {v1, v2}, Lcom/google/android/material/slider/Slider;->setEnabled(Z)V

    :cond_4
    invoke-virtual {v0}, Landroid/util/Range;->getUpper()Ljava/lang/Comparable;

    move-result-object v0

    check-cast v0, Ljava/lang/Number;

    invoke-virtual {v0}, Ljava/lang/Number;->intValue()I

    move-result v0

    int-to-float v0, v0

    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->M:F

    const/4 v1, 0x0

    cmpl-float v2, v0, v1

    if-lez v2, :cond_5

    const/16 v2, 0x64

    int-to-float v2, v2

    div-float/2addr v0, v2

    goto :goto_2

    :cond_5
    const/high16 v0, 0x3f800000    # 1.0f

    :goto_2
    iput v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->N:F

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    if-eqz v0, :cond_6

    invoke-virtual {v0, v1}, Lcom/google/android/material/slider/Slider;->setValueFrom(F)V

    :cond_6
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->n:Lcom/google/android/material/slider/Slider;

    if-eqz v0, :cond_7

    iget v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->M:F

    invoke-virtual {v0, v1}, Lcom/google/android/material/slider/Slider;->setValueTo(F)V

    :cond_7
    return-void
.end method

.method public final enableSplitView(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    return-object p0
.end method

.method public final enableTorch(Z)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->hasFlashUnit()Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_0

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-interface {v0, p1}, Landroidx/camera/core/CameraControl;->enableTorch(Z)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_0
    return-void
.end method

.method public final enableTouchZoom(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    return-object p0
.end method

.method public final f()V
    .locals 7
    .annotation build Landroid/annotation/SuppressLint;
        value = {
            "UnsafeOptInUsageError"
        }
    .end annotation

    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v1, "DefaultCameraScan"

    const-string v2, "startCamerafunction()"

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->i0:Z

    const-string v1, "mActivity"

    const/4 v2, 0x0

    if-eqz v0, :cond_1

    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v0, :cond_0

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v2

    goto :goto_0

    :catch_0
    move-exception v0

    goto :goto_1

    :cond_0
    :goto_0
    const-string v3, "location"

    invoke-virtual {v0, v3}, Landroid/app/Activity;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v3

    const-string v4, "null cannot be cast to non-null type android.location.LocationManager"

    invoke-static {v3, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v3, Landroid/location/LocationManager;

    iput-object v3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->j0:Landroid/location/LocationManager;

    if-eqz v3, :cond_1

    const-string v4, "gps"

    invoke-virtual {v3, v4}, Landroid/location/LocationManager;->isProviderEnabled(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_1

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a(Landroid/app/Activity;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_2

    :goto_1
    invoke-virtual {v0}, Ljava/lang/Throwable;->printStackTrace()V

    :cond_1
    :goto_2
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v0, :cond_2

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    :cond_2
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->T:Lcom/scanflow/datacapture/barinternal/j/c;

    const-string v3, "internetManager"

    if-nez v0, :cond_3

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v2

    .line 1
    :cond_3
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/j/c;->b:Lcom/scanflow/datacapture/barinternal/j/a;

    .line 2
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/j/a;->a:Landroidx/lifecycle/MutableLiveData;

    .line 3
    new-instance v4, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda13;

    invoke-direct {v4, p0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda13;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V

    invoke-virtual {v0, p0, v4}, Landroidx/lifecycle/LiveData;->observe(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->T:Lcom/scanflow/datacapture/barinternal/j/c;

    if-nez v0, :cond_4

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v2

    .line 4
    :cond_4
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/j/c;->a:Lcom/scanflow/datacapture/barinternal/j/b;

    .line 5
    invoke-virtual {v3}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 6
    new-instance v3, Landroid/net/NetworkRequest$Builder;

    invoke-direct {v3}, Landroid/net/NetworkRequest$Builder;-><init>()V

    const/16 v4, 0xc

    invoke-virtual {v3, v4}, Landroid/net/NetworkRequest$Builder;->addCapability(I)Landroid/net/NetworkRequest$Builder;

    move-result-object v3

    const/16 v4, 0xd

    invoke-virtual {v3, v4}, Landroid/net/NetworkRequest$Builder;->addCapability(I)Landroid/net/NetworkRequest$Builder;

    move-result-object v3

    const/4 v4, 0x1

    invoke-virtual {v3, v4}, Landroid/net/NetworkRequest$Builder;->addTransportType(I)Landroid/net/NetworkRequest$Builder;

    move-result-object v3

    const/4 v5, 0x0

    invoke-virtual {v3, v5}, Landroid/net/NetworkRequest$Builder;->addTransportType(I)Landroid/net/NetworkRequest$Builder;

    move-result-object v3

    const/4 v5, 0x3

    invoke-virtual {v3, v5}, Landroid/net/NetworkRequest$Builder;->addTransportType(I)Landroid/net/NetworkRequest$Builder;

    move-result-object v3

    invoke-virtual {v3}, Landroid/net/NetworkRequest$Builder;->build()Landroid/net/NetworkRequest;

    move-result-object v3

    const-string v6, "build(...)"

    invoke-static {v3, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 7
    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/j/c;->c:Landroid/net/ConnectivityManager;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/j/c;->b:Lcom/scanflow/datacapture/barinternal/j/a;

    invoke-virtual {v6, v3, v0}, Landroid/net/ConnectivityManager;->registerNetworkCallback(Landroid/net/NetworkRequest;Landroid/net/ConnectivityManager$NetworkCallback;)V

    .line 8
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->i:Lcom/scanflow/datacapture/barinternal/d/a;

    if-nez v0, :cond_5

    new-instance v0, Lcom/scanflow/datacapture/barinternal/d/a;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/d/a;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->i:Lcom/scanflow/datacapture/barinternal/d/a;

    :cond_5
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->Companion:Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;

    iget-object v3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b:Landroid/app/Activity;

    if-nez v3, :cond_6

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v3, v2

    :cond_6
    invoke-virtual {v0, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider$Companion;->getInstance(Landroid/content/Context;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->g:Lcom/google/common/util/concurrent/ListenableFuture;

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    if-nez v0, :cond_7

    const-string v0, "mPreviewView"

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v2

    :cond_7
    invoke-virtual {v0}, Landroid/view/View;->getDisplay()Landroid/view/Display;

    move-result-object v0

    invoke-virtual {v0}, Landroid/view/Display;->getRotation()I

    move-result v0

    if-eq v0, v4, :cond_8

    if-eq v0, v5, :cond_8

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    :goto_3
    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e:Landroid/util/Size;

    goto :goto_4

    :cond_8
    new-instance v1, Landroid/util/Size;

    iget-object v3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    invoke-virtual {v3}, Landroid/util/Size;->getHeight()I

    move-result v3

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    invoke-virtual {v4}, Landroid/util/Size;->getWidth()I

    move-result v4

    invoke-direct {v1, v3, v4}, Landroid/util/Size;-><init>(II)V

    goto :goto_3

    :goto_4
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->g:Lcom/google/common/util/concurrent/ListenableFuture;

    if-eqz v1, :cond_a

    new-instance v3, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda14;

    invoke-direct {v3, p0, v0}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/core/camera/BaseCameraCaptureScan$$ExternalSyntheticLambda14;-><init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;I)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->a:Landroid/app/Activity;

    if-nez v0, :cond_9

    const-string v0, "mContext"

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    goto :goto_5

    :cond_9
    move-object v2, v0

    :goto_5
    invoke-static {v2}, Landroidx/core/content/ContextCompat;->getMainExecutor(Landroid/content/Context;)Ljava/util/concurrent/Executor;

    move-result-object v0

    invoke-interface {v1, v3, v0}, Lcom/google/common/util/concurrent/ListenableFuture;->addListener(Ljava/lang/Runnable;Ljava/util/concurrent/Executor;)V

    :cond_a
    return-void
.end method

.method public final getCamera()Landroidx/camera/core/Camera;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    return-object v0
.end method

.method public final getLifecycle()Landroidx/lifecycle/Lifecycle;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    return-object v0
.end method

.method public final hasFlashUnit()Z
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_0

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->hasFlashUnit()Z

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public final isTorchEnabled()Z
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getTorchState()Landroidx/lifecycle/LiveData;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Integer;

    if-nez v0, :cond_0

    goto :goto_0

    :cond_0
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_1

    return v1

    :cond_1
    :goto_0
    const/4 v0, 0x0

    return v0
.end method

.method public final lineZoomIn()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-nez v0, :cond_0

    goto :goto_1

    :cond_0
    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroidx/camera/core/ZoomState;

    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroidx/camera/core/ZoomState;->getLinearZoom()F

    move-result v0

    const v1, 0x3dcccccd    # 0.1f

    add-float/2addr v0, v1

    goto :goto_0

    :cond_1
    const/4 v0, 0x0

    :goto_0
    const/high16 v1, 0x3f800000    # 1.0f

    cmpg-float v1, v0, v1

    if-gtz v1, :cond_2

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v1, :cond_2

    invoke-interface {v1}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v1

    if-eqz v1, :cond_2

    invoke-interface {v1, v0}, Landroidx/camera/core/CameraControl;->setLinearZoom(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_2
    :goto_1
    return-void
.end method

.method public final lineZoomOut()V
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-nez v0, :cond_0

    goto :goto_1

    :cond_0
    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    const/4 v1, 0x0

    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroidx/camera/core/ZoomState;

    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroidx/camera/core/ZoomState;->getLinearZoom()F

    move-result v0

    const v2, 0x3dcccccd    # 0.1f

    sub-float/2addr v0, v2

    goto :goto_0

    :cond_1
    move v0, v1

    :goto_0
    cmpl-float v1, v0, v1

    if-ltz v1, :cond_2

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v1, :cond_2

    invoke-interface {v1}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v1

    if-eqz v1, :cond_2

    invoke-interface {v1, v0}, Landroidx/camera/core/CameraControl;->setLinearZoom(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_2
    :goto_1
    return-void
.end method

.method public final lineZoomTo(F)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_0

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-interface {v0, p1}, Landroidx/camera/core/CameraControl;->setLinearZoom(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_0
    return-void
.end method

.method public final performOneTouchClick()Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;

    if-eqz v0, :cond_0

    invoke-interface {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;->onStarted()V

    :cond_0
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->E:Z

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->S:Z

    return-object p0
.end method

.method public final release()V
    .locals 1

    .line 0
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->m:Landroid/view/View;

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->A:Lcom/scanflow/datacapture/barinternal/e/a;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/e/a;->b()V

    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->close()V

    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->stopCamera()V

    return-void
.end method

.method public final resetOneToManyCodes()Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    return-object p0
.end method

.method public final setAutoExposure(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->D:Z

    return-object p0
.end method

.method public final setAutoFlashlight(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->C:Z

    return-object p0
.end method

.method public final setAutoZoom(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->E:Z

    return-object p0
.end method

.method public final setBeepSoundResource(I)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->O:Ljava/lang/Integer;

    return-object p0
.end method

.method public final setCameraResolution(Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "size"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->getSize()Landroid/util/Size;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->d:Landroid/util/Size;

    return-object p0
.end method

.method public final setEchanceTextCount(I)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x0:I

    return-object p0
.end method

.method public final setEnableDataTracking(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f0:Z

    return-object p0
.end method

.method public final setEnableLocationTracking(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->i0:Z

    return-object p0
.end method

.method public final setEnableTireAngleDetection(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h0:Z

    return-object p0
.end method

.method public final setEnableTirePreProcessing(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->g0:Z

    return-object p0
.end method

.method public final setEnhanceTextResult(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w0:Z

    return-object p0
.end method

.method public final setIsBatchScanning(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    return-object p0
.end method

.method public final setIsContinuousScan(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->G:Z

    return-object p0
.end method

.method public final setOnBarcodeScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "callback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->r:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w:Ljava/lang/Object;

    return-object p0
.end method

.method public final setOnCameraResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "callback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w:Ljava/lang/Object;

    return-object p0
.end method

.method public final setOnIDCardScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "callback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->s:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w:Ljava/lang/Object;

    return-object p0
.end method

.method public final setOnLicenseValidationCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "callback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->x:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;

    return-object p0
.end method

.method public final setOnOneTouchCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "onOneTouchCallback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;

    return-object p0
.end method

.method public final setOnTextComponentScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "callback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->t:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w:Ljava/lang/Object;

    return-object p0
.end method

.method public final setOnTextComponentVinPlateScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "callback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w:Ljava/lang/Object;

    return-object p0
.end method

.method public final setOnTextComponentVinStickerScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "callback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->v:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w:Ljava/lang/Object;

    return-object p0
.end method

.method public final setOnTextScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "callback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->p:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback;

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w:Ljava/lang/Object;

    return-object p0
.end method

.method public final setOnWebServiceScanResultCallback(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnWebServiceScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "callback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->w:Ljava/lang/Object;

    return-object p0
.end method

.method public final setOneToManyCodes(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    return-object p0
.end method

.method public final setOneToManyCodesKeepCurrent(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    return-object p0
.end method

.method public final setPlayBeep(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->u0:Z

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v0, :cond_0

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setPlayBeep(Z)V

    :cond_0
    return-object p0
.end method

.method public final setQrBarcodeDetection(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    return-object p0
.end method

.method public final setSwitchCategory(Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "switchCategory"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->y0:Ljava/lang/String;

    return-object p0
.end method

.method public final setVibrate(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->v0:Z

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v0, :cond_0

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setVibrate(Z)V

    :cond_0
    return-object p0
.end method

.method public final setVinNumberColor(Lcom/scanflow/datacapture/config/VinNumberColorConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 1

    .line 0
    const-string v0, "selectedVinNumberColorConfig"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->B0:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    return-object p0
.end method

.method public final startCamera()V
    .locals 5

    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v1, "DefaultCameraScan"

    const-string v2, "startCamera()"

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    const/4 v1, 0x0

    if-eqz v0, :cond_4

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->g:Lcom/google/common/util/concurrent/ListenableFuture;

    if-eqz v0, :cond_0

    invoke-interface {v0}, Ljava/util/concurrent/Future;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->unbindAll()V

    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_3

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    if-eqz v0, :cond_3

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getCameraSelector()Landroidx/camera/core/CameraSelector;

    move-result-object v0

    if-eqz v0, :cond_3

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->g:Lcom/google/common/util/concurrent/ListenableFuture;

    if-eqz v2, :cond_3

    invoke-interface {v2}, Ljava/util/concurrent/Future;->get()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    if-eqz v2, :cond_3

    iget-object v3, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    if-nez v3, :cond_1

    const-string v3, "mLifecycleOwner"

    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v3, v1

    :cond_1
    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->A0:Landroidx/camera/core/UseCaseGroup;

    if-nez v4, :cond_2

    const-string v4, "useCaseGroup"

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    goto :goto_0

    :cond_2
    move-object v1, v4

    :goto_0
    invoke-virtual {v2, v3, v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->bindToLifecycle(Landroidx/lifecycle/LifecycleOwner;Landroidx/camera/core/CameraSelector;Landroidx/camera/core/UseCaseGroup;)Landroidx/camera/core/Camera;

    .line 1
    :cond_3
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->z0:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v1, Landroidx/lifecycle/Lifecycle$State;->STARTED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v0, v1}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    .line 2
    iget v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->F:F

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->lineZoomTo(F)V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->e()V

    return-void

    :cond_4
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    const-string v2, "mPreviewView"

    if-nez v0, :cond_5

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v1

    :cond_5
    invoke-virtual {v0}, Landroid/view/View;->getWidth()I

    move-result v0

    if-lez v0, :cond_7

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f:Landroidx/camera/view/PreviewView;

    if-nez v0, :cond_6

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    goto :goto_1

    :cond_6
    move-object v1, v0

    :goto_1
    invoke-virtual {v1}, Landroid/view/View;->getHeight()I

    move-result v0

    if-lez v0, :cond_7

    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->f()V

    return-void

    :cond_7
    invoke-virtual {p0}, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->b()V

    return-void
.end method

.method public final stopCamera()V
    .locals 1

    .line 0
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->g:Lcom/google/common/util/concurrent/ListenableFuture;

    if-eqz v0, :cond_0

    invoke-interface {v0}, Ljava/util/concurrent/Future;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/lifecycle/ProcessCameraProvider;->unbindAll()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception v0

    goto :goto_0

    :cond_0
    return-void

    :goto_0
    invoke-virtual {v0}, Ljava/lang/Throwable;->printStackTrace()V

    return-void
.end method

.method public final updateConfidenceValue(F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;
    .locals 0

    .line 0
    return-object p0
.end method

.method public final zoomIn()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v0

    invoke-virtual {v0}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    check-cast v0, Landroidx/camera/core/ZoomState;

    invoke-interface {v0}, Landroidx/camera/core/ZoomState;->getZoomRatio()F

    move-result v0

    const v1, 0x3dcccccd    # 0.1f

    add-float/2addr v0, v1

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v1}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v1

    invoke-interface {v1}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v1

    invoke-virtual {v1}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v1

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    check-cast v1, Landroidx/camera/core/ZoomState;

    invoke-interface {v1}, Landroidx/camera/core/ZoomState;->getMaxZoomRatio()F

    move-result v1

    cmpg-float v1, v0, v1

    if-gtz v1, :cond_0

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v1}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v1

    invoke-interface {v1, v0}, Landroidx/camera/core/CameraControl;->setZoomRatio(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_0
    return-void
.end method

.method public final zoomOut()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v0

    invoke-virtual {v0}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    check-cast v0, Landroidx/camera/core/ZoomState;

    invoke-interface {v0}, Landroidx/camera/core/ZoomState;->getZoomRatio()F

    move-result v0

    const v1, 0x3dcccccd    # 0.1f

    sub-float/2addr v0, v1

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v1}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v1

    invoke-interface {v1}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v1

    invoke-virtual {v1}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v1

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    check-cast v1, Landroidx/camera/core/ZoomState;

    invoke-interface {v1}, Landroidx/camera/core/ZoomState;->getMinZoomRatio()F

    move-result v1

    cmpl-float v1, v0, v1

    if-ltz v1, :cond_0

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v1}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v1

    invoke-interface {v1, v0}, Landroidx/camera/core/CameraControl;->setZoomRatio(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_0
    return-void
.end method

.method public final zoomTo(F)V
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-nez v0, :cond_0

    goto :goto_2

    :cond_0
    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroidx/camera/core/ZoomState;

    goto :goto_0

    :cond_1
    const/4 v0, 0x0

    :goto_0
    const/4 v1, 0x0

    if-eqz v0, :cond_2

    invoke-interface {v0}, Landroidx/camera/core/ZoomState;->getMaxZoomRatio()F

    move-result v2

    goto :goto_1

    :cond_2
    move v2, v1

    :goto_1
    if-eqz v0, :cond_3

    invoke-interface {v0}, Landroidx/camera/core/ZoomState;->getMinZoomRatio()F

    move-result v1

    :cond_3
    invoke-static {p1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->coerceAtMost(FF)F

    move-result p1

    invoke-static {p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/RangesKt;->coerceAtLeast(FF)F

    move-result p1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->h:Landroidx/camera/core/Camera;

    if-eqz v0, :cond_4

    invoke-interface {v0}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v0

    if-eqz v0, :cond_4

    invoke-interface {v0, p1}, Landroidx/camera/core/CameraControl;->setZoomRatio(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_4
    :goto_2
    return-void
.end method
