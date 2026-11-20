.class public final Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;
.super Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;
.source "PrimitiveRanges.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange$Companion;

.field private static final EMPTY:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange$Companion;

    .line 86
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    const/4 v1, 0x1

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;-><init>(II)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;->EMPTY:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    return-void
.end method

.method public constructor <init>(II)V
    .locals 1

    const/4 v0, 0x1

    .line 54
    invoke-direct {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;-><init>(III)V

    return-void
.end method

.method public static final synthetic access$getEMPTY$cp()Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;
    .locals 1

    .line 54
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;->EMPTY:Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    return-object v0
.end method


# virtual methods
.method public contains(I)Z
    .locals 1

    .line 66
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getFirst()I

    move-result v0

    if-gt v0, p1, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getLast()I

    move-result v0

    if-gt p1, v0, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 2

    .line 76
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    if-eqz v0, :cond_2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_0

    move-object v0, p1

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_1

    .line 77
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getFirst()I

    move-result v0

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getFirst()I

    move-result v1

    if-ne v0, v1, :cond_2

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getLast()I

    move-result v0

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getLast()I

    move-result p1

    if-ne v0, p1, :cond_2

    :cond_1
    const/4 p1, 0x1

    return p1

    :cond_2
    const/4 p1, 0x0

    return p1
.end method

.method public getEndInclusive()Ljava/lang/Integer;
    .locals 1

    .line 56
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getLast()I

    move-result v0

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    return-object v0
.end method

.method public getStart()Ljava/lang/Integer;
    .locals 1

    .line 55
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getFirst()I

    move-result v0

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    return-object v0
.end method

.method public hashCode()I
    .locals 2

    .line 80
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntRange;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, -0x1

    return v0

    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getFirst()I

    move-result v0

    mul-int/lit8 v0, v0, 0x1f

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getLast()I

    move-result v1

    add-int/2addr v0, v1

    return v0
.end method

.method public isEmpty()Z
    .locals 2

    .line 73
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getFirst()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getLast()I

    move-result v1

    if-le v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 82
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getFirst()I

    move-result v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ".."

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;->getLast()I

    move-result v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
