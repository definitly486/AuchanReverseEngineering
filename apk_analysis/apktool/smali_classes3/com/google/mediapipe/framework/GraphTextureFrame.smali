.class public Lcom/google/mediapipe/framework/GraphTextureFrame;
.super Ljava/lang/Object;
.source "GraphTextureFrame.java"

# interfaces
.implements Lcom/google/mediapipe/framework/TextureFrame;


# static fields
.field private static final logger:Lcom/google/common/flogger/FluentLogger;


# instance fields
.field private final activeConsumerContextHandleSet:Ljava/util/Set;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Set<",
            "Ljava/lang/Long;",
            ">;"
        }
    .end annotation
.end field

.field private final deferredSync:Z

.field private final format:I

.field private height:I

.field private nativeBufferHandle:J

.field private refCount:I

.field private textureName:I

.field private timestamp:J

.field private width:I


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 28
    invoke-static {}, Lcom/google/common/flogger/FluentLogger;->forEnclosingClass()Lcom/google/common/flogger/FluentLogger;

    move-result-object v0

    sput-object v0, Lcom/google/mediapipe/framework/GraphTextureFrame;->logger:Lcom/google/common/flogger/FluentLogger;

    return-void
.end method

.method constructor <init>(JJ)V
    .locals 6

    const/4 v5, 0x0

    move-object v0, p0

    move-wide v1, p1

    move-wide v3, p3

    .line 43
    invoke-direct/range {v0 .. v5}, Lcom/google/mediapipe/framework/GraphTextureFrame;-><init>(JJZ)V

    return-void
.end method

.method public constructor <init>(JJZ)V
    .locals 2

    .line 54
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide/high16 v0, -0x8000000000000000L

    .line 35
    iput-wide v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->timestamp:J

    .line 39
    new-instance v0, Ljava/util/HashSet;

    invoke-direct {v0}, Ljava/util/HashSet;-><init>()V

    iput-object v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->activeConsumerContextHandleSet:Ljava/util/Set;

    const/4 v0, 0x1

    .line 40
    iput v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->refCount:I

    .line 55
    iput-wide p1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J

    .line 57
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeGetTextureName(J)I

    move-result p1

    iput p1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->textureName:I

    .line 58
    iget-wide p1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J

    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeGetWidth(J)I

    move-result p1

    iput p1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->width:I

    .line 59
    iget-wide p1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J

    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeGetHeight(J)I

    move-result p1

    iput p1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->height:I

    .line 60
    iget-wide p1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J

    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeGetFormat(J)I

    move-result p1

    iput p1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->format:I

    .line 61
    iput-wide p3, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->timestamp:J

    .line 62
    iput-boolean p5, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->deferredSync:Z

    return-void
.end method

.method private native nativeCreateSyncTokenForCurrentExternalContext(J)J
.end method

.method private native nativeDidRead(JJ)V
.end method

.method private native nativeGetCurrentExternalContextHandle()J
.end method

.method private native nativeGetFormat(J)I
.end method

.method private native nativeGetHeight(J)I
.end method

.method private native nativeGetTextureName(J)I
.end method

.method private native nativeGetWidth(J)I
.end method

.method private native nativeGpuWait(J)V
.end method

.method private native nativeReleaseBuffer(J)V
.end method


# virtual methods
.method protected finalize()V
    .locals 4

    .line 185
    iget v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->refCount:I

    if-gtz v0, :cond_0

    iget-wide v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J

    const-wide/16 v2, 0x0

    cmp-long v0, v0, v2

    if-eqz v0, :cond_1

    .line 186
    :cond_0
    sget-object v0, Lcom/google/mediapipe/framework/GraphTextureFrame;->logger:Lcom/google/common/flogger/FluentLogger;

    invoke-virtual {v0}, Lcom/google/common/flogger/AbstractLogger;->atWarning()Lcom/google/common/flogger/LoggingApi;

    move-result-object v0

    check-cast v0, Lcom/google/common/flogger/FluentLogger$Api;

    const-string v1, "release was not called before finalize"

    invoke-interface {v0, v1}, Lcom/google/common/flogger/LoggingApi;->log(Ljava/lang/String;)V

    .line 188
    :cond_1
    iget-object v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->activeConsumerContextHandleSet:Ljava/util/Set;

    invoke-interface {v0}, Ljava/util/Set;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_2

    .line 189
    sget-object v0, Lcom/google/mediapipe/framework/GraphTextureFrame;->logger:Lcom/google/common/flogger/FluentLogger;

    invoke-virtual {v0}, Lcom/google/common/flogger/AbstractLogger;->atWarning()Lcom/google/common/flogger/LoggingApi;

    move-result-object v0

    check-cast v0, Lcom/google/common/flogger/FluentLogger$Api;

    const-string v1, "active consumers did not release with sync before finalize"

    invoke-interface {v0, v1}, Lcom/google/common/flogger/LoggingApi;->log(Ljava/lang/String;)V

    :cond_2
    return-void
.end method

.method public getFormat()I
    .locals 1

    .line 111
    iget v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->format:I

    return v0
.end method

.method public getHeight()I
    .locals 1

    .line 101
    iget v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->height:I

    return v0
.end method

