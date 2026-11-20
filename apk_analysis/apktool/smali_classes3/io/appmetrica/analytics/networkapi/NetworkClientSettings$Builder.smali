.class public final Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lio/appmetrica/analytics/networkapi/NetworkClientSettings;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Builder"
.end annotation


# instance fields
.field private a:Ljava/lang/Integer;

.field private b:Ljava/lang/Integer;

.field private c:Ljava/lang/Long;

.field private d:Ljavax/net/ssl/SSLSocketFactory;

.field private e:Ljava/lang/Boolean;

.field private f:Ljava/lang/Boolean;

.field private g:I

.field private h:Ljava/lang/Boolean;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const v0, 0x7fffffff

    .line 9
    iput v0, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->g:I

    return-void
.end method


# virtual methods
.method public final build()Lio/appmetrica/analytics/networkapi/NetworkClientSettings;
    .locals 10

    .line 1
    new-instance v0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings;

    .line 2
    iget-object v1, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->a:Ljava/lang/Integer;

    .line 3
    iget-object v2, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->b:Ljava/lang/Integer;

    .line 4
    iget-object v3, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->c:Ljava/lang/Long;

    .line 5
    iget-object v4, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->d:Ljavax/net/ssl/SSLSocketFactory;

    .line 6
    iget-object v5, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->e:Ljava/lang/Boolean;

    .line 7
    iget-object v6, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->f:Ljava/lang/Boolean;

    .line 8
    iget v7, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->g:I

    .line 9
    iget-object v8, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->h:Ljava/lang/Boolean;

    const/4 v9, 0x0

    .line 10
    invoke-direct/range {v0 .. v9}, Lio/appmetrica/analytics/networkapi/NetworkClientSettings;-><init>(Ljava/lang/Integer;Ljava/lang/Integer;Ljava/lang/Long;Ljavax/net/ssl/SSLSocketFactory;Ljava/lang/Boolean;Ljava/lang/Boolean;ILjava/lang/Boolean;Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public final withCallTimeout(JLjava/util/concurrent/TimeUnit;)Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;
    .locals 0

    .line 1
    invoke-virtual {p3, p1, p2}, Ljava/util/concurrent/TimeUnit;->toMillis(J)J

    move-result-wide p1

    invoke-static {p1, p2}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object p1

    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->c:Ljava/lang/Long;

    return-object p0
.end method

.method public final withCollectMetrics(Z)Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;
    .locals 0

    .line 1
    invoke-static {p1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object p1

    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->h:Ljava/lang/Boolean;

    return-object p0
.end method

.method public final withConnectTimeout(I)Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;
    .locals 0

    .line 1
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->a:Ljava/lang/Integer;

    return-object p0
.end method

.method public final withInstanceFollowRedirects(Z)Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;
    .locals 0

    .line 1
    invoke-static {p1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object p1

    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->f:Ljava/lang/Boolean;

    return-object p0
.end method

.method public final withMaxResponseSize(I)Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;
    .locals 0

    .line 1
    iput p1, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->g:I

    return-object p0
.end method

.method public final withReadTimeout(I)Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;
    .locals 0

    .line 1
    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->b:Ljava/lang/Integer;

    return-object p0
.end method

.method public final withSslSocketFactory(Ljavax/net/ssl/SSLSocketFactory;)Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;
    .locals 0

    .line 1
    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->d:Ljavax/net/ssl/SSLSocketFactory;

    return-object p0
.end method

.method public final withUseCaches(Z)Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;
    .locals 0

    .line 1
    invoke-static {p1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object p1

    iput-object p1, p0, Lio/appmetrica/analytics/networkapi/NetworkClientSettings$Builder;->e:Ljava/lang/Boolean;

    return-object p0
.end method
