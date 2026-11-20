.class interface abstract Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontProvider$ContentQueryWrapper;
.super Ljava/lang/Object;
.source "FontProvider.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontProvider;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x60a
    name = "ContentQueryWrapper"
.end annotation


# direct methods
.method public static make(Landroid/content/Context;Landroid/net/Uri;)Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontProvider$ContentQueryWrapper;
    .locals 1

    .line 340
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontProvider$ContentQueryWrapperApi24Impl;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontProvider$ContentQueryWrapperApi24Impl;-><init>(Landroid/content/Context;Landroid/net/Uri;)V

    return-object v0
.end method


# virtual methods
.method public abstract close()V
.end method

.method public abstract query(Landroid/net/Uri;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Landroid/os/CancellationSignal;)Landroid/database/Cursor;
.end method
