.class public final Lcom/google/crypto/tink/internal/LegacyProtoKey;
.super Lcom/google/crypto/tink/Key;
.source "LegacyProtoKey.java"


# annotations
.annotation runtime Lcom/google/errorprone/annotations/Immutable;
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/internal/LegacyProtoKey$LegacyProtoParametersNotForCreation;
    }
.end annotation


# instance fields
.field private final outputPrefix:Lcom/google/crypto/tink/util/Bytes;

.field private final serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;


# direct methods
.method public constructor <init>(Lcom/google/crypto/tink/internal/ProtoKeySerialization;Lcom/google/crypto/tink/SecretKeyAccess;)V
    .locals 0

    .line 115
    invoke-direct {p0}, Lcom/google/crypto/tink/Key;-><init>()V

    .line 116
    invoke-static {p1, p2}, Lcom/google/crypto/tink/internal/LegacyProtoKey;->throwIfMissingAccess(Lcom/google/crypto/tink/internal/ProtoKeySerialization;Lcom/google/crypto/tink/SecretKeyAccess;)V

    .line 117
    iput-object p1, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    .line 118
    invoke-static {p1}, Lcom/google/crypto/tink/internal/LegacyProtoKey;->computeOutputPrefix(Lcom/google/crypto/tink/internal/ProtoKeySerialization;)Lcom/google/crypto/tink/util/Bytes;

    move-result-object p1

    iput-object p1, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->outputPrefix:Lcom/google/crypto/tink/util/Bytes;

    return-void
.end method

