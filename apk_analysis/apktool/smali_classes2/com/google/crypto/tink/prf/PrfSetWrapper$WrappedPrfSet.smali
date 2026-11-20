.class Lcom/google/crypto/tink/prf/PrfSetWrapper$WrappedPrfSet;
.super Lcom/google/crypto/tink/prf/PrfSet;
.source "PrfSetWrapper.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/crypto/tink/prf/PrfSetWrapper;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0xa
    name = "WrappedPrfSet"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/prf/PrfSetWrapper$WrappedPrfSet$PrfWithMonitoring;
    }
.end annotation


# instance fields
.field private final keyIdToPrfMap:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map<",
            "Ljava/lang/Integer;",
            "Lcom/google/crypto/tink/prf/Prf;",
            ">;"
        }
    .end annotation
.end field

.field private final primaryKeyId:I


# direct methods
.method private constructor <init>(Ljava/util/Map;I)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map<",
            "Ljava/lang/Integer;",
            "Lcom/google/crypto/tink/prf/Prf;",
            ">;I)V"
        }
    .end annotation

    .line 82
    invoke-direct {p0}, Lcom/google/crypto/tink/prf/PrfSet;-><init>()V

    .line 83
    iput-object p1, p0, Lcom/google/crypto/tink/prf/PrfSetWrapper$WrappedPrfSet;->keyIdToPrfMap:Ljava/util/Map;

    .line 84
    iput p2, p0, Lcom/google/crypto/tink/prf/PrfSetWrapper$WrappedPrfSet;->primaryKeyId:I

    return-void
.end method

.method synthetic constructor <init>(Ljava/util/Map;ILcom/google/crypto/tink/prf/PrfSetWrapper$1;)V
    .locals 0

    .line 48
    invoke-direct {p0, p1, p2}, Lcom/google/crypto/tink/prf/PrfSetWrapper$WrappedPrfSet;-><init>(Ljava/util/Map;I)V

    return-void
.end method


# virtual methods
.method public getPrfs()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map<",
            "Ljava/lang/Integer;",
            "Lcom/google/crypto/tink/prf/Prf;",
            ">;"
        }
    .end annotation

    .line 94
    iget-object v0, p0, Lcom/google/crypto/tink/prf/PrfSetWrapper$WrappedPrfSet;->keyIdToPrfMap:Ljava/util/Map;

    return-object v0
.end method

.method public getPrimaryId()I
    .locals 1

    .line 89
    iget v0, p0, Lcom/google/crypto/tink/prf/PrfSetWrapper$WrappedPrfSet;->primaryKeyId:I

    return v0
.end method
