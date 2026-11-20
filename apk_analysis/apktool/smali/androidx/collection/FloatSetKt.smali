.class public final Landroidx/collection/FloatSetKt;
.super Ljava/lang/Object;
.source "FloatSet.kt"


# static fields
.field private static final EmptyFloatArray:[F

.field private static final EmptyFloatSet:Landroidx/collection/MutableFloatSet;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 49
    new-instance v0, Landroidx/collection/MutableFloatSet;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatSet;-><init>(I)V

    sput-object v0, Landroidx/collection/FloatSetKt;->EmptyFloatSet:Landroidx/collection/MutableFloatSet;

    .line 52
    new-array v0, v1, [F

    sput-object v0, Landroidx/collection/FloatSetKt;->EmptyFloatArray:[F

    return-void
.end method

.method public static final buildFloatSet(ILkotlin/jvm/functions/Function1;)Landroidx/collection/FloatSet;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableFloatSet;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/FloatSet;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 134
    new-instance v0, Landroidx/collection/MutableFloatSet;

    invoke-direct {v0, p0}, Landroidx/collection/MutableFloatSet;-><init>(I)V

    invoke-interface {p1, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final buildFloatSet(Lkotlin/jvm/functions/Function1;)Landroidx/collection/FloatSet;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableFloatSet;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/FloatSet;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 117
    new-instance v0, Landroidx/collection/MutableFloatSet;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatSet;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-interface {p0, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final emptyFloatSet()Landroidx/collection/FloatSet;
    .locals 1

    .line 55
    sget-object v0, Landroidx/collection/FloatSetKt;->EmptyFloatSet:Landroidx/collection/MutableFloatSet;

    return-object v0
.end method

.method public static final floatSetOf()Landroidx/collection/FloatSet;
    .locals 1

    .line 58
    sget-object v0, Landroidx/collection/FloatSetKt;->EmptyFloatSet:Landroidx/collection/MutableFloatSet;

    return-object v0
.end method

.method public static final floatSetOf(F)Landroidx/collection/FloatSet;
    .locals 0

    .line 62
    invoke-static {p0}, Landroidx/collection/FloatSetKt;->mutableFloatSetOf(F)Landroidx/collection/MutableFloatSet;

    move-result-object p0

    return-object p0
.end method

.method public static final floatSetOf(FF)Landroidx/collection/FloatSet;
    .locals 0

    .line 67
    invoke-static {p0, p1}, Landroidx/collection/FloatSetKt;->mutableFloatSetOf(FF)Landroidx/collection/MutableFloatSet;

    move-result-object p0

    return-object p0
.end method

.method public static final floatSetOf(FFF)Landroidx/collection/FloatSet;
    .locals 0

    .line 72
    invoke-static {p0, p1, p2}, Landroidx/collection/FloatSetKt;->mutableFloatSetOf(FFF)Landroidx/collection/MutableFloatSet;

    move-result-object p0

    return-object p0
.end method

.method public static final varargs floatSetOf([F)Landroidx/collection/FloatSet;
    .locals 2

    const-string v0, "elements"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 77
    new-instance v0, Landroidx/collection/MutableFloatSet;

    array-length v1, p0

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatSet;-><init>(I)V

    invoke-virtual {v0, p0}, Landroidx/collection/MutableFloatSet;->plusAssign([F)V

    return-object v0
.end method

.method public static final getEmptyFloatArray()[F
    .locals 1

    .line 52
    sget-object v0, Landroidx/collection/FloatSetKt;->EmptyFloatArray:[F

    return-object v0
.end method

.method public static final mutableFloatSetOf()Landroidx/collection/MutableFloatSet;
    .locals 4

    .line 80
    new-instance v0, Landroidx/collection/MutableFloatSet;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatSet;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public static final mutableFloatSetOf(F)Landroidx/collection/MutableFloatSet;
    .locals 2

    .line 84
    new-instance v0, Landroidx/collection/MutableFloatSet;

    const/4 v1, 0x1

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatSet;-><init>(I)V

    invoke-virtual {v0, p0}, Landroidx/collection/MutableFloatSet;->plusAssign(F)V

    return-object v0
.end method

.method public static final mutableFloatSetOf(FF)Landroidx/collection/MutableFloatSet;
    .locals 2

    .line 88
    new-instance v0, Landroidx/collection/MutableFloatSet;

    const/4 v1, 0x2

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatSet;-><init>(I)V

    .line 89
    invoke-virtual {v0, p0}, Landroidx/collection/MutableFloatSet;->plusAssign(F)V

    .line 90
    invoke-virtual {v0, p1}, Landroidx/collection/MutableFloatSet;->plusAssign(F)V

    return-object v0
.end method

.method public static final mutableFloatSetOf(FFF)Landroidx/collection/MutableFloatSet;
    .locals 2

    .line 95
    new-instance v0, Landroidx/collection/MutableFloatSet;

    const/4 v1, 0x3

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatSet;-><init>(I)V

    .line 96
    invoke-virtual {v0, p0}, Landroidx/collection/MutableFloatSet;->plusAssign(F)V

    .line 97
    invoke-virtual {v0, p1}, Landroidx/collection/MutableFloatSet;->plusAssign(F)V

    .line 98
    invoke-virtual {v0, p2}, Landroidx/collection/MutableFloatSet;->plusAssign(F)V

    return-object v0
.end method

.method public static final varargs mutableFloatSetOf([F)Landroidx/collection/MutableFloatSet;
    .locals 2

    const-string v0, "elements"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 103
    new-instance v0, Landroidx/collection/MutableFloatSet;

    array-length v1, p0

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatSet;-><init>(I)V

    invoke-virtual {v0, p0}, Landroidx/collection/MutableFloatSet;->plusAssign([F)V

    return-object v0
.end method