.method public declared-synchronized getTextureName()I
    .locals 4

    monitor-enter p0

    .line 76
    :try_start_0
    iget-wide v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    const-wide/16 v2, 0x0

    cmp-long v0, v0, v2

    if-nez v0, :cond_0

    .line 77
    monitor-exit p0

    const/4 v0, 0x0

    return v0

    .line 79
    :cond_0
    :try_start_1
    invoke-direct {p0}, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeGetCurrentExternalContextHandle()J

    move-result-wide v0

    cmp-long v2, v0, v2

    if-eqz v2, :cond_1

    .line 80
    iget-object v2, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->activeConsumerContextHandleSet:Ljava/util/Set;

    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    invoke-interface {v2, v0}, Ljava/util/Set;->add(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 83
    iget-boolean v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->deferredSync:Z

    if-eqz v0, :cond_1

    .line 86
    iget-wide v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J

    invoke-direct {p0, v0, v1}, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeGpuWait(J)V

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    .line 89
    :cond_1
    :goto_0
    iget v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->textureName:I
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    monitor-exit p0

    return v0

    :goto_1
    :try_start_2
    monitor-exit p0
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw v0
.end method

.method public getTimestamp()J
    .locals 2

    .line 106
    iget-wide v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->timestamp:J

    return-wide v0
.end method

.method public getWidth()I
    .locals 1

    .line 95
    iget v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->width:I

    return v0
.end method

.method public declared-synchronized release()V
    .locals 5

    monitor-enter p0

    .line 135
    :try_start_0
    invoke-direct {p0}, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeGetCurrentExternalContextHandle()J

    move-result-wide v0

    const-wide/16 v2, 0x0

    cmp-long v2, v0, v2

    if-nez v2, :cond_0

    .line 136
    iget-object v3, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->activeConsumerContextHandleSet:Ljava/util/Set;

    invoke-interface {v3}, Ljava/util/Set;->isEmpty()Z

    move-result v3

    if-nez v3, :cond_0

    .line 137
    sget-object v3, Lcom/google/mediapipe/framework/GraphTextureFrame;->logger:Lcom/google/common/flogger/FluentLogger;

    invoke-virtual {v3}, Lcom/google/common/flogger/AbstractLogger;->atWarning()Lcom/google/common/flogger/LoggingApi;

    move-result-object v3

    check-cast v3, Lcom/google/common/flogger/FluentLogger$Api;

    const-string v4, "GraphTextureFrame is being released on non GL thread while having active consumers, which may lead to external / internal GL contexts synchronization issues."

    invoke-interface {v3, v4}, Lcom/google/common/flogger/LoggingApi;->log(Ljava/lang/String;)V

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_2

    :cond_0
    :goto_0
    if-eqz v2, :cond_1

    .line 142
    iget-object v2, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->activeConsumerContextHandleSet:Ljava/util/Set;

    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    invoke-interface {v2, v0}, Ljava/util/Set;->remove(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 143
    new-instance v0, Lcom/google/mediapipe/framework/GraphGlSyncToken;

    iget-wide v1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J

    .line 144
    invoke-direct {p0, v1, v2}, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeCreateSyncTokenForCurrentExternalContext(J)J

    move-result-wide v1

    invoke-direct {v0, v1, v2}, Lcom/google/mediapipe/framework/GraphGlSyncToken;-><init>(J)V

    goto :goto_1

    :cond_1
    const/4 v0, 0x0

    .line 146
    :goto_1
    invoke-virtual {p0, v0}, Lcom/google/mediapipe/framework/GraphTextureFrame;->release(Lcom/google/mediapipe/framework/GlSyncToken;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 147
    monitor-exit p0

    return-void

    :goto_2
    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method

.method public declared-synchronized release(Lcom/google/mediapipe/framework/GlSyncToken;)V
    .locals 6

    monitor-enter p0

    .line 160
    :try_start_0
    iget-wide v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J

    const-wide/16 v2, 0x0

    cmp-long v0, v0, v2

    if-nez v0, :cond_1

    if-eqz p1, :cond_0

    .line 162
    sget-object p1, Lcom/google/mediapipe/framework/GraphTextureFrame;->logger:Lcom/google/common/flogger/FluentLogger;

    invoke-virtual {p1}, Lcom/google/common/flogger/AbstractLogger;->atWarning()Lcom/google/common/flogger/LoggingApi;

    move-result-object p1

    check-cast p1, Lcom/google/common/flogger/FluentLogger$Api;

    const-string v0, "release with sync token, but handle is 0"

    invoke-interface {p1, v0}, Lcom/google/common/flogger/LoggingApi;->log(Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 164
    :cond_0
    :goto_0
    monitor-exit p0

    return-void

    :cond_1
    if-eqz p1, :cond_2

    .line 168
    :try_start_1
    invoke-interface {p1}, Lcom/google/mediapipe/framework/GlSyncToken;->nativeToken()J

    move-result-wide v0

    .line 169
    iget-wide v4, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J

    invoke-direct {p0, v4, v5, v0, v1}, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeDidRead(JJ)V

    .line 172
    invoke-interface {p1}, Lcom/google/mediapipe/framework/GlSyncToken;->release()V

    .line 175
    :cond_2
    iget p1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->refCount:I

    add-int/lit8 p1, p1, -0x1

    iput p1, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->refCount:I

    if-gtz p1, :cond_3

    .line 177
    iget-wide v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J

    invoke-direct {p0, v0, v1}, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeReleaseBuffer(J)V

    .line 178
    iput-wide v2, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->nativeBufferHandle:J
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 180
    :cond_3
    monitor-exit p0

    return-void

    :goto_1
    :try_start_2
    monitor-exit p0
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw p1
.end method

.method public declared-synchronized retain()V
    .locals 1

    monitor-enter p0

    .line 122
    :try_start_0
    iget v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->refCount:I

    add-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/framework/GraphTextureFrame;->refCount:I
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 123
    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method

.method public supportsRetain()Z
    .locals 1

    .line 0
    const/4 v0, 0x1

    return v0
.end method
