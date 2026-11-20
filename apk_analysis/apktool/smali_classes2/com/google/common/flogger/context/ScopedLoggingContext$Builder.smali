.class public abstract Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;
.super Ljava/lang/Object;
.source "ScopedLoggingContext.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/context/ScopedLoggingContext;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "Builder"
.end annotation


# instance fields
.field private hasLogLevelMap:Z

.field private logLevelMap:Lcom/google/common/flogger/context/LogLevelMap;

.field private metadata:Lcom/google/common/flogger/context/ContextMetadata$Builder;

.field private tags:Lcom/google/common/flogger/context/Tags;


# direct methods
.method protected constructor <init>()V
    .locals 1

    .line 140
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x0

    .line 135
    iput-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->tags:Lcom/google/common/flogger/context/Tags;

    .line 136
    iput-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->metadata:Lcom/google/common/flogger/context/ContextMetadata$Builder;

    .line 137
    iput-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->logLevelMap:Lcom/google/common/flogger/context/LogLevelMap;

    const/4 v0, 0x0

    .line 138
    iput-boolean v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->hasLogLevelMap:Z

    return-void
.end method


# virtual methods
.method public final call(Ljava/util/concurrent/Callable;)Ljava/lang/Object;
    .locals 0
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<R:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/concurrent/Callable<",
            "TR;>;)TR;"
        }
    .end annotation

    .line 242
    invoke-virtual {p0, p1}, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->wrap(Ljava/util/concurrent/Callable;)Ljava/util/concurrent/Callable;

    move-result-object p1

    invoke-interface {p1}, Ljava/util/concurrent/Callable;->call()Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final callUnchecked(Ljava/util/concurrent/Callable;)Ljava/lang/Object;
    .locals 2
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<R:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/concurrent/Callable<",
            "TR;>;)TR;"
        }
    .end annotation

    .line 252
    :try_start_0
    invoke-virtual {p0, p1}, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->call(Ljava/util/concurrent/Callable;)Ljava/lang/Object;

    move-result-object p1
    :try_end_0
    .catch Ljava/lang/RuntimeException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    return-object p1

    :catch_0
    move-exception p1

    .line 256
    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "checked exception caught during context call"

    invoke-direct {v0, v1, p1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    throw v0

    :catch_1
    move-exception p1

    .line 254
    throw p1
.end method

.method protected final getLogLevelMap()Lcom/google/common/flogger/context/LogLevelMap;
    .locals 1

    .line 311
    iget-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->logLevelMap:Lcom/google/common/flogger/context/LogLevelMap;

    return-object v0
.end method

.method protected final getMetadata()Lcom/google/common/flogger/context/ContextMetadata;
    .locals 1

    .line 303
    iget-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->metadata:Lcom/google/common/flogger/context/ContextMetadata$Builder;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/google/common/flogger/context/ContextMetadata$Builder;->build()Lcom/google/common/flogger/context/ContextMetadata;

    move-result-object v0

    return-object v0

    :cond_0
    const/4 v0, 0x0

    return-object v0
.end method

.method protected final getTags()Lcom/google/common/flogger/context/Tags;
    .locals 1

    .line 295
    iget-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->tags:Lcom/google/common/flogger/context/Tags;

    return-object v0
.end method

.method public abstract install()Lcom/google/common/flogger/context/ScopedLoggingContext$LoggingContextCloseable;
    .annotation build Lcom/google/errorprone/annotations/MustBeClosed;
    .end annotation
.end method

.method public final run(Ljava/lang/Runnable;)V
    .locals 0

    .line 236
    invoke-virtual {p0, p1}, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->wrap(Ljava/lang/Runnable;)Ljava/lang/Runnable;

    move-result-object p1

    invoke-interface {p1}, Ljava/lang/Runnable;->run()V

    return-void
.end method

.method public final withLogLevelMap(Lcom/google/common/flogger/context/LogLevelMap;)Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;
    .locals 3
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .line 176
    iget-boolean v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->hasLogLevelMap:Z

    const/4 v1, 0x1

    xor-int/2addr v0, v1

    const-string v2, "log level map already set"

    invoke-static {v0, v2}, Lcom/google/common/flogger/util/Checks;->checkState(ZLjava/lang/String;)V

    .line 177
    iput-boolean v1, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->hasLogLevelMap:Z

    .line 178
    iput-object p1, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->logLevelMap:Lcom/google/common/flogger/context/LogLevelMap;

    return-object p0
.end method

.method public final withMetadata(Lcom/google/common/flogger/MetadataKey;Ljava/lang/Object;)Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;
    .locals 1
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<T:",
            "Ljava/lang/Object;",
            ">(",
            "Lcom/google/common/flogger/MetadataKey<",
            "TT;>;TT;)",
            "Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;"
        }
    .end annotation

    if-nez p2, :cond_0

    return-object p0

    .line 163
    :cond_0
    iget-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->metadata:Lcom/google/common/flogger/context/ContextMetadata$Builder;

    if-nez v0, :cond_1

    .line 164
    invoke-static {}, Lcom/google/common/flogger/context/ContextMetadata;->builder()Lcom/google/common/flogger/context/ContextMetadata$Builder;

    move-result-object v0

    iput-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->metadata:Lcom/google/common/flogger/context/ContextMetadata$Builder;

    .line 166
    :cond_1
    iget-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->metadata:Lcom/google/common/flogger/context/ContextMetadata$Builder;

    invoke-virtual {v0, p1, p2}, Lcom/google/common/flogger/context/ContextMetadata$Builder;->add(Lcom/google/common/flogger/MetadataKey;Ljava/lang/Object;)Lcom/google/common/flogger/context/ContextMetadata$Builder;

    return-object p0
.end method

.method public final withTags(Lcom/google/common/flogger/context/Tags;)Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;
    .locals 2
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .line 148
    iget-object v0, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->tags:Lcom/google/common/flogger/context/Tags;

    if-nez v0, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    const-string v1, "tags already set"

    invoke-static {v0, v1}, Lcom/google/common/flogger/util/Checks;->checkState(ZLjava/lang/String;)V

    .line 149
    const-string v0, "tags"

    invoke-static {p1, v0}, Lcom/google/common/flogger/util/Checks;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)Ljava/lang/Object;

    .line 150
    iput-object p1, p0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;->tags:Lcom/google/common/flogger/context/Tags;

    return-object p0
.end method

.method public final wrap(Ljava/lang/Runnable;)Ljava/lang/Runnable;
    .locals 1

    .line 191
    new-instance v0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder$1;

    invoke-direct {v0, p0, p1}, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder$1;-><init>(Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;Ljava/lang/Runnable;)V

    return-object v0
.end method

.method public final wrap(Ljava/util/concurrent/Callable;)Ljava/util/concurrent/Callable;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<R:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/util/concurrent/Callable<",
            "TR;>;)",
            "Ljava/util/concurrent/Callable<",
            "TR;>;"
        }
    .end annotation

    .line 217
    new-instance v0, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder$2;

    invoke-direct {v0, p0, p1}, Lcom/google/common/flogger/context/ScopedLoggingContext$Builder$2;-><init>(Lcom/google/common/flogger/context/ScopedLoggingContext$Builder;Ljava/util/concurrent/Callable;)V

    return-object v0
.end method
