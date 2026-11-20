.class Landroidx/browser/customtabs/CustomTabsSession$MockSession;
.super Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$Stub;
.source "CustomTabsSession.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Landroidx/browser/customtabs/CustomTabsSession;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = "MockSession"
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 558
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$Stub;-><init>()V

    return-void
.end method


# virtual methods
.method public extraCommand(Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;
    .locals 0

    .line 0
    const/4 p1, 0x0

    return-object p1
.end method

.method public isEngagementSignalsApiAvailable(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/Bundle;)Z
    .locals 0

    .line 626
    const/4 p1, 0x0

    return p1
.end method

.method public mayLaunchUrl(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;Landroid/os/Bundle;Ljava/util/List;)Z
    .locals 0

    .line 578
    const/4 p1, 0x0

    return p1
.end method

.method public newSession(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;)Z
    .locals 0

    .line 566
    const/4 p1, 0x0

    return p1
.end method

.method public newSessionWithExtras(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/Bundle;)Z
    .locals 0

    .line 572
    const/4 p1, 0x0

    return p1
.end method

.method public postMessage(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Ljava/lang/String;Landroid/os/Bundle;)I
    .locals 0

    .line 608
    const/4 p1, 0x0

    return p1
.end method

.method public receiveFile(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;ILandroid/os/Bundle;)Z
    .locals 0

    .line 620
    const/4 p1, 0x0

    return p1
.end method

.method public requestPostMessageChannel(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;)Z
    .locals 0

    .line 596
    const/4 p1, 0x0

    return p1
.end method

.method public requestPostMessageChannelWithExtras(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;Landroid/os/Bundle;)Z
    .locals 0

    .line 602
    const/4 p1, 0x0

    return p1
.end method

.method public setEngagementSignalsCallback(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/IBinder;Landroid/os/Bundle;)Z
    .locals 0

    .line 632
    const/4 p1, 0x0

    return p1
.end method

.method public updateVisuals(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/Bundle;)Z
    .locals 0

    .line 590
    const/4 p1, 0x0

    return p1
.end method

.method public validateRelationship(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;ILandroid/net/Uri;Landroid/os/Bundle;)Z
    .locals 0

    .line 614
    const/4 p1, 0x0

    return p1
.end method

.method public warmup(J)Z
    .locals 0

    .line 0
    const/4 p1, 0x0

    return p1
.end method
