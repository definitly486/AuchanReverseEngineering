.class public Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/impl/OPPOHomeBader;
.super Ljava/lang/Object;
.source "OPPOHomeBader.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/Badger;


# instance fields
.field private mCurrentTotalCount:I


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 25
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, -0x1

    .line 33
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/impl/OPPOHomeBader;->mCurrentTotalCount:I

    return-void
.end method

.method private executeBadgeByContentProvider(Landroid/content/Context;I)V
    .locals 3

    .line 75
    :try_start_0
    new-instance v0, Landroid/os/Bundle;

    invoke-direct {v0}, Landroid/os/Bundle;-><init>()V

    .line 76
    const-string v1, "app_badge_count"

    invoke-virtual {v0, v1, p2}, Landroid/os/BaseBundle;->putInt(Ljava/lang/String;I)V

    .line 77
    invoke-virtual {p1}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object p1

    const-string p2, "content://com.android.badge/badge"

    invoke-static {p2}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object p2

    const-string v1, "setAppBadgeCount"

    const/4 v2, 0x0

    invoke-virtual {p1, p2, v1, v2, v0}, Landroid/content/ContentResolver;->call(Landroid/net/Uri;Ljava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-void

    .line 79
    :catchall_0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/ShortcutBadgeException;

    const-string p2, "Unable to execute Badge By Content Provider"

    invoke-direct {p1, p2}, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/ShortcutBadgeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method


# virtual methods
.method public executeBadge(Landroid/content/Context;Landroid/content/ComponentName;I)V
    .locals 0

    .line 37
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/impl/OPPOHomeBader;->mCurrentTotalCount:I

    if-ne p2, p3, :cond_0

    return-void

    .line 40
    :cond_0
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/impl/OPPOHomeBader;->mCurrentTotalCount:I

    .line 42
    invoke-direct {p0, p1, p3}, Lcom/scanflow/datacapture/barinternal/me/leolin/shortcutbadger/impl/OPPOHomeBader;->executeBadgeByContentProvider(Landroid/content/Context;I)V

    return-void
.end method

.method public getSupportLaunchers()Ljava/util/List;
    .locals 1

    .line 50
    const-string v0, "com.oppo.launcher"

    invoke-static {v0}, Ljava/util/Collections;->singletonList(Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method
