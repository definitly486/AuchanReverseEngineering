.class public final Lcom/scanflow/datacapture/barcode/b;
.super Lcom/scanflow/datacapture/barcode/SFBarcodeReader;
.source "SourceFile"


# instance fields
.field public a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

.field public final b:Ljava/lang/String;

.field public final c:I

.field public final d:F

.field public final e:Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;

.field public final f:Ljava/lang/String;

.field public final g:Z

.field public final h:Z

.field public final i:Z

.field public final j:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

.field public final k:Ljava/lang/String;

.field public final l:Ljava/util/ArrayList;

.field public final m:Landroid/graphics/Matrix;

.field public final n:Ljava/util/HashSet;

.field public final o:Ljava/util/LinkedList;

.field public final p:Ljava/util/HashSet;

.field public final q:Ljava/lang/String;


# direct methods
.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;Lcom/scanflow/datacapture/barcode/config/DecodeConfig;Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;Landroid/graphics/Bitmap;)V
    .locals 20

    move-object/from16 v1, p0

    move-object/from16 v0, p1

    move-object/from16 v2, p2

    move-object/from16 v3, p3

    move-object/from16 v4, p4

    move-object/from16 v5, p5

    const-string v6, "mActivity"

    invoke-static {v0, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "SCANFLOW_LICENSE_KEY"

    invoke-static {v2, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "decodeConfig"

    invoke-static {v3, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "callback"

    invoke-static {v4, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v6, "bitmap"

    invoke-static {v5, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {v1}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader;-><init>()V

    new-instance v6, Ljava/util/concurrent/atomic/AtomicBoolean;

    const/4 v7, 0x0

    invoke-direct {v6, v7}, Ljava/util/concurrent/atomic/AtomicBoolean;-><init>(Z)V

    const-string v8, "SFBarcodeBitmap"

    iput-object v8, v1, Lcom/scanflow/datacapture/barcode/b;->b:Ljava/lang/String;

    const-string v9, "MODEL_FILE_KEY_PREF_NAME"

    const-string v10, "WN*J8yH19c9szb9#"

    const/16 v11, 0x1c0

    iput v11, v1, Lcom/scanflow/datacapture/barcode/b;->c:I

    const v12, 0x3e4ccccd    # 0.2f

    iput v12, v1, Lcom/scanflow/datacapture/barcode/b;->d:F

    const-string v12, "SuperResolution"

    const-string v13, "qr_code"

    iput-object v13, v1, Lcom/scanflow/datacapture/barcode/b;->f:Ljava/lang/String;

    const-string v13, "any"

    iput-object v13, v1, Lcom/scanflow/datacapture/barcode/b;->k:Ljava/lang/String;

    new-instance v13, Ljava/util/ArrayList;

    invoke-direct {v13}, Ljava/util/ArrayList;-><init>()V

    iput-object v13, v1, Lcom/scanflow/datacapture/barcode/b;->l:Ljava/util/ArrayList;

    new-instance v13, Landroid/graphics/Matrix;

    invoke-direct {v13}, Landroid/graphics/Matrix;-><init>()V

    new-instance v13, Ljava/util/HashSet;

    invoke-direct {v13}, Ljava/util/HashSet;-><init>()V

    iput-object v13, v1, Lcom/scanflow/datacapture/barcode/b;->n:Ljava/util/HashSet;

    new-instance v13, Ljava/util/LinkedList;

    invoke-direct {v13}, Ljava/util/LinkedList;-><init>()V

    iput-object v13, v1, Lcom/scanflow/datacapture/barcode/b;->o:Ljava/util/LinkedList;

    new-instance v13, Ljava/util/HashSet;

    invoke-direct {v13}, Ljava/util/HashSet;-><init>()V

    iput-object v13, v1, Lcom/scanflow/datacapture/barcode/b;->p:Ljava/util/HashSet;

    const-string v13, "sharp"

    iput-object v13, v1, Lcom/scanflow/datacapture/barcode/b;->q:Ljava/lang/String;

    const-string v13, "License Checking - Started"

    invoke-static {v8, v13}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    iput-object v4, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    new-instance v4, Landroidx/security/crypto/MasterKey$Builder;

    const-string v13, "_androidx_security_master_key_"

    invoke-direct {v4, v0, v13}, Landroidx/security/crypto/MasterKey$Builder;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    sget-object v13, Landroidx/security/crypto/MasterKey$KeyScheme;->AES256_GCM:Landroidx/security/crypto/MasterKey$KeyScheme;

    invoke-virtual {v4, v13}, Landroidx/security/crypto/MasterKey$Builder;->setKeyScheme(Landroidx/security/crypto/MasterKey$KeyScheme;)Landroidx/security/crypto/MasterKey$Builder;

    move-result-object v4

    invoke-virtual {v4}, Landroidx/security/crypto/MasterKey$Builder;->build()Landroidx/security/crypto/MasterKey;

    move-result-object v4

    const-string v13, "build(...)"

    invoke-static {v4, v13}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    sget-object v13, Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;->AES256_SIV:Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;

    sget-object v14, Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;->AES256_GCM:Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;

    invoke-static {v0, v2, v4, v13, v14}, Landroidx/security/crypto/EncryptedSharedPreferences;->create(Landroid/content/Context;Ljava/lang/String;Landroidx/security/crypto/MasterKey;Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;)Landroid/content/SharedPreferences;

    move-result-object v2

    const/4 v4, 0x0

    if-nez v2, :cond_0

    const-string v13, "licenseSharedPreferences"

    invoke-static {v13}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v13, v4

    goto :goto_0

    :cond_0
    move-object v13, v2

    :goto_0
    invoke-interface {v13}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v13

    invoke-interface {v13, v9, v10}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    invoke-interface {v13}, Landroid/content/SharedPreferences$Editor;->apply()V

    sget-object v10, Lcom/scanflow/datacapture/barinternal/h;->a:Lcom/scanflow/datacapture/barinternal/h;

    invoke-virtual {v10, v5}, Lcom/scanflow/datacapture/barinternal/h;->a(Landroid/graphics/Bitmap;)Lcom/scanflow/datacapture/model/LowLightResponse;

    move-result-object v10

    sget-object v13, Lcom/scanflow/datacapture/barinternal/t;->a:Lcom/scanflow/datacapture/barinternal/t;

    invoke-virtual {v5}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v14

    invoke-virtual {v5}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v15

    invoke-static {v14, v15, v11, v11, v7}, Lcom/scanflow/datacapture/barinternal/t;->a(IIIII)Landroid/graphics/Matrix;

    move-result-object v11

    if-nez v10, :cond_1

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barcode/b;->a()V

    return-void

    :cond_1
    new-instance v14, Landroid/graphics/Matrix;

    invoke-direct {v14}, Landroid/graphics/Matrix;-><init>()V

    iput-object v14, v1, Lcom/scanflow/datacapture/barcode/b;->m:Landroid/graphics/Matrix;

    invoke-virtual {v11, v14}, Landroid/graphics/Matrix;->invert(Landroid/graphics/Matrix;)Z

    new-instance v11, Ljava/util/ArrayList;

    invoke-direct {v11}, Ljava/util/ArrayList;-><init>()V

    iput-object v11, v1, Lcom/scanflow/datacapture/barcode/b;->l:Ljava/util/ArrayList;

    new-instance v11, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    sget v14, Lcom/scanflow/datacapture/barcode/R$raw;->beep:I

    invoke-static {v14}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v14

    invoke-direct {v11, v0, v14}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;-><init>(Landroid/content/Context;Ljava/lang/Integer;)V

    iput-object v11, v1, Lcom/scanflow/datacapture/barcode/b;->j:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    invoke-virtual {v11, v7}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setVibrate(Z)V

    const/4 v14, 0x1

    invoke-virtual {v11, v14}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setPlayBeep(Z)V

    invoke-virtual {v6}, Ljava/util/concurrent/atomic/AtomicBoolean;->get()Z

    .line 1
    const-string v6, "decodeConfig"

    invoke-static {v3, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    sget-object v6, Lcom/scanflow/datacapture/barinternal/z;->a:[I

    invoke-virtual {v3}, Ljava/lang/Enum;->ordinal()I

    move-result v3

    aget v3, v6, v3

    packed-switch v3, :pswitch_data_0

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;-><init>()V

    throw v0

    :pswitch_0
    const-string v3, "dotmatrix_metal"

    :goto_1
    iput-object v3, v1, Lcom/scanflow/datacapture/barcode/b;->f:Ljava/lang/String;

    iput-boolean v7, v1, Lcom/scanflow/datacapture/barcode/b;->g:Z

    goto :goto_2

    :pswitch_1
    const-string v3, "dotmatrix_white"

    goto :goto_1

    :pswitch_2
    const-string v3, "any"

    iput-object v3, v1, Lcom/scanflow/datacapture/barcode/b;->f:Ljava/lang/String;

    iput-boolean v7, v1, Lcom/scanflow/datacapture/barcode/b;->g:Z

    iput-boolean v14, v1, Lcom/scanflow/datacapture/barcode/b;->i:Z

    goto :goto_2

    :pswitch_3
    const-string v3, "any"

    iput-object v3, v1, Lcom/scanflow/datacapture/barcode/b;->f:Ljava/lang/String;

    iput-boolean v14, v1, Lcom/scanflow/datacapture/barcode/b;->g:Z

    iput-boolean v14, v1, Lcom/scanflow/datacapture/barcode/b;->h:Z

    goto :goto_2

    :pswitch_4
    const-string v3, "any"

    iput-object v3, v1, Lcom/scanflow/datacapture/barcode/b;->f:Ljava/lang/String;

    iput-boolean v14, v1, Lcom/scanflow/datacapture/barcode/b;->g:Z

    iput-boolean v7, v1, Lcom/scanflow/datacapture/barcode/b;->h:Z

    goto :goto_2

    :pswitch_5
    const-string v3, "any"

    goto :goto_1

    :pswitch_6
    const-string v3, "bar_code"

    goto :goto_1

    :pswitch_7
    const-string v3, "qr_code"

    goto :goto_1

    .line 2
    :goto_2
    invoke-static {}, Lcom/google/mediapipe/tasks/core/BaseOptions;->builder()Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;

    move-result-object v3

    const-string v6, "efficientnet-lite0-blur-v1.3.tflite"

    invoke-virtual {v3, v6}, Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;->setModelAssetPath(Ljava/lang/String;)Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;

    move-result-object v3

    invoke-static {v14}, Lcom/scanflow/datacapture/barinternal/c;->a(I)I

    move-result v6

    const/4 v11, 0x2

    if-eq v6, v14, :cond_3

    if-eq v6, v11, :cond_2

    goto :goto_4

    :cond_2
    sget-object v6, Lcom/google/mediapipe/tasks/core/Delegate;->GPU:Lcom/google/mediapipe/tasks/core/Delegate;

    :goto_3
    invoke-virtual {v3, v6}, Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;->setDelegate(Lcom/google/mediapipe/tasks/core/Delegate;)Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;

    goto :goto_5

    :cond_3
    :goto_4
    sget-object v6, Lcom/google/mediapipe/tasks/core/Delegate;->CPU:Lcom/google/mediapipe/tasks/core/Delegate;

    goto :goto_3

    :goto_5
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions;->builder()Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;

    move-result-object v6

    invoke-virtual {v3}, Lcom/google/mediapipe/tasks/core/BaseOptions$Builder;->build()Lcom/google/mediapipe/tasks/core/BaseOptions;

    move-result-object v3

    invoke-virtual {v6, v3}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;->setBaseOptions(Lcom/google/mediapipe/tasks/core/BaseOptions;)Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;

    move-result-object v3

    const/4 v6, 0x3

    invoke-static {v6}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v6

    invoke-virtual {v3, v6}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;->setMaxResults(Ljava/lang/Integer;)Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;

    move-result-object v3

    invoke-virtual {v3}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions$Builder;->build()Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions;

    move-result-object v3

    invoke-static {v0, v3}, Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier;->createFromOptions(Landroid/content/Context;Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier$ImageClassifierOptions;)Lcom/google/mediapipe/tasks/vision/imageclassifier/ImageClassifier;

    const-string v3, "MediaPipeBlurClassifier"

    const-string v6, "Created MediaPipe Image Classifier successfully"

    invoke-static {v3, v6}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 3
    invoke-virtual {v0}, Landroid/content/Context;->getAssets()Landroid/content/res/AssetManager;

    move-result-object v3

    if-eqz v3, :cond_5

    if-nez v2, :cond_4

    const-string v2, "licenseSharedPreferences"

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v2, v4

    :cond_4
    const-string v3, ""

    invoke-interface {v2, v9, v3}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Lcom/scanflow/datacapture/barinternal/m;->a(Landroid/content/Context;Ljava/lang/String;)Ljava/io/File;

    move-result-object v2

    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    .line 4
    new-instance v3, Lcom/scanflow/datacapture/barinternal/N;

    invoke-direct {v3, v0, v2}, Lcom/scanflow/datacapture/barinternal/N;-><init>(Landroid/content/Context;Ljava/io/File;)V

    goto :goto_6

    :cond_5
    move-object v3, v4

    :goto_6
    if-eqz v3, :cond_6

    .line 5
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/N;->a()V

    .line 6
    :cond_6
    iget-object v2, v1, Lcom/scanflow/datacapture/barcode/b;->e:Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;

    if-nez v2, :cond_7

    new-instance v2, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;

    invoke-direct {v2, v14}, Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;-><init>(Z)V

    iput-object v2, v1, Lcom/scanflow/datacapture/barcode/b;->e:Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;

    sget-object v6, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->CPU:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    const/4 v9, 0x4

    invoke-virtual {v2, v0, v12, v6, v9}, Lcom/scanflow/datacapture/core/source/super_resolution/h;->init(Landroid/content/Context;Ljava/lang/String;Lcom/scanflow/datacapture/core/source/super_resolution/Device;I)Z

    :cond_7
    iget-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->f:Ljava/lang/String;

    const-string v2, "dotmatrix_white"

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_20

    iget-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->f:Ljava/lang/String;

    const-string v2, "dotmatrix_metal"

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_8

    goto/16 :goto_11

    :cond_8
    invoke-virtual {v13, v5}, Lcom/scanflow/datacapture/barinternal/t;->c(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v0

    sget-object v2, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    const-string v6, "image resize to 448 - Completed"

    invoke-virtual {v2, v8, v6}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    const-string v6, "448 image to model - Started"

    invoke-virtual {v2, v8, v6}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    monitor-enter p0

    .line 7
    :try_start_0
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    if-eqz v3, :cond_e

    if-nez v0, :cond_9

    goto :goto_8

    :cond_9
    invoke-static {v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v3, v0}, Lcom/scanflow/datacapture/barinternal/N;->a(Landroid/graphics/Bitmap;)Ljava/util/ArrayList;

    move-result-object v3

    invoke-virtual {v3}, Ljava/util/ArrayList;->size()I

    move-result v6

    if-nez v6, :cond_a

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->recycle()V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    goto :goto_9

    :catchall_0
    move-exception v0

    goto/16 :goto_10

    :cond_a
    :try_start_1
    invoke-virtual {v3}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v0

    const-string v3, "iterator(...)"

    invoke-static {v0, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_b
    :goto_7
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_e

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    const-string v6, "next(...)"

    invoke-static {v3, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v3, Lcom/scanflow/datacapture/barinternal/b;

    iget v6, v1, Lcom/scanflow/datacapture/barcode/b;->d:F

    iget-object v8, v1, Lcom/scanflow/datacapture/barcode/b;->f:Ljava/lang/String;

    if-nez v8, :cond_c

    const-string v8, ""

    .line 8
    :cond_c
    const-string v9, "result"

    invoke-static {v3, v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v9, "scanType"

    invoke-static {v8, v9}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 9
    iget v9, v3, Lcom/scanflow/datacapture/barinternal/b;->c:F

    cmpl-float v6, v9, v6

    if-ltz v6, :cond_b

    .line 10
    iget-object v6, v3, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 11
    invoke-static {v6, v8}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v6

    if-nez v6, :cond_d

    iget-object v6, v1, Lcom/scanflow/datacapture/barcode/b;->k:Ljava/lang/String;

    invoke-static {v8, v6}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_b

    .line 12
    :cond_d
    invoke-virtual {v2, v3}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_7

    :cond_e
    :goto_8
    monitor-exit p0

    .line 13
    :goto_9
    invoke-virtual {v2}, Ljava/util/ArrayList;->size()I

    move-result v0

    if-ge v0, v14, :cond_f

    iget-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_1a

    goto/16 :goto_e

    :cond_f
    iget-boolean v0, v1, Lcom/scanflow/datacapture/barcode/b;->g:Z

    if-eqz v0, :cond_16

    invoke-virtual {v2}, Ljava/util/ArrayList;->size()I

    move-result v0

    if-lez v0, :cond_16

    iget-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_10

    invoke-interface {v0, v14}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    :cond_10
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->l:Ljava/util/ArrayList;

    invoke-virtual {v2}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v0

    const-string v2, "iterator(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_11
    :goto_a
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_15

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    const-string v3, "next(...)"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v2, Lcom/scanflow/datacapture/barinternal/b;

    .line 14
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 15
    iget-object v6, v1, Lcom/scanflow/datacapture/barcode/b;->m:Landroid/graphics/Matrix;

    invoke-static {v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v6, v3}, Landroid/graphics/Matrix;->mapRect(Landroid/graphics/RectF;)Z

    .line 16
    const-string v6, "<set-?>"

    invoke-static {v3, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object v3, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 17
    iget-object v3, v1, Lcom/scanflow/datacapture/barcode/b;->o:Ljava/util/LinkedList;

    invoke-virtual {v3, v2}, Ljava/util/LinkedList;->add(Ljava/lang/Object;)Z

    .line 18
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 19
    iget v6, v3, Landroid/graphics/RectF;->left:F

    const/16 v7, 0x19

    int-to-float v7, v7

    sub-float v8, v6, v7

    const/4 v9, 0x0

    cmpg-float v10, v8, v9

    if-gtz v10, :cond_12

    goto :goto_b

    :cond_12
    move v6, v8

    :goto_b
    iget v8, v3, Landroid/graphics/RectF;->top:F

    sub-float v7, v8, v7

    cmpg-float v10, v7, v9

    if-gtz v10, :cond_13

    goto :goto_c

    :cond_13
    move v8, v7

    :goto_c
    cmpl-float v7, v6, v9

    if-lez v7, :cond_14

    cmpl-float v7, v8, v9

    if-lez v7, :cond_14

    :try_start_2
    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    float-to-int v6, v6

    float-to-int v7, v8

    invoke-virtual {v3}, Landroid/graphics/RectF;->width()F

    move-result v8

    float-to-int v8, v8

    add-int/lit8 v8, v8, 0x32

    invoke-virtual {v3}, Landroid/graphics/RectF;->height()F

    move-result v3

    float-to-int v3, v3

    add-int/lit8 v3, v3, 0x32

    invoke-static {v5, v6, v7, v8, v3}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIII)Landroid/graphics/Bitmap;

    move-result-object v3

    goto :goto_d

    :cond_14
    invoke-static {v5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    iget v6, v3, Landroid/graphics/RectF;->left:F

    float-to-int v6, v6

    iget v7, v3, Landroid/graphics/RectF;->top:F

    float-to-int v7, v7

    invoke-virtual {v3}, Landroid/graphics/RectF;->width()F

    move-result v8

    float-to-int v8, v8

    invoke-virtual {v3}, Landroid/graphics/RectF;->height()F

    move-result v3

    float-to-int v3, v3

    invoke-static {v5, v6, v7, v8, v3}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIII)Landroid/graphics/Bitmap;

    move-result-object v3
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_0

    goto :goto_d

    :catch_0
    move-object v3, v4

    :goto_d
    if-eqz v3, :cond_11

    .line 20
    iget-object v6, v1, Lcom/scanflow/datacapture/barcode/b;->l:Ljava/util/ArrayList;

    new-instance v7, Lcom/scanflow/datacapture/barinternal/B;

    .line 21
    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 22
    invoke-direct {v7, v3, v2}, Lcom/scanflow/datacapture/barinternal/B;-><init>(Landroid/graphics/Bitmap;Landroid/graphics/RectF;)V

    invoke-virtual {v6, v7}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto/16 :goto_a

    :cond_15
    iget-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->l:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v0

    if-lez v0, :cond_1a

    new-instance v0, Lcom/scanflow/datacapture/barcode/a;

    invoke-direct {v0, v1, v4}, Lcom/scanflow/datacapture/barcode/a;-><init>(Lcom/scanflow/datacapture/barcode/b;Lkotlin/coroutines/Continuation;)V

    invoke-static {v4, v0, v14, v4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->runBlocking$default(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Ljava/lang/Object;

    goto/16 :goto_14

    :cond_16
    iget-boolean v0, v1, Lcom/scanflow/datacapture/barcode/b;->i:Z

    if-eqz v0, :cond_1b

    .line 23
    invoke-virtual {v2}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v0

    const-string v2, "iterator(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_17
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_18

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    const-string v3, "next(...)"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v2, Lcom/scanflow/datacapture/barinternal/b;

    .line 24
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 25
    iget v5, v1, Lcom/scanflow/datacapture/barcode/b;->c:I

    div-int/2addr v5, v11

    int-to-float v5, v5

    invoke-virtual {v3, v5, v5}, Landroid/graphics/RectF;->contains(FF)Z

    move-result v3

    if-eqz v3, :cond_17

    move-object v4, v2

    :cond_18
    if-eqz v4, :cond_19

    .line 26
    iget-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_1e

    goto :goto_f

    :cond_19
    iget-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_1a

    .line 13
    :goto_e
    invoke-interface {v0, v7}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    :cond_1a
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barcode/b;->a()V

    goto/16 :goto_14

    .line 27
    :cond_1b
    invoke-virtual {v2}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v0

    const-string v2, "iterator(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    :cond_1c
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_1d

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    const-string v3, "next(...)"

    invoke-static {v2, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v2, Lcom/scanflow/datacapture/barinternal/b;

    .line 28
    iget-object v3, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 29
    iget v5, v1, Lcom/scanflow/datacapture/barcode/b;->c:I

    div-int/2addr v5, v11

    int-to-float v5, v5

    invoke-virtual {v3, v5, v5}, Landroid/graphics/RectF;->contains(FF)Z

    move-result v3

    if-eqz v3, :cond_1c

    move-object v4, v2

    :cond_1d
    if-eqz v4, :cond_1f

    .line 30
    iget-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_1e

    .line 26
    :goto_f
    invoke-interface {v0, v14}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    :cond_1e
    invoke-virtual {v1, v4, v10}, Lcom/scanflow/datacapture/barcode/b;->a(Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/model/LowLightResponse;)V

    return-void

    .line 30
    :cond_1f
    iget-object v0, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_23

    invoke-interface {v0, v7}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onScanBarcodeDetection(Z)V

    return-void

    :goto_10
    monitor-exit p0

    throw v0

    :cond_20
    :goto_11
    sget-object v0, Lcom/scanflow/datacapture/barinternal/s;->a:Landroid/graphics/Bitmap;

    invoke-virtual {v10}, Lcom/scanflow/datacapture/model/LowLightResponse;->getBitmap()Landroid/graphics/Bitmap;

    move-result-object v0

    iget-object v2, v1, Lcom/scanflow/datacapture/barcode/b;->f:Ljava/lang/String;

    const-string v3, "dotmatrix_white"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_21

    const-wide v2, 0x406fe00000000000L    # 255.0

    goto :goto_12

    :cond_21
    const-wide v2, 0x4072c00000000000L    # 300.0

    .line 31
    :goto_12
    const-string v4, "bitmapSource"

    invoke-static {v0, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v8, Lorg/opencv/core/Mat;

    invoke-direct {v8}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {v0, v8}, Lorg/opencv/android/Utils;->bitmapToMat(Landroid/graphics/Bitmap;Lorg/opencv/core/Mat;)V

    new-instance v9, Lorg/opencv/core/Mat;

    invoke-direct {v9}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v10, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    invoke-direct {v10, v2, v3, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;-><init>(DD)V

    const-wide/16 v13, 0x0

    const/4 v15, 0x2

    const-wide/16 v11, 0x0

    invoke-static/range {v8 .. v15}, Lorg/opencv/imgproc/Imgproc;->resize(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;DDI)V

    invoke-virtual {v9}, Lorg/opencv/core/Mat;->cols()I

    move-result v0

    invoke-virtual {v9}, Lorg/opencv/core/Mat;->rows()I

    move-result v2

    sget-object v3, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v0, v2, v3}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v0

    const-string v2, "createBitmap(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v9, v0}, Lorg/opencv/android/Utils;->matToBitmap(Lorg/opencv/core/Mat;Landroid/graphics/Bitmap;)V

    if-eqz v0, :cond_23

    .line 32
    iget-object v2, v1, Lcom/scanflow/datacapture/barcode/b;->f:Ljava/lang/String;

    const-string v4, "dotmatrix_white"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_22

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/r;->b(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v2

    goto :goto_13

    :cond_22
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/r;->a(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v2

    :goto_13
    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v4

    int-to-double v4, v4

    const-wide/high16 v8, 0x4010000000000000L    # 4.0

    div-double/2addr v4, v8

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v0

    int-to-double v10, v0

    div-double/2addr v10, v8

    .line 33
    const-string v0, "bitmapSource"

    invoke-static {v2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v12, Lorg/opencv/core/Mat;

    invoke-direct {v12}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {v2, v12}, Lorg/opencv/android/Utils;->bitmapToMat(Landroid/graphics/Bitmap;Lorg/opencv/core/Mat;)V

    new-instance v13, Lorg/opencv/core/Mat;

    invoke-direct {v13}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v14, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    invoke-direct {v14, v4, v5, v10, v11}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;-><init>(DD)V

    const-wide/16 v17, 0x0

    const/16 v19, 0x2

    const-wide/16 v15, 0x0

    invoke-static/range {v12 .. v19}, Lorg/opencv/imgproc/Imgproc;->resize(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;DDI)V

    invoke-virtual {v13}, Lorg/opencv/core/Mat;->cols()I

    move-result v0

    invoke-virtual {v13}, Lorg/opencv/core/Mat;->rows()I

    move-result v2

    invoke-static {v0, v2, v3}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v0

    const-string v2, "createBitmap(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v13, v0}, Lorg/opencv/android/Utils;->matToBitmap(Lorg/opencv/core/Mat;Landroid/graphics/Bitmap;)V

    .line 34
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/t;->b(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v0

    invoke-static {v0, v7}, Lcom/google/mlkit/vision/common/InputImage;->fromBitmap(Landroid/graphics/Bitmap;I)Lcom/google/mlkit/vision/common/InputImage;

    move-result-object v0

    const-string v2, "fromBitmap(...)"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 35
    sget-object v2, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    .line 36
    invoke-interface {v2, v0}, Lcom/google/mlkit/vision/barcode/BarcodeScanner;->process(Lcom/google/mlkit/vision/common/InputImage;)Lcom/google/android/gms/tasks/Task;

    move-result-object v0

    new-instance v2, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda1;

    invoke-direct {v2, v1}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barcode/b;)V

    invoke-virtual {v0, v2}, Lcom/google/android/gms/tasks/Task;->addOnCompleteListener(Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;

    :cond_23
    :goto_14
    return-void

    nop

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

.method public static a(Landroid/graphics/Point;Landroid/graphics/Point;)D
    .locals 2

    .line 2
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

.method public static a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;
    .locals 1

    const/4 v0, 0x1

    if-eq p0, v0, :cond_1

    const/4 v0, 0x2

    if-eq p0, v0, :cond_0

    sparse-switch p0, :sswitch_data_0

    .line 3
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

.method public static final a(Lcom/scanflow/datacapture/barcode/b;Lcom/google/android/gms/tasks/Task;)V
    .locals 10

    .line 1
    const-string v0, "this$0"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "it"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p1}, Lcom/google/android/gms/tasks/Task;->isSuccessful()Z

    move-result v0

    const-string v1, "qrResult"

    if-eqz v0, :cond_3

    invoke-virtual {p1}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    if-lez v0, :cond_3

    invoke-virtual {p1}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/List;

    const/4 v2, 0x0

    invoke-interface {v0, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v0}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_3

    invoke-virtual {p1}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/List;

    invoke-interface {v0, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v0}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {v0}, Ljava/lang/CharSequence;->length()I

    move-result v0

    if-nez v0, :cond_0

    goto :goto_0

    :cond_0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v3, "qrResult ML- "

    invoke-direct {v0, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/List;

    invoke-interface {v3, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v3}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v3, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    invoke-virtual {p1}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/util/List;

    invoke-interface {p1, v2}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {p1}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v4

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v5, Lcom/scanflow/datacapture/utils/BarcodeFormat;->QR_CODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    new-instance v7, Ljava/util/ArrayList;

    invoke-direct {v7}, Ljava/util/ArrayList;-><init>()V

    new-instance v8, Landroid/graphics/RectF;

    invoke-direct {v8}, Landroid/graphics/RectF;-><init>()V

    const/4 v6, 0x1

    const-string v9, "QR_CODE"

    invoke-direct/range {v3 .. v9}, Lcom/scanflow/datacapture/model/ScanResultSuccess;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/barcode/b;->j:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz p1, :cond_1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->playBeepSoundAndVibrate()V

    :cond_1
    iget-object p0, p0, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz p0, :cond_2

    invoke-interface {p0, v3}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V

    :cond_2
    return-void

    :cond_3
    :goto_0
    const-string p1, "qrResult - failed"

    invoke-static {v1, p1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barcode/b;->a()V

    return-void
.end method

.method public static final a(ZLandroid/graphics/Bitmap;Lcom/scanflow/datacapture/barcode/b;Lcom/scanflow/datacapture/barinternal/b;Lcom/google/android/gms/tasks/Task;)V
    .locals 35

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    move-object/from16 v2, p3

    const-string v3, "processModelResultZxing"

    const-string v4, "$croppedBitmap"

    invoke-static {v0, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v4, "this$0"

    invoke-static {v1, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v4, "$result"

    invoke-static {v2, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v4, "it"

    move-object/from16 v5, p4

    invoke-static {v5, v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v5}, Lcom/google/android/gms/tasks/Task;->isSuccessful()Z

    move-result v4

    if-eqz v4, :cond_f

    invoke-virtual {v5}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    invoke-interface {v4}, Ljava/util/List;->size()I

    move-result v4

    if-lez v4, :cond_f

    invoke-virtual {v5}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    const/4 v6, 0x0

    invoke-interface {v4, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v4

    if-eqz v4, :cond_f

    invoke-virtual {v5}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    invoke-interface {v4, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v4

    invoke-static {v4}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {v4}, Ljava/lang/String;->length()I

    move-result v4

    if-nez v4, :cond_0

    goto/16 :goto_c

    :cond_0
    invoke-virtual {v5}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    invoke-interface {v4, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v4}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v4

    new-instance v11, Ljava/util/ArrayList;

    invoke-direct {v11}, Ljava/util/ArrayList;-><init>()V

    const/4 v7, 0x2

    const/4 v8, 0x1

    if-eqz p0, :cond_1

    move v9, v7

    goto :goto_0

    :cond_1
    move v9, v8

    :goto_0
    invoke-virtual {v5}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Ljava/util/List;

    invoke-interface {v10, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v10}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getCornerPoints()[Landroid/graphics/Point;

    move-result-object v10

    if-eqz v10, :cond_2

    new-instance v12, Landroid/graphics/PointF;

    new-instance v13, Landroid/graphics/Point;

    aget-object v14, v10, v6

    iget v15, v14, Landroid/graphics/Point;->x:I

    div-int/2addr v15, v9

    iget v14, v14, Landroid/graphics/Point;->y:I

    div-int/2addr v14, v9

    invoke-direct {v13, v15, v14}, Landroid/graphics/Point;-><init>(II)V

    invoke-direct {v12, v13}, Landroid/graphics/PointF;-><init>(Landroid/graphics/Point;)V

    invoke-virtual {v11, v12}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v12, Landroid/graphics/PointF;

    new-instance v13, Landroid/graphics/Point;

    aget-object v14, v10, v8

    iget v15, v14, Landroid/graphics/Point;->x:I

    div-int/2addr v15, v9

    iget v14, v14, Landroid/graphics/Point;->y:I

    div-int/2addr v14, v9

    invoke-direct {v13, v15, v14}, Landroid/graphics/Point;-><init>(II)V

    invoke-direct {v12, v13}, Landroid/graphics/PointF;-><init>(Landroid/graphics/Point;)V

    invoke-virtual {v11, v12}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v12, Landroid/graphics/PointF;

    new-instance v13, Landroid/graphics/Point;

    aget-object v14, v10, v7

    iget v15, v14, Landroid/graphics/Point;->x:I

    div-int/2addr v15, v9

    iget v14, v14, Landroid/graphics/Point;->y:I

    div-int/2addr v14, v9

    invoke-direct {v13, v15, v14}, Landroid/graphics/Point;-><init>(II)V

    invoke-direct {v12, v13}, Landroid/graphics/PointF;-><init>(Landroid/graphics/Point;)V

    invoke-virtual {v11, v12}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v12, Landroid/graphics/PointF;

    new-instance v13, Landroid/graphics/Point;

    const/4 v14, 0x3

    aget-object v10, v10, v14

    iget v14, v10, Landroid/graphics/Point;->x:I

    div-int/2addr v14, v9

    iget v10, v10, Landroid/graphics/Point;->y:I

    div-int/2addr v10, v9

    invoke-direct {v13, v14, v10}, Landroid/graphics/Point;-><init>(II)V

    invoke-direct {v12, v13}, Landroid/graphics/PointF;-><init>(Landroid/graphics/Point;)V

    invoke-virtual {v11, v12}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    :cond_2
    invoke-virtual {v5}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Ljava/util/List;

    invoke-interface {v10, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v10}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getCornerPoints()[Landroid/graphics/Point;

    move-result-object v10

    const-string v12, "SFBarcode"

    if-eqz v10, :cond_4

    aget-object v13, v10, v6

    iget v14, v13, Landroid/graphics/Point;->x:I

    int-to-double v14, v14

    iget v13, v13, Landroid/graphics/Point;->y:I

    move/from16 v16, v8

    move/from16 v17, v9

    int-to-double v8, v13

    aget-object v13, v10, v16

    move/from16 v18, v6

    iget v6, v13, Landroid/graphics/Point;->x:I

    move-wide/from16 v20, v8

    int-to-double v7, v6

    iget v6, v13, Landroid/graphics/Point;->y:I

    move v9, v4

    int-to-double v4, v6

    invoke-virtual {v1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    sub-double/2addr v7, v14

    const/4 v6, 0x2

    int-to-double v13, v6

    .line 6
    invoke-static {v7, v8, v13, v14}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v7

    sub-double v4, v4, v20

    invoke-static {v4, v5, v13, v14}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v4

    add-double/2addr v4, v7

    invoke-static {v4, v5}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v4

    .line 7
    aget-object v7, v10, v16

    iget v8, v7, Landroid/graphics/Point;->x:I

    move v15, v9

    int-to-double v8, v8

    iget v7, v7, Landroid/graphics/Point;->y:I

    move/from16 v19, v6

    int-to-double v6, v7

    move-wide/from16 v20, v6

    aget-object v6, v10, v19

    iget v7, v6, Landroid/graphics/Point;->x:I

    move-wide/from16 v22, v8

    int-to-double v7, v7

    iget v6, v6, Landroid/graphics/Point;->y:I

    move-wide/from16 v24, v7

    int-to-double v6, v6

    sub-double v8, v24, v22

    .line 8
    invoke-static {v8, v9, v13, v14}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v8

    sub-double v6, v6, v20

    invoke-static {v6, v7, v13, v14}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v6

    add-double/2addr v6, v8

    invoke-static {v6, v7}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v6

    .line 9
    new-instance v8, Ljava/lang/StringBuilder;

    const-string v9, "Calculate Distance - "

    invoke-direct {v8, v9}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v8, v4, v5}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const/16 v9, 0x20

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v6, v7}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-static {v12, v8}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    cmpl-double v4, v4, v6

    if-lez v4, :cond_3

    new-instance v4, Landroid/graphics/Point;

    aget-object v5, v10, v18

    iget v6, v5, Landroid/graphics/Point;->x:I

    div-int v6, v6, v17

    iget v5, v5, Landroid/graphics/Point;->y:I

    div-int v5, v5, v17

    invoke-direct {v4, v6, v5}, Landroid/graphics/Point;-><init>(II)V

    new-instance v5, Landroid/graphics/Point;

    aget-object v6, v10, v16

    iget v7, v6, Landroid/graphics/Point;->x:I

    div-int v7, v7, v17

    iget v6, v6, Landroid/graphics/Point;->y:I

    div-int v6, v6, v17

    invoke-direct {v5, v7, v6}, Landroid/graphics/Point;-><init>(II)V

    :goto_1
    invoke-static {v4, v5}, Lcom/scanflow/datacapture/barcode/b;->a(Landroid/graphics/Point;Landroid/graphics/Point;)D

    move-result-wide v4

    goto :goto_2

    :cond_3
    new-instance v4, Landroid/graphics/Point;

    aget-object v5, v10, v16

    iget v6, v5, Landroid/graphics/Point;->x:I

    div-int v6, v6, v17

    iget v5, v5, Landroid/graphics/Point;->y:I

    div-int v5, v5, v17

    invoke-direct {v4, v6, v5}, Landroid/graphics/Point;-><init>(II)V

    new-instance v5, Landroid/graphics/Point;

    const/16 v19, 0x2

    aget-object v6, v10, v19

    iget v7, v6, Landroid/graphics/Point;->x:I

    div-int v7, v7, v17

    iget v6, v6, Landroid/graphics/Point;->y:I

    div-int v6, v6, v17

    invoke-direct {v5, v7, v6}, Landroid/graphics/Point;-><init>(II)V

    goto :goto_1

    :cond_4
    move v15, v4

    move/from16 v18, v6

    move/from16 v16, v8

    const-wide/16 v4, 0x0

    .line 10
    :goto_2
    const-string v6, "croppedBitmap"

    invoke-static {v0, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v7

    add-int/lit8 v7, v7, 0x32

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v8

    add-int/lit8 v8, v8, 0x32

    sget-object v9, Landroid/graphics/Bitmap$Config;->ARGB_8888:Landroid/graphics/Bitmap$Config;

    invoke-static {v7, v8, v9}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object v7

    const-string v8, "createBitmap(...)"

    invoke-static {v7, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v9, Landroid/graphics/Canvas;

    invoke-direct {v9, v7}, Landroid/graphics/Canvas;-><init>(Landroid/graphics/Bitmap;)V

    sget-object v10, Landroid/graphics/PorterDuff$Mode;->LIGHTEN:Landroid/graphics/PorterDuff$Mode;

    const/4 v13, -0x1

    invoke-virtual {v9, v13, v10}, Landroid/graphics/Canvas;->drawColor(ILandroid/graphics/PorterDuff$Mode;)V

    new-instance v10, Landroid/graphics/Paint;

    invoke-direct {v10}, Landroid/graphics/Paint;-><init>()V

    move/from16 v13, v16

    invoke-virtual {v10, v13}, Landroid/graphics/Paint;->setAntiAlias(Z)V

    invoke-virtual {v10, v13}, Landroid/graphics/Paint;->setFilterBitmap(Z)V

    invoke-virtual {v10, v13}, Landroid/graphics/Paint;->setDither(Z)V

    const/16 v14, 0x19

    int-to-float v14, v14

    invoke-virtual {v9, v0, v14, v14, v10}, Landroid/graphics/Canvas;->drawBitmap(Landroid/graphics/Bitmap;FFLandroid/graphics/Paint;)V

    double-to-float v4, v4

    .line 11
    invoke-static {v7, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v5, Landroid/graphics/Matrix;

    invoke-direct {v5}, Landroid/graphics/Matrix;-><init>()V

    invoke-virtual {v5, v4}, Landroid/graphics/Matrix;->postRotate(F)Z

    invoke-virtual {v7}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v4

    invoke-virtual {v7}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v6

    invoke-static {v7, v4, v6, v13}, Landroid/graphics/Bitmap;->createScaledBitmap(Landroid/graphics/Bitmap;IIZ)Landroid/graphics/Bitmap;

    move-result-object v4

    const-string v6, "createScaledBitmap(...)"

    invoke-static {v4, v6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v23

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v24

    const/16 v22, 0x0

    const/16 v26, 0x1

    const/16 v21, 0x0

    move-object/from16 v20, v4

    move-object/from16 v25, v5

    invoke-static/range {v20 .. v26}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIIILandroid/graphics/Matrix;Z)Landroid/graphics/Bitmap;

    move-result-object v4

    invoke-static {v4, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 12
    invoke-virtual/range {p4 .. p4}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/util/List;

    move/from16 v6, v18

    invoke-interface {v5, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v5}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getFormat()I

    move-result v5

    const/4 v6, 0x2

    if-ne v5, v6, :cond_9

    sget-object v5, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    const-string v5, "decodeZxing - Started"

    invoke-static {v12, v5}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v5, Ljava/util/ArrayList;

    invoke-direct {v5}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v5

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v6

    mul-int/2addr v6, v5

    new-array v5, v6, [I

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v30

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v33

    invoke-virtual {v4}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v34

    const/16 v31, 0x0

    const/16 v32, 0x0

    const/16 v29, 0x0

    move-object/from16 v27, v4

    move-object/from16 v28, v5

    invoke-virtual/range {v27 .. v34}, Landroid/graphics/Bitmap;->getPixels([IIIIIII)V

    move-object/from16 v4, v28

    new-instance v5, Lcom/google/zxing/RGBLuminanceSource;

    invoke-virtual/range {v27 .. v27}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v6

    invoke-virtual/range {v27 .. v27}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v7

    invoke-direct {v5, v6, v7, v4}, Lcom/google/zxing/RGBLuminanceSource;-><init>(II[I)V

    new-instance v4, Lcom/google/zxing/common/HybridBinarizer;

    invoke-direct {v4, v5}, Lcom/google/zxing/common/HybridBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    new-instance v6, Lcom/google/zxing/MultiFormatReader;

    invoke-direct {v6}, Lcom/google/zxing/MultiFormatReader;-><init>()V

    new-instance v7, Ljava/util/HashMap;

    invoke-direct {v7}, Ljava/util/HashMap;-><init>()V

    sget-object v8, Lcom/google/zxing/DecodeHintType;->PURE_BARCODE:Lcom/google/zxing/DecodeHintType;

    sget-object v9, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    invoke-virtual {v7, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {v6, v7}, Lcom/google/zxing/MultiFormatReader;->setHints(Ljava/util/Map;)V

    :try_start_0
    new-instance v8, Lcom/google/zxing/BinaryBitmap;

    invoke-direct {v8, v4}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v6, v8, v7}, Lcom/google/zxing/MultiFormatReader;->decode(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;

    move-result-object v4

    if-nez v4, :cond_5

    new-instance v4, Lcom/google/zxing/BinaryBitmap;

    new-instance v8, Lcom/google/zxing/common/GlobalHistogramBinarizer;

    invoke-direct {v8, v5}, Lcom/google/zxing/common/GlobalHistogramBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    invoke-direct {v4, v8}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v6, v4, v7}, Lcom/google/zxing/MultiFormatReader;->decode(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;

    move-result-object v4
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_3

    :catchall_0
    move-exception v0

    goto/16 :goto_9

    :cond_5
    :goto_3
    invoke-virtual {v6}, Lcom/google/zxing/MultiFormatReader;->reset()V

    if-nez v4, :cond_7

    invoke-virtual {v5}, Lcom/google/zxing/LuminanceSource;->invert()Lcom/google/zxing/LuminanceSource;

    move-result-object v4

    :try_start_1
    new-instance v5, Lcom/google/zxing/common/HybridBinarizer;

    invoke-direct {v5, v4}, Lcom/google/zxing/common/HybridBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    new-instance v7, Lcom/google/zxing/BinaryBitmap;

    invoke-direct {v7, v5}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v6, v7}, Lcom/google/zxing/MultiFormatReader;->decodeWithState(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;

    move-result-object v5

    if-nez v5, :cond_6

    new-instance v5, Lcom/google/zxing/BinaryBitmap;

    new-instance v7, Lcom/google/zxing/common/GlobalHistogramBinarizer;

    invoke-direct {v7, v4}, Lcom/google/zxing/common/GlobalHistogramBinarizer;-><init>(Lcom/google/zxing/LuminanceSource;)V

    invoke-direct {v5, v7}, Lcom/google/zxing/BinaryBitmap;-><init>(Lcom/google/zxing/Binarizer;)V

    invoke-virtual {v6, v5}, Lcom/google/zxing/MultiFormatReader;->decodeWithState(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;

    move-result-object v4

    goto :goto_4

    :catchall_1
    move-exception v0

    goto :goto_5

    :cond_6
    move-object v4, v5

    :goto_4
    const-string v5, "White_points_inverted"

    invoke-virtual {v4}, Lcom/google/zxing/Result;->getResultPoints()[Lcom/google/zxing/ResultPoint;

    move-result-object v7

    const/16 v18, 0x0

    aget-object v7, v7, v18

    invoke-virtual {v7}, Lcom/google/zxing/ResultPoint;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v5, v7}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    invoke-virtual {v6}, Lcom/google/zxing/MultiFormatReader;->reset()V

    goto :goto_6

    :catch_0
    :try_start_2
    const-string v4, "Exception - 1"

    invoke-static {v3, v4}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_1

    goto :goto_8

    :goto_5
    invoke-virtual {v6}, Lcom/google/zxing/MultiFormatReader;->reset()V

    throw v0

    :cond_7
    :goto_6
    invoke-virtual {v4}, Lcom/google/zxing/Result;->getText()Ljava/lang/String;

    move-result-object v5

    if-eqz v5, :cond_8

    const-string v6, "decodeZxing - "

    invoke-virtual {v6, v5}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    invoke-static {v3, v5}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    :cond_8
    const-string v3, "decodeZxing - Completed"

    invoke-static {v12, v3}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {v4}, Lcom/google/zxing/Result;->getText()Ljava/lang/String;

    move-result-object v3

    :goto_7
    move-object v8, v3

    goto :goto_a

    :catch_1
    :try_start_3
    const-string v4, "Exception - 0"

    invoke-static {v3, v4}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    :goto_8
    invoke-virtual {v6}, Lcom/google/zxing/MultiFormatReader;->reset()V

    const/4 v3, 0x0

    goto :goto_7

    :goto_9
    invoke-virtual {v6}, Lcom/google/zxing/MultiFormatReader;->reset()V

    throw v0

    :cond_9
    invoke-virtual/range {p4 .. p4}, Lcom/google/android/gms/tasks/Task;->getResult()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/util/List;

    const/4 v6, 0x0

    invoke-interface {v3, v6}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/mlkit/vision/barcode/common/Barcode;

    invoke-virtual {v3}, Lcom/google/mlkit/vision/barcode/common/Barcode;->getDisplayValue()Ljava/lang/String;

    move-result-object v3

    goto :goto_7

    :goto_a
    if-eqz v8, :cond_f

    new-instance v7, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    invoke-virtual {v1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    invoke-static {v15}, Lcom/scanflow/datacapture/barcode/b;->a(I)Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v9

    .line 13
    iget-object v12, v2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 14
    iget-object v13, v2, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    move/from16 v10, p0

    .line 15
    invoke-direct/range {v7 .. v13}, Lcom/scanflow/datacapture/model/ScanResultSuccess;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V

    iget-boolean v3, v1, Lcom/scanflow/datacapture/barcode/b;->g:Z

    if-eqz v3, :cond_a

    iget-boolean v4, v1, Lcom/scanflow/datacapture/barcode/b;->h:Z

    if-nez v4, :cond_a

    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    invoke-virtual {v3, v7}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    iget-object v4, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v4, :cond_d

    invoke-interface {v4, v3}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onBatchScanResultSuccess(Ljava/util/ArrayList;)V

    goto :goto_b

    :cond_a
    if-eqz v3, :cond_c

    iget-boolean v3, v1, Lcom/scanflow/datacapture/barcode/b;->h:Z

    if-eqz v3, :cond_c

    new-instance v3, Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;

    invoke-virtual {v7}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getText()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v7}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->getBarcodeFormat()Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object v5

    invoke-direct {v3, v4, v5}, Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v4, v1, Lcom/scanflow/datacapture/barcode/b;->p:Ljava/util/HashSet;

    invoke-virtual {v4, v3}, Ljava/util/HashSet;->add(Ljava/lang/Object;)Z

    iget-object v4, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v4, :cond_b

    iget-object v5, v1, Lcom/scanflow/datacapture/barcode/b;->p:Ljava/util/HashSet;

    invoke-interface {v4, v5}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onOneOfManyCodeResult(Ljava/util/HashSet;)V

    :cond_b
    iget-object v4, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v4, :cond_d

    invoke-interface {v4, v3}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onOneofManyCodeSelected(Lcom/scanflow/datacapture/model/OneOFManyCodesScanResults;)V

    goto :goto_b

    :cond_c
    iget-object v3, v1, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v3, :cond_d

    invoke-interface {v3, v7}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V

    :cond_d
    :goto_b
    iget-object v3, v1, Lcom/scanflow/datacapture/barcode/b;->j:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz v3, :cond_e

    invoke-virtual {v3}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->playBeepSoundAndVibrate()V

    :cond_e
    iget-object v1, v1, Lcom/scanflow/datacapture/barcode/b;->o:Ljava/util/LinkedList;

    invoke-virtual {v1, v2}, Ljava/util/LinkedList;->add(Ljava/lang/Object;)Z

    invoke-virtual {v0}, Landroid/graphics/Bitmap;->recycle()V

    goto :goto_d

    :cond_f
    :goto_c
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barcode/b;->a()V

    :goto_d
    return-void
.end method


# virtual methods
.method public final a()V
    .locals 2

    .line 27
    iget-object v0, p0, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz v0, :cond_0

    const-string v1, "Scan Failed!"

    invoke-interface {v0, v1}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onScanResultFailure(Ljava/lang/String;)V

    :cond_0
    return-void
.end method

.method public final a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/barinternal/y;ZIZ)V
    .locals 7

    sget-object p3, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    .line 16
    iget-object v6, p2, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 17
    iget-object v5, p2, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 18
    new-instance p3, Ljava/util/ArrayList;

    invoke-direct {p3}, Ljava/util/ArrayList;-><init>()V

    const/4 p3, 0x0

    invoke-static {p1, p3, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/android/ConvertBitmap;->bitmapToGray(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I8;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move-result-object p5

    const-string p6, "bitmapToGray(...)"

    invoke-static {p5, p6}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance p6, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;

    invoke-direct {p6}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;-><init>()V

    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {p6, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/FactoryFiducial;->qrcode(Lcom/scanflow/datacapture/barinternal/boofcv/factory/fiducial/ConfigQrCode;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodePreciseDetector;

    move-result-object p6

    const-string v0, "qrcode(...)"

    invoke-static {p6, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-interface {p6, p5}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodeDetector;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)V

    invoke-interface {p6}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/fiducial/QrCodeDetector;->getDetections()Ljava/util/List;

    move-result-object p5

    invoke-interface {p5}, Ljava/util/List;->size()I

    move-result p6

    if-lez p6, :cond_0

    const/4 p3, 0x0

    invoke-interface {p5, p3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p6

    check-cast p6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    iget-object v1, p6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->message:Ljava/lang/String;

    invoke-interface {p5, p3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p5

    check-cast p5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    iget-object p5, p5, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bounds:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    new-instance v4, Ljava/util/ArrayList;

    invoke-direct {v4}, Ljava/util/ArrayList;-><init>()V

    new-instance p6, Landroid/graphics/PointF;

    invoke-virtual {p5, p3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    double-to-float v0, v2

    invoke-virtual {p5, p3}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p3

    iget-wide v2, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    double-to-float p3, v2

    invoke-direct {p6, v0, p3}, Landroid/graphics/PointF;-><init>(FF)V

    invoke-virtual {v4, p6}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance p3, Landroid/graphics/PointF;

    const/4 p6, 0x1

    invoke-virtual {p5, p6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    double-to-float v0, v2

    invoke-virtual {p5, p6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p6

    iget-wide v2, p6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    double-to-float p6, v2

    invoke-direct {p3, v0, p6}, Landroid/graphics/PointF;-><init>(FF)V

    invoke-virtual {v4, p3}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance p3, Landroid/graphics/PointF;

    const/4 p6, 0x2

    invoke-virtual {p5, p6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    double-to-float v0, v2

    invoke-virtual {p5, p6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p6

    iget-wide v2, p6, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    double-to-float p6, v2

    invoke-direct {p3, v0, p6}, Landroid/graphics/PointF;-><init>(FF)V

    invoke-virtual {v4, p3}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance p3, Landroid/graphics/PointF;

    const/4 p6, 0x3

    invoke-virtual {p5, p6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v0

    iget-wide v2, v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->x:D

    double-to-float v0, v2

    invoke-virtual {p5, p6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object p5

    iget-wide p5, p5, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->y:D

    double-to-float p5, p5

    invoke-direct {p3, v0, p5}, Landroid/graphics/PointF;-><init>(FF)V

    invoke-virtual {v4, p3}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    new-instance v0, Lcom/scanflow/datacapture/model/ScanResultSuccess;

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    sget-object v2, Lcom/scanflow/datacapture/utils/BarcodeFormat;->QR_CODE:Lcom/scanflow/datacapture/utils/BarcodeFormat;

    move v3, p4

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/model/ScanResultSuccess;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/utils/BarcodeFormat;ZLjava/util/ArrayList;Landroid/graphics/RectF;Ljava/lang/String;)V

    move-object p3, v0

    goto :goto_0

    :cond_0
    move v3, p4

    :goto_0
    if-eqz p3, :cond_3

    iget-object p4, p0, Lcom/scanflow/datacapture/barcode/b;->j:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    if-eqz p4, :cond_1

    invoke-virtual {p4}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->playBeepSoundAndVibrate()V

    :cond_1
    iget-object p4, p0, Lcom/scanflow/datacapture/barcode/b;->o:Ljava/util/LinkedList;

    invoke-virtual {p4, p2}, Ljava/util/LinkedList;->add(Ljava/lang/Object;)Z

    sget-object p2, Lcom/scanflow/datacapture/barinternal/y;->a:Lcom/scanflow/datacapture/barinternal/y;

    invoke-virtual {p1}, Landroid/graphics/Bitmap;->recycle()V

    iget-object p1, p0, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    if-eqz p1, :cond_2

    invoke-interface {p1, p3}, Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;->onScanResultSuccess(Lcom/scanflow/datacapture/model/ScanResultSuccess;)V

    :cond_2
    return-void

    :cond_3
    invoke-virtual {p0, p1, p2, v3}, Lcom/scanflow/datacapture/barcode/b;->a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;Z)V

    return-void
.end method

.method public final a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;Z)V
    .locals 2

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/t;->a(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;

    move-result-object v0

    const/4 v1, 0x0

    invoke-static {v0, v1}, Lcom/google/mlkit/vision/common/InputImage;->fromBitmap(Landroid/graphics/Bitmap;I)Lcom/google/mlkit/vision/common/InputImage;

    move-result-object v0

    const-string v1, "fromBitmap(...)"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 4
    sget-object v1, Lcom/scanflow/datacapture/barinternal/l;->a:Lcom/google/mlkit/vision/barcode/BarcodeScanner;

    .line 5
    invoke-interface {v1, v0}, Lcom/google/mlkit/vision/barcode/BarcodeScanner;->process(Lcom/google/mlkit/vision/common/InputImage;)Lcom/google/android/gms/tasks/Task;

    move-result-object v0

    new-instance v1, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;

    invoke-direct {v1, p3, p1, p0, p2}, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;-><init>(ZLandroid/graphics/Bitmap;Lcom/scanflow/datacapture/barcode/b;Lcom/scanflow/datacapture/barinternal/b;)V

    invoke-virtual {v0, v1}, Lcom/google/android/gms/tasks/Task;->addOnCompleteListener(Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;

    return-void
.end method

.method public final a(Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/model/LowLightResponse;)V
    .locals 9

    iget-object v0, p0, Lcom/scanflow/datacapture/barcode/b;->m:Landroid/graphics/Matrix;

    if-eqz v0, :cond_0

    .line 19
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/b;->d:Landroid/graphics/RectF;

    .line 20
    invoke-virtual {v0, v1}, Landroid/graphics/Matrix;->mapRect(Landroid/graphics/RectF;)Z

    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barcode/b;->b:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "Result Location: "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v2, ".location"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    invoke-virtual {p2}, Lcom/scanflow/datacapture/model/LowLightResponse;->getBitmap()Landroid/graphics/Bitmap;

    move-result-object v3

    if-eqz v3, :cond_2

    .line 21
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/b;->b:Ljava/lang/String;

    .line 22
    const-string v1, "qr_code"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    const-string v1, "IsLongDistanceImage: false"

    if-eqz v0, :cond_1

    sget-object v5, Lcom/scanflow/datacapture/barinternal/y;->a:Lcom/scanflow/datacapture/barinternal/y;

    .line 23
    sget-object v0, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    iget-object v2, p0, Lcom/scanflow/datacapture/barcode/b;->b:Ljava/lang/String;

    invoke-virtual {v0, v2, v1}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    .line 24
    iget-object v1, p0, Lcom/scanflow/datacapture/barcode/b;->b:Ljava/lang/String;

    const-string v2, "Is Long Distance Image : false"

    invoke-virtual {v0, v1, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    const/4 v7, 0x1

    invoke-virtual {p2}, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight()Z

    move-result v8

    const/4 v6, 0x0

    move-object v2, p0

    move-object v4, p1

    invoke-virtual/range {v2 .. v8}, Lcom/scanflow/datacapture/barcode/b;->a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;Lcom/scanflow/datacapture/barinternal/y;ZIZ)V

    return-void

    :cond_1
    move-object v2, p0

    move-object v4, p1

    sget-object p1, Lcom/scanflow/datacapture/barinternal/y;->a:Lcom/scanflow/datacapture/barinternal/y;

    .line 25
    sget-object p1, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    iget-object v0, v2, Lcom/scanflow/datacapture/barcode/b;->b:Ljava/lang/String;

    invoke-virtual {p1, v0, v1}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V

    .line 26
    invoke-virtual {p2}, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight()Z

    const/4 p1, 0x0

    invoke-virtual {p0, v3, v4, p1}, Lcom/scanflow/datacapture/barcode/b;->a(Landroid/graphics/Bitmap;Lcom/scanflow/datacapture/barinternal/b;Z)V

    return-void

    :cond_2
    move-object v2, p0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barcode/b;->a()V

    return-void
.end method

.method public final setOnBarcodeScanResultCallback(Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;)Lcom/scanflow/datacapture/barcode/SFBarcodeReader;
    .locals 1

    .line 0
    const-string v0, "callback"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barcode/b;->a:Lcom/scanflow/datacapture/barcode/SFBarcodeReader$OnBarcodeScanResultCallback;

    return-object p0
.end method
