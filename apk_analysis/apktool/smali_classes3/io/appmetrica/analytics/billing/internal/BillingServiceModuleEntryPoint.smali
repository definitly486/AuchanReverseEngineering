.class public final Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;
.super Lio/appmetrica/analytics/modulesapi/internal/service/ModuleServiceEntryPoint;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lio/appmetrica/analytics/modulesapi/internal/service/ModuleServiceEntryPoint<",
        "Lio/appmetrica/analytics/billing/internal/config/RemoteBillingConfig;",
        ">;"
    }
.end annotation


# instance fields
.field private a:Lio/appmetrica/analytics/billing/impl/m;

.field private final b:Lio/appmetrica/analytics/billing/impl/q;

.field private final c:Lio/appmetrica/analytics/billing/impl/p;

.field private final d:Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$configUpdateListener$1;

.field private final e:Ljava/lang/String;

.field private final f:Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$remoteConfigExtensionConfiguration$1;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 1
    invoke-direct {p0}, Lio/appmetrica/analytics/modulesapi/internal/service/ModuleServiceEntryPoint;-><init>()V

    .line 2
    new-instance v0, Lio/appmetrica/analytics/billing/impl/q;

    const/4 v1, 0x3

    const/4 v2, 0x0

    invoke-direct {v0, v2, v2, v1, v2}, Lio/appmetrica/analytics/billing/impl/q;-><init>(Lio/appmetrica/analytics/billing/impl/g;Lio/appmetrica/analytics/billing/impl/f;ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    iput-object v0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->b:Lio/appmetrica/analytics/billing/impl/q;

    .line 3
    new-instance v0, Lio/appmetrica/analytics/billing/impl/p;

    const/4 v1, 0x1

    invoke-direct {v0, v2, v1, v2}, Lio/appmetrica/analytics/billing/impl/p;-><init>(Lio/appmetrica/analytics/billing/impl/r;ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    iput-object v0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->c:Lio/appmetrica/analytics/billing/impl/p;

    .line 4
    new-instance v0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$configUpdateListener$1;

    invoke-direct {v0, p0}, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$configUpdateListener$1;-><init>(Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;)V

    iput-object v0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->d:Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$configUpdateListener$1;

    .line 5
    const-string v0, "billing"

    iput-object v0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->e:Ljava/lang/String;

    .line 6
    new-instance v0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$remoteConfigExtensionConfiguration$1;

    invoke-direct {v0, p0}, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$remoteConfigExtensionConfiguration$1;-><init>(Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;)V

    iput-object v0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->f:Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$remoteConfigExtensionConfiguration$1;

    return-void
.end method

.method public static final synthetic access$getBillingMonitorWrapper$p(Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;)Lio/appmetrica/analytics/billing/impl/m;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->a:Lio/appmetrica/analytics/billing/impl/m;

    return-object p0
.end method

.method public static final synthetic access$getConfigConverter$p(Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;)Lio/appmetrica/analytics/billing/impl/p;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->c:Lio/appmetrica/analytics/billing/impl/p;

    return-object p0
.end method

.method public static final synthetic access$getConfigParser$p(Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;)Lio/appmetrica/analytics/billing/impl/q;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->b:Lio/appmetrica/analytics/billing/impl/q;

    return-object p0
.end method

.method public static final synthetic access$getConfigUpdateListener$p(Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;)Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$configUpdateListener$1;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->d:Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$configUpdateListener$1;

    return-object p0
.end method


# virtual methods
.method public getIdentifier()Ljava/lang/String;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->e:Ljava/lang/String;

    return-object v0
.end method

.method public getRemoteConfigExtensionConfiguration()Lio/appmetrica/analytics/modulesapi/internal/service/RemoteConfigExtensionConfiguration;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lio/appmetrica/analytics/modulesapi/internal/service/RemoteConfigExtensionConfiguration<",
            "Lio/appmetrica/analytics/billing/internal/config/RemoteBillingConfig;",
            ">;"
        }
    .end annotation

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->f:Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint$remoteConfigExtensionConfiguration$1;

    return-object v0
.end method

.method public initServiceSide(Lio/appmetrica/analytics/modulesapi/internal/service/ServiceContext;Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig;)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lio/appmetrica/analytics/modulesapi/internal/service/ServiceContext;",
            "Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig<",
            "Lio/appmetrica/analytics/billing/internal/config/RemoteBillingConfig;",
            ">;)V"
        }
    .end annotation

    .line 1
    invoke-interface {p2}, Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig;->getFeaturesConfig()Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lio/appmetrica/analytics/billing/internal/config/RemoteBillingConfig;

    if-eqz p2, :cond_0

    new-instance v0, Lio/appmetrica/analytics/billing/impl/B;

    .line 2
    invoke-virtual {p2}, Lio/appmetrica/analytics/billing/internal/config/RemoteBillingConfig;->getEnabled()Z

    move-result v1

    .line 3
    new-instance v2, Lio/appmetrica/analytics/billing/impl/A;

    invoke-virtual {p2}, Lio/appmetrica/analytics/billing/internal/config/RemoteBillingConfig;->getConfig()Lio/appmetrica/analytics/billing/internal/config/BillingConfig;

    move-result-object p2

    invoke-direct {v2, p2}, Lio/appmetrica/analytics/billing/impl/A;-><init>(Lio/appmetrica/analytics/billing/internal/config/BillingConfig;)V

    .line 4
    invoke-direct {v0, v1, v2}, Lio/appmetrica/analytics/billing/impl/B;-><init>(ZLio/appmetrica/analytics/billing/impl/A;)V

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    .line 5
    :goto_0
    new-instance p2, Lio/appmetrica/analytics/billing/impl/m;

    invoke-direct {p2, p1, v0}, Lio/appmetrica/analytics/billing/impl/m;-><init>(Lio/appmetrica/analytics/modulesapi/internal/service/ServiceContext;Lio/appmetrica/analytics/billing/impl/B;)V

    .line 9
    invoke-interface {p1}, Lio/appmetrica/analytics/modulesapi/internal/service/ServiceContext;->getServiceModuleReporterComponentLifecycle()Lio/appmetrica/analytics/coreapi/internal/servicecomponents/ServiceModuleReporterComponentLifecycle;

    move-result-object p1

    invoke-interface {p1, p2}, Lio/appmetrica/analytics/coreapi/internal/servicecomponents/ServiceModuleReporterComponentLifecycle;->subscribe(Lio/appmetrica/analytics/coreapi/internal/servicecomponents/ServiceModuleReporterComponentLifecycleListener;)V

    .line 10
    iput-object p2, p0, Lio/appmetrica/analytics/billing/internal/BillingServiceModuleEntryPoint;->a:Lio/appmetrica/analytics/billing/impl/m;

    return-void
.end method
