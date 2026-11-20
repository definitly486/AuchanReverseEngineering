.class public final Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;
.super Ljava/lang/Object;
.source "EcdsaVerifyJce.java"

# interfaces
.implements Lcom/google/crypto/tink/PublicKeyVerify;


# annotations
.annotation runtime Lcom/google/errorprone/annotations/Immutable;
.end annotation


# static fields
.field static final CURVE_TYPE_CONVERTER:Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/internal/EnumTypeProtoConverter<",
            "Lcom/google/crypto/tink/subtle/EllipticCurves$CurveType;",
            "Lcom/google/crypto/tink/signature/EcdsaParameters$CurveType;",
            ">;"
        }
    .end annotation
.end field

.field private static final EMPTY:[B

.field static final ENCODING_CONVERTER:Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/internal/EnumTypeProtoConverter<",
            "Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;",
            "Lcom/google/crypto/tink/signature/EcdsaParameters$SignatureEncoding;",
            ">;"
        }
    .end annotation
.end field

.field public static final FIPS:Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;

.field static final HASH_TYPE_CONVERTER:Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/internal/EnumTypeProtoConverter<",
            "Lcom/google/crypto/tink/subtle/Enums$HashType;",
            "Lcom/google/crypto/tink/signature/EcdsaParameters$HashType;",
            ">;"
        }
    .end annotation
.end field

