.class final Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;
.super Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList;
.source "EnumEntries.kt"

# interfaces
.implements Lkotlin/enums/EnumEntries;
.implements Ljava/util/RandomAccess;
.implements Ljava/io/Serializable;


# instance fields
.field private final entries:[Ljava/lang/Enum;


# direct methods
.method public constructor <init>([Ljava/lang/Enum;)V
    .locals 1

    const-string v0, "entries"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 48
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList;-><init>()V

    .line 49
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->entries:[Ljava/lang/Enum;

    return-void
.end method


# virtual methods
.method public contains(Ljava/lang/Enum;)Z
    .locals 2

    const-string v0, "element"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 70
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->entries:[Ljava/lang/Enum;

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->getOrNull([Ljava/lang/Object;I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Enum;

    if-ne v0, p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public final bridge contains(Ljava/lang/Object;)Z
    .locals 1

    .line 48
    instance-of v0, p1, Ljava/lang/Enum;

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return p1

    :cond_0
    check-cast p1, Ljava/lang/Enum;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->contains(Ljava/lang/Enum;)Z

    move-result p1

    return p1
.end method

.method public get(I)Ljava/lang/Enum;
    .locals 2

    .line 59
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->entries:[Ljava/lang/Enum;

    array-length v1, v1

    invoke-virtual {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;->checkElementIndex$kotlin_stdlib(II)V

    .line 60
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->entries:[Ljava/lang/Enum;

    aget-object p1, v0, p1

    return-object p1
.end method

.method public bridge synthetic get(I)Ljava/lang/Object;
    .locals 0

    .line 48
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->get(I)Ljava/lang/Enum;

    move-result-object p1

    return-object p1
.end method

.method public getSize()I
    .locals 1

    .line 56
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->entries:[Ljava/lang/Enum;

    array-length v0, v0

    return v0
.end method

.method public indexOf(Ljava/lang/Enum;)I
    .locals 2

    const-string v0, "element"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 78
    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v0

    .line 79
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->entries:[Ljava/lang/Enum;

    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->getOrNull([Ljava/lang/Object;I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/Enum;

    if-ne v1, p1, :cond_0

    return v0

    :cond_0
    const/4 p1, -0x1

    return p1
.end method

.method public final bridge indexOf(Ljava/lang/Object;)I
    .locals 1

    .line 48
    instance-of v0, p1, Ljava/lang/Enum;

    if-nez v0, :cond_0

    const/4 p1, -0x1

    return p1

    :cond_0
    check-cast p1, Ljava/lang/Enum;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->indexOf(Ljava/lang/Enum;)I

    move-result p1

    return p1
.end method

.method public lastIndexOf(Ljava/lang/Enum;)I
    .locals 1

    const-string v0, "element"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 83
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->indexOf(Ljava/lang/Enum;)I

    move-result p1

    return p1
.end method

.method public final bridge lastIndexOf(Ljava/lang/Object;)I
    .locals 1

    .line 48
    instance-of v0, p1, Ljava/lang/Enum;

    if-nez v0, :cond_0

    const/4 p1, -0x1

    return p1

    :cond_0
    check-cast p1, Ljava/lang/Enum;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesList;->lastIndexOf(Ljava/lang/Enum;)I

    move-result p1

    return p1
.end method
