.class public final Lcom/google/crypto/tink/signature/internal/LegacyFullSign;
.super Ljava/lang/Object;
.source "LegacyFullSign.java"

# interfaces
.implements Lcom/google/crypto/tink/PublicKeySign;


# annotations
.annotation runtime Lcom/google/errorprone/annotations/Immutable;
.end annotation


# instance fields
.field private final messageSuffix:[B

.field private final outputPrefix:[B

.field private final rawSigner:Lcom/google/crypto/tink/PublicKeySign;


# direct methods
.method private constructor <init>(Lcom/google/crypto/tink/PublicKeySign;[B[B)V
    .locals 0

    .line 53
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 54
    iput-object p1, p0, Lcom/google/crypto/tink/signature/internal/LegacyFullSign;->rawSigner:Lcom/google/crypto/tink/PublicKeySign;

    .line 55
    iput-object p2, p0, Lcom/google/crypto/tink/signature/internal/LegacyFullSign;->outputPrefix:[B

    .line 56
    iput-object p3, p0, Lcom/google/crypto/tink/signature/internal/LegacyFullSign;->messageSuffix:[B

    return-void
.end method

.method public static create(Lcom/google/crypto/tink/internal/LegacyProtoKey;)Lcom/google/crypto/tink/PublicKeySign;
    .locals 3

    .line 38
    invoke-static {}, Lcom/google/crypto/tink/InsecureSecretKeyAccess;->get()Lcom/google/crypto/tink/SecretKeyAccess;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/google/crypto/tink/internal/LegacyProtoKey;->getSerialization(Lcom/google/crypto/tink/SecretKeyAccess;)Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    move-result-object p0

    .line 40
    invoke-static {}, Lcom/google/crypto/tink/proto/KeyData;->newBuilder()Lcom/google/crypto/tink/proto/KeyData$Builder;

    move-result-object v0

    .line 41
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getTypeUrl()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/proto/KeyData$Builder;->setTypeUrl(Ljava/lang/String;)Lcom/google/crypto/tink/proto/KeyData$Builder;

    move-result-object v0

    .line 42
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getValue()Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/proto/KeyData$Builder;->setValue(Lcom/google/crypto/tink/shaded/protobuf/ByteString;)Lcom/google/crypto/tink/proto/KeyData$Builder;

    move-result-object v0

    .line 43
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getKeyMaterialType()Lcom/google/crypto/tink/proto/KeyData$KeyMaterialType;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/proto/KeyData$Builder;->setKeyMaterialType(Lcom/google/crypto/tink/proto/KeyData$KeyMaterialType;)Lcom/google/crypto/tink/proto/KeyData$Builder;

    move-result-object v0

    .line 44
    invoke-virtual {v0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->build()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/proto/KeyData;

    .line 45
    const-class v1, Lcom/google/crypto/tink/PublicKeySign;

    invoke-static {v0, v1}, Lcom/google/crypto/tink/Registry;->getPrimitive(Lcom/google/crypto/tink/proto/KeyData;Ljava/lang/Class;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/PublicKeySign;

    .line 47
    new-instance v1, Lcom/google/crypto/tink/signature/internal/LegacyFullSign;

    .line 49
    invoke-static {p0}, Lcom/google/crypto/tink/signature/internal/LegacyFullVerify;->getOutputPrefix(Lcom/google/crypto/tink/internal/ProtoKeySerialization;)[B

    move-result-object v2

    .line 50
    invoke-static {p0}, Lcom/google/crypto/tink/signature/internal/LegacyFullVerify;->getMessageSuffix(Lcom/google/crypto/tink/internal/ProtoKeySerialization;)[B

    move-result-object p0

    invoke-direct {v1, v0, v2, p0}, Lcom/google/crypto/tink/signature/internal/LegacyFullSign;-><init>(Lcom/google/crypto/tink/PublicKeySign;[B[B)V

    return-object v1
.end method


# virtual methods
.method public sign([B)[B
    .locals 2

    .line 71
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/LegacyFullSign;->messageSuffix:[B

    array-length v1, v0

    if-nez v1, :cond_0

    .line 72
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/LegacyFullSign;->rawSigner:Lcom/google/crypto/tink/PublicKeySign;

    invoke-interface {v0, p1}, Lcom/google/crypto/tink/PublicKeySign;->sign([B)[B

    move-result-object p1

    goto :goto_0

    .line 74
    :cond_0
    iget-object v1, p0, Lcom/google/crypto/tink/signature/internal/LegacyFullSign;->rawSigner:Lcom/google/crypto/tink/PublicKeySign;

    filled-new-array {p1, v0}, [[B

    move-result-object p1

    invoke-static {p1}, Lcom/google/crypto/tink/subtle/Bytes;->concat([[B)[B

    move-result-object p1

    invoke-interface {v1, p1}, Lcom/google/crypto/tink/PublicKeySign;->sign([B)[B

    move-result-object p1

    .line 76
    :goto_0
    iget-object v0, p0, Lcom/google/crypto/tink/signature/internal/LegacyFullSign;->outputPrefix:[B

    array-length v1, v0

    if-nez v1, :cond_1

    return-object p1

    .line 79
    :cond_1
    filled-new-array {v0, p1}, [[B

    move-result-object p1

    invoke-static {p1}, Lcom/google/crypto/tink/subtle/Bytes;->concat([[B)[B

    move-result-object p1

    return-object p1
.end method
