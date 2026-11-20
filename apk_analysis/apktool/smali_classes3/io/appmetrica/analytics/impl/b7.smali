.class public final Lio/appmetrica/analytics/impl/b7;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lio/appmetrica/analytics/impl/a7;


# annotations
.annotation build Lio/appmetrica/analytics/coreapi/internal/annotations/DoNotInline;
.end annotation


# instance fields
.field private final a:Lio/appmetrica/analytics/impl/Sg;


# direct methods
.method public constructor <init>(Lio/appmetrica/analytics/impl/Sg;)V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 3
    iput-object p1, p0, Lio/appmetrica/analytics/impl/b7;->a:Lio/appmetrica/analytics/impl/Sg;

    return-void
.end method


# virtual methods
.method public a(Landroid/content/Context;Ljava/lang/String;)Ljava/io/File;
    .locals 2

    .line 1
    new-instance v0, Ljava/io/File;

    invoke-virtual {p1}, Landroid/content/Context;->getNoBackupFilesDir()Ljava/io/File;

    move-result-object p1

    iget-object v1, p0, Lio/appmetrica/analytics/impl/b7;->a:Lio/appmetrica/analytics/impl/Sg;

    invoke-interface {v1, p2}, Lio/appmetrica/analytics/impl/Sg;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p2

    invoke-direct {v0, p1, p2}, Ljava/io/File;-><init>(Ljava/io/File;Ljava/lang/String;)V

    return-object v0
.end method
