.class public final Lcom/scanflow/datacapture/barinternal/M;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;
.implements Landroidx/lifecycle/LifecycleOwner;


# instance fields
.field public final A:Ljava/lang/String;

.field public final B:Ljava/util/LinkedList;

.field public final C:Landroidx/lifecycle/MutableLiveData;

.field public final D:Landroidx/lifecycle/MutableLiveData;

.field public final E:Landroid/os/Handler;

.field public F:Ljava/util/ArrayList;

.field public final G:Lcom/scanflow/ui/ar/ArObjectTracker;

.field public final H:J

.field public final I:J

.field public final J:Ljava/util/HashSet;

.field public final K:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

.field public final L:Lcom/scanflow/datacapture/barinternal/v;

.field public M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

.field public N:Landroid/util/Size;

.field public final O:Lcom/scanflow/datacapture/sfbarcode/SFCameraView;

.field public P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

.field public Q:Ljava/util/ArrayList;

.field public R:Z

.field public final S:Ljava/util/concurrent/atomic/AtomicBoolean;

.field public final T:Landroid/content/SharedPreferences;

.field public final U:Ljava/lang/String;

.field public final V:Ljava/lang/String;

.field public final W:Ljava/lang/String;

.field public X:Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

.field public final Y:I

.field public final Z:I

.field public a:Ljava/lang/String;

.field public final a0:Landroidx/lifecycle/MutableLiveData;

.field public b:Z

.field public b0:Ljava/util/HashSet;

.field public c:Z

.field public d:Z

.field public final e:Lcom/scanflow/datacapture/barinternal/g;

.field public final f:Landroid/app/Activity;

.field public final g:Lcom/scanflow/datacapture/barinternal/N;

.field public h:Z

.field public final i:Ljava/util/concurrent/ExecutorService;

.field public j:Landroid/graphics/Matrix;

.field public k:Landroid/graphics/Matrix;

.field public l:Landroid/graphics/Matrix;

.field public final m:Lcom/scanflow/datacapture/barinternal/L;

.field public n:Z

.field public final o:F

.field public p:Z

.field public q:Z

.field public final r:Ljava/lang/String;

.field public s:I

.field public t:I

.field public u:Z

.field public v:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;

.field public final w:Landroidx/lifecycle/LifecycleRegistry;

.field public x:Ljava/util/ArrayList;

.field public final y:I

.field public final z:Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;


