.class Lcom/google/common/flogger/DurationRateLimiter$1;
.super Lcom/google/common/flogger/LogSiteMap;
.source "DurationRateLimiter.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/DurationRateLimiter;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/common/flogger/LogSiteMap<",
        "Lcom/google/common/flogger/DurationRateLimiter;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 42
    invoke-direct {p0}, Lcom/google/common/flogger/LogSiteMap;-><init>()V

    return-void
.end method


# virtual methods
.method protected initialValue()Lcom/google/common/flogger/DurationRateLimiter;
    .locals 1

    .line 45
    new-instance v0, Lcom/google/common/flogger/DurationRateLimiter;

    invoke-direct {v0}, Lcom/google/common/flogger/DurationRateLimiter;-><init>()V

    return-object v0
.end method

.method protected bridge synthetic initialValue()Ljava/lang/Object;
    .locals 1

    .line 42
    invoke-virtual {p0}, Lcom/google/common/flogger/DurationRateLimiter$1;->initialValue()Lcom/google/common/flogger/DurationRateLimiter;

    move-result-object v0

    return-object v0
.end method
