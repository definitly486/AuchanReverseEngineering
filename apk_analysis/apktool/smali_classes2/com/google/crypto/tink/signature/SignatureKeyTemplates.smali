.class public final Lcom/google/crypto/tink/signature/SignatureKeyTemplates;
.super Ljava/lang/Object;
.source "SignatureKeyTemplates.java"


# static fields
.field public static final ECDSA_P256:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final ECDSA_P256_IEEE_P1363:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final ECDSA_P256_IEEE_P1363_WITHOUT_PREFIX:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final ECDSA_P384:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final ECDSA_P384_IEEE_P1363:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final ECDSA_P521:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final ECDSA_P521_IEEE_P1363:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final ED25519:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final ED25519WithRawOutput:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final RSA_SSA_PKCS1_3072_SHA256_F4:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final RSA_SSA_PKCS1_3072_SHA256_F4_WITHOUT_PREFIX:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final RSA_SSA_PKCS1_4096_SHA512_F4:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final RSA_SSA_PSS_3072_SHA256_SHA256_32_F4:Lcom/google/crypto/tink/proto/KeyTemplate;

.field public static final RSA_SSA_PSS_4096_SHA512_SHA512_64_F4:Lcom/google/crypto/tink/proto/KeyTemplate;


# direct methods
.method static constructor <clinit>()V
    .locals 8

    .line 79
    sget-object v0, Lcom/google/crypto/tink/proto/HashType;->SHA256:Lcom/google/crypto/tink/proto/HashType;

    sget-object v1, Lcom/google/crypto/tink/proto/EllipticCurveType;->NIST_P256:Lcom/google/crypto/tink/proto/EllipticCurveType;

    sget-object v2, Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;->DER:Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;

    sget-object v3, Lcom/google/crypto/tink/proto/OutputPrefixType;->TINK:Lcom/google/crypto/tink/proto/OutputPrefixType;

    .line 80
    invoke-static {v0, v1, v2, v3}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createEcdsaKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/EllipticCurveType;Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v4

    sput-object v4, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->ECDSA_P256:Lcom/google/crypto/tink/proto/KeyTemplate;

    .line 97
    sget-object v4, Lcom/google/crypto/tink/proto/HashType;->SHA512:Lcom/google/crypto/tink/proto/HashType;

    sget-object v5, Lcom/google/crypto/tink/proto/EllipticCurveType;->NIST_P384:Lcom/google/crypto/tink/proto/EllipticCurveType;

    .line 98
    invoke-static {v4, v5, v2, v3}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createEcdsaKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/EllipticCurveType;Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v6

    sput-object v6, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->ECDSA_P384:Lcom/google/crypto/tink/proto/KeyTemplate;

    .line 115
    sget-object v6, Lcom/google/crypto/tink/proto/EllipticCurveType;->NIST_P521:Lcom/google/crypto/tink/proto/EllipticCurveType;

    .line 116
    invoke-static {v4, v6, v2, v3}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createEcdsaKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/EllipticCurveType;Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v2

    sput-object v2, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->ECDSA_P521:Lcom/google/crypto/tink/proto/KeyTemplate;

    .line 133
    sget-object v2, Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;->IEEE_P1363:Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;

    .line 134
    invoke-static {v0, v1, v2, v3}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createEcdsaKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/EllipticCurveType;Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v7

    sput-object v7, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->ECDSA_P256_IEEE_P1363:Lcom/google/crypto/tink/proto/KeyTemplate;

    .line 152
    invoke-static {v4, v5, v2, v3}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createEcdsaKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/EllipticCurveType;Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v5

    sput-object v5, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->ECDSA_P384_IEEE_P1363:Lcom/google/crypto/tink/proto/KeyTemplate;

    .line 171
    sget-object v5, Lcom/google/crypto/tink/proto/OutputPrefixType;->RAW:Lcom/google/crypto/tink/proto/OutputPrefixType;

    .line 172
    invoke-static {v0, v1, v2, v5}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createEcdsaKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/EllipticCurveType;Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v1

    sput-object v1, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->ECDSA_P256_IEEE_P1363_WITHOUT_PREFIX:Lcom/google/crypto/tink/proto/KeyTemplate;

    .line 190
    invoke-static {v4, v6, v2, v3}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createEcdsaKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/EllipticCurveType;Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v1

    sput-object v1, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->ECDSA_P521_IEEE_P1363:Lcom/google/crypto/tink/proto/KeyTemplate;

    .line 203
    invoke-static {}, Lcom/google/crypto/tink/proto/KeyTemplate;->newBuilder()Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object v1

    .line 204
    invoke-static {}, Lcom/google/crypto/tink/signature/Ed25519PrivateKeyManager;->getKeyType()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setTypeUrl(Ljava/lang/String;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object v1

    .line 205
    invoke-virtual {v1, v3}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setOutputPrefixType(Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object v1

    .line 206
    invoke-virtual {v1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object v1

    check-cast v1, Lcom/google/crypto/tink/proto/KeyTemplate;

    sput-object v1, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->ED25519:Lcom/google/crypto/tink/proto/KeyTemplate;

    .line 219
    invoke-static {}, Lcom/google/crypto/tink/proto/KeyTemplate;->newBuilder()Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object v1

    .line 220
    invoke-static {}, Lcom/google/crypto/tink/signature/Ed25519PrivateKeyManager;->getKeyType()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setTypeUrl(Ljava/lang/String;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object v1

    .line 221
    invoke-virtual {v1, v5}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setOutputPrefixType(Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object v1

    .line 222
    invoke-virtual {v1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object v1

    check-cast v1, Lcom/google/crypto/tink/proto/KeyTemplate;

    sput-object v1, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->ED25519WithRawOutput:Lcom/google/crypto/tink/proto/KeyTemplate;

    .line 260
    sget-object v1, Ljava/security/spec/RSAKeyGenParameterSpec;->F4:Ljava/math/BigInteger;

    const/16 v2, 0xc00

    .line 261
    invoke-static {v0, v2, v1, v3}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createRsaSsaPkcs1KeyTemplate(Lcom/google/crypto/tink/proto/HashType;ILjava/math/BigInteger;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v6

    sput-object v6, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->RSA_SSA_PKCS1_3072_SHA256_F4:Lcom/google/crypto/tink/proto/KeyTemplate;

    .line 276
    invoke-static {v0, v2, v1, v5}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createRsaSsaPkcs1KeyTemplate(Lcom/google/crypto/tink/proto/HashType;ILjava/math/BigInteger;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v5

    sput-object v5, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->RSA_SSA_PKCS1_3072_SHA256_F4_WITHOUT_PREFIX:Lcom/google/crypto/tink/proto/KeyTemplate;

    const/16 v5, 0x1000

    .line 291
    invoke-static {v4, v5, v1, v3}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createRsaSsaPkcs1KeyTemplate(Lcom/google/crypto/tink/proto/HashType;ILjava/math/BigInteger;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v3

    sput-object v3, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->RSA_SSA_PKCS1_4096_SHA512_F4:Lcom/google/crypto/tink/proto/KeyTemplate;

    const/16 v3, 0x20

    .line 329
    invoke-static {v0, v0, v3, v2, v1}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createRsaSsaPssKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/HashType;IILjava/math/BigInteger;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v0

    sput-object v0, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->RSA_SSA_PSS_3072_SHA256_SHA256_32_F4:Lcom/google/crypto/tink/proto/KeyTemplate;

    const/16 v0, 0x40

    .line 345
    invoke-static {v4, v4, v0, v5, v1}, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->createRsaSsaPssKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/HashType;IILjava/math/BigInteger;)Lcom/google/crypto/tink/proto/KeyTemplate;

    move-result-object v0

    sput-object v0, Lcom/google/crypto/tink/signature/SignatureKeyTemplates;->RSA_SSA_PSS_4096_SHA512_SHA512_64_F4:Lcom/google/crypto/tink/proto/KeyTemplate;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 379
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static createEcdsaKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/EllipticCurveType;Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 236
    invoke-static {}, Lcom/google/crypto/tink/proto/EcdsaParams;->newBuilder()Lcom/google/crypto/tink/proto/EcdsaParams$Builder;

    move-result-object v0

    .line 237
    invoke-virtual {v0, p0}, Lcom/google/crypto/tink/proto/EcdsaParams$Builder;->setHashType(Lcom/google/crypto/tink/proto/HashType;)Lcom/google/crypto/tink/proto/EcdsaParams$Builder;

    move-result-object p0

    .line 238
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/proto/EcdsaParams$Builder;->setCurve(Lcom/google/crypto/tink/proto/EllipticCurveType;)Lcom/google/crypto/tink/proto/EcdsaParams$Builder;

    move-result-object p0

    .line 239
    invoke-virtual {p0, p2}, Lcom/google/crypto/tink/proto/EcdsaParams$Builder;->setEncoding(Lcom/google/crypto/tink/proto/EcdsaSignatureEncoding;)Lcom/google/crypto/tink/proto/EcdsaParams$Builder;

    move-result-object p0

    .line 240
    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/EcdsaParams;

    .line 241
    invoke-static {}, Lcom/google/crypto/tink/proto/EcdsaKeyFormat;->newBuilder()Lcom/google/crypto/tink/proto/EcdsaKeyFormat$Builder;

    move-result-object p1

    invoke-virtual {p1, p0}, Lcom/google/crypto/tink/proto/EcdsaKeyFormat$Builder;->setParams(Lcom/google/crypto/tink/proto/EcdsaParams;)Lcom/google/crypto/tink/proto/EcdsaKeyFormat$Builder;

    move-result-object p0

    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/EcdsaKeyFormat;

    .line 242
    invoke-static {}, Lcom/google/crypto/tink/proto/KeyTemplate;->newBuilder()Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p1

    .line 243
    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/AbstractMessageLite;->toByteString()Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    move-result-object p0

    invoke-virtual {p1, p0}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setValue(Lcom/google/crypto/tink/shaded/protobuf/ByteString;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p0

    .line 244
    invoke-static {}, Lcom/google/crypto/tink/signature/EcdsaSignKeyManager;->getKeyType()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setTypeUrl(Ljava/lang/String;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p0

    .line 245
    invoke-virtual {p0, p3}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setOutputPrefixType(Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p0

    .line 246
    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KeyTemplate;

    return-object p0
.end method

.method public static createRsaSsaPkcs1KeyTemplate(Lcom/google/crypto/tink/proto/HashType;ILjava/math/BigInteger;Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 302
    invoke-static {}, Lcom/google/crypto/tink/proto/RsaSsaPkcs1Params;->newBuilder()Lcom/google/crypto/tink/proto/RsaSsaPkcs1Params$Builder;

    move-result-object v0

    invoke-virtual {v0, p0}, Lcom/google/crypto/tink/proto/RsaSsaPkcs1Params$Builder;->setHashType(Lcom/google/crypto/tink/proto/HashType;)Lcom/google/crypto/tink/proto/RsaSsaPkcs1Params$Builder;

    move-result-object p0

    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/RsaSsaPkcs1Params;

    .line 304
    invoke-static {}, Lcom/google/crypto/tink/proto/RsaSsaPkcs1KeyFormat;->newBuilder()Lcom/google/crypto/tink/proto/RsaSsaPkcs1KeyFormat$Builder;

    move-result-object v0

    .line 305
    invoke-virtual {v0, p0}, Lcom/google/crypto/tink/proto/RsaSsaPkcs1KeyFormat$Builder;->setParams(Lcom/google/crypto/tink/proto/RsaSsaPkcs1Params;)Lcom/google/crypto/tink/proto/RsaSsaPkcs1KeyFormat$Builder;

    move-result-object p0

    .line 306
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/proto/RsaSsaPkcs1KeyFormat$Builder;->setModulusSizeInBits(I)Lcom/google/crypto/tink/proto/RsaSsaPkcs1KeyFormat$Builder;

    move-result-object p0

    .line 307
    invoke-virtual {p2}, Ljava/math/BigInteger;->toByteArray()[B

    move-result-object p1

    invoke-static {p1}, Lcom/google/crypto/tink/shaded/protobuf/ByteString;->copyFrom([B)Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/proto/RsaSsaPkcs1KeyFormat$Builder;->setPublicExponent(Lcom/google/crypto/tink/shaded/protobuf/ByteString;)Lcom/google/crypto/tink/proto/RsaSsaPkcs1KeyFormat$Builder;

    move-result-object p0

    .line 308
    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/RsaSsaPkcs1KeyFormat;

    .line 309
    invoke-static {}, Lcom/google/crypto/tink/proto/KeyTemplate;->newBuilder()Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p1

    .line 310
    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/AbstractMessageLite;->toByteString()Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    move-result-object p0

    invoke-virtual {p1, p0}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setValue(Lcom/google/crypto/tink/shaded/protobuf/ByteString;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p0

    .line 311
    invoke-static {}, Lcom/google/crypto/tink/signature/RsaSsaPkcs1SignKeyManager;->getKeyType()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setTypeUrl(Ljava/lang/String;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p0

    .line 312
    invoke-virtual {p0, p3}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setOutputPrefixType(Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p0

    .line 313
    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KeyTemplate;

    return-object p0
.end method

.method public static createRsaSsaPssKeyTemplate(Lcom/google/crypto/tink/proto/HashType;Lcom/google/crypto/tink/proto/HashType;IILjava/math/BigInteger;)Lcom/google/crypto/tink/proto/KeyTemplate;
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 361
    invoke-static {}, Lcom/google/crypto/tink/proto/RsaSsaPssParams;->newBuilder()Lcom/google/crypto/tink/proto/RsaSsaPssParams$Builder;

    move-result-object v0

    .line 362
    invoke-virtual {v0, p0}, Lcom/google/crypto/tink/proto/RsaSsaPssParams$Builder;->setSigHash(Lcom/google/crypto/tink/proto/HashType;)Lcom/google/crypto/tink/proto/RsaSsaPssParams$Builder;

    move-result-object p0

    .line 363
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/proto/RsaSsaPssParams$Builder;->setMgf1Hash(Lcom/google/crypto/tink/proto/HashType;)Lcom/google/crypto/tink/proto/RsaSsaPssParams$Builder;

    move-result-object p0

    .line 364
    invoke-virtual {p0, p2}, Lcom/google/crypto/tink/proto/RsaSsaPssParams$Builder;->setSaltLength(I)Lcom/google/crypto/tink/proto/RsaSsaPssParams$Builder;

    move-result-object p0

    .line 365
    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/RsaSsaPssParams;

    .line 367
    invoke-static {}, Lcom/google/crypto/tink/proto/RsaSsaPssKeyFormat;->newBuilder()Lcom/google/crypto/tink/proto/RsaSsaPssKeyFormat$Builder;

    move-result-object p1

    .line 368
    invoke-virtual {p1, p0}, Lcom/google/crypto/tink/proto/RsaSsaPssKeyFormat$Builder;->setParams(Lcom/google/crypto/tink/proto/RsaSsaPssParams;)Lcom/google/crypto/tink/proto/RsaSsaPssKeyFormat$Builder;

    move-result-object p0

    .line 369
    invoke-virtual {p0, p3}, Lcom/google/crypto/tink/proto/RsaSsaPssKeyFormat$Builder;->setModulusSizeInBits(I)Lcom/google/crypto/tink/proto/RsaSsaPssKeyFormat$Builder;

    move-result-object p0

    .line 370
    invoke-virtual {p4}, Ljava/math/BigInteger;->toByteArray()[B

    move-result-object p1

    invoke-static {p1}, Lcom/google/crypto/tink/shaded/protobuf/ByteString;->copyFrom([B)Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/proto/RsaSsaPssKeyFormat$Builder;->setPublicExponent(Lcom/google/crypto/tink/shaded/protobuf/ByteString;)Lcom/google/crypto/tink/proto/RsaSsaPssKeyFormat$Builder;

    move-result-object p0

    .line 371
    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/RsaSsaPssKeyFormat;

    .line 372
    invoke-static {}, Lcom/google/crypto/tink/proto/KeyTemplate;->newBuilder()Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p1

    .line 373
    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/AbstractMessageLite;->toByteString()Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    move-result-object p0

    invoke-virtual {p1, p0}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setValue(Lcom/google/crypto/tink/shaded/protobuf/ByteString;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p0

    .line 374
    invoke-static {}, Lcom/google/crypto/tink/signature/RsaSsaPssSignKeyManager;->getKeyType()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setTypeUrl(Ljava/lang/String;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p0

    sget-object p1, Lcom/google/crypto/tink/proto/OutputPrefixType;->TINK:Lcom/google/crypto/tink/proto/OutputPrefixType;

    .line 375
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/proto/KeyTemplate$Builder;->setOutputPrefixType(Lcom/google/crypto/tink/proto/OutputPrefixType;)Lcom/google/crypto/tink/proto/KeyTemplate$Builder;

    move-result-object p0

    .line 376
    invoke-virtual {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KeyTemplate;

    return-object p0
.end method
