.class public final Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters;
.super Ljava/lang/Object;
.source "PredefinedStreamingAeadParameters.java"


# static fields
.field public static final AES128_CTR_HMAC_SHA256_1MB:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

.field public static final AES128_CTR_HMAC_SHA256_4KB:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

.field public static final AES128_GCM_HKDF_1MB:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

.field public static final AES128_GCM_HKDF_4KB:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

.field public static final AES256_CTR_HMAC_SHA256_1MB:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

.field public static final AES256_CTR_HMAC_SHA256_4KB:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

.field public static final AES256_GCM_HKDF_1MB:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

.field public static final AES256_GCM_HKDF_4KB:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;


# direct methods
.method public static synthetic $r8$lambda$74N34Hcs43wkb1zKgIeD_DbT8pw()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;
    .locals 2

    .line 162
    invoke-static {}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;->builder()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x10

    .line 163
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    .line 164
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setDerivedAesGcmKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;->SHA256:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;

    .line 165
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setHkdfHashType(Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    const/high16 v1, 0x100000

    .line 166
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setCiphertextSegmentSizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    .line 167
    invoke-virtual {v0}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->build()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    move-result-object v0

    return-object v0
.end method

.method public static synthetic $r8$lambda$LomddjGbw_KOEuMLqu8UGG-e-n0()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;
    .locals 2

    .line 183
    invoke-static {}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;->builder()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x20

    .line 184
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    .line 185
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setDerivedAesGcmKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;->SHA256:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;

    .line 186
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setHkdfHashType(Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x1000

    .line 187
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setCiphertextSegmentSizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    .line 188
    invoke-virtual {v0}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->build()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    move-result-object v0

    return-object v0
.end method

.method public static synthetic $r8$lambda$O3As-vE6UxqGC_fjNepCJYobEvo()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;
    .locals 2

    .line 141
    invoke-static {}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;->builder()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x10

    .line 142
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    .line 143
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setDerivedAesGcmKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;->SHA256:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;

    .line 144
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setHkdfHashType(Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x1000

    .line 145
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setCiphertextSegmentSizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    .line 146
    invoke-virtual {v0}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->build()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    move-result-object v0

    return-object v0
.end method

.method public static synthetic $r8$lambda$fXFnkFiYyBSGfzWmnlvozCnrFO4()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;
    .locals 2

    .line 44
    invoke-static {}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;->builder()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x10

    .line 45
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 46
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setDerivedKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;->SHA256:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;

    .line 47
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHkdfHashType(Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 48
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHmacHashType(Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x20

    .line 49
    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHmacTagSizeBytes(Ljava/lang/Integer;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x1000

    .line 50
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setCiphertextSegmentSizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 51
    invoke-virtual {v0}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->build()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    move-result-object v0

    return-object v0
.end method

.method public static synthetic $r8$lambda$nJ4rLQRQ2ttBCQzLXXnvTx5ttPg()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;
    .locals 2

    .line 68
    invoke-static {}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;->builder()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x10

    .line 69
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 70
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setDerivedKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;->SHA256:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;

    .line 71
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHkdfHashType(Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 72
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHmacHashType(Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x20

    .line 73
    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHmacTagSizeBytes(Ljava/lang/Integer;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    const/high16 v1, 0x100000

    .line 74
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setCiphertextSegmentSizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 75
    invoke-virtual {v0}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->build()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    move-result-object v0

    return-object v0
.end method

.method public static synthetic $r8$lambda$rajZfSPtz7fpC3EDfATi5jm0Za8()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;
    .locals 2

    .line 204
    invoke-static {}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;->builder()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x20

    .line 205
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    .line 206
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setDerivedAesGcmKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;->SHA256:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;

    .line 207
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setHkdfHashType(Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    const/high16 v1, 0x100000

    .line 208
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->setCiphertextSegmentSizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;

    move-result-object v0

    .line 209
    invoke-virtual {v0}, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters$Builder;->build()Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    move-result-object v0

    return-object v0
.end method

.method public static synthetic $r8$lambda$sGfquEqnaSSdrDXax1WkCrdYI58()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;
    .locals 3

    .line 118
    invoke-static {}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;->builder()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x20

    .line 119
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 120
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setDerivedKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    sget-object v2, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;->SHA256:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;

    .line 121
    invoke-virtual {v0, v2}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHkdfHashType(Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 122
    invoke-virtual {v0, v2}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHmacHashType(Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 123
    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHmacTagSizeBytes(Ljava/lang/Integer;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    const/high16 v1, 0x100000

    .line 124
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setCiphertextSegmentSizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 125
    invoke-virtual {v0}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->build()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    move-result-object v0

    return-object v0
.end method

.method public static synthetic $r8$lambda$uNgSZ4N--O1X78lijL4EW39ekGs()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;
    .locals 3

    .line 93
    invoke-static {}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;->builder()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x20

    .line 94
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 95
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setDerivedKeySizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    sget-object v2, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;->SHA256:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;

    .line 96
    invoke-virtual {v0, v2}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHkdfHashType(Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 97
    invoke-virtual {v0, v2}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHmacHashType(Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$HashType;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 98
    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setHmacTagSizeBytes(Ljava/lang/Integer;)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    const/16 v1, 0x1000

    .line 99
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->setCiphertextSegmentSizeBytes(I)Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;

    move-result-object v0

    .line 100
    invoke-virtual {v0}, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters$Builder;->build()Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 1

    .line 41
    new-instance v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda0;-><init>()V

    .line 42
    invoke-static {v0}, Lcom/google/crypto/tink/internal/TinkBugException;->exceptionIsBug(Lcom/google/crypto/tink/internal/TinkBugException$ThrowingSupplier;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    sput-object v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters;->AES128_CTR_HMAC_SHA256_4KB:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    .line 65
    new-instance v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda1;

    invoke-direct {v0}, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda1;-><init>()V

    .line 66
    invoke-static {v0}, Lcom/google/crypto/tink/internal/TinkBugException;->exceptionIsBug(Lcom/google/crypto/tink/internal/TinkBugException$ThrowingSupplier;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    sput-object v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters;->AES128_CTR_HMAC_SHA256_1MB:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    .line 90
    new-instance v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda2;

    invoke-direct {v0}, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda2;-><init>()V

    .line 91
    invoke-static {v0}, Lcom/google/crypto/tink/internal/TinkBugException;->exceptionIsBug(Lcom/google/crypto/tink/internal/TinkBugException$ThrowingSupplier;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    sput-object v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters;->AES256_CTR_HMAC_SHA256_4KB:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    .line 115
    new-instance v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda3;

    invoke-direct {v0}, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda3;-><init>()V

    .line 116
    invoke-static {v0}, Lcom/google/crypto/tink/internal/TinkBugException;->exceptionIsBug(Lcom/google/crypto/tink/internal/TinkBugException$ThrowingSupplier;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    sput-object v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters;->AES256_CTR_HMAC_SHA256_1MB:Lcom/google/crypto/tink/streamingaead/AesCtrHmacStreamingParameters;

    .line 138
    new-instance v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda4;

    invoke-direct {v0}, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda4;-><init>()V

    .line 139
    invoke-static {v0}, Lcom/google/crypto/tink/internal/TinkBugException;->exceptionIsBug(Lcom/google/crypto/tink/internal/TinkBugException$ThrowingSupplier;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    sput-object v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters;->AES128_GCM_HKDF_4KB:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    .line 159
    new-instance v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda5;

    invoke-direct {v0}, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda5;-><init>()V

    .line 160
    invoke-static {v0}, Lcom/google/crypto/tink/internal/TinkBugException;->exceptionIsBug(Lcom/google/crypto/tink/internal/TinkBugException$ThrowingSupplier;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    sput-object v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters;->AES128_GCM_HKDF_1MB:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    .line 180
    new-instance v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda6;

    invoke-direct {v0}, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda6;-><init>()V

    .line 181
    invoke-static {v0}, Lcom/google/crypto/tink/internal/TinkBugException;->exceptionIsBug(Lcom/google/crypto/tink/internal/TinkBugException$ThrowingSupplier;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    sput-object v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters;->AES256_GCM_HKDF_4KB:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    .line 201
    new-instance v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda7;

    invoke-direct {v0}, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters$$ExternalSyntheticLambda7;-><init>()V

    .line 202
    invoke-static {v0}, Lcom/google/crypto/tink/internal/TinkBugException;->exceptionIsBug(Lcom/google/crypto/tink/internal/TinkBugException$ThrowingSupplier;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    sput-object v0, Lcom/google/crypto/tink/streamingaead/PredefinedStreamingAeadParameters;->AES256_GCM_HKDF_1MB:Lcom/google/crypto/tink/streamingaead/AesGcmHkdfStreamingParameters;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 211
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method
