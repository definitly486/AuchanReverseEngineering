.class public Lcom/google/crypto/tink/mac/ChunkedMacWrapper;
.super Ljava/lang/Object;
.source "ChunkedMacWrapper.java"

# interfaces
.implements Lcom/google/crypto/tink/internal/PrimitiveWrapper;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/mac/ChunkedMacWrapper$WrappedChunkedMac;,
        Lcom/google/crypto/tink/mac/ChunkedMacWrapper$WrappedChunkedMacVerification;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/crypto/tink/internal/PrimitiveWrapper<",
        "Lcom/google/crypto/tink/mac/ChunkedMac;",
        "Lcom/google/crypto/tink/mac/ChunkedMac;",
        ">;"
    }
.end annotation


# static fields
.field private static final WRAPPER:Lcom/google/crypto/tink/mac/ChunkedMacWrapper;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 45
    new-instance v0, Lcom/google/crypto/tink/mac/ChunkedMacWrapper;

    invoke-direct {v0}, Lcom/google/crypto/tink/mac/ChunkedMacWrapper;-><init>()V

    sput-object v0, Lcom/google/crypto/tink/mac/ChunkedMacWrapper;->WRAPPER:Lcom/google/crypto/tink/mac/ChunkedMacWrapper;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 131
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static getOutputPrefix(Lcom/google/crypto/tink/Key;)Lcom/google/crypto/tink/util/Bytes;
    .locals 3

    .line 48
    instance-of v0, p0, Lcom/google/crypto/tink/mac/MacKey;

    if-eqz v0, :cond_0

    .line 49
    check-cast p0, Lcom/google/crypto/tink/mac/MacKey;

    invoke-virtual {p0}, Lcom/google/crypto/tink/mac/MacKey;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

    move-result-object p0

    return-object p0

    .line 51
    :cond_0
    instance-of v0, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    if-eqz v0, :cond_1

    .line 52
    check-cast p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/LegacyProtoKey;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

    move-result-object p0

    return-object p0

    .line 54
    :cond_1
    new-instance v0, Ljava/security/GeneralSecurityException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Cannot get output prefix for key of class "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 56
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, " with parameters "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 58
    invoke-virtual {p0}, Lcom/google/crypto/tink/Key;->getParameters()Lcom/google/crypto/tink/Parameters;

    move-result-object p0

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method static register()V
    .locals 2

    .line 166
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/mac/ChunkedMacWrapper;->WRAPPER:Lcom/google/crypto/tink/mac/ChunkedMacWrapper;

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveWrapper(Lcom/google/crypto/tink/internal/PrimitiveWrapper;)V

    return-void
.end method

.method public static registerToInternalPrimitiveRegistry(Lcom/google/crypto/tink/internal/PrimitiveRegistry$Builder;)V
    .locals 1

    .line 176
    sget-object v0, Lcom/google/crypto/tink/mac/ChunkedMacWrapper;->WRAPPER:Lcom/google/crypto/tink/mac/ChunkedMacWrapper;

    invoke-virtual {p0, v0}, Lcom/google/crypto/tink/internal/PrimitiveRegistry$Builder;->registerPrimitiveWrapper(Lcom/google/crypto/tink/internal/PrimitiveWrapper;)Lcom/google/crypto/tink/internal/PrimitiveRegistry$Builder;

    return-void
.end method


# virtual methods
.method public getInputPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/mac/ChunkedMac;",
            ">;"
        }
    .end annotation

    .line 162
    const-class v0, Lcom/google/crypto/tink/mac/ChunkedMac;

    return-object v0
.end method

.method public getPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/mac/ChunkedMac;",
            ">;"
        }
    .end annotation

    .line 157
    const-class v0, Lcom/google/crypto/tink/mac/ChunkedMac;

    return-object v0
.end method

.method public wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/mac/ChunkedMac;
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "Lcom/google/crypto/tink/mac/ChunkedMac;",
            ">;)",
            "Lcom/google/crypto/tink/mac/ChunkedMac;"
        }
    .end annotation

    if-eqz p1, :cond_2

    .line 139
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object v0

    .line 140
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v1

    if-eqz v1, :cond_1

    .line 144
    new-instance v2, Lcom/google/crypto/tink/internal/PrefixMap$Builder;

    invoke-direct {v2}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;-><init>()V

    const/4 v3, 0x0

    .line 145
    :goto_0
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->size()I

    move-result v4

    if-ge v3, v4, :cond_0

    .line 146
    invoke-interface {v0, v3}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getAt(I)Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v4

    .line 147
    invoke-virtual {p1, v4}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/google/crypto/tink/mac/ChunkedMac;

    .line 148
    invoke-interface {v4}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getKey()Lcom/google/crypto/tink/Key;

    move-result-object v4

    invoke-static {v4}, Lcom/google/crypto/tink/mac/ChunkedMacWrapper;->getOutputPrefix(Lcom/google/crypto/tink/Key;)Lcom/google/crypto/tink/util/Bytes;

    move-result-object v4

    invoke-virtual {v2, v4, v5}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;->put(Lcom/google/crypto/tink/util/Bytes;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/PrefixMap$Builder;

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 150
    :cond_0
    invoke-virtual {p1, v1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/crypto/tink/mac/ChunkedMac;

    .line 152
    new-instance v0, Lcom/google/crypto/tink/mac/ChunkedMacWrapper$WrappedChunkedMac;

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;->build()Lcom/google/crypto/tink/internal/PrefixMap;

    move-result-object v1

    const/4 v2, 0x0

    invoke-direct {v0, v1, p1, v2}, Lcom/google/crypto/tink/mac/ChunkedMacWrapper$WrappedChunkedMac;-><init>(Lcom/google/crypto/tink/internal/PrefixMap;Lcom/google/crypto/tink/mac/ChunkedMac;Lcom/google/crypto/tink/mac/ChunkedMacWrapper$1;)V

    return-object v0

    .line 142
    :cond_1
    new-instance p1, Ljava/security/GeneralSecurityException;

    const-string v0, "no primary in primitive set"

    invoke-direct {p1, v0}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 137
    :cond_2
    new-instance p1, Ljava/security/GeneralSecurityException;

    const-string v0, "primitive set must be non-null"

    invoke-direct {p1, v0}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/lang/Object;
    .locals 0

    .line 43
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/mac/ChunkedMacWrapper;->wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/mac/ChunkedMac;

    move-result-object p1

    return-object p1
.end method
