.class public final Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;
.super Lio/appmetrica/analytics/modulesapi/internal/client/ModuleClientEntryPoint;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lio/appmetrica/analytics/modulesapi/internal/client/ModuleClientEntryPoint<",
        "Lio/appmetrica/analytics/screenshot/internal/config/ParcelableRemoteScreenshotConfig;",
        ">;"
    }
.end annotation


# instance fields
.field private a:Lio/appmetrica/analytics/screenshot/impl/l;

.field private final b:Lio/appmetrica/analytics/screenshot/impl/h;

.field private final c:Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$configUpdateListener$1;

.field private d:Lio/appmetrica/analytics/screenshot/impl/S;

.field private final e:Ljava/lang/String;

.field private final f:Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$serviceConfigExtensionConfiguration$1;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 1
    invoke-direct {p0}, Lio/appmetrica/analytics/modulesapi/internal/client/ModuleClientEntryPoint;-><init>()V

    .line 7
    new-instance v0, Lio/appmetrica/analytics/screenshot/impl/h;

    invoke-direct {v0}, Lio/appmetrica/analytics/screenshot/impl/h;-><init>()V

    iput-object v0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->b:Lio/appmetrica/analytics/screenshot/impl/h;

    .line 8
    new-instance v0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$configUpdateListener$1;

    invoke-direct {v0, p0}, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$configUpdateListener$1;-><init>(Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;)V

    iput-object v0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->c:Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$configUpdateListener$1;

    .line 26
    const-string v0, "screenshot"

    iput-object v0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->e:Ljava/lang/String;

    .line 29
    new-instance v0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$serviceConfigExtensionConfiguration$1;

    invoke-direct {v0, p0}, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$serviceConfigExtensionConfiguration$1;-><init>(Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;)V

    iput-object v0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->f:Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$serviceConfigExtensionConfiguration$1;

    return-void
.end method

.method public static final synthetic access$getBundleConverter$p(Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;)Lio/appmetrica/analytics/screenshot/impl/h;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->b:Lio/appmetrica/analytics/screenshot/impl/h;

    return-object p0
.end method

.method public static final synthetic access$getClientSideRemoteScreenshotConfig$p(Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;)Lio/appmetrica/analytics/screenshot/impl/l;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->a:Lio/appmetrica/analytics/screenshot/impl/l;

    return-object p0
.end method

.method public static final synthetic access$getConfigUpdateListener$p(Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;)Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$configUpdateListener$1;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->c:Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$configUpdateListener$1;

    return-object p0
.end method

.method public static final synthetic access$getScreenshotCaptorsController$p(Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;)Lio/appmetrica/analytics/screenshot/impl/S;
    .locals 0

    .line 1
    iget-object p0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->d:Lio/appmetrica/analytics/screenshot/impl/S;

    return-object p0
.end method

.method public static final synthetic access$setClientSideRemoteScreenshotConfig$p(Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;Lio/appmetrica/analytics/screenshot/impl/l;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->a:Lio/appmetrica/analytics/screenshot/impl/l;

    return-void
.end method


# virtual methods
.method public getIdentifier()Ljava/lang/String;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->e:Ljava/lang/String;

    return-object v0
.end method

.method public getServiceConfigExtensionConfiguration()Lio/appmetrica/analytics/modulesapi/internal/client/ServiceConfigExtensionConfiguration;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lio/appmetrica/analytics/modulesapi/internal/client/ServiceConfigExtensionConfiguration<",
            "Lio/appmetrica/analytics/screenshot/internal/config/ParcelableRemoteScreenshotConfig;",
            ">;"
        }
    .end annotation

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->f:Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint$serviceConfigExtensionConfiguration$1;

    return-object v0
.end method

.method public initClientSide(Lio/appmetrica/analytics/modulesapi/internal/client/ClientContext;)V
    .locals 3

    .line 1
    monitor-enter p0

    .line 2
    :try_start_0
    new-instance v0, Lio/appmetrica/analytics/screenshot/impl/S;

    .line 3
    new-instance v1, Lio/appmetrica/analytics/screenshot/impl/x;

    invoke-direct {v1, p1}, Lio/appmetrica/analytics/screenshot/impl/x;-><init>(Lio/appmetrica/analytics/modulesapi/internal/client/ClientContext;)V

    const/16 v2, 0x22

    .line 5
    invoke-static {v2}, Lio/appmetrica/analytics/coreutils/internal/AndroidUtils;->isApiAchieved(I)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 6
    new-instance v2, Lio/appmetrica/analytics/screenshot/impl/w;

    invoke-direct {v2, p1, v1}, Lio/appmetrica/analytics/screenshot/impl/w;-><init>(Lio/appmetrica/analytics/modulesapi/internal/client/ClientContext;Lio/appmetrica/analytics/screenshot/impl/Q;)V

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 8
    :cond_0
    new-instance v2, Lio/appmetrica/analytics/screenshot/impl/G;

    invoke-direct {v2, p1, v1}, Lio/appmetrica/analytics/screenshot/impl/G;-><init>(Lio/appmetrica/analytics/modulesapi/internal/client/ClientContext;Lio/appmetrica/analytics/screenshot/impl/Q;)V

    .line 9
    :goto_0
    invoke-direct {v0, v2}, Lio/appmetrica/analytics/screenshot/impl/S;-><init>(Lio/appmetrica/analytics/screenshot/impl/i;)V

    .line 10
    iput-object v0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->d:Lio/appmetrica/analytics/screenshot/impl/S;

    .line 11
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 12
    monitor-exit p0

    return-void

    .line 13
    :goto_1
    monitor-exit p0

    throw p1
.end method

.method public onActivated()V
    .locals 4

    .line 1
    monitor-enter p0

    .line 2
    :try_start_0
    iget-object v0, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->d:Lio/appmetrica/analytics/screenshot/impl/S;

    if-eqz v0, :cond_1

    .line 4
    iget-object v1, p0, Lio/appmetrica/analytics/screenshot/internal/ScreenshotClientModuleEntryPoint;->a:Lio/appmetrica/analytics/screenshot/impl/l;

    .line 5
    iget-object v2, v0, Lio/appmetrica/analytics/screenshot/impl/S;->a:Ljava/util/List;

    .line 17
    invoke-interface {v2}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :goto_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_0

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lio/appmetrica/analytics/screenshot/impl/P;

    .line 18
    invoke-interface {v3}, Lio/appmetrica/analytics/screenshot/impl/P;->a()V

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    .line 20
    :cond_0
    invoke-virtual {v0, v1}, Lio/appmetrica/analytics/screenshot/impl/S;->a(Lio/appmetrica/analytics/screenshot/impl/l;)V

    .line 21
    :cond_1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 22
    monitor-exit p0

    return-void

    .line 23
    :goto_1
    monitor-exit p0

    throw v0
.end method
