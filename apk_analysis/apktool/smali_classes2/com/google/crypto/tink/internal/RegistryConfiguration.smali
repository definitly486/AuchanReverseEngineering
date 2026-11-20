.class public final Lcom/google/crypto/tink/internal/RegistryConfiguration;
.super Lcom/google/crypto/tink/internal/InternalConfiguration;
.source "RegistryConfiguration.java"


# static fields
.field private static final CONFIG:Lcom/google/crypto/tink/internal/RegistryConfiguration;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 38
    new-instance v0, Lcom/google/crypto/tink/internal/RegistryConfiguration;

    invoke-direct {v0}, Lcom/google/crypto/tink/internal/RegistryConfiguration;-><init>()V

    sput-object v0, Lcom/google/crypto/tink/internal/RegistryConfiguration;->CONFIG:Lcom/google/crypto/tink/internal/RegistryConfiguration;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 40
    invoke-direct {p0}, Lcom/google/crypto/tink/internal/InternalConfiguration;-><init>()V

    return-void
.end method

.method public static createFromPrimitiveRegistry(Lcom/google/crypto/tink/internal/PrimitiveRegistry;)Lcom/google/crypto/tink/internal/InternalConfiguration;
    .locals 1
    .annotation build Lcom/google/errorprone/annotations/DoNotCall;
    .end annotation

    .line 72
    new-instance p0, Ljava/lang/UnsupportedOperationException;

    const-string v0, "Cannot create RegistryConfiguration from a PrimitiveRegistry"

    invoke-direct {p0, v0}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static get()Lcom/google/crypto/tink/internal/RegistryConfiguration;
    .locals 1

    .line 35
    sget-object v0, Lcom/google/crypto/tink/internal/RegistryConfiguration;->CONFIG:Lcom/google/crypto/tink/internal/RegistryConfiguration;

    return-object v0
.end method


# virtual methods
.method public getInputPrimitiveClass(Ljava/lang/Class;)Ljava/lang/Class;
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Class<",
            "*>;)",
            "Ljava/lang/Class<",
            "*>;"
        }
    .end annotation

    .line 60
    invoke-static {p1}, Lcom/google/crypto/tink/Registry;->getInputPrimitive(Ljava/lang/Class;)Ljava/lang/Class;

    move-result-object p1

    return-object p1
.end method

.method public getPrimitive(Lcom/google/crypto/tink/Key;Ljava/lang/Class;)Ljava/lang/Object;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<P:",
            "Ljava/lang/Object;",
            ">(",
            "Lcom/google/crypto/tink/Key;",
            "Ljava/lang/Class<",
            "TP;>;)TP;"
        }
    .end annotation

    .line 48
    invoke-static {}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->globalInstance()Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/google/crypto/tink/internal/MutablePrimitiveRegistry;->getPrimitive(Lcom/google/crypto/tink/Key;Ljava/lang/Class;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;Ljava/lang/Class;)Ljava/lang/Object;
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<B:",
            "Ljava/lang/Object;",
            "P:",
            "Ljava/lang/Object;",
            ">(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "TB;>;",
            "Ljava/lang/Class<",
            "TP;>;)TP;"
        }
    .end annotation

    .line 54
    invoke-static {p1, p2}, Lcom/google/crypto/tink/Registry;->wrap(Lcom/google/crypto/tink/internal/PrimitiveSet;Ljava/lang/Class;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
