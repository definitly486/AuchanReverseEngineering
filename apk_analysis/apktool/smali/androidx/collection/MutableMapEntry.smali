.class final Landroidx/collection/MutableMapEntry;
.super Ljava/lang/Object;
.source "ScatterMap.kt"

# interfaces
.implements Ljava/util/Map$Entry;
.implements Lcom/scanflow/datacapture/barinternal/kotlin/jvm/internal/markers/KMutableMap$Entry;


# instance fields
.field private final index:I

.field private final keys:[Ljava/lang/Object;

.field private final values:[Ljava/lang/Object;


# direct methods
.method public constructor <init>([Ljava/lang/Object;[Ljava/lang/Object;I)V
    .locals 1

    const-string v0, "keys"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "values"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 1499
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 1500
    iput-object p1, p0, Landroidx/collection/MutableMapEntry;->keys:[Ljava/lang/Object;

    .line 1501
    iput-object p2, p0, Landroidx/collection/MutableMapEntry;->values:[Ljava/lang/Object;

    .line 1502
    iput p3, p0, Landroidx/collection/MutableMapEntry;->index:I

    return-void
.end method


# virtual methods
.method public getKey()Ljava/lang/Object;
    .locals 2

    .line 1514
    iget-object v0, p0, Landroidx/collection/MutableMapEntry;->keys:[Ljava/lang/Object;

    iget v1, p0, Landroidx/collection/MutableMapEntry;->index:I

    aget-object v0, v0, v1

    return-object v0
.end method

.method public getValue()Ljava/lang/Object;
    .locals 2

    .line 1518
    iget-object v0, p0, Landroidx/collection/MutableMapEntry;->values:[Ljava/lang/Object;

    iget v1, p0, Landroidx/collection/MutableMapEntry;->index:I

    aget-object v0, v0, v1

    return-object v0
.end method

.method public setValue(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 3

    .line 1507
    iget-object v0, p0, Landroidx/collection/MutableMapEntry;->values:[Ljava/lang/Object;

    iget v1, p0, Landroidx/collection/MutableMapEntry;->index:I

    aget-object v2, v0, v1

    .line 1508
    aput-object p1, v0, v1

    return-object v2
.end method
