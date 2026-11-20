.class public final Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;
.super Ljava/lang/Object;
.source "RsaSsaPssSignConscrypt.java"

# interfaces
.implements Lcom/google/crypto/tink/PublicKeySign;


# annotations
.annotation runtime Lcom/google/errorprone/annotations/Immutable;
.end annotation


# static fields
.field private static final EMPTY:[B

.field public static final FIPS:Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;

.field private static final LEGACY_MESSAGE_SUFFIX:[B


# instance fields
.field private final conscrypt:Ljava/security/Provider;

.field private final messageSuffix:[B

.field private final outputPrefix:[B

.field private final parameterSpec:Ljava/security/spec/PSSParameterSpec;

.field private final privateKey:Ljava/security/interfaces/RSAPrivateCrtKey;

.field private final signatureAlgorithm:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 40
    sget-object v0, Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;->ALGORITHM_REQUIRES_BORINGCRYPTO:Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;

    sput-object v0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->FIPS:Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;

    const/4 v0, 0x0

    .line 43
    new-array v1, v0, [B

    sput-object v1, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->EMPTY:[B

    const/4 v1, 0x1

    .line 44
    new-array v1, v1, [B

    aput-byte v0, v1, v0

    sput-object v1, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->LEGACY_MESSAGE_SUFFIX:[B

    return-void
.end method

.method private constructor <init>(Ljava/security/interfaces/RSAPrivateCrtKey;Lcom/google/crypto/tink/signature/RsaSsaPssParameters$HashType;Lcom/google/crypto/tink/signature/RsaSsaPssParameters$HashType;I[B[BLjava/security/Provider;)V
    .locals 1

    .line 103
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 104
    sget-object v0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->FIPS:Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;

    invoke-virtual {v0}, Lcom/google/crypto/tink/config/internal/TinkFipsUtil$AlgorithmFipsCompatibility;->isCompatible()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 108
    invoke-interface {p1}, Ljava/security/interfaces/RSAKey;->getModulus()Ljava/math/BigInteger;

    move-result-object v0

    invoke-virtual {v0}, Ljava/math/BigInteger;->bitLength()I

    move-result v0

    invoke-static {v0}, Lcom/google/crypto/tink/subtle/Validators;->validateRsaModulusSize(I)V

    .line 109
    invoke-interface {p1}, Ljava/security/interfaces/RSAPrivateCrtKey;->getPublicExponent()Ljava/math/BigInteger;

    move-result-object v0

    invoke-static {v0}, Lcom/google/crypto/tink/subtle/Validators;->validateRsaPublicExponent(Ljava/math/BigInteger;)V

    .line 110
    iput-object p1, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->privateKey:Ljava/security/interfaces/RSAPrivateCrtKey;

    .line 111
    invoke-static {p2}, Lcom/google/crypto/tink/signature/internal/RsaSsaPssVerifyConscrypt;->getConscryptRsaSsaPssAlgo(Lcom/google/crypto/tink/signature/RsaSsaPssParameters$HashType;)Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->signatureAlgorithm:Ljava/lang/String;

    .line 113
    invoke-static {p2, p3, p4}, Lcom/google/crypto/tink/signature/internal/RsaSsaPssVerifyConscrypt;->getPssParameterSpec(Lcom/google/crypto/tink/signature/RsaSsaPssParameters$HashType;Lcom/google/crypto/tink/signature/RsaSsaPssParameters$HashType;I)Ljava/security/spec/PSSParameterSpec;

    move-result-object p1

    iput-object p1, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->parameterSpec:Ljava/security/spec/PSSParameterSpec;

    .line 114
    iput-object p5, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->outputPrefix:[B

    .line 115
    iput-object p6, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->messageSuffix:[B

    .line 116
    iput-object p7, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->conscrypt:Ljava/security/Provider;

    return-void

    .line 105
    :cond_0
    new-instance p1, Ljava/security/GeneralSecurityException;

    const-string p2, "Cannot use RSA PSS in FIPS-mode, as BoringCrypto module is not available."

    invoke-direct {p1, p2}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public static create(Lcom/google/crypto/tink/signature/RsaSsaPssPrivateKey;)Lcom/google/crypto/tink/PublicKeySign;
    .locals 18
    .annotation build Lcom/google/crypto/tink/AccessesPartialKey;
    .end annotation

    .line 65
    invoke-static {}, Lcom/google/crypto/tink/signature/internal/RsaSsaPssVerifyConscrypt;->conscryptProviderOrNull()Ljava/security/Provider;

    move-result-object v7

    if-eqz v7, :cond_1

    .line 69
    const-string v0, "RSA"

    invoke-static {v0, v7}, Ljava/security/KeyFactory;->getInstance(Ljava/lang/String;Ljava/security/Provider;)Ljava/security/KeyFactory;

    move-result-object v0

    .line 70
    invoke-virtual/range {p0 .. p0}, Lcom/google/crypto/tink/signature/RsaSsaPssPrivateKey;->getParameters()Lcom/google/crypto/tink/signature/RsaSsaPssParameters;

    move-result-object v1

    .line 71
    new-instance v8, Ljava/security/spec/RSAPrivateCrtKeySpec;

    .line 75
    invoke-virtual/range {p0 .. p0}, Lcom/google/crypto/tink/signature/RsaSsaPssPrivateKey;->getPublicKey()Lcom/google/crypto/tink/signature/RsaSsaPssPublicKey;

    move-result-object v2

    invoke-virtual {v2}, Lcom/google/crypto/tink/signature/RsaSsaPssPublicKey;->getModulus()Ljava/math/BigInteger;

    move-result-object v9

    .line 76
    invoke-virtual {v1}, Lcom/google/crypto/tink/signature/RsaSsaPssParameters;->getPublicExponent()Ljava/math/BigInteger;

    move-result-object v10

    .line 77
    invoke-virtual/range {p0 .. p0}, Lcom/google/crypto/tink/signature/RsaSsaPssPrivateKey;->getPrivateExponent()Lcom/google/crypto/tink/util/SecretBigInteger;

    move-result-object v2

    invoke-static {}, Lcom/google/crypto/tink/InsecureSecretKeyAccess;->get()Lcom/google/crypto/tink/SecretKeyAccess;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/google/crypto/tink/util/SecretBigInteger;->getBigInteger(Lcom/google/crypto/tink/SecretKeyAccess;)Ljava/math/BigInteger;

    move-result-object v11

    .line 78
    invoke-virtual/range {p0 .. p0}, Lcom/google/crypto/tink/signature/RsaSsaPssPrivateKey;->getPrimeP()Lcom/google/crypto/tink/util/SecretBigInteger;

    move-result-object v2

    invoke-static {}, Lcom/google/crypto/tink/InsecureSecretKeyAccess;->get()Lcom/google/crypto/tink/SecretKeyAccess;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/google/crypto/tink/util/SecretBigInteger;->getBigInteger(Lcom/google/crypto/tink/SecretKeyAccess;)Ljava/math/BigInteger;

    move-result-object v12

    .line 79
    invoke-virtual/range {p0 .. p0}, Lcom/google/crypto/tink/signature/RsaSsaPssPrivateKey;->getPrimeQ()Lcom/google/crypto/tink/util/SecretBigInteger;

    move-result-object v2

    invoke-static {}, Lcom/google/crypto/tink/InsecureSecretKeyAccess;->get()Lcom/google/crypto/tink/SecretKeyAccess;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/google/crypto/tink/util/SecretBigInteger;->getBigInteger(Lcom/google/crypto/tink/SecretKeyAccess;)Ljava/math/BigInteger;

    move-result-object v13

    .line 80
    invoke-virtual/range {p0 .. p0}, Lcom/google/crypto/tink/signature/RsaSsaPssPrivateKey;->getPrimeExponentP()Lcom/google/crypto/tink/util/SecretBigInteger;

    move-result-object v2

    invoke-static {}, Lcom/google/crypto/tink/InsecureSecretKeyAccess;->get()Lcom/google/crypto/tink/SecretKeyAccess;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/google/crypto/tink/util/SecretBigInteger;->getBigInteger(Lcom/google/crypto/tink/SecretKeyAccess;)Ljava/math/BigInteger;

    move-result-object v14

    .line 81
    invoke-virtual/range {p0 .. p0}, Lcom/google/crypto/tink/signature/RsaSsaPssPrivateKey;->getPrimeExponentQ()Lcom/google/crypto/tink/util/SecretBigInteger;

    move-result-object v2

    invoke-static {}, Lcom/google/crypto/tink/InsecureSecretKeyAccess;->get()Lcom/google/crypto/tink/SecretKeyAccess;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/google/crypto/tink/util/SecretBigInteger;->getBigInteger(Lcom/google/crypto/tink/SecretKeyAccess;)Ljava/math/BigInteger;

    move-result-object v15

    .line 82
    invoke-virtual/range {p0 .. p0}, Lcom/google/crypto/tink/signature/RsaSsaPssPrivateKey;->getCrtCoefficient()Lcom/google/crypto/tink/util/SecretBigInteger;

    move-result-object v2

    invoke-static {}, Lcom/google/crypto/tink/InsecureSecretKeyAccess;->get()Lcom/google/crypto/tink/SecretKeyAccess;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/google/crypto/tink/util/SecretBigInteger;->getBigInteger(Lcom/google/crypto/tink/SecretKeyAccess;)Ljava/math/BigInteger;

    move-result-object v16

    invoke-direct/range {v8 .. v16}, Ljava/security/spec/RSAPrivateCrtKeySpec;-><init>(Ljava/math/BigInteger;Ljava/math/BigInteger;Ljava/math/BigInteger;Ljava/math/BigInteger;Ljava/math/BigInteger;Ljava/math/BigInteger;Ljava/math/BigInteger;Ljava/math/BigInteger;)V

    .line 73
    invoke-virtual {v0, v8}, Ljava/security/KeyFactory;->generatePrivate(Ljava/security/spec/KeySpec;)Ljava/security/PrivateKey;

    move-result-object v0

    check-cast v0, Ljava/security/interfaces/RSAPrivateCrtKey;

    move-object v2, v1

    move-object v1, v0

    .line 83
    new-instance v0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;

    move-object v3, v2

    .line 85
    invoke-virtual {v3}, Lcom/google/crypto/tink/signature/RsaSsaPssParameters;->getSigHashType()Lcom/google/crypto/tink/signature/RsaSsaPssParameters$HashType;

    move-result-object v2

    move-object v4, v3

    .line 86
    invoke-virtual {v4}, Lcom/google/crypto/tink/signature/RsaSsaPssParameters;->getMgf1HashType()Lcom/google/crypto/tink/signature/RsaSsaPssParameters$HashType;

    move-result-object v3

    move-object v5, v4

    .line 87
    invoke-virtual {v5}, Lcom/google/crypto/tink/signature/RsaSsaPssParameters;->getSaltLengthBytes()I

    move-result v4

    .line 88
    invoke-virtual/range {p0 .. p0}, Lcom/google/crypto/tink/signature/SignaturePrivateKey;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

    move-result-object v6

    invoke-virtual {v6}, Lcom/google/crypto/tink/util/Bytes;->toByteArray()[B

    move-result-object v6

    .line 89
    invoke-virtual {v5}, Lcom/google/crypto/tink/signature/RsaSsaPssParameters;->getVariant()Lcom/google/crypto/tink/signature/RsaSsaPssParameters$Variant;

    move-result-object v5

    sget-object v8, Lcom/google/crypto/tink/signature/RsaSsaPssParameters$Variant;->LEGACY:Lcom/google/crypto/tink/signature/RsaSsaPssParameters$Variant;

    invoke-virtual {v5, v8}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 90
    sget-object v5, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->LEGACY_MESSAGE_SUFFIX:[B

    :goto_0
    move-object/from16 v17, v6

    move-object v6, v5

    move-object/from16 v5, v17

    goto :goto_1

    .line 91
    :cond_0
    sget-object v5, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->EMPTY:[B

    goto :goto_0

    :goto_1
    invoke-direct/range {v0 .. v7}, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;-><init>(Ljava/security/interfaces/RSAPrivateCrtKey;Lcom/google/crypto/tink/signature/RsaSsaPssParameters$HashType;Lcom/google/crypto/tink/signature/RsaSsaPssParameters$HashType;I[B[BLjava/security/Provider;)V

    return-object v0

    .line 67
    :cond_1
    new-instance v0, Ljava/security/NoSuchProviderException;

    const-string v1, "RSA SSA PSS using Conscrypt is not supported."

    invoke-direct {v0, v1}, Ljava/security/NoSuchProviderException;-><init>(Ljava/lang/String;)V

    throw v0
.end method


# virtual methods
.method public sign([B)[B
    .locals 2

    .line 121
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->signatureAlgorithm:Ljava/lang/String;

    iget-object v1, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->conscrypt:Ljava/security/Provider;

    invoke-static {v0, v1}, Ljava/security/Signature;->getInstance(Ljava/lang/String;Ljava/security/Provider;)Ljava/security/Signature;

    move-result-object v0

    .line 122
    iget-object v1, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->privateKey:Ljava/security/interfaces/RSAPrivateCrtKey;

    invoke-virtual {v0, v1}, Ljava/security/Signature;->initSign(Ljava/security/PrivateKey;)V

    .line 123
    iget-object v1, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->parameterSpec:Ljava/security/spec/PSSParameterSpec;

    invoke-virtual {v0, v1}, Ljava/security/Signature;->setParameter(Ljava/security/spec/AlgorithmParameterSpec;)V

    .line 124
    invoke-virtual {v0, p1}, Ljava/security/Signature;->update([B)V

    .line 125
    iget-object p1, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->messageSuffix:[B

    array-length v1, p1

    if-lez v1, :cond_0

    .line 126
    invoke-virtual {v0, p1}, Ljava/security/Signature;->update([B)V

    .line 128
    :cond_0
    invoke-virtual {v0}, Ljava/security/Signature;->sign()[B

    move-result-object p1

    .line 129
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/RsaSsaPssSignConscrypt;->outputPrefix:[B

    array-length v1, v0

    if-nez v1, :cond_1

    return-object p1

    .line 132
    :cond_1
    filled-new-array {v0, p1}, [[B

    move-result-object p1

    invoke-static {p1}, Lcom/google/crypto/tink/subtle/Bytes;->concat([[B)[B

    move-result-object p1

    return-object p1
.end method
