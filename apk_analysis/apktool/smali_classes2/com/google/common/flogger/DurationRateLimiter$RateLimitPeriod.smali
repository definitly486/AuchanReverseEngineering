.class final Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;
.super Ljava/lang/Object;
.source "DurationRateLimiter.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/DurationRateLimiter;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = "RateLimitPeriod"
.end annotation


# instance fields
.field private final n:I

.field private final unit:Ljava/util/concurrent/TimeUnit;


# direct methods
.method private constructor <init>(ILjava/util/concurrent/TimeUnit;)V
    .locals 2

    .line 81
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    if-lez p1, :cond_0

    .line 86
    iput p1, p0, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->n:I

    .line 87
    const-string p1, "time unit"

    invoke-static {p2, p1}, Lcom/google/common/flogger/util/Checks;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/util/concurrent/TimeUnit;

    iput-object p1, p0, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->unit:Ljava/util/concurrent/TimeUnit;

    return-void

    .line 84
    :cond_0
    new-instance p2, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "time period must be positive: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p2, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p2
.end method

.method synthetic constructor <init>(ILjava/util/concurrent/TimeUnit;Lcom/google/common/flogger/DurationRateLimiter$1;)V
    .locals 0

    .line 77
    invoke-direct {p0, p1, p2}, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;-><init>(ILjava/util/concurrent/TimeUnit;)V

    return-void
.end method

.method static synthetic access$100(Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;)J
    .locals 2

    .line 77
    invoke-direct {p0}, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->toNanos()J

    move-result-wide v0

    return-wide v0
.end method

.method private toNanos()J
    .locals 3

    .line 95
    iget-object v0, p0, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->unit:Ljava/util/concurrent/TimeUnit;

    iget v1, p0, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->n:I

    int-to-long v1, v1

    invoke-virtual {v0, v1, v2}, Ljava/util/concurrent/TimeUnit;->toNanos(J)J

    move-result-wide v0

    return-wide v0
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 3

    .line 111
    instance-of v0, p1, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    .line 112
    check-cast p1, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;

    .line 113
    iget v0, p0, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->n:I

    iget v2, p1, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->n:I

    if-ne v0, v2, :cond_0

    iget-object v0, p0, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->unit:Ljava/util/concurrent/TimeUnit;

    iget-object p1, p1, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->unit:Ljava/util/concurrent/TimeUnit;

    if-ne v0, p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    return v1
.end method

.method public hashCode()I
    .locals 2

    .line 106
    iget v0, p0, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->n:I

    mul-int/lit8 v0, v0, 0x25

    iget-object v1, p0, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->unit:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v1}, Ljava/lang/Object;->hashCode()I

    move-result v1

    xor-int/2addr v0, v1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 100
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iget v1, p0, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->n:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, " "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/google/common/flogger/DurationRateLimiter$RateLimitPeriod;->unit:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
