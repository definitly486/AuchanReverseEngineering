.class public Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;
.super Ljava/lang/Object;
.source "DeterministicAeadWrapper.java"

# interfaces
.implements Lcom/google/crypto/tink/internal/PrimitiveWrapper;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$WrappedDeterministicAead;,
        Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$DeterministicAeadWithId;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/crypto/tink/internal/PrimitiveWrapper<",
        "Lcom/google/crypto/tink/DeterministicAead;",
        "Lcom/google/crypto/tink/DeterministicAead;",
        ">;"
    }
.end annotation


# static fields
.field private static final LEGACY_FULL_DAEAD_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/internal/PrimitiveConstructor<",
            "Lcom/google/crypto/tink/internal/LegacyProtoKey;",
            "Lcom/google/crypto/tink/DeterministicAead;",
            ">;"
        }
    .end annotation
.end field

.field private static final WRAPPER:Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 57
    new-instance v0, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;

    invoke-direct {v0}, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;-><init>()V

    sput-object v0, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;->WRAPPER:Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;

    .line 59
    new-instance v0, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$$ExternalSyntheticLambda0;-><init>()V

    const-class v1, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    const-class v2, Lcom/google/crypto/tink/DeterministicAead;

    .line 60
    invoke-static {v0, v1, v2}, Lcom/google/crypto/tink/internal/PrimitiveConstructor;->create(Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;Ljava/lang/Class;Ljava/lang/Class;)Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    move-result-object v0

    sput-object v0, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;->LEGACY_FULL_DAEAD_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    return-void
.end method

.method constructor <init>()V
    .locals 0

    .line 125
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static getOutputPrefix(Lcom/google/crypto/tink/Key;)Lcom/google/crypto/tink/util/Bytes;
    .locals 3

    .line 64
    instance-of v0, p0, Lcom/google/crypto/tink/daead/DeterministicAeadKey;

    if-eqz v0, :cond_0

    .line 65
    check-cast p0, Lcom/google/crypto/tink/daead/DeterministicAeadKey;

    invoke-virtual {p0}, Lcom/google/crypto/tink/daead/DeterministicAeadKey;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

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

.method public static register()V
    .locals 2

    .line 168
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;->WRAPPER:Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveWrapper(Lcom/google/crypto/tink/internal/PrimitiveWrapper;)V

    .line 169
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;->LEGACY_FULL_DAEAD_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    .line 170
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveConstructor(Lcom/google/crypto/tink/internal/PrimitiveConstructor;)V

    return-void
.end method

.method public static registerToInternalPrimitiveRegistry(Lcom/google/crypto/tink/internal/PrimitiveRegistry$Builder;)V
    .locals 1

    .line 180
    sget-object v0, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;->WRAPPER:Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;

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
            "Lcom/google/crypto/tink/DeterministicAead;",
            ">;"
        }
    .end annotation

    .line 164
    const-class v0, Lcom/google/crypto/tink/DeterministicAead;

    return-object v0
.end method

.method public getPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/DeterministicAead;",
            ">;"
        }
    .end annotation

    .line 159
    const-class v0, Lcom/google/crypto/tink/DeterministicAead;

    return-object v0
.end method

.method public wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/DeterministicAead;
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "Lcom/google/crypto/tink/DeterministicAead;",
            ">;)",
            "Lcom/google/crypto/tink/DeterministicAead;"
        }
    .end annotation

    .line 130
    new-instance v0, Lcom/google/crypto/tink/internal/PrefixMap$Builder;

    invoke-direct {v0}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;-><init>()V

    .line 131
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object v1

    const/4 v2, 0x0

    .line 132
    :goto_0
    invoke-interface {v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->size()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 133
    invoke-interface {v1, v2}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getAt(I)Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v3

    .line 134
    invoke-virtual {p1, v3}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/crypto/tink/DeterministicAead;

    .line 136
    invoke-interface {v3}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getKey()Lcom/google/crypto/tink/Key;

    move-result-object v5

    invoke-static {v5}, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;->getOutputPrefix(Lcom/google/crypto/tink/Key;)Lcom/google/crypto/tink/util/Bytes;

    move-result-object v5

    new-instance v6, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$DeterministicAeadWithId;

    .line 137
    invoke-interface {v3}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v3

    invoke-direct {v6, v4, v3}, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$DeterministicAeadWithId;-><init>(Lcom/google/crypto/tink/DeterministicAead;I)V

    .line 135
    invoke-virtual {v0, v5, v6}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;->put(Lcom/google/crypto/tink/util/Bytes;Ljava/lang/Object;)Lcom/google/crypto/tink/internal/PrefixMap$Builder;

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 141
    :cond_0
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v2

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/MonitoringAnnotations;->isEmpty()Z

    move-result v2

    if-nez v2, :cond_1

    .line 142
    invoke-static {}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;

    move-result-object v2

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->getMonitoringClient()Lcom/google/crypto/tink/internal/MonitoringClient;

    move-result-object v2

    .line 143
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v3

    const-string v4, "encrypt"

    const-string v5, "daead"

    invoke-interface {v2, v1, v3, v5, v4}, Lcom/google/crypto/tink/internal/MonitoringClient;->createLogger(Lcom/google/crypto/tink/internal/KeysetHandleInterface;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Ljava/lang/String;Ljava/lang/String;)Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-result-object v3

    .line 144
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v4

    const-string v6, "decrypt"

    invoke-interface {v2, v1, v4, v5, v6}, Lcom/google/crypto/tink/internal/MonitoringClient;->createLogger(Lcom/google/crypto/tink/internal/KeysetHandleInterface;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Ljava/lang/String;Ljava/lang/String;)Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-result-object v2

    goto :goto_1

    .line 146
    :cond_1
    sget-object v3, Lcom/google/crypto/tink/internal/MonitoringUtil;->DO_NOTHING_LOGGER:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-object v2, v3

    .line 149
    :goto_1
    new-instance v4, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$WrappedDeterministicAead;

    new-instance v5, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$DeterministicAeadWithId;

    .line 151
    invoke-interface {v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v6

    invoke-virtual {p1, v6}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/crypto/tink/DeterministicAead;

    invoke-interface {v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v1

    invoke-interface {v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v1

    invoke-direct {v5, p1, v1}, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$DeterministicAeadWithId;-><init>(Lcom/google/crypto/tink/DeterministicAead;I)V

    .line 152
    invoke-virtual {v0}, Lcom/google/crypto/tink/internal/PrefixMap$Builder;->build()Lcom/google/crypto/tink/internal/PrefixMap;

    move-result-object p1

    invoke-direct {v4, v5, p1, v3, v2}, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$WrappedDeterministicAead;-><init>(Lcom/google/crypto/tink/daead/DeterministicAeadWrapper$DeterministicAeadWithId;Lcom/google/crypto/tink/internal/PrefixMap;Lcom/google/crypto/tink/internal/MonitoringClient$Logger;Lcom/google/crypto/tink/internal/MonitoringClient$Logger;)V

    return-object v4
.end method

.method public bridge synthetic wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/lang/Object;
    .locals 0

    .line 45
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/daead/DeterministicAeadWrapper;->wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/DeterministicAead;

    move-result-object p1

    return-object p1
.end method
