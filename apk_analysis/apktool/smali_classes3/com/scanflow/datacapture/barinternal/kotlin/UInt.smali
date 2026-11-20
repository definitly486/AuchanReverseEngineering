.class public final Lcom/scanflow/datacapture/barinternal/kotlin/UInt;
.super Ljava/lang/Object;
.source "UInt.kt"

# interfaces
.implements Ljava/lang/Comparable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/UInt$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/kotlin/UInt$Companion;


# instance fields
.field private final data:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/UInt$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/UInt$Companion;

    return-void
.end method

.method private synthetic constructor <init>(I)V
    .locals 0

    .line 16
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->data:I

    return-void
.end method

.method public static final synthetic box-impl(I)Lcom/scanflow/datacapture/barinternal/kotlin/UInt;
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;-><init>(I)V

    return-object v0
.end method

.method public static constructor-impl(I)I
    .locals 0

    .line 0
    return p0
.end method

.method public static equals-impl(ILjava/lang/Object;)Z
    .locals 2

    .line 0
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    :cond_0
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->unbox-impl()I

    move-result p1

    if-eq p0, p1, :cond_1

    return v1

    :cond_1
    const/4 p0, 0x1

    return p0
.end method

.method public static hashCode-impl(I)I
    .locals 0

    .line 0
    invoke-static {p0}, Ljava/lang/Integer;->hashCode(I)I

    move-result p0

    return p0
.end method

.method public static toString-impl(I)Ljava/lang/String;
    .locals 4

    int-to-long v0, p0

    const-wide v2, 0xffffffffL

    and-long/2addr v0, v2

    .line 424
    invoke-static {v0, v1}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public bridge synthetic compareTo(Ljava/lang/Object;)I
    .locals 1

    .line 14
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->unbox-impl()I

    move-result p1

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->unbox-impl()I

    move-result v0

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UnsignedKt;->uintCompare(II)I

    move-result p1

    return p1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->data:I

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->equals-impl(ILjava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public hashCode()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->data:I

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->hashCode-impl(I)I

    move-result v0

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 424
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->data:I

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->toString-impl(I)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public final synthetic unbox-impl()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/UInt;->data:I

    return v0
.end method
