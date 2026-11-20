.class public final Lio/appmetrica/analytics/coreutils/internal/permission/SinglePermissionStrategy;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lio/appmetrica/analytics/coreapi/internal/permission/PermissionResolutionStrategy;


# instance fields
.field private final a:Lio/appmetrica/analytics/coreapi/internal/system/PermissionExtractor;

.field private final b:Ljava/lang/String;


# direct methods
.method public constructor <init>(Lio/appmetrica/analytics/coreapi/internal/system/PermissionExtractor;Ljava/lang/String;)V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 2
    iput-object p1, p0, Lio/appmetrica/analytics/coreutils/internal/permission/SinglePermissionStrategy;->a:Lio/appmetrica/analytics/coreapi/internal/system/PermissionExtractor;

    .line 3
    iput-object p2, p0, Lio/appmetrica/analytics/coreutils/internal/permission/SinglePermissionStrategy;->b:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public hasNecessaryPermissions(Landroid/content/Context;)Z
    .locals 2

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/coreutils/internal/permission/SinglePermissionStrategy;->a:Lio/appmetrica/analytics/coreapi/internal/system/PermissionExtractor;

    iget-object v1, p0, Lio/appmetrica/analytics/coreutils/internal/permission/SinglePermissionStrategy;->b:Ljava/lang/String;

    invoke-interface {v0, p1, v1}, Lio/appmetrica/analytics/coreapi/internal/system/PermissionExtractor;->hasPermission(Landroid/content/Context;Ljava/lang/String;)Z

    move-result p1

    return p1
.end method
