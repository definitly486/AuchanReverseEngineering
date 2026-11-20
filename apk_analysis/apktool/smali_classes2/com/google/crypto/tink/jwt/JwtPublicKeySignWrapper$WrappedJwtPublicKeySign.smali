.class Lcom/google/crypto/tink/jwt/JwtPublicKeySignWrapper$WrappedJwtPublicKeySign;
.super Ljava/lang/Object;
.source "JwtPublicKeySignWrapper.java"

# interfaces
.implements Lcom/google/crypto/tink/jwt/JwtPublicKeySign;


# annotations
.annotation runtime Lcom/google/errorprone/annotations/Immutable;
.end annotation

.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/crypto/tink/jwt/JwtPublicKeySignWrapper;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0xa
    name = "WrappedJwtPublicKeySign"
.end annotation


# instance fields
.field private final logger:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

.field private final primary:Lcom/google/crypto/tink/jwt/JwtPublicKeySign;

.field private final primaryKeyId:I


# direct methods
.method public constructor <init>(Lcom/google/crypto/tink/internal/PrimitiveSet;)V
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "Lcom/google/crypto/tink/jwt/JwtPublicKeySign;",
            ">;)V"
        }
    .end annotation

    .line 51
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 52
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object v0

    .line 53
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v1

    invoke-virtual {p1, v1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/google/crypto/tink/jwt/JwtPublicKeySign;

    iput-object v1, p0, Lcom/google/crypto/tink/jwt/JwtPublicKeySignWrapper$WrappedJwtPublicKeySign;->primary:Lcom/google/crypto/tink/jwt/JwtPublicKeySign;

    .line 54
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v1

    invoke-interface {v1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v1

    iput v1, p0, Lcom/google/crypto/tink/jwt/JwtPublicKeySignWrapper$WrappedJwtPublicKeySign;->primaryKeyId:I

    .line 55
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object v1

    invoke-virtual {v1}, Lcom/google/crypto/tink/internal/MonitoringAnnotations;->isEmpty()Z

    move-result v1

    if-nez v1, :cond_0

    .line 56
    invoke-static {}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;

    move-result-object v1

    invoke-virtual {v1}, Lcom/google/crypto/tink/internal/MutableMonitoringRegistry;->getMonitoringClient()Lcom/google/crypto/tink/internal/MonitoringClient;

    move-result-object v1

    .line 58
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    move-result-object p1

    const-string v2, "jwtsign"

    const-string v3, "sign"

    invoke-interface {v1, v0, p1, v2, v3}, Lcom/google/crypto/tink/internal/MonitoringClient;->createLogger(Lcom/google/crypto/tink/internal/KeysetHandleInterface;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Ljava/lang/String;Ljava/lang/String;)Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    move-result-object p1

    iput-object p1, p0, Lcom/google/crypto/tink/jwt/JwtPublicKeySignWrapper$WrappedJwtPublicKeySign;->logger:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    return-void

    .line 60
    :cond_0
    sget-object p1, Lcom/google/crypto/tink/internal/MonitoringUtil;->DO_NOTHING_LOGGER:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    iput-object p1, p0, Lcom/google/crypto/tink/jwt/JwtPublicKeySignWrapper$WrappedJwtPublicKeySign;->logger:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    return-void
.end method


# virtual methods
.method public signAndEncode(Lcom/google/crypto/tink/jwt/RawJwt;)Ljava/lang/String;
    .locals 4

    .line 67
    :try_start_0
    iget-object v0, p0, Lcom/google/crypto/tink/jwt/JwtPublicKeySignWrapper$WrappedJwtPublicKeySign;->primary:Lcom/google/crypto/tink/jwt/JwtPublicKeySign;

    invoke-interface {v0, p1}, Lcom/google/crypto/tink/jwt/JwtPublicKeySign;->signAndEncode(Lcom/google/crypto/tink/jwt/RawJwt;)Ljava/lang/String;

    move-result-object p1

    .line 68
    iget-object v0, p0, Lcom/google/crypto/tink/jwt/JwtPublicKeySignWrapper$WrappedJwtPublicKeySign;->logger:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    iget v1, p0, Lcom/google/crypto/tink/jwt/JwtPublicKeySignWrapper$WrappedJwtPublicKeySign;->primaryKeyId:I

    const-wide/16 v2, 0x1

    invoke-interface {v0, v1, v2, v3}, Lcom/google/crypto/tink/internal/MonitoringClient$Logger;->log(IJ)V
    :try_end_0
    .catch Ljava/security/GeneralSecurityException; {:try_start_0 .. :try_end_0} :catch_0

    return-object p1

    :catch_0
    move-exception p1

    .line 71
    iget-object v0, p0, Lcom/google/crypto/tink/jwt/JwtPublicKeySignWrapper$WrappedJwtPublicKeySign;->logger:Lcom/google/crypto/tink/internal/MonitoringClient$Logger;

    invoke-interface {v0}, Lcom/google/crypto/tink/internal/MonitoringClient$Logger;->logFailure()V

    .line 72
    throw p1
.end method
