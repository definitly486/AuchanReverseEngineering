.class public final Lio/appmetrica/analytics/networkapi/Response$Builder;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lio/appmetrica/analytics/networkapi/Response;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation


# instance fields
.field private final a:Z

.field private final b:I

.field private final c:[B

.field private final d:Ljava/lang/Throwable;

.field private e:Ljava/util/Map;

.field private f:Ljava/lang/String;

.field private g:Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;


# direct methods
.method public constructor <init>(Ljava/lang/Throwable;)V
    .locals 2

    const/4 v0, 0x0

    .line 9
    new-array v1, v0, [B

    .line 10
    invoke-direct {p0, v0, v0, v1, p1}, Lio/appmetrica/analytics/networkapi/Response$Builder;-><init>(ZI[BLjava/lang/Throwable;)V

    return-void
.end method

.method public constructor <init>(ZI[B)V
    .locals 1

    const/4 v0, 0x0

    .line 11
    invoke-direct {p0, p1, p2, p3, v0}, Lio/appmetrica/analytics/networkapi/Response$Builder;-><init>(ZI[BLjava/lang/Throwable;)V

    return-void
.end method

.method private constructor <init>(ZI[BLjava/lang/Throwable;)V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 2
    iput-boolean p1, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->a:Z

    .line 3
    iput p2, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->b:I

    .line 4
    iput-object p3, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->c:[B

    .line 5
    iput-object p4, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->d:Ljava/lang/Throwable;

    .line 8
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/MapsKt;->emptyMap()Ljava/util/Map;

    move-result-object p1

    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->e:Ljava/util/Map;

    return-void
.end method


# virtual methods
.method public final build()Lio/appmetrica/analytics/networkapi/Response;
    .locals 9

    .line 1
    new-instance v0, Lio/appmetrica/analytics/networkapi/Response;

    .line 2
    iget-boolean v1, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->a:Z

    .line 3
    iget v2, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->b:I

    .line 4
    iget-object v3, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->c:[B

    .line 5
    iget-object v4, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->e:Ljava/util/Map;

    .line 6
    iget-object v5, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->d:Ljava/lang/Throwable;

    .line 7
    iget-object v6, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->f:Ljava/lang/String;

    .line 8
    iget-object v7, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->g:Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;

    const/4 v8, 0x0

    .line 9
    invoke-direct/range {v0 .. v8}, Lio/appmetrica/analytics/networkapi/Response;-><init>(ZI[BLjava/util/Map;Ljava/lang/Throwable;Ljava/lang/String;Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public final withHeaders(Ljava/util/Map;)Lio/appmetrica/analytics/networkapi/Response$Builder;
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "+",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;>;)",
            "Lio/appmetrica/analytics/networkapi/Response$Builder;"
        }
    .end annotation

    .line 1
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/MapsKt;->toMap(Ljava/util/Map;)Ljava/util/Map;

    move-result-object p1

    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->e:Ljava/util/Map;

    return-object p0
.end method

.method public final withMetrics(Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;)Lio/appmetrica/analytics/networkapi/Response$Builder;
    .locals 0

    .line 1
    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->g:Lio/appmetrica/analytics/networkapi/NetworkCallMetrics;

    return-object p0
.end method

.method public final withUrl(Ljava/lang/String;)Lio/appmetrica/analytics/networkapi/Response$Builder;
    .locals 0

    .line 1
    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/Response$Builder;->f:Ljava/lang/String;

    return-object p0
.end method
