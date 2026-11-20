.class public final Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;
.super Lio/appmetrica/analytics/modulesapi/internal/service/ModuleServiceEntryPoint;
.source "SourceFile"

# interfaces
.implements Lio/appmetrica/analytics/modulesapi/internal/service/RemoteConfigUpdateListener;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lio/appmetrica/analytics/modulesapi/internal/service/ModuleServiceEntryPoint<",
        "Lio/appmetrica/analytics/idsync/internal/model/IdSyncConfig;",
        ">;",
        "Lio/appmetrica/analytics/modulesapi/internal/service/RemoteConfigUpdateListener<",
        "Lio/appmetrica/analytics/idsync/internal/model/IdSyncConfig;",
        ">;"
    }
.end annotation


# instance fields
.field private final a:Lio/appmetrica/analytics/idsync/impl/d;

.field private final b:Lio/appmetrica/analytics/idsync/impl/c;

.field private c:Lio/appmetrica/analytics/idsync/impl/h;

.field private final d:Ljava/lang/String;

.field private final e:Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint$remoteConfigExtensionConfiguration$1;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 1
    invoke-direct {p0}, Lio/appmetrica/analytics/modulesapi/internal/service/ModuleServiceEntryPoint;-><init>()V

    .line 2
    new-instance v0, Lio/appmetrica/analytics/idsync/impl/e;

    invoke-direct {v0}, Lio/appmetrica/analytics/idsync/impl/e;-><init>()V

    .line 3
    new-instance v1, Lio/appmetrica/analytics/idsync/impl/d;

    invoke-direct {v1, v0}, Lio/appmetrica/analytics/idsync/impl/d;-><init>(Lio/appmetrica/analytics/idsync/impl/e;)V

    iput-object v1, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->a:Lio/appmetrica/analytics/idsync/impl/d;

    .line 4
    new-instance v1, Lio/appmetrica/analytics/idsync/impl/c;

    invoke-direct {v1, v0}, Lio/appmetrica/analytics/idsync/impl/c;-><init>(Lio/appmetrica/analytics/idsync/impl/e;)V

    iput-object v1, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->b:Lio/appmetrica/analytics/idsync/impl/c;

    .line 5
    const-string v0, "id-sync"

    iput-object v0, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->d:Ljava/lang/String;

    .line 6
    new-instance v0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint$remoteConfigExtensionConfiguration$1;

    invoke-direct {v0, p0}, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint$remoteConfigExtensionConfiguration$1;-><init>(Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;)V

    iput-object v0, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->e:Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint$remoteConfigExtensionConfiguration$1;

    return-void
.end method

.method public static final synthetic access$getConfigParser$p(Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;)Lio/appmetrica/analytics/idsync/impl/c;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->b:Lio/appmetrica/analytics/idsync/impl/c;

    return-object p0
.end method

.method public static final synthetic access$getConfigToBytesConverter$p(Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;)Lio/appmetrica/analytics/idsync/impl/d;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->a:Lio/appmetrica/analytics/idsync/impl/d;

    return-object p0
.end method


# virtual methods
.method public getIdentifier()Ljava/lang/String;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->d:Ljava/lang/String;

    return-object v0
.end method

.method public getRemoteConfigExtensionConfiguration()Lio/appmetrica/analytics/modulesapi/internal/service/RemoteConfigExtensionConfiguration;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lio/appmetrica/analytics/modulesapi/internal/service/RemoteConfigExtensionConfiguration<",
            "Lio/appmetrica/analytics/idsync/internal/model/IdSyncConfig;",
            ">;"
        }
    .end annotation

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->e:Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint$remoteConfigExtensionConfiguration$1;

    return-object v0
.end method

.method public initServiceSide(Lio/appmetrica/analytics/modulesapi/internal/service/ServiceContext;Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig;)V
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lio/appmetrica/analytics/modulesapi/internal/service/ServiceContext;",
            "Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig<",
            "Lio/appmetrica/analytics/idsync/internal/model/IdSyncConfig;",
            ">;)V"
        }
    .end annotation

    .line 1
    monitor-enter p0

    .line 2
    :try_start_0
    iget-object v0, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->c:Lio/appmetrica/analytics/idsync/impl/h;

    if-nez v0, :cond_0

    .line 3
    new-instance v0, Lio/appmetrica/analytics/idsync/impl/h;

    invoke-interface {p2}, Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig;->getIdentifiers()Lio/appmetrica/analytics/coreapi/internal/identifiers/SdkIdentifiers;

    move-result-object v1

    invoke-direct {v0, p1, v1}, Lio/appmetrica/analytics/idsync/impl/h;-><init>(Lio/appmetrica/analytics/modulesapi/internal/service/ServiceContext;Lio/appmetrica/analytics/coreapi/internal/identifiers/SdkIdentifiers;)V

    .line 4
    iput-object v0, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->c:Lio/appmetrica/analytics/idsync/impl/h;

    .line 5
    invoke-interface {p2}, Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig;->getFeaturesConfig()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lio/appmetrica/analytics/idsync/internal/model/IdSyncConfig;

    if-eqz p1, :cond_0

    invoke-interface {p2}, Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig;->getIdentifiers()Lio/appmetrica/analytics/coreapi/internal/identifiers/SdkIdentifiers;

    move-result-object p2

    invoke-virtual {v0, p1, p2}, Lio/appmetrica/analytics/idsync/impl/h;->a(Lio/appmetrica/analytics/idsync/internal/model/IdSyncConfig;Lio/appmetrica/analytics/coreapi/internal/identifiers/SdkIdentifiers;)V

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 7
    :cond_0
    :goto_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 8
    monitor-exit p0

    return-void

    .line 9
    :goto_1
    monitor-exit p0

    throw p1
.end method

.method public declared-synchronized onRemoteConfigUpdated(Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig;)V
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig<",
            "Lio/appmetrica/analytics/idsync/internal/model/IdSyncConfig;",
            ">;)V"
        }
    .end annotation

    monitor-enter p0

    .line 1
    :try_start_0
    invoke-interface {p1}, Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig;->getFeaturesConfig()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lio/appmetrica/analytics/idsync/internal/model/IdSyncConfig;

    if-eqz v0, :cond_0

    iget-object v1, p0, Lio/appmetrica/analytics/idsync/internal/IdSyncModuleEntryPoint;->c:Lio/appmetrica/analytics/idsync/impl/h;

    if-eqz v1, :cond_0

    invoke-interface {p1}, Lio/appmetrica/analytics/modulesapi/internal/service/ModuleRemoteConfig;->getIdentifiers()Lio/appmetrica/analytics/coreapi/internal/identifiers/SdkIdentifiers;

    move-result-object p1

    invoke-virtual {v1, v0, p1}, Lio/appmetrica/analytics/idsync/impl/h;->a(Lio/appmetrica/analytics/idsync/internal/model/IdSyncConfig;Lio/appmetrica/analytics/coreapi/internal/identifiers/SdkIdentifiers;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    :cond_0
    :goto_0
    monitor-exit p0

    return-void

    :goto_1
    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw p1
.end method
