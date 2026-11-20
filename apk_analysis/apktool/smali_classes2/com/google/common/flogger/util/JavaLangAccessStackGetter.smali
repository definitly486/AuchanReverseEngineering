.class final Lcom/google/common/flogger/util/JavaLangAccessStackGetter;
.super Ljava/lang/Object;
.source "JavaLangAccessStackGetter.java"

# interfaces
.implements Lcom/google/common/flogger/util/StackGetter;


# static fields
.field private static final access:Lsun/misc/JavaLangAccess;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 31
    invoke-static {}, Lsun/misc/SharedSecrets;->getJavaLangAccess()Lsun/misc/JavaLangAccess;

    move-result-object v0

    sput-object v0, Lcom/google/common/flogger/util/JavaLangAccessStackGetter;->access:Lsun/misc/JavaLangAccess;

    return-void
.end method

.method constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private findCallerIndex(Ljava/lang/Throwable;Ljava/lang/Class;I)I
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Throwable;",
            "Ljava/lang/Class<",
            "*>;I)I"
        }
    .end annotation

    .line 62
    sget-object v0, Lcom/google/common/flogger/util/JavaLangAccessStackGetter;->access:Lsun/misc/JavaLangAccess;

    invoke-interface {v0, p1}, Lsun/misc/JavaLangAccess;->getStackTraceDepth(Ljava/lang/Throwable;)I

    move-result v0

    .line 64
    invoke-virtual {p2}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object p2

    const/4 v1, 0x0

    :goto_0
    if-ge p3, v0, :cond_2

    .line 66
    sget-object v2, Lcom/google/common/flogger/util/JavaLangAccessStackGetter;->access:Lsun/misc/JavaLangAccess;

    invoke-interface {v2, p1, p3}, Lsun/misc/JavaLangAccess;->getStackTraceElement(Ljava/lang/Throwable;I)Ljava/lang/StackTraceElement;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StackTraceElement;->getClassName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v2, p2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    const/4 v1, 0x1

    goto :goto_1

    :cond_0
    if-eqz v1, :cond_1

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

    .line 35
    :goto_0
    const-string v2, "skipFrames must be >= 0"

    invoke-static {v1, v2}, Lcom/google/common/flogger/util/Checks;->checkArgument(ZLjava/lang/String;)V

    .line 36
    new-instance v1, Ljava/lang/Throwable;

    invoke-direct {v1}, Ljava/lang/Throwable;-><init>()V

    add-int/2addr p2, v0

    .line 37
    invoke-direct {p0, v1, p1, p2}, Lcom/google/common/flogger/util/JavaLangAccessStackGetter;->findCallerIndex(Ljava/lang/Throwable;Ljava/lang/Class;I)I

    move-result p1

    const/4 p2, -0x1

    if-ne p1, p2, :cond_1

    const/4 p1, 0x0

    return-object p1

    .line 38
    :cond_1
    sget-object p2, Lcom/google/common/flogger/util/JavaLangAccessStackGetter;->access:Lsun/misc/JavaLangAccess;

    invoke-interface {p2, v1, p1}, Lsun/misc/JavaLangAccess;->getStackTraceElement(Ljava/lang/Throwable;I)Ljava/lang/StackTraceElement;

    move-result-object p1

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

    .line 43
    :goto_1
    const-string v4, "maxDepth must be > 0 or -1"

    invoke-static {v3, v4}, Lcom/google/common/flogger/util/Checks;->checkArgument(ZLjava/lang/String;)V

    if-ltz p3, :cond_2

    move v3, v0

    goto :goto_2

    :cond_2
    move v3, v1

    .line 44
    :goto_2
    const-string v4, "skipFrames must be >= 0"

    invoke-static {v3, v4}, Lcom/google/common/flogger/util/Checks;->checkArgument(ZLjava/lang/String;)V

    .line 45
    new-instance v3, Ljava/lang/Throwable;

    invoke-direct {v3}, Ljava/lang/Throwable;-><init>()V

    add-int/2addr p3, v0

    .line 46
    invoke-direct {p0, v3, p1, p3}, Lcom/google/common/flogger/util/JavaLangAccessStackGetter;->findCallerIndex(Ljava/lang/Throwable;Ljava/lang/Class;I)I

    move-result p1

    if-ne p1, v2, :cond_3

    .line 48
    new-array p1, v1, [Ljava/lang/StackTraceElement;

    return-object p1

    .line 50
    :cond_3
    sget-object p3, Lcom/google/common/flogger/util/JavaLangAccessStackGetter;->access:Lsun/misc/JavaLangAccess;

    invoke-interface {p3, v3}, Lsun/misc/JavaLangAccess;->getStackTraceDepth(Ljava/lang/Throwable;)I

    move-result p3

    sub-int/2addr p3, p1

    if-lez p2, :cond_4

    if-ge p2, p3, :cond_4

    goto :goto_3

    :cond_4
    move p2, p3

    .line 54
    :goto_3
    new-array p3, p2, [Ljava/lang/StackTraceElement;

    :goto_4
    if-ge v1, p2, :cond_5

    .line 56
    sget-object v0, Lcom/google/common/flogger/util/JavaLangAccessStackGetter;->access:Lsun/misc/JavaLangAccess;

    add-int v2, p1, v1

    invoke-interface {v0, v3, v2}, Lsun/misc/JavaLangAccess;->getStackTraceElement(Ljava/lang/Throwable;I)Ljava/lang/StackTraceElement;

    move-result-object v0

    aput-object v0, p3, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_4

    :cond_5
    return-object p3
.end method
