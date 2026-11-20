.class public Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;
.super Ljava/lang/Object;
.source "PrimitiveSet.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/crypto/tink/internal/PrimitiveSet;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Builder"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "<P:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;"
    }
.end annotation


# instance fields
.field private annotations:Lcom/google/crypto/tink/internal/MonitoringAnnotations;

.field private entries:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map<",
            "Lcom/google/crypto/tink/util/Bytes;",
            "Ljava/util/List<",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;>;>;"
        }
    .end annotation
.end field

.field private final entriesInKeysetOrder:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;>;"
        }
    .end annotation
.end field

.field private primary:Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;"
        }
    .end annotation
.end field

.field private final primitiveClass:Ljava/lang/Class;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/Class<",
            "TP;>;"
        }
    .end annotation
.end field

.field private primitiveConstructionFunction:Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction<",
            "Lcom/google/crypto/tink/Key;",
            "TP;>;"
        }
    .end annotation
.end field


# direct methods
.method public static synthetic $r8$lambda$uJehxU2nEm2f3Zt3gVst33MVRjQ(Lcom/google/crypto/tink/Key;)Ljava/lang/Object;
    .locals 1

    .line 227
    new-instance p0, Ljava/security/GeneralSecurityException;

    const-string v0, "No PrimitiveConstructionFunction specified"

    invoke-direct {p0, v0}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method private constructor <init>(Ljava/lang/Class;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Class<",
            "TP;>;)V"
        }
    .end annotation

    .line 313
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 220
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->entries:Ljava/util/Map;

    .line 221
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->entriesInKeysetOrder:Ljava/util/List;

    .line 224
    new-instance v0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder$$ExternalSyntheticLambda0;-><init>()V

    iput-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->primitiveConstructionFunction:Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;

    .line 314
    iput-object p1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->primitiveClass:Ljava/lang/Class;

    .line 315
    sget-object p1, Lcom/google/crypto/tink/internal/MonitoringAnnotations;->EMPTY:Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    iput-object p1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->annotations:Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    return-void
.end method

.method synthetic constructor <init>(Ljava/lang/Class;Lcom/google/crypto/tink/internal/PrimitiveSet$1;)V
    .locals 0

    .line 215
    invoke-direct {p0, p1}, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;-><init>(Ljava/lang/Class;)V

    return-void
.end method

