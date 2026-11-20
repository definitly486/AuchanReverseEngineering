.class public final Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
.super Ljava/lang/Object;
.source "Instant.kt"

# interfaces
.implements Ljava/lang/Comparable;
.implements Ljava/io/Serializable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;

.field private static final MAX:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

.field private static final MIN:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;


# instance fields
.field private final epochSeconds:J

.field private final nanosecondsOfSecond:I


# direct methods
.method static constructor <clinit>()V
    .locals 4

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant$Companion;

    .line 437
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    const-wide v1, -0x701cefeb9bec00L

    const/4 v3, 0x0

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;-><init>(JI)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->MIN:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    .line 438
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    const-wide v1, 0x701cd2fa9578ffL

    const v3, 0x3b9ac9ff

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;-><init>(JI)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->MAX:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    return-void
.end method

.method public constructor <init>(JI)V
    .locals 2

    .line 105
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 120
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->epochSeconds:J

    .line 130
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->nanosecondsOfSecond:I

    const-wide v0, -0x701cefeb9bec00L

    cmp-long p3, v0, p1

    if-gtz p3, :cond_0

    const-wide v0, 0x701cd2fa957900L

    cmp-long p1, p1, v0

    if-gez p1, :cond_0

    return-void

    .line 134
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Instant exceeds minimum or maximum instant"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public static final synthetic access$getMAX$cp()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
    .locals 1

    .line 105
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->MAX:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    return-object v0
.end method

.method public static final synthetic access$getMIN$cp()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
    .locals 1

    .line 105
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->MIN:Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    return-object v0
.end method


# virtual methods
.method public compareTo(Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)I
    .locals 4

    const-string v0, "other"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 242
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->epochSeconds:J

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->epochSeconds:J

    invoke-static {v0, v1, v2, v3}, Lkotlin/jvm/internal/Intrinsics;->compare(JJ)I

    move-result v0

    if-eqz v0, :cond_0

    return v0

    .line 246
    :cond_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->nanosecondsOfSecond:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->nanosecondsOfSecond:I

    invoke-static {v0, p1}, Lkotlin/jvm/internal/Intrinsics;->compare(II)I

    move-result p1

    return p1
.end method

.method public bridge synthetic compareTo(Ljava/lang/Object;)I
    .locals 0

    .line 105
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->compareTo(Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)I

    move-result p1

    return p1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    if-eq p0, p1, :cond_1

    .line 250
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    if-eqz v0, :cond_0

    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->epochSeconds:J

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->epochSeconds:J

    cmp-long v0, v0, v2

    if-nez v0, :cond_0

    .line 251
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->nanosecondsOfSecond:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->nanosecondsOfSecond:I

    if-ne v0, p1, :cond_0

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    return p1

    :cond_1
    :goto_0
    const/4 p1, 0x1

    return p1
.end method

.method public final getEpochSeconds()J
    .locals 2

    .line 120
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->epochSeconds:J

    return-wide v0
.end method

.method public final getNanosecondsOfSecond()I
    .locals 1

    .line 130
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->nanosecondsOfSecond:I

    return v0
.end method

.method public hashCode()I
    .locals 2

    .line 254
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->epochSeconds:J

    invoke-static {v0, v1}, Ljava/lang/Long;->hashCode(J)I

    move-result v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;->nanosecondsOfSecond:I

    mul-int/lit8 v1, v1, 0x33

    add-int/2addr v0, v1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 267
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->access$formatIso(Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
