.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat;
.super Ljava/lang/Object;
.source "TextDirectionHeuristicsCompat.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;,
        Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionAlgorithm;,
        Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$FirstStrong;,
        Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$AnyStrong;,
        Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicLocale;,
        Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicImpl;
    }
.end annotation


# static fields
.field public static final ANYRTL_LTR:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

.field public static final FIRSTSTRONG_LTR:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

.field public static final FIRSTSTRONG_RTL:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

.field public static final LOCALE:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

.field public static final LTR:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

.field public static final RTL:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;


# direct methods
.method static constructor <clinit>()V
    .locals 4

    .line 33
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;

    const/4 v1, 0x0

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionAlgorithm;Z)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat;->LTR:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

    .line 39
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;

    const/4 v3, 0x1

    invoke-direct {v0, v1, v3}, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionAlgorithm;Z)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat;->RTL:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

    .line 47
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$FirstStrong;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$FirstStrong;

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionAlgorithm;Z)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat;->FIRSTSTRONG_LTR:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

    .line 55
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;

    invoke-direct {v0, v1, v3}, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionAlgorithm;Z)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat;->FIRSTSTRONG_RTL:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

    .line 62
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$AnyStrong;->INSTANCE_RTL:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$AnyStrong;

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicInternal;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionAlgorithm;Z)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat;->ANYRTL_LTR:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

    .line 68
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicLocale;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat$TextDirectionHeuristicLocale;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicsCompat;->LOCALE:Lcom/scanflow/datacapture/barinternal/androidx/core/text/TextDirectionHeuristicCompat;

    return-void
.end method

.method static isRtlText(I)I
    .locals 1

    .line 79
    const/4 v0, 0x1

    if-eqz p0, :cond_1

    if-eq p0, v0, :cond_0

    const/4 v0, 0x2

    if-eq p0, v0, :cond_0

    return v0

    :cond_0
    const/4 p0, 0x0

    return p0

    :cond_1
    return v0
.end method

.method static isRtlTextOrFormat(I)I
    .locals 2

    .line 91
    const/4 v0, 0x1

    if-eqz p0, :cond_1

    if-eq p0, v0, :cond_0

    const/4 v1, 0x2

    if-eq p0, v1, :cond_0

    packed-switch p0, :pswitch_data_0

    return v1

    :cond_0
    :pswitch_0
    const/4 p0, 0x0

    return p0

    :cond_1
    :pswitch_1
    return v0

    nop

    :pswitch_data_0
    .packed-switch 0xe
        :pswitch_1
        :pswitch_1
        :pswitch_0
        :pswitch_0
    .end packed-switch
.end method
