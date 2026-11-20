.class Lcom/google/crypto/tink/internal/PrimitiveSet$KeysetHandleImpl;
.super Ljava/lang/Object;
.source "PrimitiveSet.java"

# interfaces
.implements Lcom/google/crypto/tink/internal/KeysetHandleInterface;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/crypto/tink/internal/PrimitiveSet;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x2
    name = "KeysetHandleImpl"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/google/crypto/tink/internal/PrimitiveSet;


# direct methods
.method private constructor <init>(Lcom/google/crypto/tink/internal/PrimitiveSet;)V
    .locals 0

    .line 143
    iput-object p1, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$KeysetHandleImpl;->this$0:Lcom/google/crypto/tink/internal/PrimitiveSet;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/crypto/tink/internal/PrimitiveSet;Lcom/google/crypto/tink/internal/PrimitiveSet$1;)V
    .locals 0

    .line 143
    invoke-direct {p0, p1}, Lcom/google/crypto/tink/internal/PrimitiveSet$KeysetHandleImpl;-><init>(Lcom/google/crypto/tink/internal/PrimitiveSet;)V

    return-void
.end method


# virtual methods
.method public getAt(I)Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;
    .locals 1

    .line 156
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$KeysetHandleImpl;->this$0:Lcom/google/crypto/tink/internal/PrimitiveSet;

    invoke-static {v0}, Lcom/google/crypto/tink/internal/PrimitiveSet;->access$100(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/util/List;

    move-result-object v0

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;

    return-object p1
.end method

.method public getPrimary()Lcom/google/crypto/tink/internal/KeysetHandleInterface$Entry;
    .locals 1

    .line 146
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$KeysetHandleImpl;->this$0:Lcom/google/crypto/tink/internal/PrimitiveSet;

    invoke-static {v0}, Lcom/google/crypto/tink/internal/PrimitiveSet;->access$000(Lcom/google/crypto/tink/internal/PrimitiveSet;)Lcom/google/crypto/tink/internal/PrimitiveSet$Entry;

    move-result-object v0

    return-object v0
.end method

.method public size()I
    .locals 1

    .line 151
    iget-object v0, p0, Lcom/google/crypto/tink/internal/PrimitiveSet$KeysetHandleImpl;->this$0:Lcom/google/crypto/tink/internal/PrimitiveSet;

    invoke-static {v0}, Lcom/google/crypto/tink/internal/PrimitiveSet;->access$100(Lcom/google/crypto/tink/internal/PrimitiveSet;)Ljava/util/List;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method
