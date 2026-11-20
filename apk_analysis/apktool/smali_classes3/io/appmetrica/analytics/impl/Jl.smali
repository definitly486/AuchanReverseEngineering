.class public final Lio/appmetrica/analytics/impl/Jl;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation build Landroid/annotation/TargetApi;
    value = 0x1d
.end annotation

.annotation build Lio/appmetrica/analytics/coreapi/internal/annotations/DoNotInline;
.end annotation


# static fields
.field public static final a:Lio/appmetrica/analytics/impl/Jl;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lio/appmetrica/analytics/impl/Jl;

    invoke-direct {v0}, Lio/appmetrica/analytics/impl/Jl;-><init>()V

    sput-object v0, Lio/appmetrica/analytics/impl/Jl;->a:Lio/appmetrica/analytics/impl/Jl;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static final a(Landroid/telephony/SubscriptionInfo;)Ljava/lang/Integer;
    .locals 0

    .line 1
    invoke-static {p0}, Lio/appmetrica/analytics/impl/Jl$$ExternalSyntheticApiModelOutline1;->m(Landroid/telephony/SubscriptionInfo;)Ljava/lang/String;

    move-result-object p0

    invoke-static {p0}, Lio/appmetrica/analytics/coreutils/internal/parsing/ParseUtils;->intValueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object p0

    return-object p0
.end method

.method public static final b(Landroid/telephony/SubscriptionInfo;)Ljava/lang/Integer;
    .locals 0

    .line 1
    invoke-static {p0}, Lio/appmetrica/analytics/impl/Jl$$ExternalSyntheticApiModelOutline0;->m(Landroid/telephony/SubscriptionInfo;)Ljava/lang/String;

    move-result-object p0

    invoke-static {p0}, Lio/appmetrica/analytics/coreutils/internal/parsing/ParseUtils;->intValueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object p0

    return-object p0
.end method
