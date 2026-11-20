.class public Lcom/google/mediapipe/framework/AppTextureFrame;
.super Ljava/lang/Object;
.source "AppTextureFrame.java"

# interfaces
.implements Lcom/google/mediapipe/framework/TextureFrame;


# static fields
.field private static final DEFAULT_FORMAT:I = 0x1908


# instance fields
.field private final format:I

.field private final height:I

.field private inUse:Z

.field private legacyInUse:Z

.field private releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

.field private final textureName:I

.field private timestamp:J

.field private final width:I


# direct methods
.method public constructor <init>(III)V
    .locals 1

    const/16 v0, 0x1908

    .line 42
    invoke-direct {p0, p1, p2, p3, v0}, Lcom/google/mediapipe/framework/AppTextureFrame;-><init>(IIII)V

    return-void
.end method

.method public constructor <init>(IIII)V
    .locals 2

    .line 45
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide/high16 v0, -0x8000000000000000L

    .line 36
    iput-wide v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->timestamp:J

    const/4 v0, 0x0

    .line 37
    iput-boolean v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->inUse:Z

    .line 38
    iput-boolean v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->legacyInUse:Z

    const/4 v0, 0x0

    .line 39
    iput-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    .line 46
    iput p1, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->textureName:I

    .line 47
    iput p2, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->width:I

    .line 48
    iput p3, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->height:I

    .line 49
    iput p4, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->format:I

    return-void
.end method


# virtual methods
.method public finalize()V
    .locals 1

    .line 204
    iget-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    if-eqz v0, :cond_0

    .line 205
    invoke-interface {v0}, Lcom/google/mediapipe/framework/GlSyncToken;->release()V

    const/4 v0, 0x0

    .line 206
    iput-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    :cond_0
    return-void
.end method

.method public getFormat()I
    .locals 1

    .line 78
    iget v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->format:I

    return v0
.end method

.method public getHeight()I
    .locals 1

    .line 68
    iget v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->height:I

    return v0
.end method

.method public getInUse()Z
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 144
    monitor-enter p0

    .line 145
    :try_start_0
    iget-boolean v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->legacyInUse:Z

    monitor-exit p0

    return v0

    :catchall_0
    move-exception v0

    .line 146
    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public getTextureName()I
    .locals 1

    .line 58
    iget v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->textureName:I

    return v0
.end method

.method public getTimestamp()J
    .locals 2

    .line 73
    iget-wide v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->timestamp:J

    return-wide v0
.end method

.method public getWidth()I
    .locals 1

    .line 63
    iget v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->width:I

    return v0
.end method

.method public isNotYetReleased()Z
    .locals 1

    .line 83
    monitor-enter p0

    .line 84
    :try_start_0
    iget-boolean v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->inUse:Z

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    if-nez v0, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    :cond_0
    const/4 v0, 0x0

    :goto_0
    monitor-exit p0

    return v0

    .line 85
    :goto_1
    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public release()V
    .locals 1

    .line 170
    monitor-enter p0

    const/4 v0, 0x0

    .line 171
    :try_start_0
    iput-boolean v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->inUse:Z

    .line 172
    iput-boolean v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->legacyInUse:Z

    .line 173
    invoke-virtual {p0}, Ljava/lang/Object;->notifyAll()V

    .line 174
    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public release(Lcom/google/mediapipe/framework/GlSyncToken;)V
    .locals 1

    .line 184
    monitor-enter p0

    .line 185
    :try_start_0
    iget-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    if-eqz v0, :cond_0

    .line 186
    invoke-interface {v0}, Lcom/google/mediapipe/framework/GlSyncToken;->release()V

    const/4 v0, 0x0

    .line 187
    iput-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 189
    :cond_0
    :goto_0
    iput-object p1, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    const/4 p1, 0x0

    .line 192
    iput-boolean p1, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->legacyInUse:Z

    .line 193
    invoke-virtual {p0}, Ljava/lang/Object;->notifyAll()V

    .line 194
    monitor-exit p0

    return-void

    :goto_1
    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method public setInUse()V
    .locals 1

    .line 154
    monitor-enter p0

    .line 155
    :try_start_0
    iget-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    if-eqz v0, :cond_0

    .line 156
    invoke-interface {v0}, Lcom/google/mediapipe/framework/GlSyncToken;->release()V

    const/4 v0, 0x0

    .line 157
    iput-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    :cond_0
    :goto_0
    const/4 v0, 0x1

    .line 159
    iput-boolean v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->inUse:Z

    .line 160
    iput-boolean v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->legacyInUse:Z

    .line 161
    monitor-exit p0

    return-void

    :goto_1
    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public setTimestamp(J)V
    .locals 0

    .line 53
    iput-wide p1, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->timestamp:J

    return-void
.end method

.method public waitUntilReleased()V
    .locals 3

    .line 96
    monitor-enter p0

    .line 97
    :goto_0
    :try_start_0
    iget-boolean v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->inUse:Z

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    if-nez v0, :cond_0

    .line 98
    invoke-virtual {p0}, Ljava/lang/Object;->wait()V

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_2

    .line 100
    :cond_0
    iget-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    const/4 v1, 0x0

    if-eqz v0, :cond_1

    const/4 v2, 0x0

    .line 102
    iput-boolean v2, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->inUse:Z

    .line 103
    iput-object v1, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    goto :goto_1

    :cond_1
    move-object v0, v1

    .line 105
    :goto_1
    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-eqz v0, :cond_2

    .line 107
    invoke-interface {v0}, Lcom/google/mediapipe/framework/GlSyncToken;->waitOnCpu()V

    .line 108
    invoke-interface {v0}, Lcom/google/mediapipe/framework/GlSyncToken;->release()V

    :cond_2
    return-void

    .line 105
    :goto_2
    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method

.method public waitUntilReleasedWithGpuSync()V
    .locals 3

    .line 120
    monitor-enter p0

    .line 121
    :goto_0
    :try_start_0
    iget-boolean v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->inUse:Z

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    if-nez v0, :cond_0

    .line 122
    invoke-virtual {p0}, Ljava/lang/Object;->wait()V

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_2

    .line 124
    :cond_0
    iget-object v0, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    const/4 v1, 0x0

    if-eqz v0, :cond_1

    const/4 v2, 0x0

    .line 126
    iput-boolean v2, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->inUse:Z

    .line 127
    iput-object v1, p0, Lcom/google/mediapipe/framework/AppTextureFrame;->releaseSyncToken:Lcom/google/mediapipe/framework/GlSyncToken;

    goto :goto_1

    :cond_1
    move-object v0, v1

    .line 129
    :goto_1
    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-eqz v0, :cond_2

    .line 131
    invoke-interface {v0}, Lcom/google/mediapipe/framework/GlSyncToken;->waitOnGpu()V

    .line 132
    invoke-interface {v0}, Lcom/google/mediapipe/framework/GlSyncToken;->release()V

    :cond_2
    return-void

    .line 129
    :goto_2
    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method
