.class public final Landroidx/browser/customtabs/CustomTabsIntent;
.super Ljava/lang/Object;
.source "CustomTabsIntent.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Landroidx/browser/customtabs/CustomTabsIntent$Api21Impl;,
        Landroidx/browser/customtabs/CustomTabsIntent$Api34Impl;,
        Landroidx/browser/customtabs/CustomTabsIntent$Api24Impl;,
        Landroidx/browser/customtabs/CustomTabsIntent$Api23Impl;,
        Landroidx/browser/customtabs/CustomTabsIntent$Builder;
    }
.end annotation


# instance fields
.field public final intent:Landroid/content/Intent;

.field public final startAnimationBundle:Landroid/os/Bundle;


# direct methods
.method constructor <init>(Landroid/content/Intent;Landroid/os/Bundle;)V
    .locals 0

    .line 666
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 667
    iput-object p1, p0, Landroidx/browser/customtabs/CustomTabsIntent;->intent:Landroid/content/Intent;

    .line 668
    iput-object p2, p0, Landroidx/browser/customtabs/CustomTabsIntent;->startAnimationBundle:Landroid/os/Bundle;

    return-void
.end method

.method public static getActivityResizeBehavior(Landroid/content/Intent;)I
    .locals 2

    .line 1601
    const-string v0, "androidx.browser.customtabs.extra.ACTIVITY_HEIGHT_RESIZE_BEHAVIOR"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result p0

    return p0
.end method

.method public static getActivitySideSheetBreakpointDp(Landroid/content/Intent;)I
    .locals 2

    .line 1639
    const-string v0, "androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_BREAKPOINT_DP"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result p0

    return p0
.end method

.method public static getActivitySideSheetDecorationType(Landroid/content/Intent;)I
    .locals 2

    .line 1680
    const-string v0, "androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_DECORATION_TYPE"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result p0

    return p0
.end method

.method public static getActivitySideSheetPosition(Landroid/content/Intent;)I
    .locals 2

    .line 1662
    const-string v0, "androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_POSITION"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result p0

    return p0
.end method

.method public static getActivitySideSheetRoundedCornersPosition(Landroid/content/Intent;)I
    .locals 2

    .line 1695
    const-string v0, "androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_ROUNDED_CORNERS_POSITION"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result p0

    return p0
.end method

.method public static getCloseButtonPosition(Landroid/content/Intent;)I
    .locals 2

    .line 1722
    const-string v0, "androidx.browser.customtabs.extra.CLOSE_BUTTON_POSITION"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result p0

    return p0
.end method

.method public static getColorSchemeParams(Landroid/content/Intent;I)Landroidx/browser/customtabs/CustomTabColorSchemeParams;
    .locals 2

    if-ltz p1, :cond_2

    const/4 v0, 0x2

    if-gt p1, v0, :cond_2

    if-eqz p1, :cond_2

    .line 1570
    invoke-virtual {p0}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object p0

    if-nez p0, :cond_0

    const/4 p0, 0x0

    .line 1572
    invoke-static {p0}, Landroidx/browser/customtabs/CustomTabColorSchemeParams;->fromBundle(Landroid/os/Bundle;)Landroidx/browser/customtabs/CustomTabColorSchemeParams;

    move-result-object p0

    return-object p0

    .line 1575
    :cond_0
    invoke-static {p0}, Landroidx/browser/customtabs/CustomTabColorSchemeParams;->fromBundle(Landroid/os/Bundle;)Landroidx/browser/customtabs/CustomTabColorSchemeParams;

    move-result-object v0

    .line 1576
    const-string v1, "androidx.browser.customtabs.extra.COLOR_SCHEME_PARAMS"

    invoke-virtual {p0, v1}, Landroid/os/Bundle;->getSparseParcelableArray(Ljava/lang/String;)Landroid/util/SparseArray;

    move-result-object p0

    if-eqz p0, :cond_1

    .line 1579
    invoke-virtual {p0, p1}, Landroid/util/SparseArray;->get(I)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Landroid/os/Bundle;

    if-eqz p0, :cond_1

    .line 1581
    invoke-static {p0}, Landroidx/browser/customtabs/CustomTabColorSchemeParams;->fromBundle(Landroid/os/Bundle;)Landroidx/browser/customtabs/CustomTabColorSchemeParams;

    move-result-object p0

    .line 1582
    invoke-virtual {p0, v0}, Landroidx/browser/customtabs/CustomTabColorSchemeParams;->withDefaults(Landroidx/browser/customtabs/CustomTabColorSchemeParams;)Landroidx/browser/customtabs/CustomTabColorSchemeParams;

    move-result-object p0

    return-object p0

    :cond_1
    return-object v0

    .line 1567
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Invalid colorScheme: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static getInitialActivityHeightPx(Landroid/content/Intent;)I
    .locals 2

    .line 1614
    const-string v0, "androidx.browser.customtabs.extra.INITIAL_ACTIVITY_HEIGHT_PX"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result p0

    return p0
.end method

.method public static getInitialActivityWidthPx(Landroid/content/Intent;)I
    .locals 2

    .line 1626
    const-string v0, "androidx.browser.customtabs.extra.INITIAL_ACTIVITY_WIDTH_PX"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result p0

    return p0
.end method

