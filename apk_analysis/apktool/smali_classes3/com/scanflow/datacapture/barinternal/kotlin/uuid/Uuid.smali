.class public final Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;
.super Ljava/lang/Object;
.source "Uuid.kt"

# interfaces
.implements Ljava/lang/Comparable;
.implements Ljava/io/Serializable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid$Companion;

.field private static final NIL:Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;


# instance fields
.field private final leastSignificantBits:J

.field private final mostSignificantBits:J


# direct methods
.method static constructor <clinit>()V
    .locals 3

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid$Companion;

    .line 291
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    const-wide/16 v1, 0x0

    invoke-direct {v0, v1, v2, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;-><init>(JJ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->NIL:Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    return-void
.end method

.method private constructor <init>(JJ)V
    .locals 0

    .line 47
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 50
    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->mostSignificantBits:J

    .line 51
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->leastSignificantBits:J

    return-void
.end method

.method public synthetic constructor <init>(JJLkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;-><init>(JJ)V

    return-void
.end method

.method public static final synthetic access$getNIL$cp()Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;
    .locals 1

    .line 47
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->NIL:Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    return-object v0
.end method


# virtual methods
.method public compareTo(Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;)I
    .locals 4

    const-string v0, "other"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 270
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->mostSignificantBits:J

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->mostSignificantBits:J

    cmp-long v2, v0, v2

    if-eqz v2, :cond_0

    .line 271
    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ULong;->constructor-impl(J)J

    move-result-wide v0

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->mostSignificantBits:J

    invoke-static {v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/ULong;->constructor-impl(J)J

    move-result-wide v2

    invoke-static {v0, v1, v2, v3}, Ljava/lang/Long;->compareUnsigned(JJ)I

    move-result p1

    return p1

    .line 273
    :cond_0
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->leastSignificantBits:J

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ULong;->constructor-impl(J)J

    move-result-wide v0

    iget-wide v2, p1, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->leastSignificantBits:J

    invoke-static {v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/ULong;->constructor-impl(J)J

    move-result-wide v2

    invoke-static {v0, v1, v2, v3}, Ljava/lang/Long;->compareUnsigned(JJ)I

    move-result p1

    return p1
.end method

.method public bridge synthetic compareTo(Ljava/lang/Object;)I
    .locals 0

    .line 47
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->compareTo(Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;)I

    move-result p1

    return p1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 7

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 242
    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    .line 243
    :cond_1
    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->mostSignificantBits:J

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->mostSignificantBits:J

    cmp-long v1, v3, v5

    if-nez v1, :cond_2

    .line 244
    iget-wide v3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->leastSignificantBits:J

    iget-wide v5, p1, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->leastSignificantBits:J

    cmp-long p1, v3, v5

    if-nez p1, :cond_2

    return v0

    :cond_2
    return v2
.end method

.method public hashCode()I
    .locals 4

    .line 277
    iget-wide v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->mostSignificantBits:J

    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->leastSignificantBits:J

    xor-long/2addr v0, v2

    invoke-static {v0, v1}, Ljava/lang/Long;->hashCode(J)I

    move-result v0

    return v0
.end method

.method public final toHexDashString()Ljava/lang/String;
    .locals 8

    const/16 v0, 0x24

    .line 163
    new-array v3, v0, [B

    .line 164
    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->mostSignificantBits:J

    const/4 v5, 0x0

    const/4 v6, 0x4

    const/4 v4, 0x0

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidJVMKt;->formatBytesInto(J[BIII)V

    const/16 v0, 0x8

    const/16 v7, 0x2d

    .line 165
    aput-byte v7, v3, v0

    .line 166
    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->mostSignificantBits:J

    const/4 v5, 0x4

    const/4 v6, 0x6

    const/16 v4, 0x9

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidJVMKt;->formatBytesInto(J[BIII)V

    const/16 v0, 0xd

    .line 167
    aput-byte v7, v3, v0

    .line 168
    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->mostSignificantBits:J

    const/4 v5, 0x6

    const/16 v6, 0x8

    const/16 v4, 0xe

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidJVMKt;->formatBytesInto(J[BIII)V

    const/16 v0, 0x12

    .line 169
    aput-byte v7, v3, v0

    .line 170
    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->leastSignificantBits:J

    const/4 v5, 0x0

    const/4 v6, 0x2

    const/16 v4, 0x13

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidJVMKt;->formatBytesInto(J[BIII)V

    const/16 v0, 0x17

    .line 171
    aput-byte v7, v3, v0

    .line 172
    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->leastSignificantBits:J

    const/4 v5, 0x2

    const/16 v6, 0x8

    const/16 v4, 0x18

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidJVMKt;->formatBytesInto(J[BIII)V

    .line 173
    invoke-static {v3}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->decodeToString([B)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 142
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->toHexDashString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
