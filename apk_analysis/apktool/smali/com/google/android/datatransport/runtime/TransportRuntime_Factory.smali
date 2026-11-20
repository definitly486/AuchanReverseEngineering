.class public final Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;
.super Ljava/lang/Object;
.source "TransportRuntime_Factory.java"

# interfaces
.implements Lcom/google/android/datatransport/runtime/dagger/internal/Factory;


# annotations
.annotation build Lcom/google/android/datatransport/runtime/dagger/internal/DaggerGenerated;
.end annotation

.annotation build Lcom/google/android/datatransport/runtime/dagger/internal/QualifierMetadata;
    value = {
        "com.google.android.datatransport.runtime.time.WallTime",
        "com.google.android.datatransport.runtime.time.Monotonic"
    }
.end annotation

.annotation build Lcom/google/android/datatransport/runtime/dagger/internal/ScopeMetadata;
    value = "javax.inject.Singleton"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/android/datatransport/runtime/dagger/internal/Factory<",
        "Lcom/google/android/datatransport/runtime/TransportRuntime;",
        ">;"
    }
.end annotation


# instance fields
.field private final eventClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private final initializerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private final schedulerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private final uploaderProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private final uptimeClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            ")V"
        }
    .end annotation

    .line 37
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 38
    iput-object p1, p0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->eventClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 39
    iput-object p2, p0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->uptimeClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 40
    iput-object p3, p0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->schedulerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 41
    iput-object p4, p0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->uploaderProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 42
    iput-object p5, p0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->initializerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    return-void
.end method

.method public static create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            ")",
            "Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;"
        }
    .end annotation

    .line 53
    new-instance v0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    invoke-direct/range {v0 .. v5}, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;-><init>(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)V

    return-object v0
.end method

.method public static newInstance(Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/scheduling/Scheduler;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkInitializer;)Lcom/google/android/datatransport/runtime/TransportRuntime;
    .locals 6

    .line 58
    new-instance v0, Lcom/google/android/datatransport/runtime/TransportRuntime;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    invoke-direct/range {v0 .. v5}, Lcom/google/android/datatransport/runtime/TransportRuntime;-><init>(Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/scheduling/Scheduler;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkInitializer;)V

    return-object v0
.end method


# virtual methods
.method public get()Lcom/google/android/datatransport/runtime/TransportRuntime;
    .locals 5

    .line 47
    iget-object v0, p0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->eventClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/google/android/datatransport/runtime/time/Clock;

    iget-object v1, p0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->uptimeClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-interface {v1}, Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;->get()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/google/android/datatransport/runtime/time/Clock;

    iget-object v2, p0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->schedulerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-interface {v2}, Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;->get()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/google/android/datatransport/runtime/scheduling/Scheduler;

    iget-object v3, p0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->uploaderProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-interface {v3}, Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;->get()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader;

    iget-object v4, p0, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->initializerProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-interface {v4}, Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;->get()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkInitializer;

    invoke-static {v0, v1, v2, v3, v4}, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->newInstance(Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/scheduling/Scheduler;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkInitializer;)Lcom/google/android/datatransport/runtime/TransportRuntime;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic get()Ljava/lang/Object;
    .locals 1

    .line 14
    invoke-virtual {p0}, Lcom/google/android/datatransport/runtime/TransportRuntime_Factory;->get()Lcom/google/android/datatransport/runtime/TransportRuntime;

    move-result-object v0

    return-object v0
.end method
