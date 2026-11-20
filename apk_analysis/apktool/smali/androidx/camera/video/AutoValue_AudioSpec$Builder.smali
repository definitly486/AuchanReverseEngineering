.class final Landroidx/camera/video/AutoValue_AudioSpec$Builder;
.super Landroidx/camera/video/AudioSpec$Builder;
.source "AutoValue_AudioSpec.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Landroidx/camera/video/AutoValue_AudioSpec;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = "Builder"
.end annotation


# instance fields
.field private bitrate:Landroid/util/Range;

.field private channelCount:Ljava/lang/Integer;

.field private sampleRate:Landroid/util/Range;

.field private source:Ljava/lang/Integer;

.field private sourceFormat:Ljava/lang/Integer;


# direct methods
.method constructor <init>()V
    .locals 0

    .line 118
    invoke-direct {p0}, Landroidx/camera/video/AudioSpec$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public build()Landroidx/camera/video/AudioSpec;
    .locals 9

    .line 161
    iget-object v0, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->bitrate:Landroid/util/Range;

    const-string v1, ""

    if-nez v0, :cond_0

    .line 162
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " bitrate"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 164
    :cond_0
    iget-object v0, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->sourceFormat:Ljava/lang/Integer;

    if-nez v0, :cond_1

    .line 165
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " sourceFormat"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 167
    :cond_1
    iget-object v0, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->source:Ljava/lang/Integer;

    if-nez v0, :cond_2

    .line 168
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " source"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 170
    :cond_2
    iget-object v0, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->sampleRate:Landroid/util/Range;

    if-nez v0, :cond_3

    .line 171
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " sampleRate"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 173
    :cond_3
    iget-object v0, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->channelCount:Ljava/lang/Integer;

    if-nez v0, :cond_4

    .line 174
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, " channelCount"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 176
    :cond_4
    invoke-virtual {v1}, Ljava/lang/String;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_5

    .line 179
    new-instance v2, Landroidx/camera/video/AutoValue_AudioSpec;

    iget-object v3, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->bitrate:Landroid/util/Range;

    iget-object v0, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->sourceFormat:Ljava/lang/Integer;

    .line 181
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v4

    iget-object v0, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->source:Ljava/lang/Integer;

    .line 182
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v5

    iget-object v6, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->sampleRate:Landroid/util/Range;

    iget-object v0, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->channelCount:Ljava/lang/Integer;

    .line 184
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v7

    const/4 v8, 0x0

    invoke-direct/range {v2 .. v8}, Landroidx/camera/video/AutoValue_AudioSpec;-><init>(Landroid/util/Range;IILandroid/util/Range;ILandroidx/camera/video/AutoValue_AudioSpec$1;)V

    return-object v2

    .line 177
    :cond_5
    new-instance v0, Ljava/lang/IllegalStateException;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Missing required properties:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public setBitrate(Landroid/util/Range;)Landroidx/camera/video/AudioSpec$Builder;
    .locals 1

    if-eqz p1, :cond_0

    .line 132
    iput-object p1, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->bitrate:Landroid/util/Range;

    return-object p0

    .line 130
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null bitrate"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setChannelCount(I)Landroidx/camera/video/AudioSpec$Builder;
    .locals 0

    .line 155
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->channelCount:Ljava/lang/Integer;

    return-object p0
.end method

.method public setSampleRate(Landroid/util/Range;)Landroidx/camera/video/AudioSpec$Builder;
    .locals 1

    if-eqz p1, :cond_0

    .line 150
    iput-object p1, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->sampleRate:Landroid/util/Range;

    return-object p0

    .line 148
    :cond_0
    new-instance p1, Ljava/lang/NullPointerException;

    const-string v0, "Null sampleRate"

    invoke-direct {p1, v0}, Ljava/lang/NullPointerException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public setSource(I)Landroidx/camera/video/AudioSpec$Builder;
    .locals 0

    .line 142
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->source:Ljava/lang/Integer;

    return-object p0
.end method

.method public setSourceFormat(I)Landroidx/camera/video/AudioSpec$Builder;
    .locals 0

    .line 137
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Landroidx/camera/video/AutoValue_AudioSpec$Builder;->sourceFormat:Ljava/lang/Integer;

    return-object p0
.end method
