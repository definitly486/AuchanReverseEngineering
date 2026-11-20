.class public Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;
.super Ljava/lang/Object;
.source "PublicKeyVerifyWrapper.java"

# interfaces
.implements Lcom/google/crypto/tink/internal/PrimitiveWrapper;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper$WrappedPublicKeyVerify;,
        Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper$PublicKeyVerifyWithId;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/crypto/tink/internal/PrimitiveWrapper<",
        "Lcom/google/crypto/tink/PublicKeyVerify;",
        "Lcom/google/crypto/tink/PublicKeyVerify;",
        ">;"
    }
.end annotation


# static fields
.field private static final LEGACY_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/internal/PrimitiveConstructor<",
            "Lcom/google/crypto/tink/internal/LegacyProtoKey;",
            "Lcom/google/crypto/tink/PublicKeyVerify;",
            ">;"
        }
    .end annotation
.end field

.field private static final WRAPPER:Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 57
    new-instance v0, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;

    invoke-direct {v0}, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;-><init>()V

    sput-object v0, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;->WRAPPER:Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;

    .line 59
    new-instance v0, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper$$ExternalSyntheticLambda0;-><init>()V

    const-class v1, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    const-class v2, Lcom/google/crypto/tink/PublicKeyVerify;

    .line 60
    invoke-static {v0, v1, v2}, Lcom/google/crypto/tink/internal/PrimitiveConstructor;->create(Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;Ljava/lang/Class;Ljava/lang/Class;)Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    move-result-object v0

    sput-object v0, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;->LEGACY_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 46
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static getOutputPrefix(Lcom/google/crypto/tink/Key;)Lcom/google/crypto/tink/util/Bytes;
    .locals 3

    .line 64
    instance-of v0, p0, Lcom/google/crypto/tink/signature/SignaturePublicKey;

    if-eqz v0, :cond_0

    .line 65
    check-cast p0, Lcom/google/crypto/tink/signature/SignaturePublicKey;

    invoke-virtual {p0}, Lcom/google/crypto/tink/signature/SignaturePublicKey;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

    move-result-object p0

    return-object p0

    .line 67
    :cond_0
    instance-of v0, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    if-eqz v0, :cond_1

    .line 68
    check-cast p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/LegacyProtoKey;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

    move-result-object p0

    return-object p0

    .line 70
    :cond_1
    new-instance v0, Ljava/security/GeneralSecurityException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Cannot get output prefix for key of class "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 72
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, " with parameters "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 74
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

    .line 148
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;->WRAPPER:Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveWrapper(Lcom/google/crypto/tink/internal/PrimitiveWrapper;)V

    .line 149
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;->LEGACY_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    .line 150
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveConstructor(Lcom/google/crypto/tink/internal/PrimitiveConstructor;)V

    return-void
.end method

.method public static registerToInternalPrimitiveRegistry(Lcom/google/crypto/tink/internal/PrimitiveRegistry$Builder;)V
    .locals 1

    .line 160
    sget-object v0, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;->WRAPPER:Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;

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
            "Lcom/google/crypto/tink/PublicKeyVerify;",
            ">;"
        }
    .end annotation

    .line 138
    const-class v0, Lcom/google/crypto/tink/PublicKeyVerify;

    return-object v0
.end method

.method public getPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/PublicKeyVerify;",
            ">;"
        }
    .end annotation

    .line 133
    const-class v0, Lcom/google/crypto/tink/PublicKeyVerify;

    return-object v0
.end method

.method public wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/PublicKeyVerify;
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "Lcom/google/crypto/tink/PublicKeyVerify;",
            ">;)",
            "Lcom/google/crypto/tink/PublicKeyVerify;"
        }
    .end annotation

    .line 110
    new-instance v0, Lcom/google/crypto/tink/internal/PrefixMap$Builder;

    invoke-direct {v0}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;-><init>()V

    .line 111
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object v1

    const/4 v2, 0x0

    .line 112
    :goto_0
    invoke-interface {v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->size()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 113
    invoke-interface {v1, v2}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getAt(I)Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v3

    .line 114
    invoke-virtual {p1, v3}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/crypto/tink/PublicKeyVerify;

    .line 116
    invoke-interface {v3}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getKey()Lcom/google/crypto/tink/Key;

    move-result-object v5

    invoke-static {v5}, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;->getOutputPrefix(Lcom/google/crypto/tink/Key;)Lcom/google/crypto/tink/util/Bytes;

    move-result-object v5

    new-instance v6, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper$PublicKeyVerifyWithId;

    .line 117
    invoke-interface {v3}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v3

    invoke-direct {v6, v4, v3}, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper$PublicKeyVerifyWithId;-><init>(Lcom/google/crypto/tink/PublicKeyVerify;I)V

    .line 115
    invoke-virtual {v0, v5, v6}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;->put(Lcom/google/crypto/tink/util/Bytes;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/PrefixMap$Builder;

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 120
    :cond_0
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v2

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/MonitoringAnnotations;->isEmpty()Z

    move-result v2

    if-nez v2, :cond_1

    .line 121
    invoke-static {}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;

    move-result-object v2

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->getMonitoringClient()Lcom/google/crypto/tink/internal/MonitoringClient;

    move-result-object v2

    .line 124
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object p1

    const-string v3, "public_key_verify"

    const-string v4, "verify"

    .line 123
    invoke-interface {v2, v1, p1, v3, v4}, Lcom/google/crypto/tink/internal/MonitoringClient;->createLogger(Lcom/google/crypto/tink/internal/KeysetHandleInterface;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Ljava/lang/String;Ljava/lang/String;)Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-result-object p1

    goto :goto_1

    .line 126
    :cond_1
    sget-object p1, Lcom/google/crypto/tink/internal/MonitoringUtil;->DO_NOTHING_LOGGER:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    .line 128
    :goto_1
    new-instance v1, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper$WrappedPublicKeyVerify;

    invoke-virtual {v0}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;->build()Lcom/google/crypto/tink/internal/PrefixMap;

    move-result-object v0

    invoke-direct {v1, v0, p1}, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper$WrappedPublicKeyVerify;-><init>(Lcom/google/crypto/tink/internal/PrefixMap;Lcom/google/crypto/tink/internal/MonitoringClient$Logger;)V

    return-object v1
.end method

.method public bridge synthetic wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/lang/Object;
    .locals 0

    .line 46
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/signature/PublicKeyVerifyWrapper;->wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/PublicKeyVerify;

    move-result-object p1

    return-object p1
.end method