.method private static getLocaleForLanguageTag(Landroid/content/Intent;)Ljava/util/Locale;
    .locals 0

    .line 1767
    invoke-static {p0}, Landroidx/browser/customtabs/CustomTabsIntent$Api21Impl;->getLocaleForLanguageTag(Landroid/content/Intent;)Ljava/util/Locale;

    move-result-object p0

    return-object p0
.end method

.method public static getMaxToolbarItems()I
    .locals 1

    .line 0
    const/4 v0, 0x5

    return v0
.end method

.method public static getSecondaryToolbarSwipeUpGesture(Landroid/content/Intent;)Landroid/app/PendingIntent;
    .locals 1

    .line 1786
    const-string v0, "androidx.browser.customtabs.extra.SECONDARY_TOOLBAR_SWIPE_UP_GESTURE"

    invoke-virtual {p0, v0}, Landroid/content/Intent;->getParcelableExtra(Ljava/lang/String;)Landroid/os/Parcelable;

    move-result-object p0

    check-cast p0, Landroid/app/PendingIntent;

    return-object p0
.end method

.method public static getToolbarCornerRadiusDp(Landroid/content/Intent;)I
    .locals 2

    .line 1708
    const-string v0, "androidx.browser.customtabs.extra.TOOLBAR_CORNER_RADIUS_DP"

    const/16 v1, 0x10

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result p0

    return p0
.end method

.method public static getTranslateLocale(Landroid/content/Intent;)Ljava/util/Locale;
    .locals 0

    .line 1759
    invoke-static {p0}, Landroidx/browser/customtabs/CustomTabsIntent;->getLocaleForLanguageTag(Landroid/content/Intent;)Ljava/util/Locale;

    move-result-object p0

    return-object p0
.end method

.method public static isActivitySideSheetMaximizationEnabled(Landroid/content/Intent;)Z
    .locals 2

    .line 1647
    const-string v0, "androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_ENABLE_MAXIMIZATION"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getBooleanExtra(Ljava/lang/String;Z)Z

    move-result p0

    return p0
.end method

.method public static isBackgroundInteractionEnabled(Landroid/content/Intent;)Z
    .locals 2

    .line 1775
    const-string v0, "androidx.browser.customtabs.extra.DISABLE_BACKGROUND_INTERACTION"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getBooleanExtra(Ljava/lang/String;Z)Z

    move-result p0

    xor-int/lit8 p0, p0, 0x1

    return p0
.end method

.method public static isBookmarksButtonEnabled(Landroid/content/Intent;)Z
    .locals 2

    .line 1730
    const-string v0, "org.chromium.chrome.browser.customtabs.EXTRA_DISABLE_STAR_BUTTON"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getBooleanExtra(Ljava/lang/String;Z)Z

    move-result p0

    xor-int/lit8 p0, p0, 0x1

    return p0
.end method

.method public static isDownloadButtonEnabled(Landroid/content/Intent;)Z
    .locals 2

    .line 1738
    const-string v0, "org.chromium.chrome.browser.customtabs.EXTRA_DISABLE_DOWNLOAD_BUTTON"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getBooleanExtra(Ljava/lang/String;Z)Z

    move-result p0

    xor-int/lit8 p0, p0, 0x1

    return p0
.end method

.method public static isSendToExternalDefaultHandlerEnabled(Landroid/content/Intent;)Z
    .locals 2

    .line 1746
    const-string v0, "android.support.customtabs.extra.SEND_TO_EXTERNAL_HANDLER"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getBooleanExtra(Ljava/lang/String;Z)Z

    move-result p0

    return p0
.end method

.method public static setAlwaysUseBrowserUI(Landroid/content/Intent;)Landroid/content/Intent;
    .locals 2

    if-nez p0, :cond_0

    .line 1533
    new-instance p0, Landroid/content/Intent;

    const-string v0, "android.intent.action.VIEW"

    invoke-direct {p0, v0}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    :cond_0
    const/high16 v0, 0x10000000

    .line 1534
    invoke-virtual {p0, v0}, Landroid/content/Intent;->addFlags(I)Landroid/content/Intent;

    .line 1535
    const-string v0, "android.support.customtabs.extra.user_opt_out"

    const/4 v1, 0x1

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Z)Landroid/content/Intent;

    return-object p0
.end method

.method public static shouldAlwaysUseBrowserUI(Landroid/content/Intent;)Z
    .locals 2

    .line 1547
    const-string v0, "android.support.customtabs.extra.user_opt_out"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Intent;->getBooleanExtra(Ljava/lang/String;Z)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1548
    invoke-virtual {p0}, Landroid/content/Intent;->getFlags()I

    move-result p0

    const/high16 v0, 0x10000000

    and-int/2addr p0, v0

    if-eqz p0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    return v1
.end method


# virtual methods
.method public launchUrl(Landroid/content/Context;Landroid/net/Uri;)V
    .locals 1

    .line 661
    iget-object v0, p0, Landroidx/browser/customtabs/CustomTabsIntent;->intent:Landroid/content/Intent;

    invoke-virtual {v0, p2}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 662
    iget-object p2, p0, Landroidx/browser/customtabs/CustomTabsIntent;->intent:Landroid/content/Intent;

    iget-object v0, p0, Landroidx/browser/customtabs/CustomTabsIntent;->startAnimationBundle:Landroid/os/Bundle;

    invoke-static {p1, p2, v0}, Landroidx/core/content/ContextCompat;->startActivity(Landroid/content/Context;Landroid/content/Intent;Landroid/os/Bundle;)V

    return-void
.end method
