.class public final Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;
.super Ljava/lang/Object;
.source "Duration.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser$Companion;

.field private static final default:Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;

.field private static final iso:Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;


# instance fields
.field private final allowSign:Z

.field private final lastDigitMax:J

.field private final overflowLimit:J

.field private final overflowThreshold:J


# direct methods
.method static constructor <clinit>()V
    .locals 4

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser$Companion;

    .line 1314
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;

    const-wide v1, 0x3fffffffffffffffL    # 1.9999999999999998

    const/4 v3, 0x1

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;-><init>(JZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->iso:Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;

    .line 1315
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;

    const-wide v1, 0x7fffffffffffffffL

    const/4 v3, 0x0

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;-><init>(JZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->default:Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;

    return-void
.end method

.method private constructor <init>(JZ)V
    .locals 4

    .line 1266
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->overflowLimit:J

    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->allowSign:Z

    const/16 p3, 0xa

    int-to-long v0, p3

    .line 1269
    div-long v2, p1, v0

    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->overflowThreshold:J

    .line 1272
    rem-long/2addr p1, v0

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->lastDigitMax:J

    return-void
.end method

.method public static final synthetic access$getAllowSign$p(Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;)Z
    .locals 0

    .line 1266
    iget-boolean p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->allowSign:Z

    return p0
.end method

.method public static final synthetic access$getDefault$cp()Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;
    .locals 1

    .line 1266
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->default:Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;

    return-object v0
.end method

.method public static final synthetic access$getIso$cp()Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;
    .locals 1

    .line 1266
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->iso:Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;

    return-object v0
.end method

.method public static final synthetic access$getLastDigitMax$p(Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;)J
    .locals 2

    .line 1266
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->lastDigitMax:J

    return-wide v0
.end method

.method public static final synthetic access$getOverflowLimit$p(Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;)J
    .locals 2

    .line 1266
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->overflowLimit:J

    return-wide v0
.end method

.method public static final synthetic access$getOverflowThreshold$p(Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;)J
    .locals 2

    .line 1266
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/LongParser;->overflowThreshold:J

    return-wide v0
.end method
