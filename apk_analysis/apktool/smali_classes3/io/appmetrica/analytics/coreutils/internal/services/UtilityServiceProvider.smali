.class public final Lio/appmetrica/analytics/coreutils/internal/services/UtilityServiceProvider;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field private final a:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

.field private final b:Lio/appmetrica/analytics/coreutils/internal/services/WaitForActivationDelayBarrier;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 5
    new-instance v0, Lio/appmetrica/analytics/coreutils/impl/l;

    invoke-direct {v0, p0}, Lio/appmetrica/analytics/coreutils/impl/l;-><init>(Lio/appmetrica/analytics/coreutils/internal/services/UtilityServiceProvider;)V

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/LazyKt;->lazy(Lkotlin/jvm/functions/Function0;)Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    move-result-object v0

    iput-object v0, p0, Lio/appmetrica/analytics/coreutils/internal/services/UtilityServiceProvider;->a:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    .line 7
    new-instance v0, Lio/appmetrica/analytics/coreutils/internal/services/WaitForActivationDelayBarrier;

    invoke-direct {v0}, Lio/appmetrica/analytics/coreutils/internal/services/WaitForActivationDelayBarrier;-><init>()V

    iput-object v0, p0, Lio/appmetrica/analytics/coreutils/internal/services/UtilityServiceProvider;->b:Lio/appmetrica/analytics/coreutils/internal/services/WaitForActivationDelayBarrier;

    return-void
.end method


# virtual methods
.method public final getActivationBarrier()Lio/appmetrica/analytics/coreutils/internal/services/WaitForActivationDelayBarrier;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/coreutils/internal/services/UtilityServiceProvider;->b:Lio/appmetrica/analytics/coreutils/internal/services/WaitForActivationDelayBarrier;

    return-object v0
.end method

.method public final getFirstExecutionService()Lio/appmetrica/analytics/coreutils/internal/services/FirstExecutionConditionServiceImpl;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/coreutils/internal/services/UtilityServiceProvider;->a:Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Lazy;->getValue()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lio/appmetrica/analytics/coreutils/internal/services/FirstExecutionConditionServiceImpl;

    return-object v0
.end method

.method public final initAsync()V
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/coreutils/internal/services/UtilityServiceProvider;->b:Lio/appmetrica/analytics/coreutils/internal/services/WaitForActivationDelayBarrier;

    invoke-virtual {v0}, Lio/appmetrica/analytics/coreutils/internal/services/WaitForActivationDelayBarrier;->activate()V

    return-void
.end method

.method public final updateConfiguration(Lio/appmetrica/analytics/coreutils/internal/services/UtilityServiceConfiguration;)V
    .locals 1

    .line 1
    invoke-virtual {p0}, Lio/appmetrica/analytics/coreutils/internal/services/UtilityServiceProvider;->getFirstExecutionService()Lio/appmetrica/analytics/coreutils/internal/services/FirstExecutionConditionServiceImpl;

    move-result-object v0

    invoke-virtual {v0, p1}, Lio/appmetrica/analytics/coreutils/internal/services/FirstExecutionConditionServiceImpl;->updateConfig(Lio/appmetrica/analytics/coreutils/internal/services/UtilityServiceConfiguration;)V

    return-void
.end method
