.class Lcom/google/common/flogger/CountingRateLimiter$1;
.super Lcom/google/common/flogger/LogSiteMap;
.source "CountingRateLimiter.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/CountingRateLimiter;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/common/flogger/LogSiteMap<",
        "Lcom/google/common/flogger/CountingRateLimiter;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 37
    invoke-direct {p0}, Lcom/google/common/flogger/LogSiteMap;-><init>()V

    return-void
.end method


# virtual methods
.method protected initialValue()Lcom/google/common/flogger/CountingRateLimiter;
    .locals 1

    .line 40
    new-instance v0, Lcom/google/common/flogger/CountingRateLimiter;

    invoke-direct {v0}, Lcom/google/common/flogger/CountingRateLimiter;-><init>()V

    return-object v0
.end method

.method protected bridge synthetic initialValue()Ljava/lang/Object;
    .locals 1

    .line 37
    invoke-virtual {p0}, Lcom/google/common/flogger/CountingRateLimiter$1;->initialValue()Lcom/google/common/flogger/CountingRateLimiter;

    move-result-object v0

    return-object v0
.end method
