.class Lcom/google/crypto/tink/jwt/JwtMacWrapper;
.super Ljava/lang/Object;
.source "JwtMacWrapper.java"

# interfaces
.implements Lcom/google/crypto/tink/internal/PrimitiveWrapper;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/jwt/JwtMacWrapper$WrappedJwtMac;,
        Lcom/google/crypto/tink/jwt/JwtMacWrapper$JwtMacWithId;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/crypto/tink/internal/PrimitiveWrapper<",
        "Lcom/google/crypto/tink/jwt/JwtMac;",
        "Lcom/google/crypto/tink/jwt/JwtMac;",
        ">;"
    }
.end annotation


# static fields
.field private static final WRAPPER:Lcom/google/crypto/tink/jwt/JwtMacWrapper;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 45
    new-instance v0, Lcom/google/crypto/tink/jwt/JwtMacWrapper;

    invoke-direct {v0}, Lcom/google/crypto/tink/jwt/JwtMacWrapper;-><init>()V

    sput-object v0, Lcom/google/crypto/tink/jwt/JwtMacWrapper;->WRAPPER:Lcom/google/crypto/tink/jwt/JwtMacWrapper;

    return-void
.end method

.method constructor <init>()V
    .locals 0

    .line 115
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static register()V
    .locals 2

    .line 159
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/jwt/JwtMacWrapper;->WRAPPER:Lcom/google/crypto/tink/jwt/JwtMacWrapper;

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveWrapper(Lcom/google/crypto/tink/internal/PrimitiveWrapper;)V

    return-void
.end method

.method private static validate(Lcom/google/crypto/tink/internal/PrimitiveSet;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "Lcom/google/crypto/tink/jwt/JwtMac;",
            ">;)V"
        }
    .end annotation

    .line 48
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object p0

    invoke-interface {p0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object p0

    if-eqz p0, :cond_0

    return-void

    .line 49
    :cond_0
    new-instance p0, Ljava/security/GeneralSecurityException;

    const-string v0, "Primitive set has no primary."

    invoke-direct {p0, v0}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p0
.end method


# virtual methods
.method public getInputPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/jwt/JwtMac;",
            ">;"
        }
    .end annotation

    .line 155
    const-class v0, Lcom/google/crypto/tink/jwt/JwtMac;

    return-object v0
.end method

.method public getPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/jwt/JwtMac;",
            ">;"
        }
    .end annotation

    .line 150
    const-class v0, Lcom/google/crypto/tink/jwt/JwtMac;

    return-object v0
.end method

.method public wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/jwt/JwtMac;
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "Lcom/google/crypto/tink/jwt/JwtMac;",
            ">;)",
            "Lcom/google/crypto/tink/jwt/JwtMac;"
        }
    .end annotation

    .line 119
    invoke-static {p1}, Lcom/google/crypto/tink/jwt/JwtMacWrapper;->validate(Lcom/google/crypto/tink/internal/PrimitiveSet;)V

    .line 120
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object v0

    .line 121
    new-instance v3, Ljava/util/ArrayList;

    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->size()I

    move-result v1

    invoke-direct {v3, v1}, Ljava/util/ArrayList;-><init>(I)V

    const/4 v1, 0x0

    .line 122
    :goto_0
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->size()I

    move-result v2

    if-ge v1, v2, :cond_0

    .line 123
    invoke-interface {v0, v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getAt(I)Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v2

    .line 124
    invoke-virtual {p1, v2}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/crypto/tink/jwt/JwtMac;

    .line 125
    new-instance v5, Lcom/google/crypto/tink/jwt/JwtMacWrapper$JwtMacWithId;

    invoke-interface {v2}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v2

    invoke-direct {v5, v4, v2}, Lcom/google/crypto/tink/jwt/JwtMacWrapper$JwtMacWithId;-><init>(Lcom/google/crypto/tink/jwt/JwtMac;I)V

    invoke-interface {v3, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 129
    :cond_0
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v1

    invoke-virtual {v1}, Lcom/google/crypto/tink/internal/MonitoringAnnotations;->isEmpty()Z

    move-result v1

    if-nez v1, :cond_1

    .line 130
    invoke-static {}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;

    move-result-object v1

    invoke-virtual {v1}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->getMonitoringClient()Lcom/google/crypto/tink/internal/MonitoringClient;

    move-result-object v1

    .line 132
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v2

    const-string v4, "compute"

    const-string v5, "jwtmac"

    invoke-interface {v1, v0, v2, v5, v4}, Lcom/google/crypto/tink/internal/MonitoringClient;->createLogger(Lcom/google/crypto/tink/internal/KeysetHandleInterface;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Ljava/lang/String;Ljava/lang/String;)Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-result-object v2

    .line 134
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v4

    const-string v6, "verify"

    invoke-interface {v1, v0, v4, v5, v6}, Lcom/google/crypto/tink/internal/MonitoringClient;->createLogger(Lcom/google/crypto/tink/internal/KeysetHandleInterface;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Ljava/lang/String;Ljava/lang/String;)Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-result-object v1

    move-object v5, v1

    move-object v4, v2

    goto :goto_1

    .line 136
    :cond_1
    sget-object v2, Lcom/google/crypto/tink/internal/MonitoringUtil;->DO_NOTHING_LOGGER:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-object v4, v2

    move-object v5, v4

    .line 139
    :goto_1
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v1

    invoke-virtual {p1, v1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/crypto/tink/jwt/JwtMac;

    .line 141
    new-instance v1, Lcom/google/crypto/tink/jwt/JwtMacWrapper$WrappedJwtMac;

    new-instance v2, Lcom/google/crypto/tink/jwt/JwtMacWrapper$JwtMacWithId;

    .line 142
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v0

    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v0

    invoke-direct {v2, p1, v0}, Lcom/google/crypto/tink/jwt/JwtMacWrapper$JwtMacWithId;-><init>(Lcom/google/crypto/tink/jwt/JwtMac;I)V

    const/4 v6, 0x0

    invoke-direct/range {v1 .. v6}, Lcom/google/crypto/tink/jwt/JwtMacWrapper$WrappedJwtMac;-><init>(Lcom/google/crypto/tink/jwt/JwtMacWrapper$JwtMacWithId;Ljava/util/List;Lcom/google/crypto/tink/internal/MonitoringClient$Logger;Lcom/google/crypto/tink/internal/MonitoringClient$Logger;Lcom/google/crypto/tink/jwt/JwtMacWrapper$1;)V

    return-object v1
.end method

.method public bridge synthetic wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/lang/Object;
    .locals 0

    .line 34
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/jwt/JwtMacWrapper;->wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/jwt/JwtMac;

    move-result-object p1

    return-object p1
.end method
