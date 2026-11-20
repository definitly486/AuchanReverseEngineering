.class public final Lcom/google/mlkit/vision/text/internal/TextOptionalModuleUtils;
.super Ljava/lang/Object;
.source "com.google.android.gms:play-services-mlkit-text-recognition-common@@19.1.0"


# annotations
.annotation build Lcom/google/android/gms/common/annotation/KeepForSdk;
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static zza(Lcom/google/mlkit/vision/text/TextRecognizerOptionsInterface;)[Lcom/google/android/gms/common/Feature;
    .locals 1

    .line 1
    invoke-interface {p0}, Lcom/google/mlkit/vision/text/TextRecognizerOptionsInterface;->getIsThickClient()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 2
    sget-object p0, Lcom/google/mlkit/common/sdkinternal/OptionalModuleUtils;->EMPTY_FEATURES:[Lcom/google/android/gms/common/Feature;

    return-object p0

    .line 3
    :cond_0
    invoke-interface {p0}, Lcom/google/mlkit/vision/text/TextRecognizerOptionsInterface;->getLoggingLanguageOption()I

    move-result p0

    packed-switch p0, :pswitch_data_0

    .line 9
    sget-object p0, Lcom/google/mlkit/common/sdkinternal/OptionalModuleUtils;->FEATURE_OCR:Lcom/google/android/gms/common/Feature;

    filled-new-array {p0}, [Lcom/google/android/gms/common/Feature;

    move-result-object p0

    return-object p0

    .line 4
    :pswitch_0
    sget-object p0, Lcom/google/mlkit/common/sdkinternal/OptionalModuleUtils;->FEATURE_OCR_COMMON:Lcom/google/android/gms/common/Feature;

    filled-new-array {p0}, [Lcom/google/android/gms/common/Feature;

    move-result-object p0

    return-object p0

    .line 5
    :pswitch_1
    sget-object p0, Lcom/google/mlkit/common/sdkinternal/OptionalModuleUtils;->FEATURE_OCR_KOREAN:Lcom/google/android/gms/common/Feature;

    filled-new-array {p0}, [Lcom/google/android/gms/common/Feature;

    move-result-object p0

    return-object p0

    .line 6
    :pswitch_2
    sget-object p0, Lcom/google/mlkit/common/sdkinternal/OptionalModuleUtils;->FEATURE_OCR_JAPANESE:Lcom/google/android/gms/common/Feature;

    filled-new-array {p0}, [Lcom/google/android/gms/common/Feature;

    move-result-object p0

    return-object p0

    .line 7
    :pswitch_3
    sget-object p0, Lcom/google/mlkit/common/sdkinternal/OptionalModuleUtils;->FEATURE_OCR_DEVANAGARI:Lcom/google/android/gms/common/Feature;

    filled-new-array {p0}, [Lcom/google/android/gms/common/Feature;

    move-result-object p0

    return-object p0

    .line 8
    :pswitch_4
    sget-object p0, Lcom/google/mlkit/common/sdkinternal/OptionalModuleUtils;->FEATURE_OCR_CHINESE:Lcom/google/android/gms/common/Feature;

    filled-new-array {p0}, [Lcom/google/android/gms/common/Feature;

    move-result-object p0

    return-object p0

    :pswitch_data_0
    .packed-switch 0x2
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
        :pswitch_0
        :pswitch_0
    .end packed-switch
.end method
