.class Lcom/google/common/flogger/util/RecursionDepth$1;
.super Ljava/lang/ThreadLocal;
.source "RecursionDepth.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/util/RecursionDepth;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/ThreadLocal<",
        "Lcom/google/common/flogger/util/RecursionDepth;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 32
    invoke-direct {p0}, Ljava/lang/ThreadLocal;-><init>()V

    return-void
.end method


# virtual methods
.method protected initialValue()Lcom/google/common/flogger/util/RecursionDepth;
    .locals 1

    .line 35
    new-instance v0, Lcom/google/common/flogger/util/RecursionDepth;

    invoke-direct {v0}, Lcom/google/common/flogger/util/RecursionDepth;-><init>()V

    return-object v0
.end method

.method protected bridge synthetic initialValue()Ljava/lang/Object;
    .locals 1

    .line 32
    invoke-virtual {p0}, Lcom/google/common/flogger/util/RecursionDepth$1;->initialValue()Lcom/google/common/flogger/util/RecursionDepth;

    move-result-object v0

    return-object v0
.end method
