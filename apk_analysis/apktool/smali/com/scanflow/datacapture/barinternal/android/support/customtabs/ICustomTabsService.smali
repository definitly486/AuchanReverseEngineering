.class public interface abstract Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;
.super Ljava/lang/Object;
.source "ICustomTabsService.java"

# interfaces
.implements Landroid/os/IInterface;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;,
        Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$Stub;
    }
.end annotation


# static fields
.field public static final DESCRIPTOR:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    const/16 v0, 0x24

    const/16 v1, 0x2e

    .line 557
    const-string v2, "android$support$customtabs$ICustomTabsService"

    invoke-virtual {v2, v0, v1}, Ljava/lang/String;->replace(CC)Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->DESCRIPTOR:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public abstract extraCommand(Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;
.end method

.method public abstract isEngagementSignalsApiAvailable(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/Bundle;)Z
.end method

.method public abstract mayLaunchUrl(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;Landroid/os/Bundle;Ljava/util/List;)Z
.end method

.method public abstract newSession(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;)Z
.end method

.method public abstract newSessionWithExtras(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/Bundle;)Z
.end method

.method public abstract postMessage(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Ljava/lang/String;Landroid/os/Bundle;)I
.end method

.method public abstract receiveFile(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;ILandroid/os/Bundle;)Z
.end method

.method public abstract requestPostMessageChannel(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;)Z
.end method

.method public abstract requestPostMessageChannelWithExtras(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;Landroid/os/Bundle;)Z
.end method

.method public abstract setEngagementSignalsCallback(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/IBinder;Landroid/os/Bundle;)Z
.end method

.method public abstract updateVisuals(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/Bundle;)Z
.end method

.method public abstract validateRelationship(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;ILandroid/net/Uri;Landroid/os/Bundle;)Z
.end method

.method public abstract warmup(J)Z
.end method
