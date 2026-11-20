.class public final Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;
.super Ljava/lang/Object;
.source "PrimitiveSet.java"

# interfaces
.implements Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/crypto/tink/internal/PrimitiveSet;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Entry"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "<P:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;",
        "Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;"
    }
.end annotation


# instance fields
.field private final isPrimary:Z

.field private final key:Lcom/google/crypto/tink/Key;

.field private final keyId:I

.field private final outputPrefix:Lcom/google/crypto/tink/util/Bytes;

.field private final status:Lcom/google/crypto/tink/KeyStatus;


# direct methods
.method private constructor <init>(Lcom/google/crypto/tink/util/Bytes;Lcom/google/crypto/tink/KeyStatus;ILcom/google/crypto/tink/Key;Z)V
    .locals 0

    .line 69
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 70
    iput-object p1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->outputPrefix:Lcom/google/crypto/tink/util/Bytes;

    .line 71
    iput-object p2, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->status:Lcom/google/crypto/tink/KeyStatus;

    .line 72
    iput p3, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->keyId:I

    .line 73
    iput-object p4, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->key:Lcom/google/crypto/tink/Key;

    .line 74
    iput-boolean p5, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->isPrimary:Z

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/crypto/tink/util/Bytes;Lcom/google/crypto/tink/KeyStatus;ILcom/google/crypto/tink/Key;ZLcom/google/crypto/tink/internal/PrimitiveSet$1;)V
    .locals 0

    .line 57
    invoke-direct/range {p0 .. p5}, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;-><init>(Lcom/google/crypto/tink/util/Bytes;Lcom/google/crypto/tink/KeyStatus;ILcom/google/crypto/tink/Key;Z)V

    return-void
.end method


# virtual methods
.method public getId()I
    .locals 1

    .line 88
    iget v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->keyId:I

    return v0
.end method

.method public getKey()Lcom/google/crypto/tink/Key;
    .locals 1

    .line 93
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->key:Lcom/google/crypto/tink/Key;

    return-object v0
.end method

.method final getOutputPrefix()Lcom/google/crypto/tink/util/Bytes;
    .locals 1

    .line 83
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->outputPrefix:Lcom/google/crypto/tink/util/Bytes;

    return-object v0
.end method

.method public getParameters()Lcom/google/crypto/tink/Parameters;
    .locals 1

    .line 98
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->key:Lcom/google/crypto/tink/Key;

    if-nez v0, :cond_0

    const/4 v0, 0x0

    return-object v0

    .line 101
    :cond_0
    invoke-virtual {v0}, Lcom/google/crypto/tink/Key;->getParameters()Lcom/google/crypto/tink/Parameters;

    move-result-object v0

    return-object v0
.end method

.method public getStatus()Lcom/google/crypto/tink/KeyStatus;
    .locals 1

    .line 79
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->status:Lcom/google/crypto/tink/KeyStatus;

    return-object v0
.end method

.method public isPrimary()Z
    .locals 1

    .line 106
    iget-boolean v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;->isPrimary:Z

    return v0
.end method