.method private static computeOutputPrefix(Lcom/google/crypto/tink/internal/ProtoKeySerialization;)Lcom/google/crypto/tink/util/Bytes;
    .locals 2

    .line 96
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getOutputPrefixType()Lcom/google/crypto/tink/proto/OutputPrefixType;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/proto/OutputPrefixType;->RAW:Lcom/google/crypto/tink/proto/OutputPrefixType;

    invoke-virtual {v0, v1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 p0, 0x0

    .line 97
    new-array p0, p0, [B

    invoke-static {p0}, Lcom/google/crypto/tink/util/Bytes;->copyFrom([B)Lcom/google/crypto/tink/util/Bytes;

    move-result-object p0

    return-object p0

    .line 99
    :cond_0
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getOutputPrefixType()Lcom/google/crypto/tink/proto/OutputPrefixType;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/proto/OutputPrefixType;->TINK:Lcom/google/crypto/tink/proto/OutputPrefixType;

    invoke-virtual {v0, v1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 100
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getIdRequirementOrNull()Ljava/lang/Integer;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Integer;->intValue()I

    move-result p0

    invoke-static {p0}, Lcom/google/crypto/tink/internal/OutputPrefixUtil;->getTinkOutputPrefix(I)Lcom/google/crypto/tink/util/Bytes;

    move-result-object p0

    return-object p0

    .line 102
    :cond_1
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getOutputPrefixType()Lcom/google/crypto/tink/proto/OutputPrefixType;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/proto/OutputPrefixType;->LEGACY:Lcom/google/crypto/tink/proto/OutputPrefixType;

    invoke-virtual {v0, v1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_3

    .line 103
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getOutputPrefixType()Lcom/google/crypto/tink/proto/OutputPrefixType;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/proto/OutputPrefixType;->CRUNCHY:Lcom/google/crypto/tink/proto/OutputPrefixType;

    invoke-virtual {v0, v1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    goto :goto_0

    .line 106
    :cond_2
    new-instance p0, Ljava/security/GeneralSecurityException;

    const-string v0, "Unknown output prefix type"

    invoke-direct {p0, v0}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 104
    :cond_3
    :goto_0
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getIdRequirementOrNull()Ljava/lang/Integer;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Integer;->intValue()I

    move-result p0

    invoke-static {p0}, Lcom/google/crypto/tink/internal/OutputPrefixUtil;->getLegacyOutputPrefix(I)Lcom/google/crypto/tink/util/Bytes;

    move-result-object p0

    return-object p0
.end method

.method private static throwIfMissingAccess(Lcom/google/crypto/tink/internal/ProtoKeySerialization;Lcom/google/crypto/tink/SecretKeyAccess;)V
    .locals 1

    .line 85
    sget-object v0, Lcom/google/crypto/tink/internal/LegacyProtoKey$1;->$SwitchMap$com$google$crypto$tink$proto$KeyData$KeyMaterialType:[I

    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getKeyMaterialType()Lcom/google/crypto/tink/proto/KeyData$KeyMaterialType;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Enum;->ordinal()I

    move-result p0

    aget p0, v0, p0

    const/4 v0, 0x1

    if-eq p0, v0, :cond_0

    const/4 v0, 0x2

    if-eq p0, v0, :cond_0

    return-void

    .line 88
    :cond_0
    invoke-static {p1}, Lcom/google/crypto/tink/SecretKeyAccess;->requireAccess(Lcom/google/crypto/tink/SecretKeyAccess;)Lcom/google/crypto/tink/SecretKeyAccess;

    return-void
.end method


# virtual methods
.method public equalsKey(Lcom/google/crypto/tink/Key;)Z
    .locals 3

    .line 135
    instance-of v0, p1, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    .line 138
    :cond_0
    check-cast p1, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    iget-object p1, p1, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    .line 140
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getOutputPrefixType()Lcom/google/crypto/tink/proto/OutputPrefixType;

    move-result-object v0

    iget-object v2, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getOutputPrefixType()Lcom/google/crypto/tink/proto/OutputPrefixType;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    return v1

    .line 143
    :cond_1
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getKeyMaterialType()Lcom/google/crypto/tink/proto/KeyData$KeyMaterialType;

    move-result-object v0

    iget-object v2, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getKeyMaterialType()Lcom/google/crypto/tink/proto/KeyData$KeyMaterialType;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_2

    return v1

    .line 146
    :cond_2
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getTypeUrl()Ljava/lang/String;

    move-result-object v0

    iget-object v2, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getTypeUrl()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_3

    return v1

    .line 149
    :cond_3
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getIdRequirementOrNull()Ljava/lang/Integer;

    move-result-object v0

    iget-object v2, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getIdRequirementOrNull()Ljava/lang/Integer;

    move-result-object v2

    invoke-static {v0, v2}, Ljava/util/Objects;->equals(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_4

    return v1

    .line 152
    :cond_4
    iget-object v0, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    .line 153
    invoke-virtual {v0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getValue()Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/crypto/tink/shaded/protobuf/ByteString;->toByteArray()[B

    move-result-object v0

    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getValue()Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    move-result-object p1

    invoke-virtual {p1}, Lcom/google/crypto/tink/shaded/protobuf/ByteString;->toByteArray()[B

    move-result-object p1

    .line 152
    invoke-static {v0, p1}, Lcom/google/crypto/tink/subtle/Bytes;->equal([B[B)Z

    move-result p1

    return p1
.end method

.method public getIdRequirementOrNull()Ljava/lang/Integer;
    .locals 1

    .line 159
    iget-object v0, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    invoke-virtual {v0}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getIdRequirementOrNull()Ljava/lang/Integer;

    move-result-object v0

    return-object v0
.end method

.method public getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;
    .locals 1

    .line 186
    iget-object v0, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->outputPrefix:Lcom/google/crypto/tink/util/Bytes;

    return-object v0
.end method

.method public getParameters()Lcom/google/crypto/tink/Parameters;
    .locals 4

    .line 181
    new-instance v0, Lcom/google/crypto/tink/internal/LegacyProtoKey$LegacyProtoParametersNotForCreation;

    iget-object v1, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    .line 182
    invoke-virtual {v1}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getTypeUrl()Ljava/lang/String;

    move-result-object v1

    iget-object v2, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/ProtoKeySerialization;->getOutputPrefixType()Lcom/google/crypto/tink/proto/OutputPrefixType;

    move-result-object v2

    const/4 v3, 0x0

    invoke-direct {v0, v1, v2, v3}, Lcom/google/crypto/tink/internal/LegacyProtoKey$LegacyProtoParametersNotForCreation;-><init>(Ljava/lang/String;Lcom/google/crypto/tink/proto/OutputPrefixType;Lcom/google/crypto/tink/internal/LegacyProtoKey$1;)V

    return-object v0
.end method

.method public getSerialization(Lcom/google/crypto/tink/SecretKeyAccess;)Lcom/google/crypto/tink/internal/ProtoKeySerialization;
    .locals 1

    .line 169
    iget-object v0, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    invoke-static {v0, p1}, Lcom/google/crypto/tink/internal/LegacyProtoKey;->throwIfMissingAccess(Lcom/google/crypto/tink/internal/ProtoKeySerialization;Lcom/google/crypto/tink/SecretKeyAccess;)V

    .line 170
    iget-object p1, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;->serialization:Lcom/google/crypto/tink/internal/ProtoKeySerialization;

    return-object p1
.end method
