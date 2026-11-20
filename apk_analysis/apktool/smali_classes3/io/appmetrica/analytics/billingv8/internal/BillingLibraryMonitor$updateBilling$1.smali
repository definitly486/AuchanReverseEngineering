.class public final Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor$updateBilling$1;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lio/appmetrica/analytics/billinginterface/internal/library/UtilsProvider;


# instance fields
.field final synthetic a:Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;


# direct methods
.method constructor <init>(Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;)V
    .locals 0

    iput-object p1, p0, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor$updateBilling$1;->a:Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getBillingInfoManager()Lio/appmetrica/analytics/billinginterface/internal/storage/BillingInfoManager;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor$updateBilling$1;->a:Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;

    invoke-static {v0}, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;->access$getBillingInfoManager$p(Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;)Lio/appmetrica/analytics/billinginterface/internal/storage/BillingInfoManager;

    move-result-object v0

    return-object v0
.end method

.method public getBillingInfoSender()Lio/appmetrica/analytics/billinginterface/internal/storage/BillingInfoSender;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor$updateBilling$1;->a:Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;

    invoke-static {v0}, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;->access$getBillingInfoSender$p(Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;)Lio/appmetrica/analytics/billinginterface/internal/storage/BillingInfoSender;

    move-result-object v0

    return-object v0
.end method

.method public getUiExecutor()Ljava/util/concurrent/Executor;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor$updateBilling$1;->a:Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;

    invoke-static {v0}, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;->access$getUiExecutor$p(Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;)Ljava/util/concurrent/Executor;

    move-result-object v0

    return-object v0
.end method

.method public getUpdatePolicy()Lio/appmetrica/analytics/billinginterface/internal/update/UpdatePolicy;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor$updateBilling$1;->a:Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;

    invoke-static {v0}, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;->access$getUpdatePolicy$p(Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;)Lio/appmetrica/analytics/billinginterface/internal/update/UpdatePolicy;

    move-result-object v0

    return-object v0
.end method

.method public getWorkerExecutor()Ljava/util/concurrent/Executor;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor$updateBilling$1;->a:Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;

    invoke-static {v0}, Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;->access$getWorkerExecutor$p(Lio/appmetrica/analytics/billingv8/internal/BillingLibraryMonitor;)Ljava/util/concurrent/Executor;

    move-result-object v0

    return-object v0
.end method
