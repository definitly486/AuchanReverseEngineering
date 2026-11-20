.class final Lcom/google/common/flogger/util/ThrowableStackGetter;
.super Ljava/lang/Object;
.source "ThrowableStackGetter.java"

# interfaces
.implements Lcom/google/common/flogger/util/StackGetter;


# direct methods
.method constructor <init>()V
    .locals 0

    .line 24
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private findCallerIndex([Ljava/lang/StackTraceElement;Ljava/lang/Class;I)I
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "([",
            "Ljava/lang/StackTraceElement;",
            "Ljava/lang/Class<",
            "*>;I)I"
        }
    .end annotation

    .line 58
    invoke-virtual {p2}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object p2

    const/4 v0, 0x0

    .line 59
    :goto_0
    array-length v1, p1

    if-ge p3, v1, :cond_2

    .line 60
    aget-object v1, p1, p3

    invoke-virtual {v1}, Ljava/lang/StackTraceElement;->getClassName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    const/4 v0, 0x1

    goto :goto_1

    :cond_0
    if-eqz v0, :cond_1

    return p3

    :cond_1
    :goto_1
    add-int/lit8 p3, p3, 0x1

    goto :goto_0

    :cond_2
    const/4 p1, -0x1

    return p1
.end method


# virtual methods
.method public callerOf(Ljava/lang/Class;I)Ljava/lang/StackTraceElement;
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Class<",
            "*>;I)",
            "Ljava/lang/StackTraceElement;"
        }
    .end annotation

    const/4 v0, 0x1

    if-ltz p2, :cond_0

    move v1, v0

    goto :goto_0

    :cond_0
    const/4 v1, 0x0

    .line 28
    :goto_0
    const-string v2, "skipFrames must be >= 0"

    invoke-static {v1, v2}, Lcom/google/common/flogger/util/Checks;->checkArgument(ZLjava/lang/String;)V

    .line 29
    new-instance v1, Ljava/lang/Throwable;

    invoke-direct {v1}, Ljava/lang/Throwable;-><init>()V

    invoke-virtual {v1}, Ljava/lang/Throwable;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    add-int/2addr p2, v0

    .line 30
    invoke-direct {p0, v1, p1, p2}, Lcom/google/common/flogger/util/ThrowableStackGetter;->findCallerIndex([Ljava/lang/StackTraceElement;Ljava/lang/Class;I)I

    move-result p1

    const/4 p2, -0x1

    if-eq p1, p2, :cond_1

    .line 32
    aget-object p1, v1, p1

    return-object p1

    :cond_1
    const/4 p1, 0x0

    return-object p1
.end method

.method public getStackForCaller(Ljava/lang/Class;II)[Ljava/lang/StackTraceElement;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Class<",
            "*>;II)[",
            "Ljava/lang/StackTraceElement;"
        }
    .end annotation

    const/4 v0, 0x1

    const/4 v1, 0x0

    const/4 v2, -0x1

    if-eq p2, v2, :cond_1

    if-lez p2, :cond_0

    goto :goto_0

    :cond_0
    move v3, v1

    goto :goto_1

    :cond_1
    :goto_0
    move v3, v0

    .line 40
    :goto_1
    const-string v4, "maxDepth must be > 0 or -1"

    invoke-static {v3, v4}, Lcom/google/common/flogger/util/Checks;->checkArgument(ZLjava/lang/String;)V

    if-ltz p3, :cond_2

    move v3, v0

    goto :goto_2

    :cond_2
    move v3, v1

    .line 41
    :goto_2
    const-string v4, "skipFrames must be >= 0"

    invoke-static {v3, v4}, Lcom/google/common/flogger/util/Checks;->checkArgument(ZLjava/lang/String;)V

    .line 42
    new-instance v3, Ljava/lang/Throwable;

    invoke-direct {v3}, Ljava/lang/Throwable;-><init>()V

    invoke-virtual {v3}, Ljava/lang/Throwable;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v3

    add-int/2addr p3, v0

    .line 43
    invoke-direct {p0, v3, p1, p3}, Lcom/google/common/flogger/util/ThrowableStackGetter;->findCallerIndex([Ljava/lang/StackTraceElement;Ljava/lang/Class;I)I

    move-result p1

    if-ne p1, v2, :cond_3

    .line 45
    new-array p1, v1, [Ljava/lang/StackTraceElement;

    return-object p1

    .line 47
    :cond_3
    array-length p3, v3

    sub-int/2addr p3, p1

    if-lez p2, :cond_4

    if-ge p2, p3, :cond_4

    goto :goto_3

    :cond_4
    move p2, p3

    .line 51
    :goto_3
    new-array p3, p2, [Ljava/lang/StackTraceElement;

    .line 52
    invoke-static {v3, p1, p3, v1, p2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-object p3
.end method