# direct methods
.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/sfbarcode/SFCameraView;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)V
    .locals 25

    move-object/from16 v1, p0

    move-object/from16 v2, p1

    move-object/from16 v0, p2

    move-object/from16 v3, p3

    move-object/from16 v4, p4

    const-string v5, "mActivity"

    invoke-static {v2, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v5, "sfCameraView"

    invoke-static {v3, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v5, "decodeConfig"

    invoke-static {v4, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v5, "SCANFLOW_LICENSE_KEY"

    invoke-static {v0, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    const-string v5, "qr_code"

    iput-object v5, v1, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    const-string v5, "SFBarcode"

    invoke-static {}, Ljava/util/concurrent/Executors;->newSingleThreadExecutor()Ljava/util/concurrent/ExecutorService;

    move-result-object v6

    iput-object v6, v1, Lcom/scanflow/datacapture/barinternal/M;->i:Ljava/util/concurrent/ExecutorService;

    new-instance v6, Landroid/graphics/Matrix;

    invoke-direct {v6}, Landroid/graphics/Matrix;-><init>()V

    iput-object v6, v1, Lcom/scanflow/datacapture/barinternal/M;->l:Landroid/graphics/Matrix;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    new-instance v7, Lcom/scanflow/datacapture/barinternal/L;

    invoke-direct {v7, v6}, Lcom/scanflow/datacapture/barinternal/L;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;)V

    iput-object v7, v1, Lcom/scanflow/datacapture/barinternal/M;->m:Lcom/scanflow/datacapture/barinternal/L;

    const v6, 0x3dcccccd    # 0.1f

    iput v6, v1, Lcom/scanflow/datacapture/barinternal/M;->o:F

    const/4 v6, 0x1

    iput-boolean v6, v1, Lcom/scanflow/datacapture/barinternal/M;->p:Z

    const-string v7, "sharp"

    iput-object v7, v1, Lcom/scanflow/datacapture/barinternal/M;->r:Ljava/lang/String;

    new-instance v7, Landroidx/lifecycle/LifecycleRegistry;

    invoke-direct {v7, v1}, Landroidx/lifecycle/LifecycleRegistry;-><init>(Landroidx/lifecycle/LifecycleOwner;)V

    iput-object v7, v1, Lcom/scanflow/datacapture/barinternal/M;->w:Landroidx/lifecycle/LifecycleRegistry;

    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->x:Ljava/util/ArrayList;

    const/4 v8, 0x3

    iput v8, v1, Lcom/scanflow/datacapture/barinternal/M;->y:I

    const-string v8, "SuperResolution"

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->A:Ljava/lang/String;

    new-instance v8, Ljava/util/LinkedList;

    invoke-direct {v8}, Ljava/util/LinkedList;-><init>()V

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->B:Ljava/util/LinkedList;

    new-instance v8, Landroidx/lifecycle/MutableLiveData;

    invoke-direct {v8}, Landroidx/lifecycle/MutableLiveData;-><init>()V

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->C:Landroidx/lifecycle/MutableLiveData;

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->D:Landroidx/lifecycle/MutableLiveData;

    new-instance v8, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v9

    invoke-direct {v8, v9}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->E:Landroid/os/Handler;

    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    new-instance v8, Lcom/scanflow/ui/ar/ArObjectTracker;

    invoke-direct {v8}, Lcom/scanflow/ui/ar/ArObjectTracker;-><init>()V

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->G:Lcom/scanflow/ui/ar/ArObjectTracker;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v8

    iput-wide v8, v1, Lcom/scanflow/datacapture/barinternal/M;->H:J

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    const-wide/16 v8, 0x7d0

    iput-wide v8, v1, Lcom/scanflow/datacapture/barinternal/M;->I:J

    new-instance v8, Ljava/util/HashSet;

    invoke-direct {v8}, Ljava/util/HashSet;-><init>()V

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->J:Ljava/util/HashSet;

    new-instance v8, Landroid/util/Size;

    const/16 v9, 0x438

    const/16 v10, 0x780

    invoke-direct {v8, v9, v10}, Landroid/util/Size;-><init>(II)V

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->N:Landroid/util/Size;

    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->Q:Ljava/util/ArrayList;

    new-instance v8, Ljava/util/concurrent/atomic/AtomicBoolean;

    const/4 v9, 0x0

    invoke-direct {v8, v9}, Ljava/util/concurrent/atomic/AtomicBoolean;-><init>(Z)V

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->S:Ljava/util/concurrent/atomic/AtomicBoolean;

    const-string v8, "SECRET_KEY_PREF_NAME"

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->U:Ljava/lang/String;

    const-string v8, "SALTVALUE_PREF_NAME"

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->V:Ljava/lang/String;

    const-string v8, "MODEL_FILE_KEY_PREF_NAME"

    iput-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->W:Ljava/lang/String;

    const/16 v10, 0x14

    invoke-static {v10}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v11

    iput v10, v1, Lcom/scanflow/datacapture/barinternal/M;->Y:I

    const/16 v12, 0x37

    invoke-static {v12}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v13

    iput v12, v1, Lcom/scanflow/datacapture/barinternal/M;->Z:I

    new-instance v14, Landroidx/lifecycle/MutableLiveData;

    invoke-direct {v14}, Landroidx/lifecycle/MutableLiveData;-><init>()V

    new-instance v15, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-direct {v15, v13, v11}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    invoke-virtual {v14, v15}, Landroidx/lifecycle/MutableLiveData;->setValue(Ljava/lang/Object;)V

    iput-object v14, v1, Lcom/scanflow/datacapture/barinternal/M;->a0:Landroidx/lifecycle/MutableLiveData;

    const-string v14, "#2256DE"

    invoke-static {v14}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    const-string v14, "#FF543E"

    invoke-static {v14}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    const-string v14, "#FFAF4D"

    invoke-static {v14}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    const-string v14, "#3098F1"

    invoke-static {v14}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    new-instance v14, Ljava/util/HashSet;

    invoke-direct {v14}, Ljava/util/HashSet;-><init>()V

    iput-object v14, v1, Lcom/scanflow/datacapture/barinternal/M;->b0:Ljava/util/HashSet;

    new-instance v14, Ljava/util/ArrayList;

    invoke-direct {v14}, Ljava/util/ArrayList;-><init>()V

    sget-object v14, Landroidx/lifecycle/Lifecycle$State;->CREATED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v7, v14}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    iput-object v3, v1, Lcom/scanflow/datacapture/barinternal/M;->O:Lcom/scanflow/datacapture/sfbarcode/SFCameraView;

    iput-object v2, v1, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    sget-object v7, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    invoke-virtual {v7, v9}, Lcom/scanflow/datacapture/utils/ScanflowLog;->enable(Z)V

    new-instance v14, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    sget v15, Lcom/scanflow/datacapture/barcode/R$raw;->oneofmany_beep:I

    invoke-static {v15}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v15

    invoke-direct {v14, v2, v15}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;-><init>(Landroid/content/Context;Ljava/lang/Integer;)V

    iput-object v14, v1, Lcom/scanflow/datacapture/barinternal/M;->K:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    invoke-virtual {v14, v9}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setVibrate(Z)V

    invoke-virtual {v14, v6}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setPlayBeep(Z)V

    new-instance v9, Landroidx/security/crypto/MasterKey$Builder;

    const-string v14, "_androidx_security_master_key_"

    invoke-direct {v9, v2, v14}, Landroidx/security/crypto/MasterKey$Builder;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    sget-object v14, Landroidx/security/crypto/MasterKey$KeyScheme;->AES256_GCM:Landroidx/security/crypto/MasterKey$KeyScheme;

    invoke-virtual {v9, v14}, Landroidx/security/crypto/MasterKey$Builder;->setKeyScheme(Landroidx/security/crypto/MasterKey$KeyScheme;)Landroidx/security/crypto/MasterKey$Builder;

    move-result-object v9

    invoke-virtual {v9}, Landroidx/security/crypto/MasterKey$Builder;->build()Landroidx/security/crypto/MasterKey;

    move-result-object v9

    const/4 v14, 0x0

    if-nez v9, :cond_0

    const-string v9, "masterKey"

    invoke-static {v9}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v9, v14

    :cond_0
    sget-object v15, Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;->AES256_SIV:Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;

    sget-object v12, Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;->AES256_GCM:Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;

    invoke-static {v2, v0, v9, v15, v12}, Landroidx/security/crypto/EncryptedSharedPreferences;->create(Landroid/content/Context;Ljava/lang/String;Landroidx/security/crypto/MasterKey;Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;)Landroid/content/SharedPreferences;

    move-result-object v0

    iput-object v0, v1, Lcom/scanflow/datacapture/barinternal/M;->T:Landroid/content/SharedPreferences;

    const-string v9, "licenseSharedPreferences"

    if-nez v0, :cond_1

    invoke-static {v9}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v12, v14

    goto :goto_0

    :cond_1
    move-object v12, v0

    :goto_0
    invoke-interface {v12}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v12

    const-string v15, "WN*J8yH19c9szb9#"

    invoke-interface {v12, v8, v15}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    invoke-interface {v12}, Landroid/content/SharedPreferences$Editor;->apply()V

    if-nez v0, :cond_2

    invoke-static {v9}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v14

    :cond_2
    const-string v12, ""

    invoke-interface {v0, v8, v12}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    const-string v8, "MODEL_FILE"

    invoke-virtual {v7, v8, v0}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    new-instance v0, Lcom/scanflow/datacapture/barinternal/v;

    invoke-direct {v0, v2}, Lcom/scanflow/datacapture/barinternal/v;-><init>(Landroid/content/Context;)V

    iput-object v0, v1, Lcom/scanflow/datacapture/barinternal/M;->L:Lcom/scanflow/datacapture/barinternal/v;

    invoke-virtual {v1, v4}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)V

    .line 1
    :try_start_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/g;

    invoke-direct {v0, v2}, Lcom/scanflow/datacapture/barinternal/g;-><init>(Landroid/app/Activity;)V

    .line 2
    iput-object v0, v1, Lcom/scanflow/datacapture/barinternal/M;->e:Lcom/scanflow/datacapture/barinternal/g;

    const-string v0, "Blur Detection Classifier initialized successfully"

    invoke-static {v5, v0}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    :catch_0
    move-exception v0

    new-instance v7, Ljava/lang/StringBuilder;

    const-string v8, "Failed to initialize Blur Detection Classifier: "

    invoke-direct {v7, v8}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v7, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v5, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    iput-object v14, v1, Lcom/scanflow/datacapture/barinternal/M;->e:Lcom/scanflow/datacapture/barinternal/g;

    :goto_1
    invoke-virtual {v2}, Landroid/content/Context;->getAssets()Landroid/content/res/AssetManager;

    move-result-object v0

    if-eqz v0, :cond_4

    iget-object v0, v1, Lcom/scanflow/datacapture/barinternal/M;->T:Landroid/content/SharedPreferences;

    if-nez v0, :cond_3

    invoke-static {v9}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    goto :goto_2

    :cond_3
    move-object v14, v0

    :goto_2
    iget-object v0, v1, Lcom/scanflow/datacapture/barinternal/M;->W:Ljava/lang/String;

    invoke-interface {v14, v0, v12}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v2, v0}, Lcom/scanflow/datacapture/barinternal/m;->a(Landroid/content/Context;Ljava/lang/String;)Ljava/io/File;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    .line 3
    new-instance v14, Lcom/scanflow/datacapture/barinternal/N;

    invoke-direct {v14, v2, v0}, Lcom/scanflow/datacapture/barinternal/N;-><init>(Landroid/content/Context;Ljava/io/File;)V

    .line 4
    :cond_4
    iput-object v14, v1, Lcom/scanflow/datacapture/barinternal/M;->g:Lcom/scanflow/datacapture/barinternal/N;

    if-eqz v14, :cond_5

    .line 5
    invoke-virtual {v14}, Lcom/scanflow/datacapture/barinternal/N;->a()V

    .line 6
    :cond_5
    iget-object v0, v1, Lcom/scanflow/datacapture/barinternal/M;->z:Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;

    if-nez v0, :cond_6

    new-instance v0, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;

    invoke-direct {v0, v6}, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;-><init>(Z)V

    iput-object v0, v1, Lcom/scanflow/datacapture/barinternal/M;->z:Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;

    iget-object v5, v1, Lcom/scanflow/datacapture/barinternal/M;->A:Ljava/lang/String;

    sget-object v6, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->CPU:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    const/4 v7, 0x4

    invoke-virtual {v0, v2, v5, v6, v7}, Lcom/scanflow/datacapture/core/source/super_resolution/h;->init(Landroid/content/Context;Ljava/lang/String;Lcom/scanflow/datacapture/core/source/super_resolution/Device;I)Z

    .line 7
    :cond_6
    iget-object v0, v1, Lcom/scanflow/datacapture/barinternal/M;->w:Landroidx/lifecycle/LifecycleRegistry;

    sget-object v2, Landroidx/lifecycle/Lifecycle$State;->STARTED:Landroidx/lifecycle/Lifecycle$State;

    invoke-virtual {v0, v2}, Landroidx/lifecycle/LifecycleRegistry;->setCurrentState(Landroidx/lifecycle/Lifecycle$State;)V

    .line 8
    invoke-virtual {v3}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->getArOverlayView()Lcom/scanflow/ui/ar/ArOverlayView;

    move-result-object v0

    const-string v2, "getArOverlayView(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/ui/ar/ArOverlayView;)V

    invoke-virtual {v3}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->isBorderCornersRounded()Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v24

    invoke-virtual {v3}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->mTopLeftColor()Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v20

    invoke-virtual {v3}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->mTopRightColor()Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v21

    invoke-virtual {v3}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->mBottomLeftColor()Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v22

    invoke-virtual {v3}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->mBottomRightColor()Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v23

    sget-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->DOTMATRIX_WHITE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    if-eq v4, v0, :cond_9

    sget-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->DOTMATRIX_METAL:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    if-ne v4, v0, :cond_7

    goto :goto_4

    :cond_7
    sget-object v0, Lcom/scanflow/datacapture/barcode/config/DecodeConfig;->BARCODE:Lcom/scanflow/datacapture/barcode/config/DecodeConfig;

    if-ne v4, v0, :cond_8

    const/16 v0, 0xa

    iput v0, v1, Lcom/scanflow/datacapture/barinternal/M;->Y:I

    const/16 v2, 0x50

    iput v2, v1, Lcom/scanflow/datacapture/barinternal/M;->Z:I

    new-instance v4, Landroidx/lifecycle/MutableLiveData;

    invoke-direct {v4}, Landroidx/lifecycle/MutableLiveData;-><init>()V

    new-instance v5, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    invoke-direct {v5, v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    :goto_3
    invoke-virtual {v4, v5}, Landroidx/lifecycle/MutableLiveData;->setValue(Ljava/lang/Object;)V

    iput-object v4, v1, Lcom/scanflow/datacapture/barinternal/M;->a0:Landroidx/lifecycle/MutableLiveData;

    goto :goto_5

    :cond_8
    iput v10, v1, Lcom/scanflow/datacapture/barinternal/M;->Y:I

    const/16 v2, 0x37

    iput v2, v1, Lcom/scanflow/datacapture/barinternal/M;->Z:I

    new-instance v0, Landroidx/lifecycle/MutableLiveData;

    invoke-direct {v0}, Landroidx/lifecycle/MutableLiveData;-><init>()V

    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-direct {v2, v13, v11}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    invoke-virtual {v0, v2}, Landroidx/lifecycle/MutableLiveData;->setValue(Ljava/lang/Object;)V

    iput-object v0, v1, Lcom/scanflow/datacapture/barinternal/M;->a0:Landroidx/lifecycle/MutableLiveData;

    goto :goto_5

    :cond_9
    :goto_4
    const/16 v0, 0x46

    iput v0, v1, Lcom/scanflow/datacapture/barinternal/M;->Y:I

    const/16 v2, 0x52

    iput v2, v1, Lcom/scanflow/datacapture/barinternal/M;->Z:I

    new-instance v4, Landroidx/lifecycle/MutableLiveData;

    invoke-direct {v4}, Landroidx/lifecycle/MutableLiveData;-><init>()V

    new-instance v5, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    invoke-direct {v5, v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    goto :goto_3

    :goto_5
    sget-object v16, Lcom/scanflow/datacapture/sfcamera/SFTextOverlay;->INSTANCE:Lcom/scanflow/datacapture/sfcamera/SFTextOverlay;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->getSurfaceView()Landroid/view/SurfaceView;

    move-result-object v0

    const-string v2, "getSurfaceView(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/M;->Z:I

    iget v3, v1, Lcom/scanflow/datacapture/barinternal/M;->Y:I

    move-object/from16 v17, v0

    move/from16 v18, v2

    move/from16 v19, v3

    invoke-virtual/range {v16 .. v24}, Lcom/scanflow/datacapture/sfcamera/SFTextOverlay;->setTextCaptureOverlay(Landroid/view/SurfaceView;IIIIIIZ)V

    return-void
.end method

.method public static a(Landroid/graphics/Point;Landroid/graphics/Point;)D
    .locals 2

    .line 3
    const-string v0, "p1"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "p2"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget v0, p0, Landroid/graphics/Point;->y:I

    iget v1, p1, Landroid/graphics/Point;->y:I

    sub-int/2addr v0, v1

    int-to-double v0, v0

    iget p1, p1, Landroid/graphics/Point;->x:I

    iget p0, p0, Landroid/graphics/Point;->x:I

    sub-int/2addr p1, p0

    int-to-double p0, p1

    invoke-static {v0, v1, p0, p1}, Ljava/lang/Math;->atan2(DD)D

    move-result-wide p0

    invoke-static {p0, p1}, Ljava/lang/Math;->toDegrees(D)D

    move-result-wide p0

    const-wide/16 v0, 0x0

    cmpg-double v0, p0, v0

    if-gez v0, :cond_0

    const-wide v0, 0x4076800000000000L    # 360.0

    add-double/2addr p0, v0

    :cond_0
    return-wide p0
.end method

.method public static a(Landroid/graphics/Bitmap;Landroid/graphics/RectF;)Landroid/graphics/Bitmap;
    .locals 5

    .line 8
    iget v0, p1, Landroid/graphics/RectF;->left:F

    const/16 v1, 0x19

    int-to-float v1, v1

    sub-float v2, v0, v1

    const/4 v3, 0x0

    cmpg-float v4, v2, v3

    if-gtz v4, :cond_0

    goto :goto_0

    :cond_0
    move v0, v2

    :goto_0
    iget v2, p1, Landroid/graphics/RectF;->top:F

    sub-float v1, v2, v1

    cmpg-float v4, v1, v3

    if-gtz v4, :cond_1

    goto :goto_1

    :cond_1
    move v2, v1

    :goto_1
    cmpl-float v1, v0, v3

    if-lez v1, :cond_2

    cmpl-float v1, v2, v3

    if-lez v1, :cond_2

    :try_start_0
    invoke-static {p0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    float-to-int v0, v0

    float-to-int v1, v2

    invoke-virtual {p1}, Landroid/graphics/RectF;->width()F

    move-result v2

    float-to-int v2, v2

    add-int/lit8 v2, v2, 0x32

    invoke-virtual {p1}, Landroid/graphics/RectF;->height()F

    move-result v3

    float-to-int v3, v3

    invoke-virtual {p1}, Landroid/graphics/RectF;->height()F

    move-result p1

    float-to-int p1, p1

    div-int/lit8 p1, p1, 0x2

    add-int/2addr v3, p1

    invoke-static {p0, v0, v1, v2, v3}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIII)Landroid/graphics/Bitmap;

    move-result-object p0

    return-object p0

    :cond_2
    invoke-static {p0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v0, p1, Landroid/graphics/RectF;->left:F

    float-to-int v0, v0

    iget v1, p1, Landroid/graphics/RectF;->top:F

    float-to-int v1, v1

    invoke-virtual {p1}, Landroid/graphics/RectF;->width()F

    move-result v2

    float-to-int v2, v2

    invoke-virtual {p1}, Landroid/graphics/RectF;->height()F

    move-result p1

    float-to-int p1, p1

    invoke-static {p0, v0, v1, v2, p1}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIII)Landroid/graphics/Bitmap;

    move-result-object p0
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    return-object p0

    :catch_0
    const/4 p0, 0x0

    return-object p0
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lcom/scanflow/datacapture/barinternal/M;ZLandroid/graphics/RectF;Lcom/scanflow/datacapture/barinternal/b;Landroid/graphics/Bitmap;Lcom/google/mlkit/vision/text/Text;)Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    .locals 20

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    move-object/from16 v2, p4

    const-string v3, "$listener"

    invoke-static {v0, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v3, "this$0"

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v3, "$location"

    move-object/from16 v9, p3

    invoke-static {v9, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v3, "$result"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v3, "$croppedBitmap"

    move-object/from16 v11, p5

    invoke-static {v11, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual/range {p6 .. p6}, Lcom/google/mlkit/vision/text/Text;->getText()Ljava/lang/String;

    move-result-object v3

    if-eqz v3, :cond_19

    invoke-virtual {v3}, Ljava/lang/String;->length()I

    move-result v3

    if-nez v3, :cond_0

    goto/16 :goto_f

    :cond_0
    invoke-virtual/range {p6 .. p6}, Lcom/google/mlkit/vision/text/Text;->getTextBlocks()Ljava/util/List;

    move-result-object v3

    const-string v4, "getTextBlocks(...)"

    invoke-static {v3, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 73
    new-instance v4, Ljava/util/ArrayList;

    invoke-direct {v4}, Ljava/util/ArrayList;-><init>()V

    invoke-interface {v3}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v5

    if-eqz v5, :cond_1

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v4, v5}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 74
    :cond_1
    new-instance v3, Ljava/lang/StringBuilder;

    const-string v5, "data "

    invoke-direct {v3, v5}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v4}, Ljava/util/ArrayList;->size()I

    move-result v5

    invoke-virtual {v3, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    const-string v5, "refinedResult"

    invoke-static {v5, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    const/4 v3, 0x0

    move v6, v3

    :goto_1
    invoke-virtual {v4}, Ljava/util/ArrayList;->size()I

    move-result v7

    if-ge v6, v7, :cond_2

    new-instance v7, Ljava/lang/StringBuilder;

    const-string v8, "Before "

    invoke-direct {v7, v8}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v4, v6}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v8}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getText()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v8, " "

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v6}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v8}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getBoundingBox()Landroid/graphics/Rect;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v5, v7}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    add-int/lit8 v6, v6, 0x1

    goto :goto_1

    :cond_2
    invoke-virtual {v4}, Ljava/util/ArrayList;->size()I

    move-result v6

    const-string v7, "\n"

    const-string v8, ""

    const/4 v10, 0x1

    if-ne v6, v10, :cond_3

    invoke-virtual {v4, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v4}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getText()Ljava/lang/String;

    move-result-object v4

    :goto_2
    move-object v9, v4

    goto/16 :goto_9

    :cond_3
    new-instance v6, Lcom/scanflow/datacapture/barinternal/P;

    invoke-direct {v6}, Lcom/scanflow/datacapture/barinternal/P;-><init>()V

    invoke-static {v4, v6}, Ljava/util/Collections;->sort(Ljava/util/List;Ljava/util/Comparator;)V

    new-instance v6, Ljava/util/ArrayList;

    invoke-direct {v6}, Ljava/util/ArrayList;-><init>()V

    new-instance v12, Ljava/util/ArrayList;

    invoke-direct {v12}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v4, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v13

    check-cast v13, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v13}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getBoundingBox()Landroid/graphics/Rect;

    move-result-object v13

    iget v13, v13, Landroid/graphics/Rect;->top:I

    add-int/lit8 v13, v13, -0xa

    int-to-double v13, v13

    invoke-virtual {v4, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v15

    check-cast v15, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v15}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getBoundingBox()Landroid/graphics/Rect;

    move-result-object v15

    iget v15, v15, Landroid/graphics/Rect;->top:I

    add-int/lit8 v15, v15, 0xa

    move/from16 p6, v10

    int-to-double v10, v15

    move v15, v3

    move-object v3, v8

    :goto_3
    invoke-virtual {v4}, Ljava/util/ArrayList;->size()I

    move-result v9

    if-ge v15, v9, :cond_7

    if-nez v15, :cond_4

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v12, v9}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v9, Ljava/lang/StringBuilder;

    move-wide/from16 v16, v10

    const-string v10, "if (idx == 0) "

    invoke-direct {v9, v10}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v10}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getText()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v5, v9}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v9, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    :goto_4
    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v3}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getText()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v9, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    move-wide/from16 v10, v16

    goto/16 :goto_5

    :cond_4
    move-wide/from16 v16, v10

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v9}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getBoundingBox()Landroid/graphics/Rect;

    move-result-object v9

    iget v9, v9, Landroid/graphics/Rect;->top:I

    int-to-double v9, v9

    cmpl-double v9, v9, v13

    if-ltz v9, :cond_5

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v9}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getBoundingBox()Landroid/graphics/Rect;

    move-result-object v9

    iget v9, v9, Landroid/graphics/Rect;->top:I

    int-to-double v9, v9

    cmpg-double v9, v9, v16

    if-gtz v9, :cond_5

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v12, v9}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v9, Ljava/lang/StringBuilder;

    const-string v10, "data.get(idx).getBoundingBox().top "

    invoke-direct {v9, v10}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v10}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getText()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v5, v9}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v9, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v9, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_4

    :cond_5
    new-instance v9, Ljava/util/ArrayList;

    invoke-direct {v9, v12}, Ljava/util/ArrayList;-><init>(Ljava/util/Collection;)V

    invoke-virtual {v6, v9}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v9, Ljava/util/ArrayList;

    invoke-direct {v9}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v9, v10}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v10, Ljava/lang/StringBuilder;

    const-string v11, "else.get(idx).getBoundingBox().top "

    invoke-direct {v10, v11}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v11

    check-cast v11, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v11}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getText()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-static {v5, v10}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v10, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v3}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getText()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v10, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v10}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getBoundingBox()Landroid/graphics/Rect;

    move-result-object v10

    iget v10, v10, Landroid/graphics/Rect;->top:I

    add-int/lit8 v10, v10, -0xa

    int-to-double v10, v10

    invoke-virtual {v4, v15}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v12

    check-cast v12, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v12}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getBoundingBox()Landroid/graphics/Rect;

    move-result-object v12

    iget v12, v12, Landroid/graphics/Rect;->top:I

    add-int/lit8 v12, v12, 0xa

    int-to-double v12, v12

    move-wide/from16 v18, v12

    move-wide v13, v10

    move-wide/from16 v10, v18

    move-object v12, v9

    :goto_5
    invoke-virtual {v4}, Ljava/util/ArrayList;->size()I

    move-result v9

    add-int/lit8 v9, v9, -0x1

    if-ne v15, v9, :cond_6

    invoke-virtual {v12}, Ljava/util/ArrayList;->isEmpty()Z

    move-result v9

    if-nez v9, :cond_6

    new-instance v9, Ljava/util/ArrayList;

    invoke-direct {v9, v12}, Ljava/util/ArrayList;-><init>(Ljava/util/Collection;)V

    invoke-virtual {v6, v9}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    :cond_6
    add-int/lit8 v15, v15, 0x1

    goto/16 :goto_3

    :cond_7
    new-instance v4, Ljava/lang/StringBuilder;

    const-string v9, "- - "

    invoke-direct {v4, v9}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v4, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v5, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v3, Ljava/lang/StringBuilder;

    const-string v4, "line "

    invoke-direct {v3, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v12}, Ljava/util/ArrayList;->size()I

    move-result v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v5, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v6}, Ljava/util/ArrayList;->size()I

    move-result v4

    const/4 v9, 0x0

    :goto_6
    if-ge v9, v4, :cond_9

    invoke-virtual {v6, v9}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v10

    add-int/lit8 v9, v9, 0x1

    check-cast v10, Ljava/util/ArrayList;

    invoke-virtual {v10}, Ljava/util/ArrayList;->size()I

    move-result v11

    move/from16 v12, p6

    if-le v11, v12, :cond_8

    new-instance v11, Lcom/scanflow/datacapture/barinternal/O;

    invoke-direct {v11}, Lcom/scanflow/datacapture/barinternal/O;-><init>()V

    invoke-static {v10, v11}, Ljava/util/Collections;->sort(Ljava/util/List;Ljava/util/Comparator;)V

    :cond_8
    invoke-virtual {v3, v10}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    const/16 p6, 0x1

    goto :goto_6

    :cond_9
    new-instance v4, Ljava/lang/StringBuilder;

    const-string v6, "finalData "

    invoke-direct {v4, v6}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v3}, Ljava/util/ArrayList;->size()I

    move-result v6

    invoke-virtual {v4, v6}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v5, v4}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    move-object v4, v8

    const/4 v6, 0x0

    :goto_7
    invoke-virtual {v3}, Ljava/util/ArrayList;->size()I

    move-result v9

    if-ge v6, v9, :cond_b

    const/4 v9, 0x0

    :goto_8
    invoke-virtual {v3, v6}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Ljava/util/ArrayList;

    invoke-virtual {v10}, Ljava/util/ArrayList;->size()I

    move-result v10

    if-ge v9, v10, :cond_a

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v10, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v6}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/ArrayList;

    invoke-virtual {v4, v9}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mlkit/vision/text/Text$TextBlock;

    invoke-virtual {v4}, Lcom/google/mlkit/vision/text/Text$TextBlock;->getText()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v10, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    add-int/lit8 v9, v9, 0x1

    goto :goto_8

    :cond_a
    sget-object v9, Ljava/lang/System;->out:Ljava/io/PrintStream;

    const-string v10, "--------------------"

    invoke-virtual {v9, v10}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    add-int/lit8 v6, v6, 0x1

    goto :goto_7

    :cond_b
    sget-object v3, Ljava/lang/System;->out:Ljava/io/PrintStream;

    new-instance v6, Ljava/lang/StringBuilder;

    const-string v9, "finalrefinedOutput---before-----"

    invoke-direct {v6, v9}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v6, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v3, v6}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    new-instance v3, Ljava/lang/StringBuilder;

    const-string v6, "-final- "

    invoke-direct {v3, v6}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v5, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_2

    :goto_9
    if-eqz v9, :cond_19

    .line 75
    invoke-virtual {v9}, Ljava/lang/String;->length()I

    move-result v3

    if-nez v3, :cond_c

    goto/16 :goto_f

    .line 76
    :cond_c
    const-string v3, "text"

    invoke-static {v9, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    filled-new-array {v7}, [Ljava/lang/String;

    move-result-object v10

    const/4 v13, 0x6

    const/4 v14, 0x0

    const/4 v11, 0x0

    const/4 v12, 0x0

    invoke-static/range {v9 .. v14}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->split$default(Ljava/lang/CharSequence;[Ljava/lang/String;ZIILjava/lang/Object;)Ljava/util/List;

    move-result-object v4

    .line 77
    invoke-static {v4, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    invoke-interface {v4}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v4

    :cond_d
    :goto_a
    invoke-interface {v4}, Ljava/util/Iterator;->hasNext()Z

    move-result v5

    const-string v6, "-"

    if-eqz v5, :cond_f

    invoke-interface {v4}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/lang/String;

    if-eqz v5, :cond_d

    invoke-virtual {v5}, Ljava/lang/String;->length()I

    move-result v7

    if-nez v7, :cond_e

    goto :goto_a

    :cond_e
    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-nez v6, :cond_d

    const-string v6, "*"

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-nez v6, :cond_d

    const-string v6, "%"

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-nez v6, :cond_d

    invoke-static {v5}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->trim(Ljava/lang/CharSequence;)Ljava/lang/CharSequence;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v3, v5}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_a

    .line 78
    :cond_f
    invoke-virtual {v3}, Ljava/util/ArrayList;->size()I

    move-result v4

    if-lez v4, :cond_10

    const/4 v4, 0x0

    invoke-virtual {v3, v4}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v9

    goto :goto_b

    :cond_10
    const/4 v4, 0x0

    :goto_b
    move-object v3, v9

    check-cast v3, Ljava/lang/CharSequence;

    if-eqz v3, :cond_19

    invoke-interface {v3}, Ljava/lang/CharSequence;->length()I

    move-result v3

    if-nez v3, :cond_11

    goto/16 :goto_f

    :cond_11
    move-object v10, v9

    check-cast v10, Ljava/lang/String;

    const/4 v3, 0x2

    const/4 v5, 0x0

    invoke-static {v10, v6, v4, v3, v5}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->startsWith$default(Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_12

    const/4 v14, 0x4

    const/4 v15, 0x0

    const-string v11, "-"

    const-string v12, ""

    const/4 v13, 0x0

    invoke-static/range {v10 .. v15}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replaceFirst$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->trim(Ljava/lang/CharSequence;)Ljava/lang/CharSequence;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v9

    :cond_12
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/M;->x:Ljava/util/ArrayList;

    invoke-virtual {v3, v9}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    check-cast v9, Ljava/lang/String;

    const-string v3, "barcodeText"

    invoke-static {v3, v9}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    iget-object v6, v1, Lcom/scanflow/datacapture/barinternal/M;->x:Ljava/util/ArrayList;

    .line 79
    const-string v7, "scannedResut"

    invoke-static {v6, v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v7, Ljava/util/HashMap;

    invoke-direct {v7}, Ljava/util/HashMap;-><init>()V

    invoke-virtual {v6}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v6

    const-string v10, "iterator(...)"

    invoke-static {v6, v10}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    move v10, v4

    :cond_13
    :goto_c
    invoke-interface {v6}, Ljava/util/Iterator;->hasNext()Z

    move-result v11

    if-eqz v11, :cond_15

    invoke-interface {v6}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v11

    const-string v12, "next(...)"

    invoke-static {v11, v12}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v11, Ljava/lang/String;

    invoke-virtual {v7, v11}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v12

    check-cast v12, Ljava/lang/Integer;

    if-eqz v12, :cond_14

    invoke-virtual {v12}, Ljava/lang/Integer;->intValue()I

    move-result v12

    :goto_d
    const/4 v13, 0x1

    goto :goto_e

    :cond_14
    move v12, v4

    goto :goto_d

    :goto_e
    add-int/2addr v12, v13

    invoke-static {v12}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v13

    invoke-virtual {v7, v11, v13}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    if-le v12, v10, :cond_13

    move-object v8, v11

    move v10, v12

    goto :goto_c

    :cond_15
    new-instance v4, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-static {v10}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v6

    invoke-direct {v4, v6, v8}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    .line 80
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getFirst()Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/lang/Number;

    invoke-virtual {v6}, Ljava/lang/Number;->intValue()I

    move-result v6

    iget v7, v1, Lcom/scanflow/datacapture/barinternal/M;->y:I

    if-lt v6, v7, :cond_16

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getSecond()Ljava/lang/Object;

    move-result-object v4

    move-object v5, v4

    check-cast v5, Ljava/lang/String;

    :cond_16
    if-eqz v5, :cond_19

    .line 81
    const-string v4, "barcodeText MOST - "

    invoke-virtual {v4, v5}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v4, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    const/4 v12, 0x1

    invoke-static {v12}, Lcom/scanflow/datacapture/barinternal/M;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v6

    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    const-string v10, "bar_code"

    move/from16 v7, p2

    move-object v5, v9

    move-object/from16 v9, p3

    invoke-direct/range {v4 .. v10}, Lcom/scanflow/datacapture/model/ScanResultSuccess;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V

    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v3, :cond_17

    invoke-interface {v3, v4}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V

    :cond_17
    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    iput-object v3, v1, Lcom/scanflow/datacapture/barinternal/M;->x:Ljava/util/ArrayList;

    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    iput-object v3, v1, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    new-instance v5, Lcom/scanflow/ui/ar/ArObject;

    invoke-virtual {v4}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getText()Ljava/lang/String;

    move-result-object v6

    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/M;->l:Landroid/graphics/Matrix;

    .line 82
    iget-object v7, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 83
    const-string v8, "previewToCropTransform"

    invoke-static {v4, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v8, "yolov4location"

    invoke-static {v7, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v4, v7}, Landroid/graphics/Matrix;->mapRect(Landroid/graphics/RectF;)Z

    .line 84
    iget-object v8, v1, Lcom/scanflow/datacapture/barinternal/M;->N:Landroid/util/Size;

    const-string v4, "#1ab3fb"

    invoke-static {v4}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v10

    const/4 v11, 0x0

    const/4 v12, 0x0

    const/4 v9, 0x0

    invoke-direct/range {v5 .. v12}, Lcom/scanflow/ui/ar/ArObject;-><init>(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)V

    invoke-virtual {v3, v5}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/M;->E:Landroid/os/Handler;

    new-instance v4, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda8;

    invoke-direct {v4, v1}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda8;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v3, v4}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/M;->B:Ljava/util/LinkedList;

    invoke-virtual {v3, v2}, Ljava/util/LinkedList;->add(Ljava/lang/Object;)Z

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/M;->b()V

    invoke-virtual/range {p5 .. p5}, Landroid/graphics/Bitmap;->recycle()V

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/M;->M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v1, :cond_18

    invoke-virtual {v1}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->playBeepSoundAndVibrate()V

    :cond_18
    const-string v1, "Success"

    invoke-interface {v0, v1}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onSuccess(Ljava/lang/String;)V

    goto :goto_10

    :cond_19
    :goto_f
    invoke-interface {v0}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onFailure()V

    :goto_10
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object v0
.end method

.method public static a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;
    .locals 1

    const/4 v0, 0x1

    if-eq p0, v0, :cond_1

    const/4 v0, 0x2

    if-eq p0, v0, :cond_0

    sparse-switch p0, :sswitch_data_0

    .line 15
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODE_128:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_0
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->AZTEC:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_1
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->PDF_417:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_2
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->UPC_E:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_3
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->UPC_A:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_4
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->QR_CODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_5
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->ITF:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_6
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->EAN_8:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_7
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->EAN_13:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_8
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->DATA_MATRIX:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_9
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODABAR:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :sswitch_a
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODE_93:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :cond_0
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODE_39:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    :cond_1
    sget-object p0, Lcom/scanflow/datacapture/utils/BarcodeFormat;->CODE_128:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    return-object p0

    nop

    :sswitch_data_0
    .sparse-switch
        0x4 -> :sswitch_a
        0x8 -> :sswitch_9
        0x10 -> :sswitch_8
        0x20 -> :sswitch_7
        0x40 -> :sswitch_6
        0x80 -> :sswitch_5
        0x100 -> :sswitch_4
        0x200 -> :sswitch_3
        0x400 -> :sswitch_2
        0x800 -> :sswitch_1
        0x1000 -> :sswitch_0
    .end sparse-switch
.end method

.method public static final a(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 2

    .line 1
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/M;->O:Lcom/scanflow/datacapture/sfbarcode/SFCameraView;

    if-nez p0, :cond_0

    const-string p0, "sfCameraView"

    invoke-static {p0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 p0, 0x0

    :cond_0
    sget-object v0, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    const-string v1, "Error 13 - License Key Expired\nThe license key validation failed. Your license key has expired, please log into your account at www.scanflow.ai and request an extension or contact support through this contact form."

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V

    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lcom/google/android/gms/tasks/Task;)V
    .locals 11

    .line 2
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "$listener"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "it"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/google/android/gms/tasks/Task;->isSuccessful()Z

    move-result v0

    const-string v1, "qrResult"

    if-eqz v0, :cond_3

    invoke-virtual {p2}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    if-lez v0, :cond_3

    invoke-virtual {p2}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/List;

    const/4 v2, 0x0

    invoke-interface {v0, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v0}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_3

    invoke-virtual {p2}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/List;

    invoke-interface {v0, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v0}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    if-nez v0, :cond_0

    goto :goto_0

    :cond_0
    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    new-instance v3, Ljava/lang/StringBuilder;

    const-string v4, "qrResult ML- "

    invoke-direct {v3, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    invoke-interface {v4, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v0, v1, v3}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    new-instance v4, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    invoke-virtual {p2}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Ljava/util/List;

    invoke-interface {p2, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {p2}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v5

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v6, Lcom/scanflow/datacapture/utils/BarcodeFormat;->QR_CODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    new-instance v9, Landroid/graphics/RectF;

    invoke-direct {v9}, Landroid/graphics/RectF;-><init>()V

    const/4 v7, 0x1

    const-string v10, "QR_CODE"

    invoke-direct/range {v4 .. v10}, Lcom/scanflow/datacapture/model/ScanResultSuccess;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/M;->M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz p2, :cond_1

    invoke-virtual {p2}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->playBeepSoundAndVibrate()V

    :cond_1
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz p2, :cond_2

    invoke-interface {p2, v4}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V

    :cond_2
    new-instance p2, Ljava/util/ArrayList;

    invoke-direct {p2}, Ljava/util/ArrayList;-><init>()V

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/M;->x:Ljava/util/ArrayList;

    const-string p0, "Scanned"

    invoke-interface {p1, p0}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onSuccess(Ljava/lang/String;)V

    return-void

    :cond_3
    :goto_0
    sget-object p2, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v0, "qrResult - failed"

    invoke-virtual {p2, v1, v0}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    return-void
.end method

.method public static a(Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/model/ScanResultSuccess;I)V
    .locals 5

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getPoints()Ljava/util/ArrayList;

    move-result-object v0

    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v0

    if-lez v0, :cond_0

    new-instance v0, Landroid/graphics/PointF;

    .line 22
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 23
    iget v1, v1, Landroid/graphics/RectF;->left:F

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getPoints()Ljava/util/ArrayList;

    move-result-object v2

    const/4 v3, 0x0

    invoke-virtual {v2, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/graphics/PointF;

    iget v2, v2, Landroid/graphics/PointF;->x:F

    int-to-float p2, p2

    div-float/2addr v2, p2

    add-float/2addr v2, v1

    .line 24
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 25
    iget v1, v1, Landroid/graphics/RectF;->top:F

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getPoints()Ljava/util/ArrayList;

    move-result-object v4

    invoke-virtual {v4, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroid/graphics/PointF;

    iget v3, v3, Landroid/graphics/PointF;->y:F

    div-float/2addr v3, p2

    add-float/2addr v3, v1

    invoke-direct {v0, v2, v3}, Landroid/graphics/PointF;-><init>(FF)V

    .line 26
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/b;->e:Landroid/graphics/PointF;

    .line 27
    new-instance v0, Landroid/graphics/PointF;

    .line 28
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 29
    iget v1, v1, Landroid/graphics/RectF;->left:F

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getPoints()Ljava/util/ArrayList;

    move-result-object v2

    const/4 v3, 0x1

    invoke-virtual {v2, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/graphics/PointF;

    iget v2, v2, Landroid/graphics/PointF;->x:F

    div-float/2addr v2, p2

    add-float/2addr v2, v1

    .line 30
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 31
    iget v1, v1, Landroid/graphics/RectF;->top:F

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getPoints()Ljava/util/ArrayList;

    move-result-object v4

    invoke-virtual {v4, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroid/graphics/PointF;

    iget v3, v3, Landroid/graphics/PointF;->y:F

    div-float/2addr v3, p2

    add-float/2addr v3, v1

    invoke-direct {v0, v2, v3}, Landroid/graphics/PointF;-><init>(FF)V

    .line 33
    new-instance v0, Landroid/graphics/PointF;

    .line 34
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 35
    iget v1, v1, Landroid/graphics/RectF;->left:F

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getPoints()Ljava/util/ArrayList;

    move-result-object v2

    const/4 v3, 0x2

    invoke-virtual {v2, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/graphics/PointF;

    iget v2, v2, Landroid/graphics/PointF;->x:F

    div-float/2addr v2, p2

    add-float/2addr v2, v1

    .line 36
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 37
    iget v1, v1, Landroid/graphics/RectF;->top:F

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getPoints()Ljava/util/ArrayList;

    move-result-object v4

    invoke-virtual {v4, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroid/graphics/PointF;

    iget v3, v3, Landroid/graphics/PointF;->y:F

    div-float/2addr v3, p2

    add-float/2addr v3, v1

    invoke-direct {v0, v2, v3}, Landroid/graphics/PointF;-><init>(FF)V

    .line 39
    new-instance v0, Landroid/graphics/PointF;

    .line 40
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 41
    iget v1, v1, Landroid/graphics/RectF;->left:F

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getPoints()Ljava/util/ArrayList;

    move-result-object v2

    const/4 v3, 0x3

    invoke-virtual {v2, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/graphics/PointF;

    iget v2, v2, Landroid/graphics/PointF;->x:F

    div-float/2addr v2, p2

    add-float/2addr v2, v1

    .line 42
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 43
    iget p0, p0, Landroid/graphics/RectF;->top:F

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getPoints()Ljava/util/ArrayList;

    move-result-object p1

    invoke-virtual {p1, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroid/graphics/PointF;

    iget p1, p1, Landroid/graphics/PointF;->y:F

    div-float/2addr p1, p2

    add-float/2addr p1, p0

    invoke-direct {v0, v2, p1}, Landroid/graphics/PointF;-><init>(FF)V

    :cond_0
    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Ljava/lang/Exception;)V
    .locals 1

    .line 86
    const-string v0, "$listener"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "exception"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-interface {p0}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onFailure()V

    return-void
.end method

.method public static final a(Lcom/scanflow/ui/ar/BoundingBoxArOverlay;Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/ui/ar/ArOverlayView;)V
    .locals 3

    const-string v0, "$boundingBoxArOverlay"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "this$0"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-static {p2}, Landroidx/core/view/ViewCompat;->isLaidOut(Landroid/view/View;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p2}, Landroid/view/View;->isLayoutRequested()Z

    move-result v0

    if-nez v0, :cond_0

    .line 5
    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/M;->G:Lcom/scanflow/ui/ar/ArObjectTracker;

    .line 6
    new-instance v0, Lcom/scanflow/datacapture/barinternal/x;

    invoke-virtual {p2}, Landroid/view/View;->getWidth()I

    move-result v1

    invoke-virtual {p2}, Landroid/view/View;->getHeight()I

    move-result v2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/x;-><init>(II)V

    invoke-virtual {p1, v0}, Lcom/scanflow/ui/ar/ArObjectTracker;->pipe(Lcom/scanflow/ui/ar/ArObjectTracker;)Lcom/scanflow/ui/ar/ArObjectTracker;

    move-result-object p1

    new-instance v0, Lcom/scanflow/datacapture/barinternal/w;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/w;-><init>()V

    invoke-virtual {p1, v0}, Lcom/scanflow/ui/ar/ArObjectTracker;->pipe(Lcom/scanflow/ui/ar/ArObjectTracker;)Lcom/scanflow/ui/ar/ArObjectTracker;

    move-result-object p1

    invoke-virtual {p1, p0}, Lcom/scanflow/ui/ar/ArObjectTracker;->addTrackingListener(Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;)Lcom/scanflow/ui/ar/ArObjectTracker;

    goto :goto_0

    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/J;

    invoke-direct {v0, p1, p0}, Lcom/scanflow/datacapture/barinternal/J;-><init>(Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/ui/ar/BoundingBoxArOverlay;)V

    invoke-virtual {p2, v0}, Landroid/view/View;->addOnLayoutChangeListener(Landroid/view/View$OnLayoutChangeListener;)V

    :goto_0
    invoke-virtual {p2, p0}, Lcom/scanflow/ui/ar/ArOverlayView;->add(Lcom/scanflow/ui/ar/a;)V

    return-void
.end method

.method public static final a(Lkotlin/jvm/functions/Function1;Ljava/lang/Object;)V
    .locals 1

    .line 85
    const-string v0, "$tmp0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-interface {p0, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method public static final a(ZLandroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/M;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;ILcom/google/android/gms/tasks/Task;)V
    .locals 38

    move-object/from16 v1, p1

    move-object/from16 v0, p2

    move-object/from16 v2, p3

    move-object/from16 v4, p4

    move-object/from16 v5, p5

    const-string v3, "processModelResultZxing"

    const-string v6, "$croppedBitmap"

    invoke-static {v1, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "this$0"

    invoke-static {v0, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "$barcodeType"

    invoke-static {v2, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "$result"

    invoke-static {v4, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "$listener"

    invoke-static {v5, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "it"

    move-object/from16 v7, p7

    invoke-static {v7, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v7}, Lcom/google/android/gms/tasks/Task;->isSuccessful()Z

    move-result v6

    const-string v8, "bar_code"

    if-eqz v6, :cond_11

    invoke-virtual {v7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/util/List;

    invoke-interface {v6}, Ljava/util/List;->size()I

    move-result v6

    if-lez v6, :cond_11

    invoke-virtual {v7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/util/List;

    const/4 v9, 0x0

    invoke-interface {v6, v9}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v6}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v6

    if-eqz v6, :cond_11

    invoke-virtual {v7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/util/List;

    invoke-interface {v6, v9}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v6}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v6

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v6}, Ljava/lang/String;->length()I

    move-result v6

    if-nez v6, :cond_0

    goto/16 :goto_d

    :cond_0
    invoke-virtual {v7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/util/List;

    invoke-interface {v6, v9}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v6}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v6

    new-instance v14, Ljava/util/ArrayList;

    invoke-direct {v14}, Ljava/util/ArrayList;-><init>()V

    if-eqz p0, :cond_1

    const/4 v12, 0x2

    goto :goto_0

    :cond_1
    const/4 v12, 0x1

    :goto_0
    invoke-virtual {v7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v13

    check-cast v13, Ljava/util/List;

    invoke-interface {v13, v9}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v13

    check-cast v13, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v13}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getCornerPoints()[Landroid/graphics/Point;

    move-result-object v13

    if-eqz v13, :cond_2

    new-instance v15, Landroid/graphics/PointF;

    const/16 v16, 0x1

    new-instance v11, Landroid/graphics/Point;

    const/16 v17, 0x2

    aget-object v10, v13, v9

    iget v9, v10, Landroid/graphics/Point;->x:I

    div-int/2addr v9, v12

    iget v10, v10, Landroid/graphics/Point;->y:I

    div-int/2addr v10, v12

    invoke-direct {v11, v9, v10}, Landroid/graphics/Point;-><init>(II)V

    invoke-direct {v15, v11}, Landroid/graphics/PointF;-><init>(Landroid/graphics/Point;)V

    invoke-virtual {v14, v15}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v9, Landroid/graphics/PointF;

    new-instance v10, Landroid/graphics/Point;

    aget-object v11, v13, v16

    iget v15, v11, Landroid/graphics/Point;->x:I

    div-int/2addr v15, v12

    iget v11, v11, Landroid/graphics/Point;->y:I

    div-int/2addr v11, v12

    invoke-direct {v10, v15, v11}, Landroid/graphics/Point;-><init>(II)V

    invoke-direct {v9, v10}, Landroid/graphics/PointF;-><init>(Landroid/graphics/Point;)V

    invoke-virtual {v14, v9}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v9, Landroid/graphics/PointF;

    new-instance v10, Landroid/graphics/Point;

    aget-object v11, v13, v17

    iget v15, v11, Landroid/graphics/Point;->x:I

    div-int/2addr v15, v12

    iget v11, v11, Landroid/graphics/Point;->y:I

    div-int/2addr v11, v12

    invoke-direct {v10, v15, v11}, Landroid/graphics/Point;-><init>(II)V

    invoke-direct {v9, v10}, Landroid/graphics/PointF;-><init>(Landroid/graphics/Point;)V

    invoke-virtual {v14, v9}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v9, Landroid/graphics/PointF;

    new-instance v10, Landroid/graphics/Point;

    const/4 v11, 0x3

    aget-object v11, v13, v11

    iget v13, v11, Landroid/graphics/Point;->x:I

    div-int/2addr v13, v12

    iget v11, v11, Landroid/graphics/Point;->y:I

    div-int/2addr v11, v12

    invoke-direct {v10, v13, v11}, Landroid/graphics/Point;-><init>(II)V

    invoke-direct {v9, v10}, Landroid/graphics/PointF;-><init>(Landroid/graphics/Point;)V

    invoke-virtual {v14, v9}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_1

    :cond_2
    const/16 v16, 0x1

    const/16 v17, 0x2

    :goto_1
    invoke-virtual {v7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Ljava/util/List;

    const/4 v10, 0x0

    invoke-interface {v9, v10}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v9}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getCornerPoints()[Landroid/graphics/Point;

    move-result-object v9

    const-string v11, "SFBarcode"

    if-eqz v9, :cond_4

    aget-object v13, v9, v10

    iget v10, v13, Landroid/graphics/Point;->x:I

    move v15, v6

    int-to-double v6, v10

    iget v10, v13, Landroid/graphics/Point;->y:I

    move-wide/from16 v19, v6

    int-to-double v6, v10

    aget-object v10, v9, v16

    iget v13, v10, Landroid/graphics/Point;->x:I

    move-wide/from16 v21, v6

    int-to-double v6, v13

    iget v10, v10, Landroid/graphics/Point;->y:I

    move-wide/from16 v23, v6

    int-to-double v6, v10

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-wide/from16 v25, v6

    sub-double v6, v23, v19

    move/from16 v19, v12

    move/from16 v10, v17

    int-to-double v12, v10

    .line 89
    invoke-static {v6, v7, v12, v13}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v6

    move-object/from16 v20, v11

    sub-double v10, v25, v21

    invoke-static {v10, v11, v12, v13}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v10

    add-double/2addr v10, v6

    invoke-static {v10, v11}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v6

    .line 90
    aget-object v10, v9, v16

    iget v11, v10, Landroid/graphics/Point;->x:I

    move-object/from16 v21, v14

    move/from16 v22, v15

    int-to-double v14, v11

    iget v10, v10, Landroid/graphics/Point;->y:I

    int-to-double v10, v10

    move-object/from16 v23, v9

    aget-object v9, v23, v17

    move-wide/from16 v24, v10

    iget v10, v9, Landroid/graphics/Point;->x:I

    int-to-double v10, v10

    iget v9, v9, Landroid/graphics/Point;->y:I

    move-wide/from16 v26, v10

    int-to-double v9, v9

    sub-double v14, v26, v14

    .line 91
    invoke-static {v14, v15, v12, v13}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v14

    sub-double v9, v9, v24

    invoke-static {v9, v10, v12, v13}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v9

    add-double/2addr v9, v14

    invoke-static {v9, v10}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v9

    .line 92
    new-instance v11, Ljava/lang/StringBuilder;

    const-string v12, "Calculate Distance - "

    invoke-direct {v11, v12}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v11, v6, v7}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const/16 v12, 0x20

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v11, v9, v10}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    move-object/from16 v12, v20

    invoke-static {v12, v11}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    cmpl-double v6, v6, v9

    if-lez v6, :cond_3

    new-instance v6, Landroid/graphics/Point;

    const/16 v18, 0x0

    aget-object v7, v23, v18

    iget v9, v7, Landroid/graphics/Point;->x:I

    div-int v9, v9, v19

    iget v7, v7, Landroid/graphics/Point;->y:I

    div-int v7, v7, v19

    invoke-direct {v6, v9, v7}, Landroid/graphics/Point;-><init>(II)V

    new-instance v7, Landroid/graphics/Point;

    aget-object v9, v23, v16

    iget v10, v9, Landroid/graphics/Point;->x:I

    div-int v10, v10, v19

    iget v9, v9, Landroid/graphics/Point;->y:I

    div-int v9, v9, v19

    invoke-direct {v7, v10, v9}, Landroid/graphics/Point;-><init>(II)V

    :goto_2
    invoke-static {v6, v7}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Point;Landroid/graphics/Point;)D

    move-result-wide v6

    goto :goto_3

    :cond_3
    new-instance v6, Landroid/graphics/Point;

    aget-object v7, v23, v16

    iget v9, v7, Landroid/graphics/Point;->x:I

    div-int v9, v9, v19

    iget v7, v7, Landroid/graphics/Point;->y:I

    div-int v7, v7, v19

    invoke-direct {v6, v9, v7}, Landroid/graphics/Point;-><init>(II)V

    new-instance v7, Landroid/graphics/Point;

    const/16 v17, 0x2

    aget-object v9, v23, v17

    iget v10, v9, Landroid/graphics/Point;->x:I

    div-int v10, v10, v19

    iget v9, v9, Landroid/graphics/Point;->y:I

    div-int v9, v9, v19

    invoke-direct {v7, v10, v9}, Landroid/graphics/Point;-><init>(II)V

    goto :goto_2

    :cond_4
    move/from16 v22, v6

    move-object v12, v11

    move-object/from16 v21, v14

    const-wide/16 v6, 0x0

    :goto_3
    new-instance v9, Ljava/lang/StringBuilder;

    const-string v10, "angle - "

    invoke-direct {v9, v10}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v9, v6, v7}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v12, v9}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    .line 93
    const-string v9, "croppedBitmap"

    invoke-static {v1, v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v1}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v10

    add-int/lit8 v10, v10, 0x32

    invoke-virtual {v1}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v11

    add-int/lit8 v11, v11, 0x32

    sget-object v13, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v10, v11, v13}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v10

    const-string v11, "createBitmap(...)"

    invoke-static {v10, v11}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v13, Landroid/graphics/Canvas;

    invoke-direct {v13, v10}, Landroid/graphics/Canvas;-><init>(Landroid/graphics/Bitmap;)V

    sget-object v14, Landroid/graphics/PorterDuff$Mode;->LIGHTEN:Landroid/graphics/PorterDuff$Mode;

    const/4 v15, -0x1

    invoke-virtual {v13, v15, v14}, Landroid/graphics/Canvas;->drawColor(ILandroid/graphics/PorterDuff$Mode;)V

    new-instance v14, Landroid/graphics/Paint;

    invoke-direct {v14}, Landroid/graphics/Paint;-><init>()V

    move/from16 v15, v16

    invoke-virtual {v14, v15}, Landroid/graphics/Paint;->setAntiAlias(Z)V

    invoke-virtual {v14, v15}, Landroid/graphics/Paint;->setFilterBitmap(Z)V

    invoke-virtual {v14, v15}, Landroid/graphics/Paint;->setDither(Z)V

    const/16 v15, 0x19

    int-to-float v15, v15

    invoke-virtual {v13, v1, v15, v15, v14}, Landroid/graphics/Canvas;->drawBitmap(Landroid/graphics/Bitmap;FFLandroid/graphics/Paint;)V

    double-to-float v6, v6

    .line 94
    invoke-static {v10, v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v7, Landroid/graphics/Matrix;

    invoke-direct {v7}, Landroid/graphics/Matrix;-><init>()V

    invoke-virtual {v7, v6}, Landroid/graphics/Matrix;->postRotate(F)Z

    invoke-virtual {v10}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v6

    invoke-virtual {v10}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v9

    const/4 v15, 0x1

    invoke-static {v10, v6, v9, v15}, Landroid/graphics/Bitmap;->createScaledBitmap(Landroid/graphics/Bitmap;IIZ)Landroid/graphics/Bitmap;

    move-result-object v6

    const-string v9, "createScaledBitmap(...)"

    invoke-static {v6, v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v26

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v27

    const/16 v25, 0x0

    const/16 v29, 0x1

    const/16 v24, 0x0

    move-object/from16 v23, v6

    move-object/from16 v28, v7

    invoke-static/range {v23 .. v29}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIIILandroid/graphics/Matrix;Z)Landroid/graphics/Bitmap;

    move-result-object v6

    invoke-static {v6, v11}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 95
    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Ljava/util/List;

    const/4 v10, 0x0

    invoke-interface {v7, v10}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v7}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v7

    const/4 v10, 0x2

    if-ne v7, v10, :cond_9

    sget-object v7, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    const-string v7, "decodeZxing - Started"

    invoke-static {v12, v7}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v7, Ljava/util/ArrayList;

    invoke-direct {v7}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v7

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v9

    mul-int/2addr v9, v7

    new-array v7, v9, [I

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v33

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v36

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v37

    const/16 v34, 0x0

    const/16 v35, 0x0

    const/16 v32, 0x0

    move-object/from16 v30, v6

    move-object/from16 v31, v7

    invoke-virtual/range {v30 .. v37}, Landroid/graphics/Bitmap;->getPixels([IIIIIII)V

    move-object/from16 v6, v31

    new-instance v7, Lcom/google/zxing/RGBLuminanceSource;

    invoke-virtual/range {v30 .. v30}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v9

    invoke-virtual/range {v30 .. v30}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v10

    invoke-direct {v7, v9, v10, v6}, Lcom/google/zxing/RGBLuminanceSource;-><init>(II[I)V

    new-instance v6, Lcom/google/zxing/common/HybridBinarizer;

    invoke-direct {v6, v7}, Lcom/google/zxing/common/HybridBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    new-instance v9, Lcom/google/zxing/MultiFormatReader;

    invoke-direct {v9}, Lcom/google/zxing/MultiFormatReader;-><init>()V

    new-instance v10, Ljava/util/HashMap;

    invoke-direct {v10}, Ljava/util/HashMap;-><init>()V

    sget-object v11, Lcom/google/zxing/DecodeHintType;->PURE_BARCODE:Lcom/google/zxing/DecodeHintType;

    sget-object v13, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    invoke-virtual {v10, v11, v13}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {v9, v10}, Lcom/google/zxing/MultiFormatReader;->setHints(Ljava/util/Map;)V

    :try_start_0
    new-instance v11, Lcom/google/zxing/BinaryBitmap;

    invoke-direct {v11, v6}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v9, v11, v10}, Lcom/google/zxing/MultiFormatReader;->decode(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;

    move-result-object v6

    if-nez v6, :cond_5

    new-instance v6, Lcom/google/zxing/BinaryBitmap;

    new-instance v11, Lcom/google/zxing/common/GlobalHistogramBinarizer;

    invoke-direct {v11, v7}, Lcom/google/zxing/common/GlobalHistogramBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    invoke-direct {v6, v11}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v9, v6, v10}, Lcom/google/zxing/MultiFormatReader;->decode(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;

    move-result-object v6
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_4

    :catchall_0
    move-exception v0

    goto/16 :goto_a

    :cond_5
    :goto_4
    invoke-virtual {v9}, Lcom/google/zxing/MultiFormatReader;->reset()V

    if-nez v6, :cond_7

    invoke-virtual {v7}, Lcom/google/zxing/LuminanceSource;->invert()Lcom/google/zxing/LuminanceSource;

    move-result-object v6

    :try_start_1
    new-instance v7, Lcom/google/zxing/common/HybridBinarizer;

    invoke-direct {v7, v6}, Lcom/google/zxing/common/HybridBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    new-instance v10, Lcom/google/zxing/BinaryBitmap;

    invoke-direct {v10, v7}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v9, v10}, Lcom/google/zxing/MultiFormatReader;->decodeWithState(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;

    move-result-object v7

    if-nez v7, :cond_6

    new-instance v7, Lcom/google/zxing/BinaryBitmap;

    new-instance v10, Lcom/google/zxing/common/GlobalHistogramBinarizer;

    invoke-direct {v10, v6}, Lcom/google/zxing/common/GlobalHistogramBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    invoke-direct {v7, v10}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v9, v7}, Lcom/google/zxing/MultiFormatReader;->decodeWithState(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;

    move-result-object v6

    goto :goto_5

    :catchall_1
    move-exception v0

    goto :goto_6

    :cond_6
    move-object v6, v7

    :goto_5
    const-string v7, "White_points_inverted"

    invoke-virtual {v6}, Lcom/google/zxing/Result;->getResultPoints()[Lcom/google/zxing/ResultPoint;

    move-result-object v10

    const/16 v18, 0x0

    aget-object v10, v10, v18

    invoke-virtual {v10}, Lcom/google/zxing/ResultPoint;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-static {v7, v10}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    invoke-virtual {v9}, Lcom/google/zxing/MultiFormatReader;->reset()V

    goto :goto_7

    :catch_0
    :try_start_2
    const-string v6, "Exception - 1"

    invoke-static {v3, v6}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_1

    goto :goto_9

    :goto_6
    invoke-virtual {v9}, Lcom/google/zxing/MultiFormatReader;->reset()V

    throw v0

    :cond_7
    :goto_7
    invoke-virtual {v6}, Lcom/google/zxing/Result;->getText()Ljava/lang/String;

    move-result-object v7

    if-eqz v7, :cond_8

    const-string v9, "decodeZxing - "

    invoke-virtual {v9, v7}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-static {v3, v7}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    :cond_8
    const-string v3, "decodeZxing - Completed"

    invoke-static {v12, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {v6}, Lcom/google/zxing/Result;->getText()Ljava/lang/String;

    move-result-object v3

    :goto_8
    move-object v11, v3

    const/4 v10, 0x0

    goto :goto_b

    :catch_1
    :try_start_3
    const-string v6, "Exception - 0"

    invoke-static {v3, v6}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    :goto_9
    invoke-virtual {v9}, Lcom/google/zxing/MultiFormatReader;->reset()V

    const/4 v3, 0x0

    goto :goto_8

    :goto_a
    invoke-virtual {v9}, Lcom/google/zxing/MultiFormatReader;->reset()V

    throw v0

    :cond_9
    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/List;

    const/4 v10, 0x0

    invoke-interface {v3, v10}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v3}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v3

    move-object v11, v3

    :goto_b
    new-instance v3, Ljava/lang/StringBuilder;

    const-string v6, "MLOutput After- "

    invoke-direct {v3, v6}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/util/List;

    invoke-interface {v6, v10}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v6}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v3, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v6, "  format: "

    invoke-virtual {v3, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual/range {p7 .. p7}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/util/List;

    invoke-interface {v6, v10}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v6}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v6

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    invoke-static {v6}, Lcom/scanflow/datacapture/barinternal/M;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v6

    invoke-virtual {v3, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v12, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v3, Ljava/lang/StringBuilder;

    const-string v6, "zxingOutput After- "

    invoke-direct {v3, v6}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v3, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v12, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    if-eqz v11, :cond_10

    new-instance v10, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    invoke-static/range {v22 .. v22}, Lcom/scanflow/datacapture/barinternal/M;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v2

    .line 96
    iget-object v15, v4, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 97
    iget-object v3, v4, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    move-object v13, v12

    move-object v12, v2

    move-object v2, v13

    move/from16 v13, p0

    move-object/from16 v16, v3

    move-object/from16 v14, v21

    .line 98
    invoke-direct/range {v10 .. v16}, Lcom/scanflow/datacapture/model/ScanResultSuccess;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V

    const-string v3, "decodeML - Completed"

    invoke-static {v2, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {v10}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getText()Ljava/lang/String;

    move-result-object v2

    const-string v3, "processModelResultML"

    invoke-static {v3, v2}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    iget-boolean v2, v0, Lcom/scanflow/datacapture/barinternal/M;->b:Z

    if-eqz v2, :cond_a

    iget-boolean v3, v0, Lcom/scanflow/datacapture/barinternal/M;->d:Z

    if-nez v3, :cond_a

    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v2, v10}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v3, :cond_e

    invoke-interface {v3, v2}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onBatchScanResultSuccess(Ljava/util/ArrayList;)V

    goto :goto_c

    :cond_a
    if-eqz v2, :cond_c

    iget-boolean v2, v0, Lcom/scanflow/datacapture/barinternal/M;->d:Z

    if-eqz v2, :cond_c

    new-instance v2, Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    invoke-virtual {v10}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getText()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v10}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getBarcodeFormat()Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object v6

    invoke-direct {v2, v3, v6}, Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/M;->J:Ljava/util/HashSet;

    invoke-virtual {v3, v2}, Ljava/util/HashSet;->add(Ljava/lang/Object;)Z

    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v3, :cond_b

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/M;->J:Ljava/util/HashSet;

    invoke-interface {v3, v6}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onOneOfManyCodeResult(Ljava/util/HashSet;)V

    :cond_b
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v3, :cond_e

    invoke-interface {v3, v2}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onOneofManyCodeSelected(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V

    goto :goto_c

    :cond_c
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v2, :cond_d

    invoke-interface {v2, v10}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V

    :cond_d
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    iput-object v2, v0, Lcom/scanflow/datacapture/barinternal/M;->x:Ljava/util/ArrayList;

    :cond_e
    :goto_c
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/M;->M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v2, :cond_f

    invoke-virtual {v2}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->playBeepSoundAndVibrate()V

    :cond_f
    move/from16 v2, p6

    invoke-static {v4, v10, v2}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/model/ScanResultSuccess;I)V

    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    iput-object v2, v0, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    new-instance v11, Lcom/scanflow/ui/ar/ArObject;

    invoke-virtual {v10}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getText()Ljava/lang/String;

    move-result-object v12

    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/M;->l:Landroid/graphics/Matrix;

    .line 99
    iget-object v13, v4, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 100
    const-string v6, "previewToCropTransform"

    invoke-static {v3, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "yolov4location"

    invoke-static {v13, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v3, v13}, Landroid/graphics/Matrix;->mapRect(Landroid/graphics/RectF;)Z

    .line 101
    iget-object v14, v0, Lcom/scanflow/datacapture/barinternal/M;->N:Landroid/util/Size;

    const-string v3, "#1ab3fb"

    invoke-static {v3}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v16

    const/16 v17, 0x0

    const/16 v18, 0x0

    const/4 v15, 0x0

    invoke-direct/range {v11 .. v18}, Lcom/scanflow/ui/ar/ArObject;-><init>(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)V

    invoke-virtual {v2, v11}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/M;->E:Landroid/os/Handler;

    new-instance v3, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda10;

    invoke-direct {v3, v0}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda10;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v2, v3}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/M;->B:Ljava/util/LinkedList;

    invoke-virtual {v2, v4}, Ljava/util/LinkedList;->add(Ljava/lang/Object;)Z

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/M;->b()V

    invoke-virtual {v1}, Landroid/graphics/Bitmap;->recycle()V

    const-string v0, "Scanned"

    invoke-interface {v5, v0}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onSuccess(Ljava/lang/String;)V

    goto :goto_f

    :cond_10
    invoke-virtual {v2, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_12

    goto :goto_e

    :cond_11
    :goto_d
    invoke-virtual {v2, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_12

    .line 102
    :goto_e
    iget-object v3, v4, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    move/from16 v2, p0

    .line 103
    invoke-virtual/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;ZLandroid/graphics/RectF;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    goto :goto_f

    :cond_12
    invoke-virtual {v0, v5}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    :goto_f
    return-void
.end method

.method public static a(Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)Z
    .locals 8

    new-instance v0, Ljava/text/SimpleDateFormat;

    const-string v1, "yyyy-MM-dd\'T\'HH:mm:ss.SSS"

    invoke-direct {v0, v1}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;)V

    if-eqz p0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getResult()Lcom/scanflow/datacapture/model/subscription/Result;

    move-result-object p0

    if-eqz p0, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/model/subscription/Result;->getSubscriptionEndDate()Ljava/lang/String;

    move-result-object p0

    if-eqz p0, :cond_0

    .line 16
    const-string v2, "UTC"

    invoke-static {v2}, Ljava/util/TimeZone;->getTimeZone(Ljava/lang/String;)Ljava/util/TimeZone;

    move-result-object v2

    .line 17
    const-string v3, "<this>"

    invoke-static {p0, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v4, "dateFormat"

    invoke-static {v1, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v5, "timeZone"

    invoke-static {v2, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v6, Ljava/text/SimpleDateFormat;

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v7

    invoke-direct {v6, v1, v7}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    invoke-virtual {v6, v2}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    invoke-virtual {v6, p0}, Ljava/text/DateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;

    move-result-object p0

    if-eqz p0, :cond_0

    .line 19
    invoke-static {}, Ljava/util/TimeZone;->getDefault()Ljava/util/TimeZone;

    move-result-object v2

    .line 20
    invoke-static {p0, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v1, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v2, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v3, Ljava/text/SimpleDateFormat;

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v4

    invoke-direct {v3, v1, v4}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    invoke-virtual {v3, v2}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    invoke-virtual {v3, p0}, Ljava/text/DateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object p0

    if-eqz p0, :cond_0

    .line 21
    invoke-virtual {v0, p0}, Ljava/text/DateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;

    move-result-object p0

    goto :goto_0

    :cond_0
    const/4 p0, 0x0

    :goto_0
    new-instance v0, Ljava/util/Date;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v1

    invoke-direct {v0, v1, v2}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v0, p0}, Ljava/util/Date;->after(Ljava/util/Date;)Z

    move-result p0

    return p0
.end method

.method public static final b(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 2

    .line 1
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/M;->O:Lcom/scanflow/datacapture/sfbarcode/SFCameraView;

    if-nez p0, :cond_0

    const-string p0, "sfCameraView"

    invoke-static {p0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 p0, 0x0

    :cond_0
    sget-object v0, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    const-string v1, "Valid License"

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V

    return-void
.end method

.method public static final c(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 3

    .line 1
    const-string v0, "$this_run"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->O:Lcom/scanflow/datacapture/sfbarcode/SFCameraView;

    const/4 v1, 0x0

    if-nez v0, :cond_0

    const-string v0, "sfCameraView"

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v0, v1

    :cond_0
    sget-object v2, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/M;->X:Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    if-eqz p0, :cond_1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getMessage()Ljava/lang/String;

    move-result-object v1

    :cond_1
    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0, v2, v1}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V

    return-void
.end method

.method public static final d(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 2

    .line 1
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/M;->O:Lcom/scanflow/datacapture/sfbarcode/SFCameraView;

    if-nez p0, :cond_0

    const-string p0, "sfCameraView"

    invoke-static {p0}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 p0, 0x0

    :cond_0
    sget-object v0, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    const-string v1, "Error 19 - Device Activation Failed\nThe device activation failed. Please connect to the Internet and restart the app."

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V

    return-void
.end method

.method public static final e(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 1

    .line 1
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->G:Lcom/scanflow/ui/ar/ArObjectTracker;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    invoke-virtual {v0, p0}, Lcom/scanflow/ui/ar/ArObjectTracker;->processObject(Ljava/util/ArrayList;)V

    return-void
.end method

.method public static final f(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 1

    .line 1
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->G:Lcom/scanflow/ui/ar/ArObjectTracker;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    invoke-virtual {v0, p0}, Lcom/scanflow/ui/ar/ArObjectTracker;->processObject(Ljava/util/ArrayList;)V

    return-void
.end method

.method public static final g(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 1

    .line 1
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->G:Lcom/scanflow/ui/ar/ArObjectTracker;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    invoke-virtual {v0, p0}, Lcom/scanflow/ui/ar/ArObjectTracker;->processObject(Ljava/util/ArrayList;)V

    return-void
.end method

.method public static final h(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 1

    .line 1
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->G:Lcom/scanflow/ui/ar/ArObjectTracker;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    invoke-virtual {v0, p0}, Lcom/scanflow/ui/ar/ArObjectTracker;->processObject(Ljava/util/ArrayList;)V

    return-void
.end method

.method public static final i(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 2

    .line 1
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->G:Lcom/scanflow/ui/ar/ArObjectTracker;

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/scanflow/ui/ar/ArObjectTracker;->processObject(Lcom/scanflow/ui/ar/ArObject;)V

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/M;->G:Lcom/scanflow/ui/ar/ArObjectTracker;

    invoke-virtual {p0, v0}, Lcom/scanflow/ui/ar/ArObjectTracker;->processObject(Ljava/util/ArrayList;)V

    return-void
.end method

.method public static final j(Lcom/scanflow/datacapture/barinternal/M;)V
    .locals 1

    .line 1
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    return-void
.end method


# virtual methods
.method public final a(Landroid/graphics/Bitmap;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/D;
    .locals 3

    sget-object v0, Lcom/scanflow/datacapture/barinternal/D;->a:Lcom/scanflow/datacapture/barinternal/D;

    const-string v0, "qr_code"

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result p2

    const/16 v0, 0x64

    if-eqz p2, :cond_0

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getWidth()I

    move-result p2

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getHeight()I

    move-result p1

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/M;->s:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/M;->t:I

    int-to-float p2, p2

    int-to-float v1, v1

    div-float/2addr p2, v1

    int-to-float v0, v0

    mul-float/2addr p2, v0

    const/high16 v1, 0x41500000    # 13.0f

    cmpg-float p2, p2, v1

    if-ltz p2, :cond_2

    int-to-float p1, p1

    int-to-float p2, v2

    div-float/2addr p1, p2

    mul-float/2addr p1, v0

    const/high16 p2, 0x41100000    # 9.0f

    cmpg-float p1, p1, p2

    if-gez p1, :cond_1

    goto :goto_0

    .line 7
    :cond_0
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getWidth()I

    move-result p2

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getHeight()I

    move-result p1

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/M;->s:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/M;->t:I

    int-to-float p2, p2

    int-to-float v1, v1

    div-float/2addr p2, v1

    int-to-float v0, v0

    mul-float/2addr p2, v0

    const/high16 v1, 0x42800000    # 64.0f

    cmpg-float p2, p2, v1

    if-ltz p2, :cond_2

    int-to-float p1, p1

    int-to-float p2, v2

    div-float/2addr p1, p2

    mul-float/2addr p1, v0

    const/high16 p2, 0x41800000    # 16.0f

    cmpg-float p1, p1, p2

    if-gez p1, :cond_1

    goto :goto_0

    :cond_1
    const/4 p1, 0x0

    goto :goto_1

    :cond_2
    :goto_0
    const/4 p1, 0x1

    :goto_1
    sget-object p2, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "IsLongDistanceImage: "

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    const-string v1, "SFBarcode"

    invoke-virtual {p2, v1, v0}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    if-eqz p1, :cond_3

    sget-object p1, Lcom/scanflow/datacapture/barinternal/D;->b:Lcom/scanflow/datacapture/barinternal/D;

    return-object p1

    :cond_3
    sget-object p1, Lcom/scanflow/datacapture/barinternal/D;->c:Lcom/scanflow/datacapture/barinternal/D;

    return-object p1
.end method

.method public final a(Ljava/lang/String;)Ljava/lang/String;
    .locals 10

    .line 9
    const-string v0, ""

    const-string v1, "Error occured during decryption: "

    const/4 v2, 0x0

    :try_start_0
    invoke-static {}, Ljava/util/Base64;->getDecoder()Ljava/util/Base64$Decoder;

    move-result-object v3

    invoke-virtual {v3, p1}, Ljava/util/Base64$Decoder;->decode(Ljava/lang/String;)[B

    move-result-object p1

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v3, 0x0

    const/16 v4, 0xc

    invoke-static {p1, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyOfRange([BII)[B

    move-result-object v3

    array-length v5, p1

    invoke-static {p1, v4, v5}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyOfRange([BII)[B

    move-result-object p1

    new-instance v4, Ljavax/crypto/spec/GCMParameterSpec;

    const/16 v5, 0x80

    invoke-direct {v4, v5, v3}, Ljavax/crypto/spec/GCMParameterSpec;-><init>(I[B)V

    const-string v3, "PBKDF2WithHmacSHA256"

    invoke-static {v3}, Ljavax/crypto/SecretKeyFactory;->getInstance(Ljava/lang/String;)Ljavax/crypto/SecretKeyFactory;

    move-result-object v3

    new-instance v5, Ljavax/crypto/spec/PBEKeySpec;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/M;->T:Landroid/content/SharedPreferences;
    :try_end_0
    .catch Ljava/security/InvalidAlgorithmParameterException; {:try_start_0 .. :try_end_0} :catch_6
    .catch Ljava/security/InvalidKeyException; {:try_start_0 .. :try_end_0} :catch_5
    .catch Ljava/security/NoSuchAlgorithmException; {:try_start_0 .. :try_end_0} :catch_4
    .catch Ljava/security/spec/InvalidKeySpecException; {:try_start_0 .. :try_end_0} :catch_3
    .catch Ljavax/crypto/BadPaddingException; {:try_start_0 .. :try_end_0} :catch_2
    .catch Ljavax/crypto/IllegalBlockSizeException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljavax/crypto/NoSuchPaddingException; {:try_start_0 .. :try_end_0} :catch_0

    const-string v7, "licenseSharedPreferences"

    if-nez v6, :cond_0

    :try_start_1
    invoke-static {v7}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v6, v2

    goto :goto_0

    :catch_0
    move-exception p1

    goto :goto_1

    :catch_1
    move-exception p1

    goto/16 :goto_2

    :catch_2
    move-exception p1

    goto/16 :goto_3

    :catch_3
    move-exception p1

    goto/16 :goto_4

    :catch_4
    move-exception p1

    goto/16 :goto_5

    :catch_5
    move-exception p1

    goto/16 :goto_6

    :catch_6
    move-exception p1

    goto/16 :goto_7

    :cond_0
    :goto_0
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/M;->U:Ljava/lang/String;

    invoke-interface {v6, v8, v0}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-static {v6}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/String;->toCharArray()[C

    move-result-object v6

    const-string v8, "toCharArray(...)"

    invoke-static {v6, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/M;->T:Landroid/content/SharedPreferences;

    if-nez v8, :cond_1

    invoke-static {v7}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v8, v2

    :cond_1
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/M;->V:Ljava/lang/String;

    invoke-interface {v8, v7, v0}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    sget-object v7, Lcom/scanflow/datacapture/barinternal/kotlin/text/Charsets;->UTF_8:Ljava/nio/charset/Charset;

    invoke-virtual {v0, v7}, Ljava/lang/String;->getBytes(Ljava/nio/charset/Charset;)[B

    move-result-object v0

    const-string v8, "getBytes(...)"

    invoke-static {v0, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    const/high16 v8, 0x10000

    const/16 v9, 0x100

    invoke-direct {v5, v6, v0, v8, v9}, Ljavax/crypto/spec/PBEKeySpec;-><init>([C[BII)V

    invoke-virtual {v3, v5}, Ljavax/crypto/SecretKeyFactory;->generateSecret(Ljava/security/spec/KeySpec;)Ljavax/crypto/SecretKey;

    move-result-object v0

    new-instance v3, Ljavax/crypto/spec/SecretKeySpec;

    invoke-interface {v0}, Ljava/security/Key;->getEncoded()[B

    move-result-object v0

    const-string v5, "AES"

    invoke-direct {v3, v0, v5}, Ljavax/crypto/spec/SecretKeySpec;-><init>([BLjava/lang/String;)V

    const-string v0, "AES/GCM/NoPadding"

    invoke-static {v0}, Ljavax/crypto/Cipher;->getInstance(Ljava/lang/String;)Ljavax/crypto/Cipher;

    move-result-object v0

    const/4 v5, 0x2

    invoke-virtual {v0, v5, v3, v4}, Ljavax/crypto/Cipher;->init(ILjava/security/Key;Ljava/security/spec/AlgorithmParameterSpec;)V

    invoke-virtual {v0, p1}, Ljavax/crypto/Cipher;->doFinal([B)[B

    move-result-object p1

    const-string v0, "doFinal(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, p1, v7}, Ljava/lang/String;-><init>([BLjava/nio/charset/Charset;)V
    :try_end_1
    .catch Ljava/security/InvalidAlgorithmParameterException; {:try_start_1 .. :try_end_1} :catch_6
    .catch Ljava/security/InvalidKeyException; {:try_start_1 .. :try_end_1} :catch_5
    .catch Ljava/security/NoSuchAlgorithmException; {:try_start_1 .. :try_end_1} :catch_4
    .catch Ljava/security/spec/InvalidKeySpecException; {:try_start_1 .. :try_end_1} :catch_3
    .catch Ljavax/crypto/BadPaddingException; {:try_start_1 .. :try_end_1} :catch_2
    .catch Ljavax/crypto/IllegalBlockSizeException; {:try_start_1 .. :try_end_1} :catch_1
    .catch Ljavax/crypto/NoSuchPaddingException; {:try_start_1 .. :try_end_1} :catch_0

    return-object v0

    :goto_1
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_2
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_3
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_4
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_5
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_6
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    goto :goto_8

    :goto_7
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    :goto_8
    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    sget-object v0, Ljava/lang/System;->out:Ljava/io/PrintStream;

    invoke-virtual {v0, p1}, Ljava/io/PrintStream;->println(Ljava/lang/Object;)V

    return-object v2
.end method

.method public final declared-synchronized a(Landroid/graphics/Bitmap;)Ljava/util/ArrayList;
    .locals 5

    monitor-enter p0

    :try_start_0
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->g:Lcom/scanflow/datacapture/barinternal/N;

    if-eqz v1, :cond_6

    if-nez p1, :cond_0

    goto/16 :goto_1

    :cond_0
    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v1, p1}, Lcom/scanflow/datacapture/barinternal/N;->a(Landroid/graphics/Bitmap;)Ljava/util/ArrayList;

    move-result-object v1

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "TFLite Model results Size: "

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v3, " Result:  "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "SFBarcode"

    invoke-static {v3, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/M;->B:Ljava/util/LinkedList;

    invoke-virtual {v2}, Ljava/util/LinkedList;->clear()V

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v2

    if-nez v2, :cond_1

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->recycle()V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception p1

    goto :goto_2

    :cond_1
    :try_start_1
    invoke-virtual {v1}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object p1

    const-string v1, "iterator(...)"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_2
    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_5

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    const-string v2, "next(...)"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v1, Lcom/scanflow/datacapture/barinternal/b;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    if-nez v2, :cond_3

    const-string v2, ""

    .line 10
    :cond_3
    const-string v3, "result"

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v3, "scanType"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 11
    iget v3, v1, Lcom/scanflow/datacapture/barinternal/b;->c:F

    const v4, 0x3e4ccccd    # 0.2f

    cmpl-float v3, v3, v4

    if-ltz v3, :cond_2

    .line 12
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 13
    invoke-static {v3, v2}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_4

    const-string v3, "any"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_2

    .line 14
    :cond_4
    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    :cond_5
    monitor-exit p0

    return-object v0

    :cond_6
    :goto_1
    monitor-exit p0

    return-object v0

    :goto_2
    :try_start_2
    monitor-exit p0
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw p1
.end method

.method public final a()V
    .locals 4

    .line 135
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/M;->H:J

    sub-long/2addr v0, v2

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/M;->I:J

    cmp-long v0, v0, v2

    if-lez v0, :cond_0

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->E:Landroid/os/Handler;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda7;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda7;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v0, v1}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    :cond_0
    return-void
.end method

.method public final a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/barinternal/D;ZILjava/lang/String;ZLcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V
    .locals 20

    move-object/from16 v0, p0

    move-object/from16 v2, p2

    move-object/from16 v1, p3

    sget-object v3, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    .line 104
    iget-object v10, v2, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 105
    iget-object v9, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 106
    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    const/4 v3, 0x0

    move-object/from16 v11, p1

    invoke-static {v11, v3, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/android/ConvertBitmap;->bitmapToGray(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object v4

    const-string v5, "bitmapToGray(...)"

    invoke-static {v4, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v5, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;

    invoke-direct {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;-><init>()V

    const-class v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {v5, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/FactoryFiducial;->qrcode(Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;

    move-result-object v5

    const-string v6, "qrcode(...)"

    invoke-static {v5, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-interface {v5, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodeDetector;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    invoke-interface {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodeDetector;->getDetections()Ljava/util/List;

    move-result-object v4

    invoke-interface {v4}, Ljava/util/List;->size()I

    move-result v5

    if-lez v5, :cond_0

    const/4 v3, 0x0

    invoke-interface {v4, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    iget-object v5, v5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->message:Ljava/lang/String;

    invoke-interface {v4, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bounds:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    new-instance v6, Landroid/graphics/PointF;

    invoke-virtual {v4, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v7

    iget-wide v12, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    double-to-float v7, v12

    invoke-virtual {v4, v3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v3

    iget-wide v12, v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    double-to-float v3, v12

    invoke-direct {v6, v7, v3}, Landroid/graphics/PointF;-><init>(FF)V

    invoke-virtual {v8, v6}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v3, Landroid/graphics/PointF;

    const/4 v6, 0x1

    invoke-virtual {v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v7

    iget-wide v12, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    double-to-float v7, v12

    invoke-virtual {v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v6

    iget-wide v12, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    double-to-float v6, v12

    invoke-direct {v3, v7, v6}, Landroid/graphics/PointF;-><init>(FF)V

    invoke-virtual {v8, v3}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v3, Landroid/graphics/PointF;

    const/4 v6, 0x2

    invoke-virtual {v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v7

    iget-wide v12, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    double-to-float v7, v12

    invoke-virtual {v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v6

    iget-wide v12, v6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    double-to-float v6, v12

    invoke-direct {v3, v7, v6}, Landroid/graphics/PointF;-><init>(FF)V

    invoke-virtual {v8, v3}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v3, Landroid/graphics/PointF;

    const/4 v6, 0x3

    invoke-virtual {v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v7

    iget-wide v12, v7, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    double-to-float v7, v12

    invoke-virtual {v4, v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v4

    iget-wide v12, v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    double-to-float v4, v12

    invoke-direct {v3, v7, v4}, Landroid/graphics/PointF;-><init>(FF)V

    invoke-virtual {v8, v3}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v4, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v6, Lcom/scanflow/datacapture/utils/BarcodeFormat;->QR_CODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move/from16 v7, p4

    invoke-direct/range {v4 .. v10}, Lcom/scanflow/datacapture/model/ScanResultSuccess;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V

    move-object v3, v4

    :cond_0
    const-string v4, "SFBarcode"

    if-eqz v3, :cond_3

    sget-object v5, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    new-instance v6, Ljava/lang/StringBuilder;

    const-string v7, "qrResult "

    invoke-direct {v6, v7}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v3}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getText()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v4, v6}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/M;->M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v6, :cond_1

    invoke-virtual {v6}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->playBeepSoundAndVibrate()V

    :cond_1
    move/from16 v6, p5

    invoke-static {v2, v3, v6}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/model/ScanResultSuccess;I)V

    new-instance v6, Ljava/lang/StringBuilder;

    const-string v7, "boundingBox = "

    invoke-direct {v6, v7}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/M;->l:Landroid/graphics/Matrix;

    .line 107
    iget-object v8, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 108
    const-string v9, "previewToCropTransform"

    invoke-static {v7, v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v9, "yolov4location"

    invoke-static {v8, v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v7, v8}, Landroid/graphics/Matrix;->mapRect(Landroid/graphics/RectF;)Z

    .line 109
    invoke-virtual {v6, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v4, v6}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    new-instance v6, Ljava/util/ArrayList;

    invoke-direct {v6}, Ljava/util/ArrayList;-><init>()V

    iput-object v6, v0, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    new-instance v12, Lcom/scanflow/ui/ar/ArObject;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getText()Ljava/lang/String;

    move-result-object v13

    .line 110
    iget-object v14, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 111
    iget-object v15, v0, Lcom/scanflow/datacapture/barinternal/M;->N:Landroid/util/Size;

    const-string v7, "#1ab3fb"

    invoke-static {v7}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v17

    const/16 v18, 0x0

    const/16 v19, 0x0

    const/16 v16, 0x0

    invoke-direct/range {v12 .. v19}, Lcom/scanflow/ui/ar/ArObject;-><init>(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)V

    invoke-virtual {v6, v12}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/M;->E:Landroid/os/Handler;

    new-instance v7, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda11;

    invoke-direct {v7, v0}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda11;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v6, v7}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    iget-object v6, v0, Lcom/scanflow/datacapture/barinternal/M;->B:Ljava/util/LinkedList;

    invoke-virtual {v6, v2}, Ljava/util/LinkedList;->add(Ljava/lang/Object;)Z

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v6, "Boofcv decode succeed in mode: "

    invoke-direct {v2, v6}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v5, v4, v1}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/M;->b()V

    sget-object v1, Lcom/scanflow/datacapture/barinternal/D;->a:Lcom/scanflow/datacapture/barinternal/D;

    invoke-virtual {v11}, Landroid/graphics/Bitmap;->recycle()V

    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v1, :cond_2

    invoke-interface {v1, v3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V

    :cond_2
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    iput-object v1, v0, Lcom/scanflow/datacapture/barinternal/M;->x:Ljava/util/ArrayList;

    const-string v1, "Scanned"

    move-object/from16 v3, p8

    invoke-interface {v3, v1}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onSuccess(Ljava/lang/String;)V

    return-void

    :cond_3
    move/from16 v6, p5

    move-object/from16 v3, p8

    sget-object v5, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    new-instance v7, Ljava/lang/StringBuilder;

    const-string v8, "Boofcv decode failed in mode: "

    invoke-direct {v7, v8}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v7, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v5, v4, v1}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    move-object/from16 v5, p6

    move v4, v6

    move-object v1, v11

    move-object v6, v3

    move/from16 v3, p4

    invoke-virtual/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;ZILjava/lang/String;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    return-void
.end method

.method public final a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;ZILjava/lang/String;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V
    .locals 9

    const-string v0, "SFBarcode"

    const-string v1, "decodeML - Started"

    invoke-static {v0, v1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/t;->a(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v0

    const/4 v1, 0x0

    invoke-static {v0, v1}, Lcom/google/mlkit/vision/common/InputImage;->fromBitmap(Landroid/graphics/Bitmap;I)Lcom/google/mlkit/vision/common/InputImage;

    move-result-object v0

    const-string v1, "fromBitmap(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 87
    sget-object v1, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    .line 88
    invoke-interface {v1, v0}, Lcom/google/mlkit/vision/barcode/BarcodeScanner;->process(Lcom/google/mlkit/vision/common/InputImage;)Lcom/google/android/gms/tasks/Task;

    move-result-object v0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;

    move-object v4, p0

    move-object v3, p1

    move-object v6, p2

    move v2, p3

    move v8, p4

    move-object v5, p5

    move-object v7, p6

    invoke-direct/range {v1 .. v8}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda6;-><init>(ZLandroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/M;Ljava/lang/String;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;I)V

    invoke-virtual {v0, v1}, Lcom/google/android/gms/tasks/Task;->addOnCompleteListener(Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;

    return-void
.end method

.method public final a(Landroid/graphics/Bitmap;ZLandroid/graphics/RectF;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V
    .locals 8

    .line 72
    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v0

    div-int/lit8 v0, v0, 0x2

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v1

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v2

    div-int/lit8 v2, v2, 0x2

    const/4 v3, 0x0

    invoke-static {p1, v3, v0, v1, v2}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIII)Landroid/graphics/Bitmap;

    move-result-object v0

    const-string v1, "createBitmap(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    sget-object v1, Lcom/google/mlkit/vision/text/latin/TextRecognizerOptions;->DEFAULT_OPTIONS:Lcom/google/mlkit/vision/text/latin/TextRecognizerOptions;

    new-instance v1, Lcom/google/mlkit/vision/text/latin/TextRecognizerOptions$Builder;

    invoke-direct {v1}, Lcom/google/mlkit/vision/text/latin/TextRecognizerOptions$Builder;-><init>()V

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/M;->i:Ljava/util/concurrent/ExecutorService;

    invoke-virtual {v1, v2}, Lcom/google/mlkit/vision/text/latin/TextRecognizerOptions$Builder;->setExecutor(Ljava/util/concurrent/Executor;)Lcom/google/mlkit/vision/text/latin/TextRecognizerOptions$Builder;

    move-result-object v1

    invoke-virtual {v1}, Lcom/google/mlkit/vision/text/latin/TextRecognizerOptions$Builder;->build()Lcom/google/mlkit/vision/text/latin/TextRecognizerOptions;

    move-result-object v1

    invoke-static {v1}, Lcom/google/mlkit/vision/text/TextRecognition;->getClient(Lcom/google/mlkit/vision/text/TextRecognizerOptionsInterface;)Lcom/google/mlkit/vision/text/TextRecognizer;

    move-result-object v1

    const-string v2, "getClient(...)"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v0, v3}, Lcom/google/mlkit/vision/common/InputImage;->fromBitmap(Landroid/graphics/Bitmap;I)Lcom/google/mlkit/vision/common/InputImage;

    move-result-object v0

    invoke-interface {v1, v0}, Lcom/google/mlkit/vision/text/TextRecognizer;->process(Lcom/google/mlkit/vision/common/InputImage;)Lcom/google/android/gms/tasks/Task;

    move-result-object v0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;

    move-object v3, p0

    move-object v7, p1

    move v4, p2

    move-object v5, p3

    move-object v6, p4

    move-object v2, p5

    invoke-direct/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda13;-><init>(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lcom/scanflow/datacapture/barinternal/M;ZLandroid/graphics/RectF;Lcom/scanflow/datacapture/barinternal/b;Landroid/graphics/Bitmap;)V

    new-instance p1, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda14;

    invoke-direct {p1, v1}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda14;-><init>(Lkotlin/jvm/functions/Function1;)V

    invoke-virtual {v0, p1}, Lcom/google/android/gms/tasks/Task;->addOnSuccessListener(Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;

    move-result-object p1

    new-instance p2, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda15;

    invoke-direct {p2, v2}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda15;-><init>(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    invoke-virtual {p1, p2}, Lcom/google/android/gms/tasks/Task;->addOnFailureListener(Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;

    return-void
.end method

.method public final a(Lcom/scanflow/datacapture/barcode/config/DecodeConfig;)V
    .locals 3

    .line 138
    const-string v0, "decodeConfig"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/E;->a:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, v0, p1

    const/4 v0, 0x1

    const-string v1, "any"

    const/4 v2, 0x0

    packed-switch p1, :pswitch_data_0

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;-><init>()V

    throw p1

    :pswitch_0
    const-string p1, "dotmatrix_metal"

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    iput-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/M;->b:Z

    return-void

    :pswitch_1
    const-string p1, "dotmatrix_white"

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    iput-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/M;->b:Z

    return-void

    :pswitch_2
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    iput-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/M;->b:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/M;->c:Z

    return-void

    :pswitch_3
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/M;->b:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/M;->d:Z

    return-void

    :pswitch_4
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/M;->b:Z

    iput-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/M;->d:Z

    return-void

    :pswitch_5
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    iput-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/M;->b:Z

    return-void

    :pswitch_6
    const-string p1, "bar_code"

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    iput-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/M;->b:Z

    return-void

    :pswitch_7
    const-string p1, "qr_code"

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    iput-boolean v2, p0, Lcom/scanflow/datacapture/barinternal/M;->b:Z

    return-void

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_7
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public final a(Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/model/LowLightResponse;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V
    .locals 26

    move-object/from16 v1, p0

    move-object/from16 v3, p1

    iget-object v0, v1, Lcom/scanflow/datacapture/barinternal/M;->k:Landroid/graphics/Matrix;

    if-eqz v0, :cond_0

    .line 112
    iget-object v2, v3, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 113
    invoke-virtual {v0, v2}, Landroid/graphics/Matrix;->mapRect(Landroid/graphics/RectF;)Z

    :cond_0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v2, "Result Location: "

    invoke-direct {v0, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v2, ".location"

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    const-string v2, "SFBarcode"

    invoke-static {v2, v0}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual/range {p2 .. p2}, Lcom/scanflow/datacapture/model/LowLightResponse;->getBitmap()Landroid/graphics/Bitmap;

    move-result-object v0

    .line 114
    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 115
    invoke-static {v0, v4}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;Landroid/graphics/RectF;)Landroid/graphics/Bitmap;

    move-result-object v0

    if-eqz v0, :cond_a

    .line 116
    iget-object v4, v3, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 117
    const-string v5, "qr_code"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_8

    sget-object v4, Lcom/scanflow/datacapture/barinternal/D;->a:Lcom/scanflow/datacapture/barinternal/D;

    .line 118
    iget-object v5, v3, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 119
    invoke-virtual {v1, v0, v5}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/D;

    move-result-object v5

    move-object v6, v4

    sget-object v4, Lcom/scanflow/datacapture/barinternal/D;->b:Lcom/scanflow/datacapture/barinternal/D;

    if-eq v5, v4, :cond_1

    sget-object v4, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v5, "Is Long Distance Image : false"

    invoke-virtual {v4, v2, v5}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    .line 120
    iget-object v7, v3, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 121
    invoke-virtual/range {p2 .. p2}, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight()Z

    move-result v8

    const/4 v5, 0x0

    move-object v4, v6

    const/4 v6, 0x1

    move-object/from16 v9, p3

    move-object v2, v0

    invoke-virtual/range {v1 .. v9}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/barinternal/D;ZILjava/lang/String;ZLcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    return-void

    :cond_1
    sget-object v5, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v6, "Is Long Distance Image : true"

    invoke-virtual {v5, v2, v6}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    .line 122
    const-string v6, "Super Resolution & Gamma Correction applied - Started"

    invoke-virtual {v5, v2, v6}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    sget-object v6, Lcom/scanflow/datacapture/barinternal/s;->a:Landroid/graphics/Bitmap;

    iget-object v6, v1, Lcom/scanflow/datacapture/barinternal/M;->z:Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;

    .line 123
    const-string v7, "orginal"

    invoke-static {v0, v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v7, 0x0

    :try_start_0
    new-instance v8, Landroid/graphics/BitmapFactory$Options;

    invoke-direct {v8}, Landroid/graphics/BitmapFactory$Options;-><init>()V

    const/4 v9, 0x1

    iput-boolean v9, v8, Landroid/graphics/BitmapFactory$Options;->inJustDecodeBounds:Z

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/s;->a(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v0

    iget v9, v8, Landroid/graphics/BitmapFactory$Options;->outWidth:I

    int-to-float v9, v9

    const/high16 v10, 0x40000000    # 2.0f

    mul-float/2addr v9, v10

    float-to-int v9, v9

    iget v11, v8, Landroid/graphics/BitmapFactory$Options;->outHeight:I

    int-to-float v11, v11

    mul-float/2addr v11, v10

    float-to-int v10, v11

    const/4 v11, 0x2

    :goto_0
    div-int v12, v9, v11

    div-int v13, v10, v11

    mul-int/2addr v12, v13

    const/high16 v13, 0xc00000

    if-le v12, v13, :cond_2

    mul-int/lit8 v11, v11, 0x2

    goto :goto_0

    :cond_2
    iput-boolean v7, v8, Landroid/graphics/BitmapFactory$Options;->inJustDecodeBounds:Z

    iput v11, v8, Landroid/graphics/BitmapFactory$Options;->inSampleSize:I

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v8

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v9

    mul-int/2addr v8, v9

    const/high16 v9, 0x800000

    div-int/2addr v8, v9

    int-to-double v8, v8

    invoke-static {v8, v9}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v8

    const-wide/high16 v10, 0x3ff0000000000000L    # 1.0

    invoke-static {v8, v9, v10, v11}, Ljava/lang/Math;->max(DD)D

    move-result-wide v8

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v10

    int-to-double v10, v10

    div-double/2addr v10, v8

    double-to-int v10, v10

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v11

    int-to-double v11, v11

    div-double/2addr v11, v8

    double-to-int v8, v11

    invoke-static {v0, v10, v8, v7}, Landroid/graphics/Bitmap;->createScaledBitmap(Landroid/graphics/Bitmap;IIZ)Landroid/graphics/Bitmap;

    move-result-object v0

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    filled-new-array {v0}, [Landroid/graphics/Bitmap;

    move-result-object v0

    invoke-virtual {v6, v0, v7}, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;->process([Landroid/graphics/Bitmap;I)Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;

    move-result-object v0
    :try_end_0
    .catch Ljava/lang/OutOfMemoryError; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    :catch_0
    move-exception v0

    invoke-virtual {v0}, Ljava/lang/Throwable;->printStackTrace()V

    new-instance v8, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;

    new-instance v9, Ljava/util/ArrayList;

    invoke-direct {v9}, Ljava/util/ArrayList;-><init>()V

    new-array v10, v7, [Ljava/lang/String;

    const-wide/16 v11, 0x0

    const-wide/16 v13, 0x0

    invoke-direct/range {v8 .. v14}, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;-><init>(Ljava/util/List;[Ljava/lang/String;JJ)V

    move-object v0, v8

    :goto_1
    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v8, Lcom/scanflow/datacapture/barinternal/s;->a:Landroid/graphics/Bitmap;

    filled-new-array {v8}, [Landroid/graphics/Bitmap;

    move-result-object v8

    invoke-virtual {v6, v8, v7}, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;->process([Landroid/graphics/Bitmap;I)Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    if-eqz v0, :cond_3

    .line 124
    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/source/super_resolution/ProcessResult;->getResults()Ljava/util/List;

    move-result-object v0

    if-eqz v0, :cond_3

    invoke-interface {v0, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;

    goto :goto_2

    :cond_3
    const/4 v0, 0x0

    :goto_2
    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;->getEnhancedImages()[Landroid/graphics/Bitmap;

    move-result-object v0

    aget-object v0, v0, v7

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    .line 125
    const-string v6, "src"

    invoke-static {v0, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v6

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v8

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getConfig()Landroid/graphics/Bitmap$Config;

    move-result-object v9

    if-nez v9, :cond_4

    sget-object v9, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    :cond_4
    invoke-static {v6, v8, v9}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v6

    const-string v8, "createBitmap(...)"

    invoke-static {v6, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v8

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v9

    const/16 v10, 0x100

    new-array v11, v10, [I

    new-array v12, v10, [I

    new-array v13, v10, [I

    move v14, v7

    :goto_3
    move-object/from16 v16, v11

    if-ge v14, v10, :cond_5

    int-to-double v10, v14

    const-wide v17, 0x406fe00000000000L    # 255.0

    div-double v10, v10, v17

    move/from16 v19, v8

    const-wide v7, 0x3ffaaaaaaaaaaaabL    # 1.6666666666666667

    invoke-static {v10, v11, v7, v8}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v20

    mul-double v20, v20, v17

    const-wide/high16 v22, 0x3fe0000000000000L    # 0.5

    add-double v7, v20, v22

    double-to-int v7, v7

    const/16 v8, 0xff

    invoke-static {v8, v7}, Ljava/lang/Math;->min(II)I

    move-result v7

    aput v7, v16, v14

    move v7, v9

    const-wide v8, 0x3ffaaaaaaaaaaaabL    # 1.6666666666666667

    invoke-static {v10, v11, v8, v9}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v24

    mul-double v24, v24, v17

    add-double v8, v24, v22

    double-to-int v8, v8

    const/16 v9, 0xff

    invoke-static {v9, v8}, Ljava/lang/Math;->min(II)I

    move-result v8

    aput v8, v12, v14

    move/from16 v20, v7

    const-wide v7, 0x3ffaaaaaaaaaaaabL    # 1.6666666666666667

    invoke-static {v10, v11, v7, v8}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v7

    mul-double v7, v7, v17

    add-double v7, v7, v22

    double-to-int v7, v7

    invoke-static {v9, v7}, Ljava/lang/Math;->min(II)I

    move-result v7

    aput v7, v13, v14

    add-int/lit8 v14, v14, 0x1

    move-object/from16 v11, v16

    move/from16 v8, v19

    move/from16 v9, v20

    const/4 v7, 0x0

    const/16 v10, 0x100

    goto :goto_3

    :cond_5
    move v7, v8

    const/4 v8, 0x0

    :goto_4
    move/from16 v20, v9

    if-ge v8, v7, :cond_7

    move/from16 v9, v20

    const/4 v10, 0x0

    :goto_5
    if-ge v10, v9, :cond_6

    invoke-virtual {v0, v8, v10}, Landroid/graphics/Bitmap;->getPixel(II)I

    move-result v11

    invoke-static {v11}, Landroid/graphics/Color;->alpha(I)I

    move-result v14

    invoke-static {v11}, Landroid/graphics/Color;->red(I)I

    move-result v15

    aget v15, v16, v15

    invoke-static {v11}, Landroid/graphics/Color;->green(I)I

    move-result v17

    move-object/from16 v18, v0

    aget v0, v12, v17

    invoke-static {v11}, Landroid/graphics/Color;->blue(I)I

    move-result v11

    aget v11, v13, v11

    invoke-static {v14, v15, v0, v11}, Landroid/graphics/Color;->argb(IIII)I

    move-result v0

    invoke-virtual {v6, v8, v10, v0}, Landroid/graphics/Bitmap;->setPixel(III)V

    add-int/lit8 v10, v10, 0x1

    move-object/from16 v0, v18

    goto :goto_5

    :cond_6
    move-object/from16 v18, v0

    add-int/lit8 v8, v8, 0x1

    goto :goto_4

    :cond_7
    move-object/from16 v18, v0

    .line 126
    const-string v0, "Super Resolution & Gamma Correction applied"

    invoke-virtual {v5, v2, v0}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    invoke-virtual/range {v18 .. v18}, Landroid/graphics/Bitmap;->recycle()V

    .line 127
    iget-object v7, v3, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 128
    invoke-virtual/range {p2 .. p2}, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight()Z

    move-result v8

    const/4 v5, 0x1

    move-object v2, v6

    const/4 v6, 0x2

    move-object/from16 v9, p3

    invoke-virtual/range {v1 .. v9}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/barinternal/D;ZILjava/lang/String;ZLcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    return-void

    :cond_8
    sget-object v2, Lcom/scanflow/datacapture/barinternal/D;->a:Lcom/scanflow/datacapture/barinternal/D;

    .line 129
    iget-object v2, v3, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 130
    invoke-virtual {v1, v0, v2}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/D;

    move-result-object v2

    sget-object v4, Lcom/scanflow/datacapture/barinternal/D;->b:Lcom/scanflow/datacapture/barinternal/D;

    if-eq v2, v4, :cond_9

    .line 131
    iget-object v6, v3, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 132
    invoke-virtual/range {p2 .. p2}, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight()Z

    const/4 v4, 0x0

    const/4 v5, 0x1

    move-object/from16 v7, p3

    move-object v2, v0

    invoke-virtual/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;ZILjava/lang/String;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    return-void

    :cond_9
    move-object v2, v0

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/s;->a(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v2

    .line 133
    iget-object v6, v3, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 134
    invoke-virtual/range {p2 .. p2}, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight()Z

    const/4 v4, 0x1

    const/4 v5, 0x1

    move-object/from16 v1, p0

    move-object/from16 v7, p3

    invoke-virtual/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;ZILjava/lang/String;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    return-void

    :cond_a
    move-object/from16 v7, p3

    invoke-virtual {v1, v7}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/M;->a()V

    return-void
.end method

.method public final a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V
    .locals 2

    .line 136
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/M;->q:Z

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_0

    const-string v1, "Scan Failed!"

    invoke-interface {v0, v1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanResultFailure(Ljava/lang/String;)V

    :cond_0
    invoke-interface {p1}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onPerformCaptureScan()V

    :cond_1
    invoke-interface {p1}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onFailure()V

    return-void
.end method

.method public final declared-synchronized a(Lcom/scanflow/datacapture/sfbarcode/SFCameraView;)V
    .locals 2

    monitor-enter p0

    .line 137
    :try_start_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->getPreviewView()Landroidx/camera/view/PreviewView;

    move-result-object v0

    invoke-virtual {v0}, Landroid/view/View;->getMeasuredWidth()I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/M;->s:I

    invoke-virtual {p1}, Lcom/scanflow/datacapture/sfbarcode/SFCameraView;->getPreviewView()Landroidx/camera/view/PreviewView;

    move-result-object p1

    invoke-virtual {p1}, Landroid/view/View;->getMeasuredHeight()I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/M;->t:I

    sget-object p1, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    sget-object v0, Lkotlin/jvm/internal/StringCompanionObject;->INSTANCE:Lkotlin/jvm/internal/StringCompanionObject;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/M;->s:I

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/M;->t:I

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    filled-new-array {v0, v1}, [Ljava/lang/Object;

    move-result-object v0

    const/4 v1, 0x2

    invoke-static {v0, v1}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v0

    const-string v1, "PreviewMetrics: %dx%d"

    invoke-static {v1, v0}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    const-string v1, "format(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v1, "SFBarcode"

    invoke-virtual {p1, v1, v0}, Lcom/scanflow/datacapture/utils/ScanflowLog;->i(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-void

    :catchall_0
    move-exception p1

    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw p1
.end method

.method public final a(Lcom/scanflow/ui/ar/ArOverlayView;)V
    .locals 3

    .line 4
    const-string v0, "arOverlays"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/ui/ar/BoundingBoxArOverlay;-><init>(Landroid/content/Context;Z)V

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->C:Landroidx/lifecycle/MutableLiveData;

    invoke-virtual {v1, p1}, Landroidx/lifecycle/MutableLiveData;->postValue(Ljava/lang/Object;)V

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->D:Landroidx/lifecycle/MutableLiveData;

    new-instance v2, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda9;

    invoke-direct {v2, v0, p0}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda9;-><init>(Lcom/scanflow/ui/ar/BoundingBoxArOverlay;Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v1, p0, v2}, Landroidx/lifecycle/LiveData;->observe(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V

    new-instance v0, Lcom/scanflow/datacapture/barinternal/I;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/I;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {p1, v0}, Landroid/view/View;->setOnTouchListener(Landroid/view/View$OnTouchListener;)V

    return-void
.end method

.method public final a(Ljava/util/ArrayList;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V
    .locals 21

    move-object/from16 v0, p0

    move-object/from16 v1, p2

    const-string v2, "batchScanningResultList"

    move-object/from16 v3, p1

    invoke-static {v3, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v2, "listener"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v3}, Ljava/util/ArrayList;->size()I

    move-result v2

    if-lez v2, :cond_d

    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    new-instance v4, Ljava/util/ArrayList;

    invoke-direct {v4}, Ljava/util/ArrayList;-><init>()V

    iput-object v4, v0, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/M;->B:Ljava/util/LinkedList;

    invoke-virtual {v4}, Ljava/util/LinkedList;->clear()V

    invoke-virtual {v3}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v3

    const-string v4, "iterator(...)"

    invoke-static {v3, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_0
    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v4

    if-eqz v4, :cond_b

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v4

    const-string v5, "next(...)"

    invoke-static {v4, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v4, Lcom/scanflow/datacapture/barinternal/C;

    new-instance v9, Ljava/util/ArrayList;

    invoke-direct {v9}, Ljava/util/ArrayList;-><init>()V

    .line 45
    iget-object v12, v4, Lcom/scanflow/datacapture/barinternal/C;->b:Lcom/google/mlkit/vision/barcode/common/Barcode;

    if-eqz v12, :cond_0

    .line 46
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/C;->c:Ljava/lang/String;

    if-nez v5, :cond_1

    .line 47
    invoke-virtual {v12}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v5

    if-eqz v5, :cond_0

    invoke-virtual {v12}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v5

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v5}, Ljava/lang/String;->length()I

    move-result v5

    if-nez v5, :cond_1

    goto :goto_0

    :cond_1
    new-instance v5, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    .line 48
    iget-object v6, v4, Lcom/scanflow/datacapture/barinternal/C;->c:Ljava/lang/String;

    if-eqz v6, :cond_2

    goto :goto_1

    .line 49
    :cond_2
    invoke-virtual {v12}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v13

    invoke-static {v13}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const/16 v17, 0x4

    const/16 v18, 0x0

    const-string v14, "\u001d"

    const-string v15, " "

    const/16 v16, 0x0

    invoke-static/range {v13 .. v18}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    invoke-static {v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->trimStart(Ljava/lang/CharSequence;)Ljava/lang/CharSequence;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v6

    :goto_1
    invoke-virtual {v12}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v7

    invoke-static {v7}, Lcom/scanflow/datacapture/barinternal/M;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v7

    .line 50
    iget-object v10, v4, Lcom/scanflow/datacapture/barinternal/C;->a:Landroid/graphics/RectF;

    .line 51
    invoke-static {v10}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/M;->r:Ljava/lang/String;

    const/4 v8, 0x0

    invoke-direct/range {v5 .. v11}, Lcom/scanflow/datacapture/model/ScanResultSuccess;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V

    invoke-virtual {v2, v5}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v5, Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    invoke-virtual {v12}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v6

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v12}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v7

    invoke-static {v7}, Lcom/scanflow/datacapture/barinternal/M;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object v7

    invoke-direct {v5, v6, v7}, Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    new-instance v6, Lcom/scanflow/datacapture/barinternal/b;

    invoke-virtual {v12}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v7

    invoke-static {v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v12}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v8

    invoke-static {v8}, Lcom/scanflow/datacapture/barinternal/M;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object v8

    const/high16 v9, 0x3f000000    # 0.5f

    .line 52
    iget-object v10, v4, Lcom/scanflow/datacapture/barinternal/C;->a:Landroid/graphics/RectF;

    .line 53
    invoke-direct {v6, v7, v8, v9, v10}, Lcom/scanflow/datacapture/barinternal/b;-><init>(Ljava/lang/String;Ljava/lang/String;FLandroid/graphics/RectF;)V

    iget-boolean v7, v0, Lcom/scanflow/datacapture/barinternal/M;->d:Z

    if-eqz v7, :cond_4

    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/M;->J:Ljava/util/HashSet;

    invoke-virtual {v7, v5}, Ljava/util/HashSet;->contains(Ljava/lang/Object;)Z

    move-result v7

    if-eqz v7, :cond_3

    goto :goto_2

    .line 55
    :cond_3
    const-string v7, "#FFFFFF"

    invoke-static {v7}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v7

    goto :goto_3

    .line 53
    :cond_4
    :goto_2
    const-string v7, "#1ab3fb"

    invoke-static {v7}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v7

    .line 54
    :goto_3
    iput v7, v6, Lcom/scanflow/datacapture/barinternal/b;->f:I

    .line 56
    iget-object v7, v4, Lcom/scanflow/datacapture/barinternal/C;->b:Lcom/google/mlkit/vision/barcode/common/Barcode;

    .line 57
    invoke-virtual {v7}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v7

    const/4 v8, 0x2

    if-ne v7, v8, :cond_5

    .line 58
    iget-object v7, v4, Lcom/scanflow/datacapture/barinternal/C;->c:Ljava/lang/String;

    :goto_4
    move-object v14, v7

    goto :goto_5

    .line 59
    :cond_5
    iget-object v7, v4, Lcom/scanflow/datacapture/barinternal/C;->b:Lcom/google/mlkit/vision/barcode/common/Barcode;

    if-eqz v7, :cond_6

    .line 60
    invoke-virtual {v7}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v7

    goto :goto_4

    :cond_6
    const/4 v7, 0x0

    goto :goto_4

    :goto_5
    if-eqz v14, :cond_a

    .line 61
    iget-object v7, v4, Lcom/scanflow/datacapture/barinternal/C;->a:Landroid/graphics/RectF;

    if-eqz v7, :cond_9

    .line 62
    invoke-virtual {v14}, Ljava/lang/String;->length()I

    move-result v7

    if-nez v7, :cond_7

    goto :goto_6

    :cond_7
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/M;->b0:Ljava/util/HashSet;

    invoke-virtual {v7, v14}, Ljava/util/HashSet;->contains(Ljava/lang/Object;)Z

    move-result v7

    if-eqz v7, :cond_8

    iget-boolean v7, v0, Lcom/scanflow/datacapture/barinternal/M;->d:Z

    if-eqz v7, :cond_9

    :cond_8
    new-instance v7, Ljava/lang/StringBuilder;

    const-string v8, "scannedMatrixDataList.contains(it): "

    invoke-direct {v7, v8}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v8, v0, Lcom/scanflow/datacapture/barinternal/M;->b0:Ljava/util/HashSet;

    invoke-virtual {v8, v14}, Ljava/util/HashSet;->contains(Ljava/lang/Object;)Z

    move-result v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const/16 v8, 0x20

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    iget-boolean v9, v0, Lcom/scanflow/datacapture/barinternal/M;->d:Z

    invoke-virtual {v7, v9}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    const-string v9, "batchScanningResult"

    invoke-static {v9, v7}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v7, Ljava/lang/StringBuilder;

    const-string v10, "batchScanningResult: "

    invoke-direct {v7, v10}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 63
    iget-object v10, v4, Lcom/scanflow/datacapture/barinternal/C;->a:Landroid/graphics/RectF;

    .line 64
    invoke-virtual {v7, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 65
    iget-object v4, v4, Lcom/scanflow/datacapture/barinternal/C;->c:Ljava/lang/String;

    .line 66
    invoke-virtual {v7, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v9, v4}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/M;->F:Ljava/util/ArrayList;

    new-instance v13, Lcom/scanflow/ui/ar/ArObject;

    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/M;->l:Landroid/graphics/Matrix;

    .line 67
    iget-object v15, v6, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 68
    const-string v8, "previewToCropTransform"

    invoke-static {v7, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v8, "yolov4location"

    invoke-static {v15, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v7, v15}, Landroid/graphics/Matrix;->mapRect(Landroid/graphics/RectF;)Z

    .line 69
    iget-object v7, v0, Lcom/scanflow/datacapture/barinternal/M;->N:Landroid/util/Size;

    .line 70
    iget v8, v6, Lcom/scanflow/datacapture/barinternal/b;->f:I

    .line 71
    iget-boolean v9, v0, Lcom/scanflow/datacapture/barinternal/M;->d:Z

    xor-int/lit8 v20, v9, 0x1

    const/16 v17, 0x0

    move-object/from16 v19, v5

    move-object/from16 v16, v7

    move/from16 v18, v8

    invoke-direct/range {v13 .. v20}, Lcom/scanflow/ui/ar/ArObject;-><init>(Ljava/lang/String;Landroid/graphics/RectF;Landroid/util/Size;IILcom/scanflow/datacapture/model/OneOFManyCodesScanResults;Z)V

    invoke-virtual {v4, v13}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    :cond_9
    :goto_6
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/M;->b0:Ljava/util/HashSet;

    invoke-virtual {v4, v14}, Ljava/util/HashSet;->add(Ljava/lang/Object;)Z

    :cond_a
    iget-object v4, v0, Lcom/scanflow/datacapture/barinternal/M;->B:Ljava/util/LinkedList;

    invoke-virtual {v4, v6}, Ljava/util/LinkedList;->add(Ljava/lang/Object;)Z

    goto/16 :goto_0

    :cond_b
    iget-object v3, v0, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v3, :cond_c

    invoke-interface {v3, v2}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onBatchScanResultSuccess(Ljava/util/ArrayList;)V

    :cond_c
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/M;->E:Landroid/os/Handler;

    new-instance v3, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda5;

    invoke-direct {v3, v0}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v2, v3}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/M;->b()V

    const-string v2, "Scanned"

    invoke-interface {v1, v2}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onSuccess(Ljava/lang/String;)V

    return-void

    :cond_d
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/M;->a()V

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    return-void
.end method

.method public final analyze(Landroidx/camera/core/ImageProxy;Landroidx/camera/core/Camera;Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Ljava/lang/Object;)V
    .locals 23

    move-object/from16 v3, p0

    move-object/from16 v4, p2

    move-object/from16 v0, p3

    move-object/from16 v5, p4

    move-object/from16 v1, p5

    const-string v2, "bitmapSource"

    const-string v6, "dotmatrix_white"

    const-string v7, "createBitmap(...)"

    const-string v8, "SFBarcode"

    const-string v9, "448 image to model - Completed "

    const-string v10, "Blur Detection - Completed "

    const-string v11, "imageProxy to Bitmap - Completed "

    const-string v12, "isOneTouchZoomEnabled - "

    const-string v13, "imageProxy"

    move-object/from16 v14, p1

    invoke-static {v14, v13}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v13, "mCamera"

    invoke-static {v4, v13}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v13, "cameraUserConfig"

    invoke-static {v0, v13}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v13, "listener"

    invoke-static {v5, v13}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    :try_start_0
    iget-object v13, v3, Lcom/scanflow/datacapture/barinternal/M;->v:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;

    if-nez v13, :cond_0

    iput-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->v:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;

    goto :goto_0

    :catch_0
    move-object v9, v3

    goto/16 :goto_21

    .line 0
    :cond_0
    :goto_0
    iget-object v13, v3, Lcom/scanflow/datacapture/barinternal/M;->M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-nez v13, :cond_1

    invoke-virtual {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getBeepSoundResource()Ljava/lang/Integer;

    move-result-object v13

    if-eqz v13, :cond_1

    new-instance v13, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    iget-object v15, v3, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    invoke-static {v15}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getBeepSoundResource()Ljava/lang/Integer;

    move-result-object v0

    invoke-direct {v13, v15, v0}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;-><init>(Landroid/content/Context;Ljava/lang/Integer;)V

    iput-object v13, v3, Lcom/scanflow/datacapture/barinternal/M;->M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getVibrate()Z

    move-result v0

    invoke-virtual {v13, v0}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setVibrate(Z)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v0, :cond_2

    :goto_1
    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getPlayBeep()Z

    move-result v13

    goto :goto_2

    :cond_1
    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-nez v0, :cond_2

    new-instance v0, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    iget-object v13, v3, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    invoke-static {v13}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget v15, Lcom/scanflow/datacapture/barcode/R$raw;->beep:I

    invoke-static {v15}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v15

    invoke-direct {v0, v13, v15}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;-><init>(Landroid/content/Context;Ljava/lang/Integer;)V

    iput-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getVibrate()Z

    move-result v13

    invoke-virtual {v0, v13}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setVibrate(Z)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->M:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v0, :cond_2

    goto :goto_1

    :goto_2
    invoke-virtual {v0, v13}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setPlayBeep(Z)V

    :cond_2
    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isContinuousScan()Z

    move-result v0

    iput-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->p:Z

    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isPerformCaptureScan()Z

    move-result v0

    iput-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->q:Z

    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isNetworkAvailable()Z

    move-result v0

    iput-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->R:Z

    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->S:Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicBoolean;->get()Z

    move-result v0

    if-nez v0, :cond_c

    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getLicenseInfo()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v16

    if-nez v16, :cond_4

    iget-boolean v15, v3, Lcom/scanflow/datacapture/barinternal/M;->R:Z

    if-nez v15, :cond_4

    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    if-eqz v0, :cond_3

    new-instance v1, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda0;

    invoke-direct {v1, v3}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_3
    const-string v0, "Error 19 - Device Activation Failed\nThe device activation failed. Please connect to the Internet and restart the app."

    invoke-interface {v5, v0}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onLicenseFailed(Ljava/lang/String;)V

    return-void

    :cond_4
    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v15

    if-nez v15, :cond_5

    iget-boolean v15, v3, Lcom/scanflow/datacapture/barinternal/M;->R:Z

    if-eqz v15, :cond_5

    const-string v0, "InProgress"

    invoke-interface {v5, v0}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onLicenseFailed(Ljava/lang/String;)V

    return-void

    :cond_5
    invoke-virtual {v3, v0}, Lcom/scanflow/datacapture/barinternal/M;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    new-instance v15, Lcom/google/gson/Gson;

    invoke-direct {v15}, Lcom/google/gson/Gson;-><init>()V

    const-class v13, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    invoke-virtual {v15, v0, v13}, Lcom/google/gson/Gson;->fromJson(Ljava/lang/String;Ljava/lang/Class;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    iput-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->X:Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    if-eqz v0, :cond_9

    invoke-virtual {v0}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getResult()Lcom/scanflow/datacapture/model/subscription/Result;

    move-result-object v0

    if-eqz v0, :cond_9

    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->X:Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)Z

    move-result v0

    if-eqz v0, :cond_7

    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    if-eqz v0, :cond_6

    new-instance v1, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda1;

    invoke-direct {v1, v3}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_6
    const-string v0, "Error 13 - License Key Expired\nThe license key validation failed. Your license key has expired, please log into your account at www.scanflow.ai and request an extension or contact support through this contact form."

    invoke-interface {v5, v0}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onLicenseFailed(Ljava/lang/String;)V

    return-void

    :cond_7
    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    if-eqz v0, :cond_8

    new-instance v13, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda2;

    invoke-direct {v13, v3}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v0, v13}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_8
    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->S:Ljava/util/concurrent/atomic/AtomicBoolean;

    const/4 v13, 0x1

    invoke-virtual {v0, v13}, Ljava/util/concurrent/atomic/AtomicBoolean;->set(Z)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    goto :goto_4

    :cond_9
    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    if-eqz v0, :cond_a

    new-instance v1, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda3;

    invoke-direct {v1, v3}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_a
    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->X:Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    if-eqz v0, :cond_b

    invoke-virtual {v0}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getMessage()Ljava/lang/String;

    move-result-object v15

    goto :goto_3

    :cond_b
    const/4 v15, 0x0

    :goto_3
    invoke-static {v15}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v5, v15}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onLicenseFailed(Ljava/lang/String;)V

    return-void

    :cond_c
    :goto_4
    iget-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->p:Z

    if-nez v0, :cond_d

    iget-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->q:Z

    if-nez v0, :cond_d

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/M;->a()V

    invoke-interface {v5}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onFailure()V

    return-void

    :cond_d
    const-string v0, "null cannot be cast to non-null type com.scanflow.datacapture.core.camera.ScanflowReader.OnBarcodeScanResultCallback"

    invoke-static {v1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    move-object v0, v1

    check-cast v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    iput-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getAutoZoom()Z

    move-result v0

    iput-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->n:Z

    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isOneTouchZoomEnabled()Z

    move-result v0

    iput-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->u:Z

    invoke-virtual/range {p3 .. p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getSelectedResolution()Landroid/util/Size;

    move-result-object v0

    iput-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->N:Landroid/util/Size;

    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v1, "isOneTouchZoomEnabled"

    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13, v12}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-boolean v12, v3, Lcom/scanflow/datacapture/barinternal/M;->u:Z

    invoke-virtual {v13, v12}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v12

    invoke-virtual {v0, v1, v12}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v1, v3, Lcom/scanflow/datacapture/barinternal/M;->O:Lcom/scanflow/datacapture/sfbarcode/SFCameraView;

    if-nez v1, :cond_e

    const-string v1, "sfCameraView"

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    const/4 v1, 0x0

    :cond_e
    invoke-virtual {v3, v1}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/sfbarcode/SFCameraView;)V

    const-string v1, "imageProxy to Bitmap - Started"

    invoke-virtual {v0, v8, v1}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    invoke-static {v14}, Lcom/scanflow/datacapture/barinternal/t;->a(Landroidx/camera/core/ImageProxy;)Landroid/graphics/Bitmap;

    move-result-object v1

    new-instance v12, Ljava/lang/StringBuilder;

    invoke-direct {v12, v11}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    if-eqz v1, :cond_f

    invoke-virtual {v1}, Landroid/graphics/Bitmap;->getByteCount()I

    move-result v11

    invoke-static {v11}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v11

    goto :goto_5

    :cond_f
    const/4 v11, 0x0

    :goto_5
    invoke-virtual {v12, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v12}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v0, v8, v11}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v14}, Landroidx/camera/core/ImageProxy;->getCropRect()Landroid/graphics/Rect;

    move-result-object v11

    iget v11, v11, Landroid/graphics/Rect;->left:I

    invoke-interface {v14}, Landroidx/camera/core/ImageProxy;->getCropRect()Landroid/graphics/Rect;

    move-result-object v12

    iget v12, v12, Landroid/graphics/Rect;->top:I

    invoke-interface {v14}, Landroidx/camera/core/ImageProxy;->getCropRect()Landroid/graphics/Rect;

    move-result-object v13

    invoke-virtual {v13}, Landroid/graphics/Rect;->width()I

    move-result v13

    invoke-interface {v14}, Landroidx/camera/core/ImageProxy;->getCropRect()Landroid/graphics/Rect;

    move-result-object v15

    invoke-virtual {v15}, Landroid/graphics/Rect;->height()I

    move-result v15

    invoke-static {v1, v11, v12, v13, v15}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIII)Landroid/graphics/Bitmap;

    move-result-object v11

    invoke-static {v11, v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-interface {v14}, Landroidx/camera/core/ImageProxy;->getImageInfo()Landroidx/camera/core/ImageInfo;

    move-result-object v12

    invoke-interface {v12}, Landroidx/camera/core/ImageInfo;->getRotationDegrees()I

    move-result v12

    invoke-static {v11, v12}, Lcom/scanflow/datacapture/barinternal/t;->a(Landroid/graphics/Bitmap;I)Landroid/graphics/Bitmap;

    move-result-object v11

    iget-object v12, v3, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    if-eqz v12, :cond_10

    invoke-virtual {v12}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v12

    if-eqz v12, :cond_10

    invoke-virtual {v12}, Landroid/content/res/Resources;->getConfiguration()Landroid/content/res/Configuration;

    move-result-object v12

    if-eqz v12, :cond_10

    iget v12, v12, Landroid/content/res/Configuration;->orientation:I

    goto :goto_6

    :cond_10
    const/4 v12, 0x1

    :goto_6
    invoke-virtual {v11}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v13

    invoke-virtual {v11}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v15

    const/16 v14, 0x1c0

    invoke-static {v13, v15, v14, v14, v12}, Lcom/scanflow/datacapture/barinternal/t;->a(IIIII)Landroid/graphics/Matrix;

    move-result-object v13

    iput-object v13, v3, Lcom/scanflow/datacapture/barinternal/M;->j:Landroid/graphics/Matrix;

    new-instance v13, Landroid/graphics/Matrix;

    invoke-direct {v13}, Landroid/graphics/Matrix;-><init>()V

    iput-object v13, v3, Lcom/scanflow/datacapture/barinternal/M;->k:Landroid/graphics/Matrix;

    iget-object v15, v3, Lcom/scanflow/datacapture/barinternal/M;->j:Landroid/graphics/Matrix;

    if-eqz v15, :cond_11

    invoke-virtual {v15, v13}, Landroid/graphics/Matrix;->invert(Landroid/graphics/Matrix;)Z

    :cond_11
    iget v13, v3, Lcom/scanflow/datacapture/barinternal/M;->s:I

    iget v15, v3, Lcom/scanflow/datacapture/barinternal/M;->t:I

    invoke-virtual {v11}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v14

    move-object/from16 v18, v2

    invoke-virtual {v11}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v2

    invoke-static {v13, v15, v14, v2, v12}, Lcom/scanflow/datacapture/barinternal/t;->a(IIIII)Landroid/graphics/Matrix;

    move-result-object v2

    iput-object v2, v3, Lcom/scanflow/datacapture/barinternal/M;->l:Landroid/graphics/Matrix;

    invoke-virtual {v2, v2}, Landroid/graphics/Matrix;->invert(Landroid/graphics/Matrix;)Z

    const-string v2, "About to start blur detection check"

    invoke-virtual {v0, v8, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v2, v3, Lcom/scanflow/datacapture/barinternal/M;->e:Lcom/scanflow/datacapture/barinternal/g;

    const/4 v12, 0x0

    if-eqz v2, :cond_14

    const-string v2, "Blur Detection - Started"

    invoke-virtual {v0, v8, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    invoke-interface/range {p1 .. p1}, Landroidx/camera/core/ImageProxy;->getImageInfo()Landroidx/camera/core/ImageInfo;

    move-result-object v2

    invoke-interface {v2}, Landroidx/camera/core/ImageInfo;->getRotationDegrees()I

    move-result v2

    iget-object v13, v3, Lcom/scanflow/datacapture/barinternal/M;->e:Lcom/scanflow/datacapture/barinternal/g;

    if-eqz v13, :cond_12

    invoke-virtual {v13, v11, v2}, Lcom/scanflow/datacapture/barinternal/e;->a(Landroid/graphics/Bitmap;I)Ljava/util/ArrayList;

    move-result-object v2

    goto :goto_7

    :cond_12
    const/4 v2, 0x0

    :goto_7
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13, v10}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    if-eqz v2, :cond_13

    invoke-interface {v2, v12}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Lcom/scanflow/datacapture/barinternal/d;

    if-eqz v10, :cond_13

    .line 1
    iget-object v10, v10, Lcom/scanflow/datacapture/barinternal/d;->b:Ljava/lang/String;

    goto :goto_8

    :cond_13
    const/4 v10, 0x0

    .line 2
    :goto_8
    invoke-virtual {v13, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v0, v8, v10}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    if-eqz v2, :cond_15

    invoke-interface {v2}, Ljava/util/List;->isEmpty()Z

    move-result v10

    if-nez v10, :cond_15

    invoke-interface {v2, v12}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/d;

    .line 3
    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/d;->b:Ljava/lang/String;

    .line 4
    const-string v10, "sharp"

    const/4 v13, 0x1

    invoke-static {v2, v10, v13}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->equals(Ljava/lang/String;Ljava/lang/String;Z)Z

    move-result v2

    if-nez v2, :cond_15

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/M;->a()V

    invoke-interface {v5}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onFailure()V

    return-void

    :cond_14
    const-string v2, "Blur Detection - Skipped (classifier not available)"

    invoke-virtual {v0, v8, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    :cond_15
    const-string v2, "Blur detection check completed, proceeding to next step"

    invoke-virtual {v0, v8, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    const-string v2, "About to start low light detection"

    invoke-virtual {v0, v8, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    const-string v2, "Checking Low Light and image updated - Started"

    invoke-virtual {v0, v8, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    sget-object v2, Lcom/scanflow/datacapture/barinternal/h;->a:Lcom/scanflow/datacapture/barinternal/h;

    invoke-virtual {v2, v11}, Lcom/scanflow/datacapture/barinternal/h;->a(Landroid/graphics/Bitmap;)Lcom/scanflow/datacapture/model/LowLightResponse;

    move-result-object v2

    const-string v10, "Checking Low Light and image updated - Completed"

    invoke-virtual {v0, v8, v10}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    if-nez v2, :cond_17

    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_16

    invoke-interface {v0, v12}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_16
    invoke-virtual {v3, v5}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    move-object v9, v3

    goto/16 :goto_1b

    :cond_17
    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    invoke-virtual {v0, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_18

    iget-object v0, v3, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    const-string v10, "dotmatrix_metal"

    invoke-virtual {v0, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_19

    :cond_18
    move-object v9, v3

    move-object v10, v5

    goto/16 :goto_1c

    :cond_19
    const-string v0, "image resize to 448 - Started"

    invoke-static {v8, v0}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {v2}, Lcom/scanflow/datacapture/model/LowLightResponse;->getBitmap()Landroid/graphics/Bitmap;

    move-result-object v0
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 5
    :try_start_1
    const-string v1, "source"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v1

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v6

    sget-object v10, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    const/16 v11, 0x1c0

    invoke-static {v11, v11, v10}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v10

    invoke-static {v10, v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v6, v1, v11, v11, v12}, Lcom/scanflow/datacapture/barinternal/t;->a(IIIII)Landroid/graphics/Matrix;

    move-result-object v1

    new-instance v6, Landroid/graphics/Matrix;

    invoke-direct {v6}, Landroid/graphics/Matrix;-><init>()V

    invoke-virtual {v1, v6}, Landroid/graphics/Matrix;->invert(Landroid/graphics/Matrix;)Z

    new-instance v6, Landroid/graphics/Canvas;

    invoke-direct {v6, v10}, Landroid/graphics/Canvas;-><init>(Landroid/graphics/Bitmap;)V

    const/4 v7, 0x0

    invoke-virtual {v6, v0, v1, v7}, Landroid/graphics/Canvas;->drawBitmap(Landroid/graphics/Bitmap;Landroid/graphics/Matrix;Landroid/graphics/Paint;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 6
    :try_start_2
    const-string v0, "image resize to 448 - Completed"

    invoke-static {v8, v0}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    const-string v0, "448 image to model - Started"

    invoke-static {v8, v0}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {v3, v10}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;)Ljava/util/ArrayList;

    move-result-object v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1, v9}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v6

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v8, v1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    iget-object v1, v3, Lcom/scanflow/datacapture/barinternal/M;->L:Lcom/scanflow/datacapture/barinternal/v;

    if-eqz v1, :cond_1a

    new-instance v6, Ljava/util/LinkedList;

    invoke-direct {v6}, Ljava/util/LinkedList;-><init>()V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    invoke-virtual {v1, v6}, Lcom/scanflow/datacapture/barinternal/v;->a(Ljava/util/List;)V

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_1a
    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v1

    const/4 v13, 0x1

    if-ge v1, v13, :cond_2a

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/M;->a()V

    iget-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->n:Z
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_0

    const-string v1, "format(...)"

    const-string v2, "%.2f"

    const/high16 v6, 0x3f800000    # 1.0f

    const v7, 0x3c23d70a    # 0.01f

    if-eqz v0, :cond_23

    :try_start_3
    invoke-interface {v4}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    if-eqz v0, :cond_1b

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v0

    if-eqz v0, :cond_1b

    invoke-virtual {v0}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroidx/camera/core/ZoomState;

    if-eqz v0, :cond_1b

    invoke-interface {v0}, Landroidx/camera/core/ZoomState;->getLinearZoom()F

    move-result v0

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    goto :goto_9

    :cond_1b
    const/4 v0, 0x0

    :goto_9
    invoke-interface {v4}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v8

    if-eqz v8, :cond_1c

    invoke-interface {v8}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v8

    if-eqz v8, :cond_1c

    invoke-virtual {v8}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Landroidx/camera/core/ZoomState;

    if-eqz v8, :cond_1c

    invoke-interface {v8}, Landroidx/camera/core/ZoomState;->getZoomRatio()F

    move-result v8

    invoke-static {v8}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v8

    goto :goto_a

    :cond_1c
    const/4 v8, 0x0

    :goto_a
    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v8}, Ljava/lang/Float;->floatValue()F

    move-result v8

    invoke-interface {v4}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v9

    if-eqz v9, :cond_1d

    invoke-interface {v9}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v9

    if-eqz v9, :cond_1d

    invoke-virtual {v9}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Landroidx/camera/core/ZoomState;

    if-eqz v9, :cond_1d

    invoke-interface {v9}, Landroidx/camera/core/ZoomState;->getMaxZoomRatio()F

    move-result v9

    invoke-static {v9}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v9

    goto :goto_b

    :cond_1d
    const/4 v9, 0x0

    :goto_b
    invoke-static {v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v9}, Ljava/lang/Float;->floatValue()F

    move-result v9

    if-eqz v0, :cond_22

    cmpg-float v10, v8, v9

    if-nez v10, :cond_1e

    goto :goto_e

    :cond_1e
    iget-boolean v10, v3, Lcom/scanflow/datacapture/barinternal/M;->h:Z

    if-nez v10, :cond_21

    move v9, v7

    const/4 v8, 0x1

    :goto_c
    const/16 v10, 0x10

    if-ge v8, v10, :cond_20

    add-float/2addr v9, v7

    sget-object v10, Lkotlin/jvm/internal/StringCompanionObject;->INSTANCE:Lkotlin/jvm/internal/StringCompanionObject;

    invoke-virtual {v0}, Ljava/lang/Float;->floatValue()F

    move-result v10

    add-float/2addr v10, v9

    invoke-static {v10}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v10

    filled-new-array {v10}, [Ljava/lang/Object;

    move-result-object v10

    const/4 v13, 0x1

    invoke-static {v10, v13}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v10

    invoke-static {v2, v10}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v10

    invoke-static {v10, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v10}, Ljava/lang/Float;->parseFloat(Ljava/lang/String;)F

    move-result v11

    cmpg-float v11, v11, v6

    if-gtz v11, :cond_1f

    invoke-interface {v4}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v11

    if-eqz v11, :cond_1f

    invoke-static {v10}, Ljava/lang/Float;->parseFloat(Ljava/lang/String;)F

    move-result v10

    invoke-interface {v11, v10}, Landroidx/camera/core/CameraControl;->setLinearZoom(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_1f
    add-int/lit8 v8, v8, 0x1

    goto :goto_c

    :cond_20
    :goto_d
    move-object v9, v3

    move-object v10, v5

    goto/16 :goto_14

    :cond_21
    :goto_e
    cmpl-float v0, v8, v9

    if-ltz v0, :cond_20

    iget-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->h:Z

    if-nez v0, :cond_20

    const/4 v13, 0x1

    iput-boolean v13, v3, Lcom/scanflow/datacapture/barinternal/M;->h:Z

    sget-object v6, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/GlobalScope;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/GlobalScope;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->getIO()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object v0

    iget-object v1, v3, Lcom/scanflow/datacapture/barinternal/M;->m:Lcom/scanflow/datacapture/barinternal/L;

    invoke-virtual {v0, v1}, Lkotlin/coroutines/AbstractCoroutineContextElement;->plus(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;

    move-result-object v7

    new-instance v9, Lcom/scanflow/datacapture/barinternal/F;

    const/4 v0, 0x0

    invoke-direct {v9, v3, v4, v0}, Lcom/scanflow/datacapture/barinternal/F;-><init>(Lcom/scanflow/datacapture/barinternal/M;Landroidx/camera/core/Camera;Lkotlin/coroutines/Continuation;)V

    const/4 v10, 0x2

    const/4 v11, 0x0

    const/4 v8, 0x0

    invoke-static/range {v6 .. v11}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    goto :goto_d

    :cond_22
    move-object v9, v3

    move-object v10, v5

    goto/16 :goto_15

    :cond_23
    iget-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->u:Z

    if-eqz v0, :cond_20

    iget-boolean v0, v3, Lcom/scanflow/datacapture/barinternal/M;->h:Z

    if-nez v0, :cond_20

    invoke-interface {v4}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v0

    if-eqz v0, :cond_24

    invoke-interface {v0}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v0

    if-eqz v0, :cond_24

    invoke-virtual {v0}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroidx/camera/core/ZoomState;

    if-eqz v0, :cond_24

    invoke-interface {v0}, Landroidx/camera/core/ZoomState;->getLinearZoom()F

    move-result v0

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    goto :goto_f

    :cond_24
    const/4 v0, 0x0

    :goto_f
    invoke-interface {v4}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v8

    if-eqz v8, :cond_25

    invoke-interface {v8}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v8

    if-eqz v8, :cond_25

    invoke-virtual {v8}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Landroidx/camera/core/ZoomState;

    if-eqz v8, :cond_25

    invoke-interface {v8}, Landroidx/camera/core/ZoomState;->getZoomRatio()F

    move-result v8

    invoke-static {v8}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v8

    goto :goto_10

    :cond_25
    const/4 v8, 0x0

    :goto_10
    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v8}, Ljava/lang/Float;->floatValue()F

    move-result v8

    invoke-interface {v4}, Landroidx/camera/core/Camera;->getCameraInfo()Landroidx/camera/core/CameraInfo;

    move-result-object v9

    if-eqz v9, :cond_26

    invoke-interface {v9}, Landroidx/camera/core/CameraInfo;->getZoomState()Landroidx/lifecycle/LiveData;

    move-result-object v9

    if-eqz v9, :cond_26

    invoke-virtual {v9}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Landroidx/camera/core/ZoomState;

    if-eqz v9, :cond_26

    invoke-interface {v9}, Landroidx/camera/core/ZoomState;->getMaxZoomRatio()F

    move-result v9

    invoke-static {v9}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v15

    goto :goto_11

    :cond_26
    const/4 v15, 0x0

    :goto_11
    invoke-static {v15}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v15}, Ljava/lang/Float;->floatValue()F

    move-result v9

    new-instance v10, Lkotlin/jvm/internal/Ref$FloatRef;

    invoke-direct {v10}, Lkotlin/jvm/internal/Ref$FloatRef;-><init>()V

    iput v7, v10, Lkotlin/jvm/internal/Ref$FloatRef;->element:F

    if-eqz v0, :cond_22

    invoke-virtual {v0}, Ljava/lang/Number;->floatValue()F

    move-result v11

    cmpg-float v11, v11, v6

    if-gez v11, :cond_29

    iput v7, v10, Lkotlin/jvm/internal/Ref$FloatRef;->element:F

    const/4 v8, 0x1

    :goto_12
    const/16 v9, 0x1a

    if-ge v8, v9, :cond_20

    iget v9, v10, Lkotlin/jvm/internal/Ref$FloatRef;->element:F

    add-float/2addr v9, v7

    iput v9, v10, Lkotlin/jvm/internal/Ref$FloatRef;->element:F

    sget-object v9, Lkotlin/jvm/internal/StringCompanionObject;->INSTANCE:Lkotlin/jvm/internal/StringCompanionObject;

    invoke-virtual {v0}, Ljava/lang/Float;->floatValue()F

    move-result v9

    iget v11, v10, Lkotlin/jvm/internal/Ref$FloatRef;->element:F

    add-float/2addr v9, v11

    invoke-static {v9}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v9

    filled-new-array {v9}, [Ljava/lang/Object;

    move-result-object v9

    const/4 v13, 0x1

    invoke-static {v9, v13}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v9

    invoke-static {v2, v9}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v9

    invoke-static {v9, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v9}, Ljava/lang/Float;->parseFloat(Ljava/lang/String;)F

    move-result v11

    cmpg-float v11, v11, v6

    if-gtz v11, :cond_27

    invoke-interface {v4}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v11

    if-eqz v11, :cond_28

    invoke-static {v9}, Ljava/lang/Float;->parseFloat(Ljava/lang/String;)F

    move-result v9

    invoke-interface {v11, v9}, Landroidx/camera/core/CameraControl;->setLinearZoom(F)Lcom/google/common/util/concurrent/ListenableFuture;

    goto :goto_13

    :cond_27
    invoke-interface {v4}, Landroidx/camera/core/Camera;->getCameraControl()Landroidx/camera/core/CameraControl;

    move-result-object v9

    if-eqz v9, :cond_28

    invoke-interface {v9, v6}, Landroidx/camera/core/CameraControl;->setLinearZoom(F)Lcom/google/common/util/concurrent/ListenableFuture;

    :cond_28
    :goto_13
    add-int/lit8 v8, v8, 0x1

    goto :goto_12

    :cond_29
    cmpl-float v1, v8, v9

    if-ltz v1, :cond_20

    iget-boolean v1, v3, Lcom/scanflow/datacapture/barinternal/M;->h:Z

    if-nez v1, :cond_20

    invoke-interface {v5}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->OnOneTouchCallbackDisable()V

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    iput-boolean v12, v3, Lcom/scanflow/datacapture/barinternal/M;->u:Z

    const/4 v13, 0x1

    iput-boolean v13, v3, Lcom/scanflow/datacapture/barinternal/M;->h:Z

    sget-object v7, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/GlobalScope;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/GlobalScope;

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Dispatchers;->getIO()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;

    move-result-object v1

    iget-object v2, v3, Lcom/scanflow/datacapture/barinternal/M;->m:Lcom/scanflow/datacapture/barinternal/L;

    invoke-virtual {v1, v2}, Lkotlin/coroutines/AbstractCoroutineContextElement;->plus(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;

    move-result-object v8

    move-object v2, v0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/G;

    const/4 v6, 0x0

    move-object v1, v10

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/G;-><init>(Lkotlin/jvm/internal/Ref$FloatRef;Ljava/lang/Float;Lcom/scanflow/datacapture/barinternal/M;Landroidx/camera/core/Camera;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lkotlin/coroutines/Continuation;)V
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_0

    move-object v9, v3

    move-object v10, v5

    const/4 v5, 0x2

    const/4 v6, 0x0

    const/4 v3, 0x0

    move-object v4, v0

    move-object v1, v7

    move-object v2, v8

    :try_start_4
    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    :goto_14
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :goto_15
    iget-object v0, v9, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_2f

    invoke-interface {v0, v12}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    goto/16 :goto_17

    :cond_2a
    move-object v9, v3

    move-object v10, v5

    iget-boolean v1, v9, Lcom/scanflow/datacapture/barinternal/M;->b:Z
    :try_end_4
    .catch Ljava/lang/Exception; {:try_start_4 .. :try_end_4} :catch_1

    const-string v3, "next(...)"

    const-string v4, "iterator(...)"

    if-eqz v1, :cond_30

    :try_start_5
    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v1

    if-lez v1, :cond_30

    iget-object v1, v9, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v1, :cond_2b

    const/4 v13, 0x1

    invoke-interface {v1, v13}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_2b
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    iput-object v1, v9, Lcom/scanflow/datacapture/barinternal/M;->Q:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v0

    invoke-static {v0, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_2c
    :goto_16
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_2d

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v1, Lcom/scanflow/datacapture/barinternal/b;

    .line 7
    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 8
    iget-object v5, v9, Lcom/scanflow/datacapture/barinternal/M;->k:Landroid/graphics/Matrix;

    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v5, v4}, Landroid/graphics/Matrix;->mapRect(Landroid/graphics/RectF;)Z

    .line 9
    const-string v5, "<set-?>"

    invoke-static {v4, v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object v4, v1, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 10
    iget-object v4, v9, Lcom/scanflow/datacapture/barinternal/M;->B:Ljava/util/LinkedList;

    invoke-virtual {v4, v1}, Ljava/util/LinkedList;->add(Ljava/lang/Object;)Z

    invoke-virtual {v2}, Lcom/scanflow/datacapture/model/LowLightResponse;->getBitmap()Landroid/graphics/Bitmap;

    move-result-object v4

    .line 11
    iget-object v5, v1, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 12
    invoke-static {v4, v5}, Lcom/scanflow/datacapture/barinternal/M;->a(Landroid/graphics/Bitmap;Landroid/graphics/RectF;)Landroid/graphics/Bitmap;

    move-result-object v4

    if-eqz v4, :cond_2c

    iget-object v5, v9, Lcom/scanflow/datacapture/barinternal/M;->Q:Ljava/util/ArrayList;

    new-instance v6, Lcom/scanflow/datacapture/barinternal/B;

    .line 13
    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 14
    invoke-direct {v6, v4, v1}, Lcom/scanflow/datacapture/barinternal/B;-><init>(Landroid/graphics/Bitmap;Landroid/graphics/RectF;)V

    invoke-virtual {v5, v6}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_16

    :cond_2d
    iget-object v0, v9, Lcom/scanflow/datacapture/barinternal/M;->Q:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v0

    if-lez v0, :cond_2e

    new-instance v0, Lcom/scanflow/datacapture/barinternal/H;

    const/4 v7, 0x0

    invoke-direct {v0, v9, v10, v7}, Lcom/scanflow/datacapture/barinternal/H;-><init>(Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Lkotlin/coroutines/Continuation;)V

    const/4 v13, 0x1

    invoke-static {v7, v0, v13, v7}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->runBlocking$default(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Ljava/lang/Object;

    goto/16 :goto_1b

    :cond_2e
    invoke-virtual {v9}, Lcom/scanflow/datacapture/barinternal/M;->a()V

    .line 6
    :cond_2f
    :goto_17
    invoke-virtual {v9, v10}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    goto/16 :goto_1b

    :cond_30
    const/4 v7, 0x0

    .line 14
    iget-boolean v1, v9, Lcom/scanflow/datacapture/barinternal/M;->c:Z

    const/16 v5, 0xe0

    if-eqz v1, :cond_36

    invoke-virtual {v0}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v0

    invoke-static {v0, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_31
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_32

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v1, Lcom/scanflow/datacapture/barinternal/b;

    .line 15
    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    int-to-float v6, v5

    .line 16
    invoke-virtual {v4, v6, v6}, Landroid/graphics/RectF;->contains(FF)Z

    move-result v4

    if-eqz v4, :cond_31

    move-object v15, v1

    goto :goto_18

    :cond_32
    move-object v15, v7

    :goto_18
    if-eqz v15, :cond_34

    .line 17
    iget-object v0, v9, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_33

    const/4 v13, 0x1

    invoke-interface {v0, v13}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_33
    invoke-virtual {v9, v15, v2, v10}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/model/LowLightResponse;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    goto :goto_1a

    :cond_34
    invoke-virtual {v9}, Lcom/scanflow/datacapture/barinternal/M;->a()V

    iget-object v0, v9, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_35

    invoke-interface {v0, v12}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_35
    invoke-virtual {v9, v10}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    goto :goto_1a

    :cond_36
    invoke-virtual {v0}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v0

    invoke-static {v0, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_37
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_38

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v1, Lcom/scanflow/datacapture/barinternal/b;

    .line 18
    iget-object v4, v1, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    int-to-float v6, v5

    .line 19
    invoke-virtual {v4, v6, v6}, Landroid/graphics/RectF;->contains(FF)Z

    move-result v4

    if-eqz v4, :cond_37

    move-object v15, v1

    goto :goto_19

    :cond_38
    move-object v15, v7

    :goto_19
    if-eqz v15, :cond_3a

    .line 20
    iget-object v0, v9, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_39

    const/4 v13, 0x1

    invoke-interface {v0, v13}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_39
    invoke-virtual {v9, v15, v2, v10}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/model/LowLightResponse;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    goto :goto_1a

    :cond_3a
    invoke-virtual {v9}, Lcom/scanflow/datacapture/barinternal/M;->a()V

    iget-object v0, v9, Lcom/scanflow/datacapture/barinternal/M;->P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_3b

    invoke-interface {v0, v12}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_3b
    invoke-virtual {v9, v10}, Lcom/scanflow/datacapture/barinternal/M;->a(Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    .line 17
    :goto_1a
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    .line 4
    :goto_1b
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-void

    :catchall_0
    move-exception v0

    move-object v9, v3

    .line 20
    throw v0

    :goto_1c
    invoke-interface/range {p1 .. p1}, Landroidx/camera/core/ImageProxy;->getImageInfo()Landroidx/camera/core/ImageInfo;

    move-result-object v0

    invoke-interface {v0}, Landroidx/camera/core/ImageInfo;->getRotationDegrees()I

    move-result v0

    invoke-interface/range {p1 .. p1}, Landroidx/camera/core/ImageProxy;->getHeight()I

    move-result v2

    invoke-interface/range {p1 .. p1}, Landroidx/camera/core/ImageProxy;->getWidth()I

    move-result v3

    div-int v4, v3, v2

    new-instance v5, Landroid/graphics/Rect;

    invoke-direct {v5, v12, v12, v3, v2}, Landroid/graphics/Rect;-><init>(IIII)V

    iget-object v8, v9, Lcom/scanflow/datacapture/barinternal/M;->a0:Landroidx/lifecycle/MutableLiveData;

    invoke-virtual {v8}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    const/4 v11, 0x3

    const/4 v13, 0x2

    if-le v4, v11, :cond_3c

    invoke-static {v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v8}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getFirst()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/Number;

    invoke-virtual {v4}, Ljava/lang/Number;->intValue()I

    move-result v4

    invoke-virtual {v8}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getSecond()Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Ljava/lang/Number;

    invoke-virtual {v8}, Ljava/lang/Number;->intValue()I

    move-result v8

    iget-object v11, v9, Lcom/scanflow/datacapture/barinternal/M;->a0:Landroidx/lifecycle/MutableLiveData;

    new-instance v14, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    div-int/2addr v4, v13

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v8}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v8

    invoke-direct {v14, v4, v8}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    invoke-virtual {v11, v14}, Landroidx/lifecycle/MutableLiveData;->setValue(Ljava/lang/Object;)V

    :cond_3c
    iget-object v4, v9, Lcom/scanflow/datacapture/barinternal/M;->a0:Landroidx/lifecycle/MutableLiveData;

    invoke-virtual {v4}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getFirst()Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Ljava/lang/Number;

    invoke-virtual {v8}, Ljava/lang/Number;->intValue()I

    move-result v8

    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getSecond()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/Number;

    invoke-virtual {v4}, Ljava/lang/Number;->intValue()I

    move-result v4

    const/16 v11, 0x5a

    const/high16 v14, 0x42c80000    # 100.0f

    if-eq v0, v11, :cond_3d

    const/16 v11, 0x10e

    if-eq v0, v11, :cond_3d

    new-instance v11, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    int-to-float v4, v4

    div-float/2addr v4, v14

    invoke-static {v4}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v4

    int-to-float v8, v8

    div-float/2addr v8, v14

    invoke-static {v8}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v8

    invoke-direct {v11, v4, v8}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    goto :goto_1d

    :cond_3d
    new-instance v11, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    int-to-float v8, v8

    div-float/2addr v8, v14

    invoke-static {v8}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v8

    int-to-float v4, v4

    div-float/2addr v4, v14

    invoke-static {v4}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v4

    invoke-direct {v11, v8, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    :goto_1d
    invoke-virtual {v11}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->component1()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/Number;

    invoke-virtual {v4}, Ljava/lang/Number;->floatValue()F

    move-result v4

    invoke-virtual {v11}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->component2()Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Ljava/lang/Number;

    invoke-virtual {v8}, Ljava/lang/Number;->floatValue()F

    move-result v8

    int-to-float v3, v3

    mul-float/2addr v3, v4

    int-to-float v4, v13

    div-float/2addr v3, v4

    float-to-int v3, v3

    int-to-float v2, v2

    mul-float/2addr v2, v8

    div-float/2addr v2, v4

    float-to-int v2, v2

    invoke-virtual {v5, v3, v2}, Landroid/graphics/Rect;->inset(II)V

    invoke-static {v1, v0, v5}, Lcom/scanflow/datacapture/barinternal/t;->a(Landroid/graphics/Bitmap;ILandroid/graphics/Rect;)Landroid/graphics/Bitmap;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    if-eqz v0, :cond_3e

    invoke-virtual {v9, v0}, Lcom/scanflow/datacapture/barinternal/M;->b(Landroid/graphics/Bitmap;)V

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    :cond_3e
    sget-object v1, Lcom/scanflow/datacapture/barinternal/s;->a:Landroid/graphics/Bitmap;

    iget-object v1, v9, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    invoke-virtual {v1, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_3f

    const-wide v1, 0x406fe00000000000L    # 255.0

    :goto_1e
    move-object/from16 v3, v18

    goto :goto_1f

    :cond_3f
    const-wide v1, 0x4072c00000000000L    # 300.0

    goto :goto_1e

    .line 21
    :goto_1f
    invoke-static {v0, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v13, Lorg/opencv/core/Mat;

    invoke-direct {v13}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {v0, v13}, Lorg/opencv/android/Utils;->bitmapToMat(Landroid/graphics/Bitmap;Lorg/opencv/core/Mat;)V

    new-instance v14, Lorg/opencv/core/Mat;

    invoke-direct {v14}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v15, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    invoke-direct {v15, v1, v2, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;-><init>(DD)V

    const-wide/16 v18, 0x0

    const/16 v20, 0x2

    const-wide/16 v16, 0x0

    invoke-static/range {v13 .. v20}, Lorg/opencv/imgproc/Imgproc;->resize(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;DDI)V

    invoke-virtual {v14}, Lorg/opencv/core/Mat;->cols()I

    move-result v0

    invoke-virtual {v14}, Lorg/opencv/core/Mat;->rows()I

    move-result v1

    sget-object v2, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v0, v1, v2}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v0

    invoke-static {v0, v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v14, v0}, Lorg/opencv/android/Utils;->matToBitmap(Lorg/opencv/core/Mat;Landroid/graphics/Bitmap;)V

    if-eqz v0, :cond_41

    .line 22
    iget-object v1, v9, Lcom/scanflow/datacapture/barinternal/M;->a:Ljava/lang/String;

    invoke-virtual {v1, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_40

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/r;->b(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v1

    goto :goto_20

    :cond_40
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/r;->a(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v1

    :goto_20
    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v4

    int-to-double v4, v4

    const-wide/high16 v13, 0x4010000000000000L    # 4.0

    div-double/2addr v4, v13

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v0

    move-wide/from16 p1, v13

    int-to-double v13, v0

    div-double v13, v13, p1

    .line 23
    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v15, Lorg/opencv/core/Mat;

    invoke-direct {v15}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {v1, v15}, Lorg/opencv/android/Utils;->bitmapToMat(Landroid/graphics/Bitmap;Lorg/opencv/core/Mat;)V

    new-instance v16, Lorg/opencv/core/Mat;

    invoke-direct/range {v16 .. v16}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    invoke-direct {v0, v4, v5, v13, v14}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;-><init>(DD)V

    const-wide/16 v20, 0x0

    const/16 v22, 0x2

    const-wide/16 v18, 0x0

    move-object/from16 v17, v0

    invoke-static/range {v15 .. v22}, Lorg/opencv/imgproc/Imgproc;->resize(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;DDI)V

    move-object/from16 v0, v16

    invoke-virtual {v0}, Lorg/opencv/core/Mat;->cols()I

    move-result v1

    invoke-virtual {v0}, Lorg/opencv/core/Mat;->rows()I

    move-result v3

    invoke-static {v1, v3, v2}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v1

    invoke-static {v1, v7}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v0, v1}, Lorg/opencv/android/Utils;->matToBitmap(Lorg/opencv/core/Mat;Landroid/graphics/Bitmap;)V

    .line 24
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/t;->b(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v0

    invoke-static {v0, v12}, Lcom/google/mlkit/vision/common/InputImage;->fromBitmap(Landroid/graphics/Bitmap;I)Lcom/google/mlkit/vision/common/InputImage;

    move-result-object v0

    const-string v1, "fromBitmap(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 25
    sget-object v1, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    .line 26
    invoke-interface {v1, v0}, Lcom/google/mlkit/vision/barcode/BarcodeScanner;->process(Lcom/google/mlkit/vision/common/InputImage;)Lcom/google/android/gms/tasks/Task;

    move-result-object v0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda4;

    invoke-direct {v1, v9, v10}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/M;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;)V

    invoke-virtual {v0, v1}, Lcom/google/android/gms/tasks/Task;->addOnCompleteListener(Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;
    :try_end_5
    .catch Ljava/lang/Exception; {:try_start_5 .. :try_end_5} :catch_1

    :catch_1
    :cond_41
    :goto_21
    return-void
.end method

.method public final declared-synchronized b()V
    .locals 3

    monitor-enter p0

    .line 3
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->L:Lcom/scanflow/datacapture/barinternal/v;

    if-eqz v0, :cond_0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->B:Ljava/util/LinkedList;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/v;->a(Ljava/util/List;)V

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_3

    :catch_0
    move-exception v0

    goto :goto_1

    :cond_0
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    if-eqz v0, :cond_1

    new-instance v1, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda12;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/M$$ExternalSyntheticLambda12;-><init>(Lcom/scanflow/datacapture/barinternal/M;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    :cond_1
    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v1, "SFBarcode"

    const-string v2, "Bounding Box Updated"

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_2

    :goto_1
    :try_start_1
    invoke-virtual {v0}, Ljava/lang/Throwable;->printStackTrace()V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    :goto_2
    monitor-exit p0

    return-void

    :goto_3
    :try_start_2
    monitor-exit p0
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw v0
.end method

.method public final b(Landroid/graphics/Bitmap;)V
    .locals 4

    .line 2
    sget-object v0, Lcom/scanflow/datacapture/utils/StorageUtils;->INSTANCE:Lcom/scanflow/datacapture/utils/StorageUtils;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    const-string v2, "BarcodeOrginal"

    const/4 v3, 0x0

    invoke-virtual {v0, p1, v1, v2, v3}, Lcom/scanflow/datacapture/utils/StorageUtils;->addBitmapToStorage(Landroid/graphics/Bitmap;Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Landroid/net/Uri;

    move-result-object p1

    if-eqz p1, :cond_0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/M;->f:Landroid/app/Activity;

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v0, v1, p1}, Lcom/scanflow/datacapture/utils/StorageUtils;->getPath(Landroid/content/Context;Landroid/net/Uri;)Ljava/lang/String;

    :cond_0
    return-void
.end method

.method public final getLifecycle()Landroidx/lifecycle/Lifecycle;
    .locals 1

    .line 1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/M;->w:Landroidx/lifecycle/LifecycleRegistry;

    return-object v0
.end method
