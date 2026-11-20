.class public final Lio/appmetrica/analytics/coreutils/internal/services/PackageManagerUtilsTiramisu;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation build Landroid/annotation/TargetApi;
    value = 0x21
.end annotation

.annotation build Lio/appmetrica/analytics/coreapi/internal/annotations/DoNotInline;
.end annotation


# static fields
.field public static final INSTANCE:Lio/appmetrica/analytics/coreutils/internal/services/PackageManagerUtilsTiramisu;

.field private static final a:Ljava/lang/String; = "[PackageManagerUtilsTiramisu]"


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lio/appmetrica/analytics/coreutils/internal/services/PackageManagerUtilsTiramisu;

    invoke-direct {v0}, Lio/appmetrica/analytics/coreutils/internal/services/PackageManagerUtilsTiramisu;-><init>()V

    sput-object v0, Lio/appmetrica/analytics/coreutils/internal/services/PackageManagerUtilsTiramisu;->INSTANCE:Lio/appmetrica/analytics/coreutils/internal/services/PackageManagerUtilsTiramisu;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final resolveContentProvider(Landroid/content/pm/PackageManager;Ljava/lang/String;)Landroid/content/pm/ProviderInfo;
    .locals 2

    const-wide/16 v0, 0x8

    .line 1
    :try_start_0
    invoke-static {v0, v1}, Lio/appmetrica/analytics/coreutils/internal/services/PackageManagerUtilsTiramisu$$ExternalSyntheticApiModelOutline0;->m(J)Landroid/content/pm/PackageManager$ComponentInfoFlags;

    move-result-object v0

    .line 2
    invoke-static {p1, p2, v0}, Lio/appmetrica/analytics/coreutils/internal/services/PackageManagerUtilsTiramisu$$ExternalSyntheticApiModelOutline1;->m(Landroid/content/pm/PackageManager;Ljava/lang/String;Landroid/content/pm/PackageManager$ComponentInfoFlags;)Landroid/content/pm/ProviderInfo;

    move-result-object p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-object p1

    :catchall_0
    const/4 p1, 0x0

    return-object p1
.end method