.method private addEntry(Lcom/google/crypto/tink/Key;Lcom/google/crypto/tink/proto/Keyset$Key;Z)Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;
    .locals 9
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/Key;",
            "Lcom/google/crypto/tink/proto/Keyset$Key;",
            "Z)",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Builder<",
            "TP;>;"
        }
    .end annotation

    .line 233
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->entries:Ljava/util/Map;

    if-eqz v0, :cond_3

    .line 236
    invoke-virtual {p2}, Lcom/google/crypto/tink/proto/Keyset$Key;->getStatus()Lcom/google/crypto/tink/proto/KeyStatusType;

    move-result-object v0

    sget-object v1, Lcom/google/crypto/tink/proto/KeyStatusType;->ENABLED:Lcom/google/crypto/tink/proto/KeyStatusType;

    if-ne v0, v1, :cond_2

    .line 240
    new-instance v2, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;

    .line 242
    invoke-static {p2}, Lcom/google/crypto/tink/CryptoFormat;->getOutputPrefix(Lcom/google/crypto/tink/proto/Keyset$Key;)[B

    move-result-object v0

    invoke-static {v0}, Lcom/google/crypto/tink/util/Bytes;->copyFrom([B)Lcom/google/crypto/tink/util/Bytes;

    move-result-object v3

    sget-object v4, Lcom/google/crypto/tink/KeyStatus;->ENABLED:Lcom/google/crypto/tink/KeyStatus;

    .line 245
    invoke-virtual {p2}, Lcom/google/crypto/tink/proto/Keyset$Key;->getKeyId()I

    move-result v5

    const/4 v8, 0x0

    move-object v6, p1

    move v7, p3

    invoke-direct/range {v2 .. v8}, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;-><init>(Lcom/google/crypto/tink/util/Bytes;Lcom/google/crypto/tink/KeyStatus;ILcom/google/crypto/tink/Key;ZLcom/google/crypto/tink/internal/PrimitiveSet$1;)V

    .line 248
    iget-object p1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->entries:Ljava/util/Map;

    iget-object p2, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->entriesInKeysetOrder:Ljava/util/List;

    invoke-static {v2, p1, p2}, Lcom/google/crypto/tink/internal/PrimitiveSet;->access$400(Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;Ljava/util/Map;Ljava/util/List;)V

    if-eqz v7, :cond_1

    .line 250
    iget-object p1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->primary:Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;

    if-nez p1, :cond_0

    .line 253
    iput-object v2, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->primary:Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;

    return-object p0

    .line 251
    :cond_0
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string p2, "you cannot set two primary primitives"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_1
    return-object p0

    .line 238
    :cond_2
    new-instance p1, Ljava/security/GeneralSecurityException;

    const-string p2, "only ENABLED key is allowed"

    invoke-direct {p1, p2}, Ljava/security/GeneralSecurityException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 234
    :cond_3
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string p2, "addEntry cannot be called after build"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method


# virtual methods
.method public add(Lcom/google/crypto/tink/Key;Lcom/google/crypto/tink/proto/Keyset$Key;)Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;
    .locals 1
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/Key;",
            "Lcom/google/crypto/tink/proto/Keyset$Key;",
            ")",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Builder<",
            "TP;>;"
        }
    .end annotation

    const/4 v0, 0x0

    .line 266
    invoke-direct {p0, p1, p2, v0}, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->addEntry(Lcom/google/crypto/tink/Key;Lcom/google/crypto/tink/proto/Keyset$Key;Z)Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;

    move-result-object p1

    return-object p1
.end method

.method public addPrimary(Lcom/google/crypto/tink/Key;Lcom/google/crypto/tink/proto/Keyset$Key;)Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;
    .locals 1
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/Key;",
            "Lcom/google/crypto/tink/proto/Keyset$Key;",
            ")",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Builder<",
            "TP;>;"
        }
    .end annotation

    const/4 v0, 0x1

    .line 277
    invoke-direct {p0, p1, p2, v0}, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->addEntry(Lcom/google/crypto/tink/Key;Lcom/google/crypto/tink/proto/Keyset$Key;Z)Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;

    move-result-object p1

    return-object p1
.end method

.method public addPrimitiveConstructor(Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;)Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;
    .locals 0
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction<",
            "Lcom/google/crypto/tink/Key;",
            "TP;>;)",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Builder<",
            "TP;>;"
        }
    .end annotation

    .line 292
    iput-object p1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->primitiveConstructionFunction:Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;

    return-object p0
.end method

.method public build()Lcom/google/crypto/tink/internal/PrimitiveSet;
    .locals 8
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/crypto/tink/internal/PrimitiveSet<",
            "TP;>;"
        }
    .end annotation

    .line 297
    iget-object v1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->entries:Ljava/util/Map;

    if-eqz v1, :cond_0

    .line 301
    new-instance v0, Lcom/google/crypto/tink/internal/PrimitiveSet;

    iget-object v2, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->entriesInKeysetOrder:Ljava/util/List;

    iget-object v3, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->primary:Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;

    iget-object v4, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->annotations:Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    iget-object v5, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->primitiveConstructionFunction:Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;

    iget-object v6, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->primitiveClass:Ljava/lang/Class;

    const/4 v7, 0x0

    invoke-direct/range {v0 .. v7}, Lcom/google/crypto/tink/internal/PrimitiveSet;-><init>(Ljava/util/Map;Ljava/util/List;Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;Ljava/lang/Class;Lcom/google/crypto/tink/internal/PrimitiveSet$1;)V

    const/4 v1, 0x0

    .line 309
    iput-object v1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->entries:Ljava/util/Map;

    return-object v0

    .line 298
    :cond_0
    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "build cannot be called twice"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public setAnnotations(Lcom/google/crypto/tink/internal/MonitoringAnnotations;)Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;
    .locals 1
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/MonitoringAnnotations;",
            ")",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Builder<",
            "TP;>;"
        }
    .end annotation

    .line 282
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->entries:Ljava/util/Map;

    if-eqz v0, :cond_0

    .line 285
    iput-object p1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;->annotations:Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    return-object p0

    .line 283
    :cond_0
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string v0, "setAnnotations cannot be called after build"

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
