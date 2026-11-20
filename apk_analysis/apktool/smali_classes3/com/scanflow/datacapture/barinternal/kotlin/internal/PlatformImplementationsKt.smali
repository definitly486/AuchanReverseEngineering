.class public abstract Lcom/scanflow/datacapture/barinternal/kotlin/internal/PlatformImplementationsKt;
.super Ljava/lang/Object;
.source "PlatformImplementations.kt"


# static fields
.field public static final IMPLEMENTATIONS:Lcom/scanflow/datacapture/barinternal/kotlin/internal/PlatformImplementations;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 57
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/internal/jdk8/JDK8PlatformImplementations;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/internal/jdk8/JDK8PlatformImplementations;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/internal/PlatformImplementationsKt;->IMPLEMENTATIONS:Lcom/scanflow/datacapture/barinternal/kotlin/internal/PlatformImplementations;

    return-void
.end method
