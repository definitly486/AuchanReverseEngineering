.class final Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;
.super Lcom/google/android/datatransport/runtime/TransportRuntimeComponent;
.source "DaggerTransportRuntimeComponent.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "TransportRuntimeComponentImpl"
.end annotation


# instance fields
.field private configProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private creationContextFactoryProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

.field private defaultSchedulerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private executorProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private metadataBackendRegistryProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

.field private packageNameProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private sQLiteEventStoreProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private schemaManagerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

.field private setApplicationContextProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private final transportRuntimeComponentImpl:Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;

.field private transportRuntimeProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private uploaderProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private workInitializerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private workSchedulerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field


# direct methods
.method private constructor <init>(Landroid/content/Context;)V
    .locals 0

    .line 95
    invoke-direct {p0}, Lcom/google/android/datatransport/runtime/TransportRuntimeComponent;-><init>()V

    .line 64
    iput-object p0, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->transportRuntimeComponentImpl:Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;

    .line 97
    invoke-direct {p0, p1}, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->initialize(Landroid/content/Context;)V

    return-void
.end method

.method synthetic constructor <init>(Landroid/content/Context;Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$1;)V
    .locals 0

    .line 63
    invoke-direct {p0, p1}, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;-><init>(Landroid/content/Context;)V

    return-void
.end method

