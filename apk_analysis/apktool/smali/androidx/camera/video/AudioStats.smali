.class public abstract Landroidx/camera/video/AudioStats;
.super Ljava/lang/Object;
.source "AudioStats.java"


# static fields
.field private static final ERROR_STATES:Ljava/util/Set;


# direct methods
.method static constructor <clinit>()V
    .locals 4

    .line 119
    new-instance v0, Ljava/util/HashSet;

    const/4 v1, 0x2

    .line 120
    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    const/4 v2, 0x3

    .line 121
    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    const/4 v3, 0x4

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    filled-new-array {v1, v2, v3}, [Ljava/lang/Integer;

    move-result-object v1

    .line 120
    invoke-static {v1}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/util/HashSet;-><init>(Ljava/util/Collection;)V

    invoke-static {v0}, Ljava/util/Collections;->unmodifiableSet(Ljava/util/Set;)Ljava/util/Set;

    move-result-object v0

    sput-object v0, Landroidx/camera/video/AudioStats;->ERROR_STATES:Ljava/util/Set;

    return-void
.end method

.method constructor <init>()V
    .locals 0

    .line 43
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static of(ILjava/lang/Throwable;D)Landroidx/camera/video/AudioStats;
    .locals 1

    .line 50
    new-instance v0, Landroidx/camera/video/AutoValue_AudioStats;

    invoke-direct {v0, p0, p2, p3, p1}, Landroidx/camera/video/AutoValue_AudioStats;-><init>(IDLjava/lang/Throwable;)V

    return-object v0
.end method


# virtual methods
.method abstract getAudioAmplitudeInternal()D
.end method

.method public abstract getAudioState()I
.end method

.method public abstract getErrorCause()Ljava/lang/Throwable;
.end method
