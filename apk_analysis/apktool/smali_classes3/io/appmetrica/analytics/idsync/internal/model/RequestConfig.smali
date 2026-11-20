.class public final Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field private final a:Ljava/lang/String;

.field private final b:Ljava/lang/String;

.field private final c:Lio/appmetrica/analytics/idsync/internal/model/Preconditions;

.field private final d:Ljava/util/Map;

.field private final e:J

.field private final f:J

.field private final g:Ljava/util/List;

.field private final h:Z

.field private final i:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;Lio/appmetrica/analytics/idsync/internal/model/Preconditions;Ljava/util/Map;JJLjava/util/List;ZLjava/lang/String;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Lio/appmetrica/analytics/idsync/internal/model/Preconditions;",
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "+",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;>;JJ",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;Z",
            "Ljava/lang/String;",
            ")V"
        }
    .end annotation

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 2
    iput-object p1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->a:Ljava/lang/String;

    .line 3
    iput-object p2, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->b:Ljava/lang/String;

    .line 4
    iput-object p3, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->c:Lio/appmetrica/analytics/idsync/internal/model/Preconditions;

    .line 5
    iput-object p4, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->d:Ljava/util/Map;

    .line 6
    iput-wide p5, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->e:J

    .line 7
    iput-wide p7, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->f:J

    .line 8
    iput-object p9, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->g:Ljava/util/List;

    .line 9
    iput-boolean p10, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->h:Z

    .line 10
    iput-object p11, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->i:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 7

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    if-eqz p1, :cond_1

    .line 1
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    goto :goto_0

    :cond_1
    const/4 v1, 0x0

    :goto_0
    const-class v2, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;

    invoke-static {v2, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    const/4 v2, 0x0

    if-nez v1, :cond_2

    return v2

    .line 3
    :cond_2
    const-string v1, "null cannot be cast to non-null type io.appmetrica.analytics.idsync.internal.model.RequestConfig"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p1, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;

    .line 5
    iget-wide v3, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->e:J

    iget-wide v5, p1, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->e:J

    cmp-long v1, v3, v5

    if-eqz v1, :cond_3

    return v2

    .line 6
    :cond_3
    iget-wide v3, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->f:J

    iget-wide v5, p1, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->f:J

    cmp-long v1, v3, v5

    if-eqz v1, :cond_4

    return v2

    .line 7
    :cond_4
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->a:Ljava/lang/String;

    iget-object v3, p1, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->a:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_5

    return v2

    .line 8
    :cond_5
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->b:Ljava/lang/String;

    iget-object v3, p1, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->b:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_6

    return v2

    .line 9
    :cond_6
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->c:Lio/appmetrica/analytics/idsync/internal/model/Preconditions;

    iget-object v3, p1, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->c:Lio/appmetrica/analytics/idsync/internal/model/Preconditions;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_7

    return v2

    .line 10
    :cond_7
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->d:Ljava/util/Map;

    iget-object v3, p1, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->d:Ljava/util/Map;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_8

    return v2

    .line 11
    :cond_8
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->g:Ljava/util/List;

    iget-object v3, p1, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->g:Ljava/util/List;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_9

    return v2

    .line 12
    :cond_9
    iget-boolean v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->h:Z

    iget-boolean v3, p1, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->h:Z

    if-eq v1, v3, :cond_a

    return v2

    .line 13
    :cond_a
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->i:Ljava/lang/String;

    iget-object p1, p1, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->i:Ljava/lang/String;

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_b

    return v2

    :cond_b
    return v0
.end method

.method public final getHeaders()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;>;"
        }
    .end annotation

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->d:Ljava/util/Map;

    return-object v0
.end method

.method public final getPreconditions()Lio/appmetrica/analytics/idsync/internal/model/Preconditions;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->c:Lio/appmetrica/analytics/idsync/internal/model/Preconditions;

    return-object v0
.end method

.method public final getReportEventEnabled()Z
    .locals 1

    .line 1
    iget-boolean v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->h:Z

    return v0
.end method

.method public final getReportUrl()Ljava/lang/String;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->i:Ljava/lang/String;

    return-object v0
.end method

.method public final getResendIntervalForInvalidResponse()J
    .locals 2

    .line 1
    iget-wide v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->f:J

    return-wide v0
.end method

.method public final getResendIntervalForValidResponse()J
    .locals 2

    .line 1
    iget-wide v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->e:J

    return-wide v0
.end method

.method public final getType()Ljava/lang/String;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->a:Ljava/lang/String;

    return-object v0
.end method

.method public final getUrl()Ljava/lang/String;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->b:Ljava/lang/String;

    return-object v0
.end method

.method public final getValidResponseCodes()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->g:Ljava/util/List;

    return-object v0
.end method

.method public hashCode()I
    .locals 3

    .line 1
    iget-wide v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->e:J

    invoke-static {v0, v1}, Ljava/lang/Long;->hashCode(J)I

    move-result v0

    mul-int/lit8 v0, v0, 0x1f

    .line 2
    iget-wide v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->f:J

    invoke-static {v1, v2}, Ljava/lang/Long;->hashCode(J)I

    move-result v1

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    .line 3
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->a:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    .line 4
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->b:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v1

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    .line 5
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->c:Lio/appmetrica/analytics/idsync/internal/model/Preconditions;

    invoke-virtual {v0}, Lio/appmetrica/analytics/idsync/internal/model/Preconditions;->hashCode()I

    move-result v0

    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    .line 6
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->d:Ljava/util/Map;

    invoke-virtual {v1}, Ljava/lang/Object;->hashCode()I

    move-result v1

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    .line 7
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->g:Ljava/util/List;

    invoke-virtual {v0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    .line 8
    iget-boolean v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->h:Z

    invoke-static {v1}, Ljava/lang/Boolean;->hashCode(Z)I

    move-result v1

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    .line 9
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->i:Ljava/lang/String;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    add-int/2addr v1, v0

    return v1
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 1
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "RequestConfig(type=\'"

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 2
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->a:Ljava/lang/String;

    .line 3
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 4
    const-string v1, "\', url=\'"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 6
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->b:Ljava/lang/String;

    .line 7
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 8
    const-string v1, "\', preconditions="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 11
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->c:Lio/appmetrica/analytics/idsync/internal/model/Preconditions;

    .line 12
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    .line 13
    const-string v1, ", headers="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 17
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->d:Ljava/util/Map;

    .line 18
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    .line 19
    const-string v1, ", resendIntervalForValidResponse="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 24
    iget-wide v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->e:J

    .line 25
    invoke-virtual {v0, v1, v2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    .line 26
    const-string v1, ", resendIntervalForInvalidResponse="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 32
    iget-wide v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->f:J

    .line 33
    invoke-virtual {v0, v1, v2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    .line 34
    const-string v1, ", validResponseCodes="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 41
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->g:Ljava/util/List;

    .line 42
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    .line 43
    const-string v1, ", reportEventEnabled="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 51
    iget-boolean v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->h:Z

    .line 52
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    .line 53
    const-string v1, ", reportUrl="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 62
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/RequestConfig;->i:Ljava/lang/String;

    .line 63
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
