.class public final Lio/appmetrica/analytics/impl/vn;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lio/appmetrica/analytics/impl/u;


# instance fields
.field public final a:Lio/appmetrica/analytics/impl/v;

.field public final b:Lio/appmetrica/analytics/impl/w;

.field public final c:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 1

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 4
    new-instance v0, Lio/appmetrica/analytics/impl/v;

    invoke-direct {v0}, Lio/appmetrica/analytics/impl/v;-><init>()V

    iput-object v0, p0, Lio/appmetrica/analytics/impl/vn;->a:Lio/appmetrica/analytics/impl/v;

    .line 7
    new-instance v0, Lio/appmetrica/analytics/impl/w;

    invoke-direct {v0, p1}, Lio/appmetrica/analytics/impl/w;-><init>(Landroid/content/Context;)V

    iput-object v0, p0, Lio/appmetrica/analytics/impl/vn;->b:Lio/appmetrica/analytics/impl/w;

    .line 9
    new-instance p1, Lio/appmetrica/analytics/impl/un;

    invoke-direct {p1, p0}, Lio/appmetrica/analytics/impl/un;-><init>(Lio/appmetrica/analytics/impl/vn;)V

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyKt;->lazy(Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    move-result-object p1

    iput-object p1, p0, Lio/appmetrica/analytics/impl/vn;->c:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    return-void
.end method

.method public static final synthetic a(Lio/appmetrica/analytics/impl/vn;)Lio/appmetrica/analytics/impl/x;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/impl/vn;->a:Lio/appmetrica/analytics/impl/v;

    return-object p0
.end method

.method public static final synthetic b(Lio/appmetrica/analytics/impl/vn;)Lio/appmetrica/analytics/impl/x;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/impl/vn;->b:Lio/appmetrica/analytics/impl/w;

    return-object p0
.end method


# virtual methods
.method public final a(Ljava/util/Map;)Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)",
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 2
    iget-object v0, p0, Lio/appmetrica/analytics/impl/vn;->c:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map;

    .line 3
    invoke-interface {p1, v0}, Ljava/util/Map;->putAll(Ljava/util/Map;)V

    return-object p1
.end method
