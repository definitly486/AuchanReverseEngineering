.class public final Lio/appmetrica/analytics/networkapi/Response;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lio/appmetrica/analytics/networkapi/Response$Builder;
    }
.end annotation


# instance fields
.field private final a:Z

.field private final b:I

.field private final c:[B

.field private final d:Ljava/util/Map;

.field private final e:Ljava/lang/Throwable;

.field private final f:Ljava/lang/String;

.field private final g:Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;


# direct methods
.method private constructor <init>(ZI[BLjava/util/Map;Ljava/lang/Throwable;Ljava/lang/String;Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;)V
    .locals 0

    .line 2
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 3
    iput-boolean p1, p0, Lio/appmetrica/analytics/networkapi/Response;->a:Z

    .line 4
    iput p2, p0, Lio/appmetrica/analytics/networkapi/Response;->b:I

    .line 5
    iput-object p3, p0, Lio/appmetrica/analytics/networkapi/Response;->c:[B

    .line 6
    iput-object p4, p0, Lio/appmetrica/analytics/networkapi/Response;->d:Ljava/util/Map;

    .line 7
    iput-object p5, p0, Lio/appmetrica/analytics/networkapi/Response;->e:Ljava/lang/Throwable;

    .line 8
    iput-object p6, p0, Lio/appmetrica/analytics/networkapi/Response;->f:Ljava/lang/String;

    .line 9
    iput-object p7, p0, Lio/appmetrica/analytics/networkapi/Response;->g:Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;

    return-void
.end method

.method public synthetic constructor <init>(ZI[BLjava/util/Map;Ljava/lang/Throwable;Ljava/lang/String;Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 1
    invoke-direct/range {p0 .. p7}, Lio/appmetrica/analytics/networkapi/Response;-><init>(ZI[BLjava/util/Map;Ljava/lang/Throwable;Ljava/lang/String;Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;)V

    return-void
.end method


# virtual methods
.method public final getCode()I
    .locals 1

    .line 1
    iget v0, p0, Lio/appmetrica/analytics/networkapi/Response;->b:I

    return v0
.end method

.method public final getException()Ljava/lang/Throwable;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/networkapi/Response;->e:Ljava/lang/Throwable;

    return-object v0
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
    iget-object v0, p0, Lio/appmetrica/analytics/networkapi/Response;->d:Ljava/util/Map;

    return-object v0
.end method

.method public final getMetrics()Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/networkapi/Response;->g:Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;

    return-object v0
.end method

.method public final getResponseData()[B
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/networkapi/Response;->c:[B

    return-object v0
.end method

.method public final getUrl()Ljava/lang/String;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/networkapi/Response;->f:Ljava/lang/String;

    return-object v0
.end method

.method public final isCompleted()Z
    .locals 1

    .line 1
    iget-boolean v0, p0, Lio/appmetrica/analytics/networkapi/Response;->a:Z

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 1
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "Response(isCompleted="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 2
    iget-boolean v1, p0, Lio/appmetrica/analytics/networkapi/Response;->a:Z

    .line 3
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    .line 4
    const-string v1, ", code="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 6
    iget v1, p0, Lio/appmetrica/analytics/networkapi/Response;->b:I

    .line 7
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    .line 8
    const-string v1, ", responseDataLength="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 11
    iget-object v1, p0, Lio/appmetrica/analytics/networkapi/Response;->c:[B

    array-length v1, v1

    .line 12
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    .line 13
    const-string v1, ", headers="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 17
    iget-object v1, p0, Lio/appmetrica/analytics/networkapi/Response;->d:Ljava/util/Map;

    .line 18
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    .line 19
    const-string v1, ", exception="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 24
    iget-object v1, p0, Lio/appmetrica/analytics/networkapi/Response;->e:Ljava/lang/Throwable;

    .line 25
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    .line 26
    const-string v1, ", url="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 32
    iget-object v1, p0, Lio/appmetrica/analytics/networkapi/Response;->f:Ljava/lang/String;

    .line 33
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 34
    const-string v1, ", metrics="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 41
    iget-object v1, p0, Lio/appmetrica/analytics/networkapi/Response;->g:Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;

    .line 42
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
