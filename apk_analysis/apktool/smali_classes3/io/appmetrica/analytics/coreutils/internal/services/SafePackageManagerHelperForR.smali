.class public final Lio/appmetrica/analytics/coreutils/internal/services/SafePackageManagerHelperForR;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation build Landroid/annotation/TargetApi;
    value = 0x1e
.end annotation

.annotation build Lio/appmetrica/analytics/coreapi/internal/annotations/DoNotInline;
.end annotation


# static fields
.field public static final INSTANCE:Lio/appmetrica/analytics/coreutils/internal/services/SafePackageManagerHelperForR;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lio/appmetrica/analytics/coreutils/internal/services/SafePackageManagerHelperForR;

    invoke-direct {v0}, Lio/appmetrica/analytics/coreutils/internal/services/SafePackageManagerHelperForR;-><init>()V

    sput-object v0, Lio/appmetrica/analytics/coreutils/internal/services/SafePackageManagerHelperForR;->INSTANCE:Lio/appmetrica/analytics/coreutils/internal/services/SafePackageManagerHelperForR;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static final extractPackageInstaller(Landroid/content/pm/PackageManager;Ljava/lang/String;)Ljava/lang/String;
    .locals 0

    .line 1
    invoke-static {p0, p1}, Lio/appmetrica/analytics/coreutils/internal/services/SafePackageManagerHelperForR$$ExternalSyntheticApiModelOutline0;->m(Landroid/content/pm/PackageManager;Ljava/lang/String;)Landroid/content/pm/InstallSourceInfo;

    move-result-object p0

    invoke-static {p0}, Lio/appmetrica/analytics/coreutils/internal/services/SafePackageManagerHelperForR$$ExternalSyntheticApiModelOutline1;->m(Landroid/content/pm/InstallSourceInfo;)Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method
