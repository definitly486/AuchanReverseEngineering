.class public final Landroidx/work/impl/utils/NetworkRequest30;
.super Ljava/lang/Object;
.source "NetworkRequestCompat.kt"


# static fields
.field public static final INSTANCE:Landroidx/work/impl/utils/NetworkRequest30;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Landroidx/work/impl/utils/NetworkRequest30;

    invoke-direct {v0}, Landroidx/work/impl/utils/NetworkRequest30;-><init>()V

    sput-object v0, Landroidx/work/impl/utils/NetworkRequest30;->INSTANCE:Landroidx/work/impl/utils/NetworkRequest30;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 173
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final getNetworkSpecifier(Landroid/net/NetworkRequest;)Landroid/net/NetworkSpecifier;
    .locals 1

    const-string v0, "request"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 175
    invoke-static {p1}, Landroidx/work/impl/utils/NetworkRequest30$$ExternalSyntheticApiModelOutline0;->m(Landroid/net/NetworkRequest;)Landroid/net/NetworkSpecifier;

    move-result-object p1

    return-object p1
.end method
