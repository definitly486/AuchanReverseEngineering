.class public Lme/leolin/shortcutbadger/impl/DefaultBadger;
.super Ljava/lang/Object;
.source "DefaultBadger.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/Badger;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 18
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public executeBadge(Landroid/content/Context;Landroid/content/ComponentName;I)V
    .locals 2

    .line 26
    new-instance v0, Landroid/content/Intent;

    const-string v1, "android.intent.action.BADGE_COUNT_UPDATE"

    invoke-direct {v0, v1}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 27
    const-string v1, "badge_count"

    invoke-virtual {v0, v1, p3}, Landroid/content/Intent;->putExtra(Ljava/lang/String;I)Landroid/content/Intent;

    .line 28
    const-string p3, "badge_count_package_name"

    invoke-virtual {p2}, Landroid/content/ComponentName;->getPackageName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, p3, v1}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 29
    const-string p3, "badge_count_class_name"

    invoke-virtual {p2}, Landroid/content/ComponentName;->getClassName()Ljava/lang/String;

    move-result-object p2

    invoke-virtual {v0, p3, p2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 31
    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/util/BroadcastHelper;->sendDefaultIntentExplicitly(Landroid/content/Context;Landroid/content/Intent;)V

    return-void
.end method

.method public getSupportLaunchers()Ljava/util/List;
    .locals 3

    .line 36
    const-string v0, "com.quaap.launchtime"

    const-string v1, "com.quaap.launchtime_official"

    const-string v2, "fr.neamar.kiss"

    filled-new-array {v2, v0, v1}, [Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method
