.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/core/text/ICUCompat;
.super Ljava/lang/Object;
.source "ICUCompat.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/core/text/ICUCompat$Api24Impl;
    }
.end annotation


# direct methods
.method static constructor <clinit>()V
    .locals 0

    .line 61
    return-void
.end method

.method public static maximizeAndGetScript(Ljava/util/Locale;)Ljava/lang/String;
    .locals 0

    .line 88
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/core/text/ICUCompat$Api24Impl;->forLocale(Ljava/util/Locale;)Landroid/icu/util/ULocale;

    move-result-object p0

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/core/text/ICUCompat$Api24Impl;->addLikelySubtags(Ljava/lang/Object;)Landroid/icu/util/ULocale;

    move-result-object p0

    .line 89
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/core/text/ICUCompat$Api24Impl;->getScript(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method
