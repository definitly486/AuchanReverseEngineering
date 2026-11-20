.class Lcom/google/common/flogger/RateLimitStatus$LogGuard$1;
.super Lcom/google/common/flogger/LogSiteMap;
.source "RateLimitStatus.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/RateLimitStatus$LogGuard;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/common/flogger/LogSiteMap<",
        "Lcom/google/common/flogger/RateLimitStatus$LogGuard;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 145
    invoke-direct {p0}, Lcom/google/common/flogger/LogSiteMap;-><init>()V

    return-void
.end method


# virtual methods
.method public initialValue()Lcom/google/common/flogger/RateLimitStatus$LogGuard;
    .locals 2

    .line 148
    new-instance v0, Lcom/google/common/flogger/RateLimitStatus$LogGuard;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/google/common/flogger/RateLimitStatus$LogGuard;-><init>(Lcom/google/common/flogger/RateLimitStatus$1;)V

    return-object v0
.end method

.method public bridge synthetic initialValue()Ljava/lang/Object;
    .locals 1

    .line 145
    invoke-virtual {p0}, Lcom/google/common/flogger/RateLimitStatus$LogGuard$1;->initialValue()Lcom/google/common/flogger/RateLimitStatus$LogGuard;

    move-result-object v0

    return-object v0
.end method
