.class public final Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;
.super Ljava/lang/Object;
.source "KeysetDeriverWrapper.java"

# interfaces
.implements Lcom/google/crypto/tink/internal/PrimitiveWrapper;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$WrappedKeysetDeriver;,
        Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$DeriverWithId;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/crypto/tink/internal/PrimitiveWrapper<",
        "Lcom/google/crypto/tink/keyderivation/internal/KeyDeriver;",
        "Lcom/google/crypto/tink/keyderivation/KeysetDeriver;",
        ">;"
    }
.end annotation


# static fields
.field private static final WRAPPER:Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 46
    new-instance v0, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;

    invoke-direct {v0}, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;-><init>()V

    sput-object v0, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;->WRAPPER:Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;

    return-void
.end method

.method constructor <init>()V
    .locals 0

    .line 88
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static register()V
    .locals 2

    .line 118
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;->WRAPPER:Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;

    invoke-virtual {v0, v1}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->registerPrimitiveWrapper(Lcom/google/crypto/tink/internal/PrimitiveWrapper;)V

    return-void
.end method

.method private static validate(Lcom/google/crypto/tink/internal/KeysetHandleInterface;)V
    .locals 1

    .line 49
    invoke-interface {p0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object p0

    if-eqz p0, :cond_0

    return-void

    .line 50
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
            "Lcom/google/crypto/tink/keyderivation/internal/KeyDeriver;",
            ">;"
        }
    .end annotation

    .line 113
    const-class v0, Lcom/google/crypto/tink/keyderivation/internal/KeyDeriver;

    return-object v0
.end method

.method public getPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "Lcom/google/crypto/tink/keyderivation/KeysetDeriver;",
            ">;"
        }
    .end annotation

    .line 108
    const-class v0, Lcom/google/crypto/tink/keyderivation/KeysetDeriver;

    return-object v0
.end method

.method public wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/keyderivation/KeysetDeriver;
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "Lcom/google/crypto/tink/keyderivation/internal/KeyDeriver;",
            ">;)",
            "Lcom/google/crypto/tink/keyderivation/KeysetDeriver;"
        }
    .end annotation

    .line 93
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object v0

    invoke-static {v0}, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;->validate(Lcom/google/crypto/tink/internal/KeysetHandleInterface;)V

    .line 94
    invoke-virtual {p1}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;

    move-result-object v0

    .line 95
    new-instance v1, Ljava/util/ArrayList;

    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->size()I

    move-result v2

    invoke-direct {v1, v2}, Ljava/util/ArrayList;-><init>(I)V

    const/4 v2, 0x0

    .line 96
    :goto_0
    invoke-interface {v0}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->size()I

    move-result v3

    if-ge v2, v3, :cond_0

    .line 97
    invoke-interface {v0, v2}, Lcom/google/crypto/tink/internal/KeysetHandleInterface;->getAt(I)Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    move-result-object v3

    .line 98
    new-instance v4, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$DeriverWithId;

    .line 100
    invoke-virtual {p1, v3}, Lcom/google/crypto/tink/internal/PrimitiveSet;->getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/google/crypto/tink/keyderivation/internal/KeyDeriver;

    invoke-interface {v3}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getId()I

    move-result v6

    invoke-interface {v3}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->isPrimary()Z

    move-result v3

    invoke-direct {v4, v5, v6, v3}, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$DeriverWithId;-><init>(Lcom/google/crypto/tink/keyderivation/internal/KeyDeriver;IZ)V

    .line 98
    invoke-interface {v1, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 103
    :cond_0
    new-instance p1, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$WrappedKeysetDeriver;

    const/4 v0, 0x0

    invoke-direct {p1, v1, v0}, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$WrappedKeysetDeriver;-><init>(Ljava/util/List;Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$1;)V

    return-object p1
.end method

.method public bridge synthetic wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/lang/Object;
    .locals 0

    .line 32
    invoke-virtual {p0, p1}, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;->wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/keyderivation/KeysetDeriver;

    move-result-object p1

    return-object p1
.end method
