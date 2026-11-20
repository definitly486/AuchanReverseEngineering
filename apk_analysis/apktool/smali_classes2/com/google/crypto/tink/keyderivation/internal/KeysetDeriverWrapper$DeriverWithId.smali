.class Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$DeriverWithId;
.super Ljava/lang/Object;
.source "KeysetDeriverWrapper.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0xa
    name = "DeriverWithId"
.end annotation


# instance fields
.field final deriver:Lcom/google/crypto/tink/keyderivation/internal/KeyDeriver;

.field final id:I

.field final isPrimary:Z


# direct methods
.method constructor <init>(Lcom/google/crypto/tink/keyderivation/internal/KeyDeriver;IZ)V
    .locals 0

    .line 35
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 36
    iput-object p1, p0, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$DeriverWithId;->deriver:Lcom/google/crypto/tink/keyderivation/internal/KeyDeriver;

    .line 37
    iput p2, p0, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$DeriverWithId;->id:I

    .line 38
    iput-boolean p3, p0, Lcom/google/crypto/tink/keyderivation/internal/KeysetDeriverWrapper$DeriverWithId;->isPrimary:Z

    return-void
.end method
