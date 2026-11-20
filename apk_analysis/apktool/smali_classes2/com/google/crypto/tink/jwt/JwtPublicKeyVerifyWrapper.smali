.class Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper;
.super Ljava/lang/Object;
.source "JwtPublicKeyVerifyWrapper.java"

# interfaces
.implements Lcom/google/crypto/tink/internal/PrimitiveWrapper;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper$WrappedJwtPublicKeyVerify;,
        Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper$JwtPublicKeyVerifyWithId;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/crypto/tink/internal/PrimitiveWrapper<",
        "Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;",
        "Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;",
        ">;"
    }
.end annotation


# static fields
.field private static final WRAPPER:Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 44
    new-instance v0, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper;

    invoke-direct {v0}, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper;-><init>()V

    sput-object v0, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper;->WRAPPER:Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper;

    return-void
.end method

.method constructor <init>()V
    .locals 0

    .line 32
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static register()V
    .locals 2

    .line 125
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper;->WRAPPER:Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper;

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveWrapper(Lcom/google/crypto/tink/internal/PrimitiveWrapper;)V

    return-void
.end method


# virtual methods
.method public getInputPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;",
            ">;"
        }
    .end annotation

    .line 115
    const-class v0, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;

    return-object v0
.end method

.method public getPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;",
            ">;"
        }
    .end annotation

    .line 110
    const-class v0, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;

    return-object v0
.end method

.method public wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;",
            ">;)",
            "Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;"
        }
    .end annotation

    .line 89
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object v0

    .line 90
    new-instance v1, Ljava/util/ArrayList;

    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->size()I

    move-result v2

    invoke-direct {v1, v2}, Ljava/util/ArrayList;-><init>(I)V

    const/4 v2, 0x0

    .line 91
    :goto_0
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->size()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 92
    invoke-interface {v0, v2}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getAt(I)Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v3

    .line 93
    new-instance v4, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper$JwtPublicKeyVerifyWithId;

    .line 94
    invoke-virtual {p1, v3}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;

    invoke-interface {v3}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v3

    invoke-direct {v4, v5, v3}, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper$JwtPublicKeyVerifyWithId;-><init>(Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;I)V

    .line 93
    invoke-interface {v1, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 97
    :cond_0
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v2

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/MonitoringAnnotations;->isEmpty()Z

    move-result v2

    if-nez v2, :cond_1

    .line 98
    invoke-static {}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;

    move-result-object v2

    invoke-virtual {v2}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->getMonitoringClient()Lcom/google/crypto/tink/internal/MonitoringClient;

    move-result-object v2

    .line 100
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object p1

    const-string v3, "jwtverify"

    const-string v4, "verify"

    invoke-interface {v2, v0, p1, v3, v4}, Lcom/google/crypto/tink/internal/MonitoringClient;->createLogger(Lcom/google/crypto/tink/internal/KeysetHandleInterface;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Ljava/lang/String;Ljava/lang/String;)Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-result-object p1

    goto :goto_1

    .line 102
    :cond_1
    sget-object p1, Lcom/google/crypto/tink/internal/MonitoringUtil;->DO_NOTHING_LOGGER:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    .line 105
    :goto_1
    new-instance v0, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper$WrappedJwtPublicKeyVerify;

    invoke-direct {v0, p1, v1}, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper$WrappedJwtPublicKeyVerify;-><init>(Lcom/google/crypto/tink/internal/MonitoringClient$Logger;Ljava/util/List;)V

    return-object v0
.end method

.method public bridge synthetic wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/lang/Object;
    .locals 0

    .line 32
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/jwt/JwtPublicKeyVerifyWrapper;->wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/jwt/JwtPublicKeyVerify;

    move-result-object p1

    return-object p1
.end method