.field private static final legacyMessageSuffix:[B


# instance fields
.field private final encoding:Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;

.field private final messageSuffix:[B

.field private final outputPrefix:[B

.field private final provider:Ljava/security/Provider;

.field private final publicKey:Ljava/security/interfaces/ECPublicKey;

.field private final signatureAlgorithm:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 54
    sget-object v0, Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;->ALGORITHM_REQUIRES_BORINGCRYPTO:Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;

    sput-object v0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->FIPS:Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;

    const/4 v0, 0x0

    .line 57
    new-array v1, v0, [B

    sput-object v1, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->EMPTY:[B

    const/4 v1, 0x1

    .line 58
    new-array v1, v1, [B

    aput-byte v0, v1, v0

    sput-object v1, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->legacyMessageSuffix:[B

    .line 77
    invoke-static {}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;->builder()Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/subtle/Enums$HashType;->SHA256:Lcom/google/crypto/tink/subtle/Enums$HashType;

    sget-object v2, Lcom/google/crypto/tink/signature/EcdsaParameters$HashType;->SHA256:Lcom/google/crypto/tink/signature/EcdsaParameters$HashType;

    .line 78
    invoke-virtual {v0, v1, v2}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->add(Ljava/lang/Enum;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/subtle/Enums$HashType;->SHA384:Lcom/google/crypto/tink/subtle/Enums$HashType;

    sget-object v2, Lcom/google/crypto/tink/signature/EcdsaParameters$HashType;->SHA384:Lcom/google/crypto/tink/signature/EcdsaParameters$HashType;

    .line 79
    invoke-virtual {v0, v1, v2}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->add(Ljava/lang/Enum;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/subtle/Enums$HashType;->SHA512:Lcom/google/crypto/tink/subtle/Enums$HashType;

    sget-object v2, Lcom/google/crypto/tink/signature/EcdsaParameters$HashType;->SHA512:Lcom/google/crypto/tink/signature/EcdsaParameters$HashType;

    .line 80
    invoke-virtual {v0, v1, v2}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->add(Ljava/lang/Enum;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    .line 81
    invoke-virtual {v0}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->build()Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;

    move-result-object v0

    sput-object v0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->HASH_TYPE_CONVERTER:Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;

    .line 84
    invoke-static {}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;->builder()Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;->IEEE_P1363:Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;

    sget-object v2, Lcom/google/crypto/tink/signature/EcdsaParameters$SignatureEncoding;->IEEE_P1363:Lcom/google/crypto/tink/signature/EcdsaParameters$SignatureEncoding;

    .line 85
    invoke-virtual {v0, v1, v2}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->add(Ljava/lang/Enum;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;->DER:Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;

    sget-object v2, Lcom/google/crypto/tink/signature/EcdsaParameters$SignatureEncoding;->DER:Lcom/google/crypto/tink/signature/EcdsaParameters$SignatureEncoding;

    .line 86
    invoke-virtual {v0, v1, v2}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->add(Ljava/lang/Enum;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    .line 87
    invoke-virtual {v0}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->build()Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;

    move-result-object v0

    sput-object v0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->ENCODING_CONVERTER:Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;

    .line 89
    invoke-static {}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;->builder()Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/subtle/EllipticCurves$CurveType;->NIST_P256:Lcom/google/crypto/tink/subtle/EllipticCurves$CurveType;

    sget-object v2, Lcom/google/crypto/tink/signature/EcdsaParameters$CurveType;->NIST_P256:Lcom/google/crypto/tink/signature/EcdsaParameters$CurveType;

    .line 90
    invoke-virtual {v0, v1, v2}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->add(Ljava/lang/Enum;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/subtle/EllipticCurves$CurveType;->NIST_P384:Lcom/google/crypto/tink/subtle/EllipticCurves$CurveType;

    sget-object v2, Lcom/google/crypto/tink/signature/EcdsaParameters$CurveType;->NIST_P384:Lcom/google/crypto/tink/signature/EcdsaParameters$CurveType;

    .line 91
    invoke-virtual {v0, v1, v2}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->add(Ljava/lang/Enum;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/subtle/EllipticCurves$CurveType;->NIST_P521:Lcom/google/crypto/tink/subtle/EllipticCurves$CurveType;

    sget-object v2, Lcom/google/crypto/tink/signature/EcdsaParameters$CurveType;->NIST_P521:Lcom/google/crypto/tink/signature/EcdsaParameters$CurveType;

    .line 92
    invoke-virtual {v0, v1, v2}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->add(Ljava/lang/Enum;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;

    move-result-object v0

    .line 93
    invoke-virtual {v0}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter$Builder;->build()Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;

    move-result-object v0

    sput-object v0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->CURVE_TYPE_CONVERTER:Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;

    return-void
.end method

.method public constructor <init>(Ljava/security/interfaces/ECPublicKey;Lcom/google/crypto/tink/subtle/Enums$HashType;Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;)V
    .locals 7

    .line 146
    sget-object v4, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->EMPTY:[B

    invoke-static {}, Lcom/google/crypto/tink/internal/ConscryptUtil;->providerOrNull()Ljava/security/Provider;

    move-result-object v6

    move-object v5, v4

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    invoke-direct/range {v0 .. v6}, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;-><init>(Ljava/security/interfaces/ECPublicKey;Lcom/google/crypto/tink/subtle/Enums$HashType;Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;[B[BLjava/security/Provider;)V

    .line 147
    invoke-interface {v1}, Ljava/security/interfaces/ECPublicKey;->getW()Ljava/security/spec/ECPoint;

    move-result-object p1

    invoke-interface {v1}, Ljava/security/interfaces/ECKey;->getParams()Ljava/security/spec/ECParameterSpec;

    move-result-object p2

    invoke-virtual {p2}, Ljava/security/spec/ECParameterSpec;->getCurve()Ljava/security/spec/EllipticCurve;

    move-result-object p2

    invoke-static {p1, p2}, Lcom/google/crypto/tink/internal/EllipticCurvesUtil;->checkPointOnCurve(Ljava/security/spec/ECPoint;Ljava/security/spec/EllipticCurve;)V

    return-void
.end method

.method private constructor <init>(Ljava/security/interfaces/ECPublicKey;Lcom/google/crypto/tink/subtle/Enums$HashType;Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;[B[BLjava/security/Provider;)V
    .locals 1

    .line 130
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 131
    sget-object v0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->FIPS:Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;

    invoke-virtual {v0}, Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;->isCompatible()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 136
    invoke-static {p2}, Lcom/google/crypto/tink/subtle/SubtleUtil;->toEcdsaAlgo(Lcom/google/crypto/tink/subtle/Enums$HashType;)Ljava/lang/String;

    move-result-object p2

    iput-object p2, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->signatureAlgorithm:Ljava/lang/String;

    .line 137
    iput-object p1, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->publicKey:Ljava/security/interfaces/ECPublicKey;

    .line 138
    iput-object p3, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->encoding:Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;

    .line 139
    iput-object p4, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->outputPrefix:[B

    .line 140
    iput-object p5, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->messageSuffix:[B

    .line 141
    iput-object p6, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->provider:Ljava/security/Provider;

    return-void

    .line 132
    :cond_0
    new-instance p1, Ljava/security/GeneralSecurityException;

    const-string p2, "Can not use ECDSA in FIPS-mode, as BoringCrypto is not available."

    invoke-direct {p1, p2}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public static create(Lcom/google/crypto/tink/signature/EcdsaPublicKey;)Lcom/google/crypto/tink/PublicKeyVerify;
    .locals 7
    .annotation build Lcom/google/crypto/tink/AccessesPartialKey;
    .end annotation

    .line 97
    invoke-static {}, Lcom/google/crypto/tink/internal/ConscryptUtil;->providerOrNull()Ljava/security/Provider;

    move-result-object v6

    .line 99
    sget-object v0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->CURVE_TYPE_CONVERTER:Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;

    .line 101
    invoke-virtual {p0}, Lcom/google/crypto/tink/signature/EcdsaPublicKey;->getParameters()Lcom/google/crypto/tink/signature/EcdsaParameters;

    move-result-object v1

    invoke-virtual {v1}, Lcom/google/crypto/tink/signature/EcdsaParameters;->getCurveType()Lcom/google/crypto/tink/signature/EcdsaParameters$CurveType;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;->toProtoEnum(Ljava/lang/Object;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/subtle/EllipticCurves$CurveType;

    .line 100
    invoke-static {v0}, Lcom/google/crypto/tink/subtle/EllipticCurves;->getCurveSpec(Lcom/google/crypto/tink/subtle/EllipticCurves$CurveType;)Ljava/security/spec/ECParameterSpec;

    move-result-object v0

    .line 102
    invoke-virtual {p0}, Lcom/google/crypto/tink/signature/EcdsaPublicKey;->getPublicPoint()Ljava/security/spec/ECPoint;

    move-result-object v1

    .line 103
    new-instance v2, Ljava/security/spec/ECPublicKeySpec;

    invoke-direct {v2, v1, v0}, Ljava/security/spec/ECPublicKeySpec;-><init>(Ljava/security/spec/ECPoint;Ljava/security/spec/ECParameterSpec;)V

    .line 105
    const-string v0, "EC"

    if-eqz v6, :cond_0

    .line 106
    invoke-static {v0, v6}, Ljava/security/KeyFactory;->getInstance(Ljava/lang/String;Ljava/security/Provider;)Ljava/security/KeyFactory;

    move-result-object v0

    goto :goto_0

    .line 108
    :cond_0
    sget-object v1, Lcom/google/crypto/tink/subtle/EngineFactory;->KEY_FACTORY:Lcom/google/crypto/tink/subtle/EngineFactory;

    invoke-virtual {v1, v0}, Lcom/google/crypto/tink/subtle/EngineFactory;->getInstance(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/security/KeyFactory;

    .line 110
    :goto_0
    invoke-virtual {v0, v2}, Ljava/security/KeyFactory;->generatePublic(Ljava/security/spec/KeySpec;)Ljava/security/PublicKey;

    move-result-object v0

    move-object v1, v0

    check-cast v1, Ljava/security/interfaces/ECPublicKey;

    .line 112
    new-instance v0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;

    sget-object v2, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->HASH_TYPE_CONVERTER:Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;

    .line 114
    invoke-virtual {p0}, Lcom/google/crypto/tink/signature/EcdsaPublicKey;->getParameters()Lcom/google/crypto/tink/signature/EcdsaParameters;

    move-result-object v3

    invoke-virtual {v3}, Lcom/google/crypto/tink/signature/EcdsaParameters;->getHashType()Lcom/google/crypto/tink/signature/EcdsaParameters$HashType;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;->toProtoEnum(Ljava/lang/Object;)Ljava/lang/Enum;

    move-result-object v2

    check-cast v2, Lcom/google/crypto/tink/subtle/Enums$HashType;

    sget-object v3, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->ENCODING_CONVERTER:Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;

    .line 115
    invoke-virtual {p0}, Lcom/google/crypto/tink/signature/EcdsaPublicKey;->getParameters()Lcom/google/crypto/tink/signature/EcdsaParameters;

    move-result-object v4

    invoke-virtual {v4}, Lcom/google/crypto/tink/signature/EcdsaParameters;->getSignatureEncoding()Lcom/google/crypto/tink/signature/EcdsaParameters$SignatureEncoding;

    move-result-object v4

    invoke-virtual {v3, v4}, Lcom/google/crypto/tink/internal/EnumTypeProtoConverter;->toProtoEnum(Ljava/lang/Object;)Ljava/lang/Enum;

    move-result-object v3

    check-cast v3, Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;

    .line 116
    invoke-virtual {p0}, Lcom/google/crypto/tink/signature/EcdsaPublicKey;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

    move-result-object v4

    invoke-virtual {v4}, Lcom/google/crypto/tink/util/Bytes;->toByteArray()[B

    move-result-object v4

    .line 117
    invoke-virtual {p0}, Lcom/google/crypto/tink/signature/EcdsaPublicKey;->getParameters()Lcom/google/crypto/tink/signature/EcdsaParameters;

    move-result-object p0

    invoke-virtual {p0}, Lcom/google/crypto/tink/signature/EcdsaParameters;->getVariant()Lcom/google/crypto/tink/signature/EcdsaParameters$Variant;

    move-result-object p0

    sget-object v5, Lcom/google/crypto/tink/signature/EcdsaParameters$Variant;->LEGACY:Lcom/google/crypto/tink/signature/EcdsaParameters$Variant;

    invoke-virtual {p0, v5}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result p0

    if-eqz p0, :cond_1

    .line 118
    sget-object p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->legacyMessageSuffix:[B

    :goto_1
    move-object v5, p0

    goto :goto_2

    .line 119
    :cond_1
    sget-object p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->EMPTY:[B

    goto :goto_1

    :goto_2
    invoke-direct/range {v0 .. v6}, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;-><init>(Ljava/security/interfaces/ECPublicKey;Lcom/google/crypto/tink/subtle/Enums$HashType;Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;[B[BLjava/security/Provider;)V

    return-object v0
.end method

.method private getInstance(Ljava/lang/String;)Ljava/security/Signature;
    .locals 1

    .line 151
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->provider:Ljava/security/Provider;

    if-eqz v0, :cond_0

    .line 152
    invoke-static {p1, v0}, Ljava/security/Signature;->getInstance(Ljava/lang/String;Ljava/security/Provider;)Ljava/security/Signature;

    move-result-object p1

    return-object p1

    .line 154
    :cond_0
    sget-object v0, Lcom/google/crypto/tink/subtle/EngineFactory;->SIGNATURE:Lcom/google/crypto/tink/subtle/EngineFactory;

    invoke-virtual {v0, p1}, Lcom/google/crypto/tink/subtle/EngineFactory;->getInstance(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/security/Signature;

    return-object p1
.end method

.method private noPrefixVerify([B[B)V
    .locals 3

    .line 160
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->encoding:Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;

    sget-object v1, Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;->IEEE_P1363:Lcom/google/crypto/tink/subtle/EllipticCurves$EcdsaEncoding;

    const-string v2, "Invalid signature"

    if-ne v0, v1, :cond_1

    .line 161
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->publicKey:Ljava/security/interfaces/ECPublicKey;

    invoke-interface {v0}, Ljava/security/interfaces/ECKey;->getParams()Ljava/security/spec/ECParameterSpec;

    move-result-object v0

    invoke-virtual {v0}, Ljava/security/spec/ECParameterSpec;->getCurve()Ljava/security/spec/EllipticCurve;

    move-result-object v0

    .line 162
    array-length v1, p1

    invoke-static {v0}, Lcom/google/crypto/tink/subtle/EllipticCurves;->fieldSizeInBytes(Ljava/security/spec/EllipticCurve;)I

    move-result v0

    mul-int/lit8 v0, v0, 0x2

    if-ne v1, v0, :cond_0

    .line 165
    invoke-static {p1}, Lcom/google/crypto/tink/subtle/EllipticCurves;->ecdsaIeee2Der([B)[B

    move-result-object p1

    goto :goto_0

    .line 163
    :cond_0
    new-instance p1, Ljava/security/GeneralSecurityException;

    invoke-direct {p1, v2}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 167
    :cond_1
    :goto_0
    invoke-static {p1}, Lcom/google/crypto/tink/subtle/EllipticCurves;->isValidDerEncoding([B)Z

    move-result v0

    if-eqz v0, :cond_4

    .line 170
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->signatureAlgorithm:Ljava/lang/String;

    invoke-direct {p0, v0}, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->getInstance(Ljava/lang/String;)Ljava/security/Signature;

    move-result-object v0

    .line 171
    iget-object v1, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->publicKey:Ljava/security/interfaces/ECPublicKey;

    invoke-virtual {v0, v1}, Ljava/security/Signature;->initVerify(Ljava/security/PublicKey;)V

    .line 172
    invoke-virtual {v0, p2}, Ljava/security/Signature;->update([B)V

    .line 173
    iget-object p2, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->messageSuffix:[B

    array-length v1, p2

    if-lez v1, :cond_2

    .line 174
    invoke-virtual {v0, p2}, Ljava/security/Signature;->update([B)V

    .line 178
    :cond_2
    :try_start_0
    invoke-virtual {v0, p1}, Ljava/security/Signature;->verify([B)Z

    move-result p1
    :try_end_0
    .catch Ljava/lang/RuntimeException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    :catch_0
    const/4 p1, 0x0

    :goto_1
    if-eqz p1, :cond_3

    return-void

    .line 183
    :cond_3
    new-instance p1, Ljava/security/GeneralSecurityException;

    invoke-direct {p1, v2}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 168
    :cond_4
    new-instance p1, Ljava/security/GeneralSecurityException;

    invoke-direct {p1, v2}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p1
.end method


# virtual methods
.method public verify([B[B)V
    .locals 2

    .line 189
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->outputPrefix:[B

    array-length v1, v0

    if-nez v1, :cond_0

    .line 190
    invoke-direct {p0, p1, p2}, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->noPrefixVerify([B[B)V

    return-void

    .line 193
    :cond_0
    invoke-static {v0, p1}, Lcom/google/crypto/tink/internal/Util;->isPrefix([B[B)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 196
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->outputPrefix:[B

    array-length v0, v0

    array-length v1, p1

    invoke-static {p1, v0, v1}, Ljava/util/Arrays;->copyOfRange([BII)[B

    move-result-object p1

    .line 197
    invoke-direct {p0, p1, p2}, Lcom/google/crypto/tink/signature/internal/EcdsaVerifyJce;->noPrefixVerify([B[B)V

    return-void

    .line 194
    :cond_1
    new-instance p1, Ljava/security/GeneralSecurityException;

    const-string p2, "Invalid signature (output prefix mismatch)"

    invoke-direct {p1, p2}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