.method private initialize(Landroid/content/Context;)V
    .locals 9

    .line 103
    invoke-static {}, Lcom/google/android/datatransport/runtime/ExecutionModule_ExecutorFactory;->create()Lcom/google/android/datatransport/runtime/ExecutionModule_ExecutorFactory;

    move-result-object v0

    invoke-static {v0}, Lcom/google/android/datatransport/runtime/dagger/internal/DoubleCheck;->provider(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->executorProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 104
    invoke-static {p1}, Lcom/google/android/datatransport/runtime/dagger/internal/InstanceFactory;->create(Ljava/lang/Object;)Lcom/google/android/datatransport/runtime/dagger/internal/Factory;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->setApplicationContextProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 105
    invoke-static {}, Lcom/google/android/datatransport/runtime/time/TimeModule_EventClockFactory;->create()Lcom/google/android/datatransport/runtime/time/TimeModule_EventClockFactory;

    move-result-object v0

    invoke-static {}, Lcom/google/android/datatransport/runtime/time/TimeModule_UptimeClockFactory;->create()Lcom/google/android/datatransport/runtime/time/TimeModule_UptimeClockFactory;

    move-result-object v1

    invoke-static {p1, v0, v1}, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->creationContextFactoryProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 106
    iget-object v0, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->setApplicationContextProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-static {v0, p1}, Lcom/google/android/datatransport/runtime/backends/MetadataBackendRegistry_Factory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/backends/MetadataBackendRegistry_Factory;

    move-result-object p1

    invoke-static {p1}, Lcom/google/android/datatransport/runtime/dagger/internal/DoubleCheck;->provider(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->metadataBackendRegistryProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 107
    iget-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->setApplicationContextProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-static {}, Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule_DbNameFactory;->create()Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule_DbNameFactory;

    move-result-object v0

    invoke-static {}, Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule_SchemaVersionFactory;->create()Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule_SchemaVersionFactory;

    move-result-object v1

    invoke-static {p1, v0, v1}, Lcom/google/android/datatransport/runtime/scheduling/persistence/SchemaManager_Factory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/scheduling/persistence/SchemaManager_Factory;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->schemaManagerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 108
    iget-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->setApplicationContextProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-static {p1}, Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule_PackageNameFactory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule_PackageNameFactory;

    move-result-object p1

    invoke-static {p1}, Lcom/google/android/datatransport/runtime/dagger/internal/DoubleCheck;->provider(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->packageNameProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 109
    invoke-static {}, Lcom/google/android/datatransport/runtime/time/TimeModule_EventClockFactory;->create()Lcom/google/android/datatransport/runtime/time/TimeModule_EventClockFactory;

    move-result-object p1

    invoke-static {}, Lcom/google/android/datatransport/runtime/time/TimeModule_UptimeClockFactory;->create()Lcom/google/android/datatransport/runtime/time/TimeModule_UptimeClockFactory;

    move-result-object v0

    invoke-static {}, Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule_StoreConfigFactory;->create()Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule_StoreConfigFactory;

    move-result-object v1

    iget-object v2, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->schemaManagerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v3, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->packageNameProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-static {p1, v0, v1, v2, v3}, Lcom/google/android/datatransport/runtime/scheduling/persistence/SQLiteEventStore_Factory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/scheduling/persistence/SQLiteEventStore_Factory;

    move-result-object p1

    invoke-static {p1}, Lcom/google/android/datatransport/runtime/dagger/internal/DoubleCheck;->provider(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->sQLiteEventStoreProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 110
    invoke-static {}, Lcom/google/android/datatransport/runtime/time/TimeModule_EventClockFactory;->create()Lcom/google/android/datatransport/runtime/time/TimeModule_EventClockFactory;

    move-result-object p1

    invoke-static {p1}, Lcom/google/android/datatransport/runtime/scheduling/SchedulingConfigModule_ConfigFactory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/scheduling/SchedulingConfigModule_ConfigFactory;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->configProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 111
    iget-object v0, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->setApplicationContextProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->sQLiteEventStoreProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-static {}, Lcom/google/android/datatransport/runtime/time/TimeModule_UptimeClockFactory;->create()Lcom/google/android/datatransport/runtime/time/TimeModule_UptimeClockFactory;

    move-result-object v2

    invoke-static {v0, v1, p1, v2}, Lcom/google/android/datatransport/runtime/scheduling/SchedulingModule_WorkSchedulerFactory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/scheduling/SchedulingModule_WorkSchedulerFactory;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->workSchedulerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 112
    iget-object v0, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->executorProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->metadataBackendRegistryProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v2, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->sQLiteEventStoreProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-static {v0, v1, p1, v2, v2}, Lcom/google/android/datatransport/runtime/scheduling/DefaultScheduler_Factory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/scheduling/DefaultScheduler_Factory;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->defaultSchedulerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 113
    iget-object v0, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->setApplicationContextProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->metadataBackendRegistryProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v2, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->sQLiteEventStoreProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v3, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->workSchedulerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v4, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->executorProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-static {}, Lcom/google/android/datatransport/runtime/time/TimeModule_EventClockFactory;->create()Lcom/google/android/datatransport/runtime/time/TimeModule_EventClockFactory;

    move-result-object v6

    invoke-static {}, Lcom/google/android/datatransport/runtime/time/TimeModule_UptimeClockFactory;->create()Lcom/google/android/datatransport/runtime/time/TimeModule_UptimeClockFactory;

    move-result-object v7

    iget-object v8, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->sQLiteEventStoreProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    move-object v5, v2

    invoke-static/range {v0 .. v8}, Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader_Factory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader_Factory;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->uploaderProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 114
    iget-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->executorProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v0, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->sQLiteEventStoreProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->workSchedulerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-static {p1, v0, v1, v0}, Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkInitializer_Factory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkInitializer_Factory;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->workInitializerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 115
    invoke-static {}, Lcom/google/android/datatransport/runtime/time/TimeModule_EventClockFactory;->create()Lcom/google/android/datatransport/runtime/time/TimeModule_EventClockFactory;

    move-result-object p1

    invoke-static {}, Lcom/google/android/datatransport/runtime/time/TimeModule_UptimeClockFactory;->create()Lcom/google/android/datatransport/runtime/time/TimeModule_UptimeClockFactory;

    move-result-object v0

    iget-object v1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->defaultSchedulerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v2, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->uploaderProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    iget-object v3, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->workInitializerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-static {p1, v0, v1, v2, v3}, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;

    move-result-object p1

    invoke-static {p1}, Lcom/google/android/datatransport/runtime/dagger/internal/DoubleCheck;->provider(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    move-result-object p1

    iput-object p1, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->transportRuntimeProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    return-void
.end method


# virtual methods
.method getEventStore()Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;
    .locals 1

    .line 125
    iget-object v0, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->sQLiteEventStoreProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;

    return-object v0
.end method

.method getTransportRuntime()Lcom/google/android/datatransport/runtime/TransportRuntime;
    .locals 1

    .line 120
    iget-object v0, p0, Lcom/google/android/datatransport/runtime/DaggerTransportRuntimeComponent$TransportRuntimeComponentImpl;->transportRuntimeProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/android/datatransport/runtime/TransportRuntime;

    return-object v0
.end method
