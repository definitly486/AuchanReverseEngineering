.class public Lcom/google/crypto/tink/aead/AeadWrapper;
.super Ljava/lang/Object;
.source "AeadWrapper.java"

# interfaces
.implements Lcom/google/crypto/tink/internal/PrimitiveWrapper;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/aead/AeadWrapper$WrappedAead;,
        Lcom/google/crypto/tink/aead/AeadWrapper$AeadWithId;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/crypto/tink/internal/PrimitiveWrapper<",
        "Lcom/google/crypto/tink/Aead;",
        "Lcom/google/crypto/tink/Aead;",
        ">;"
    }
.end annotation


# static fields
.field private static final LEGACY_FULL_AEAD_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/internal/PrimitiveConstructor<",
            "Lcom/google/crypto/tink/internal/LegacyProtoKey;",
            "Lcom/google/crypto/tink/Aead;",
            ">;"
        }
    .end annotation
.end field

.field private static final WRAPPER:Lcom/google/crypto/tink/aead/AeadWrapper;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 55
    new-instance v0, Lcom/google/crypto/tink/aead/AeadWrapper;

    invoke-direct {v0}, Lcom/google/crypto/tink/aead/AeadWrapper;-><init>()V

    sput-object v0, Lcom/google/crypto/tink/aead/AeadWrapper;->WRAPPER:Lcom/google/crypto/tink/aead/AeadWrapper;

    .line 57
    new-instance v0, Lcom/google/crypto/tink/aead/AeadWrapper$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/google/crypto/tink/aead/AeadWrapper$$ExternalSyntheticLambda0;-><init>()V

    const-class v1, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    const-class v2, Lcom/google/crypto/tink/Aead;

    .line 58
    invoke-static {v0, v1, v2}, Lcom/google/crypto/tink/internal/PrimitiveConstructor;->create(Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;Ljava/lang/Class;Ljava/lang/Class;)Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    move-result-object v0

    sput-object v0, Lcom/google/crypto/tink/aead/AeadWrapper;->LEGACY_FULL_AEAD_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    return-void
.end method

.method constructor <init>()V
    .locals 0

    .line 122
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static getOutputPrefix(Lcom/google/crypto/tink/Key;)Lcom/google/crypto/tink/util/Bytes;
    .locals 3

    .line 61
    instance-of v0, p0, Lcom/google/crypto/tink/aead/AeadKey;

    if-eqz v0, :cond_0

    .line 62
    check-cast p0, Lcom/google/crypto/tink/aead/AeadKey;

    invoke-virtual {p0}, Lcom/google/crypto/tink/aead/AeadKey;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

    move-result-object p0

    return-object p0

    .line 64
    :cond_0
    instance-of v0, p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    if-eqz v0, :cond_1

    .line 65
    check-cast p0, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/LegacyProtoKey;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

    move-result-object p0

    return-object p0

    .line 67
    :cond_1
    new-instance v0, Ljava/security/GeneralSecurityException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Cannot get output prefix for key of class "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 69
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, " with parameters "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 71
    invoke-virtual {p0}, Lcom/google/crypto/tink/Key;->getParameters()Lcom/google/crypto/tink/Parameters;

    move-result-object p0

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public static register()V
    .locals 2

    .line 164
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/aead/AeadWrapper;->WRAPPER:Lcom/google/crypto/tink/aead/AeadWrapper;

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveWrapper(Lcom/google/crypto/tink/internal/PrimitiveWrapper;)V

    .line 165
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/aead/AeadWrapper;->LEGACY_FULL_AEAD_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    .line 166
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveConstructor(Lcom/google/crypto/tink/internal/PrimitiveConstructor;)V

    return-void
.end method

.method public static registerToInternalPrimitiveRegistry(Lcom/google/crypto/tink/internal/PrimitiveRegistry$Builder;)V
    .locals 1

    .line 176
    sget-object v0, Lcom/google/crypto/tink/aead/AeadWrapper;->WRAPPER:Lcom/google/crypto/tink/aead/AeadWrapper;

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
            "Lcom/google/crypto/tink/Aead;",
            ">;"
        }
    .end annotation

    .line 160
    const-class v0, Lcom/google/crypto/tink/Aead;

    return-object v0
.end method

.method public getPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/Aead;",
            ">;"
        }
    .end annotation

    .line 155
    const-class v0, Lcom/google/crypto/tink/Aead;

    return-object v0
