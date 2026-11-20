.class final Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;
.super Lcom/google/common/flogger/context/ScopedLoggingContext;
.source "NoOpContextDataProvider.java"

# interfaces
.implements Lcom/google/common/flogger/context/ScopedLoggingContext$LoggingContextCloseable;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/context/NoOpContextDataProvider;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "NoOpScopedLoggingContext"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext$LazyLogger;
    }
.end annotation


# instance fields
.field private final haveWarned:Ljava/util/concurrent/atomic/AtomicBoolean;


# direct methods
.method private constructor <init>()V
    .locals 1

    .line 40
    invoke-direct {p0}, Lcom/google/common/flogger/context/ScopedLoggingContext;-><init>()V

    .line 48
    new-instance v0, Ljava/util/concurrent/atomic/AtomicBoolean;

    invoke-direct {v0}, Ljava/util/concurrent/atomic/AtomicBoolean;-><init>()V

    iput-object v0, p0, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;->haveWarned:Ljava/util/concurrent/atomic/AtomicBoolean;

    return-void
.end method

.method synthetic constructor <init>(Lcom/google/common/flogger/context/NoOpContextDataProvider$1;)V
    .locals 0

    .line 40
    invoke-direct {p0}, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;-><init>()V

    return-void
.end method

.method static synthetic access$100(Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;)V
    .locals 0

    .line 40
    invoke-direct {p0}, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;->logWarningOnceOnly()V

    return-void
.end method

.method private logWarningOnceOnly()V
    .locals 3

    .line 51
    iget-object v0, p0, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;->haveWarned:Ljava/util/concurrent/atomic/AtomicBoolean;

    const/4 v1, 0x0

    const/4 v2, 0x1

    invoke-virtual {v0, v1, v2}, Ljava/util/concurrent/atomic/AtomicBoolean;->compareAndSet(ZZ)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 52
    invoke-static {}, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext$LazyLogger;->access$000()Lcom/google/common/flogger/FluentLogger;

    move-result-object v0

    .line 53
    invoke-virtual {v0}, Lcom/google/common/flogger/AbstractLogger;->atWarning()Lcom/google/common/flogger/LoggingApi;

    move-result-object v0

    check-cast v0, Lcom/google/common/flogger/FluentLogger$Api;

    sget-object v1, Lcom/google/common/flogger/StackSize;->SMALL:Lcom/google/common/flogger/StackSize;

    .line 54
    invoke-interface {v0, v1}, Lcom/google/common/flogger/LoggingApi;->withStackTrace(Lcom/google/common/flogger/StackSize;)Lcom/google/common/flogger/LoggingApi;

    move-result-object v0

    check-cast v0, Lcom/google/common/flogger/FluentLogger$Api;

    const-string v1, "Scoped logging contexts are disabled; no context data provider was installed.\nTo enable scoped logging contexts in your application, see the site-specific Platform class used to configure logging behaviour.\nDefault Platform: com.google.common.flogger.backend.system.DefaultPlatform"

    .line 55
    invoke-interface {v0, v1}, Lcom/google/common/flogger/LoggingApi;->log(Ljava/lang/String;)V

    :cond_0
    return-void
.end method


# virtual methods
.method public addMetadata(Lcom/google/common/flogger/MetadataKey;Ljava/lang/Object;)Z
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<T:",
            "Ljava/lang/Object;",
            ">(",
            "Lcom/google/common/flogger/MetadataKey<",
            "TT;>;TT;)Z"
        }
    .end annotation

    .line 89
    invoke-direct {p0}, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;->logWarningOnceOnly()V

    .line 90
    invoke-super {p0, p1, p2}, Lcom/google/common/flogger/context/ScopedLoggingContext;->addMetadata(Lcom/google/common/flogger/MetadataKey;Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public addTags(Lcom/google/common/flogger/context/Tags;)Z
    .locals 0

    .line 82
    invoke-direct {p0}, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;->logWarningOnceOnly()V

    .line 84
    invoke-super {p0, p1}, Lcom/google/common/flogger/context/ScopedLoggingContext;->addTags(Lcom/google/common/flogger/context/Tags;)Z

    move-result p1

    return p1
.end method

.method public applyLogLevelMap(Lcom/google/common/flogger/context/LogLevelMap;)Z
    .locals 0

    .line 95
    invoke-direct {p0}, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;->logWarningOnceOnly()V

    .line 96
    invoke-super {p0, p1}, Lcom/google/common/flogger/context/ScopedLoggingContext;->applyLogLevelMap(Lcom/google/common/flogger/context/LogLevelMap;)Z

    move-result p1

    return p1
.end method

.method public close()V
    .locals 0

    .line 0
    return-void
.end method

.method isNoOp()Z
    .locals 1

    .line 0
    const/4 v0, 0x1

    return v0
.end method

.method public newContext()Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;
    .locals 1

    .line 65
    new-instance v0, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext$1;

    invoke-direct {v0, p0}, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext$1;-><init>(Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;)V

    return-object v0
.end method

.method public newContext(Lcom/google/common/flogger/context/ScopeType;)Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;
    .locals 0

    .line 77
    invoke-virtual {p0}, Lcom/google/common/flogger/context/NoOpContextDataProvider$NoOpScopedLoggingContext;->newContext()Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;

    move-result-object p1

    return-object p1
.end method
