.class public final Lcom/google/crypto/tink/internal/PrimitiveSet;
.super Ljava/lang/Object;
.source "PrimitiveSet.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;,
        Lcom/google/crypto/tink/internal/PrimitiveSet$KeysetHandleImpl;,
        Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;
    }
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
.field private final annotations:Lcom/google/crypto/tink/internal/MonitoringAnnotations;

.field private final entries:Ljava/util/Map;
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

.field private final primary:Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;
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

.field private final primitiveConstructionFunction:Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction<",
            "Lcom/google/crypto/tink/Key;",
            "TP;>;"
        }
    .end annotation
.end field


# direct methods
.method private constructor <init>(Ljava/util/Map;Ljava/util/List;Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;Ljava/lang/Class;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map<",
            "Lcom/google/crypto/tink/util/Bytes;",
            "Ljava/util/List<",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;>;>;",
            "Ljava/util/List<",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;>;",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;",
            "Lcom/google/crypto/tink/internal/MonitoringAnnotations;",
            "Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction<",
            "Lcom/google/crypto/tink/Key;",
            "TP;>;",
            "Ljava/lang/Class<",
            "TP;>;)V"
        }
    .end annotation

    .line 201
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 202
    iput-object p1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->entries:Ljava/util/Map;

    .line 203
    iput-object p2, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->entriesInKeysetOrder:Ljava/util/List;

    .line 204
    iput-object p3, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->primary:Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;

    .line 205
    iput-object p5, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->primitiveConstructionFunction:Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;

    .line 206
    iput-object p6, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->primitiveClass:Ljava/lang/Class;

    .line 207
    iput-object p4, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->annotations:Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    return-void
.end method

.method synthetic constructor <init>(Ljava/util/Map;Ljava/util/List;Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;Ljava/lang/Class;Lcom/google/crypto/tink/internal/PrimitiveSet$1;)V
    .locals 0

    .line 51
    invoke-direct/range {p0 .. p6}, Lcom/google/crypto/tink/internal/PrimitiveSet;-><init>(Ljava/util/Map;Ljava/util/List;Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;Lcom/google/crypto/tink/internal/MonitoringAnnotations;Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;Ljava/lang/Class;)V

    return-void
.end method

.method static synthetic access$000(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;
    .locals 0

    .line 51
    iget-object p0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->primary:Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;

    return-object p0
.end method

.method static synthetic access$100(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/util/List;
    .locals 0

    .line 51
    iget-object p0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->entriesInKeysetOrder:Ljava/util/List;

    return-object p0
.end method

.method static synthetic access$400(Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;Ljava/util/Map;Ljava/util/List;)V
    .locals 0

    .line 51
    invoke-static {p0, p1, p2}, Lcom/google/crypto/tink/internal/PrimitiveSet;->storeEntryInPrimitiveSet(Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;Ljava/util/Map;Ljava/util/List;)V

    return-void
.end method

.method public static newBuilder(Ljava/lang/Class;)Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<P:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/lang/Class<",
            "TP;>;)",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Builder<",
            "TP;>;"
        }
    .end annotation

    .line 320
    new-instance v0, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;

    const/4 v1, 0x0

    invoke-direct {v0, p0, v1}, Lcom/google/crypto/tink/internal/PrimitiveSet$Builder;-><init>(Ljava/lang/Class;Lcom/google/crypto/tink/internal/PrimitiveSet$1;)V

    return-object v0
.end method

.method private static storeEntryInPrimitiveSet(Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;Ljava/util/Map;Ljava/util/List;)V
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<P:",
            "Ljava/lang/Object;",
            ">(",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;",
            "Ljava/util/Map<",
            "Lcom/google/crypto/tink/util/Bytes;",
            "Ljava/util/List<",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;>;>;",
            "Ljava/util/List<",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;>;)V"
        }
    .end annotation

    .line 112
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    .line 113
    invoke-interface {v0, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 115
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

    move-result-object v1

    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    invoke-interface {p1, v1, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/List;

    if-eqz v0, :cond_0

    .line 117
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    .line 118
    invoke-interface {v1, v0}, Ljava/util/List;->addAll(Ljava/util/Collection;)Z

    .line 119
    invoke-interface {v1, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 120
    invoke-virtual {p0}, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;

    move-result-object v0

    invoke-static {v1}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v1

    invoke-interface {p1, v0, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 122
    :cond_0
    invoke-interface {p2, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method


# virtual methods
.method getAll()Ljava/util/Collection;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Collection<",
            "Ljava/util/List<",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;>;>;"
        }
    .end annotation

    .line 170
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->entries:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->values()Ljava/util/Collection;

    move-result-object v0

    return-object v0
.end method

.method getAllInKeysetOrder()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;>;"
        }
    .end annotation

    .line 175
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->entriesInKeysetOrder:Ljava/util/List;

    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getAnnotations()Lcom/google/crypto/tink/internal/MonitoringAnnotations;
    .locals 1

    .line 132
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->annotations:Lcom/google/crypto/tink/internal/MonitoringAnnotations;

    return-object v0
.end method

.method public getKeysetHandle()Lcom/google/crypto/tink/internal/KeysetHandleInterface;
    .locals 2

    .line 161
    new-instance v0, Lcom/google/crypto/tink/internal/PrimitiveSet$KeysetHandleImpl;

    const/4 v1, 0x0

    invoke-direct {v0, p0, v1}, Lcom/google/crypto/tink/internal/PrimitiveSet$KeysetHandleImpl;-><init>(Lcom/google/crypto/tink/internal/PrimitiveSet;Lcom/google/crypto/tink/internal/PrimitiveSet$1;)V

    return-object v0
.end method

.method getPrimary()Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/crypto/tink/internal/PrimitiveSet$Entry<",
            "TP;>;"
        }
    .end annotation

    .line 128
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->primary:Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;

    return-object v0
.end method

.method public getPrimitiveClass()Ljava/lang/Class;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/lang/Class<",
            "TP;>;"
        }
    .end annotation

    .line 211
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->primitiveClass:Ljava/lang/Class;

    return-object v0
.end method

.method public getPrimitiveForEntry(Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;)Ljava/lang/Object;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;",
            ")TP;"
        }
    .end annotation

    .line 165
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet;->primitiveConstructionFunction:Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;

    invoke-interface {p1}, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;->getKey()Lcom/google/crypto/tink/Key;

    move-result-object p1

    invoke-interface {v0, p1}, Lcom/google/crypto/tink/internal/PrimitiveConstructor$PrimitiveConstructionFunction;->constructPrimitive(Lcom/google/crypto/tink/Key;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