.end method

.method public wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/Aead;
    .locals 10
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "Lcom/google/crypto/tink/Aead;",
            ">;)",
            "Lcom/google/crypto/tink/Aead;"
        }
    .end annotation

    .line 126
    new-instance v0, Lcom/google/crypto/tink/internal/PrefixMap$Builder;

    invoke-direct {v0}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;-><init>()V

    .line 127
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object v1

    const/4 v2, 0x0

    .line 128
    :goto_0
    invoke-interface {v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->size()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 129
    invoke-interface {v1, v2}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getAt(I)Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v3

    .line 131
    invoke-interface {v3}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getKey()Lcom/google/crypto/tink/Key;

    move-result-object v4

    invoke-static {v4}, Lcom/google/crypto/tink/aead/AeadWrapper;->getOutputPrefix(Lcom/google/crypto/tink/Key;)Lcom/google/crypto/tink/util/Bytes;

    move-result-object v4

    new-instance v5, Lcom/google/crypto/tink/aead/AeadWrapper$AeadWithId;

    .line 132
    invoke-virtual {p1, v3}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/google/crypto/tink/Aead;

    invoke-interface {v3}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v3

    invoke-direct {v5, v6, v3}, Lcom/google/crypto/tink/aead/AeadWrapper$AeadWithId;-><init>(Lcom/google/crypto/tink/Aead;I)V

    .line 130
    invoke-virtual {v0, v4, v5}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;->put(Lcom/google/crypto/tink/util/Bytes;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/PrefixMap$Builder;

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 136
    :cond_0
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v2

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/MonitoringAnnotations;->isEmpty()Z

    move-result v2

    if-nez v2, :cond_1

    .line 137
    invoke-static {}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;

    move-result-object v2

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->getMonitoringClient()Lcom/google/crypto/tink/internal/MonitoringClient;

    move-result-object v2

    .line 138
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v3

    const-string v4, "encrypt"

    const-string v5, "aead"

    invoke-interface {v2, v1, v3, v5, v4}, Lcom/google/crypto/tink/internal/MonitoringClient;->createLogger(Lcom/google/crypto/tink/internal/KeysetHandleInterface;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Ljava/lang/String;Ljava/lang/String;)Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-result-object v3

    .line 139
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v4

    const-string v6, "decrypt"

    invoke-interface {v2, v1, v4, v5, v6}, Lcom/google/crypto/tink/internal/MonitoringClient;->createLogger(Lcom/google/crypto/tink/internal/KeysetHandleInterface;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Ljava/lang/String;Ljava/lang/String;)Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-result-object v2

    move-object v8, v2

    move-object v7, v3

    goto :goto_1

    .line 141
    :cond_1
    sget-object v3, Lcom/google/crypto/tink/internal/MonitoringUtil;->DO_NOTHING_LOGGER:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-object v7, v3

    move-object v8, v7

    .line 144
    :goto_1
    new-instance v4, Lcom/google/crypto/tink/aead/AeadWrapper$WrappedAead;

    new-instance v5, Lcom/google/crypto/tink/aead/AeadWrapper$AeadWithId;

    .line 146
    invoke-interface {v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v2

    invoke-virtual {p1, v2}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/crypto/tink/Aead;

    .line 147
    invoke-interface {v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v1

    invoke-interface {v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v1

    invoke-direct {v5, p1, v1}, Lcom/google/crypto/tink/aead/AeadWrapper$AeadWithId;-><init>(Lcom/google/crypto/tink/Aead;I)V

    .line 148
    invoke-virtual {v0}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;->build()Lcom/google/crypto/tink/internal/PrefixMap;

    move-result-object v6

    const/4 v9, 0x0

    invoke-direct/range {v4 .. v9}, Lcom/google/crypto/tink/aead/AeadWrapper$WrappedAead;-><init>(Lcom/google/crypto/tink/aead/AeadWrapper$AeadWithId;Lcom/google/crypto/tink/internal/PrefixMap;Lcom/google/crypto/tink/internal/MonitoringClient$Logger;Lcom/google/crypto/tink/internal/MonitoringClient$Logger;Lcom/google/crypto/tink/aead/AeadWrapper$1;)V

    return-object v4
.end method

.method public bridge synthetic wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/lang/Object;
    .locals 0

    .line 44
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/aead/AeadWrapper;->wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/Aead;

    move-result-object p1

    return-object p1
.end method
