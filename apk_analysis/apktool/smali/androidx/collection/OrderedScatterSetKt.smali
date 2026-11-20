.class public final Landroidx/collection/OrderedScatterSetKt;
.super Ljava/lang/Object;
.source "OrderedScatterSet.kt"


# static fields
.field private static final EmptyOrderedScatterSet:Landroidx/collection/MutableOrderedScatterSet;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 38
    new-instance v0, Landroidx/collection/MutableOrderedScatterSet;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Landroidx/collection/MutableOrderedScatterSet;-><init>(I)V

    sput-object v0, Landroidx/collection/OrderedScatterSetKt;->EmptyOrderedScatterSet:Landroidx/collection/MutableOrderedScatterSet;

    return-void
.end method

.method public static final emptyOrderedScatterSet()Landroidx/collection/OrderedScatterSet;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">()",
            "Landroidx/collection/OrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    .line 43
    sget-object v0, Landroidx/collection/OrderedScatterSetKt;->EmptyOrderedScatterSet:Landroidx/collection/MutableOrderedScatterSet;

    const-string v1, "null cannot be cast to non-null type androidx.collection.OrderedScatterSet<E of androidx.collection.OrderedScatterSetKt.emptyOrderedScatterSet>"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    return-object v0
.end method

.method public static final mutableOrderedScatterSetOf()Landroidx/collection/MutableOrderedScatterSet;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">()",
            "Landroidx/collection/MutableOrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    .line 75
    new-instance v0, Landroidx/collection/MutableOrderedScatterSet;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableOrderedScatterSet;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public static final mutableOrderedScatterSetOf(Ljava/lang/Object;)Landroidx/collection/MutableOrderedScatterSet;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">(TE;)",
            "Landroidx/collection/MutableOrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    .line 79
    new-instance v0, Landroidx/collection/MutableOrderedScatterSet;

    const/4 v1, 0x1

    invoke-direct {v0, v1}, Landroidx/collection/MutableOrderedScatterSet;-><init>(I)V

    invoke-virtual {v0, p0}, Landroidx/collection/MutableOrderedScatterSet;->plusAssign(Ljava/lang/Object;)V

    return-object v0
.end method

.method public static final mutableOrderedScatterSetOf(Ljava/lang/Object;Ljava/lang/Object;)Landroidx/collection/MutableOrderedScatterSet;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">(TE;TE;)",
            "Landroidx/collection/MutableOrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    .line 83
    new-instance v0, Landroidx/collection/MutableOrderedScatterSet;

    const/4 v1, 0x2

    invoke-direct {v0, v1}, Landroidx/collection/MutableOrderedScatterSet;-><init>(I)V

    .line 84
    invoke-virtual {v0, p0}, Landroidx/collection/MutableOrderedScatterSet;->plusAssign(Ljava/lang/Object;)V

    .line 85
    invoke-virtual {v0, p1}, Landroidx/collection/MutableOrderedScatterSet;->plusAssign(Ljava/lang/Object;)V

    return-object v0
.end method

.method public static final mutableOrderedScatterSetOf(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Landroidx/collection/MutableOrderedScatterSet;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">(TE;TE;TE;)",
            "Landroidx/collection/MutableOrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    .line 96
    new-instance v0, Landroidx/collection/MutableOrderedScatterSet;

    const/4 v1, 0x3

    invoke-direct {v0, v1}, Landroidx/collection/MutableOrderedScatterSet;-><init>(I)V

    .line 97
    invoke-virtual {v0, p0}, Landroidx/collection/MutableOrderedScatterSet;->plusAssign(Ljava/lang/Object;)V

    .line 98
    invoke-virtual {v0, p1}, Landroidx/collection/MutableOrderedScatterSet;->plusAssign(Ljava/lang/Object;)V

    .line 99
    invoke-virtual {v0, p2}, Landroidx/collection/MutableOrderedScatterSet;->plusAssign(Ljava/lang/Object;)V

    return-object v0
.end method

.method public static final varargs mutableOrderedScatterSetOf([Ljava/lang/Object;)Landroidx/collection/MutableOrderedScatterSet;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">([TE;)",
            "Landroidx/collection/MutableOrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    const-string v0, "elements"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 104
    new-instance v0, Landroidx/collection/MutableOrderedScatterSet;

    array-length v1, p0

    invoke-direct {v0, v1}, Landroidx/collection/MutableOrderedScatterSet;-><init>(I)V

    invoke-virtual {v0, p0}, Landroidx/collection/MutableOrderedScatterSet;->plusAssign([Ljava/lang/Object;)V

    return-object v0
.end method

.method public static final orderedScatterSetOf()Landroidx/collection/OrderedScatterSet;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">()",
            "Landroidx/collection/OrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    .line 48
    sget-object v0, Landroidx/collection/OrderedScatterSetKt;->EmptyOrderedScatterSet:Landroidx/collection/MutableOrderedScatterSet;

    const-string v1, "null cannot be cast to non-null type androidx.collection.OrderedScatterSet<E of androidx.collection.OrderedScatterSetKt.orderedScatterSetOf>"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    return-object v0
.end method

.method public static final orderedScatterSetOf(Ljava/lang/Object;)Landroidx/collection/OrderedScatterSet;
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">(TE;)",
            "Landroidx/collection/OrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    .line 53
    invoke-static {p0}, Landroidx/collection/OrderedScatterSetKt;->mutableOrderedScatterSetOf(Ljava/lang/Object;)Landroidx/collection/MutableOrderedScatterSet;

    move-result-object p0

    return-object p0
.end method

.method public static final orderedScatterSetOf(Ljava/lang/Object;Ljava/lang/Object;)Landroidx/collection/OrderedScatterSet;
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">(TE;TE;)",
            "Landroidx/collection/OrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    .line 58
    invoke-static {p0, p1}, Landroidx/collection/OrderedScatterSetKt;->mutableOrderedScatterSetOf(Ljava/lang/Object;Ljava/lang/Object;)Landroidx/collection/MutableOrderedScatterSet;

    move-result-object p0

    return-object p0
.end method

.method public static final orderedScatterSetOf(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Landroidx/collection/OrderedScatterSet;
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">(TE;TE;TE;)",
            "Landroidx/collection/OrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    .line 66
    invoke-static {p0, p1, p2}, Landroidx/collection/OrderedScatterSetKt;->mutableOrderedScatterSetOf(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Landroidx/collection/MutableOrderedScatterSet;

    move-result-object p0

    return-object p0
.end method

.method public static final varargs orderedScatterSetOf([Ljava/lang/Object;)Landroidx/collection/OrderedScatterSet;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Ljava/lang/Object;",
            ">([TE;)",
            "Landroidx/collection/OrderedScatterSet<",
            "TE;>;"
        }
    .end annotation

    const-string v0, "elements"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 71
    new-instance v0, Landroidx/collection/MutableOrderedScatterSet;

    array-length v1, p0

    invoke-direct {v0, v1}, Landroidx/collection/MutableOrderedScatterSet;-><init>(I)V

    invoke-virtual {v0, p0}, Landroidx/collection/MutableOrderedScatterSet;->plusAssign([Ljava/lang/Object;)V

    return-object v0
.end method
