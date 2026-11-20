.class public abstract Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/util/BroadcastHelper;
.super Ljava/lang/Object;
.source "BroadcastHelper.java"


# direct methods
.method public static resolveBroadcast(Landroid/content/Context;Landroid/content/Intent;)Ljava/util/List;
    .locals 1

    .line 21
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object p0

    const/4 v0, 0x0

    .line 22
    invoke-virtual {p0, p1, v0}, Landroid/content/pm/PackageManager;->queryBroadcastReceivers(Landroid/content/Intent;I)Ljava/util/List;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    .line 24
    :cond_0
    sget-object p0, Ljava/util/Collections;->EMPTY_LIST:Ljava/util/List;

    return-object p0
.end method

.method public static sendDefaultIntentExplicitly(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 2

    .line 48
    new-instance v0, Landroid/content/Intent;

    invoke-direct {v0, p1}, Landroid/content/Intent;-><init>(Landroid/content/Intent;)V

    .line 50
    const-string v1, "me.leolin.shortcutbadger.BADGE_COUNT_UPDATE"

    invoke-virtual {v0, v1}, Landroid/content/Intent;->setAction(Ljava/lang/String;)Landroid/content/Intent;

    .line 53
    :try_start_0
    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/util/BroadcastHelper;->sendIntentExplicitly(Landroid/content/Context;Landroid/content/Intent;)V
    :try_end_0
    .catch Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/ShortcutBadgeException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    .line 65
    :catch_0
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/util/BroadcastHelper;->sendIntentExplicitly(Landroid/content/Context;Landroid/content/Intent;)V

    return-void
.end method

.method public static sendIntentExplicitly(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 3

    .line 28
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/util/BroadcastHelper;->resolveBroadcast(Landroid/content/Context;Landroid/content/Intent;)Ljava/util/List;

    move-result-object v0

    .line 30
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    if-eqz v1, :cond_2

    .line 34
    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :cond_0
    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroid/content/pm/ResolveInfo;

    .line 35
    new-instance v2, Landroid/content/Intent;

    invoke-direct {v2, p1}, Landroid/content/Intent;-><init>(Landroid/content/Intent;)V

    if-eqz v1, :cond_0

    .line 38
    iget-object v1, v1, Landroid/content/pm/ResolveInfo;->resolvePackageName:Ljava/lang/String;

    invoke-virtual {v2, v1}, Landroid/content/Intent;->setPackage(Ljava/lang/String;)Landroid/content/Intent;

    .line 39
    invoke-virtual {p0, v2}, Landroid/content/Context;->sendBroadcast(Landroid/content/Intent;)V

    goto :goto_0

    :cond_1
    return-void

    .line 31
    :cond_2
    new-instance p0, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/ShortcutBadgeException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "unable to resolve intent: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Landroid/content/Intent;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/ShortcutBadgeException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
