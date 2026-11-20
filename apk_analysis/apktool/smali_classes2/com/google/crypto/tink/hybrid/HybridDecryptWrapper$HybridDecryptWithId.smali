.class Lcom/google/crypto/tink/hybrid/HybridDecryptWrapper$HybridDecryptWithId;
.super Ljava/lang/Object;
.source "HybridDecryptWrapper.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/crypto/tink/hybrid/HybridDecryptWrapper;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0xa
    name = "HybridDecryptWithId"
.end annotation


# instance fields
.field public final hybridDecrypt:Lcom/google/crypto/tink/HybridDecrypt;

.field public final id:I


# direct methods
.method public constructor <init>(Lcom/google/crypto/tink/HybridDecrypt;I)V
    .locals 0

    .line 45
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 46
    iput-object p1, p0, Lcom/google/crypto/tink/hybrid/HybridDecryptWrapper$HybridDecryptWithId;->hybridDecrypt:Lcom/google/crypto/tink/HybridDecrypt;

    .line 47
    iput p2, p0, Lcom/google/crypto/tink/hybrid/HybridDecryptWrapper$HybridDecryptWithId;->id:I

    return-void
.end method
