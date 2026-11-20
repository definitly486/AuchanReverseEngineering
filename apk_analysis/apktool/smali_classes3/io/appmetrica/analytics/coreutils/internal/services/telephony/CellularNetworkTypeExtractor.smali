.class public final Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$Companion;,
        Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$a;,
        Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$b;
    }
.end annotation


# static fields
.field public static final Companion:Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$Companion;

.field public static final UNKNOWN_NETWORK_TYPE_VALUE:Ljava/lang/String; = "unknown"


# instance fields
.field private final a:Landroid/content/Context;

.field private final b:Lio/appmetrica/analytics/coreapi/internal/backport/FunctionWithThrowable;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor;->Companion:Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$Companion;

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;)V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor;->a:Landroid/content/Context;

    const/16 p1, 0x18

    .line 22
    invoke-static {p1}, Lio/appmetrica/analytics/coreutils/internal/AndroidUtils;->isApiAchieved(I)Z

    move-result p1

    if-eqz p1, :cond_0

    .line 23
    new-instance p1, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$a;

    invoke-direct {p1}, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$a;-><init>()V

    goto :goto_0

    .line 25
    :cond_0
    new-instance p1, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$b;

    invoke-direct {p1}, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor$b;-><init>()V

    .line 26
    :goto_0
    iput-object p1, p0, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor;->b:Lio/appmetrica/analytics/coreapi/internal/backport/FunctionWithThrowable;

    return-void
.end method


# virtual methods
.method public final getContext()Landroid/content/Context;
    .locals 1

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor;->a:Landroid/content/Context;

    return-object v0
.end method

.method public final getNetworkType()Ljava/lang/String;
    .locals 5

    .line 1
    iget-object v0, p0, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor;->a:Landroid/content/Context;

    .line 5
    iget-object v1, p0, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeExtractor;->b:Lio/appmetrica/analytics/coreapi/internal/backport/FunctionWithThrowable;

    .line 6
    const-string v2, "Extracting cellular networkType"

    const-string v3, "TelephonyManager"

    const-string v4, "phone"

    invoke-static {v0, v4, v2, v3, v1}, Lio/appmetrica/analytics/coreutils/internal/system/SystemServiceUtils;->accessSystemServiceByNameSafely(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lio/appmetrica/analytics/coreapi/internal/backport/FunctionWithThrowable;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Integer;

    .line 7
    invoke-static {v0}, Lio/appmetrica/analytics/coreutils/internal/services/telephony/CellularNetworkTypeConverter;->convert(Ljava/lang/Integer;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
