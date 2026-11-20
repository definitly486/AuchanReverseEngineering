.class public final Lcom/scanflow/datacapture/barinternal/b/a;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lcom/scanflow/datacapture/core/camera/analyze/Analyzer;


# instance fields
.field public final a:I

.field public final b:I

.field public final c:Landroidx/lifecycle/MutableLiveData;

.field public final d:Lcom/scanflow/datacapture/sfcamera/SFCameraView;

.field public final e:Landroid/app/Activity;

.field public f:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;

.field public g:Z

.field public h:Z

.field public i:Z

.field public final j:Ljava/util/concurrent/atomic/AtomicBoolean;

.field public final k:Landroid/content/SharedPreferences;

.field public final l:Ljava/lang/String;

.field public final m:Ljava/lang/String;

.field public n:Z


# direct methods
.method public constructor <init>(Landroid/app/Activity;Lcom/scanflow/datacapture/sfcamera/SFCameraView;Ljava/lang/String;)V
    .locals 12

    .line 1
    const-string v0, "mActivity"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sfCameraView"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "SCANFLOW_LICENSE_KEY"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x5

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/b/a;->a:I

    const/16 v1, 0x5a

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->b:I

    new-instance v2, Landroidx/lifecycle/MutableLiveData;

    invoke-direct {v2}, Landroidx/lifecycle/MutableLiveData;-><init>()V

    new-instance v3, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    invoke-direct {v3, v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    invoke-virtual {v2, v3}, Landroidx/lifecycle/MutableLiveData;->setValue(Ljava/lang/Object;)V

    iput-object v2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->c:Landroidx/lifecycle/MutableLiveData;

    new-instance v0, Landroid/util/Size;

    const/16 v1, 0x438

    const/16 v2, 0x780

    invoke-direct {v0, v1, v2}, Landroid/util/Size;-><init>(II)V

    invoke-static {}, Ljava/util/concurrent/Executors;->newSingleThreadExecutor()Ljava/util/concurrent/ExecutorService;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/b/a;->h:Z

    const-string v1, "#2256DE"

    invoke-static {v1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    const-string v1, "#FF543E"

    invoke-static {v1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    const-string v1, "#FFAF4D"

    invoke-static {v1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    const-string v1, "#3098F1"

    invoke-static {v1}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    new-instance v1, Ljava/util/concurrent/atomic/AtomicBoolean;

    const/4 v2, 0x0

    invoke-direct {v1, v2}, Ljava/util/concurrent/atomic/AtomicBoolean;-><init>(Z)V

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->j:Ljava/util/concurrent/atomic/AtomicBoolean;

    const-string v1, "SECRET_KEY_PREF_NAME"

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->l:Ljava/lang/String;

    const-string v1, "SALTVALUE_PREF_NAME"

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->m:Ljava/lang/String;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    new-instance v3, Lcom/scanflow/datacapture/barinternal/b/a$a;

    invoke-direct {v3, v1}, Lcom/scanflow/datacapture/barinternal/b/a$a;-><init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;)V

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->d:Lcom/scanflow/datacapture/sfcamera/SFCameraView;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->e:Landroid/app/Activity;

    new-instance v1, Landroidx/security/crypto/MasterKey$Builder;

    const-string v3, "_androidx_security_master_key_"

    invoke-direct {v1, p1, v3}, Landroidx/security/crypto/MasterKey$Builder;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    sget-object v3, Landroidx/security/crypto/MasterKey$KeyScheme;->AES256_GCM:Landroidx/security/crypto/MasterKey$KeyScheme;

    invoke-virtual {v1, v3}, Landroidx/security/crypto/MasterKey$Builder;->setKeyScheme(Landroidx/security/crypto/MasterKey$KeyScheme;)Landroidx/security/crypto/MasterKey$Builder;

    move-result-object v1

    invoke-virtual {v1}, Landroidx/security/crypto/MasterKey$Builder;->build()Landroidx/security/crypto/MasterKey;

    move-result-object v1

    const/4 v3, 0x0

    if-nez v1, :cond_0

    const-string v1, "masterKey"

    invoke-static {v1}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v1, v3

    :cond_0
    sget-object v4, Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;->AES256_SIV:Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;

    sget-object v5, Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;->AES256_GCM:Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;

    invoke-static {p1, p3, v1, v4, v5}, Landroidx/security/crypto/EncryptedSharedPreferences;->create(Landroid/content/Context;Ljava/lang/String;Landroidx/security/crypto/MasterKey;Landroidx/security/crypto/EncryptedSharedPreferences$PrefKeyEncryptionScheme;Landroidx/security/crypto/EncryptedSharedPreferences$PrefValueEncryptionScheme;)Landroid/content/SharedPreferences;

    move-result-object p3

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/b/a;->k:Landroid/content/SharedPreferences;

    if-nez p3, :cond_1

    const-string p3, "licenseSharedPreferences"

    invoke-static {p3}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    goto :goto_0

    :cond_1
    move-object v3, p3

    :goto_0
    invoke-interface {v3}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object p3

    const-string v1, "MODEL_FILE_KEY_PREF_NAME"

    const-string v3, "WN*J8yH19c9szb9#"

    invoke-interface {p3, v1, v3}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    invoke-interface {p3}, Landroid/content/SharedPreferences$Editor;->apply()V

    invoke-virtual {p2}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->isBorderCornersRounded()Ljava/lang/Boolean;

    move-result-object p3

    invoke-virtual {p3}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v11

    invoke-virtual {p2}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopLeftColor()Ljava/lang/Integer;

    move-result-object p3

    invoke-virtual {p3}, Ljava/lang/Integer;->intValue()I

    move-result v7

    invoke-virtual {p2}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mTopRightColor()Ljava/lang/Integer;

    move-result-object p3

    invoke-virtual {p3}, Ljava/lang/Integer;->intValue()I

    move-result v8

    invoke-virtual {p2}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomLeftColor()Ljava/lang/Integer;

    move-result-object p3

    invoke-virtual {p3}, Ljava/lang/Integer;->intValue()I

    move-result v9

    invoke-virtual {p2}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->mBottomRightColor()Ljava/lang/Integer;

    move-result-object p3

    invoke-virtual {p3}, Ljava/lang/Integer;->intValue()I

    move-result v10

    sget-object p3, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    invoke-virtual {p3, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->enable(Z)V

    invoke-virtual {p2}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureHeightPercentage()Ljava/lang/Integer;

    move-result-object p3

    const/16 v1, 0x64

    if-nez p3, :cond_2

    goto :goto_1

    :cond_2
    invoke-virtual {p3}, Ljava/lang/Integer;->intValue()I

    move-result p3

    if-eq p3, v1, :cond_4

    :goto_1
    invoke-virtual {p2}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureWidthPercentage()Ljava/lang/Integer;

    move-result-object p3

    if-nez p3, :cond_3

    goto :goto_2

    :cond_3
    invoke-virtual {p3}, Ljava/lang/Integer;->intValue()I

    move-result p3

    if-eq p3, v1, :cond_4

    :goto_2
    invoke-virtual {p2}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureHeightPercentage()Ljava/lang/Integer;

    move-result-object p3

    invoke-virtual {p3}, Ljava/lang/Integer;->intValue()I

    move-result v1

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->b:I

    invoke-virtual {p2}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->textCaptureWidthPercentage()Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Integer;->intValue()I

    move-result v3

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/b/a;->a:I

    new-instance v3, Landroidx/lifecycle/MutableLiveData;

    invoke-direct {v3}, Landroidx/lifecycle/MutableLiveData;-><init>()V

    new-instance v4, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-direct {v4, p3, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    invoke-virtual {v3, v4}, Landroidx/lifecycle/MutableLiveData;->setValue(Ljava/lang/Object;)V

    iput-object v3, p0, Lcom/scanflow/datacapture/barinternal/b/a;->c:Landroidx/lifecycle/MutableLiveData;

    :cond_4
    sget-object v3, Lcom/scanflow/datacapture/sfcamera/SFTextOverlay;->INSTANCE:Lcom/scanflow/datacapture/sfcamera/SFTextOverlay;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->getSurfaceView()Landroid/view/SurfaceView;

    move-result-object v4

    const-string p2, "getSurfaceView(...)"

    invoke-static {v4, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iget v5, p0, Lcom/scanflow/datacapture/barinternal/b/a;->b:I

    iget v6, p0, Lcom/scanflow/datacapture/barinternal/b/a;->a:I

    invoke-virtual/range {v3 .. v11}, Lcom/scanflow/datacapture/sfcamera/SFTextOverlay;->setTextCaptureOverlay(Landroid/view/SurfaceView;IIIIIIZ)V

    new-instance p2, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    sget p3, Lcom/scanflow/datacapture/R$raw;->beep:I

    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    invoke-direct {p2, p1, p3}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;-><init>(Landroid/content/Context;Ljava/lang/Integer;)V

    invoke-virtual {p2, v2}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setVibrate(Z)V

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/core/camera/manager/BeepManager;->setPlayBeep(Z)V

    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/barinternal/b/a;)V
    .locals 2

    .line 1
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/b/a;->d:Lcom/scanflow/datacapture/sfcamera/SFCameraView;

    if-eqz p0, :cond_0

    sget-object v0, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    const-string v1, "Error 19 - Device Activation Failed\nThe device activation failed. Please connect to the Internet and restart the app."

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V

    :cond_0
    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/barinternal/b/a;Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)V
    .locals 1

    .line 2
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/b/a;->d:Lcom/scanflow/datacapture/sfcamera/SFCameraView;

    if-eqz p0, :cond_1

    sget-object v0, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    if-eqz p1, :cond_0

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getMessage()Ljava/lang/String;

    move-result-object p1

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    :goto_0
    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p0, v0, p1}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V

    :cond_1
    return-void
.end method

.method public static final b(Lcom/scanflow/datacapture/barinternal/b/a;)V
    .locals 2

    .line 1
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/b/a;->d:Lcom/scanflow/datacapture/sfcamera/SFCameraView;

    if-eqz p0, :cond_0

    sget-object v0, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    const-string v1, "Error 13 - License Key Expired\nThe license key validation failed. Your license key has expired, please log into your account at www.scanflow.ai and request an extension or contact support through this contact form."

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V

    :cond_0
    return-void
.end method

.method public static final c(Lcom/scanflow/datacapture/barinternal/b/a;)V
    .locals 2

    .line 1
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/b/a;->d:Lcom/scanflow/datacapture/sfcamera/SFCameraView;

    if-eqz p0, :cond_0

    sget-object v0, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    const-string v1, "Valid License"

    invoke-virtual {p0, v0, v1}, Lcom/scanflow/datacapture/sfcamera/SFCameraView;->setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V

    :cond_0
    return-void
.end method


# virtual methods
.method public final a(Ljava/lang/String;)Ljava/lang/String;
    .locals 10

    .line 3
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

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/b/a;->k:Landroid/content/SharedPreferences;
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
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/b/a;->l:Ljava/lang/String;

    invoke-interface {v6, v8, v0}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-static {v6}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/String;->toCharArray()[C

    move-result-object v6

    const-string v8, "toCharArray(...)"

    invoke-static {v6, v8}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/b/a;->k:Landroid/content/SharedPreferences;

    if-nez v8, :cond_1

    invoke-static {v7}, Lkotlin/jvm/internal/Intrinsics;->throwUninitializedPropertyAccessException(Ljava/lang/String;)V

    move-object v8, v2

    :cond_1
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/b/a;->m:Ljava/lang/String;

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

.method public final analyze(Landroidx/camera/core/ImageProxy;Landroidx/camera/core/Camera;Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;Ljava/lang/Object;)V
    .locals 9

    const-string v0, "imageProxy"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "mCamera"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p2, "cameraUserConfig"

    invoke-static {p3, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p2, "listener"

    invoke-static {p4, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    :try_start_0
    invoke-virtual {p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isNetworkAvailable()Z

    move-result p2

    iput-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->g:Z

    invoke-virtual {p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isContinuousScan()Z

    move-result p2

    iput-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->h:Z

    invoke-virtual {p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isPerformCaptureScan()Z

    move-result p2

    iput-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->i:Z

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->j:Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-virtual {p2}, Ljava/util/concurrent/atomic/AtomicBoolean;->get()Z

    move-result p2

    const/4 v0, 0x1

    if-nez p2, :cond_9

    invoke-virtual {p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getLicenseInfo()Ljava/lang/String;

    move-result-object p2

    invoke-virtual {p2}, Ljava/lang/String;->length()I

    move-result v1

    if-nez v1, :cond_1

    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->g:Z

    if-nez v1, :cond_1

    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->e:Landroid/app/Activity;

    if-eqz p1, :cond_0

    new-instance p2, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda0;

    invoke-direct {p2, p0}, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/b/a;)V

    invoke-virtual {p1, p2}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    goto :goto_0

    :catch_0
    move-exception v0

    move-object p1, v0

    goto/16 :goto_6

    :cond_0
    :goto_0
    const-string p1, "Error 19 - Device Activation Failed\nThe device activation failed. Please connect to the Internet and restart the app."

    invoke-interface {p4, p1}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onLicenseFailed(Ljava/lang/String;)V

    return-void

    :cond_1
    invoke-virtual {p2}, Ljava/lang/String;->length()I

    move-result v1

    if-nez v1, :cond_2

    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->g:Z

    if-eqz v1, :cond_2

    const-string p1, "InProgress"

    invoke-interface {p4, p1}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onLicenseFailed(Ljava/lang/String;)V

    return-void

    :cond_2
    invoke-virtual {p0, p2}, Lcom/scanflow/datacapture/barinternal/b/a;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p2

    new-instance v1, Lcom/google/gson/Gson;

    invoke-direct {v1}, Lcom/google/gson/Gson;-><init>()V

    const-class v2, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    invoke-virtual {v1, p2, v2}, Lcom/google/gson/Gson;->fromJson(Ljava/lang/String;Ljava/lang/Class;)Ljava/lang/Object;

    move-result-object p2

    const-string v1, "fromJson(...)"

    invoke-static {p2, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p2, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    invoke-virtual {p2}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getResult()Lcom/scanflow/datacapture/model/subscription/Result;

    move-result-object v1

    if-eqz v1, :cond_7

    .line 1
    new-instance v1, Ljava/text/SimpleDateFormat;

    const-string v2, "yyyy-MM-dd\'T\'HH:mm:ss.SSS"

    invoke-direct {v1, v2}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getResult()Lcom/scanflow/datacapture/model/subscription/Result;

    move-result-object p2

    if-eqz p2, :cond_3

    invoke-virtual {p2}, Lcom/scanflow/datacapture/model/subscription/Result;->getSubscriptionEndDate()Ljava/lang/String;

    move-result-object p2

    if-eqz p2, :cond_3

    invoke-virtual {v1, p2}, Ljava/text/DateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;

    move-result-object p2

    goto :goto_1

    :cond_3
    const/4 p2, 0x0

    :goto_1
    new-instance v1, Ljava/util/Date;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    invoke-direct {v1, v2, v3}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v1, p2}, Ljava/util/Date;->after(Ljava/util/Date;)Z

    move-result p2

    if-eqz p2, :cond_5

    .line 2
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->e:Landroid/app/Activity;

    if-eqz p1, :cond_4

    new-instance p2, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda1;

    invoke-direct {p2, p0}, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/b/a;)V

    invoke-virtual {p1, p2}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    :cond_4
    const-string p1, "Error 13 - License Key Expired\nThe license key validation failed. Your license key has expired, please log into your account at www.scanflow.ai and request an extension or contact support through this contact form."

    invoke-interface {p4, p1}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onLicenseFailed(Ljava/lang/String;)V

    return-void

    :cond_5
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->e:Landroid/app/Activity;

    if-eqz p2, :cond_6

    new-instance v1, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda2;

    invoke-direct {v1, p0}, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda2;-><init>(Lcom/scanflow/datacapture/barinternal/b/a;)V

    invoke-virtual {p2, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    :cond_6
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->j:Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-virtual {p2, v0}, Ljava/util/concurrent/atomic/AtomicBoolean;->set(Z)V

    goto :goto_2

    :cond_7
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->e:Landroid/app/Activity;

    if-eqz p1, :cond_8

    new-instance p3, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda3;

    invoke-direct {p3, p0, p2}, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/b/a;Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)V

    invoke-virtual {p1, p3}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    :cond_8
    invoke-virtual {p2}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->getMessage()Ljava/lang/String;

    move-result-object p1

    invoke-static {p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-interface {p4, p1}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onLicenseFailed(Ljava/lang/String;)V

    return-void

    :cond_9
    :goto_2
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    iget-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->h:Z

    if-nez p2, :cond_a

    iget-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->i:Z

    if-nez p2, :cond_a

    invoke-interface {p4}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onFailure()V

    return-void

    :cond_a
    iget-boolean p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->n:Z

    if-nez p2, :cond_b

    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/b/a;->n:Z

    :cond_b
    invoke-interface {p1}, Landroidx/camera/core/ImageProxy;->getImageInfo()Landroidx/camera/core/ImageInfo;

    move-result-object p2

    invoke-interface {p2}, Landroidx/camera/core/ImageInfo;->getRotationDegrees()I

    move-result p2

    invoke-interface {p1}, Landroidx/camera/core/ImageProxy;->getHeight()I

    move-result v0

    invoke-interface {p1}, Landroidx/camera/core/ImageProxy;->getWidth()I

    move-result v1

    invoke-virtual {p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getSelectedResolution()Landroid/util/Size;

    invoke-virtual {p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getEnableTirePreProcessing()Z

    invoke-virtual {p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->getEnableTireAngleDetection()Z

    div-int p3, v1, v0

    const-string v2, "null cannot be cast to non-null type com.scanflow.datacapture.core.camera.ScanflowReader.OnCameraResultCallback"

    invoke-static {p5, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p5, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/b/a;->f:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;

    invoke-static {p1}, Lcom/scanflow/datacapture/utils/a;->a(Landroidx/camera/core/ImageProxy;)Landroid/graphics/Bitmap;

    move-result-object v2

    new-instance p1, Landroid/graphics/Rect;

    const/4 p5, 0x0

    invoke-direct {p1, p5, p5, v1, v0}, Landroid/graphics/Rect;-><init>(IIII)V

    iget-object p5, p0, Lcom/scanflow/datacapture/barinternal/b/a;->c:Landroidx/lifecycle/MutableLiveData;

    invoke-virtual {p5}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object p5

    check-cast p5, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    const/4 v3, 0x3

    const/4 v4, 0x2

    if-le p3, v3, :cond_c

    invoke-static {p5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p5}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getFirst()Ljava/lang/Object;

    move-result-object p3

    check-cast p3, Ljava/lang/Number;

    invoke-virtual {p3}, Ljava/lang/Number;->intValue()I

    move-result p3

    invoke-virtual {p5}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getSecond()Ljava/lang/Object;

    move-result-object p5

    check-cast p5, Ljava/lang/Number;

    invoke-virtual {p5}, Ljava/lang/Number;->intValue()I

    move-result p5

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/b/a;->c:Landroidx/lifecycle/MutableLiveData;

    new-instance v5, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    div-int/2addr p3, v4

    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    invoke-static {p5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p5

    invoke-direct {v5, p3, p5}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    invoke-virtual {v3, v5}, Landroidx/lifecycle/MutableLiveData;->setValue(Ljava/lang/Object;)V

    :cond_c
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/b/a;->c:Landroidx/lifecycle/MutableLiveData;

    invoke-virtual {p3}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object p3

    check-cast p3, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    invoke-static {p3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getFirst()Ljava/lang/Object;

    move-result-object p5

    check-cast p5, Ljava/lang/Number;

    invoke-virtual {p5}, Ljava/lang/Number;->intValue()I

    move-result p5

    invoke-virtual {p3}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getSecond()Ljava/lang/Object;

    move-result-object p3

    check-cast p3, Ljava/lang/Number;

    invoke-virtual {p3}, Ljava/lang/Number;->intValue()I

    move-result p3

    const/16 v3, 0x5a

    const/high16 v5, 0x42c80000    # 100.0f

    if-eq p2, v3, :cond_d

    const/16 v3, 0x10e

    if-eq p2, v3, :cond_d

    new-instance v3, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    int-to-float p3, p3

    div-float/2addr p3, v5

    invoke-static {p3}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object p3

    int-to-float p5, p5

    div-float/2addr p5, v5

    invoke-static {p5}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object p5

    invoke-direct {v3, p3, p5}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    goto :goto_3

    :cond_d
    new-instance v3, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    int-to-float p5, p5

    div-float/2addr p5, v5

    invoke-static {p5}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object p5

    int-to-float p3, p3

    div-float/2addr p3, v5

    invoke-static {p3}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object p3

    invoke-direct {v3, p5, p3}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;-><init>(Ljava/lang/Object;Ljava/lang/Object;)V

    :goto_3
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->component1()Ljava/lang/Object;

    move-result-object p3

    check-cast p3, Ljava/lang/Number;

    invoke-virtual {p3}, Ljava/lang/Number;->floatValue()F

    move-result p3

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->component2()Ljava/lang/Object;

    move-result-object p5

    check-cast p5, Ljava/lang/Number;

    invoke-virtual {p5}, Ljava/lang/Number;->floatValue()F

    move-result p5

    int-to-float v1, v1

    mul-float/2addr v1, p3

    int-to-float p3, v4

    div-float/2addr v1, p3

    float-to-int v1, v1

    int-to-float v0, v0

    mul-float/2addr v0, p5

    div-float/2addr v0, p3

    float-to-int p3, v0

    invoke-virtual {p1, v1, p3}, Landroid/graphics/Rect;->inset(II)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    const-string p3, "Scan Failed!"

    if-eqz v2, :cond_12

    .line 3
    :try_start_1
    const-string p5, "bitmap"

    invoke-static {v2, p5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string p5, "cropRect"

    invoke-static {p1, p5}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v7, Landroid/graphics/Matrix;

    invoke-direct {v7}, Landroid/graphics/Matrix;-><init>()V

    int-to-float p2, p2

    invoke-virtual {v7, p2}, Landroid/graphics/Matrix;->preRotate(F)Z

    iget v3, p1, Landroid/graphics/Rect;->left:I

    iget v4, p1, Landroid/graphics/Rect;->top:I

    invoke-virtual {p1}, Landroid/graphics/Rect;->width()I

    move-result v5

    invoke-virtual {p1}, Landroid/graphics/Rect;->height()I

    move-result v6

    const/4 v8, 0x1

    invoke-static/range {v2 .. v8}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIIILandroid/graphics/Matrix;Z)Landroid/graphics/Bitmap;

    move-result-object p1

    const-string p2, "createBitmap(...)"

    invoke-static {p1, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    .line 4
    sget-object p2, Lcom/scanflow/datacapture/barinternal/f/a;->a:Lcom/scanflow/datacapture/barinternal/f/a;

    invoke-virtual {p2, p1, v2}, Lcom/scanflow/datacapture/barinternal/f/a;->a(Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;)Lcom/scanflow/datacapture/model/LowLightResponse;

    move-result-object p1

    if-eqz p1, :cond_f

    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/b/a;->f:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;

    if-eqz p2, :cond_e

    invoke-virtual {p1}, Lcom/scanflow/datacapture/model/LowLightResponse;->getBitmap()Landroid/graphics/Bitmap;

    move-result-object p1

    invoke-interface {p2, p1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;->onScanResultSuccess(Landroid/graphics/Bitmap;)V

    :cond_e
    const-string p1, "Success"

    invoke-interface {p4, p1}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onSuccess(Ljava/lang/String;)V

    return-void

    .line 5
    :cond_f
    iget-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->i:Z

    if-nez p1, :cond_10

    iget-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->h:Z

    if-eqz p1, :cond_14

    :cond_10
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->f:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;

    if-eqz p1, :cond_11

    invoke-interface {p1, p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;->onScanResultFailure(Ljava/lang/String;)V

    :cond_11
    :goto_4
    invoke-interface {p4}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onPerformCaptureScan()V

    goto :goto_5

    :cond_12
    iget-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->i:Z

    if-nez p1, :cond_13

    iget-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->h:Z

    if-eqz p1, :cond_14

    :cond_13
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/b/a;->f:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;

    if-eqz p1, :cond_11

    invoke-interface {p1, p3}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;->onScanResultFailure(Ljava/lang/String;)V

    goto :goto_4

    :cond_14
    :goto_5
    invoke-interface {p4}, Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;->onFailure()V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    return-void

    .line 6
    :goto_6
    invoke-virtual {p1}, Ljava/lang/Throwable;->printStackTrace()V

    return-void
.end method
