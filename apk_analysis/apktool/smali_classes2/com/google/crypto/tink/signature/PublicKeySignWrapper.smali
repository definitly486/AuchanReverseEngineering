.class public Lcom/google/crypto/tink/signature/PublicKeySignWrapper;
.super Ljava/lang/Object;
.source "PublicKeySignWrapper.java"

# interfaces
.implements Lcom/google/crypto/tink/internal/PrimitiveWrapper;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/signature/PublicKeySignWrapper$WrappedPublicKeySign;,
        Lcom/google/crypto/tink/signature/PublicKeySignWrapper$PublicKeySignWithId;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/crypto/tink/internal/PrimitiveWrapper<",
        "Lcom/google/crypto/tink/PublicKeySign;",
        "Lcom/google/crypto/tink/PublicKeySign;",
        ">;"
    }
.end annotation


# static fields
.field private static final LEGACY_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/internal/PrimitiveConstructor<",
            "Lcom/google/crypto/tink/internal/LegacyProtoKey;",
            "Lcom/google/crypto/tink/PublicKeySign;",
            ">;"
        }
    .end annotation
.end field

.field private static final WRAPPER:Lcom/google/crypto/tink/signature/PublicKeySignWrapper;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 42
    new-instance v0, Lcom/google/crypto/tink/signature/PublicKeySignWrapper;

    invoke-direct {v0}, Lcom/google/crypto/tink/signature/PublicKeySignWrapper;-><init>()V

    sput-object v0, Lcom/google/crypto/tink/signature/PublicKeySignWrapper;->WRAPPER:Lcom/google/crypto/tink/signature/PublicKeySignWrapper;

    .line 44
    new-instance v0, Lcom/google/crypto/tink/signature/PublicKeySignWrapper$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/google/crypto/tink/signature/PublicKeySignWrapper$$ExternalSyntheticLambda0;-><init>()V

    const-class v1, Lcom/google/crypto/tink/internal/LegacyProtoKey;

    const-class v2, Lcom/google/crypto/tink/PublicKeySign;

    .line 45
    invoke-static {v0, v1, v2}, Lcom/google/crypto/tink/internal/PrimitiveConstructor;->create(Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;Ljava/lang/Class;Ljava/lang/Class;)Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    move-result-object v0

    sput-object v0, Lcom/google/crypto/tink/signature/PublicKeySignWrapper;->LEGACY_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    return-void
.end method

.method constructor <init>()V
    .locals 0

    .line 82
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static register()V
    .locals 2

    .line 120
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/signature/PublicKeySignWrapper;->WRAPPER:Lcom/google/crypto/tink/signature/PublicKeySignWrapper;

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveWrapper(Lcom/google/crypto/tink/internal/PrimitiveWrapper;)V

    .line 121
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/signature/PublicKeySignWrapper;->LEGACY_PRIMITIVE_CONSTRUCTOR:Lcom/google/crypto/tink/internal/PrimitiveConstructor;

    .line 122
    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveConstructor(Lcom/google/crypto/tink/internal/PrimitiveConstructor;)V

    return-void
.end method

.method public static registerToInternalPrimitiveRegistry(Lcom/google/crypto/tink/internal/PrimitiveRegistry$Builder;)V
    .locals 1

    .line 132
    sget-object v0, Lcom/google/crypto/tink/signature/PublicKeySignWrapper;->WRAPPER:Lcom/google/crypto/tink/signature/PublicKeySignWrapper;

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
            "Lcom/google/crypto/tink/PublicKeySign;",
            ">;"
        }
    .end annotation

    .line 110
    const-class v0, Lcom/google/crypto/tink/PublicKeySign;

    return-object v0
.end method

.method public getPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/PublicKeySign;",
            ">;"
        }
    .end annotation

    .line 105
    const-class v0, Lcom/google/crypto/tink/PublicKeySign;

    return-object v0
.end method

.method public wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/PublicKeySign;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "Lcom/google/crypto/tink/PublicKeySign;",
            ">;)",
            "Lcom/google/crypto/tink/PublicKeySign;"
        }
    .end annotation

    .line 87
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object v0

    .line 89
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v1

    invoke-virtual {v1}, Lcom/google/crypto/tink/internal/MonitoringAnnotations;->isEmpty()Z

    move-result v1

    if-nez v1, :cond_0

    .line 90
    invoke-static {}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;

    move-result-object v1

    invoke-virtual {v1}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->getMonitoringClient()Lcom/google/crypto/tink/internal/MonitoringClient;

    move-result-object v1

    .line 92
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v2

    const-string v3, "public_key_sign"

    const-string v4, "sign"

    invoke-interface {v1, v0, v2, v3, v4}, Lcom/google/crypto/tink/internal/MonitoringClient;->createLogger(Lcom/google/crypto/tink/internal/KeysetHandleInterface;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Ljava/lang/String;Ljava/lang/String;)Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-result-object v1

    goto :goto_0

    .line 94
    :cond_0
    sget-object v1, Lcom/google/crypto/tink/internal/MonitoringUtil;->DO_NOTHING_LOGGER:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    .line 96
    :goto_0
    new-instance v2, Lcom/google/crypto/tink/signature/PublicKeySignWrapper$WrappedPublicKeySign;

    new-instance v3, Lcom/google/crypto/tink/signature/PublicKeySignWrapper$PublicKeySignWithId;

    .line 98
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v4

    invoke-virtual {p1, v4}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/crypto/tink/PublicKeySign;

    .line 99
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v0

    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v0

    invoke-direct {v3, p1, v0}, Lcom/google/crypto/tink/signature/PublicKeySignWrapper$PublicKeySignWithId;-><init>(Lcom/google/crypto/tink/PublicKeySign;I)V

    invoke-direct {v2, v3, v1}, Lcom/google/crypto/tink/signature/PublicKeySignWrapper$WrappedPublicKeySign;-><init>(Lcom/google/crypto/tink/signature/PublicKeySignWrapper$PublicKeySignWithId;Lcom/google/crypto/tink/internal/MonitoringClient$Logger;)V

    return-object v2
.end method

.method public bridge synthetic wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/lang/Object;
    .locals 0

    .line 40
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/signature/PublicKeySignWrapper;->wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/PublicKeySign;

    move-result-object p1

    return-object p1
.end method
