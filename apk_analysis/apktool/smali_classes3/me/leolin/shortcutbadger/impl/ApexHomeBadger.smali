.class public Lme/leolin/shortcutbadger/impl/ApexHomeBadger;
.super Ljava/lang/Object;
.source "ApexHomeBadger.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/Badger;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 17
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public executeBadge(Landroid/content/Context;Landroid/content/ComponentName;I)V
    .locals 3

    .line 26
    new-instance v0, Landroid/content/Intent;

    const-string v1, "com.anddoes.launcher.COUNTER_CHANGED"

    invoke-direct {v0, v1}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 27
    const-string v1, "package"

    invoke-virtual {p2}, Landroid/content/ComponentName;->getPackageName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 28
    const-string v1, "count"

    invoke-virtual {v0, v1, p3}, Landroid/content/Intent;->putExtra(Ljava/lang/String;I)Landroid/content/Intent;

    .line 29
    const-string p3, "class"

    invoke-virtual {p2}, Landroid/content/ComponentName;->getClassName()Ljava/lang/String;

    move-result-object p2

    invoke-virtual {v0, p3, p2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 31
    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/util/BroadcastHelper;->sendIntentExplicitly(Landroid/content/Context;Landroid/content/Intent;)V

    return-void
.end method

.method public getSupportLaunchers()Ljava/util/List;
    .locals 1

    .line 36
    const-string v0, "com.anddoes.launcher"

    filled-new-array {v0}, [Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method
