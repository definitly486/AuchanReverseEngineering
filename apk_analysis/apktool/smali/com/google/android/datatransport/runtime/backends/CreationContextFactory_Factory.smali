.class public final Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;
.super Ljava/lang/Object;
.source "CreationContextFactory_Factory.java"

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
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Lcom/google/android/datatransport/runtime/dagger/internal/Factory<",
        "Lcom/google/android/datatransport/runtime/backends/CreationContextFactory;",
        ">;"
    }
.end annotation


# instance fields
.field private final applicationContextProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private final monotonicClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field

.field private final wallClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            ")V"
        }
    .end annotation

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 31
    iput-object p1, p0, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;->applicationContextProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 32
    iput-object p2, p0, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;->wallClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    .line 33
    iput-object p3, p0, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;->monotonicClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    return-void
.end method

.method public static create(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            "Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;",
            ")",
            "Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;"
        }
    .end annotation

    .line 43
    new-instance v0, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;

    invoke-direct {v0, p0, p1, p2}, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;-><init>(Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;)V

    return-object v0
.end method

.method public static newInstance(Landroid/content/Context;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/time/Clock;)Lcom/google/android/datatransport/runtime/backends/CreationContextFactory;
    .locals 1

    .line 48
    new-instance v0, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory;

    invoke-direct {v0, p0, p1, p2}, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory;-><init>(Landroid/content/Context;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/time/Clock;)V

    return-object v0
.end method


# virtual methods
.method public get()Lcom/google/android/datatransport/runtime/backends/CreationContextFactory;
    .locals 3

    .line 38
    iget-object v0, p0, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;->applicationContextProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    iget-object v1, p0, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;->wallClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-interface {v1}, Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;->get()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/google/android/datatransport/runtime/time/Clock;

    iget-object v2, p0, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;->monotonicClockProvider:Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;

    invoke-interface {v2}, Lcom/scanflow/datacapture/barinternal/javax/inject/Provider;->get()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/google/android/datatransport/runtime/time/Clock;

    invoke-static {v0, v1, v2}, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;->newInstance(Landroid/content/Context;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/time/Clock;)Lcom/google/android/datatransport/runtime/backends/CreationContextFactory;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic get()Ljava/lang/Object;
    .locals 1

    .line 12
    invoke-virtual {p0}, Lcom/google/android/datatransport/runtime/backends/CreationContextFactory_Factory;->get()Lcom/google/android/datatransport/runtime/backends/CreationContextFactory;

    move-result-object v0

    return-object v0
.end method
