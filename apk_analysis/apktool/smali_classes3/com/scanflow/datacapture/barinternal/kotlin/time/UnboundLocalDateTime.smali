.class final Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;
.super Ljava/lang/Object;
.source "Instant.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime$Companion;


# instance fields
.field private final day:I

.field private final hour:I

.field private final minute:I

.field private final month:I

.field private final nanosecond:I

.field private final second:I

.field private final year:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime$Companion;

    return-void
.end method

.method public constructor <init>(IIIIIII)V
    .locals 0

    .line 481
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 482
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->year:I

    .line 483
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->month:I

    .line 484
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->day:I

    .line 485
    iput p4, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->hour:I

    .line 486
    iput p5, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->minute:I

    .line 487
    iput p6, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->second:I

    .line 488
    iput p7, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->nanosecond:I

    return-void
.end method


# virtual methods
.method public final getDay()I
    .locals 1

    .line 484
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->day:I

    return v0
.end method

.method public final getHour()I
    .locals 1

    .line 485
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->hour:I

    return v0
.end method

.method public final getMinute()I
    .locals 1

    .line 486
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->minute:I

    return v0
.end method

.method public final getMonth()I
    .locals 1

    .line 483
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->month:I

    return v0
.end method

.method public final getNanosecond()I
    .locals 1

    .line 488
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->nanosecond:I

    return v0
.end method

.method public final getSecond()I
    .locals 1

    .line 487
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->second:I

    return v0
.end method

.method public final getYear()I
    .locals 1

    .line 482
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->year:I

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 521
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "UnboundLocalDateTime("

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->year:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const/16 v1, 0x2d

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->month:I

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->day:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const/16 v1, 0x20

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->hour:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const/16 v1, 0x3a

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->minute:I

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->second:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const/16 v1, 0x2e

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/UnboundLocalDateTime;->nanosecond:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
