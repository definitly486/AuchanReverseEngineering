.class public final Lio/appmetrica/analytics/idsync/internal/model/Preconditions;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field private final a:Lio/appmetrica/analytics/idsync/internal/model/NetworkType;


# direct methods
.method public constructor <init>(Lio/appmetrica/analytics/idsync/internal/model/NetworkType;)V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 2
    iput-object p1, p0, Lio/appmetrica/analytics/idsync/internal/model/Preconditions;->a:Lio/appmetrica/analytics/idsync/internal/model/NetworkType;

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 3

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
    const-class v2, Lio/appmetrica/analytics/idsync/internal/model/Preconditions;

    invoke-static {v2, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    const/4 v2, 0x0

    if-nez v1, :cond_2

    return v2

    .line 3
    :cond_2
    const-string v1, "null cannot be cast to non-null type io.appmetrica.analytics.idsync.internal.model.Preconditions"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast p1, Lio/appmetrica/analytics/idsync/internal/model/Preconditions;

    .line 5
    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/Preconditions;->a:Lio/appmetrica/analytics/idsync/internal/model/NetworkType;

    iget-object p1, p1, Lio/appmetrica/analytics/idsync/internal/model/Preconditions;->a:Lio/appmetrica/analytics/idsync/internal/model/NetworkType;

    if-ne v1, p1, :cond_3

    return v0

    :cond_3
    return v2
.end method

.method public final getNetworkType()Lio/appmetrica/analytics/idsync/internal/model/NetworkType;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/Preconditions;->a:Lio/appmetrica/analytics/idsync/internal/model/NetworkType;

    return-object v0
.end method

.method public hashCode()I
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/model/Preconditions;->a:Lio/appmetrica/analytics/idsync/internal/model/NetworkType;

    invoke-virtual {v0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 1
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "Preconditions(networkType="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/model/Preconditions;->a:Lio/appmetrica/analytics/idsync/internal/model/NetworkType;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
